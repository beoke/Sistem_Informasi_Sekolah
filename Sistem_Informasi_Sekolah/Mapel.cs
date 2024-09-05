using Sistem_Informasi_Sekolah.DataIndukSiswa.Dal;
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
    public partial class Mapel : Form
    {
        private readonly MapelDal mapelDal;
        public Mapel()
        {
            InitializeComponent();

            mapelDal = new MapelDal();

            controlGrid();
        }
        #region PENGATURAN GRID
        private void controlGrid()
        {
            GridMapel.DataSource = mapelDal.ListMapel();
            adjustGridColumnSize();
            GridMapel.CellDoubleClick += GridMapel_CellDoubleClick; ;
        }

        private void GridMapel_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            var mapel = GridMapel.CurrentRow.Cells["MapelId"].Value.ToString();
            if (mapel is null)
                return;
            var Id = Convert.ToInt32(mapel);
            GetMapel(Id);
        }

        private void GetMapel(int Id)
        {
            tx_MapelID.Text = Id.ToString();
            var mapel = mapelDal.GetData(Id);
            if (mapel is null)
            {
                MessageBox.Show("Data not found");
                return;
            }
            tx_MapelName.Text = mapel.NamaMapel;
        }

        private void adjustGridColumnSize()
        {
            GridMapel.Columns["MapelId"].Width = 50;
            GridMapel.Columns["NamaMapel"].Width = 150;
            GridMapel.Columns["MapelId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridMapel.Columns["NamaMapel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion
    }
}
