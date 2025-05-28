using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesTracker.Services
{
    public static class AlertMessages
    {
        // Eşik anahtarı → (uyarı tipi, doktor mesajı)
        public static readonly Dictionary<string, (string AlertType, string Message)> Thresholds =
            new Dictionary<string, (string, string)>
            {
                ["Hipoglisemi"] = ("Acil Uyarı",
                "Hastanın kan şekeri seviyesi 70 mg/dL'nin altına düştü. Hipoglisemi riski! Hızlı müdahale gerekebilir."),
                ["Normal"] = ("Uyarı Yok",
                "Kan şekeri seviyesi normal aralıkta. Hiçbir işlem gerekmez."),
                ["OrtaYüksek"] = ("Takip Uyarısı",
                "Hastanın kan şekeri 111–150 mg/dL arasında. Durum izlenmeli."),
                ["Yüksek"] = ("İzleme Uyarısı",
                "Hastanın kan şekeri 151–200 mg/dL arasında. Diyabet kontrolü gereklidir."),
                ["Hiperglisemi"] = ("Acil Müdahale Uyarısı",
                "Hastanın kan şekeri 200 mg/dL'nin üzerinde. Hiperglisemi durumu. Acil müdahale gerekebilir.")
            };

        public static string GetThresholdKey(decimal level)
        {
            if (level < 70m) return "Hipoglisemi";
            if (level <= 110m) return "Normal";
            if (level <= 150m) return "OrtaYüksek";
            if (level <= 200m) return "Yüksek";
            return "Hiperglisemi";
        }
    }
}

