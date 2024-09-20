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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            menuStrip1 = new MenuStrip();
            formToolStripMenuItem = new ToolStripMenuItem();
            dataIdukToolStripMenuItem = new ToolStripMenuItem();
            pengajaranToolStripMenuItem = new ToolStripMenuItem();
            MapelTool = new ToolStripMenuItem();
            JurusanTool = new ToolStripMenuItem();
            KelasTool = new ToolStripMenuItem();
            GuruTool = new ToolStripMenuItem();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { formToolStripMenuItem, pengajaranToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(764, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            formToolStripMenuItem.BackgroundImageLayout = ImageLayout.Stretch;
            formToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataIdukToolStripMenuItem });
            formToolStripMenuItem.Image = (Image)resources.GetObject("formToolStripMenuItem.Image");
            formToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            formToolStripMenuItem.Name = "formToolStripMenuItem";
            formToolStripMenuItem.Size = new Size(105, 36);
            formToolStripMenuItem.Text = "Kesiswaan";
            formToolStripMenuItem.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dataIdukToolStripMenuItem
            // 
            dataIdukToolStripMenuItem.Image = (Image)resources.GetObject("dataIdukToolStripMenuItem.Image");
            dataIdukToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            dataIdukToolStripMenuItem.Name = "dataIdukToolStripMenuItem";
            dataIdukToolStripMenuItem.Size = new Size(196, 38);
            dataIdukToolStripMenuItem.Text = "Data Iduk";
            // 
            // pengajaranToolStripMenuItem
            // 
            pengajaranToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MapelTool, JurusanTool, KelasTool, GuruTool });
            pengajaranToolStripMenuItem.Name = "pengajaranToolStripMenuItem";
            pengajaranToolStripMenuItem.Size = new Size(78, 36);
            pengajaranToolStripMenuItem.Text = "Pengajaran";
            // 
            // MapelTool
            // 
            MapelTool.Name = "MapelTool";
            MapelTool.Size = new Size(180, 22);
            MapelTool.Text = "Data Mapel";
            // 
            // JurusanTool
            // 
            JurusanTool.Name = "JurusanTool";
            JurusanTool.Size = new Size(180, 22);
            JurusanTool.Text = "Data Jurusan";
            // 
            // KelasTool
            // 
            KelasTool.Name = "KelasTool";
            KelasTool.Size = new Size(180, 22);
            KelasTool.Text = "Data Kelas";
            // 
            // GuruTool
            // 
            GuruTool.Name = "GuruTool";
            GuruTool.Size = new Size(180, 22);
            GuruTool.Text = "Data Guru";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(764, 631);
            panel1.TabIndex = 1;
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
        private ToolStripMenuItem pengajaranToolStripMenuItem;
        private ToolStripMenuItem MapelTool;
        private ToolStripMenuItem JurusanTool;
        private ToolStripMenuItem KelasTool;
        private ToolStripMenuItem GuruTool;
    }
}