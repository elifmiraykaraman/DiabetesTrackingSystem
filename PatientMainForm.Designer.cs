namespace DiabetesTracker
{
    partial class PatientMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem kanŞekeriGirişiToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem egzersizToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem özetGrafikleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.DataGridView dgvRecommendations;
        private System.Windows.Forms.ToolStripMenuItem diyetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insülinFiltreleToolStripMenuItem;

        // MANUEL EKLENEN LABEL'LAR
        private System.Windows.Forms.Label lblDietPercent;
        private System.Windows.Forms.Label lblExercisePercent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            kanŞekeriGirişiToolStripMenuItem = new ToolStripMenuItem();
            egzersizToolStripMenuItem = new ToolStripMenuItem();
            diyetToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            özetGrafikleriToolStripMenuItem = new ToolStripMenuItem();
            insülinFiltreleToolStripMenuItem = new ToolStripMenuItem();
            çıkışToolStripMenuItem = new ToolStripMenuItem();
            panelContainer = new Panel();
            dgvRecommendations = new DataGridView();
            // LABEL nesneleri:
            lblDietPercent = new System.Windows.Forms.Label();
            lblExercisePercent = new System.Windows.Forms.Label();

            menuStrip1.SuspendLayout();
            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecommendations).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { kanŞekeriGirişiToolStripMenuItem, egzersizToolStripMenuItem, diyetToolStripMenuItem, toolStripSeparator1, özetGrafikleriToolStripMenuItem, çıkışToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // kanŞekeriGirişiToolStripMenuItem
            // 
            kanŞekeriGirişiToolStripMenuItem.Name = "kanŞekeriGirişiToolStripMenuItem";
            kanŞekeriGirişiToolStripMenuItem.Size = new Size(129, 24);
            kanŞekeriGirişiToolStripMenuItem.Text = "Kan Şekeri Girişi";
            // 
            // egzersizToolStripMenuItem
            // 
            egzersizToolStripMenuItem.Name = "egzersizToolStripMenuItem";
            egzersizToolStripMenuItem.Size = new Size(77, 24);
            egzersizToolStripMenuItem.Text = "Egzersiz";
            egzersizToolStripMenuItem.Click += egzersizToolStripMenuItem_Click;
            // 
            // diyetToolStripMenuItem
            // 
            diyetToolStripMenuItem.Name = "diyetToolStripMenuItem";
            diyetToolStripMenuItem.Size = new Size(58, 24);
            diyetToolStripMenuItem.Text = "Diyet";
            diyetToolStripMenuItem.Click += diyetToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 24);
            // 
            // özetGrafikleriToolStripMenuItem
            // 
            özetGrafikleriToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { insülinFiltreleToolStripMenuItem });
            özetGrafikleriToolStripMenuItem.Name = "özetGrafikleriToolStripMenuItem";
            özetGrafikleriToolStripMenuItem.Size = new Size(97, 24);
            özetGrafikleriToolStripMenuItem.Text = "Özet Grafik";
            // 
            // insülinFiltreleToolStripMenuItem
            // 
            insülinFiltreleToolStripMenuItem.Name = "insülinFiltreleToolStripMenuItem";
            insülinFiltreleToolStripMenuItem.Size = new Size(183, 26);
            insülinFiltreleToolStripMenuItem.Text = "İnsülin Filtrele";
            // 
            // çıkışToolStripMenuItem
            // 
            çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            çıkışToolStripMenuItem.Size = new Size(53, 24);
            çıkışToolStripMenuItem.Text = "Çıkış";
            // 
            // panelContainer
            // 
            panelContainer.Controls.Add(dgvRecommendations);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 28);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(800, 422);
            panelContainer.TabIndex = 1;
            // 
            // dgvRecommendations
            // 
            dgvRecommendations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecommendations.Location = new Point(0, 0);
            dgvRecommendations.Name = "dgvRecommendations";
            dgvRecommendations.RowHeadersWidth = 51;
            dgvRecommendations.Size = new Size(797, 261);
            dgvRecommendations.TabIndex = 2;
            // 
            // lblDietPercent
            // 
            lblDietPercent.AutoSize = true;
            lblDietPercent.Location = new Point(20, 400);  // Alt kısmında bir yerde göster
            lblDietPercent.Name = "lblDietPercent";
            lblDietPercent.Size = new Size(120, 20);
            lblDietPercent.TabIndex = 3;
            lblDietPercent.Text = "";
            // 
            // lblExercisePercent
            // 
            lblExercisePercent.AutoSize = true;
            lblExercisePercent.Location = new Point(200, 400); // Yine alt kısımda yanına göster
            lblExercisePercent.Name = "lblExercisePercent";
            lblExercisePercent.Size = new Size(140, 20);
            lblExercisePercent.TabIndex = 4;
            lblExercisePercent.Text = "";
            // 
            // PatientMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDietPercent);
            Controls.Add(lblExercisePercent);
            Controls.Add(panelContainer);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "PatientMainForm";
            Text = "Hasta Paneli";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecommendations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
