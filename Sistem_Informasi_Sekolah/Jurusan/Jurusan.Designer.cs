namespace Sistem_Informasi_Sekolah
{
    partial class Jurusan
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
            tx_JurusanNama = new TextBox();
            tx_JurusanID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btn_DeleteJurusan = new Button();
            btn_SaveJurusan = new Button();
            label1 = new Label();
            GridJurusan = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridJurusan).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(tx_JurusanNama);
            panel1.Controls.Add(tx_JurusanID);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btn_DeleteJurusan);
            panel1.Controls.Add(btn_SaveJurusan);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(GridJurusan);
            panel1.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(9, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(716, 400);
            panel1.TabIndex = 0;
            // 
            // tx_JurusanNama
            // 
            tx_JurusanNama.Location = new Point(486, 150);
            tx_JurusanNama.Name = "tx_JurusanNama";
            tx_JurusanNama.Size = new Size(193, 29);
            tx_JurusanNama.TabIndex = 7;
            // 
            // tx_JurusanID
            // 
            tx_JurusanID.Location = new Point(486, 93);
            tx_JurusanID.Name = "tx_JurusanID";
            tx_JurusanID.Size = new Size(193, 29);
            tx_JurusanID.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(486, 125);
            label3.Name = "label3";
            label3.Size = new Size(49, 22);
            label3.TabIndex = 5;
            label3.Text = "Nama";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(486, 68);
            label2.Name = "label2";
            label2.Size = new Size(27, 22);
            label2.TabIndex = 4;
            label2.Text = "ID";
            // 
            // btn_DeleteJurusan
            // 
            btn_DeleteJurusan.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_DeleteJurusan.Location = new Point(517, 353);
            btn_DeleteJurusan.Name = "btn_DeleteJurusan";
            btn_DeleteJurusan.Size = new Size(81, 33);
            btn_DeleteJurusan.TabIndex = 3;
            btn_DeleteJurusan.Text = "Delete";
            btn_DeleteJurusan.UseVisualStyleBackColor = true;
            // 
            // btn_SaveJurusan
            // 
            btn_SaveJurusan.Location = new Point(604, 353);
            btn_SaveJurusan.Name = "btn_SaveJurusan";
            btn_SaveJurusan.Size = new Size(75, 33);
            btn_SaveJurusan.TabIndex = 2;
            btn_SaveJurusan.Text = "Save";
            btn_SaveJurusan.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BackColor = Color.SkyBlue;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(716, 32);
            label1.TabIndex = 1;
            label1.Text = "JURUSAN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GridJurusan
            // 
            GridJurusan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridJurusan.Location = new Point(3, 35);
            GridJurusan.Name = "GridJurusan";
            GridJurusan.RowTemplate.Height = 25;
            GridJurusan.Size = new Size(443, 362);
            GridJurusan.TabIndex = 0;
            // 
            // Jurusan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 421);
            Controls.Add(panel1);
            Name = "Jurusan";
            Text = "Jurusan";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridJurusan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox tx_JurusanNama;
        private TextBox tx_JurusanID;
        private Label label3;
        private Label label2;
        private Button btn_DeleteJurusan;
        private Button btn_SaveJurusan;
        private Label label1;
        private DataGridView GridJurusan;
    }
}