namespace DiabetesTracker
{
    partial class ÖneriGirisForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblDiet = new Label();
            cmbDietType = new ComboBox();
            lblExercis = new Label();
            cmbExerciseType = new ComboBox();
            lblNote = new Label();
            txtNote = new TextBox();
            btnSave = new Button();
            dgvRecommendations = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecommendations).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(lblDiet, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbDietType, 1, 0);
            tableLayoutPanel1.Controls.Add(lblExercis, 0, 1);
            tableLayoutPanel1.Controls.Add(cmbExerciseType, 1, 1);
            tableLayoutPanel1.Controls.Add(lblNote, 0, 2);
            tableLayoutPanel1.Controls.Add(txtNote, 1, 2);
            tableLayoutPanel1.Controls.Add(btnSave, 0, 3);
            tableLayoutPanel1.Controls.Add(dgvRecommendations, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblDiet
            // 
            lblDiet.AutoSize = true;
            lblDiet.Location = new Point(3, 0);
            lblDiet.Name = "lblDiet";
            lblDiet.Size = new Size(80, 20);
            lblDiet.TabIndex = 0;
            lblDiet.Text = "Diyet Türü:";
            // 
            // cmbDietType
            // 
            cmbDietType.Dock = DockStyle.Fill;
            cmbDietType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDietType.FormattingEnabled = true;
            cmbDietType.Location = new Point(323, 3);
            cmbDietType.Name = "cmbDietType";
            cmbDietType.Size = new Size(474, 28);
            cmbDietType.TabIndex = 1;
            // 
            // lblExercis
            // 
            lblExercis.AutoSize = true;
            lblExercis.Location = new Point(3, 30);
            lblExercis.Name = "lblExercis";
            lblExercis.Size = new Size(99, 20);
            lblExercis.TabIndex = 2;
            lblExercis.Text = "Egzersiz Türü:";
            // 
            // cmbExerciseType
            // 
            cmbExerciseType.Dock = DockStyle.Fill;
            cmbExerciseType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExerciseType.FormattingEnabled = true;
            cmbExerciseType.Location = new Point(323, 33);
            cmbExerciseType.Name = "cmbExerciseType";
            cmbExerciseType.Size = new Size(474, 28);
            cmbExerciseType.TabIndex = 3;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Location = new Point(3, 60);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(73, 20);
            lblNote.TabIndex = 4;
            lblNote.Text = "Açıklama:";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(323, 63);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = ScrollBars.Vertical;
            txtNote.Size = new Size(125, 34);
            txtNote.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            tableLayoutPanel1.SetColumnSpan(btnSave, 2);
            btnSave.Location = new Point(353, 145);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // dgvRecommendations
            // 
            dgvRecommendations.AllowUserToAddRows = false;
            dgvRecommendations.AllowUserToDeleteRows = false;
            dgvRecommendations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRecommendations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgvRecommendations, 2);
            dgvRecommendations.Dock = DockStyle.Fill;
            dgvRecommendations.Location = new Point(3, 433);
            dgvRecommendations.Name = "dgvRecommendations";
            dgvRecommendations.ReadOnly = true;
            dgvRecommendations.RowHeadersVisible = false;
            dgvRecommendations.RowHeadersWidth = 51;
            dgvRecommendations.Size = new Size(794, 14);
            dgvRecommendations.TabIndex = 7;
            // 
            // ÖneriGirisForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ÖneriGirisForm";
            Text = "ÖneriGirisForm";
            Load += ÖneriGirisForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecommendations).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblDiet;
        private ComboBox cmbDietType;
        private Label lblExercis;
        private ComboBox cmbExerciseType;
        private Label lblNote;
        private TextBox txtNote;
        private Button btnSave;
        private DataGridView dgvRecommendations;
    }
}
