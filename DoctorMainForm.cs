using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;
using DiabetesTracker.Services;
using DiabetesTracker;
 // ya da class hangi namespace'de ise

namespace DiabetesTracker
{
    public partial class DoctorMainForm : MaterialForm
    {
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        private readonly int _doctorId = Program.CurrentUserId;

        private byte[] selectedPatientPhotoBytes = null;

        public DoctorMainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue500, Primary.Blue700,
                Primary.Blue100, Accent.LightBlue200,
                TextShade.WHITE
            );

            Load += DoctorMainForm_Load;
            btnAddPatient.Click += btnAddPatient_Click;
            btnDeletePatient.Click += btnDeletePatient_Click;
            pbDoctorPhoto.Click += BtnUploadPhoto_Click;
            textBox1.KeyPress += txtTcIdentity_KeyPress;
            btnApplyRecommendation.Click += btnApplyRecommendation_Click;
            btnBloodSugar.Click += btnBloodSugar_Click;
            btnGetRecommendation.Click += btnGetRecommendation_Click;
            btnViewWarnings.Click += btnViewWarnings_Click;
            btnAllPatients.Click += btnAllPatients_Click;
            btnDietExerciseStats.Click += btnAppGraph_Click;
            btnBloodSugarRelation.Click += btnBloodSugarRelation_Click;
            btnPersonInfo.Click += btnPersonInfo_Click;
            btnChoosePatientPhoto.Click += btnChoosePatientPhoto_Click;
            dgvPatients.SelectionChanged += dgvPatients_SelectionChanged;
            this.btnDietExerciseStats.Click += new System.EventHandler(this.btnDietExerciseStats_Click);


        }

        private void DoctorMainForm_Load(object sender, EventArgs e)
        {
            var dtInfo = DbHelper.ExecuteQuery(
                "SELECT full_name, email, branch, profile_pic FROM dbo.users WHERE user_id = @uid",
                new SqlParameter("@uid", _doctorId)
            );

            if (dtInfo.Rows.Count > 0)
            {
                var row = dtInfo.Rows[0];
                lblDoctorName.Text = "Dr. " + row["full_name"];
                lblDoctorEmail.Text = "E-Posta: " + row["email"];
                lblDoctorBranch.Text = "Uzmanlık: " + row["branch"];

                if (row["profile_pic"] != DBNull.Value)
                {
                    byte[] blob = (byte[])row["profile_pic"];
                    using var ms = new MemoryStream(blob);
                    pbDoctorPhoto.Image = Image.FromStream(ms);
                }
                else
                {
                    pbDoctorPhoto.Image = null;
                }
            }

            LoadPatients();
        }

        private void LoadPatients()
        {
            const string sql = @"
SELECT 
    u.user_id      AS ID,
    u.tc_identity  AS [T.C. Kimlik],
    u.full_name    AS [Ad Soyad],
    u.email        AS [E-Posta],
    u.birth_date   AS [Doğum Tarihi],
    u.gender       AS [Cinsiyet]
FROM dbo.users u
JOIN dbo.doctor_patient dp 
  ON u.user_id = dp.patient_id
WHERE dp.doctor_id = @docId
ORDER BY u.full_name;";
            var dt = DbHelper.ExecuteQuery(sql, new SqlParameter("@docId", _doctorId));
            dgvPatients.DataSource = dt;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // HASTA FOTOĞRAF SEÇME
        private void btnChoosePatientPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Fotoğraf Seç";
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    // Dosya boyutunu kontrol et (ör: 5MB üstü ise uyar)
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length > 5 * 1024 * 1024)
                    {
                        MessageBox.Show("Dosya boyutu 5MB'den büyük! Daha küçük bir görsel seçin.", "Uyarı",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Resim dosyası mı diye ekstra kontrol (uzantı kontrolü yetmez, formatı açmaya çalış)
                    try
                    {
                        selectedPatientPhotoBytes = File.ReadAllBytes(filePath);
                        using (var ms = new MemoryStream(selectedPatientPhotoBytes))
                        {
                            picPatientPhoto.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Geçersiz veya bozuk bir görsel seçtiniz!\n" + ex.Message, "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectedPatientPhotoBytes = null;
                        picPatientPhoto.Image = null;
                    }
                }
            }
        }

        // HASTA EKLEME
        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tc = textBox1.Text.Trim();
            string fullName = textBox2.Text.Trim() + " " + textBox3.Text.Trim();
            string email = textBox4.Text.Trim();
            string gender = comboBox1.SelectedItem.ToString().Substring(0, 1).ToUpper();
            DateTime birth = dateTimePicker1.Value.Date;
            string password = GenerateRandomPassword(8);

            // Duplicate TC check
            var dtDup = DbHelper.ExecuteQuery(
                "SELECT COUNT(*) FROM dbo.users WHERE tc_identity = @tc",
                new SqlParameter("@tc", tc)
            );
            if (Convert.ToInt32(dtDup.Rows[0][0]) > 0)
            {
                MessageBox.Show("Bu TC kimlik numarası ile kayıtlı hasta zaten var.", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert user + photo
            const string sql = @"
INSERT INTO dbo.users (tc_identity, full_name, email, gender, birth_date, plain_password, profile_pic)
VALUES (@tc, @name, @mail, @gender, @birth, @pass, @pic);

DECLARE @newUserId INT = SCOPE_IDENTITY();

INSERT INTO dbo.doctor_patient (doctor_id, patient_id)
VALUES (@docId, @newUserId);

INSERT INTO dbo.user_roles (user_id, role_id)
VALUES (@newUserId, 2);";
            try
            {
                DbHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@tc", tc),
                    new SqlParameter("@name", fullName),
                    new SqlParameter("@mail", email),
                    new SqlParameter("@gender", gender),
                    new SqlParameter("@birth", birth),
                    new SqlParameter("@pass", password),
                    new SqlParameter("@pic", (object)selectedPatientPhotoBytes ?? DBNull.Value),
                    new SqlParameter("@docId", _doctorId)
                );

                try
                {
                    EmailHelper.SendCredentials(email, tc, password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("E‑posta gönderilemedi: " + ex.Message,
                                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                MessageBox.Show("Hasta başarıyla eklendi.", "Bilgi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Temizle
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Today;
                picPatientPhoto.Image = null;
                selectedPatientPhotoBytes = null;

                LoadPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hasta eklenirken hata oluştu:\n" + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hasta fotoğrafını DataGridView seçilince göster
        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow != null)
            {
                int userId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["ID"].Value);
                var dt = DbHelper.ExecuteQuery("SELECT profile_pic FROM dbo.users WHERE user_id=@uid",
                    new SqlParameter("@uid", userId));
                if (dt.Rows.Count > 0 && dt.Rows[0]["profile_pic"] != DBNull.Value)
                {
                    byte[] photoBytes = (byte[])dt.Rows[0]["profile_pic"];
                    using var ms = new MemoryStream(photoBytes);
                    picPatientPhoto.Image = Image.FromStream(ms);
                }
                else
                {
                  
                    picPatientPhoto.Image = null;
                }
            }
        }
       


        // Hasta silme
        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir hasta seçin.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["ID"].Value);
            var dr = MessageBox.Show("Bu hastayı ilişkiden silmek istiyor musunuz?",
                                     "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                DbHelper.ExecuteNonQuery(
                    "DELETE FROM dbo.doctor_patient WHERE doctor_id=@doc AND patient_id=@pat",
                    new SqlParameter("@doc", _doctorId),
                    new SqlParameter("@pat", patientId)
                );
                MessageBox.Show("Hasta ilişkisi silindi.", "Bilgi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hasta silinirken hata oluştu:\n" + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Doktor profil fotoğrafı yükle
        private void btnBloodSugarRelation_Click(object sender, EventArgs e)
        {
            // Seçili hasta kontrolü
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir hasta seçin!");
                return;
            }

            // Seçili hastanın id'sini al
            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["ID"].Value);

            // Grafik formunu aç
            var frm = new GlucoseDietExerciseChartForm(patientId);
            frm.ShowDialog();
        }

        private void BtnUploadPhoto_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Filter = "JPEG|*.jpg;*.jpeg|PNG|*.png" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            byte[] data = File.ReadAllBytes(dlg.FileName);
            DbHelper.ExecuteNonQuery(
                "UPDATE dbo.users SET profile_pic = @pic WHERE user_id = @uid",
                new SqlParameter("@pic", data),
                new SqlParameter("@uid", _doctorId)
            );
            MessageBox.Show("Profil fotoğrafı güncellendi.", "Bilgi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            DoctorMainForm_Load(this, EventArgs.Empty);
        }

        private void txtTcIdentity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Diğer butonlar (hepsi aktif ve boş bile olsa var)
        private void btnApplyRecommendation_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show("Hasta seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int patientId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["ID"].Value);

            // Formu aç
            using (var approveForm = new RecommendationApproveForm(patientId))
            {
                approveForm.ShowDialog(this);
            }
        }

        private void btnBloodSugar_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show("Önce bir hasta seçin.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["ID"].Value);
            using var rpt = new PatientGlucoseReportForm(patientId);
            rpt.ShowDialog(this);
        }

        private void btnGetRecommendation_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show("Önce bir hasta seçin.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int patientId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["ID"].Value);

            using var form = new SymptomForm(patientId);
            form.ShowDialog(this);
        }

        private void btnViewWarnings_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show("Önce bir hasta seçin.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int patientId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["ID"].Value);
            var dt = DbHelper.ExecuteQuery(
                @"SELECT TOP 1 glucose_level, measurement_time
                  FROM dbo.glucose_measurements
                  WHERE patient_id = @pid
                  ORDER BY measurement_time DESC",
                new SqlParameter("@pid", patientId)
            );
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Veri bulunamadı.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            decimal level = Convert.ToDecimal(dt.Rows[0]["glucose_level"]);
            DateTime time = Convert.ToDateTime(dt.Rows[0]["measurement_time"]);
            string key = AlertMessages.GetThresholdKey(level);
            var (type, msg) = AlertMessages.Thresholds[key];
            MessageBox.Show(
                $"Son Ölçüm: {level} mg/dL ({time:dd.MM.yyyy HH:mm})\n\n" +
                $"Uyarı Tipi: {type}\n{msg}",
                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning
            );
        }

        private void btnAllPatients_Click(object sender, EventArgs e)
        {
            using var form = new AllPatientsForm();
            form.ShowDialog(this);
        }

        private void btnAppGraph_Click(object sender, EventArgs e)
        {
            // Implement as needed...
        }



        // Doktor ana formunda (ör: DoctorMainForm.cs)
        private void btnDietExerciseStats_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen tablodan bir hasta seçin!");
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["ID"].Value);

            DietExerciseTrackForm frm = new DietExerciseTrackForm(patientId);
            frm.ShowDialog();
        }

        private int GetSelectedPatientId()
        {
            if (dgvPatients.CurrentRow == null)
                return -1;

            // "ID" sütunu sizin DataGridView'de hastanın user_id'si olabilir.
            // Burada ID sütununu alıyoruz.
            if (int.TryParse(dgvPatients.CurrentRow.Cells["ID"].Value?.ToString(), out int patientId))
            {
                return patientId;
            }

            return -1;
        }



       


        private void btnPersonInfo_Click(object sender, EventArgs e)
        {
            // DataGridView'da bir satır seçili mi kontrol et
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show("Lütfen önce bir hasta seçin.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen hastanın ID'sini al
            int patientId = Convert.ToInt32(dgvPatients.CurrentRow.Cells["ID"].Value);

            // Hasta bilgi formunu aç
            using (var infoForm = new PatientInfoForm(patientId))
            {
                infoForm.ShowDialog(this);
            }
        }


        private string GenerateRandomPassword(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rng = new Random();
            return new string(Enumerable
                .Range(0, length)
                .Select(_ => chars[rng.Next(chars.Length)])
                .ToArray());
        }

    }
}
