using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DiabetesTracker.DataAccess
{
    /// <summary>
    /// Veritabanı işlemleri için yardımcı sınıf.
    /// </summary>
    public static class DbHelper
    {
        /// <summary>
        /// Veritabanı bağlantı dizesini app.config'ten alır.
        /// </summary>
        private static string GetConnectionString()
        {
            var settings = ConfigurationManager.ConnectionStrings["DiabetesConn"];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                throw new ConfigurationErrorsException("'DiabetesConn' isimli connection string bulunamadı veya boş.");
            return settings.ConnectionString;
        }

        /// <summary>
        /// Yeni bir SqlConnection örneği döner.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            var connStr = GetConnectionString();
            return new SqlConnection(connStr);
        }

        /// <summary>
        /// INSERT/UPDATE/DELETE vb. sorguları parametrik olarak çalıştırır.
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.CommandTimeout = 60; // Timeout süresi 60 sn olarak ayarlandı
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Tek değer dönen sorgular (ör. SELECT COUNT(*), SCOPE_IDENTITY()) için.
        /// </summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.CommandTimeout = 60; // Timeout süresi 60 sn olarak ayarlandı
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteScalar();
        }

        /// <summary>
        /// SELECT sorgularını DataTable olarak döner.
        /// </summary>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using var conn = GetConnection();
                using var cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 60; // Timeout süresi 60 sn olarak ayarlandı
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                using var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt); // <-- Tam bu satırda hata fırlatıyorsun!
                return dt;
            }
            catch (Exception ex)
            {
                // Burada breakpoint koy veya logla!
                System.Windows.Forms.MessageBox.Show("SQL Hatası:\n" + ex.Message, "SQL Hatası", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                throw; // (isteğe bağlı) Hatanın yukarıda yakalanması için tekrar fırlat
            }
        }
    }
}
