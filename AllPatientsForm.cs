using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker
{
    public partial class AllPatientsForm : Form
    {
        public AllPatientsForm()
        {
            InitializeComponent();
            // Eventleri ekle
            this.Load += AllPatientsForm_Load;
            btnFilter.Click += BtnFilter_Click;
            cmbGlucoseFilter.SelectedIndexChanged += cmbGlucoseFilter_SelectedIndexChanged;
            cmbSymptoms.SelectedIndexChanged += cmbSymptoms_SelectedIndexChanged;
        }

        // Form açılırken comboboxları ve tabloyu yükle
        private void AllPatientsForm_Load(object sender, EventArgs e)
        {
            cmbGlucoseFilter.Items.Clear();
            cmbGlucoseFilter.Items.Add("Tümü");
            cmbGlucoseFilter.Items.Add("<70");
            cmbGlucoseFilter.Items.Add("70-110");
            cmbGlucoseFilter.Items.Add("111-150");
            cmbGlucoseFilter.Items.Add("151-200");
            cmbGlucoseFilter.Items.Add(">200");
            cmbGlucoseFilter.SelectedIndex = 0;

            LoadSymptoms();
            LoadPatients();
        }

        // Belirti ComboBox'ı doldurur
        private void LoadSymptoms()
        {
            cmbSymptoms.DataSource = null;
            cmbSymptoms.Items.Clear();
            cmbSymptoms.Items.Add("Tümü");
            var dt = DbHelper.ExecuteQuery("SELECT name FROM symptom_types");
            foreach (DataRow row in dt.Rows)
                cmbSymptoms.Items.Add(row["name"].ToString());
            cmbSymptoms.SelectedIndex = 0;
        }

        // Tüm hastaları ve ortalama glukozunu çeker
        private DataTable _allPatientsDt;

        private void LoadPatients()
        {
            string sql = @"
    SELECT 
        u.user_id         AS [ID],
        u.tc_identity     AS [T.C. Kimlik],
        u.full_name       AS [Ad Soyad],
        u.email           AS [E-Posta],
        u.birth_date      AS [Doğum Tarihi],
        u.gender          AS [Cinsiyet],
        ISNULL((
            SELECT AVG(glucose_level)
            FROM dbo.glucose_measurements gm
            WHERE gm.patient_id = u.user_id
        ), 0) AS [OrtalamaKanŞekeri],
        STUFF((
            SELECT ', ' + st.name
            FROM dbo.patient_symptoms ps
            JOIN dbo.symptom_types st ON ps.symptom_type_id = st.symptom_type_id
            WHERE ps.patient_id = u.user_id
            FOR XML PATH('')
        ), 1, 2, '') AS [Belirtiler]
    FROM dbo.users u
    JOIN dbo.user_roles ur ON ur.user_id = u.user_id AND ur.role_id = 2
    ORDER BY u.full_name
    ";
            _allPatientsDt = DbHelper.ExecuteQuery(sql);
            dgvAllPatients.DataSource = _allPatientsDt;
        }


        // Hastanın belirtilerini çeken metot (string olarak döner)
        private string GetPatientSymptoms(int userId)
        {
            // rule_symptoms tablosu user_id içermiyor. Bağlantı recommendation_rules > rule_id ile yapılmalı!
            // Önce hastanın glukoz seviyesine göre kuralları bul, sonra o kuraldaki belirtileri getir

            // Hastanın en son ortalama glukozunu çek
            var dtGlucose = DbHelper.ExecuteQuery(
                "SELECT AVG(glucose_level) AS avgGlucose FROM dbo.glucose_measurements WHERE patient_id = @pid",
                new SqlParameter("@pid", userId)
            );
            decimal avgGlucose = 0;
            if (dtGlucose.Rows.Count > 0 && dtGlucose.Rows[0]["avgGlucose"] != DBNull.Value)
                avgGlucose = Convert.ToDecimal(dtGlucose.Rows[0]["avgGlucose"]);

            // İlgili kuralı bul
            var dtRule = DbHelper.ExecuteQuery(
                "SELECT TOP 1 rule_id FROM dbo.recommendation_rules WHERE @glucose BETWEEN min_glucose AND max_glucose",
                new SqlParameter("@glucose", avgGlucose)
            );
            if (dtRule.Rows.Count == 0)
                return "";

            int ruleId = Convert.ToInt32(dtRule.Rows[0]["rule_id"]);

            // O kurala bağlı tüm belirtileri bul
            var dtSymptoms = DbHelper.ExecuteQuery(
                @"SELECT st.name FROM dbo.rule_symptoms rs
                  JOIN dbo.symptom_types st ON rs.symptom_type_id = st.symptom_type_id
                  WHERE rs.rule_id = @ruleId",
                new SqlParameter("@ruleId", ruleId)
            );
            List<string> belirtiList = new List<string>();
            foreach (DataRow row in dtSymptoms.Rows)
                belirtiList.Add(row["name"].ToString());
            return string.Join(", ", belirtiList);
        }

        // Filtre Butonu
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Belirti filtresi
        private void cmbSymptoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;
            ApplyFilters();
        }

        // Kan şekeri filtresi
        private void cmbGlucoseFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;
            ApplyFilters();
        }

        // Filtreleme işlemi
        private void ApplyFilters()
        {
            if (dgvAllPatients.DataSource == null) return;
            DataView dv = _allPatientsDt.DefaultView;
            DataTable dt = (DataTable)dgvAllPatients.DataSource;
            string symptom = cmbSymptoms.SelectedItem?.ToString() ?? "Tümü";
            string glucoseFilter = cmbGlucoseFilter.SelectedItem?.ToString() ?? "Tümü";
            string filter = "";

            // Belirti filtresi
            if (symptom != "Tümü")
                filter += $"[Belirtiler] LIKE '%{symptom}%'";

            // Kan şekeri filtresi
            if (glucoseFilter != "Tümü")
            {
                if (filter.Length > 0) filter += " AND ";
                switch (glucoseFilter)
                {
                    case "<70": filter += "[OrtalamaKanŞekeri] < 70"; break;
                    case "70-110": filter += "[OrtalamaKanŞekeri] >= 70 AND [OrtalamaKanŞekeri] <= 110"; break;
                    case "111-150": filter += "[OrtalamaKanŞekeri] >= 111 AND [OrtalamaKanŞekeri] <= 150"; break;
                    case "151-200": filter += "[OrtalamaKanŞekeri] >= 151 AND [OrtalamaKanŞekeri] <= 200"; break;
                    case ">200": filter += "[OrtalamaKanŞekeri] > 200"; break;
                }
            }

            dv.RowFilter = filter;
            dgvAllPatients.DataSource = dv.ToTable();
        }
    }
}
