using Sistem_Informasi_Sekolah.Absensi;
using Sistem_Informasi_Sekolah.Guru;
using Sistem_Informasi_Sekolah.Jadwal_Pelajaran;
using Sistem_Informasi_Sekolah.Kelas_Siswa;
using Sistem_Informasi_Sekolah.Mapel;
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
            MapelTool.Click += MapelTool_Click;
            JurusanTool.Click += JurusanTool_Click;
            KelasTool.Click += KelasTool_Click;
            GuruTool.Click += GuruTool_Click;
            Jadwal_tool.Click += Jadwal_tool_Click;
            KelasSiswaTool.Click += KelasSiswaTool_Click;

        }


        private void Jadwal_tool_Click(object? sender, EventArgs e)
        {
            loadDataJadwal();
        }

        #region Run Load 

        private void KelasSiswaTool_Click(object? sender, EventArgs e)
        {
            LoadDataKelasSiswa();
        }

        private void GuruTool_Click(object? sender, EventArgs e)
        {
            LoadDataGuru();
        }

        private void KelasTool_Click(object? sender, EventArgs e)
        {
            LoadDataKelas();
        }

        private void JurusanTool_Click(object? sender, EventArgs e)
        {
            LoadDataJurusan();
        }

        private void MapelTool_Click(object? sender, EventArgs e)
        {
            LoadDataMapel();
        }

        private void dataIndukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataInduk();
            
        }

        #endregion
        private void LoadDataKelasSiswa()
        {

            Kelas_Siswaa kelsiswa = new Kelas_Siswaa();

            kelsiswa.TopLevel = false;
            kelsiswa.FormBorderStyle = FormBorderStyle.None;
            kelsiswa.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(kelsiswa);

            kelsiswa.Show();
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
        #region Load Data
        private void LoadDataMapel()
        {
            MapelForm mapel = new MapelForm();
            
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
        private void LoadDataKelas()
        {
            KelasForm kelas = new KelasForm();

            kelas.TopLevel = false;
            kelas.FormBorderStyle = FormBorderStyle.None;
            kelas.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(kelas);

            kelas.Show();
        }
        private void LoadDataGuru()
        {
            formGuru guru = new formGuru();

            guru.TopLevel = false;
            guru.FormBorderStyle = FormBorderStyle.None;
            guru.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(guru);

            guru.Show();
        }
        private void loadDataJadwal()
        {
            Form_JadwalPelajaran jadwal = new Form_JadwalPelajaran();
            jadwal.TopLevel = false;
            jadwal.FormBorderStyle = FormBorderStyle.None;
            jadwal.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(jadwal);

            jadwal.Show();
        }
        #endregion 
    }
}
