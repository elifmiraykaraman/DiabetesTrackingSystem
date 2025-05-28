using DiabetesTracker.DataAccess;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DiabetesTracker
{
    public partial class AssignPatientForm : MaterialForm
    {
        public AssignPatientForm()
        {
            InitializeComponent();

            // MaterialSkin tema ayarları
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue700,
                Primary.Blue100, Accent.LightBlue200,
                TextShade.WHITE
            );

            this.Load += AssignPatientForm_Load;
            materialBtnAssign.Click += btnAssign_Click;
        }

        private void AssignPatientForm_Load(object sender, EventArgs e)
        {
            // 1) Doktorları çek (role_name = 'Doctor')
            var dtDoc = DbHelper.ExecuteQuery(@"
                SELECT u.user_id, u.full_name
                FROM users u
                JOIN user_roles ur ON u.user_id = ur.user_id
                JOIN roles r       ON ur.role_id = r.role_id
                WHERE r.role_name = 'Doctor'
            ");
            cmbDoctors.DataSource = dtDoc;
            cmbDoctors.DisplayMember = "full_name";
            cmbDoctors.ValueMember = "user_id";

            // 2) Hastaları çek (role_name = 'Patient')
            var dtPat = DbHelper.ExecuteQuery(@"
                SELECT u.user_id, u.full_name
                FROM users u
                JOIN user_roles ur ON u.user_id = ur.user_id
                JOIN roles r       ON ur.role_id = r.role_id
                WHERE r.role_name = 'Patient'
            ");
            cmbPatients.DataSource = dtPat;
            cmbPatients.DisplayMember = "full_name";
            cmbPatients.ValueMember = "user_id";
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            int doctorId = (int)cmbDoctors.SelectedValue;
            int patientId = (int)cmbPatients.SelectedValue;

            const string sql = @"
                INSERT INTO doctor_patient(doctor_id, patient_id, assigned_on)
                VALUES(@doc, @pat, GETDATE());
            ";
            DbHelper.ExecuteNonQuery(
                sql,
                new SqlParameter("@doc", doctorId),
                new SqlParameter("@pat", patientId)
            );

            MessageBox.Show("Hasta başarıyla atandı.", "Tamam",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AssignPatientForm_Load_1(object sender, EventArgs e)
        {
            // Boş bırakılabilir
        }
    }
}
