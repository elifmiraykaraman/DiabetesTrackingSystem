namespace DiabetesTracker
{
    partial class RecommendationApproveForm
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
            dgvPendingRecommendations = new DataGridView();
            btnApprove = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPendingRecommendations).BeginInit();
            SuspendLayout();
            // 
            // dgvPendingRecommendations
            // 
            dgvPendingRecommendations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendingRecommendations.Location = new Point(2, 1);
            dgvPendingRecommendations.Name = "dgvPendingRecommendations";
            dgvPendingRecommendations.RowHeadersWidth = 51;
            dgvPendingRecommendations.Size = new Size(798, 251);
            dgvPendingRecommendations.TabIndex = 0;
            dgvPendingRecommendations.AutoGenerateColumns = true;

            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(674, 281);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(94, 29);
            btnApprove.TabIndex = 1;
            btnApprove.Text = "Onayla";
            btnApprove.UseVisualStyleBackColor = true;
            // 
            // RecommendationApproveForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnApprove);
            Controls.Add(dgvPendingRecommendations);
            Name = "RecommendationApproveForm";
            Text = "RecommendationApproveForm";
            ((System.ComponentModel.ISupportInitialize)dgvPendingRecommendations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPendingRecommendations;
        private Button btnApprove;
    }
}