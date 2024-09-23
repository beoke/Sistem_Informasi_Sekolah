using Sistem_Informasi_Sekolah.Guru;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah.Mapel
{
    
    public partial class MapelForm : Form
    {
        private readonly MapelDal mapelDal;
        public MapelForm()
        {
            InitializeComponent();

            mapelDal = new MapelDal();

            controlGrid();
            controlEvent();
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

        #region PENGATURAN EVENT
        private void controlEvent()
        {
            btn_SaveMapel.Click += Btn_SaveMapel_Click;
            btn_deleteMapel4.Click += Btn_deleteMapel4_Click;
        }


        private void Btn_SaveMapel_Click(object? sender, EventArgs e)
        {
            SaveMapel();
            RefreshData();
        }
        private void Btn_deleteMapel4_Click(object? sender, EventArgs e)
        {
            DeleteMapel();
            RefreshData();
        }

        private int SaveMapel()
        {
            var id = tx_MapelID.Text == string.Empty ? 0 :
            int.Parse(tx_MapelID.Text);
            string namaMapel = tx_MapelName.Text;
            if (namaMapel == string.Empty)
            {
                MessageBox.Show("Data Harus di isikan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            var mapel = new MapelModel
            {
                MapelId = id,
                NamaMapel = tx_MapelName.Text,
            };
            if (mapel.MapelId == 0)
            {
                id = mapelDal.Insert(mapel);
                MessageBox.Show("Berhasil Menambahkan", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mapelDal.Update(mapel);
                MessageBox.Show("Data Berhasil Di Update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return id;
        }

        private int DeleteMapel()
        {
            int id = tx_MapelID.Text == string.Empty ? 0 : int.Parse(tx_MapelID.Text);

            // Check if ID is valid
            if (id == 0 || string.IsNullOrEmpty(tx_MapelName.Text))
            {
                MessageBox.Show("Silahkan pilih Id atau Nama Jurusan yang ingin di hapus", "Validasi Eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }

            try
            {
                var rowsAffected = mapelDal.Delete(id);

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
            GridMapel.DataSource = mapelDal.ListMapel();
            tx_MapelID.Text = string.Empty;
            tx_MapelName.Text = string.Empty;
        }

        #endregion
    }
}
