using Sistem_Informasi_Sekolah.Guru.Dal;
using Sistem_Informasi_Sekolah.Guru.Model;
using Sistem_Informasi_Sekolah.Mapel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah.Guru
{
    public partial class formGuru : Form
    {
        private readonly GuruDal _guruDal;
        private readonly GuruMapelDal _guruMapelDal;
        private readonly MapelDal _mapelDal;

        private readonly BindingSource _listMapelBinding;
        private readonly BindingList<MapelDto> _listMapel;
        public formGuru()
        {
            InitializeComponent();


            _guruDal = new GuruDal();
            _guruMapelDal = new GuruMapelDal();
            _mapelDal = new MapelDal();
            _listMapel = new BindingList<MapelDto>();
            _listMapelBinding = new BindingSource()
            {
                DataSource = _listMapel
            };

            ControlEvent();
            InitCombo();
            InitGrid();
            RefreshListData();
        }
        private void RefreshListData()
        {
            var listData = _guruDal.ListData() ?? new List<GuruModel>();
            var dataSource = listData
                .Select(x => new GuruDto
                {
                    Id = x.GuruId,
                    Name = x.GuruName,
                    Pendidikan = $"{x.TingkatPendidikan} - {x.JurusanPendidikan}",
                })
                .ToList();
            DataGuru_Grid.DataSource = dataSource;
            DataGuru_Grid.Refresh();
        }

        private void InitGrid()
        {
            DataMapel_Grid.DataSource = _listMapelBinding;
            DataMapel_Grid.Columns["Id"].Width = 30;
            DataMapel_Grid.Columns["Mapel"].Width = 200;
        }

        private void InitCombo()
        {
            TINgkatPendidikan_Combo.Items.Clear();
            TINgkatPendidikan_Combo.Items.Add("-");
            TINgkatPendidikan_Combo.Items.Add("D3");
            TINgkatPendidikan_Combo.Items.Add("S1");
            TINgkatPendidikan_Combo.Items.Add("S2");
            TINgkatPendidikan_Combo.Items.Add("S3");
            TINgkatPendidikan_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            TINgkatPendidikan_Combo.SelectedIndex = 0;
        }

        private void ControlEvent()
        {
            New_button.Click += New_button_Click;
            Save_button.Click += Save_button_Click;
            delete_button.Click += Delete_button_Click;

            DataGuru_Grid.RowEnter += DataGuru_Grid_RowEnter;
            DataMapel_Grid.KeyDown += DataMapel_Grid_KeyDown1; ;
            DataMapel_Grid.CellValidated += DataMapel_Grid_CellValidated;
        }

        private void DataMapel_Grid_KeyDown1(object? sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                // Dapatkan baris saat ini
                DataGridViewRow currentRow = DataMapel_Grid.CurrentRow;

                // Inisialisasi form MapelList
                using var mapelListForm = new MapelList();
                if (mapelListForm.ShowDialog() == DialogResult.OK)
                {
                    var mapelId = mapelListForm.MapelId;
                    var mapelName = mapelListForm.MapelName;

                    DataMapel_Grid.BeginEdit(true);
                    currentRow.Cells["Id"].Value = mapelId;
                    currentRow.Cells["Mapel"].Value = mapelName;
                    DataMapel_Grid.EndEdit(DataGridViewDataErrorContexts.Commit);

                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // Simpan data dari baris saat ini
                if (DataMapel_Grid.CurrentRow != null)
                {
                    DataMapel_Grid.EndEdit(); // Simpan perubahan

                    // Tambahkan baris baru
                    int newRowIndex = DataMapel_Grid.Rows.Add();
                    DataMapel_Grid.CurrentCell = DataMapel_Grid.Rows[newRowIndex].Cells[0]; // Fokus ke sel pertama
                    DataMapel_Grid.BeginEdit(true); // Mulai edit
                }
            }
        }

        private void DataMapel_Grid_CellValidated(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = (DataGridView)sender;
            switch (grid.CurrentCell.OwningColumn.Name)
            {
                case "Id":
                    var mapel = _mapelDal.GetData(Convert.ToInt16(grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                    if (mapel == null)
                    {
                        _listMapel[e.RowIndex].Mapel = "";
                        return;
                    }
                    _listMapel[e.RowIndex].Id = mapel.MapelId;
                    _listMapel[e.RowIndex].Mapel = mapel.NamaMapel;
                    break;
            }
        }

        private void DataGuru_Grid_RowEnter(object? sender, DataGridViewCellEventArgs e)
        {
            var guruId = DataGuru_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            LoadData(Convert.ToInt16(guruId));
        }

        private void LoadData(int guruId)
        {
            var guru = _guruDal.GetData(guruId);
            if (guru == null)
            {
                ClearInput();
                return;
            }
            GuruId_text.Text = guru.GuruId.ToString();
            GuruNama_text.Text = guru.GuruName;
            GuruLahir_Date.Value = guru.TglLahir;
            TINgkatPendidikan_Combo.SelectedItem = guru.TingkatPendidikan;
            GuruJurusan_text.Text = guru.JurusanPendidikan;
            GuruLulus_text.Text = guru.TahunLulus;
            GuruInstansi_text.Text = guru.InstansiPendidikan;
            GuruKota_text.Text = guru.KotaPendidikan;

            var listMapel = _guruMapelDal.ListData(guruId)?.ToList()
                ?? new List<GuruMapelModel>();
            _listMapel.Clear();
            listMapel.ForEach(x => _listMapel.Add(new MapelDto
            {
                Id = x.MapelId,
                Mapel = x.MapelName
            }));
        }

        private void Delete_button_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save_button_Click(object? sender, EventArgs e)
        {
            SaveGuru();
            RefreshListData();
            ClearInput();
        }

        private void New_button_Click(object? sender, EventArgs e)
        {
            ClearInput();
        }
        private int SaveGuru()
        {
            var guruId = GuruId_text.Text == string.Empty ? 0
                : int.Parse(GuruId_text.Text);

            var guru = new GuruModel
            {
                GuruId = guruId,
                GuruName = GuruNama_text.Text,
                TglLahir = GuruLahir_Date.Value,
                TingkatPendidikan = TINgkatPendidikan_Combo.SelectedItem.ToString() ?? string.Empty,
                JurusanPendidikan = GuruJurusan_text.Text,
                TahunLulus = GuruLulus_text.Text,
                InstansiPendidikan = GuruInstansi_text.Text,
                KotaPendidikan = GuruKota_text.Text,

                ListMapel = _listMapel.Select(x => new GuruMapelModel
                {
                    GuruId = guruId,
                    MapelId = x.Id,
                }).ToList()
            };

            if (guru.GuruId == 0)
                guru.GuruId = _guruDal.Insert(guru);
            else
                _guruDal.Update(guru);

            _guruMapelDal.Delete(guru.GuruId);
            _guruMapelDal.Insert(guru.ListMapel);

            return guruId;
        }
        public void ClearInput()
        {
            GuruId_text.Clear();
            GuruNama_text.Clear();
            GuruLahir_Date.Value = new DateTime(3000, 1, 1);
            TINgkatPendidikan_Combo.SelectedIndex = 0;
            GuruJurusan_text.Clear();
            GuruLulus_text.Clear();
            GuruInstansi_text.Clear();
            GuruKota_text.Clear();

            _listMapel.Clear();
        }
    }
    public class GuruDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pendidikan { get; set; }
    }

    public class MapelDto
    {
        public int Id { get; set; }
        public string Mapel { get; set; }
    }
}


