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
            FlagText = new MaskedTextBox();
            label6 = new Label();
            tx_KelasName = new TextBox();
            cb_KelasJurusan = new ComboBox();
            btn_newKelas = new Button();
            label5 = new Label();
            rb_10 = new RadioButton();
            rb_11 = new RadioButton();
            rb_12 = new RadioButton();
            label4 = new Label();
            tx_KelasId = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btn_deleteKelas = new Button();
            btn_SaveKelas = new Button();
            label1 = new Label();
            GridKelas = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridKelas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(FlagText);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(tx_KelasName);
            panel1.Controls.Add(cb_KelasJurusan);
            panel1.Controls.Add(btn_newKelas);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(rb_10);
            panel1.Controls.Add(rb_11);
            panel1.Controls.Add(rb_12);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(tx_KelasId);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btn_deleteKelas);
            panel1.Controls.Add(btn_SaveKelas);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(GridKelas);
            panel1.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(730, 397);
            panel1.TabIndex = 2;
            // 
            // FlagText
            // 
            FlagText.Location = new Point(493, 301);
            FlagText.Name = "FlagText";
            FlagText.Size = new Size(65, 29);
            FlagText.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(492, 273);
            label6.Name = "label6";
            label6.Size = new Size(39, 22);
            label6.TabIndex = 17;
            label6.Text = "Flag";
            // 
            // tx_KelasName
            // 
            tx_KelasName.Location = new Point(491, 129);
            tx_KelasName.Name = "tx_KelasName";
            tx_KelasName.ReadOnly = true;
            tx_KelasName.Size = new Size(217, 29);
            tx_KelasName.TabIndex = 16;
            // 
            // cb_KelasJurusan
            // 
            cb_KelasJurusan.FormattingEnabled = true;
            cb_KelasJurusan.Location = new Point(493, 240);
            cb_KelasJurusan.Name = "cb_KelasJurusan";
            cb_KelasJurusan.Size = new Size(219, 30);
            cb_KelasJurusan.TabIndex = 15;
            // 
            // btn_newKelas
            // 
            btn_newKelas.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_newKelas.Location = new Point(491, 350);
            btn_newKelas.Name = "btn_newKelas";
            btn_newKelas.Size = new Size(67, 33);
            btn_newKelas.TabIndex = 14;
            btn_newKelas.Text = "New";
            btn_newKelas.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(491, 161);
            label5.Name = "label5";
            label5.Size = new Size(61, 22);
            label5.TabIndex = 13;
            label5.Text = "Tingkat";
            // 
            // rb_10
            // 
            rb_10.AutoSize = true;
            rb_10.Location = new Point(491, 186);
            rb_10.Name = "rb_10";
            rb_10.Size = new Size(44, 26);
            rb_10.TabIndex = 12;
            rb_10.TabStop = true;
            rb_10.Text = "10";
            rb_10.UseVisualStyleBackColor = true;
            // 
            // rb_11
            // 
            rb_11.AutoSize = true;
            rb_11.Location = new Point(541, 186);
            rb_11.Name = "rb_11";
            rb_11.Size = new Size(44, 26);
            rb_11.TabIndex = 11;
            rb_11.TabStop = true;
            rb_11.Text = "11";
            rb_11.UseVisualStyleBackColor = true;
            // 
            // rb_12
            // 
            rb_12.AutoSize = true;
            rb_12.Location = new Point(595, 186);
            rb_12.Name = "rb_12";
            rb_12.Size = new Size(44, 26);
            rb_12.TabIndex = 10;
            rb_12.TabStop = true;
            rb_12.Text = "12";
            rb_12.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(491, 215);
            label4.Name = "label4";
            label4.Size = new Size(58, 22);
            label4.TabIndex = 8;
            label4.Text = "Jurusan";
            // 
            // tx_KelasId
            // 
            tx_KelasId.Location = new Point(491, 72);
            tx_KelasId.Name = "tx_KelasId";
            tx_KelasId.ReadOnly = true;
            tx_KelasId.Size = new Size(221, 29);
            tx_KelasId.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(491, 104);
            label3.Name = "label3";
            label3.Size = new Size(46, 22);
            label3.TabIndex = 5;
            label3.Text = "Kelas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(491, 47);
            label2.Name = "label2";
            label2.Size = new Size(67, 22);
            label2.TabIndex = 4;
            label2.Text = "Kelas ID";
            // 
            // btn_deleteKelas
            // 
            btn_deleteKelas.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_deleteKelas.Location = new Point(572, 350);
            btn_deleteKelas.Name = "btn_deleteKelas";
            btn_deleteKelas.Size = new Size(67, 33);
            btn_deleteKelas.TabIndex = 3;
            btn_deleteKelas.Text = "Delete";
            btn_deleteKelas.UseVisualStyleBackColor = true;
            // 
            // btn_SaveKelas
            // 
            btn_SaveKelas.Location = new Point(645, 350);
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
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(730, 32);
            label1.TabIndex = 1;
            label1.Text = "KELAS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GridKelas
            // 
            GridKelas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridKelas.Location = new Point(3, 35);
            GridKelas.Name = "GridKelas";
            GridKelas.RowTemplate.Height = 25;
            GridKelas.Size = new Size(464, 362);
            GridKelas.TabIndex = 0;
            // 
            // KelasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 421);
            Controls.Add(panel1);
            Name = "KelasForm";
            Text = "KelasForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridKelas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_newKelas;
        private Label label5;
        private RadioButton rb_10;
        private RadioButton rb_11;
        private RadioButton rb_12;
        private Label label4;
        private TextBox tx_KelasId;
        private Label label3;
        private Label label2;
        private Button btn_deleteKelas;
        private Button btn_SaveKelas;
        private Label label1;
        private DataGridView GridKelas;
        private ComboBox cb_KelasJurusan;
        private TextBox tx_KelasName;
        private Label label6;
        private MaskedTextBox FlagText;
    }
}