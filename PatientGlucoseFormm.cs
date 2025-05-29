using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;
using DiabetesTracker.Services;

namespace DiabetesTracker
{
    public partial class PatientGlucoseFormm : Form
    {
        
        private readonly int _patientId;
        private readonly List<string> _stagesOrder = new() { "Sabah", "Öğle", "İkindi", "Akşam", "Gece" };

        private readonly Dictionary<string, (TimeSpan Start, TimeSpan End)> _windows = new()
        {
            { "Sabah",  (TimeSpan.FromHours(7),  TimeSpan.FromHours(9)) },
            { "Öğle",   (TimeSpan.FromHours(12), TimeSpan.FromHours(13)) },
            { "İkindi", (TimeSpan.FromHours(15), TimeSpan.FromHours(16)) },
            { "Akşam",  (TimeSpan.FromHours(18), TimeSpan.FromHours(19)) },
            { "Gece",   (TimeSpan.FromHours(22), TimeSpan.FromHours(23)) },
        };

        private Dictionary<string, decimal> _stageAverages = new();

        public PatientGlucoseFormm(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;

            Load += OnLoad;
            btnSaveAll.Click += OnSaveAll;
            comboStage.SelectedIndexChanged += OnStageChanged;
            dtpEntryDate.ValueChanged += (s, e) => EvaluateDayMeasurements(dtpEntryDate.Value.Date);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (dgvMeasurements.Columns.Count == 0)
            {
                dgvMeasurements.Columns.Add("Stage", "Aşama");
                dgvMeasurements.Columns.Add("Date", "Tarih");
                dgvMeasurements.Columns.Add("Time", "Saat");
                dgvMeasurements.Columns.Add("Level", "Seviye");
                dgvMeasurements.Columns.Add("Average", "Ortalama (mg/dL)");
                dgvMeasurements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            ResetForm();
            LoadHistory();
            EvaluateDayMeasurements(dtpEntryDate.Value.Date);
        }

        private void ResetForm()
        {
            nudSabah.Value = nudOgle.Value = nudIkindi.Value = nudAksam.Value = nudGece.Value = 0;
            comboStage.Items.Clear();
            comboStage.Text = "";
            lblStage.Text = "Seçim Yapınız";
            lblSuggestion.Text = "İnsülin Önerisi: –";
            dgvMeasurements.Rows.Clear();
            _stageAverages = new();
        }

        private void OnSaveAll(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpEntryDate.Value.Date;

            var slots = new[]
            {
                new { Stage="Sabah",  Picker=dtpSabahSaat, Level=nudSabah },
                new { Stage="Öğle",   Picker=dtpOgleTime,  Level=nudOgle },
                new { Stage="İkindi", Picker=dtpIkindiTime,Level=nudIkindi },
                new { Stage="Akşam",  Picker=dtpAksamTime, Level=nudAksam },
                new { Stage="Gece",   Picker=dtpGeceTime,  Level=nudGece },
            };
            foreach (var stage in _stagesOrder)
            {
                if (_stageAverages.TryGetValue(stage, out var avg))
                {
                    var suggestion = GetInsulinSuggestion(avg);

                    // Görselde göster
                    if (stage == "Sabah") lblInsulinSabah.Text = $"Sabah İnsülini: {suggestion}";
                    if (stage == "Öğle") lblInsulinOgle.Text = $"Öğle İnsülini: {suggestion}";
                    if (stage == "İkindi") lblInsulinIkindi.Text = $"İkindi İnsülini: {suggestion}";
                    if (stage == "Akşam") lblInsulinAksam.Text = $"Akşam İnsülini: {suggestion}";
                    if (stage == "Gece") lblInsulinGece.Text = $"Gece İnsülini: {suggestion}";

                    // Eğer öneri ml içeriyorsa
                    if (suggestion.Contains("ml"))
                    {
                        decimal ml = Convert.ToDecimal(suggestion.Replace("ml", "").Trim());



                        DbHelper.ExecuteNonQuery(
                            @"INSERT INTO dbo.insulin_logs (patient_id, log_date, stage, insulin_amount)
      VALUES (@pid, @date, @stage, @amount);",
                            new SqlParameter("@pid", _patientId),
                            new SqlParameter("@date", dtpEntryDate.Value.Date),  // ✅ SEÇİLEN TARİH
                            new SqlParameter("@stage", stage),
                            new SqlParameter("@amount", ml)
                        );
                    }
                }
            }


            const string insertMeasurement = @"
INSERT INTO dbo.glucose_measurements
  (patient_id, measurement_time, glucose_level, stage, stage_order, is_valid)
VALUES
  (@pid, @time, @level, @stage, @order, @isvalid);";

            int savedCount = 0, validCount = 0;
            List<string> missingStages = new();
            List<string> outOfWindowStages = new();

            // Aynı gün-aşama varsa sil
            foreach (var s in slots)
            {
                DbHelper.ExecuteNonQuery(
                    @"DELETE FROM dbo.glucose_measurements 
                      WHERE patient_id = @pid AND CONVERT(date, measurement_time) = @date AND stage = @stage",
                    new SqlParameter("@pid", _patientId),
                    new SqlParameter("@date", selectedDate),
                    new SqlParameter("@stage", s.Stage)
                );
            }

            foreach (var s in slots)
            {
                decimal level = s.Level.Value;
                if (level < 0) continue;

                DateTime dt = selectedDate + s.Picker.Value.TimeOfDay;
                bool isInWindow = IsWithinStageWindow(s.Stage, s.Picker.Value.TimeOfDay);

                if (level == 0)
                    missingStages.Add(s.Stage);

                if (level > 0 && !isInWindow)
                {
                    var w = _windows[s.Stage];
                    outOfWindowStages.Add($"{s.Stage} ({dt:HH:mm} - Geçerli: {w.Start:hh\\:mm}-{w.End:hh\\:mm})");
                }

                DbHelper.ExecuteNonQuery(
                    insertMeasurement,
                    new SqlParameter("@pid", _patientId),
                    new SqlParameter("@time", dt),
                    new SqlParameter("@level", level),
                    new SqlParameter("@stage", s.Stage),
                    new SqlParameter("@order", _stagesOrder.IndexOf(s.Stage) + 1),
                    new SqlParameter("@isvalid", (isInWindow && level > 0) ? 1 : 0)
                );
                if (isInWindow && level > 0)
                    validCount++;
                savedCount++;
            }

            // Günlük aşama ortalamalarını sırayla hesaplayıp kaydet
            SaveDailyStageAverages(selectedDate);

            // Eksik ölçüm uyarısı
            foreach (var stg in missingStages)
                MessageBox.Show($"{stg}: Ölçüm eksik! Ortalama alınırken bu ölçüm hesaba katılmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Saat dışı ölçüm uyarısı
            foreach (var s in outOfWindowStages)
                MessageBox.Show($"{s}: Saat dışında! Ortalama alınırken bu ölçüm hesaba katılmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (validCount < 3)
                MessageBox.Show("Yetersiz veri! Ortalama hesaplaması güvenilir değildir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            MessageBox.Show($"{savedCount} ölçüm kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
            LoadHistory();
            EvaluateDayMeasurements(dtpEntryDate.Value.Date);
        }

        // Her aşama için: Sırayla - sadece o aşamaya kadar olan valid ölçümlerin ortalamasını al
        private void SaveDailyStageAverages(DateTime date)
        {
            var measurements = GetDayMeasurements(date);

            for (int i = 0; i < _stagesOrder.Count; i++)
            {
                var stagesUpToNow = _stagesOrder.Take(i + 1).ToList();
                var validLevels = stagesUpToNow
                    .Where(stage => measurements[stage].IsValid)
                    .Select(stage => measurements[stage].Level.Value)
                    .ToList();

                decimal? avg = validLevels.Count > 0 ? validLevels.Average() : (decimal?)null;

                DbHelper.ExecuteNonQuery(@"
DELETE FROM daily_glucose_stage_averages
WHERE patient_id = @pid AND measurement_date = @date AND stage = @stage",
                    new SqlParameter("@pid", _patientId),
                    new SqlParameter("@date", date.Date),
                    new SqlParameter("@stage", _stagesOrder[i])
                );
                if (avg != null)
                {
                    DbHelper.ExecuteNonQuery(@"
INSERT INTO daily_glucose_stage_averages
  (patient_id, measurement_date, stage, average_level)
VALUES
  (@pid, @date, @stage, @avg)",
                        new SqlParameter("@pid", _patientId),
                        new SqlParameter("@date", date.Date),
                        new SqlParameter("@stage", _stagesOrder[i]),
                        new SqlParameter("@avg", avg.Value)
                    );
                }
            }
        }

        // O güne ait tüm ölçümleri getir (ve saat aralığı kontrolünü de döndür)
        private Dictionary<string, (decimal? Level, bool IsValid)> GetDayMeasurements(DateTime date)
        {
            var slots = _stagesOrder.ToDictionary(s => s, s => (Level: (decimal?)null, IsValid: false));

            const string sql = @"
SELECT
  stage,
  glucose_level,
  CAST(measurement_time AS time) AS Saat,
  is_valid
FROM dbo.glucose_measurements
WHERE patient_id = @pid
  AND CONVERT(date, measurement_time) = @date";
            var dt = DbHelper.ExecuteQuery(sql,
                        new SqlParameter("@pid", _patientId),
                        new SqlParameter("@date", date.Date));
            foreach (DataRow row in dt.Rows)
            {
                string stage = row["stage"].ToString();
                decimal? level = row["glucose_level"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["glucose_level"]);
                bool isValid = false;

                TimeSpan? t = row["Saat"] == DBNull.Value ? (TimeSpan?)null : TimeSpan.Parse(row["Saat"].ToString());
                if (level.HasValue && level.Value > 0 && t.HasValue && IsWithinStageWindow(stage, t.Value))
                    isValid = true;
                else if (row.Table.Columns.Contains("is_valid") && row["is_valid"] != DBNull.Value)
                    isValid = Convert.ToInt32(row["is_valid"]) == 1;

                if (slots.ContainsKey(stage))
                    slots[stage] = (level, isValid);
            }

            return slots;
        }

        private bool IsWithinStageWindow(string stage, TimeSpan time)
        {
            var window = _windows[stage];
            return time >= window.Start && time <= window.End;
        }

        private void ShowStageWarning(string stage, string message)
        {
            MessageBox.Show($"{stage}: {message}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void EvaluateDayMeasurements(DateTime date)
        {
            var measurements = GetDayMeasurements(date);
            _stageAverages = new();

            for (int i = 0; i < _stagesOrder.Count; i++)
            {
                var stagesUpToNow = _stagesOrder.Take(i + 1).ToList();
                var validLevels = stagesUpToNow
                    .Where(stage => measurements[stage].IsValid)
                    .Select(stage => measurements[stage].Level.Value)
                    .ToList();

                if (validLevels.Count > 0)
                    _stageAverages[_stagesOrder[i]] = validLevels.Average();
            }

            comboStage.Items.Clear();
            foreach (var stage in _stagesOrder)
                if (_stageAverages.ContainsKey(stage))
                    comboStage.Items.Add(stage);

            if (comboStage.Items.Count > 0)
            {
                comboStage.SelectedIndex = 0;
                var firstStage = comboStage.SelectedItem as string;
                if (_stageAverages.TryGetValue(firstStage, out var avg))
                {
                    lblStage.Text = $"{firstStage} Ortalaması: {avg:F1} mg/dL";
                    lblSuggestion.Text = $"İnsülin Önerisi: {GetInsulinSuggestion(avg)}";
                }
                else
                {
                    lblStage.Text = "Seçim Yapınız";
                    lblSuggestion.Text = "İnsülin Önerisi: –";
                }
            }
            else
            {
                lblStage.Text = "Ortalama hesaplanamadı";
                lblSuggestion.Text = "İnsülin Önerisi: –";
            }
        }

        private void OnStageChanged(object sender, EventArgs e)
        {
            if (comboStage.SelectedItem is string stage && _stageAverages.TryGetValue(stage, out var avg))
            {
                lblStage.Text = $"{stage} Ortalaması: {avg:F1} mg/dL";
                lblSuggestion.Text = $"İnsülin Önerisi: {GetInsulinSuggestion(avg)}";
            }
            else
            {
                lblStage.Text = "Seçim Yapınız";
                lblSuggestion.Text = "İnsülin Önerisi: –";
            }
        }

        // Ölçüm geçmişi - o güne ait ortalamayı da en sağda göster
        private void LoadHistory()
        {
            const string sql = @"
SELECT
  stage,
  CONVERT(varchar(10), measurement_time, 104) AS Tarih,
  CONVERT(varchar(5),  measurement_time, 108) AS Saat,
  glucose_level AS Seviye
FROM dbo.glucose_measurements
WHERE patient_id = @pid
ORDER BY measurement_time;";
            var dt = DbHelper.ExecuteQuery(sql, new SqlParameter("@pid", _patientId));

            dgvMeasurements.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                string stage = r["stage"].ToString();
                DateTime date = DateTime.ParseExact(r["Tarih"].ToString(), "dd.MM.yyyy", null);
                decimal? avg = GetDailyStageAverage(_patientId, date, stage);

                dgvMeasurements.Rows.Add(
                    stage,
                    r["Tarih"],
                    r["Saat"],
                    r["Seviye"],
                    avg.HasValue ? avg.Value.ToString("F1") : ""
                );
            }
        }

        // Veritabanından günlük ortalamayı çek
        private decimal? GetDailyStageAverage(int patientId, DateTime date, string stage)
        {
            const string sql = @"
SELECT average_level
FROM daily_glucose_stage_averages
WHERE patient_id = @pid AND measurement_date = @date AND stage = @stage";
            var dt = DbHelper.ExecuteQuery(sql,
                new SqlParameter("@pid", patientId),
                new SqlParameter("@date", date.Date),
                new SqlParameter("@stage", stage)
            );

            if (dt.Rows.Count > 0 && dt.Rows[0]["average_level"] != DBNull.Value)
                return Convert.ToDecimal(dt.Rows[0]["average_level"]);
            return null;
        }

        private string GetInsulinSuggestion(decimal avg)
        {
            if (avg < 70m)
                return "Yok";
            if (avg <= 110m)
                return "Yok";
            if (avg <= 150m)
                return "1 ml";
            if (avg <= 200m)
                return "2 ml";
            return "3 ml";
        }
    }
}
