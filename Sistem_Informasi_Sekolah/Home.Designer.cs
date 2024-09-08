namespace Sistem_Informasi_Sekolah.DataIndukSiswa.Dal
{
    partial class Home
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
            menuStrip1 = new MenuStrip();
            formToolStripMenuItem = new ToolStripMenuItem();
            dataIdukToolStripMenuItem = new ToolStripMenuItem();
            dataMapelToolStripMenuItem = new ToolStripMenuItem();
            dataJurusanToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            dataKelasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { formToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(764, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            formToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataIdukToolStripMenuItem, dataMapelToolStripMenuItem, dataJurusanToolStripMenuItem, dataKelasToolStripMenuItem });
            formToolStripMenuItem.Name = "formToolStripMenuItem";
            formToolStripMenuItem.Size = new Size(47, 20);
            formToolStripMenuItem.Text = "Form";
            // 
            // dataIdukToolStripMenuItem
            // 
            dataIdukToolStripMenuItem.Name = "dataIdukToolStripMenuItem";
            dataIdukToolStripMenuItem.Size = new Size(180, 22);
            dataIdukToolStripMenuItem.Text = "Data Iduk";
            // 
            // dataMapelToolStripMenuItem
            // 
            dataMapelToolStripMenuItem.Name = "dataMapelToolStripMenuItem";
            dataMapelToolStripMenuItem.Size = new Size(180, 22);
            dataMapelToolStripMenuItem.Text = "Data Mapel";
            // 
            // dataJurusanToolStripMenuItem
            // 
            dataJurusanToolStripMenuItem.Name = "dataJurusanToolStripMenuItem";
            dataJurusanToolStripMenuItem.Size = new Size(180, 22);
            dataJurusanToolStripMenuItem.Text = "Data Jurusan";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(764, 647);
            panel1.TabIndex = 1;
            // 
            // dataKelasToolStripMenuItem
            // 
            dataKelasToolStripMenuItem.Name = "dataKelasToolStripMenuItem";
            dataKelasToolStripMenuItem.Size = new Size(180, 22);
            dataKelasToolStripMenuItem.Text = "Data Kelas";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 671);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem formToolStripMenuItem;
        private ToolStripMenuItem dataIdukToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem dataMapelToolStripMenuItem;
        private ToolStripMenuItem dataJurusanToolStripMenuItem;
        private ToolStripMenuItem dataKelasToolStripMenuItem;
    }
}