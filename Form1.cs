using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public class Form1 : MaterialForm
    {
        // Kontrol alanları
        private MaterialButton btnDoctor;
        private MaterialButton btnPatient;
        private Panel pnlCreds;
        private Label lblCredsTitle;
        private TextBox txtTc;
        private TextBox txtPwd;
        private MaterialButton btnLogin;

        private bool isDoctorSelected = false;

        public Form1()
        {
            // Form temel ayarları
            Text = "Kullanıcı Girişi";
            Size = new Size(800, 450);
            StartPosition = FormStartPosition.CenterScreen;

            // MaterialSkin konfigürasyonu
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Pink200,
                TextShade.WHITE
            );

            // Kontrolleri yarat ve yerleştir
            CreateRoleButtons();
            CreateCredsPanel();
        }

        private void CreateRoleButtons()
        {
            btnDoctor = new MaterialButton
            {
                Text = "Doktor Girişi",
                Location = new Point(200, 80),
                Size = new Size(140, 36),
                HighEmphasis = true
            };
            btnPatient = new MaterialButton
            {
                Text = "Hasta Girişi",
                Location = new Point(360, 80),
                Size = new Size(140, 36),
                HighEmphasis = true
            };

            btnDoctor.Click += Role_Click;
            btnPatient.Click += Role_Click;

            Controls.Add(btnDoctor);
            Controls.Add(btnPatient);
        }

        private void CreateCredsPanel()
        {
            pnlCreds = new Panel
            {
                Size = new Size(500, 180),
                Location = new Point(150, 140),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            lblCredsTitle = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            pnlCreds.Controls.Add(lblCredsTitle);

            // TC kimlik
            var lblTc = new Label
            {
                Text = "T.C. Kimlik:",
                Location = new Point(10, 50),
                AutoSize = true
            };
            txtTc = new TextBox
            {
                Location = new Point(120, 48),
                Size = new Size(200, 28)
            };
            pnlCreds.Controls.Add(lblTc);
            pnlCreds.Controls.Add(txtTc);

            // Şifre
            var lblPwd = new Label
            {
                Text = "Şifre:",
                Location = new Point(10, 90),
                AutoSize = true
            };
            txtPwd = new TextBox
            {
                Location = new Point(120, 88),
                Size = new Size(200, 28),
                UseSystemPasswordChar = true
            };
            pnlCreds.Controls.Add(lblPwd);
            pnlCreds.Controls.Add(txtPwd);

            // Giriş butonu
            btnLogin = new MaterialButton
            {
                Text = "Giriş Yap",
                Location = new Point(340, 120),
                Size = new Size(120, 36),
                HighEmphasis = true
            };
            btnLogin.Click += BtnLogin_Click;
            pnlCreds.Controls.Add(btnLogin);

            Controls.Add(pnlCreds);
        }

        private void Role_Click(object sender, EventArgs e)
        {
            isDoctorSelected = (sender == btnDoctor);

            lblCredsTitle.Text = isDoctorSelected
                ? "Doktor olarak giriş yapın"
                : "Hasta olarak giriş yapın";
            pnlCreds.Visible = true;

            btnDoctor.BackColor = isDoctorSelected ? Color.Indigo : Color.LightGray;
            btnPatient.BackColor = isDoctorSelected ? Color.LightGray : Color.Indigo;
            btnDoctor.ForeColor = btnPatient.ForeColor = Color.White;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var tc = txtTc.Text.Trim();
            var pwd = txtPwd.Text.Trim();
            if (string.IsNullOrWhiteSpace(tc) || string.IsNullOrWhiteSpace(pwd))
            {
                MessageBox.Show("Lütfen hem T.C. kimlik hem şifre girin.",
                                "Eksik Bilgi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var dt = DbHelper.ExecuteQuery(
                "SELECT user_id FROM dbo.users WHERE tc_identity=@tc AND plain_password=@pwd",
                new SqlParameter("@tc", tc),
                new SqlParameter("@pwd", pwd)
            );
            if (dt.Rows.Count != 1)
            {
                MessageBox.Show("T.C. kimlik veya şifre hatalı!",
                                "Giriş Hatası",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);
            Program.SetCurrentUser(userId, isDoctorSelected ? "Doctor" : "Patient");

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
