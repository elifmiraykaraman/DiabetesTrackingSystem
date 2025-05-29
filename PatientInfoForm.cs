using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public partial class PatientInfoForm : Form
    {
        public PatientInfoForm(int patientId)
        {
            InitializeComponent();
            LoadPatientInfo(patientId);
        }

        private void LoadPatientInfo(int userId)
        {
            var dt = DbHelper.ExecuteQuery(
                @"SELECT tc_identity, full_name, email, birth_date, gender, profile_pic 
          FROM dbo.users WHERE user_id = @uid",
                new SqlParameter("@uid", userId)
            );

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                lblTc.Text = "TC: " + row["tc_identity"].ToString();
                lblName.Text = "Ad Soyad: " + row["full_name"].ToString();
                lblEmail.Text = "E-posta: " + row["email"].ToString();
                lblBirth.Text = "Doğum Tarihi: " + Convert.ToDateTime(row["birth_date"]).ToString("dd.MM.yyyy");

                // Cinsiyet K/E → Kadın/Erkek çevir
                string gender = row["gender"].ToString();
                lblGender.Text = "Cinsiyet: " + (gender == "K" ? "Kadın" : gender == "E" ? "Erkek" : gender);

                // Fotoğraf ata
                if (row["profile_pic"] != DBNull.Value)
                {
                    try
                    {
                        byte[] img = (byte[])row["profile_pic"];
                        if (img != null && img.Length > 0)
                        {
                            using (var ms = new MemoryStream(img))
                            {
                                picPhoto.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            picPhoto.Image = null; // Boşsa hiç resim gösterme
                        }
                    }
                    catch
                    {
                        picPhoto.Image = null; // Hatalı/bozuk dosya varsa gösterme
                    }
                }
                else
                {
                    picPhoto.Image = null;
                }

            }
            else
            {
                MessageBox.Show("Hasta bilgisi bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picPhoto_Click(object sender, EventArgs e)
        {

        }
    }
}
