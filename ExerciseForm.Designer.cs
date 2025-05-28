namespace DiabetesTracker
{
    partial class ExerciseForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvExercises;
        private Label lblExercisePercent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            dgvExercises = new DataGridView();
            lblExercisePercent = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvExercises).BeginInit();
            SuspendLayout();
            // 
            // dgvExercises
            // 
            dgvExercises.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExercises.Dock = DockStyle.Fill;
            dgvExercises.Location = new Point(0, 0);
            dgvExercises.Margin = new Padding(3, 4, 3, 4);
            dgvExercises.Name = "dgvExercises";
            dgvExercises.RowHeadersWidth = 51;
            dgvExercises.Size = new Size(828, 432);
            dgvExercises.TabIndex = 0;
            dgvExercises.CellContentClick += dgvExercises_CellContentClick;
            // 
            // lblExercisePercent
            // 
            lblExercisePercent.AutoSize = true;
            lblExercisePercent.Location = new Point(12, 366);
            lblExercisePercent.Name = "lblExercisePercent";
            lblExercisePercent.Size = new Size(50, 20);
            lblExercisePercent.TabIndex = 1;
            lblExercisePercent.Text = "label1";
            // 
            // ExerciseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 432);
            Controls.Add(lblExercisePercent);
            Controls.Add(dgvExercises);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ExerciseForm";
            Text = "Egzersiz Kayıtları";
            ((System.ComponentModel.ISupportInitialize)dgvExercises).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
