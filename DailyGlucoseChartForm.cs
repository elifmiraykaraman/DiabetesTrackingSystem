using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public partial class DailyGlucoseChartForm : Form
    {
        private readonly int _patientId;
        private Chart chart1;

        public DailyGlucoseChartForm(int patientId)
        {
            _patientId = patientId;
            InitializeComponents();
            LoadChartData();
        }

        private void InitializeComponents()
        {
            this.Text = "Günlük Kan Şekeri Ortalamaları";
            this.Size = new Size(800, 500);

            chart1 = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            ChartArea area = new ChartArea("Main");
            area.AxisX.Title = "Tarih";
            area.AxisY.Title = "Ortalama Glikoz (mg/dL)";
            area.AxisX.LabelStyle.Format = "dd.MM.yyyy";
            area.AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            area.AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            chart1.ChartAreas.Add(area);

            this.Controls.Add(chart1);
        }

        private void LoadChartData()
        {
            string sql = @"
                SELECT
                    CONVERT(date, measurement_time) AS Tarih,
                    AVG(glucose_level) AS OrtalamaGlikoz
                FROM glucose_measurements
                WHERE patient_id = @pid
                GROUP BY CONVERT(date, measurement_time)
                ORDER BY Tarih;
            ";

            var dt = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _patientId));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Grafik için yeterli veri bulunamadı.");
                return;
            }

            var series = new Series("Ortalama Glikoz")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.MediumSlateBlue,
                XValueType = ChartValueType.Date
            };

            foreach (DataRow row in dt.Rows)
            {
                DateTime tarih = Convert.ToDateTime(row["Tarih"]);
                double ort = Convert.ToDouble(row["OrtalamaGlikoz"]);
                series.Points.AddXY(tarih, ort);
            }

            chart1.Series.Clear();
            chart1.Series.Add(series);
        }
    }
}