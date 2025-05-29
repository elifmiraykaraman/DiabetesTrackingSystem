using System;
using System.Data;        // DataTable için bu using şart
using System.Windows.Forms;

namespace DiabetesTracker
{
    public partial class PatientListForm : Form
    {
        public PatientListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DoktorMainForm’dan çağrılır; tabloyu bu metotla besleriz.
        /// </summary>
        public void LoadPatients(DataTable dt)
        {
            dgvPatients.DataSource = dt;
        }

        /// <summary>
        /// DoctorMainForm’dan seçili hastayı okumak için DataGridView erişimi.
        /// </summary>
        public DataGridView DgvPatients => this.dgvPatients;
    }
}
