using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public class DietExerciseTrackForm : MaterialForm
    {
        private MaterialLabel lblPatientName;

        private DataGridView dgvDietHistory;
        private MaterialProgressBar progressBarDiet;
        private MaterialLabel lblDietPercent;

        private DataGridView dgvExerciseHistory;
        private MaterialProgressBar progressBarExercise;
        private MaterialLabel lblExercisePercent;

        private int _patientId;

        public DietExerciseTrackForm(int patientId)
        {
            _patientId = patientId;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

            Text = "Diyet ve Egzersiz Takibi";
            Size = new Size(900, 650);
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponents();

            Load += DietExerciseTrackForm_Load;
        }

        private void InitializeComponents()
        {
            lblPatientName = new MaterialLabel()
            {
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Roboto", 14, FontStyle.Bold),
                Text = "Hasta: "
            };
            Controls.Add(lblPatientName);

            dgvDietHistory = new DataGridView()
            {
                Location = new Point(20, 70),
                Size = new Size(840, 180),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackgroundColor = Color.White,
            };
            Controls.Add(dgvDietHistory);

            progressBarDiet = new MaterialProgressBar()
            {
                Location = new Point(20, 260),
                Size = new Size(600, 25)
            };
            Controls.Add(progressBarDiet);

            lblDietPercent = new MaterialLabel()
            {
                Location = new Point(630, 260),
                Size = new Size(50, 25),
                Text = "%0",
                Font = new Font("Roboto", 12, FontStyle.Bold)
            };
            Controls.Add(lblDietPercent);

            dgvExerciseHistory = new DataGridView()
            {
                Location = new Point(20, 310),
                Size = new Size(840, 180),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackgroundColor = Color.White,
            };
            Controls.Add(dgvExerciseHistory);

            progressBarExercise = new MaterialProgressBar()
            {
                Location = new Point(20, 500),
                Size = new Size(600, 25)
            };
            Controls.Add(progressBarExercise);

            lblExercisePercent = new MaterialLabel()
            {
                Location = new Point(630, 500),
                Size = new Size(50, 25),
                Text = "%0",
                Font = new Font("Roboto", 12, FontStyle.Bold)
            };
            Controls.Add(lblExercisePercent);
        }

        private void DietExerciseTrackForm_Load(object sender, EventArgs e)
        {
            LoadPatientName();
            LoadDietHistory();
            LoadExerciseHistory();
            CalculateAndShowPercentages();
        }

        private void LoadPatientName()
        {
            string sql = "SELECT full_name FROM dbo.users WHERE user_id = @pid";
            var dt = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _patientId));
            if (dt.Rows.Count > 0)
            {
                lblPatientName.Text = "Hasta: " + dt.Rows[0]["full_name"].ToString();
            }
            else
            {
                lblPatientName.Text = "Hasta: Bilinmiyor";
            }
        }

        private void LoadDietHistory()
        {
            // Diyet geçmişi: tarih, diyet adı, yapıldı mı
            string sql = @"
                SELECT 
                    r.recommendation_time AS Tarih,
                    dt.name AS Diyet,
                    CASE WHEN r.applied = 1 THEN 'Evet' ELSE 'Hayır' END AS Uygulandı
                FROM dbo.doctor_recommendations r
                INNER JOIN dbo.diet_types dt ON r.diet_type_id = dt.diet_type_id
                WHERE r.patient_id = @pid AND r.diet_type_id IS NOT NULL
                ORDER BY r.recommendation_time DESC
            ";
            var dtDiet = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _patientId));
            dgvDietHistory.DataSource = dtDiet;

            if (dgvDietHistory.Columns.Contains("Tarih"))
                dgvDietHistory.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        }

        private void LoadExerciseHistory()
        {
            // Egzersiz geçmişi: tarih, egzersiz adı, yapıldı mı
            string sql = @"
                SELECT 
                    r.recommendation_time AS Tarih,
                    et.name AS Egzersiz,
                    CASE WHEN r.applied = 1 THEN 'Evet' ELSE 'Hayır' END AS Uygulandı
                FROM dbo.doctor_recommendations r
                INNER JOIN dbo.exercise_types et ON r.exercise_type_id = et.exercise_type_id
                WHERE r.patient_id = @pid AND r.exercise_type_id IS NOT NULL
                ORDER BY r.recommendation_time DESC
            ";
            var dtExercise = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _patientId));
            dgvExerciseHistory.DataSource = dtExercise;

            if (dgvExerciseHistory.Columns.Contains("Tarih"))
                dgvExerciseHistory.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        }

        private void CalculateAndShowPercentages()
        {
            // Diyet uygulama oranı
            string sqlDietPercent = @"
                SELECT 
                    COUNT(*) AS Total, 
                    SUM(CASE WHEN applied = 1 THEN 1 ELSE 0 END) AS Applied 
                FROM dbo.doctor_recommendations 
                WHERE patient_id = @pid AND diet_type_id IS NOT NULL";
            var dtDietPercent = DbHelper.ExecuteQuery(sqlDietPercent, new SqlParameter("@pid", _patientId));
            int dietPercent = 0;
            if (dtDietPercent.Rows.Count > 0)
            {
                int total = Convert.ToInt32(dtDietPercent.Rows[0]["Total"]);
                int applied = Convert.ToInt32(dtDietPercent.Rows[0]["Applied"]);
                dietPercent = (total > 0) ? (applied * 100 / total) : 0;
            }
            progressBarDiet.Value = dietPercent > 100 ? 100 : dietPercent;
            lblDietPercent.Text = $"%{dietPercent}";

            // Egzersiz uygulama oranı
            string sqlExercisePercent = @"
                SELECT 
                    COUNT(*) AS Total, 
                    SUM(CASE WHEN applied = 1 THEN 1 ELSE 0 END) AS Applied 
                FROM dbo.doctor_recommendations 
                WHERE patient_id = @pid AND exercise_type_id IS NOT NULL";
            var dtExercisePercent = DbHelper.ExecuteQuery(sqlExercisePercent, new SqlParameter("@pid", _patientId));
            int exercisePercent = 0;
            if (dtExercisePercent.Rows.Count > 0)
            {
                int total = Convert.ToInt32(dtExercisePercent.Rows[0]["Total"]);
                int applied = Convert.ToInt32(dtExercisePercent.Rows[0]["Applied"]);
                exercisePercent = (total > 0) ? (applied * 100 / total) : 0;
            }
            progressBarExercise.Value = exercisePercent > 100 ? 100 : exercisePercent;
            lblExercisePercent.Text = $"%{exercisePercent}";
        }
    }
}