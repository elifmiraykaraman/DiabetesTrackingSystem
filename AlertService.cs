using System;
using Microsoft.Data.SqlClient;
using DiabetesTracker.DataAccess;

namespace DiabetesTracker.Services
{
    public static class AlertService
    {
        /// <summary>
        /// Hasta gün sonu veya kritik ölçüm uyarılarını yalnızca veritabanına yazar.
        /// E‑posta göndermeyi tamamen kaldırdık.
        /// </summary>
        public static void SendImmediateAlert(int patientId, string stage, string alertType, string message)
        {
            // 1) Hastanın doktora atanıp atanmadığını kontrol et
            var dt = DbHelper.ExecuteQuery(
                @"SELECT 1 
                  FROM dbo.doctor_patient 
                  WHERE patient_id = @pid",
                new SqlParameter("@pid", patientId));
            if (dt.Rows.Count == 0)
                return;  // Henüz atanmamışsa çık

            // 2) Uyarıyı logla (sadece veritabanına kaydet)
            DbHelper.ExecuteNonQuery(
                @"INSERT INTO dbo.alert_logs
                    (patient_id, alert_time, alert_type, message)
                  VALUES
                    (@pid, GETDATE(), @type, @msg)",
                new SqlParameter("@pid", patientId),
                new SqlParameter("@type", alertType),
                new SqlParameter("@msg", message)
            );
        }
    }
}
