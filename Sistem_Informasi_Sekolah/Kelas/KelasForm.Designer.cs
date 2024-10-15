namespace Sistem_Informasi_Sekolah
{
    partial class KelasForm
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
            panel1 = new Panel();
            GridKelas = new DataGridView();
            panel2 = new Panel();
            FlagText = new MaskedTextBox();
            label6 = new Label();
            tx_KelasName = new TextBox();
            cb_KelasJurusan = new ComboBox();
            label5 = new Label();
            rb_10 = new RadioButton();
            rb_11 = new RadioButton();
            rb_12 = new RadioButton();
            label4 = new Label();
            tx_KelasId = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btn_newKelas = new Button();
            btn_deleteKelas = new Button();
            btn_SaveKelas = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridKelas).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(GridKelas);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btn_newKelas);
            panel1.Controls.Add(btn_deleteKelas);
            panel1.Controls.Add(btn_SaveKelas);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(-3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(767, 420);
            panel1.TabIndex = 2;
            // 
            // GridKelas
            // 
            GridKelas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridKelas.Location = new Point(266, 47);
            GridKelas.Name = "GridKelas";
            GridKelas.RowTemplate.Height = 25;
            GridKelas.Size = new Size(491, 362);
            GridKelas.TabIndex = 31;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SkyBlue;
            panel2.Controls.Add(FlagText);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(tx_KelasName);
            panel2.Controls.Add(cb_KelasJurusan);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(rb_10);
            panel2.Controls.Add(rb_11);
            panel2.Controls.Add(rb_12);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(tx_KelasId);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(15, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(245, 299);
            panel2.TabIndex = 15;
            // 
            // FlagText
            // 
            FlagText.Location = new Point(14, 260);
            FlagText.Name = "FlagText";
            FlagText.Size = new Size(65, 29);
            FlagText.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 232);
            label6.Name = "label6";
            label6.Size = new Size(39, 22);
            label6.TabIndex = 29;
            label6.Text = "Flag";
            // 
            // tx_KelasName
            // 
            tx_KelasName.Location = new Point(12, 88);
            tx_KelasName.Name = "tx_KelasName";
            tx_KelasName.ReadOnly = true;
            tx_KelasName.Size = new Size(217, 29);
            tx_KelasName.TabIndex = 28;
            // 
            // cb_KelasJurusan
            // 
            cb_KelasJurusan.FormattingEnabled = true;
            cb_KelasJurusan.Location = new Point(14, 199);
            cb_KelasJurusan.Name = "cb_KelasJurusan";
            cb_KelasJurusan.Size = new Size(219, 30);
            cb_KelasJurusan.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 120);
            label5.Name = "label5";
            label5.Size = new Size(61, 22);
            label5.TabIndex = 26;
            label5.Text = "Tingkat";
            // 
            // rb_10
            // 
            rb_10.AutoSize = true;
            rb_10.Location = new Point(12, 145);
            rb_10.Name = "rb_10";
            rb_10.Size = new Size(44, 26);
            rb_10.TabIndex = 25;
            rb_10.TabStop = true;
            rb_10.Text = "10";
            rb_10.UseVisualStyleBackColor = true;
            // 
            // rb_11
            // 
            rb_11.AutoSize = true;
            rb_11.Location = new Point(62, 145);
            rb_11.Name = "rb_11";
            rb_11.Size = new Size(44, 26);
            rb_11.TabIndex = 24;
            rb_11.TabStop = true;
            rb_11.Text = "11";
            rb_11.UseVisualStyleBackColor = true;
            // 
            // rb_12
            // 
            rb_12.AutoSize = true;
            rb_12.Location = new Point(116, 145);
            rb_12.Name = "rb_12";
            rb_12.Size = new Size(44, 26);
            rb_12.TabIndex = 23;
            rb_12.TabStop = true;
            rb_12.Text = "12";
            rb_12.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 174);
            label4.Name = "label4";
            label4.Size = new Size(58, 22);
            label4.TabIndex = 22;
            label4.Text = "Jurusan";
            // 
            // tx_KelasId
            // 
            tx_KelasId.Location = new Point(12, 31);
            tx_KelasId.Name = "tx_KelasId";
            tx_KelasId.ReadOnly = true;
            tx_KelasId.Size = new Size(221, 29);
            tx_KelasId.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(46, 22);
            label3.TabIndex = 20;
            label3.Text = "Kelas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 6);
            label2.Name = "label2";
            label2.Size = new Size(67, 22);
            label2.TabIndex = 19;
            label2.Text = "Kelas ID";
            // 
            // btn_newKelas
            // 
            btn_newKelas.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_newKelas.Location = new Point(24, 359);
            btn_newKelas.Name = "btn_newKelas";
            btn_newKelas.Size = new Size(67, 33);
            btn_newKelas.TabIndex = 14;
            btn_newKelas.Text = "New";
            btn_newKelas.UseVisualStyleBackColor = true;
            // 
            // btn_deleteKelas
            // 
            btn_deleteKelas.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_deleteKelas.Location = new Point(105, 359);
            btn_deleteKelas.Name = "btn_deleteKelas";
            btn_deleteKelas.Size = new Size(67, 33);
            btn_deleteKelas.TabIndex = 3;
            btn_deleteKelas.Text = "Delete";
            btn_deleteKelas.UseVisualStyleBackColor = true;
            // 
            // btn_SaveKelas
            // 
            btn_SaveKelas.Location = new Point(178, 359);
            btn_SaveKelas.Name = "btn_SaveKelas";
            btn_SaveKelas.Size = new Size(67, 33);
            btn_SaveKelas.TabIndex = 2;
            btn_SaveKelas.Text = "Save";
            btn_SaveKelas.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BackColor = Color.SkyBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Sylfaen", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(767, 32);
            label1.TabIndex = 1;
            label1.Text = "KELAS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // KelasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 421);
            Controls.Add(panel1);
            Name = "KelasForm";
            Text = "KelasForm";
            Load += KelasForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GridKelas).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_newKelas;
        private Button btn_deleteKelas;
        private Button btn_SaveKelas;
        private Label label1;
        private Panel panel2;
        private MaskedTextBox FlagText;
        private Label label6;
        private TextBox tx_KelasName;
        private ComboBox cb_KelasJurusan;
        private Label label5;
        private RadioButton rb_10;
        private RadioButton rb_11;
        private RadioButton rb_12;
        private Label label4;
        private TextBox tx_KelasId;
        private Label label3;
        private Label label2;
        private DataGridView GridKelas;
    }
}