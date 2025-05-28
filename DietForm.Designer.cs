namespace DiabetesTracker
{
    partial class DietForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDiet;
        private System.Windows.Forms.Label lblDietPercent;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void DietForm_Load(object sender, EventArgs e)
        {
            LoadDietRecommendations();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDiet = new System.Windows.Forms.DataGridView();
            this.lblDietPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiet
            // 
            this.dgvDiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiet.Location = new System.Drawing.Point(10, 10);
            this.dgvDiet.Name = "dgvDiet";
            this.dgvDiet.Size = new System.Drawing.Size(770, 350);
            this.dgvDiet.TabIndex = 0;
            // 
            // lblDietPercent
            // 
            this.lblDietPercent.AutoSize = true;
            this.lblDietPercent.Location = new System.Drawing.Point(10, 370);
            this.lblDietPercent.Name = "lblDietPercent";
            this.lblDietPercent.Size = new System.Drawing.Size(120, 20);
            this.lblDietPercent.TabIndex = 1;
            this.lblDietPercent.Text = "Diyet Tamamlama: %0";
            // 
            // DietForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.lblDietPercent);
            this.Controls.Add(this.dgvDiet);
            this.Name = "DietForm";
            this.Text = "Diyet Kayıtları";
            this.Load += new System.EventHandler(this.DietForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
