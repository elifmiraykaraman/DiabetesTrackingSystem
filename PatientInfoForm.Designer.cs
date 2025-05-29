namespace DiabetesTracker
{
    partial class PatientInfoForm
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
            lblTc = new Label();
            lblName = new Label();
            lblEmail = new Label();
            lblBirth = new Label();
            lblGender = new Label();
            picPhoto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // lblTc
            // 
            lblTc.AutoSize = true;
            lblTc.Location = new Point(182, 87);
            lblTc.Name = "lblTc";
            lblTc.Size = new Size(28, 20);
            lblTc.TabIndex = 0;
            lblTc.Text = "TC:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(182, 139);
            lblName.Name = "lblName";
            lblName.Size = new Size(76, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Ad Soayd:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(182, 195);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "E mail:";
            // 
            // lblBirth
            // 
            lblBirth.AutoSize = true;
            lblBirth.Location = new Point(182, 245);
            lblBirth.Name = "lblBirth";
            lblBirth.Size = new Size(101, 20);
            lblBirth.TabIndex = 3;
            lblBirth.Text = "Doğum Tarihi:";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(182, 295);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(63, 20);
            lblGender.TabIndex = 4;
            lblGender.Text = "Cinsiyet:";
            // 
            // picPhoto
            // 
            picPhoto.Location = new Point(21, 12);
            picPhoto.Name = "picPhoto";
            picPhoto.SizeMode = PictureBoxSizeMode.Zoom; // veya StretchImage
            picPhoto.TabIndex = 5;
            picPhoto.TabStop = false;
            picPhoto.Click += picPhoto_Click;
            // 
            // PatientInfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(picPhoto);
            Controls.Add(lblGender);
            Controls.Add(lblBirth);
            Controls.Add(lblEmail);
            Controls.Add(lblName);
            Controls.Add(lblTc);
            Name = "PatientInfoForm";
            Text = "PatientInfoForm";
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTc;
        private Label lblName;
        private Label lblEmail;
        private Label lblBirth;
        private Label lblGender;
        private PictureBox picPhoto;
    }
}