namespace Sistem_Informasi_Sekolah.Absensi
{
    partial class Absensi_Form
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
            panel2 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Guru_combo = new ComboBox();
            Mapel_combo = new ComboBox();
            Kelas_combo = new ComboBox();
            Jam_mask = new MaskedTextBox();
            tanggal_date = new DateTimePicker();
            ListSiswa_button = new Button();
            New_button = new Button();
            label1 = new Label();
            TotalHadir_text = new TextBox();
            TotalSakit_text = new TextBox();
            TotalIzin_text = new TextBox();
            Save_button = new Button();
            label7 = new Label();
            TotalAlpha_text = new TextBox();
            dataGridView1 = new DataGridView();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.SkyBlue;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(Guru_combo);
            panel2.Controls.Add(Mapel_combo);
            panel2.Controls.Add(Kelas_combo);
            panel2.Controls.Add(Jam_mask);
            panel2.Controls.Add(tanggal_date);
            panel2.Controls.Add(ListSiswa_button);
            panel2.Controls.Add(New_button);
            panel2.Location = new Point(0, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 394);
            panel2.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 192);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 19;
            label6.Text = "Guru";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 137);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 18;
            label5.Text = "Mapel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 84);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 17;
            label4.Text = "Kelas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(135, 29);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 16;
            label3.Text = "Jam";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 29);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 15;
            label2.Text = "Tanggal";
            // 
            // Guru_combo
            // 
            Guru_combo.FormattingEnabled = true;
            Guru_combo.Location = new Point(18, 210);
            Guru_combo.Name = "Guru_combo";
            Guru_combo.Size = new Size(192, 23);
            Guru_combo.TabIndex = 14;
            // 
            // Mapel_combo
            // 
            Mapel_combo.FormattingEnabled = true;
            Mapel_combo.Location = new Point(20, 155);
            Mapel_combo.Name = "Mapel_combo";
            Mapel_combo.Size = new Size(192, 23);
            Mapel_combo.TabIndex = 13;
            // 
            // Kelas_combo
            // 
            Kelas_combo.FormattingEnabled = true;
            Kelas_combo.Location = new Point(18, 102);
            Kelas_combo.Name = "Kelas_combo";
            Kelas_combo.Size = new Size(192, 23);
            Kelas_combo.TabIndex = 12;
            // 
            // Jam_mask
            // 
            Jam_mask.Location = new Point(135, 47);
            Jam_mask.Name = "Jam_mask";
            Jam_mask.Size = new Size(75, 23);
            Jam_mask.TabIndex = 11;
            // 
            // tanggal_date
            // 
            tanggal_date.Format = DateTimePickerFormat.Short;
            tanggal_date.Location = new Point(18, 47);
            tanggal_date.Name = "tanggal_date";
            tanggal_date.Size = new Size(111, 23);
            tanggal_date.TabIndex = 10;
            // 
            // ListSiswa_button
            // 
            ListSiswa_button.Location = new Point(118, 265);
            ListSiswa_button.Name = "ListSiswa_button";
            ListSiswa_button.Size = new Size(75, 23);
            ListSiswa_button.TabIndex = 9;
            ListSiswa_button.Text = "List Siswa";
            ListSiswa_button.UseVisualStyleBackColor = true;
            // 
            // New_button
            // 
            New_button.Location = new Point(21, 265);
            New_button.Name = "New_button";
            New_button.Size = new Size(75, 23);
            New_button.TabIndex = 8;
            New_button.Text = "New";
            New_button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(392, 444);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "Total";
            // 
            // TotalHadir_text
            // 
            TotalHadir_text.Location = new Point(446, 444);
            TotalHadir_text.Name = "TotalHadir_text";
            TotalHadir_text.Size = new Size(30, 23);
            TotalHadir_text.TabIndex = 5;
            // 
            // TotalSakit_text
            // 
            TotalSakit_text.Location = new Point(482, 444);
            TotalSakit_text.Name = "TotalSakit_text";
            TotalSakit_text.Size = new Size(30, 23);
            TotalSakit_text.TabIndex = 6;
            // 
            // TotalIzin_text
            // 
            TotalIzin_text.Location = new Point(518, 444);
            TotalIzin_text.Name = "TotalIzin_text";
            TotalIzin_text.Size = new Size(30, 23);
            TotalIzin_text.TabIndex = 7;
            // 
            // Save_button
            // 
            Save_button.Location = new Point(728, 449);
            Save_button.Name = "Save_button";
            Save_button.Size = new Size(75, 23);
            Save_button.TabIndex = 10;
            Save_button.Text = "Save";
            Save_button.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.BackColor = Color.SkyBlue;
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Sylfaen", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(825, 41);
            label7.TabIndex = 11;
            label7.Text = "ABSENSI SISWA";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TotalAlpha_text
            // 
            TotalAlpha_text.Location = new Point(554, 444);
            TotalAlpha_text.Name = "TotalAlpha_text";
            TotalAlpha_text.Size = new Size(30, 23);
            TotalAlpha_text.TabIndex = 12;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(230, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(575, 394);
            dataGridView1.TabIndex = 13;
            // 
            // Absensi_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(825, 492);
            Controls.Add(dataGridView1);
            Controls.Add(TotalAlpha_text);
            Controls.Add(label7);
            Controls.Add(TotalIzin_text);
            Controls.Add(TotalSakit_text);
            Controls.Add(Save_button);
            Controls.Add(TotalHadir_text);
            Controls.Add(label1);
            Controls.Add(panel2);
            Name = "Absensi_Form";
            Text = "Absensi_Form";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox Guru_combo;
        private ComboBox Mapel_combo;
        private ComboBox Kelas_combo;
        private MaskedTextBox Jam_mask;
        private DateTimePicker tanggal_date;
        private Button ListSiswa_button;
        private Button New_button;
        private Label label1;
        private TextBox TotalHadir_text;
        private TextBox TotalSakit_text;
        private TextBox TotalIzin_text;
        private Button Save_button;
        private Label label7;
        private TextBox TotalAlpha_text;
        private DataGridView dataGridView1;
    }
}