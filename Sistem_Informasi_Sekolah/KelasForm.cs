using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Dal;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah
{
    public partial class KelasForm : Form
    {
        private readonly KelasDal kelasDal;
        private readonly JurusanDal jurusanDal;
        public KelasForm()
        {
            InitializeComponent();

            kelasDal = new KelasDal();
            jurusanDal = new JurusanDal();

            initCombo();
            controlGrid();
            controlEvent();
        }
        private void initCombo()
        {
            cb_KelasJurusan.DataSource = jurusanDal.Listjurusan();
            cb_KelasJurusan.DisplayMember = "NamaJurusan";
            cb_KelasJurusan.ValueMember = "JurusanId";
        }
        #region PENGATURAN GRID
        private void controlGrid()
        {
            GridKelas.DataSource = kelasDal.Listjurusan();
            adjustGridColumnSize();
            GridKelas.CellDoubleClick += GridKelas_CellDoubleClick;
        }

        private void GridKelas_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            var kelas = GridKelas.CurrentRow.Cells["KelasId"].Value.ToString();
            if (kelas is null)
                return;
            var Id = Convert.ToInt32(kelas);
            GetKelas(Id);
        }

        private void GetKelas(int Id)
        {
            tx_KelasId.Text = Id.ToString();
            var kelas = kelasDal.GetData(Id);
            if (kelas is null)
            {
                MessageBox.Show("Data not found");
                return;
            }
            tx_NamaKelas.Text = kelas.KelasNama;

            if (kelas.KelasTingkat == 10)
                rb_10.Checked = true;
            else if (kelas.KelasTingkat == 11)
                rb_11.Checked = true;
            else if (kelas.KelasTingkat == 12)
                rb_12.Checked = true;

            foreach (var item in cb_KelasJurusan.Items)
            {
                if (item.ToString() == kelas.JurusanId.ToString())
                {
                    cb_KelasJurusan.SelectedItem = item;
                    break;
                }
            }
        }

        private void adjustGridColumnSize()
        {
            // Mengatur lebar kolom
            GridKelas.Columns["KelasId"].Width = 70;
            GridKelas.Columns["KelasNama"].Width = 200;
            GridKelas.Columns["Kelastingkat"].Width = 150;
            GridKelas.Columns["JurusanId"].Visible = false;


            // Mengatur alignment kolom
            GridKelas.Columns["KelasId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridKelas.Columns["KelasNama"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridKelas.Columns["KelasTingkat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Mengatur nama kolom yang ditampilkan
            GridKelas.Columns["KelasId"].HeaderText = "Kode";
            GridKelas.Columns["KelasNama"].HeaderText = "Kelas - Nama Jurusan";
            GridKelas.Columns["KelasTingkat"].HeaderText = "Tingkat";
        }

        #endregion

        #region PENGATURAN EVENT
        private void controlEvent()
        {
            btn_newKelas.Click += Btn_newKelas_Click;
            btn_deleteKelas.Click += Btn_deleteKelas_Click;
            btn_SaveKelas.Click += Btn_SaveKelas_Click;
        }

        private void Btn_newKelas_Click(object? sender, EventArgs e)
        {
            RefreshData();
        }
        private void Btn_deleteKelas_Click(object? sender, EventArgs e)
        {
            deleteKelas();
            RefreshData();
        }

        private void Btn_SaveKelas_Click(object? sender, EventArgs e)
        {
            saveKelas();
            RefreshData();
        }

        private void saveKelas()
        {
            int tingkat = 0;
            if (rb_10.Checked) tingkat = 10;
            else if (rb_11.Checked) tingkat = 11;
            else if (rb_12.Checked) tingkat = 12;

            var isi = cb_KelasJurusan.Text;


            var KelasId = string.IsNullOrEmpty(tx_KelasId.Text) ? 0 : int.Parse(tx_KelasId.Text);
            var namaKelas = $"{tingkat} {isi}";
            var kelas = new KelasModel
            {
                KelasId = KelasId,
                KelasNama = namaKelas,
                KelasTingkat = tingkat,
                JurusanId = cb_KelasJurusan.SelectedIndex,
            };

            var datadiDb = kelasDal.GetData(KelasId);

            // Perbaiki logika pengecekan
            if (datadiDb == null) // Data tidak ada, maka lakukan insert
            {
                kelasDal.Insert(kelas);
            }
            else // Data ada, maka lakukan update
            {
                kelasDal.Update(kelas);
            }
        }

        private void deleteKelas()
        {
            int id = string.IsNullOrEmpty(tx_KelasId.Text) ? 0 : int.Parse(tx_KelasId.Text);

            // ccek apakah id valid
            if (id == 0 || string.IsNullOrEmpty(tx_NamaKelas.Text))
            {
                MessageBox.Show("silahkan pilih id atau nama jurusan yang ingin di hapus", "validasi error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // memastikan kelasDal tidak null sebelum pemanggilan
            if (kelasDal == null)
            {
                MessageBox.Show("kesalahan internal: objek kelasDal tidak diinisialisasi", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rowsAffected = kelasDal.Delete(id);

            if (rowsAffected > 0)
            {
                MessageBox.Show("catatan berhasil dihapus.", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("catatan tidak ditemukan.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData()
        {
            GridKelas.DataSource = kelasDal.Listjurusan();
            tx_KelasId.Text = string.Empty;
            tx_NamaKelas.Text = string.Empty;
            rb_10.Checked = false;
            rb_11.Checked = false;
            rb_12.Checked = false;
            cb_KelasJurusan.Text = string.Empty;
        }
        #endregion

        
    }
}
