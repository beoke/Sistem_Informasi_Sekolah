namespace Sistem_Informasi_Sekolah.Jadwal_Pelajaran
{
    partial class Form_JadwalPelajaran
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
            panel2 = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            Guru_combo = new ComboBox();
            Mapel_combo = new ComboBox();
            Hari_combo = new ComboBox();
            JenisJadwal_combo = new ComboBox();
            Selesai_text = new TextBox();
            JamMulai_text = new TextBox();
            panel3 = new Panel();
            KelasName_text = new TextBox();
            KelasId_text = new TextBox();
            label4 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            New_button = new Button();
            Save_button = new Button();
            Delete_button = new Button();
            label2 = new Label();
            panel4 = new Panel();
            Khusus_radio = new RadioButton();
            Umum_radio = new RadioButton();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SkyBlue;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(704, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 464);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left;
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(Guru_combo);
            panel2.Controls.Add(Mapel_combo);
            panel2.Controls.Add(Hari_combo);
            panel2.Controls.Add(JenisJadwal_combo);
            panel2.Controls.Add(Selesai_text);
            panel2.Controls.Add(JamMulai_text);
            panel2.Location = new Point(15, 136);
            panel2.Name = "panel2";
            panel2.Size = new Size(230, 321);
            panel2.TabIndex = 4;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(13, 266);
            label10.Name = "label10";
            label10.Size = new Size(36, 17);
            label10.TabIndex = 9;
            label10.Text = "Guru";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(13, 216);
            label9.Name = "label9";
            label9.Size = new Size(45, 17);
            label9.TabIndex = 8;
            label9.Text = "Mapel";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(12, 115);
            label8.Name = "label8";
            label8.Size = new Size(67, 17);
            label8.TabIndex = 7;
            label8.Text = "Jam Mulai";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(13, 163);
            label7.Name = "label7";
            label7.Size = new Size(48, 17);
            label7.TabIndex = 7;
            label7.Text = "Selesai";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(13, 64);
            label6.Name = "label6";
            label6.Size = new Size(36, 17);
            label6.TabIndex = 6;
            label6.Text = "Hari ";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(13, 16);
            label5.Name = "label5";
            label5.Size = new Size(79, 17);
            label5.TabIndex = 5;
            label5.Text = "Jenis Jadwal";
            // 
            // Guru_combo
            // 
            Guru_combo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Guru_combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Guru_combo.FormattingEnabled = true;
            Guru_combo.Location = new Point(12, 286);
            Guru_combo.Name = "Guru_combo";
            Guru_combo.Size = new Size(206, 25);
            Guru_combo.TabIndex = 4;
            // 
            // Mapel_combo
            // 
            Mapel_combo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Mapel_combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Mapel_combo.FormattingEnabled = true;
            Mapel_combo.Location = new Point(13, 236);
            Mapel_combo.Name = "Mapel_combo";
            Mapel_combo.Size = new Size(205, 25);
            Mapel_combo.TabIndex = 4;
            // 
            // Hari_combo
            // 
            Hari_combo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Hari_combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Hari_combo.FormattingEnabled = true;
            Hari_combo.Location = new Point(12, 84);
            Hari_combo.Name = "Hari_combo";
            Hari_combo.Size = new Size(206, 25);
            Hari_combo.TabIndex = 3;
            // 
            // JenisJadwal_combo
            // 
            JenisJadwal_combo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            JenisJadwal_combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            JenisJadwal_combo.FormattingEnabled = true;
            JenisJadwal_combo.Location = new Point(12, 36);
            JenisJadwal_combo.Name = "JenisJadwal_combo";
            JenisJadwal_combo.Size = new Size(205, 25);
            JenisJadwal_combo.TabIndex = 2;
            // 
            // Selesai_text
            // 
            Selesai_text.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Selesai_text.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Selesai_text.Location = new Point(13, 183);
            Selesai_text.Name = "Selesai_text";
            Selesai_text.Size = new Size(206, 25);
            Selesai_text.TabIndex = 1;
            // 
            // JamMulai_text
            // 
            JamMulai_text.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            JamMulai_text.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            JamMulai_text.Location = new Point(12, 135);
            JamMulai_text.Name = "JamMulai_text";
            JamMulai_text.Size = new Size(206, 25);
            JamMulai_text.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientInactiveCaption;
            panel3.Controls.Add(KelasName_text);
            panel3.Controls.Add(KelasId_text);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(15, 7);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 119);
            panel3.TabIndex = 3;
            // 
            // KelasName_text
            // 
            KelasName_text.Anchor = AnchorStyles.Left;
            KelasName_text.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            KelasName_text.Location = new Point(10, 79);
            KelasName_text.Name = "KelasName_text";
            KelasName_text.Size = new Size(207, 25);
            KelasName_text.TabIndex = 2;
            // 
            // KelasId_text
            // 
            KelasId_text.Anchor = AnchorStyles.Left;
            KelasId_text.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            KelasId_text.Location = new Point(14, 33);
            KelasId_text.Name = "KelasId_text";
            KelasId_text.Size = new Size(203, 25);
            KelasId_text.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 61);
            label4.Name = "label4";
            label4.Size = new Size(78, 17);
            label4.TabIndex = 0;
            label4.Text = "Kelas Name";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 15);
            label3.Name = "label3";
            label3.Size = new Size(54, 17);
            label3.TabIndex = 0;
            label3.Text = "Kelas Id";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(692, 431);
            dataGridView1.TabIndex = 5;
            // 
            // New_button
            // 
            New_button.Location = new Point(719, 511);
            New_button.Name = "New_button";
            New_button.Size = new Size(75, 23);
            New_button.TabIndex = 1;
            New_button.Text = "New";
            New_button.UseVisualStyleBackColor = true;
            // 
            // Save_button
            // 
            Save_button.Location = new Point(801, 511);
            Save_button.Name = "Save_button";
            Save_button.Size = new Size(75, 23);
            Save_button.TabIndex = 2;
            Save_button.Text = "Save";
            Save_button.UseVisualStyleBackColor = true;
            // 
            // Delete_button
            // 
            Delete_button.Location = new Point(882, 511);
            Delete_button.Name = "Delete_button";
            Delete_button.Size = new Size(75, 23);
            Delete_button.TabIndex = 3;
            Delete_button.Text = "Delete";
            Delete_button.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(971, 34);
            label2.TabIndex = 7;
            label2.Text = "Jadwal Pelajaran";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.SkyBlue;
            panel4.Controls.Add(Khusus_radio);
            panel4.Controls.Add(Umum_radio);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(dataGridView1);
            panel4.Location = new Point(0, 41);
            panel4.Name = "panel4";
            panel4.Size = new Size(698, 464);
            panel4.TabIndex = 8;
            // 
            // Khusus_radio
            // 
            Khusus_radio.AutoSize = true;
            Khusus_radio.Location = new Point(362, 4);
            Khusus_radio.Name = "Khusus_radio";
            Khusus_radio.Size = new Size(63, 19);
            Khusus_radio.TabIndex = 9;
            Khusus_radio.TabStop = true;
            Khusus_radio.Text = "Khusus";
            Khusus_radio.UseVisualStyleBackColor = true;
            // 
            // Umum_radio
            // 
            Umum_radio.AutoSize = true;
            Umum_radio.Location = new Point(294, 4);
            Umum_radio.Name = "Umum_radio";
            Umum_radio.Size = new Size(62, 19);
            Umum_radio.TabIndex = 8;
            Umum_radio.TabStop = true;
            Umum_radio.Text = "Umum";
            Umum_radio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 6);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 7;
            label1.Text = "Jenis Jadwal";
            // 
            // Form_JadwalPelajaran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(971, 546);
            Controls.Add(panel4);
            Controls.Add(label2);
            Controls.Add(Delete_button);
            Controls.Add(Save_button);
            Controls.Add(panel1);
            Controls.Add(New_button);
            Name = "Form_JadwalPelajaran";
            Text = "Form_JadwalPelajaran";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Button New_button;
        private Button Save_button;
        private Button Delete_button;
        private Panel panel3;
        private Label label2;
        private TextBox KelasName_text;
        private TextBox KelasId_text;
        private Label label4;
        private Label label3;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private ComboBox Guru_combo;
        private ComboBox Mapel_combo;
        private ComboBox Hari_combo;
        private ComboBox JenisJadwal_combo;
        private TextBox Selesai_text;
        private TextBox JamMulai_text;
        private Panel panel4;
        private RadioButton Khusus_radio;
        private RadioButton Umum_radio;
        private Label label1;
    }
}