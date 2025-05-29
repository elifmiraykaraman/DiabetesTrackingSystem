namespace DiabetesTracker
{
    partial class InsulinFilterForm
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
            lblStart = new Label();
            dtpStart = new DateTimePicker();
            lblEnd = new Label();
            btnFilter = new Button();
            dtpEnd = new DateTimePicker();
            dgvInsulin = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInsulin).BeginInit();
            SuspendLayout();
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(74, 46);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(114, 20);
            lblStart.TabIndex = 0;
            lblStart.Text = "Başlangıç Tarihi:";
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(195, 41);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 1;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(109, 123);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(79, 20);
            lblEnd.TabIndex = 2;
            lblEnd.Text = "Bitiş Tarihi:";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(506, 79);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filtrele";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(195, 116);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(250, 27);
            dtpEnd.TabIndex = 4;
            // 
            // dgvInsulin
            // 
            dgvInsulin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInsulin.Location = new Point(109, 160);
            dgvInsulin.Name = "dgvInsulin";
            dgvInsulin.RowHeadersWidth = 51;
            dgvInsulin.Size = new Size(491, 278);
            dgvInsulin.TabIndex = 5;
            // 
            // InsulinFilterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvInsulin);
            Controls.Add(dtpEnd);
            Controls.Add(btnFilter);
            Controls.Add(lblEnd);
            Controls.Add(dtpStart);
            Controls.Add(lblStart);
            Name = "InsulinFilterForm";
            Text = "InsulinFilterForm";
            Load += InsulinFilterForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInsulin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStart;
        private DateTimePicker dtpStart;
        private Label lblEnd;
        private Button btnFilter;
        private DateTimePicker dtpEnd;
        private DataGridView dgvInsulin;
    }
}