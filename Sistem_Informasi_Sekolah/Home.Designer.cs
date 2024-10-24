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
            KelasSiswaTool = new ToolStripMenuItem();
            pengajaranToolStripMenuItem = new ToolStripMenuItem();
            MapelTool = new ToolStripMenuItem();
            JurusanTool = new ToolStripMenuItem();
            KelasTool = new ToolStripMenuItem();
            GuruTool = new ToolStripMenuItem();
            Jadwal_tool = new ToolStripMenuItem();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { formToolStripMenuItem, pengajaranToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1035, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            formToolStripMenuItem.BackgroundImageLayout = ImageLayout.Stretch;
            formToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataIdukToolStripMenuItem, KelasSiswaTool });
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
            // KelasSiswaTool
            // 
            KelasSiswaTool.Name = "KelasSiswaTool";
            KelasSiswaTool.Size = new Size(196, 38);
            KelasSiswaTool.Text = "Kelas Siswa";
            // 
            // pengajaranToolStripMenuItem
            // 
            pengajaranToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MapelTool, JurusanTool, KelasTool, GuruTool, Jadwal_tool });
            pengajaranToolStripMenuItem.Image = (Image)resources.GetObject("pengajaranToolStripMenuItem.Image");
            pengajaranToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pengajaranToolStripMenuItem.Name = "pengajaranToolStripMenuItem";
            pengajaranToolStripMenuItem.Size = new Size(110, 36);
            pengajaranToolStripMenuItem.Text = "Pengajaran";
            // 
            // MapelTool
            // 
            MapelTool.Image = (Image)resources.GetObject("MapelTool.Image");
            MapelTool.ImageScaling = ToolStripItemImageScaling.None;
            MapelTool.Name = "MapelTool";
            MapelTool.Size = new Size(130, 38);
            MapelTool.Text = "Mapel";
            // 
            // JurusanTool
            // 
            JurusanTool.Image = (Image)resources.GetObject("JurusanTool.Image");
            JurusanTool.ImageScaling = ToolStripItemImageScaling.None;
            JurusanTool.Name = "JurusanTool";
            JurusanTool.Size = new Size(130, 38);
            JurusanTool.Text = "Jurusan";
            // 
            // KelasTool
            // 
            KelasTool.Image = (Image)resources.GetObject("KelasTool.Image");
            KelasTool.ImageScaling = ToolStripItemImageScaling.None;
            KelasTool.Name = "KelasTool";
            KelasTool.Size = new Size(130, 38);
            KelasTool.Text = "Kelas";
            // 
            // GuruTool
            // 
            GuruTool.Image = (Image)resources.GetObject("GuruTool.Image");
            GuruTool.ImageScaling = ToolStripItemImageScaling.None;
            GuruTool.Name = "GuruTool";
            GuruTool.Size = new Size(130, 38);
            GuruTool.Text = "Guru";
            // 
            // Jadwal_tool
            // 
            Jadwal_tool.Image = (Image)resources.GetObject("Jadwal_tool.Image");
            Jadwal_tool.ImageScaling = ToolStripItemImageScaling.None;
            Jadwal_tool.Name = "Jadwal_tool";
            Jadwal_tool.Size = new Size(130, 38);
            Jadwal_tool.Text = "Jadwal";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(1035, 631);
            panel1.TabIndex = 1;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 671);
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
        private ToolStripMenuItem Jadwal_tool;
        private ToolStripMenuItem KelasSiswaTool;
    }
}