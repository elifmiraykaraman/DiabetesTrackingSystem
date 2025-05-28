using System;
using System.Data;
using System.Windows.Forms;
using DiabetesTracker.DataAccess;
using Microsoft.Data.SqlClient;

namespace DiabetesTracker
{
    public partial class ExerciseForm : Form
    {
        private readonly int _userId;

        public ExerciseForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadExerciseRecommendations();
        }

        private void LoadExerciseRecommendations()
        {
            // Hem applied (checkbox için), hem de gösterim için Uygulandı string sütunu çekiyoruz
            string sql = @"
                SELECT 
                    r.recommendation_id, 
                    r.symptom_entry_date AS [Tarih], 
                    e.name AS [Egzersiz Türü],
                    r.applied
                FROM doctor_recommendations r
                LEFT JOIN exercise_types e ON r.exercise_type_id = e.exercise_type_id
                WHERE r.patient_id = @pid AND r.exercise_type_id IS NOT NULL
                ORDER BY r.symptom_entry_date DESC";

            DataTable dt = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _userId));
            dgvExercises.DataSource = dt;

            // Yüzdelik hesaplama (applied = 1 olanlar)
            int total = dt.Rows.Count;
            int done = dt.Select("applied = 1").Length;
            int percent = (total > 0) ? (int)(done * 100.0 / total) : 0;
            lblExercisePercent.Text = $"Egzersiz Tamamlama: %{percent}";

            // Checkbox sütununu ekle (sadece 1 kere eklensin)
            if (!dgvExercises.Columns.Contains("chkApplied"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "chkApplied";
                chk.HeaderText = "Yapıldı mı?";
                chk.DataPropertyName = "applied";
                dgvExercises.Columns.Add(chk);
            }

            // Gizli kolonlar
            dgvExercises.Columns["recommendation_id"].Visible = false;
            // dgvExercises.Columns["applied"].Visible = false; // Gerekirse checkbox hariç gizle

            dgvExercises.CellValueChanged -= DgvExercise_CellValueChanged;
            dgvExercises.CellValueChanged += DgvExercise_CellValueChanged;
            dgvExercises.CurrentCellDirtyStateChanged -= DgvExercise_CurrentCellDirtyStateChanged;
            dgvExercises.CurrentCellDirtyStateChanged += DgvExercise_CurrentCellDirtyStateChanged;
        }

        private void DgvExercise_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvExercises.IsCurrentCellDirty)
            {
                dgvExercises.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvExercise_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvExercises.Columns[e.ColumnIndex].Name == "chkApplied")
            {
                var row = dgvExercises.Rows[e.RowIndex];
                int recommendationId = Convert.ToInt32(row.Cells["recommendation_id"].Value);
                bool isChecked = Convert.ToBoolean(row.Cells["chkApplied"].Value);

                string updateSql = "UPDATE doctor_recommendations SET applied = @applied WHERE recommendation_id = @rid";
                DbHelper.ExecuteNonQuery(updateSql,
                    new SqlParameter("@applied", isChecked ? 1 : 0),
                    new SqlParameter("@rid", recommendationId)
                );

                // Yüzdelik oranı güncelle
                LoadExerciseRecommendations();
            }
        }

        private void dgvExercises_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Boş bırakabilirsin
        }
    }
}
