namespace DiabetesTracker
{
    partial class HastaEkleForm
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
        /// Required method for Designer support – do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTc = new TextBox();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dtpBirthDate = new DateTimePicker();
            cmbGender = new ComboBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtTc
            // 
            txtTc.Location = new Point(180, 37);
            txtTc.Name = "txtTc";
            txtTc.Size = new Size(250, 27);
            txtTc.TabIndex = 0;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(180, 113);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(250, 27);
            txtFullName.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(180, 188);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(30, 37);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 3;
            label1.Text = "TC Kimlik Numarası :\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(30, 113);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 4;
            label2.Text = "Ad Soyad :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(30, 191);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 5;
            label3.Text = "E posta :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(30, 334);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 6;
            label4.Text = "Cinsiyet :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(30, 258);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 7;
            label5.Text = "Doğum Tarihi :";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(180, 258);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(250, 27);
            dtpBirthDate.TabIndex = 8;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(180, 331);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(151, 28);
            cmbGender.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.ForeColor = SystemColors.ActiveCaptionText;
            btnSave.Location = new Point(676, 334);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // HastaEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(cmbGender);
            Controls.Add(dtpBirthDate);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(txtTc);
            Name = "HastaEkleForm";
            Text = "HastaEkleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Button btnSave;
    }
}

