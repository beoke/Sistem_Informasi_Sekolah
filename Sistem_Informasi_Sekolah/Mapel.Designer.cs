﻿namespace Sistem_Informasi_Sekolah
{
    partial class Mapel
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
            tx_MapelName = new TextBox();
            tx_MapelID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btn_deleteMapel4 = new Button();
            btn_SaveMapel = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(tx_MapelName);
            panel1.Controls.Add(tx_MapelID);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btn_deleteMapel4);
            panel1.Controls.Add(btn_SaveMapel);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(7, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(716, 400);
            panel1.TabIndex = 1;
            // 
            // tx_MapelName
            // 
            tx_MapelName.Location = new Point(486, 150);
            tx_MapelName.Name = "tx_MapelName";
            tx_MapelName.Size = new Size(193, 29);
            tx_MapelName.TabIndex = 7;
            // 
            // tx_MapelID
            // 
            tx_MapelID.Location = new Point(486, 93);
            tx_MapelID.Name = "tx_MapelID";
            tx_MapelID.Size = new Size(193, 29);
            tx_MapelID.TabIndex = 6;
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
            // btn_deleteMapel4
            // 
            btn_deleteMapel4.Font = new Font("Sylfaen", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_deleteMapel4.Location = new Point(517, 236);
            btn_deleteMapel4.Name = "btn_deleteMapel4";
            btn_deleteMapel4.Size = new Size(81, 33);
            btn_deleteMapel4.TabIndex = 3;
            btn_deleteMapel4.Text = "Delete";
            btn_deleteMapel4.UseVisualStyleBackColor = true;
            // 
            // btn_SaveMapel
            // 
            btn_SaveMapel.Location = new Point(604, 236);
            btn_SaveMapel.Name = "btn_SaveMapel";
            btn_SaveMapel.Size = new Size(75, 33);
            btn_SaveMapel.TabIndex = 2;
            btn_SaveMapel.Text = "Save";
            btn_SaveMapel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BackColor = Color.SkyBlue;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(716, 32);
            label1.TabIndex = 1;
            label1.Text = "MAPEL";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(443, 362);
            dataGridView1.TabIndex = 0;
            // 
            // Mapel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 421);
            Controls.Add(panel1);
            Name = "Mapel";
            Text = "Mapel";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox tx_MapelName;
        private TextBox tx_MapelID;
        private Label label3;
        private Label label2;
        private Button btn_deleteMapel4;
        private Button btn_SaveMapel;
        private Label label1;
        private DataGridView dataGridView1;
    }
}