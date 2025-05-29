using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public partial class ÖneriGirisForm : Form
    {
        private readonly int _doctorId;
        private readonly int _patientId;

        public ÖneriGirisForm(int doctorId, int patientId)
        {
            InitializeComponent();
            _doctorId = doctorId;
            _patientId = patientId;

            // **Event’leri bağla**
            this.Load += ÖneriGirisForm_Load;
            btnSave.Click += BtnSave_Click;
        }

        // **Form Load olayında dropdown ve listeyi yükle**
        private void ÖneriGirisForm_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadRecommendations();
        }

        // **Dropdown’ları doldur**
        private void LoadDropdowns()
        {
            var dtDiet = DbHelper.ExecuteQuery(
                "SELECT diet_type_id, name AS diet_name FROM diet_types");
            cmbDietType.DataSource = dtDiet;
            cmbDietType.ValueMember = "diet_type_id";
            cmbDietType.DisplayMember = "diet_name";

            var dtEx = DbHelper.ExecuteQuery(
                "SELECT exercise_type_id, name AS exercise_name FROM exercise_types");
            cmbExerciseType.DataSource = dtEx;
            cmbExerciseType.ValueMember = "exercise_type_id";
            cmbExerciseType.DisplayMember = "exercise_name";
        }

        // **Kaydet butonuna tıklanınca**
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbDietType.SelectedValue == null || cmbExerciseType.SelectedValue == null)
            {
                MessageBox.Show("Lütfen diyet ve egzersiz türü seçin.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const string sql = @"
                INSERT INTO dbo.doctor_recommendations
                  (doctor_id, patient_id, diet_type_id, exercise_type_id, note, recommendation_time)
                VALUES
                  (@doc, @pat, @dType, @eType, @note, GETDATE())";

            DbHelper.ExecuteNonQuery(
                sql,
                new SqlParameter("@doc", _doctorId),
                new SqlParameter("@pat", _patientId),
                new SqlParameter("@dType", cmbDietType.SelectedValue),
                new SqlParameter("@eType", cmbExerciseType.SelectedValue),
                new SqlParameter("@note", txtNote.Text.Trim())
            );

            MessageBox.Show("Öneri kaydedildi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadRecommendations();
        }

        // **Geçmiş önerileri listele**
        private void LoadRecommendations()
        {
            var dt = DbHelper.ExecuteQuery(
              @"SELECT 
                   r.recommendation_id    AS [#],
                   dt.name                AS [Diyet],
                   et.name                AS [Egzersiz],
                   r.note                 AS [Not],
                   r.recommendation_time  AS [Tarih]
                FROM dbo.doctor_recommendations r
                JOIN dbo.diet_types dt     ON r.diet_type_id     = dt.diet_type_id
                JOIN dbo.exercise_types et ON r.exercise_type_id = et.exercise_type_id
               WHERE r.doctor_id  = @doc
                 AND r.patient_id = @pat
               ORDER BY r.recommendation_time DESC",
              new SqlParameter("@doc", _doctorId),
              new SqlParameter("@pat", _patientId)
            );
            dgvRecommendations.DataSource = dt;
        }
    }
}
