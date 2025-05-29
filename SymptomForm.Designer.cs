namespace DiabetesTracker
{
    partial class SymptomForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblDate;
        private DateTimePicker dtpSymptomDate;
        private Label lblGlucose;
        private TextBox txtGlucose;
        private Button btnRecommend;
        private GroupBox grpSymptoms;
        private CheckBox chkPoliuri;
        private CheckBox chkPolifaji;
        private CheckBox chkPolidipsi;
        private CheckBox chkNeuropati;
        private CheckBox chkKilo;
        private CheckBox chkYorgun;
        private CheckBox chkYaralar;
        private CheckBox chkBulanik;
        private Label lblResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblDate = new Label();
            dtpSymptomDate = new DateTimePicker();
            lblGlucose = new Label();
            txtGlucose = new TextBox();
            btnRecommend = new Button();
            grpSymptoms = new GroupBox();
            chkPoliuri = new CheckBox();
            chkPolifaji = new CheckBox();
            chkPolidipsi = new CheckBox();
            chkNeuropati = new CheckBox();
            chkKilo = new CheckBox();
            chkYorgun = new CheckBox();
            chkYaralar = new CheckBox();
            chkBulanik = new CheckBox();
            lblResult = new Label();
            grpSymptoms.SuspendLayout();
            SuspendLayout();

            // 
            // lblDate
            // 
            lblDate.Location = new System.Drawing.Point(320, 15);
            lblDate.Name = "lblDate";
            lblDate.Size = new System.Drawing.Size(45, 23);
            lblDate.TabIndex = 0;
            lblDate.Text = "Tarih:";

            // 
            // dtpSymptomDate
            // 
            dtpSymptomDate.Format = DateTimePickerFormat.Short;
            dtpSymptomDate.Location = new System.Drawing.Point(370, 12);
            dtpSymptomDate.Name = "dtpSymptomDate";
            dtpSymptomDate.Size = new System.Drawing.Size(140, 27);
            dtpSymptomDate.TabIndex = 1;

            // 
            // lblGlucose
            // 
            lblGlucose.AutoSize = true;
            lblGlucose.Location = new System.Drawing.Point(28, 19);
            lblGlucose.Name = "lblGlucose";
            lblGlucose.Size = new System.Drawing.Size(139, 20);
            lblGlucose.TabIndex = 2;
            lblGlucose.Text = "Kan Şekeri (mg/dL):";

            // 
            // txtGlucose
            // 
            txtGlucose.Location = new System.Drawing.Point(175, 12);
            txtGlucose.Name = "txtGlucose";
            txtGlucose.Size = new System.Drawing.Size(80, 27);
            txtGlucose.TabIndex = 3;

            // 
            // btnRecommend
            // 
            btnRecommend.Location = new System.Drawing.Point(460, 329);
            btnRecommend.Name = "btnRecommend";
            btnRecommend.Size = new System.Drawing.Size(94, 29);
            btnRecommend.TabIndex = 4;
            btnRecommend.Text = "Öneri Al";
            btnRecommend.UseVisualStyleBackColor = true;
            // Event binding YOK burada, CS dosyasında olacak!

            // 
            // grpSymptoms
            // 
            grpSymptoms.Controls.Add(chkPoliuri);
            grpSymptoms.Controls.Add(chkPolifaji);
            grpSymptoms.Controls.Add(chkPolidipsi);
            grpSymptoms.Controls.Add(chkNeuropati);
            grpSymptoms.Controls.Add(chkKilo);
            grpSymptoms.Controls.Add(chkYorgun);
            grpSymptoms.Controls.Add(chkYaralar);
            grpSymptoms.Controls.Add(chkBulanik);
            grpSymptoms.Location = new System.Drawing.Point(28, 58);
            grpSymptoms.Name = "grpSymptoms";
            grpSymptoms.Size = new System.Drawing.Size(408, 300);
            grpSymptoms.TabIndex = 5;
            grpSymptoms.TabStop = false;
            grpSymptoms.Text = "Belirtiler";

            // 
            // chkPoliuri
            // 
            chkPoliuri.AutoSize = true;
            chkPoliuri.Location = new System.Drawing.Point(10, 20);
            chkPoliuri.Name = "chkPoliuri";
            chkPoliuri.Size = new System.Drawing.Size(191, 24);
            chkPoliuri.TabIndex = 0;
            chkPoliuri.Tag = "1";
            chkPoliuri.Text = "Poliüri (Sık idrara çıkma)";
            chkPoliuri.UseVisualStyleBackColor = true;

            // 
            // chkPolifaji
            // 
            chkPolifaji.AutoSize = true;
            chkPolifaji.Location = new System.Drawing.Point(10, 50);
            chkPolifaji.Name = "chkPolifaji";
            chkPolifaji.Size = new System.Drawing.Size(185, 24);
            chkPolifaji.TabIndex = 1;
            chkPolifaji.Tag = "2";
            chkPolifaji.Text = "Polifaji (Aşırı açlık hissi)";
            chkPolifaji.UseVisualStyleBackColor = true;

            // 
            // chkPolidipsi
            // 
            chkPolidipsi.AutoSize = true;
            chkPolidipsi.Location = new System.Drawing.Point(10, 80);
            chkPolidipsi.Name = "chkPolidipsi";
            chkPolidipsi.Size = new System.Drawing.Size(215, 24);
            chkPolidipsi.TabIndex = 2;
            chkPolidipsi.Tag = "3";
            chkPolidipsi.Text = "Polidipsi (Aşırı susama hissi)";
            chkPolidipsi.UseVisualStyleBackColor = true;

            // 
            // chkNeuropati
            // 
            chkNeuropati.AutoSize = true;
            chkNeuropati.Location = new System.Drawing.Point(10, 110);
            chkNeuropati.Name = "chkNeuropati";
            chkNeuropati.Size = new System.Drawing.Size(399, 24);
            chkNeuropati.TabIndex = 3;
            chkNeuropati.Tag = "4";
            chkNeuropati.Text = "Nöropati (El/ayaklarda karıncalanma veya uyuşma hissi)";
            chkNeuropati.UseVisualStyleBackColor = true;

            // 
            // chkKilo
            // 
            chkKilo.AutoSize = true;
            chkKilo.Location = new System.Drawing.Point(10, 140);
            chkKilo.Name = "chkKilo";
            chkKilo.Size = new System.Drawing.Size(96, 24);
            chkKilo.TabIndex = 4;
            chkKilo.Tag = "5";
            chkKilo.Text = "Kilo kaybı";
            chkKilo.UseVisualStyleBackColor = true;

            // 
            // chkYorgun
            // 
            chkYorgun.AutoSize = true;
            chkYorgun.Location = new System.Drawing.Point(10, 170);
            chkYorgun.Name = "chkYorgun";
            chkYorgun.Size = new System.Drawing.Size(96, 24);
            chkYorgun.TabIndex = 5;
            chkYorgun.Tag = "6";
            chkYorgun.Text = "Yorgunluk";
            chkYorgun.UseVisualStyleBackColor = true;

            // 
            // chkYaralar
            // 
            chkYaralar.AutoSize = true;
            chkYaralar.Location = new System.Drawing.Point(10, 200);
            chkYaralar.Name = "chkYaralar";
            chkYaralar.Size = new System.Drawing.Size(196, 24);
            chkYaralar.TabIndex = 6;
            chkYaralar.Tag = "7";
            chkYaralar.Text = "Yaraların yavaş iyileşmesi";
            chkYaralar.UseVisualStyleBackColor = true;

            // 
            // chkBulanik
            // 
            chkBulanik.AutoSize = true;
            chkBulanik.Location = new System.Drawing.Point(10, 230);
            chkBulanik.Name = "chkBulanik";
            chkBulanik.Size = new System.Drawing.Size(127, 24);
            chkBulanik.TabIndex = 7;
            chkBulanik.Tag = "8";
            chkBulanik.Text = "Bulanık görme";
            chkBulanik.UseVisualStyleBackColor = true;

            // 
            // lblResult
            // 
            lblResult.Location = new System.Drawing.Point(460, 58);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(300, 254);
            lblResult.TabIndex = 6;

            // 
            // SymptomForm
            // 
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(lblDate);
            Controls.Add(dtpSymptomDate);
            Controls.Add(lblGlucose);
            Controls.Add(txtGlucose);
            Controls.Add(btnRecommend);
            Controls.Add(grpSymptoms);
            Controls.Add(lblResult);
            Name = "SymptomForm";
            Text = "Belirti Seçimi";
            grpSymptoms.ResumeLayout(false);
            grpSymptoms.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
