namespace DiabetesTracker
{
    partial class PatientListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvPatients;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvPatients = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.SuspendLayout();

            // dgvPatients
            this.dgvPatients.Dock = DockStyle.Fill;
            this.dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPatients.ReadOnly = true;

            // PatientListForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.dgvPatients);
            this.Name = "PatientListForm";
            this.Text = "Hasta Listesi";

            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
