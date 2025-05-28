using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using DiabetesTracker.DataAccess;


namespace DiabetesTracker.DataAccess
{


    /// <summary>
    /// E‑posta ile hasta giriş bilgilerini gönderir.
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// Verilen e‑posta adresine T.C. kimlik ve şifre bilgilerini gönderir.
        /// </summary>
        /// <param name="toEmail">Hastanın e‑posta adresi</param>
        /// <param name="tcIdentity">Hastanın T.C. kimlik numarası</param>
        /// <param name="password">Oluşturulan düz metin şifre</param>
        public static void SendCredentials(string toEmail, string tcIdentity, string password)
        {
            // App.config'ten oku
            var from = ConfigurationManager.AppSettings["EmailFrom"]
                             ?? throw new Exception("EmailFrom missing");
            var host = ConfigurationManager.AppSettings["SmtpHost"]
                             ?? throw new Exception("SmtpHost missing");
            var portText = ConfigurationManager.AppSettings["SmtpPort"]
                             ?? throw new Exception("SmtpPort missing");
            var user = ConfigurationManager.AppSettings["SmtpUser"]
                             ?? throw new Exception("SmtpUser missing");
            var pass = ConfigurationManager.AppSettings["SmtpPass"]
                             ?? throw new Exception("SmtpPass missing");
            var sslText = ConfigurationManager.AppSettings["SmtpEnableSsl"] ?? "true";

            if (!int.TryParse(portText, out int port))
                throw new Exception("SmtpPort geçerli bir sayı değil.");

            if (!bool.TryParse(sslText, out bool enableSsl))
                enableSsl = true;

            using var msg = new MailMessage(from, toEmail)
            {
                Subject = "Diyabet Takip Sistemi – Giriş Bilgileriniz",
                Body = $"Merhaba,\n\nT.C.: {tcIdentity}\nŞifre: {password}\n\nGeçmiş Olsun.",
                IsBodyHtml = false
            };

            using var smtp = new SmtpClient(host, port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, pass),
                EnableSsl = enableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            try
            {
                smtp.Send(msg);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(
                    $"SMTP Hatası:\n{ex.StatusCode}\n{ex.InnerException?.Message ?? ex.Message}",
                    "E‑posta Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"E‑posta gönderilemedi:\n{ex.Message}",
                    "E‑posta Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                throw;
            }
        }
        public static void SendAlert(string toEmail, string subject, string body)
        {
            var from = ConfigurationManager.AppSettings["EmailFrom"] ?? throw new Exception("EmailFrom missing");
            var host = ConfigurationManager.AppSettings["SmtpHost"] ?? throw new Exception("SmtpHost missing");
            var portText = ConfigurationManager.AppSettings["SmtpPort"] ?? throw new Exception("SmtpPort missing");
            var user = ConfigurationManager.AppSettings["SmtpUser"] ?? throw new Exception("SmtpUser missing");
            var pass = ConfigurationManager.AppSettings["SmtpPass"] ?? throw new Exception("SmtpPass missing");
            var sslText = ConfigurationManager.AppSettings["SmtpEnableSsl"] ?? "true";

            if (!int.TryParse(portText, out int port)) throw new Exception("SmtpPort geçerli sayı değil.");
            if (!bool.TryParse(sslText, out bool enableSsl)) enableSsl = true;

            using var msg = new MailMessage(from, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };
            using var smtp = new SmtpClient(host, port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, pass),
                EnableSsl = enableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtp.Send(msg);
        }

    }
}
