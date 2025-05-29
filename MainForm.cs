using System;
using System.Windows.Forms;

namespace DiabetesTracker
{
    public partial class MainForm : Form
    {
        private readonly int _userId;

        // Designer ctor
        public MainForm()
        {
            InitializeComponent();
        }

        // Uygulama Program.cs’den bu ctor ile çağrılacak
        public MainForm(int userId)
            : this()
        {
            _userId = userId;
            this.Text = $"Hasta Paneli – Kullanıcı {_userId}";

            // Menü tıklama event’lerini bağla:
            ölçümToolStripMenuItem.Click += (s, e) => ShowFormInPanel(new PatientGlucoseFormm(_userId));
            kanŞekeriToolStripMenuItem.Click += (s, e) => ShowFormInPanel(new PatientGlucoseFormm(_userId));
            ölçümToolStripMenuItem1.Click += (s, e) => ShowFormInPanel(new ExerciseForm(_userId));
            diyetToolStripMenuItem.Click += (s, e) => ShowFormInPanel(new DietForm(_userId));
            egzersizToolStripMenuItem.Click += (s, e) => ShowFormInPanel(new ExerciseForm(_userId));
            semptomToolStripMenuItem.Click += (s, e) => ShowFormInPanel(new SymptomForm(_userId));
            özetGrafikToolStripMenuItem.Click += (s, e) => ShowFormInPanel(new ReportForm(_userId));
            çıkışToolStripMenuItem.Click += (s, e) => Application.Exit();
        }

        // İstediğimiz formu ortadaki panelContainer içine yerleştiren yardımcı metot
        private void diyetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new DietForm(_userId));
        }

        private void egzersizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new ExerciseForm(_userId));
        }
        // MainForm.cs içinde namespace DiabetesTracker { public partial class MainForm : Form { … buraya:
        private void kanŞekeriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new PatientGlucoseFormm(_userId));
        }

        private void özetGrafikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new ReportForm(_userId));
        }


        private void semptomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new SymptomForm(_userId));
        }

        private void özetGrafikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new ReportForm(_userId));
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowFormInPanel(Form frm)
        {
            panelContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(frm);
            frm.Show();
        }
    }
}
