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
            btn_new = new Button();
            panel2 = new Panel();
            CodeText = new MaskedTextBox();
            label4 = new Label();
            tx_JurusanNama = new TextBox();
            tx_JurusanID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            GridJurusan = new DataGridView();
            btn_SaveJurusan = new Button();
            btn_DeleteJurusan = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridJurusan).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btn_new);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(GridJurusan);
            panel1.Controls.Add(btn_SaveJurusan);
            panel1.Controls.Add(btn_DeleteJurusan);
            panel1.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(-3, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(717, 422);
            panel1.TabIndex = 0;
            // 
            // btn_new
            // 
            btn_new.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_new.Location = new Point(468, 322);
            btn_new.Name = "btn_new";
            btn_new.Size = new Size(77, 33);
            btn_new.TabIndex = 12;
            btn_new.Text = "New";
            btn_new.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SkyBlue;
            panel2.Controls.Add(CodeText);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(tx_JurusanNama);
            panel2.Controls.Add(tx_JurusanID);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(468, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(237, 272);
            panel2.TabIndex = 2;
            // 
            // CodeText
            // 
            CodeText.Location = new Point(17, 177);
            CodeText.Name = "CodeText";
            CodeText.Size = new Size(71, 29);
            CodeText.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 152);
            label4.Name = "label4";
            label4.Size = new Size(43, 22);
            label4.TabIndex = 16;
            label4.Text = "Code";
            // 
            // tx_JurusanNama
            // 
            tx_JurusanNama.Location = new Point(17, 120);
            tx_JurusanNama.Name = "tx_JurusanNama";
            tx_JurusanNama.Size = new Size(210, 29);
            tx_JurusanNama.TabIndex = 15;
            // 
            // tx_JurusanID
            // 
            tx_JurusanID.Location = new Point(17, 63);
            tx_JurusanID.Name = "tx_JurusanID";
            tx_JurusanID.Size = new Size(210, 29);
            tx_JurusanID.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 95);
            label3.Name = "label3";
            label3.Size = new Size(101, 22);
            label3.TabIndex = 13;
            label3.Text = "Jurusan Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 38);
            label2.Name = "label2";
            label2.Size = new Size(79, 22);
            label2.TabIndex = 12;
            label2.Text = "Jurusan ID";
            // 
            // label1
            // 
            label1.BackColor = Color.SkyBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Sylfaen", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(717, 32);
            label1.TabIndex = 1;
            label1.Text = "JURUSAN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GridJurusan
            // 
            GridJurusan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridJurusan.Location = new Point(15, 35);
            GridJurusan.Name = "GridJurusan";
            GridJurusan.RowTemplate.Height = 25;
            GridJurusan.Size = new Size(443, 375);
            GridJurusan.TabIndex = 0;
            // 
            // btn_SaveJurusan
            // 
            btn_SaveJurusan.Location = new Point(551, 322);
            btn_SaveJurusan.Name = "btn_SaveJurusan";
            btn_SaveJurusan.Size = new Size(78, 33);
            btn_SaveJurusan.TabIndex = 10;
            btn_SaveJurusan.Text = "Save";
            btn_SaveJurusan.UseVisualStyleBackColor = true;
            // 
            // btn_DeleteJurusan
            // 
            btn_DeleteJurusan.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_DeleteJurusan.Location = new Point(635, 322);
            btn_DeleteJurusan.Name = "btn_DeleteJurusan";
            btn_DeleteJurusan.Size = new Size(70, 33);
            btn_DeleteJurusan.TabIndex = 11;
            btn_DeleteJurusan.Text = "Delete";
            btn_DeleteJurusan.UseVisualStyleBackColor = true;
            // 
            // Jurusan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 421);
            Controls.Add(panel1);
            Name = "Jurusan";
            Text = "Jurusan";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridJurusan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView GridJurusan;
        private Button btn_new;
        private Panel panel2;
        private Label label4;
        private TextBox tx_JurusanNama;
        private TextBox tx_JurusanID;
        private Label label3;
        private Label label2;
        private Button btn_SaveJurusan;
        private Button btn_DeleteJurusan;
        private MaskedTextBox CodeText;
    }
}