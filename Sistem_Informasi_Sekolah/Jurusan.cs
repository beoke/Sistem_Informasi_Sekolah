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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah
{
    public partial class Jurusan : Form
    {
        private readonly JurusanDal jurusanDal;
        public Jurusan()
        {
            InitializeComponent();

            jurusanDal = new JurusanDal();

            controlGrid();
            controlEvent();

        }
        #region PENGATURAN GRID
        private void controlGrid()
        {
            GridJurusan.DataSource = jurusanDal.Listjurusan();
            adjustGridColumnSize();
            GridJurusan.CellDoubleClick += GridJurusan_CellDoubleClick;
        }

        private void GridJurusan_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            var siswajurusan = GridJurusan.CurrentRow.Cells["JurusanId"].Value.ToString();
            if (siswajurusan is null)
                return;
            var Id = Convert.ToInt32(siswajurusan);
            GetJurusan(Id);
        }

        private void GetJurusan(int Id)
        {
            tx_JurusanID.Text = Id.ToString();
            var jurusann = jurusanDal.GetData(Id);
            if(jurusann is null)
            {
                MessageBox.Show("Data not found");
                return;
            }
            tx_JurusanNama.Text = jurusann.NamaJurusan;
        }

        private void adjustGridColumnSize()
        {
            GridJurusan.Columns["JurusanId"].Width = 50;
            GridJurusan.Columns["NamaJurusan"].Width = 150; 
            GridJurusan.Columns["JurusanId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridJurusan.Columns["NamaJurusan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion

        #region PENGATURAN EVENT
        private void controlEvent()
        {
            btn_SaveJurusan.Click += Btn_SaveJurusan_Click;
            btn_DeleteJurusan.Click += Btn_DeleteJurusan_Click;
        }


        private void Btn_DeleteJurusan_Click(object? sender, EventArgs e)
        {
            DeleteJurusan();
            RefreshData();
        }

        private void Btn_SaveJurusan_Click(object? sender, EventArgs e)
        {
            SaveJurusan();
            RefreshData();
        }
        #endregion
        private int SaveJurusan()
        {
            var id = tx_JurusanID.Text == string.Empty ? 0 :
            int.Parse( tx_JurusanID.Text );
            string namaJurusan = tx_JurusanNama.Text;
            if (namaJurusan == string.Empty)
            {
                MessageBox.Show("Data Harus di isikan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            var jurusan = new JurusanModel
            {
                JurusanId = id,
                NamaJurusan = tx_JurusanNama.Text,
            };
            if(jurusan.JurusanId == 0)
            {
                id =jurusanDal.Insert(jurusan);
                MessageBox.Show("Berhasil Menambahkan", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                jurusanDal.Update(jurusan);
                MessageBox.Show("Data Berhasil Di Update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return id;
        }

        private int DeleteJurusan()
        {
            int id = tx_JurusanID.Text == string.Empty ? 0 : int.Parse(tx_JurusanID.Text);

            // Check if ID is valid
            if (id == 0 || string.IsNullOrEmpty(tx_JurusanNama.Text))
            {
                MessageBox.Show("Silahkan pilih Id atau Nama Jurusan yang ingin di hapus", "Validasi Eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }

            try
            {
                var rowsAffected = jurusanDal.Delete(id);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Catatan berhasil dihapus.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Catatan tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }
        
        private void RefreshData()
        {
            GridJurusan.DataSource = jurusanDal.Listjurusan();
            tx_JurusanID.Text = string.Empty;
            tx_JurusanNama.Text = string.Empty;
        }
    }
}
