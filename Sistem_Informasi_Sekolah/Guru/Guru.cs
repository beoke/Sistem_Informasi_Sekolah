using Sistem_Informasi_Sekolah.Guru.Dal;
using Sistem_Informasi_Sekolah.Guru.Model;
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
           
        }
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
