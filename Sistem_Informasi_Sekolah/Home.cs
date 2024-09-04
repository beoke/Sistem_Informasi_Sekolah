using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah.DataIndukSiswa.Dal
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            dataIdukToolStripMenuItem.Click += new EventHandler(dataIndukToolStripMenuItem_Click);
            dataMapelToolStripMenuItem.Click += new EventHandler(dataMapelToolStripMenuItem_Click);
            dataJurusanToolStripMenuItem.Click += new EventHandler(dataJurusanToolStripMenuItem_Click);
        }
        private void dataIndukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataInduk();
            
        }
        private void dataMapelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataMapel();
        }    
        private void dataJurusanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataJurusan();
        }
        
        private void LoadDataInduk()
        {
            // membuat instance dari Form1
            Form1 form1 = new Form1();

            // set Form1 untuk tidak memiliki border dan menjadi bagian dari kontrol
            form1.TopLevel = false;
            form1.FormBorderStyle = FormBorderStyle.None;
            form1.Dock = DockStyle.Fill;

            panel1.Controls.Clear(); // membersihkan kontrol sebelumnya
            panel1.Controls.Add(form1);

            // tampilkan Form1
            form1.Show();
        }
        private void LoadDataMapel()
        {
            Mapel mapel = new Mapel();
            
            mapel.TopLevel = false;
            mapel.FormBorderStyle = FormBorderStyle.None;
            mapel.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(mapel);

            mapel.Show();
        }
        private void LoadDataJurusan()
        {
            Jurusan jurusan = new Jurusan();

            jurusan.TopLevel = false;
            jurusan.FormBorderStyle = FormBorderStyle.None;
            jurusan.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(jurusan);

            jurusan.Show();
        }
    }
}
