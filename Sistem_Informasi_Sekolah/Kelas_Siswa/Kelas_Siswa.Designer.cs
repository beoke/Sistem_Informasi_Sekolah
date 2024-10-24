namespace Sistem_Informasi_Sekolah.Kelas_Siswa
{
    partial class Kelas_Siswaa
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
            TahunAjaran_text = new TextBox();
            WaliKelas_combo = new ComboBox();
            Kelas_Combo = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            Allsiswa_grid = new DataGridView();
            Save_button = new Button();
            KelasSiswa_grid = new DataGridView();
            search_text = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Allsiswa_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KelasSiswa_grid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SkyBlue;
            panel1.Controls.Add(TahunAjaran_text);
            panel1.Controls.Add(WaliKelas_combo);
            panel1.Controls.Add(Kelas_Combo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(9, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 352);
            panel1.TabIndex = 0;
            // 
            // TahunAjaran_text
            // 
            TahunAjaran_text.Location = new Point(19, 80);
            TahunAjaran_text.Name = "TahunAjaran_text";
            TahunAjaran_text.Size = new Size(180, 23);
            TahunAjaran_text.TabIndex = 5;
            // 
            // WaliKelas_combo
            // 
            WaliKelas_combo.FormattingEnabled = true;
            WaliKelas_combo.Location = new Point(19, 122);
            WaliKelas_combo.Name = "WaliKelas_combo";
            WaliKelas_combo.Size = new Size(180, 23);
            WaliKelas_combo.TabIndex = 4;
            // 
            // Kelas_Combo
            // 
            Kelas_Combo.FormattingEnabled = true;
            Kelas_Combo.Location = new Point(19, 29);
            Kelas_Combo.Name = "Kelas_Combo";
            Kelas_Combo.Size = new Size(180, 23);
            Kelas_Combo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 106);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Wali Kelas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 62);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 1;
            label2.Text = "Tahun Ajaran";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 11);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Kelas";
            // 
            // label4
            // 
            label4.BackColor = Color.SkyBlue;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Sylfaen", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(800, 37);
            label4.TabIndex = 2;
            label4.Text = "KELAS SISWA";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Allsiswa_grid
            // 
            Allsiswa_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Allsiswa_grid.Location = new Point(236, 92);
            Allsiswa_grid.Name = "Allsiswa_grid";
            Allsiswa_grid.RowTemplate.Height = 25;
            Allsiswa_grid.Size = new Size(267, 315);
            Allsiswa_grid.TabIndex = 3;
            // 
            // Save_button
            // 
            Save_button.Location = new Point(703, 415);
            Save_button.Name = "Save_button";
            Save_button.Size = new Size(75, 23);
            Save_button.TabIndex = 4;
            Save_button.Text = "Save";
            Save_button.UseVisualStyleBackColor = true;
            // 
            // KelasSiswa_grid
            // 
            KelasSiswa_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            KelasSiswa_grid.Location = new Point(509, 92);
            KelasSiswa_grid.Name = "KelasSiswa_grid";
            KelasSiswa_grid.RowTemplate.Height = 25;
            KelasSiswa_grid.Size = new Size(269, 315);
            KelasSiswa_grid.TabIndex = 5;
            // 
            // search_text
            // 
            search_text.Location = new Point(236, 58);
            search_text.Name = "search_text";
            search_text.Size = new Size(261, 23);
            search_text.TabIndex = 6;
            // 
            // Kelas_Siswaa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(search_text);
            Controls.Add(KelasSiswa_grid);
            Controls.Add(Save_button);
            Controls.Add(Allsiswa_grid);
            Controls.Add(label4);
            Controls.Add(panel1);
            Name = "Kelas_Siswaa";
            Text = "Kelas_Siswa";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Allsiswa_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)KelasSiswa_grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox TahunAjaran_text;
        private ComboBox WaliKelas_combo;
        private ComboBox Kelas_Combo;
        private Label label4;
        private DataGridView Allsiswa_grid;
        private Button Save_button;
        private DataGridView KelasSiswa_grid;
        private TextBox search_text;
    }
}