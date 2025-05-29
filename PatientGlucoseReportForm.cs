using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public partial class PatientGlucoseReportForm : Form
    {
        private readonly int _patientId;

        public PatientGlucoseReportForm(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            this.Text = $"Hasta #{patientId} - Glukoz Raporu";
            this.Load += PatientGlucoseReportForm_Load;
        }

        private void PatientGlucoseReportForm_Load(object sender, EventArgs e)
        {
            const string sql = @"
SELECT 
  gm.stage              AS [Aşama],
  CAST(gm.measurement_time AS date) AS [Tarih],
  CONVERT(varchar(5), gm.measurement_time, 108) AS [Saat],
  gm.glucose_level      AS [Seviye],
  dga.average_level     AS [Günlük Ortalama]
FROM dbo.glucose_measurements gm
LEFT JOIN dbo.daily_glucose_stage_averages dga
  ON gm.patient_id = dga.patient_id
  AND CAST(gm.measurement_time AS date) = dga.measurement_date
  AND gm.stage = dga.stage
WHERE gm.patient_id = @pid
ORDER BY gm.measurement_time;";

            var dt = DbHelper.ExecuteQuery(
                sql,
                new SqlParameter("@pid", _patientId)
            );

            dgvReport.DataSource = dt;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
