namespace DiabetesTracker
{
    partial class DoctorMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pbDoctorPhoto;
        private Label lblDoctorName;
        private DataGridView dgvPatients;
        private FlowLayoutPanel flowPanelButtons;
        private Button btnAddPatient;
        private Button btnDeletePatient;
        private Button btnBloodSugar;
        private Button btnViewWarnings;
        private Button btnGetRecommendation;
        private Button btnAllPatients;
        private Button btnApplyRecommendation;
        private Button btnDietExerciseStats;
        private Button btnBloodSugarRelation;
        private Button btnPersonInfo;
        private Label lblDoctorEmail;
        private Label lblDoctorBranch;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox picPatientPhoto;
        private Button btnChoosePatientPhoto;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pbDoctorPhoto = new PictureBox();
            lblDoctorName = new Label();
            dgvPatients = new DataGridView();
            flowPanelButtons = new FlowLayoutPanel();
            btnAddPatient = new Button();
            btnDeletePatient = new Button();
            btnBloodSugar = new Button();
            btnViewWarnings = new Button();
            btnGetRecommendation = new Button();
            btnAllPatients = new Button();
            btnApplyRecommendation = new Button();
            btnDietExerciseStats = new Button();
            btnBloodSugarRelation = new Button();
            btnPersonInfo = new Button();
            lblDoctorEmail = new Label();
            lblDoctorBranch = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            picPatientPhoto = new PictureBox();
            btnChoosePatientPhoto = new Button();
            ((System.ComponentModel.ISupportInitialize)pbDoctorPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            flowPanelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPatientPhoto).BeginInit();
            SuspendLayout();
            // 
            // pbDoctorPhoto
            // 
            pbDoctorPhoto.Cursor = Cursors.Hand;
            pbDoctorPhoto.Location = new Point(6, 67);
            pbDoctorPhoto.Name = "pbDoctorPhoto";
            pbDoctorPhoto.Size = new Size(148, 94);
            pbDoctorPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbDoctorPhoto.TabIndex = 0;
            pbDoctorPhoto.TabStop = false;
            // 
            // lblDoctorName
            // 
            lblDoctorName.AutoSize = true;
            lblDoctorName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDoctorName.Location = new Point(172, 67);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(147, 28);
            lblDoctorName.TabIndex = 1;
            lblDoctorName.Text = "Dr. [Ad Soyad]";
            // 
            // dgvPatients
            // 

            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(11, 167);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(983, 188);
            dgvPatients.TabIndex = 2;
            // 
            // flowPanelButtons
            // 
            flowPanelButtons.Controls.Add(btnAddPatient);
            flowPanelButtons.Controls.Add(btnDeletePatient);
            flowPanelButtons.Controls.Add(btnBloodSugar);
            flowPanelButtons.Controls.Add(btnViewWarnings);
            flowPanelButtons.Controls.Add(btnGetRecommendation);
            flowPanelButtons.Controls.Add(btnAllPatients);
            flowPanelButtons.Controls.Add(btnApplyRecommendation);
            flowPanelButtons.Controls.Add(btnDietExerciseStats);
            flowPanelButtons.Controls.Add(btnBloodSugarRelation);
            flowPanelButtons.Controls.Add(btnPersonInfo);
            flowPanelButtons.Location = new Point(652, 415);
            flowPanelButtons.Name = "flowPanelButtons";
            flowPanelButtons.Size = new Size(342, 241);
            flowPanelButtons.TabIndex = 3;
            // 
            // btnAddPatient
            // 
            btnAddPatient.Location = new Point(3, 3);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(150, 38);
            btnAddPatient.TabIndex = 0;
            btnAddPatient.Text = "Hasta Ekle";
            btnAddPatient.UseVisualStyleBackColor = true;
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.Location = new Point(159, 3);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(155, 38);
            btnDeletePatient.TabIndex = 1;
            btnDeletePatient.Text = "Hasta Sil";
            btnDeletePatient.UseVisualStyleBackColor = true;
            // 
            // btnBloodSugar
            // 
            btnBloodSugar.Location = new Point(3, 47);
            btnBloodSugar.Name = "btnBloodSugar";
            btnBloodSugar.Size = new Size(150, 39);
            btnBloodSugar.TabIndex = 2;
            btnBloodSugar.Text = "Kan Şekeri Verileri";
            btnBloodSugar.UseVisualStyleBackColor = true;
            // 
            // btnViewWarnings
            // 
            btnViewWarnings.Location = new Point(159, 47);
            btnViewWarnings.Name = "btnViewWarnings";
            btnViewWarnings.Size = new Size(155, 39);
            btnViewWarnings.TabIndex = 3;
            btnViewWarnings.Text = "Uyarıları Görüntüle";
            btnViewWarnings.UseVisualStyleBackColor = true;
            // 
            // btnGetRecommendation
            // 
            btnGetRecommendation.Location = new Point(3, 92);
            btnGetRecommendation.Name = "btnGetRecommendation";
            btnGetRecommendation.Size = new Size(150, 39);
            btnGetRecommendation.TabIndex = 4;
            btnGetRecommendation.Text = "Öneri Al";
            btnGetRecommendation.UseVisualStyleBackColor = true;
            // 
            // btnAllPatients
            // 
            btnAllPatients.Location = new Point(159, 92);
            btnAllPatients.Name = "btnAllPatients";
            btnAllPatients.Size = new Size(155, 39);
            btnAllPatients.TabIndex = 5;
            btnAllPatients.Text = "Tüm Hasta Bilgileri";
            btnAllPatients.UseVisualStyleBackColor = true;
            // 
            // btnApplyRecommendation
            // 
            btnApplyRecommendation.Location = new Point(3, 137);
            btnApplyRecommendation.Name = "btnApplyRecommendation";
            btnApplyRecommendation.Size = new Size(150, 41);
            btnApplyRecommendation.TabIndex = 6;
            btnApplyRecommendation.Text = "Öneri Uygula";
            btnApplyRecommendation.UseVisualStyleBackColor = true;
            // 
            // btnDietExerciseStats
            // 
            btnDietExerciseStats.Location = new Point(159, 137);
            btnDietExerciseStats.Name = "btnDietExerciseStats";
            btnDietExerciseStats.Size = new Size(155, 41);
            btnDietExerciseStats.TabIndex = 7;
            btnDietExerciseStats.Text = "Diyet/Egzersiz Takibi";
            btnDietExerciseStats.UseVisualStyleBackColor = true;
            // 
            // btnBloodSugarRelation
            // 
            btnBloodSugarRelation.Location = new Point(3, 184);
            btnBloodSugarRelation.Name = "btnBloodSugarRelation";
            btnBloodSugarRelation.Size = new Size(150, 39);
            btnBloodSugarRelation.TabIndex = 8;
            btnBloodSugarRelation.Text = "Kan Şekeri İlişkisi";
            btnBloodSugarRelation.UseVisualStyleBackColor = true;
            // 
            // btnPersonInfo
            // 
            btnPersonInfo.Location = new Point(159, 184);
            btnPersonInfo.Name = "btnPersonInfo";
            btnPersonInfo.Size = new Size(155, 39);
            btnPersonInfo.TabIndex = 9;
            btnPersonInfo.Text = "Kişi Bilgisi";
            btnPersonInfo.UseVisualStyleBackColor = true;
            // 
            // lblDoctorEmail
            // 
            lblDoctorEmail.AutoSize = true;
            lblDoctorEmail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDoctorEmail.Location = new Point(172, 105);
            lblDoctorEmail.Name = "lblDoctorEmail";
            lblDoctorEmail.Size = new Size(88, 23);
            lblDoctorEmail.TabIndex = 10;
            lblDoctorEmail.Text = "E-Posta: ...";
            // 
            // lblDoctorBranch
            // 
            lblDoctorBranch.AutoSize = true;
            lblDoctorBranch.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDoctorBranch.Location = new Point(176, 139);
            lblDoctorBranch.Name = "lblDoctorBranch";
            lblDoctorBranch.Size = new Size(103, 23);
            lblDoctorBranch.TabIndex = 11;
            lblDoctorBranch.Text = "Uzmanlık: ...";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(274, 412);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(274, 465);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(274, 518);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 14;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(274, 574);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 15;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "K", "E" });
            comboBox1.Location = new Point(274, 628);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(274, 691);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 415);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 18;
            label1.Text = "TC Kimlik:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 468);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 19;
            label2.Text = "Ad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(160, 531);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 20;
            label3.Text = "Soyadı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(159, 583);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 21;
            label4.Text = "E-Posta:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(159, 636);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 22;
            label5.Text = "Cinsiyet:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(160, 698);
            label6.Name = "label6";
            label6.Size = new Size(101, 20);
            label6.TabIndex = 23;
            label6.Text = "Doğum Tarihi:";
            // 
            // picPatientPhoto
            // 
            picPatientPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPatientPhoto.Location = new Point(11, 418);
            picPatientPhoto.Name = "picPatientPhoto";
            picPatientPhoto.Size = new Size(125, 74);
            picPatientPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picPatientPhoto.TabIndex = 24;
            picPatientPhoto.TabStop = false;
            // 
            // btnChoosePatientPhoto
            // 
            btnChoosePatientPhoto.Location = new Point(11, 512);
            btnChoosePatientPhoto.Name = "btnChoosePatientPhoto";
            btnChoosePatientPhoto.Size = new Size(125, 29);
            btnChoosePatientPhoto.TabIndex = 25;
            btnChoosePatientPhoto.Text = "Fotoğraf Seç";
            btnChoosePatientPhoto.UseVisualStyleBackColor = true;
            // 
            // DoctorMainForm
            // 
            ClientSize = new Size(1234, 768);
            Controls.Add(btnChoosePatientPhoto);
            Controls.Add(picPatientPhoto);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lblDoctorBranch);
            Controls.Add(lblDoctorEmail);
            Controls.Add(flowPanelButtons);
            Controls.Add(dgvPatients);
            Controls.Add(lblDoctorName);
            Controls.Add(pbDoctorPhoto);
            Name = "DoctorMainForm";
            Text = "Doktor Ana Ekranı";
            ((System.ComponentModel.ISupportInitialize)pbDoctorPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            flowPanelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPatientPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
