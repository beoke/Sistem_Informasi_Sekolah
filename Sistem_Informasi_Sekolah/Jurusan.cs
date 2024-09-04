using Sistem_Informasi_Sekolah.DataIndukSiswa.Dal;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            var siswajurusan = GridJurusan.CurrentRow.Cells["Id"].Value.ToString();
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
            GridJurusan.Columns["Id"].Width = 50;
            GridJurusan.Columns["NamaJurusan"].Width = 150; 
            GridJurusan.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridJurusan.Columns["NamaJurusan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion
        private int SaveJurusan()
        {
            var id = tx_JurusanID.Text == string.Empty ? 0 :
            int.Parse( tx_JurusanID.Text );
            var jurusan = new JurusanModel
            {
                Id = id,
                NamaJurusan = tx_JurusanNama.Text,
            };
            if(jurusan.Id == 0)
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
    }
}
