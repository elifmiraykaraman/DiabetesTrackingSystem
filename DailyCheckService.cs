using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiabetesTracker.DataAccess;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Data;

namespace DiabetesTracker.Services
{
    public static class DailyCheckService
    {
        public static void RunEndOfDayChecks()
        {
            // 1) Bugün girilen ölçüm sayıları
            var dtCounts = DbHelper.ExecuteQuery(@"
                SELECT patient_id, COUNT(*) AS cnt
                FROM dbo.glucose_measurements
                WHERE CAST(measurement_time AS date) = CAST(GETDATE() AS date)
                GROUP BY patient_id");

            // 2) Tüm hastalar
            var dtAll = DbHelper.ExecuteQuery(@"
                SELECT u.user_id
                FROM dbo.users u
                JOIN dbo.user_roles ur ON u.user_id = ur.user_id
                JOIN dbo.roles r       ON ur.role_id = r.role_id
                WHERE r.role_name = 'Patient'");

            var counts = dtCounts.Rows.Cast<DataRow>()
                                      .ToDictionary(r => (int)r["patient_id"], r => (int)r["cnt"]);

            foreach (DataRow row in dtAll.Rows)
            {
                int pid = (int)row["user_id"];
                counts.TryGetValue(pid, out int cnt);

                string alertType, message;
                if (cnt == 0)
                {
                    alertType = "Ölçüm Eksik Uyarısı";
                    message = "Hasta gün boyunca kan şekeri ölçümü yapmamıştır. Acil takip önerilir.";
                }
                else if (cnt < 3)
                {
                    alertType = "Ölçüm Yetersiz Uyarısı";
                    message = "Hastanın günlük kan şekeri ölçüm sayısı yetersiz (<3). Durum izlenmeli.";
                }
                else continue;

                AlertService.SendImmediateAlert(pid, "Gün Sonu", alertType, message);
            }
        }
    }
}
