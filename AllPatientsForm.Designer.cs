namespace DiabetesTracker
{
    partial class AllPatientsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvAllPatients = new DataGridView();
            cmbGlucoseFilter = new ComboBox();
            btnFilter = new Button();
            cmbSymptoms = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvAllPatients).BeginInit();
            SuspendLayout();
            // 
            // dgvAllPatients
            // 
            dgvAllPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllPatients.Location = new Point(195, 12);
            dgvAllPatients.Name = "dgvAllPatients";
            dgvAllPatients.RowHeadersWidth = 51;
            dgvAllPatients.Size = new Size(752, 465);
            dgvAllPatients.TabIndex = 0;
            // 
            // cmbGlucoseFilter
            // 
            cmbGlucoseFilter.FormattingEnabled = true;
            cmbGlucoseFilter.Location = new Point(12, 45);
            cmbGlucoseFilter.Name = "cmbGlucoseFilter";
            cmbGlucoseFilter.Size = new Size(151, 28);
            cmbGlucoseFilter.TabIndex = 1;
            cmbGlucoseFilter.SelectedIndexChanged += cmbGlucoseFilter_SelectedIndexChanged;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(12, 141);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filtrele";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // cmbSymptoms
            // 
            cmbSymptoms.FormattingEnabled = true;
            cmbSymptoms.Location = new Point(12, 94);
            cmbSymptoms.Name = "cmbSymptoms";
            cmbSymptoms.Size = new Size(151, 28);
            cmbSymptoms.TabIndex = 4;
            cmbSymptoms.SelectedIndexChanged += cmbSymptoms_SelectedIndexChanged;
            // 
            // AllPatientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 489);
            Controls.Add(cmbSymptoms);
            Controls.Add(btnFilter);
            Controls.Add(cmbGlucoseFilter);
            Controls.Add(dgvAllPatients);
            Name = "AllPatientsForm";
            Text = "AllPatientsForm";
            Load += AllPatientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAllPatients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAllPatients;
        private ComboBox cmbGlucoseFilter;
        private Button btnFilter;
        private ComboBox cmbSymptoms;
    }
}