using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public partial class GlucoseForm : Form
    {
        private readonly int _patientId;

        public GlucoseForm(int patientId)
        {
            InitializeComponent();

            _patientId = patientId;

            // Event bağlantıları
            Load += GlucoseForm_Load;
            btnGluSave.Click += BtnGluSave_Click;
        }

        private void GlucoseForm_Load(object sender, EventArgs e)
        {
            // Form açıldığında verileri yükle
            RefreshGrid();
        }

        private void BtnGluSave_Click(object sender, EventArgs e)
        {
            // 1) Kullanıcı girişi kontrolü
            if (!decimal.TryParse(txtGluInput.Text.Trim(), out var level))
            {
                MessageBox.Show("Lütfen geçerli bir glukoz seviyesi girin.", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Veritabanına ekleme
            const string insertSql = @"
                INSERT INTO dbo.glucose_measurements
                  (patient_id, measurement_time, glucose_level)
                VALUES
                  (@pid, @time, @level)";
            DbHelper.ExecuteNonQuery(
                insertSql,
                new SqlParameter("@pid", _patientId),
                new SqlParameter("@time", dtpGluTime.Value),
                new SqlParameter("@level", level)
            );

            MessageBox.Show("Kan şekeri kaydedildi.", "Bilgi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3) Grid & ortalamayı yenile
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            // 1) SQL’den son değerleri çek
            var dt = DbHelper.ExecuteQuery(
               @"SELECT 
                    measurement_id    AS [ID],
                    measurement_time  AS [Tarih],
                    glucose_level     AS [Seviye]
                 FROM dbo.glucose_measurements
                 WHERE patient_id = @pid
                 ORDER BY measurement_time DESC",
               new SqlParameter("@pid", _patientId)
            );

            // 2) Grid’e data bağla
            dgvGlucose.DataSource = dt;

            // 3) Ortalama hesapla
            decimal avg = 0m;
            if (dt.Rows.Count > 0)
            {
                // LINQ kullanarak "Seviye" kolonunun ortalamasını al
                avg = dt.AsEnumerable()
                        .Average(r => r.Field<decimal>("Seviye"));
            }

            // 4) Label’a yaz
            lblDailyAverage.Text = $"Günlük Ortalama: {avg:F2} mg/dL";
        }
    }
}
