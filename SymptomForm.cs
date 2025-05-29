using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.Services;

namespace DiabetesTracker
{
    public partial class SymptomForm : Form
    {
        private readonly RecommendationService _recSvc;
        private readonly int _patientId;

        public SymptomForm(int patientId)
        {
            InitializeComponent();
            _recSvc = new RecommendationService();
            _patientId = patientId;
            btnRecommend.Click += BtnRecommend_Click; // Doğru event binding!
        }

        private void BtnRecommend_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGlucose.Text.Trim(), out int glucose))
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var symptomIds = grpSymptoms.Controls
                .OfType<CheckBox>()
                .Where(cb => cb.Checked)
                .Select(cb => int.Parse(cb.Tag.ToString()))
                .ToList();

            if (symptomIds.Count == 0)
            {
                MessageBox.Show("En az bir belirti seçmelisiniz.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rec = _recSvc.GetRecommendation(glucose, symptomIds);

            var expectedIds = new List<int> { 4, 6, 8 };
            bool tamEslesme = (glucose >= 110 && glucose <= 180)
                              && expectedIds.All(id => symptomIds.Contains(id))
                              && symptomIds.Count == 3;

            DateTime selectedDate = dtpSymptomDate.Value.Date;

            if (rec.HasValue)
            {
                if (tamEslesme)
                {
                    lblResult.Text = $"Diyet: {rec.Value.Diet}\r\nEgzersiz: Yürüyüş";
                    // Gerekirse burada özel olarak egzersiz ID'sini elle set edebilirsin.
                }
                else
                {
                    lblResult.Text = $"Diyet: {rec.Value.Diet}\r\nEgzersiz: {(string.IsNullOrEmpty(rec.Value.Exercise) ? "Yok" : rec.Value.Exercise)}";
                }
                SaveDoctorRecommendation(rec.Value, glucose, selectedDate);
            }
            else
            {
                lblResult.Text = "Bu kombinasyon için kural bulunamadı.";
            }
        }

        private void SaveDoctorRecommendation(Recommendation rec, int glucose, DateTime symptomDate)
        {
            var connString = ConfigurationManager
                  .ConnectionStrings["DiabetesConn"]
                  .ConnectionString;

            int doctorId = Program.CurrentUserId;
            int patientId = _patientId;
            var sql = @"
INSERT INTO dbo.doctor_recommendations
  (doctor_id, patient_id, rule_id, glucose, diet_type_id, exercise_type_id, recommendation_time, symptom_entry_date)
VALUES
  (@doc, @pat, @rule, @glu, @diet, @exercise, @symptomDate, @symptomDate);";


            using var conn = new SqlConnection(connString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@doc", doctorId);
            cmd.Parameters.AddWithValue("@pat", patientId);
            cmd.Parameters.AddWithValue("@rule", rec.RuleId);
            cmd.Parameters.AddWithValue("@glu", glucose);
            cmd.Parameters.AddWithValue("@diet", rec.DietTypeId);
            cmd.Parameters.AddWithValue("@exercise", rec.ExerciseTypeId.HasValue ? (object)rec.ExerciseTypeId.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@symptomDate", symptomDate);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
