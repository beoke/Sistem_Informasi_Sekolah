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
    public partial class MapelList : Form
    {
        private readonly MapelDal _mapelDal;
        public int MapelId { get; private set; } = 0;
        public string MapelName { get; private set; } = "";


        public MapelList()
        {
            InitializeComponent();
            KeyPreview = true;

            _mapelDal = new MapelDal();
            var listMapel = _mapelDal.ListMapel()?.ToList() ?? new List<MapelModel>();

            ListDataGrid.DataSource = listMapel
                .Select(x => new
                {
                    ID = x.MapelId,
                    Mapel = x.NamaMapel
                }).ToList();

            ListDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
            ListDataGrid.KeyDown += ListDataGrid_KeyDown;
            this.KeyDown += ThisForm_KeyDown;
        }

        private void ThisForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void ListDataGrid_KeyDown(object? sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter && ListDataGrid.CurrentRow != null)
              {
                  // Prevents 'Enter' from moving to the next row
                  e.Handled = true;

                  // Access the selected row
                  DataGridViewRow selectedRow = ListDataGrid.CurrentRow;
                  // Do something with the selected row
                  MapelId = Convert.ToInt32(selectedRow.Cells[0].Value);
                  MapelName = selectedRow?.Cells[1].Value.ToString() ?? string.Empty;
                  this.DialogResult = DialogResult.OK;
                  this.Close();
              }
        }

        private void ListDataGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = ListDataGrid.Rows[e.RowIndex];
            MapelId = Convert.ToInt32(selectedRow.Cells[0].Value);
            MapelName = selectedRow?.Cells[1].Value.ToString() ?? string.Empty;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }


    }
}
