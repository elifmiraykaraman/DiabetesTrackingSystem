using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Dosya: GlucoseDataAccess.cs
// Klasör: DiabetesTracker/DataAccess

using System.Data;
using Microsoft.Data.SqlClient;

namespace DiabetesTracker.DataAccess
{
    /// <summary>
    /// Glukoz ölçümlerine özel veri erişim metotlarını içerir.
    /// </summary>
    public static class GlucoseDataAccess
    {
        /// <summary>
        /// Bugünün glukoz ölçümlerini hasta bazında DataTable olarak döner.
        /// </summary>
        /// <param name="patientId">Hasta kimliği</param>
        /// <returns>Ölçüm tarihi, saati, değeri, zaman dilimi ve sıra sırasına göre sıralanmış DataTable</returns>
        public static DataTable GetTodaysMeasurements(int patientId)
        {
            const string sql = @"
                SELECT 
                    CAST(measurement_time AS date)      AS Tarih,
                    CONVERT(varchar(5), measurement_time, 108) AS Saat,
                    glucose_level                       AS Değer,
                    stage                               AS ZamanDilimi,
                    stage_order                         AS stage_order
                FROM dbo.glucose_measurements
                WHERE patient_id = @pid
                  AND CAST(measurement_time AS date) = @today
                ORDER BY stage_order;";

            return DbHelper.ExecuteQuery(
                sql,
                new SqlParameter("@pid", patientId),
                new SqlParameter("@today", DateTime.Today)
            );
        }
    }
}
