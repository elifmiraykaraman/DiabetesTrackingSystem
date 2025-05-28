using System;
using System.Data;
using System.Windows.Forms;
using DiabetesTracker.DataAccess;
using Microsoft.Data.SqlClient;

namespace DiabetesTracker
{
    public partial class DietForm : Form
    {
        private readonly int _userId;

        public DietForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadDietRecommendations();
        }

        private void LoadDietRecommendations()
        {
            string sql = @"
        SELECT 
            dr.recommendation_id,
            dr.recommendation_time AS [Tarih],
            dt.name AS [Diyet],
            dr.note AS [Not],
            (CASE WHEN dr.applied = 1 THEN 'Evet' ELSE 'Hayır' END) AS [UygulandıMı]
        FROM doctor_recommendations dr
        LEFT JOIN diet_types dt ON dr.diet_type_id = dt.diet_type_id
        WHERE dr.patient_id = @pid AND dr.diet_type_id IS NOT NULL
        ORDER BY dr.recommendation_time DESC";

            DataTable dt = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _userId));
            dgvDiet.AutoGenerateColumns = true;
            dgvDiet.DataSource = dt;

            // Checkbox sütunu ekle (eğer yoksa)
            if (!dgvDiet.Columns.Contains("chkApplied"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "chkApplied";
                chk.HeaderText = "Uygulandı mı?";
                chk.DataPropertyName = "UygulandıMı";
                chk.TrueValue = "Evet";
                chk.FalseValue = "Hayır";
                dgvDiet.Columns.Add(chk);
            }

            // Gizli sütunlar
            if (dgvDiet.Columns.Contains("recommendation_id"))
                dgvDiet.Columns["recommendation_id"].Visible = false;

            // Eventleri ekle
            dgvDiet.CellValueChanged -= DgvDiet_CellValueChanged;
            dgvDiet.CellValueChanged += DgvDiet_CellValueChanged;
            dgvDiet.CurrentCellDirtyStateChanged -= DgvDiet_CurrentCellDirtyStateChanged;
            dgvDiet.CurrentCellDirtyStateChanged += DgvDiet_CurrentCellDirtyStateChanged;

            // Yüzde hesaplama
            int total = dt.Rows.Count;
            int done = dt.Select("[UygulandıMı]='Evet'").Length;
            int percent = (total > 0) ? (int)(done * 100.0 / total) : 0;

            lblDietPercent.Text = $"Diyet Tamamlama: %{percent}";
        }

        private void DgvDiet_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDiet.IsCurrentCellDirty)
            {
                dgvDiet.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvDiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDiet.Columns[e.ColumnIndex].Name == "chkApplied")
            {
                var row = dgvDiet.Rows[e.RowIndex];
                int recommendationId = Convert.ToInt32(row.Cells["recommendation_id"].Value);
                bool isChecked = Convert.ToString(row.Cells["chkApplied"].Value) == "Evet";

                string updateSql = "UPDATE doctor_recommendations SET applied_diet = @applied WHERE recommendation_id = @rid";
                DbHelper.ExecuteNonQuery(updateSql,
                    new SqlParameter("@applied", isChecked ? 1 : 0),
                    new SqlParameter("@rid", recommendationId)
                );
                LoadDietRecommendations();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Boş bırakılabilir
        }
    }
}
