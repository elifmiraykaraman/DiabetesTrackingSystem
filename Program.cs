using System;
using System.Windows.Forms;

namespace DiabetesTracker
{
    internal static class Program
    {
        // Global olarak tutulacak kullanıcı bilgileri
        public static int CurrentUserId { get; private set; }
        public static string CurrentUserRole { get; private set; }

        [STAThread]
        static void Main()
        {
            // WinForms konfigürasyonu (.NET 6+ için)
            ApplicationConfiguration.Initialize();

            // 1) Login formunu modal aç
            using (var login = new Form1())
            {
                var dr = login.ShowDialog();
                if (dr != DialogResult.OK)
                    return;  // İptal ya da başarısızsa uygulamayı kapat
            }

            // 2) Rol’e göre ana formu başlat
            if (CurrentUserRole.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
            {
                Application.Run(new DoctorMainForm());
            }
            else
            {
                // PatientMainForm’un constructor’ı kullanıcı ID’si alıyor
                Application.Run(new PatientMainForm(CurrentUserId));
            }
        }

        /// <summary>
        /// Login başarılı olduğunda çağrılacak:
        /// Form1 içinden userId ve roleName geçilecek.
        /// </summary>
        public static void SetCurrentUser(int userId, string roleName)
        {
            CurrentUserId = userId;
            CurrentUserRole = roleName;
        }
    }
}
