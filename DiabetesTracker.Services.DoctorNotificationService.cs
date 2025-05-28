using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker.Services
{
    public class DoctorNotificationService
    {
        // Günlük toplam 5 slot: Sabah, Öğle, İkindi, Akşam, Gece
        private const int TotalSlots = 5;

        // Bu tablo görseldeki aralıklar ve mesajlar:
        private readonly List<Threshold> _thresholds = new()
        {
            new Threshold("Hipoglisemi Riski",       v => v < 70m,      "Acil Uyarı",   "Hastanın kan şekeri seviyesi 70 mg/dL'nin altına düştü. Hipoglisemi riski! Hızlı müdahale gerekebilir."),
            new Threshold("Normal Seviye",           v => v >= 70m && v <= 110m, "Uyarı Yok",    "Kan şekeri seviyesi normal aralıkta. Hiçbir işlem gerekmez."),
            new Threshold("Orta Yüksek Seviye",      v => v > 110m && v <= 150m, "Takip Uyarısı","Hastanın kan şekeri 111-150 mg/dL arasında. Durum izlenmeli."),
            new Threshold("Yüksek Seviye",           v => v > 150m && v <= 200m, "İzleme Uyarısı","Hastanın kan şekeri 151-200 mg/dL arasında. Diyabet kontrolü gerekli."),
            new Threshold("Çok Yüksek Seviye",       v => v > 200m,      "Acil Müdahale","Hastanın kan şekeri 200 mg/dL'nin üzerinde. Hiperglisemi! Acil müdahale gerekebilir."),
        };

        public DoctorMessageResult EvaluateDailyStatus(int patientId)
        {
            // 1) Bugün çekilmiş ölçümler
            var dt = GlucoseDataAccess.GetTodaysMeasurements(patientId);
            var validValues = dt.Rows
                .Cast<DataRow>()
                .Select(r => Convert.ToDecimal(r["Değer"]))
                .Where(v => v > 0)
                .ToList();

            // 2) Eksik ölçüm kontrolü
            int enteredCount = validValues.Count;
            if (enteredCount == 0)
            {
                return new DoctorMessageResult
                {
                    MessageType = "Ölçüm Eksik Uyarısı",
                    MessageText = "Hasta gün boyunca kan şekeri ölçümü yapmamıştır. Acil takip önerilir."
                };
            }
            if (enteredCount < 3)
            {
                return new DoctorMessageResult
                {
                    MessageType = "Ölçüm Yetersiz Uyarısı",
                    MessageText = "Hastanın günlük kan şekeri ölçüm sayısı yetersiz (<3). Durum izlenmelidir."
                };
            }

            // 3) Diğer durumlar: en kritik ölçüme göre karar ver (örneğin MIN, ya da MAX)
            decimal min = validValues.Min();
            // isterseniz max veya ortalama da kullanabilirsiniz:
            // decimal max = validValues.Max();
            // decimal avg = validValues.Average();

            // 4) Threshold tablosundan uygun mesaja karar ver:
            var thr = _thresholds.First(t => t.Predicate(min));
            return new DoctorMessageResult
            {
                MessageType = thr.AlertType,
                MessageText = thr.Message
            };
        }

        private class Threshold
        {
            public string Name { get; }
            public Func<decimal, bool> Predicate { get; }
            public string AlertType { get; }
            public string Message { get; }

            public Threshold(string name, Func<decimal, bool> pred, string alertType, string message)
            {
                Name = name;
                Predicate = pred;
                AlertType = alertType;
                Message = message;
            }
        }
    }

    public class DoctorMessageResult
    {
        public string MessageType { get; set; }
        public string MessageText { get; set; }
    }
}
