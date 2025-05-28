using MaterialSkin.Controls;
using System.Windows.Forms;

namespace DiabetesTracker
{
    partial class AssignPatientForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cmbDoctors = new ComboBox();
            cmbPatients = new ComboBox();
            materialLabel1 = new MaterialLabel();
            materialLabel2 = new MaterialLabel();
            materialBtnAssign = new MaterialButton();
            SuspendLayout();
            // 
            // cmbDoctors
            // 
            cmbDoctors.FormattingEnabled = true;
            cmbDoctors.Location = new System.Drawing.Point(180, 100);
            cmbDoctors.Name = "cmbDoctors";
            cmbDoctors.Size = new System.Drawing.Size(250, 28);
            cmbDoctors.TabIndex = 0;
            // 
            // cmbPatients
            // 
            cmbPatients.FormattingEnabled = true;
            cmbPatients.Location = new System.Drawing.Point(180, 160);
            cmbPatients.Name = "cmbPatients";
            cmbPatients.Size = new System.Drawing.Size(250, 28);
            cmbPatients.TabIndex = 1;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Location = new System.Drawing.Point(60, 100);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new System.Drawing.Size(68, 20);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Doktor:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Location = new System.Drawing.Point(60, 160);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new System.Drawing.Size(64, 20);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Hasta:";
            // 
            // materialBtnAssign
            // 
            materialBtnAssign.AutoSize = false;
            materialBtnAssign.Depth = 0;
            materialBtnAssign.DrawShadows = true;
            materialBtnAssign.HighEmphasis = true;
            materialBtnAssign.Icon = null;
            materialBtnAssign.Location = new System.Drawing.Point(320, 220);
            materialBtnAssign.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            materialBtnAssign.MouseState = MaterialSkin.MouseState.HOVER;
            materialBtnAssign.Name = "materialBtnAssign";
            materialBtnAssign.Size = new System.Drawing.Size(110, 36);
            materialBtnAssign.TabIndex = 4;
            materialBtnAssign.Text = "Ata";
            materialBtnAssign.Type = MaterialButton.MaterialButtonType.Contained;
            materialBtnAssign.UseAccentColor = false;
            materialBtnAssign.UseVisualStyleBackColor = true;
            //
            // AssignPatientForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(600, 320);
            Controls.Add(materialBtnAssign);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(cmbPatients);
            Controls.Add(cmbDoctors);
            Name = "AssignPatientForm";
            Text = "Hasta Atama";
            Load += AssignPatientForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDoctors;
        private ComboBox cmbPatients;
        private MaterialLabel materialLabel1;
        private MaterialLabel materialLabel2;
        private MaterialButton materialBtnAssign;
    }
}
