using DiabetesTracker.DataAccess;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DiabetesTracker
{
    public partial class RecommendationApproveForm : Form
    {
        private readonly int _patientId;

        public RecommendationApproveForm(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            Load += RecommendationApproveForm_Load;
            btnApprove.Click += BtnApprove_Click;
        }

        private void RecommendationApproveForm_Load(object sender, EventArgs e)
        {
            LoadPendingRecommendations();
        }

        private void LoadPendingRecommendations()
        {
            string sql = @"
SELECT r.recommendation_id, r.glucose, d.name AS diet, e.name AS exercise, r.recommendation_time, r.symptom_entry_date
FROM dbo.doctor_recommendations r
LEFT JOIN dbo.diet_types d ON r.diet_type_id = d.diet_type_id
LEFT JOIN dbo.exercise_types e ON r.exercise_type_id = e.exercise_type_id
WHERE r.patient_id = @pid AND (r.applied = 0 OR r.applied IS NULL)
ORDER BY r.recommendation_time DESC";
            var dt = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _patientId));

            dgvPendingRecommendations.DataSource = dt;
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingRecommendations.CurrentRow == null)
            {
                MessageBox.Show("Onaylamak için bir öneri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int recId = Convert.ToInt32(dgvPendingRecommendations.CurrentRow.Cells["recommendation_id"].Value);
            DbHelper.ExecuteNonQuery(
                "UPDATE dbo.doctor_recommendations SET applied = 1 WHERE recommendation_id = @id",
                new SqlParameter("@id", recId)

            );
            MessageBox.Show("Öneri hastanın sayfasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Listeyi güncelle
            LoadPendingRecommendations();
        }
    }

}
