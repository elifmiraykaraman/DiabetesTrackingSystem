using System;
using System.Data;
using System.Windows.Forms;
using DiabetesTracker.DataAccess;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace DiabetesTracker
{
    public partial class PatientMainForm : Form
    {
        private readonly int _userId;

        public PatientMainForm()
        {
            InitializeComponent();
        }

        public PatientMainForm(int userId) : this()
        {
            _userId = userId;
            Text = $"Hasta Paneli – Kullanıcı {_userId}";

            // Menü olaylarını bağla
            kanŞekeriGirişiToolStripMenuItem.Click += (s, e) =>
                ShowFormInPanel(new PatientGlucoseFormm(_userId));

            diyetToolStripMenuItem.Click += (s, e) =>
                ShowFormInPanel(new DietForm(_userId));

            egzersizToolStripMenuItem.Click += (s, e) =>
                ShowFormInPanel(new ExerciseForm(_userId));

            özetGrafikleriToolStripMenuItem.Click += (s, e) =>
            {
                var chartForm = new DailyGlucoseChartForm(_userId);
                chartForm.Show();
            };

            çıkışToolStripMenuItem.Click += (s, e) =>
                Application.Exit();

            // "İnsülin Filtrele" menüsü tıklanınca
            insülinFiltreleToolStripMenuItem.Click += (s, e) =>
            {
                var form = new InsulinFilterForm(_userId);
                form.ShowDialog();
            };

            // Form yüklendiğinde önerileri yükle
            this.Load += PatientMainForm_Load;
        }

        private void PatientMainForm_Load(object sender, EventArgs e)
        {
            LoadApprovedRecommendations();
        }

        private void LoadApprovedRecommendations()
        {
            string sql = @"
                SELECT r.recommendation_time AS [Tarih],
                       d.name AS [Diyet],
                       e.name AS [Egzersiz]
                FROM doctor_recommendations r
                LEFT JOIN diet_types d ON r.diet_type_id = d.diet_type_id
                LEFT JOIN exercise_types e ON r.exercise_type_id = e.exercise_type_id
                WHERE r.patient_id = @pid AND r.applied = 1
                ORDER BY r.recommendation_time DESC";

            DataTable dt = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _userId));
            dgvRecommendations.DataSource = dt;
        }

        private void ShowFormInPanel(Form frm)
        {
            panelContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(frm);
            frm.Show();
        }
        
        private void ShowDietCompletionPercent()
        {
            // Toplam öneri sayısı (diyet)
            string totalSql = @"
        SELECT COUNT(*) FROM doctor_recommendations
        WHERE patient_id = @pid AND applied = 1 AND diet_type_id IS NOT NULL
    ";
            int totalCount = (int)DbHelper.ExecuteScalar(totalSql, new SqlParameter("@pid", _userId));

            // Tamamlanan (yapıldı işaretli) diyet sayısı
            string doneSql = @"
        SELECT COUNT(*) FROM diet_logs
        WHERE patient_id = @pid AND applied = 1
    ";
            int doneCount = (int)DbHelper.ExecuteScalar(doneSql, new SqlParameter("@pid", _userId));

            // Yüzdeyi hesapla
            string result = (totalCount > 0)
                ? $"Diyet Tamamlama: %{(int)((double)doneCount / totalCount * 100)}"
                : "Diyet Tamamlama: %0";

            // Sonucu gösterecek Label ekleyin (örneğin: lblDietPercent)
               lblDietPercent.Text = result;
        }

        private void ShowExerciseCompletionPercent()
        {
            // Toplam öneri sayısı (egzersiz)
            string totalSql = @"
        SELECT COUNT(*) FROM doctor_recommendations
        WHERE patient_id = @pid AND applied = 1 AND exercise_type_id IS NOT NULL
    ";
            int totalCount = (int)DbHelper.ExecuteScalar(totalSql, new SqlParameter("@pid", _userId));

            // Tamamlanan egzersiz sayısı
            string doneSql = @"
        SELECT COUNT(*) FROM exercise_logs
        WHERE patient_id = @pid AND applied = 1
    ";
            int doneCount = (int)DbHelper.ExecuteScalar(doneSql, new SqlParameter("@pid", _userId));

            string result = (totalCount > 0)
                ? $"Egzersiz Tamamlama: %{(int)((double)doneCount / totalCount * 100)}"
                : "Egzersiz Tamamlama: %0";

               lblExercisePercent.Text = result;
        }



        private void egzersizToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void diyetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
    }
}
