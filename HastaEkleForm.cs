using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;  // EmailHelper

namespace DiabetesTracker
{
    public partial class HastaEkleForm : Form
    {
        private byte[] selectedProfilePicBytes = null; // Fotoğraf byte array

        public HastaEkleForm()
        {
            InitializeComponent();
            this.Load += HastaEkleForm_Load;
         ///   btnChoosePhoto.Click += btnChoosePhoto_Click; // Fotoğraf seçme butonuna event bağla
        }

        private void HastaEkleForm_Load(object sender, EventArgs e)
        {
            cmbGender.Items.AddRange(new[] { "E", "K" });
            cmbGender.SelectedIndex = 0;
            txtTc.MaxLength = 11;
            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;
        }

        // FOTOĞRAF SEÇME
        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Fotoğraf Seç";
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;
             ///       picProfile.Image = Image.FromFile(path); // PictureBox'ta göster

                    // Dosyayı byte[]'a çevir
                    selectedProfilePicBytes = File.ReadAllBytes(path);
                }
            }
        }

        // KAYDET
        private async void btnSave_Click(object sender, EventArgs e)
        {
            string tc = txtTc.Text.Trim();
            string name = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime bd = dtpBirthDate.Value.Date;
            char gender = cmbGender.SelectedItem.ToString()[0];

            // Doğrulamalar
            if (!Regex.IsMatch(tc, @"^\d{11}$"))
            {
                MessageBox.Show("T.C. Kimlik 11 rakam olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Lütfen ad soyad girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Lütfen geçerli e‑posta girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şifre oluştur
            string plainPwd;
            byte[] hashBytes;
            GenerateAndHashPassword(10, out plainPwd, out hashBytes);

            // DB işlemleri
            string connStr = ConfigurationManager.ConnectionStrings["DiabetesConn"].ConnectionString;
            int newUserId;

            using (var conn = new SqlConnection(connStr))
            {
                await conn.OpenAsync();
                using var tran = conn.BeginTransaction();
                try
                {
                    const string sqlInsertUser = @"
INSERT INTO dbo.users
    (tc_identity, password_hash, plain_password,
     full_name, birth_date, gender, email, profile_pic)
VALUES
    (@tc, @pwdHash, @plainPwd,
     @name, @bd, @g, @mail, @profile_pic);
SELECT CAST(SCOPE_IDENTITY() AS int);";

                    using (var cmd = new SqlCommand(sqlInsertUser, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@tc", tc);
                        cmd.Parameters.AddWithValue("@pwdHash", hashBytes);
                        cmd.Parameters.AddWithValue("@plainPwd", plainPwd);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@bd", bd);
                        cmd.Parameters.AddWithValue("@g", gender);
                        cmd.Parameters.AddWithValue("@mail", email);
                        cmd.Parameters.Add("@profile_pic", System.Data.SqlDbType.VarBinary).Value =
                            (object)selectedProfilePicBytes ?? DBNull.Value;

                        newUserId = (int)await cmd.ExecuteScalarAsync();
                    }

                    using (var cmd = new SqlCommand(
                        "INSERT INTO dbo.user_roles(user_id, role_id) VALUES(@u, 2)", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@u", newUserId);
                        await cmd.ExecuteNonQueryAsync();
                    }

                    using (var cmd = new SqlCommand(
                        "INSERT INTO dbo.doctor_patient(doctor_id, patient_id) VALUES(@d, @p)", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@d", Program.CurrentUserId);
                        cmd.Parameters.AddWithValue("@p", newUserId);
                        await cmd.ExecuteNonQueryAsync();
                    }

                    tran.Commit();
                }
                catch (SqlException dbEx)
                {
                    tran.Rollback();
                    MessageBox.Show($"Veritabanı hatası: {dbEx.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Mail gönder
            try
            {
                EmailHelper.SendCredentials(email, tc, plainPwd);
                MessageBox.Show("Giriş şifresi hastaya e‑posta ile gönderildi.",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception mailEx)
            {
                MessageBox.Show($"E‑posta gönderilemedi:\n{mailEx.Message}",
                    "E‑posta Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Close();
        }

        // Şifre üretme yardımcıları
        private static void GenerateAndHashPassword(int length, out string plainPwd, out byte[] hashBytes)
        {
            plainPwd = GenerateRandomPassword(length);
            using var sha = SHA256.Create();
            hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainPwd));
        }

        private static string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var sb = new StringBuilder();
            using var rng = RandomNumberGenerator.Create();
            byte[] buf = new byte[4];
            while (sb.Length < length)
            {
                rng.GetBytes(buf);
                uint num = BitConverter.ToUInt32(buf, 0);
                sb.Append(chars[(int)(num % (uint)chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
