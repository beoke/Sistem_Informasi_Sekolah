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
            label2 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            KelasNama_combo = new ComboBox();
            JenisJadwal_combo = new ComboBox();
            Hari_combo = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            panel2 = new Panel();
            Mapel_combo = new ComboBox();
            New_button = new Button();
            Guru_combo = new ComboBox();
            label7 = new Label();
            Save_button = new Button();
            label8 = new Label();
            Delete_button = new Button();
            label9 = new Label();
            label10 = new Label();
            panel4 = new Panel();
            TimeslotIdLabel = new Label();
            JamSelesai_mask = new MaskedTextBox();
            JamMulai_mask = new MaskedTextBox();
            Keterangan_text = new TextBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            MapelUmum_grid = new DataGridView();
            tabPage2 = new TabPage();
            MapelKhusus_grid = new DataGridView();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MapelUmum_grid).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MapelKhusus_grid).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.BackColor = Color.SkyBlue;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(971, 34);
            label2.TabIndex = 7;
            label2.Text = "Jadwal Pelajaran";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(11, 10);
            label3.Name = "label3";
            label3.Size = new Size(43, 17);
            label3.TabIndex = 0;
            label3.Text = "Kelas ";
            // 
            // panel3
            // 
            panel3.BackColor = Color.SkyBlue;
            panel3.Controls.Add(KelasNama_combo);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(12, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(246, 72);
            panel3.TabIndex = 3;
            // 
            // KelasNama_combo
            // 
            KelasNama_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            KelasNama_combo.FormattingEnabled = true;
            KelasNama_combo.Location = new Point(13, 32);
            KelasNama_combo.Name = "KelasNama_combo";
            KelasNama_combo.Size = new Size(213, 23);
            KelasNama_combo.TabIndex = 1;
            // 
            // JenisJadwal_combo
            // 
            JenisJadwal_combo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            JenisJadwal_combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            JenisJadwal_combo.FormattingEnabled = true;
            JenisJadwal_combo.Location = new Point(9, 30);
            JenisJadwal_combo.Name = "JenisJadwal_combo";
            JenisJadwal_combo.Size = new Size(218, 25);
            JenisJadwal_combo.TabIndex = 2;
            // 
            // Hari_combo
            // 
            Hari_combo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Hari_combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Hari_combo.FormattingEnabled = true;
            Hari_combo.Location = new Point(11, 78);
            Hari_combo.Name = "Hari_combo";
            Hari_combo.Size = new Size(216, 25);
            Hari_combo.TabIndex = 3;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 10);
            label5.Name = "label5";
            label5.Size = new Size(79, 17);
            label5.TabIndex = 5;
            label5.Text = "Jenis Jadwal";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 58);
            label6.Name = "label6";
            label6.Size = new Size(36, 17);
            label6.TabIndex = 6;
            label6.Text = "Hari ";
            // 
            // panel2
            // 
            panel2.BackColor = Color.SkyBlue;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(Hari_combo);
            panel2.Controls.Add(JenisJadwal_combo);
            panel2.Location = new Point(12, 148);
            panel2.Name = "panel2";
            panel2.Size = new Size(246, 123);
            panel2.TabIndex = 4;
            // 
            // Mapel_combo
            // 
            Mapel_combo.Anchor = AnchorStyles.Bottom;
            Mapel_combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Mapel_combo.FormattingEnabled = true;
            Mapel_combo.Location = new Point(15, 81);
            Mapel_combo.Name = "Mapel_combo";
            Mapel_combo.Size = new Size(218, 25);
            Mapel_combo.TabIndex = 13;
            // 
            // New_button
            // 
            New_button.Anchor = AnchorStyles.Bottom;
            New_button.Location = new Point(14, 219);
            New_button.Name = "New_button";
            New_button.Size = new Size(70, 23);
            New_button.TabIndex = 1;
            New_button.Text = "New";
            New_button.UseVisualStyleBackColor = true;
            // 
            // Guru_combo
            // 
            Guru_combo.Anchor = AnchorStyles.Bottom;
            Guru_combo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Guru_combo.FormattingEnabled = true;
            Guru_combo.Location = new Point(14, 131);
            Guru_combo.Name = "Guru_combo";
            Guru_combo.Size = new Size(218, 25);
            Guru_combo.TabIndex = 12;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(130, 13);
            label7.Name = "label7";
            label7.Size = new Size(48, 17);
            label7.TabIndex = 15;
            label7.Text = "Selesai";
            // 
            // Save_button
            // 
            Save_button.Anchor = AnchorStyles.Bottom;
            Save_button.Location = new Point(89, 219);
            Save_button.Name = "Save_button";
            Save_button.Size = new Size(70, 23);
            Save_button.TabIndex = 2;
            Save_button.Text = "Save";
            Save_button.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(17, 13);
            label8.Name = "label8";
            label8.Size = new Size(67, 17);
            label8.TabIndex = 14;
            label8.Text = "Jam Mulai";
            // 
            // Delete_button
            // 
            Delete_button.Anchor = AnchorStyles.Bottom;
            Delete_button.Location = new Point(165, 219);
            Delete_button.Name = "Delete_button";
            Delete_button.Size = new Size(70, 23);
            Delete_button.TabIndex = 3;
            Delete_button.Text = "Delete";
            Delete_button.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(15, 61);
            label9.Name = "label9";
            label9.Size = new Size(45, 17);
            label9.TabIndex = 16;
            label9.Text = "Mapel";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(15, 111);
            label10.Name = "label10";
            label10.Size = new Size(36, 17);
            label10.TabIndex = 17;
            label10.Text = "Guru";
            // 
            // panel4
            // 
            panel4.BackColor = Color.SkyBlue;
            panel4.Controls.Add(TimeslotIdLabel);
            panel4.Controls.Add(JamSelesai_mask);
            panel4.Controls.Add(JamMulai_mask);
            panel4.Controls.Add(Keterangan_text);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(Delete_button);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(Save_button);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(Guru_combo);
            panel4.Controls.Add(New_button);
            panel4.Controls.Add(Mapel_combo);
            panel4.Location = new Point(12, 277);
            panel4.Name = "panel4";
            panel4.Size = new Size(246, 255);
            panel4.TabIndex = 5;
            // 
            // TimeslotIdLabel
            // 
            TimeslotIdLabel.AutoSize = true;
            TimeslotIdLabel.Location = new Point(224, 159);
            TimeslotIdLabel.Name = "TimeslotIdLabel";
            TimeslotIdLabel.Size = new Size(0, 15);
            TimeslotIdLabel.TabIndex = 22;
            // 
            // JamSelesai_mask
            // 
            JamSelesai_mask.Anchor = AnchorStyles.Bottom;
            JamSelesai_mask.Location = new Point(130, 32);
            JamSelesai_mask.Name = "JamSelesai_mask";
            JamSelesai_mask.Size = new Size(105, 23);
            JamSelesai_mask.TabIndex = 21;
            // 
            // JamMulai_mask
            // 
            JamMulai_mask.Anchor = AnchorStyles.Bottom;
            JamMulai_mask.Location = new Point(16, 32);
            JamMulai_mask.Name = "JamMulai_mask";
            JamMulai_mask.Size = new Size(105, 23);
            JamMulai_mask.TabIndex = 20;
            // 
            // Keterangan_text
            // 
            Keterangan_text.Anchor = AnchorStyles.Bottom;
            Keterangan_text.Location = new Point(16, 179);
            Keterangan_text.Name = "Keterangan_text";
            Keterangan_text.Size = new Size(218, 23);
            Keterangan_text.TabIndex = 19;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(16, 161);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 18;
            label1.Text = "Keterangan";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(273, 48);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(686, 486);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(MapelUmum_grid);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(678, 458);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Jadwal Mapel Umum";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // MapelUmum_grid
            // 
            MapelUmum_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MapelUmum_grid.Location = new Point(6, 6);
            MapelUmum_grid.Name = "MapelUmum_grid";
            MapelUmum_grid.RowTemplate.Height = 25;
            MapelUmum_grid.Size = new Size(666, 443);
            MapelUmum_grid.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(MapelKhusus_grid);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(678, 458);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Jadwal Mapel Khusus";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // MapelKhusus_grid
            // 
            MapelKhusus_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MapelKhusus_grid.Location = new Point(6, 6);
            MapelKhusus_grid.Name = "MapelKhusus_grid";
            MapelKhusus_grid.ReadOnly = true;
            MapelKhusus_grid.RowTemplate.Height = 25;
            MapelKhusus_grid.Size = new Size(666, 443);
            MapelKhusus_grid.TabIndex = 0;
            // 
            // Form_JadwalPelajaran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(971, 546);
            Controls.Add(tabControl1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label2);
            Name = "Form_JadwalPelajaran";
            Text = "Form_JadwalPelajaran";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MapelUmum_grid).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MapelKhusus_grid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label3;
        private Panel panel3;
        private ComboBox JenisJadwal_combo;
        private ComboBox Hari_combo;
        private Label label5;
        private Label label6;
        private Panel panel2;
        private ComboBox Mapel_combo;
        private Button New_button;
        private ComboBox Guru_combo;
        private Label label7;
        private Button Save_button;
        private Label label8;
        private Button Delete_button;
        private Label label9;
        private Label label10;
        private Panel panel4;
        private ComboBox KelasNama_combo;
        private MaskedTextBox JamSelesai_mask;
        private MaskedTextBox JamMulai_mask;
        private TextBox Keterangan_text;
        private Label label1;
        private Label TimeslotIdLabel;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView MapelUmum_grid;
        private TabPage tabPage2;
        private DataGridView MapelKhusus_grid;
    }
}