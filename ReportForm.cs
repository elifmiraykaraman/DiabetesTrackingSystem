using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public partial class ReportForm : Form
    {
        private readonly int _patientId;
        public ReportForm(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            this.Load += ReportForm_Load;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            int patientId = 1;
            var dt = DbHelper.ExecuteQuery(
                @"SELECT CAST(log_date AS date) AS [Tarih],
                         AVG(glucose_level) AS [Ortalama Şeker]
                  FROM glucose_measurements
                  WHERE patient_id = @pid
                  GROUP BY CAST(log_date AS date)
                  ORDER BY CAST(log_date AS date)",
                new SqlParameter("@pid", patientId)
            );
            dgvReport.DataSource = dt;
        }
    }
}
