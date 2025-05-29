using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public partial class InsulinFilterForm : Form
    {
        private readonly int _patientId;

        public InsulinFilterForm(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;

            btnFilter.Click += BtnFilter_Click;
            dgvInsulin.AutoGenerateColumns = true;

            LoadAllGlucoseData();
        }

        // Tüm kan şekeri kayıtlarını getir
        private void LoadAllGlucoseData()
        {
            string query = @"
                SELECT 
                    measurement_time AS [Tarih], 
                    stage AS [Aşama], 
                    glucose_level AS [Kan Şekeri (mg/dL)]
                FROM glucose_measurements
                WHERE patient_id = @pid
                ORDER BY measurement_time DESC";

            var table = DbHelper.ExecuteQuery(query, new SqlParameter("@pid", _patientId));
            dgvInsulin.DataSource = table;
        }

        // Tarih aralığına göre filtrele
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1);

            string query = @"
                SELECT 
                    measurement_time AS [Tarih], 
                    stage AS [Aşama], 
                    glucose_level AS [Kan Şekeri (mg/dL)]
                FROM glucose_measurements
                WHERE patient_id = @pid 
                  AND measurement_time BETWEEN @start AND @end
                ORDER BY measurement_time DESC";

            var table = DbHelper.ExecuteQuery(query,
                new SqlParameter("@pid", _patientId),
                new SqlParameter("@start", start),
                new SqlParameter("@end", end));

            dgvInsulin.DataSource = table;
        }

        private void InsulinFilterForm_Load(object sender, EventArgs e)
        {
            // İsteğe bağlı
        }
    }
}
