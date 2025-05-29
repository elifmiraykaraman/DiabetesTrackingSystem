using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;


namespace DiabetesTracker
{
    public class GlucoseDietExerciseChartForm : MaterialForm
    {
        private readonly int _patientId;
        private Chart chart;
        private DataGridView dgv;

        public GlucoseDietExerciseChartForm(int patientId)
        {
            _patientId = patientId;
            InitializeMaterialSkin();
            InitializeChart();
            InitializeDataGridView();
            LoadDataAndDrawChart();
        }

        private void InitializeMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700, Primary.Blue200,
                Accent.LightBlue200, TextShade.WHITE);

            this.Text = "Zaman-Diyet-Egzersizli Glikoz Grafiği";
            this.Size = new Size(1200, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeChart()
        {
            chart = new Chart
            {
                Dock = DockStyle.Top,
                Height = 420,
                BackColor = Color.WhiteSmoke,
            };

            ChartArea area = new ChartArea("Main");
            area.AxisX.Title = "Tarih";
            area.AxisY.Title = "Ortalama Glikoz (mg/dL)";
            area.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisX.LabelStyle.Format = "dd.MM.yyyy";
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chart.ChartAreas.Add(area);

            this.Controls.Add(chart);
        }

        private void InitializeDataGridView()
        {
            dgv = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Height = 200,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgv);
        }

        private void LoadDataAndDrawChart()
        {
            string connectionString = "Data Source=AAYSENURR\\SQLEXPRESS;Initial Catalog=DiyabetDB;Integrated Security=True;TrustServerCertificate=True";

            // 1) GRAFİK İÇİN GLİKOZ DEĞERLERİ (her stage ayrı seri)
            string sqlGlucose = @"
                SELECT measurement_date, stage, average_level
                FROM daily_glucose_stage_averages
                WHERE patient_id = @pid
                ORDER BY measurement_date, stage;
            ";

            DataTable dt = new DataTable();
            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sqlGlucose, con))
            {
                cmd.Parameters.AddWithValue("@pid", _patientId);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            // 2) O TARİHLERDE GEÇERLİ DİYET/EĞZERSİZİ GETİR
            string sqlRecommendation = @"
                SELECT 
                    CONVERT(date, recommendation_time) AS Tarih,
                    diet_type_id,
                    exercise_type_id,
                    (SELECT name FROM diet_types WHERE diet_type_id = r.diet_type_id) AS DietName,
                    (SELECT name FROM exercise_types WHERE exercise_type_id = r.exercise_type_id) AS ExerciseName
                FROM doctor_recommendations r
                WHERE patient_id = @pid
                ORDER BY recommendation_time;
            ";
            DataTable dtRec = new DataTable();
            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sqlRecommendation, con))
            {
                cmd.Parameters.AddWithValue("@pid", _patientId);
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dtRec);
                }
            }

            // DEBUG Amaçlı DataGridView'e at
            dgv.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Veri bulunamadı.");
                chart.Series.Clear();
                return;
            }

            // 3) Stage -> Seri ismi ve renk eşlemesi
            var stageColors = new Dictionary<string, Color>
            {
                { "Sabah", Color.CornflowerBlue },
                { "Öğle", Color.OrangeRed },
                { "İkindi", Color.LimeGreen },
                { "Akşam", Color.MediumVioletRed },
                { "Gece", Color.MediumPurple }
            };

            // Her stage için seri oluştur
            chart.Series.Clear();
            foreach (var stage in stageColors.Keys)
            {
                var s = new Series(stage)
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Color = stageColors[stage],
                    XValueType = ChartValueType.Date,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 7
                };
                chart.Series.Add(s);
            }

            // 4) VERİYİ SERİLERE EKLE
            foreach (DataRow row in dt.Rows)
            {
                string stage = row["stage"].ToString();
                DateTime tarih = Convert.ToDateTime(row["measurement_date"]);
                double ort = Convert.ToDouble(row["average_level"]);
                if (chart.Series.Contains(chart.Series[stage]))
                    chart.Series[stage].Points.AddXY(tarih, ort);
            }

            // 5) DİYET/EĞZERSİZİ ARKA PLAN/İŞARET OLARAK EKLE
            // Her bir diyet/egzersiz önerisi için dikey çizgi + Tooltip göster
            foreach (DataRow row in dtRec.Rows)
            {
                DateTime recDate = Convert.ToDateTime(row["Tarih"]);
                string diet = row["DietName"]?.ToString() ?? "-";
                string exercise = row["ExerciseName"]?.ToString() ?? "-";

                var annotation = new VerticalLineAnnotation
                {
                    AxisX = chart.ChartAreas[0].AxisX,
                    AllowMoving = false,
                    ClipToChartArea = chart.ChartAreas[0].Name,
                    IsInfinitive = true,
                    LineColor = Color.Red,
                    LineDashStyle = ChartDashStyle.Dash,
                    LineWidth = 2,
                    X = recDate.ToOADate(),
                    ToolTip = $"Diyet: {diet}\nEgzersiz: {exercise}\nTarih: {recDate:dd.MM.yyyy}"
                };
                chart.Annotations.Add(annotation);
            }

            chart.Invalidate();
        }
    }
}
