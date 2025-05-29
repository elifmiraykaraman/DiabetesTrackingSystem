namespace DiabetesTracker
{
    partial class GlucoseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvGlucose;
        private System.Windows.Forms.TextBox txtGluInput;
        private System.Windows.Forms.DateTimePicker dtpGluTime;
        private System.Windows.Forms.Button btnGluSave;
        private System.Windows.Forms.Label lblGluLevel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvGlucose = new DataGridView();
            txtGluInput = new TextBox();
            dtpGluTime = new DateTimePicker();
            btnGluSave = new Button();
            lblGluLevel = new Label();
            lblDailyAverage = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvGlucose).BeginInit();
            SuspendLayout();
            // 
            // dgvGlucose
            // 
            dgvGlucose.AllowUserToAddRows = false;
            dgvGlucose.AllowUserToDeleteRows = false;
            dgvGlucose.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGlucose.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGlucose.Dock = DockStyle.Bottom;
            dgvGlucose.Location = new Point(0, 200);
            dgvGlucose.Name = "dgvGlucose";
            dgvGlucose.ReadOnly = true;
            dgvGlucose.RowHeadersVisible = false;
            dgvGlucose.RowHeadersWidth = 51;
            dgvGlucose.Size = new Size(600, 250);
            dgvGlucose.TabIndex = 0;
            // 
            // txtGluInput
            // 
            txtGluInput.Location = new Point(140, 17);
            txtGluInput.Name = "txtGluInput";
            txtGluInput.Size = new Size(100, 27);
            txtGluInput.TabIndex = 2;
            // 
            // dtpGluTime
            // 
            dtpGluTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpGluTime.Format = DateTimePickerFormat.Custom;
            dtpGluTime.Location = new Point(20, 60);
            dtpGluTime.Name = "dtpGluTime";
            dtpGluTime.Size = new Size(220, 27);
            dtpGluTime.TabIndex = 3;
            // 
            // btnGluSave
            // 
            btnGluSave.Location = new Point(260, 58);
            btnGluSave.Name = "btnGluSave";
            btnGluSave.Size = new Size(94, 29);
            btnGluSave.TabIndex = 4;
            btnGluSave.Text = "Kaydet";
            btnGluSave.UseVisualStyleBackColor = true;
            // Designer içinde InitializeComponent() içerisinde:
            this.btnGluSave.Click += new System.EventHandler(this.BtnGluSave_Click);


            // 
            // lblGluLevel
            // 
            lblGluLevel.AutoSize = true;
            lblGluLevel.Location = new Point(20, 20);
            lblGluLevel.Name = "lblGluLevel";
            lblGluLevel.Size = new Size(113, 20);
            lblGluLevel.TabIndex = 1;
            lblGluLevel.Text = "Glukoz Seviyesi:";
            // 
            // lblDailyAverage
            // 
            lblDailyAverage.AutoSize = true;
            lblDailyAverage.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblDailyAverage.Location = new Point(20, 108);
            lblDailyAverage.Name = "lblDailyAverage";
            lblDailyAverage.Size = new Size(148, 20);
            lblDailyAverage.TabIndex = 5;
            lblDailyAverage.Text = "Günlük Ortalama: —";
            // 
            // GlucoseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(lblDailyAverage);
            Controls.Add(btnGluSave);
            Controls.Add(dtpGluTime);
            Controls.Add(txtGluInput);
            Controls.Add(lblGluLevel);
            Controls.Add(dgvGlucose);
            Name = "GlucoseForm";
            Text = "Kan Şekeri Girişi";
            Load += GlucoseForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGlucose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDailyAverage;
    }
}
