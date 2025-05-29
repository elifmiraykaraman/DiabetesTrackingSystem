
namespace DiabetesTracker
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            ölçümToolStripMenuItem = new ToolStripMenuItem();
            kanŞekeriToolStripMenuItem = new ToolStripMenuItem();
            kayıtToolStripMenuItem = new ToolStripMenuItem();
            diyetToolStripMenuItem = new ToolStripMenuItem();
            egzersizToolStripMenuItem = new ToolStripMenuItem();
            semptomToolStripMenuItem = new ToolStripMenuItem();
            raporToolStripMenuItem = new ToolStripMenuItem();
            özetGrafikToolStripMenuItem = new ToolStripMenuItem();
            çıkışToolStripMenuItem = new ToolStripMenuItem();
            panelContainer = new Panel();
            ölçümToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ölçümToolStripMenuItem, kayıtToolStripMenuItem, raporToolStripMenuItem, çıkışToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // ölçümToolStripMenuItem
            // 
            ölçümToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kanŞekeriToolStripMenuItem, ölçümToolStripMenuItem1 });
            ölçümToolStripMenuItem.Name = "ölçümToolStripMenuItem";
            ölçümToolStripMenuItem.Size = new Size(66, 24);
            ölçümToolStripMenuItem.Text = "Ölçüm";
            ölçümToolStripMenuItem.Click += ölçümToolStripMenuItem_Click;
            // 
            // kanŞekeriToolStripMenuItem
            // 
            kanŞekeriToolStripMenuItem.Name = "kanŞekeriToolStripMenuItem";
            kanŞekeriToolStripMenuItem.Size = new Size(224, 26);
            kanŞekeriToolStripMenuItem.Text = "Kan Şekeri";
      kanŞekeriToolStripMenuItem.Click += kanŞekeriToolStripMenuItem_Click;
            // 
            // kayıtToolStripMenuItem
            // 
            kayıtToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { diyetToolStripMenuItem, egzersizToolStripMenuItem, semptomToolStripMenuItem });
            kayıtToolStripMenuItem.Name = "kayıtToolStripMenuItem";
            kayıtToolStripMenuItem.Size = new Size(56, 24);
            kayıtToolStripMenuItem.Text = "Kayıt";
            kayıtToolStripMenuItem.Click += kayıtToolStripMenuItem_Click;
            // 
            // diyetToolStripMenuItem
            // 
            diyetToolStripMenuItem.Name = "diyetToolStripMenuItem";
            diyetToolStripMenuItem.Size = new Size(224, 26);
            diyetToolStripMenuItem.Text = "Diyet";
            diyetToolStripMenuItem.Click += diyetToolStripMenuItem_Click;
            // 
            // egzersizToolStripMenuItem
            // 
            egzersizToolStripMenuItem.Name = "egzersizToolStripMenuItem";
            egzersizToolStripMenuItem.Size = new Size(224, 26);
            egzersizToolStripMenuItem.Text = "Egzersiz";
            egzersizToolStripMenuItem.Click += egzersizToolStripMenuItem_Click;
            // 
            // semptomToolStripMenuItem
            // 
            semptomToolStripMenuItem.Name = "semptomToolStripMenuItem";
            semptomToolStripMenuItem.Size = new Size(224, 26);
            semptomToolStripMenuItem.Text = "Semptom";
            semptomToolStripMenuItem.Click += semptomToolStripMenuItem_Click;
            // 
            // raporToolStripMenuItem
            // 
            raporToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { özetGrafikToolStripMenuItem });
            raporToolStripMenuItem.Name = "raporToolStripMenuItem";
            raporToolStripMenuItem.Size = new Size(63, 24);
            raporToolStripMenuItem.Text = "Rapor";
            raporToolStripMenuItem.Click += raporToolStripMenuItem_Click;
            // 
            // özetGrafikToolStripMenuItem
            // 
            özetGrafikToolStripMenuItem.Name = "özetGrafikToolStripMenuItem";
            özetGrafikToolStripMenuItem.Size = new Size(166, 26);
            özetGrafikToolStripMenuItem.Text = "Özet Grafik";
            özetGrafikToolStripMenuItem.Click += özetGrafikToolStripMenuItem_Click;
            // 
            // çıkışToolStripMenuItem
            // 
            çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            çıkışToolStripMenuItem.Size = new Size(53, 24);
            çıkışToolStripMenuItem.Text = "Çıkış";
            çıkışToolStripMenuItem.Click += çıkışToolStripMenuItem_Click;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 28);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(800, 422);
            panelContainer.TabIndex = 1;
            // 
            // ölçümToolStripMenuItem1
            // 
            ölçümToolStripMenuItem1.Name = "ölçümToolStripMenuItem1";
            ölçümToolStripMenuItem1.Size = new Size(224, 26);
            ölçümToolStripMenuItem1.Text = "Ölçüm";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContainer);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void raporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void kayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ölçümToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Panel panelContainer;
        private ToolStripMenuItem ölçümToolStripMenuItem;
        private ToolStripMenuItem kanŞekeriToolStripMenuItem;
        private ToolStripMenuItem kayıtToolStripMenuItem;
        private ToolStripMenuItem raporToolStripMenuItem;
        private ToolStripMenuItem çıkışToolStripMenuItem;
        private ToolStripMenuItem diyetToolStripMenuItem;
        private ToolStripMenuItem egzersizToolStripMenuItem;
        private ToolStripMenuItem semptomToolStripMenuItem;
        private ToolStripMenuItem özetGrafikToolStripMenuItem;
        private ToolStripMenuItem ölçümToolStripMenuItem1;
    }
}