namespace DiabetesTracker
{
    partial class PatientGlucoseFormm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelSabah;
        private DateTimePicker dtpSabahSaat;
        private NumericUpDown nudSabah;
        private Label labelOgle;
        private DateTimePicker dtpOgleTime;
        private NumericUpDown nudOgle;
        private Label labelIkindi;
        private DateTimePicker dtpIkindiTime;
        private NumericUpDown nudIkindi;
        private Label labelAksam;
        private DateTimePicker dtpAksamTime;
        private NumericUpDown nudAksam;
        private Label labelGece;
        private DateTimePicker dtpGeceTime;
        private NumericUpDown nudGece;
        private Button btnSaveAll;
        private ComboBox comboStage;
        private Label lblStage;
        private Label lblSuggestion;
        private DataGridView dgvMeasurements;


        private Label lblInsulinSabah;
        private Label lblInsulinOgle;
        private Label lblInsulinIkindi;
        private Label lblInsulinAksam;
        private Label lblInsulinGece;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            labelSabah = new Label();
            dtpSabahSaat = new DateTimePicker();
            nudSabah = new NumericUpDown();
            labelOgle = new Label();
            dtpOgleTime = new DateTimePicker();
            nudOgle = new NumericUpDown();
            labelIkindi = new Label();
            dtpIkindiTime = new DateTimePicker();
            nudIkindi = new NumericUpDown();
            labelAksam = new Label();
            dtpAksamTime = new DateTimePicker();
            nudAksam = new NumericUpDown();
            labelGece = new Label();
            dtpGeceTime = new DateTimePicker();
            nudGece = new NumericUpDown();
            btnSaveAll = new Button();
            comboStage = new ComboBox();
            lblStage = new Label();
            lblSuggestion = new Label();
            dgvMeasurements = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dtpEntryDate = new DateTimePicker();
            lblInsulinSabah = new Label();
            lblInsulinOgle = new Label();
            lblInsulinIkindi = new Label();
            lblInsulinAksam = new Label();
            lblInsulinGece = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSabah).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOgle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudIkindi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAksam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGece).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeasurements).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(labelSabah, 0, 0);
            tableLayoutPanel1.Controls.Add(dtpSabahSaat, 1, 0);
            tableLayoutPanel1.Controls.Add(nudSabah, 2, 0);
            tableLayoutPanel1.Controls.Add(labelOgle, 0, 1);
            tableLayoutPanel1.Controls.Add(dtpOgleTime, 1, 1);
            tableLayoutPanel1.Controls.Add(nudOgle, 2, 1);
            tableLayoutPanel1.Controls.Add(labelIkindi, 0, 2);
            tableLayoutPanel1.Controls.Add(dtpIkindiTime, 1, 2);
            tableLayoutPanel1.Controls.Add(nudIkindi, 2, 2);
            tableLayoutPanel1.Controls.Add(labelAksam, 0, 3);
            tableLayoutPanel1.Controls.Add(dtpAksamTime, 1, 3);
            tableLayoutPanel1.Controls.Add(nudAksam, 2, 3);
            tableLayoutPanel1.Controls.Add(labelGece, 0, 4);
            tableLayoutPanel1.Controls.Add(dtpGeceTime, 1, 4);
            tableLayoutPanel1.Controls.Add(nudGece, 2, 4);
            tableLayoutPanel1.Controls.Add(btnSaveAll, 0, 5);
            tableLayoutPanel1.Controls.Add(comboStage, 0, 6);
            tableLayoutPanel1.Controls.Add(lblStage, 0, 7);
            tableLayoutPanel1.Controls.Add(lblSuggestion, 0, 8);
            tableLayoutPanel1.Controls.Add(dgvMeasurements, 0, 9);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelSabah
            // 
            labelSabah.Dock = DockStyle.Fill;
            labelSabah.Location = new Point(3, 0);
            labelSabah.Name = "labelSabah";
            labelSabah.Size = new Size(314, 40);
            labelSabah.TabIndex = 0;
            labelSabah.Text = "Sabah (07:00–09:00):";
            labelSabah.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpSabahSaat
            // 
            dtpSabahSaat.CustomFormat = "HH:mm";
            dtpSabahSaat.Dock = DockStyle.Fill;
            dtpSabahSaat.Format = DateTimePickerFormat.Custom;
            dtpSabahSaat.Location = new Point(323, 3);
            dtpSabahSaat.Name = "dtpSabahSaat";
            dtpSabahSaat.ShowUpDown = true;
            dtpSabahSaat.Size = new Size(234, 27);
            dtpSabahSaat.TabIndex = 1;
            // 
            // nudSabah
            // 
            nudSabah.Dock = DockStyle.Fill;
            nudSabah.Location = new Point(563, 3);
            nudSabah.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudSabah.Name = "nudSabah";
            nudSabah.Size = new Size(234, 27);
            nudSabah.TabIndex = 2;
            // 
            // labelOgle
            // 
            labelOgle.Dock = DockStyle.Fill;
            labelOgle.Location = new Point(3, 40);
            labelOgle.Name = "labelOgle";
            labelOgle.Size = new Size(314, 40);
            labelOgle.TabIndex = 3;
            labelOgle.Text = "Öğle (12:00–13:00):";
            labelOgle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpOgleTime
            // 
            dtpOgleTime.CustomFormat = "HH:mm";
            dtpOgleTime.Dock = DockStyle.Fill;
            dtpOgleTime.Format = DateTimePickerFormat.Custom;
            dtpOgleTime.Location = new Point(323, 43);
            dtpOgleTime.Name = "dtpOgleTime";
            dtpOgleTime.ShowUpDown = true;
            dtpOgleTime.Size = new Size(234, 27);
            dtpOgleTime.TabIndex = 4;
            // 
            // nudOgle
            // 
            nudOgle.Dock = DockStyle.Fill;
            nudOgle.Location = new Point(563, 43);
            nudOgle.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudOgle.Name = "nudOgle";
            nudOgle.Size = new Size(234, 27);
            nudOgle.TabIndex = 5;
            // 
            // labelIkindi
            // 
            labelIkindi.Dock = DockStyle.Fill;
            labelIkindi.Location = new Point(3, 80);
            labelIkindi.Name = "labelIkindi";
            labelIkindi.Size = new Size(314, 40);
            labelIkindi.TabIndex = 6;
            labelIkindi.Text = "İkindi (15:00–16:00):";
            labelIkindi.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpIkindiTime
            // 
            dtpIkindiTime.CustomFormat = "HH:mm";
            dtpIkindiTime.Dock = DockStyle.Fill;
            dtpIkindiTime.Format = DateTimePickerFormat.Custom;
            dtpIkindiTime.Location = new Point(323, 83);
            dtpIkindiTime.Name = "dtpIkindiTime";
            dtpIkindiTime.ShowUpDown = true;
            dtpIkindiTime.Size = new Size(234, 27);
            dtpIkindiTime.TabIndex = 7;
            // 
            // nudIkindi
            // 
            nudIkindi.Dock = DockStyle.Fill;
            nudIkindi.Location = new Point(563, 83);
            nudIkindi.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudIkindi.Name = "nudIkindi";
            nudIkindi.Size = new Size(234, 27);
            nudIkindi.TabIndex = 8;
            // 
            // labelAksam
            // 
            labelAksam.Dock = DockStyle.Fill;
            labelAksam.Location = new Point(3, 120);
            labelAksam.Name = "labelAksam";
            labelAksam.Size = new Size(314, 40);
            labelAksam.TabIndex = 9;
            labelAksam.Text = "Akşam (18:00–19:00):";
            labelAksam.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpAksamTime
            // 
            dtpAksamTime.CustomFormat = "HH:mm";
            dtpAksamTime.Dock = DockStyle.Fill;
            dtpAksamTime.Format = DateTimePickerFormat.Custom;
            dtpAksamTime.Location = new Point(323, 123);
            dtpAksamTime.Name = "dtpAksamTime";
            dtpAksamTime.ShowUpDown = true;
            dtpAksamTime.Size = new Size(234, 27);
            dtpAksamTime.TabIndex = 10;
            // 
            // nudAksam
            // 
            nudAksam.Dock = DockStyle.Fill;
            nudAksam.Location = new Point(563, 123);
            nudAksam.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudAksam.Name = "nudAksam";
            nudAksam.Size = new Size(234, 27);
            nudAksam.TabIndex = 11;
            // 
            // labelGece
            // 
            labelGece.Dock = DockStyle.Fill;
            labelGece.Location = new Point(3, 160);
            labelGece.Name = "labelGece";
            labelGece.Size = new Size(314, 35);
            labelGece.TabIndex = 12;
            labelGece.Text = "Gece (22:00–23:00):";
            labelGece.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpGeceTime
            // 
            dtpGeceTime.CustomFormat = "HH:mm";
            dtpGeceTime.Dock = DockStyle.Fill;
            dtpGeceTime.Format = DateTimePickerFormat.Custom;
            dtpGeceTime.Location = new Point(323, 163);
            dtpGeceTime.Name = "dtpGeceTime";
            dtpGeceTime.ShowUpDown = true;
            dtpGeceTime.Size = new Size(234, 27);
            dtpGeceTime.TabIndex = 13;
            // 
            // nudGece
            // 
            nudGece.Dock = DockStyle.Fill;
            nudGece.Location = new Point(563, 163);
            nudGece.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudGece.Name = "nudGece";
            nudGece.Size = new Size(234, 27);
            nudGece.TabIndex = 14;
            // 
            // btnSaveAll
            // 
            btnSaveAll.Dock = DockStyle.Fill;
            btnSaveAll.Location = new Point(3, 198);
            btnSaveAll.Name = "btnSaveAll";
            btnSaveAll.Size = new Size(314, 34);
            btnSaveAll.TabIndex = 15;
            btnSaveAll.Text = "Kaydet";
            // 
            // comboStage
            // 
            comboStage.Dock = DockStyle.Fill;
            comboStage.Location = new Point(3, 238);
            comboStage.Name = "comboStage";
            comboStage.Size = new Size(314, 28);
            comboStage.TabIndex = 16;
            // 
            // lblStage
            // 
            lblStage.Dock = DockStyle.Fill;
            lblStage.Location = new Point(3, 265);
            lblStage.Name = "lblStage";
            lblStage.Size = new Size(314, 30);
            lblStage.TabIndex = 17;
            lblStage.Text = "Seçim Yapınız";
            // 
            // lblSuggestion
            // 
            lblSuggestion.Dock = DockStyle.Fill;
            lblSuggestion.Location = new Point(3, 295);
            lblSuggestion.Name = "lblSuggestion";
            lblSuggestion.Size = new Size(314, 30);
            lblSuggestion.TabIndex = 18;
            lblSuggestion.Text = "İnsülin Önerisi: –";
            // 
            // dgvMeasurements
            // 
            dgvMeasurements.AllowUserToAddRows = false;
            dgvMeasurements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMeasurements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeasurements.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            tableLayoutPanel1.SetColumnSpan(dgvMeasurements, 3);
            dgvMeasurements.Dock = DockStyle.Fill;
            dgvMeasurements.Location = new Point(3, 328);
            dgvMeasurements.Name = "dgvMeasurements";
            dgvMeasurements.RowHeadersWidth = 51;
            dgvMeasurements.Size = new Size(794, 119);
            dgvMeasurements.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dtpEntryDate
            // 
            dtpEntryDate.CustomFormat = "dd.MM.yyyy";
            dtpEntryDate.Format = DateTimePickerFormat.Custom;
            dtpEntryDate.Location = new Point(0, 0);
            dtpEntryDate.Name = "dtpEntryDate";
            dtpEntryDate.Size = new Size(175, 27);
            dtpEntryDate.TabIndex = 1;
            // 
            // lblInsulinSabah
            // 
            lblInsulinSabah.Location = new Point(0, 0);
            lblInsulinSabah.Name = "lblInsulinSabah";
            lblInsulinSabah.Size = new Size(100, 23);
            lblInsulinSabah.TabIndex = 0;
            // 
            // lblInsulinOgle
            // 
            lblInsulinOgle.Location = new Point(0, 0);
            lblInsulinOgle.Name = "lblInsulinOgle";
            lblInsulinOgle.Size = new Size(100, 23);
            lblInsulinOgle.TabIndex = 0;
            // 
            // lblInsulinIkindi
            // 
            lblInsulinIkindi.Location = new Point(0, 0);
            lblInsulinIkindi.Name = "lblInsulinIkindi";
            lblInsulinIkindi.Size = new Size(100, 23);
            lblInsulinIkindi.TabIndex = 0;
            // 
            // lblInsulinAksam
            // 
            lblInsulinAksam.Location = new Point(0, 0);
            lblInsulinAksam.Name = "lblInsulinAksam";
            lblInsulinAksam.Size = new Size(100, 23);
            lblInsulinAksam.TabIndex = 0;
            // 
            // lblInsulinGece
            // 
            lblInsulinGece.Location = new Point(0, 0);
            lblInsulinGece.Name = "lblInsulinGece";
            lblInsulinGece.Size = new Size(100, 23);
            lblInsulinGece.TabIndex = 0;
            // 
            // PatientGlucoseFormm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(dtpEntryDate);
            Controls.Add(tableLayoutPanel1);
            Name = "PatientGlucoseFormm";
            Text = "Hasta Kan Şekeri Girişi";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudSabah).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOgle).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudIkindi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAksam).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGece).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeasurements).EndInit();
            ResumeLayout(false);
        }
        private DateTimePicker dtpEntryDate;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;




    }
}