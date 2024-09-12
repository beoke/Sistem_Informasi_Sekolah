using Dapper;
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
        private readonly KelasDal _kelasDal;
        private readonly JurusanDal _jurusanDal;
        int kelasTingkat = 0;
        public KelasForm()
        {

            InitializeComponent();

            _kelasDal = new KelasDal();
            _jurusanDal = new JurusanDal();

            InitComboBox();
            RegisterControlEvent();
            RefreshListData();
        }
        private void RefreshListData()
        {
            var listKelas = _kelasDal.ListData();
            var datasource = listKelas
                .Select(x => new
                {
                    Id = x.KelasId,
                    Name = x.KelasName,
                }).ToList();
            GridKelas.DataSource = datasource;
        }

        #region CUSTOM COMBO RADIO
        private void RegisterControlEvent()
        {
            NewButton.Click += NewButton_Click;
            SaveButton.Click += SaveButton_Click;
            DeleteButton.Click += DeletButton_Click;

            Tingkat10Radio.Click += TingkatRadio_Click;
            Tingkat11Radio.Click += TingkatRadio_Click;
            Tingkat12Radio.Click += TingkatRadio_Click;

            JurusanComboBox.SelectedValueChanged += JurusanComboBox_SelectedValueChanged;
            FlagText.Validated += FlagText_Validated;

            ListDataGrid.RowEnter += ListDataGrid_RowEnter;
        }

        private void RefreshComboRadio()
        {
            string jurusanName = string.Empty;
            if (cb_KelasJurusan.SelectedItem != null)
            {
                jurusanName = ((dynamic)cb_KelasJurusan.SelectedItem).NamaJurusan;
            }

            tx_KelasName.Text = GridKelas.CurrentRow.Cells[1].Value.ToString();
        }

        #endregion


        #region EVENT
        private void InitialEvent()
        {
            btn_SaveKelas.Click += Btn_SaveKelas_Click; 
            btn_newKelas.Click += Btn_newKelas_Click;
            btn_deleteKelas.Click += Btn_deleteKelas_Click;
            GridKelas.DoubleClick += GridKelas_DoubleClick;
            cb_KelasJurusan.SelectedIndexChanged += Cb_KelasJurusan_SelectedIndexChanged;

            List<RadioButton> radioTingkat = new List<RadioButton>
            {
                rb_10,
                rb_11,
                rb_12
            };
            foreach (var radio in radioTingkat)
                radio.CheckedChanged += Radio_CheckedChanged;
        }

        private void GridKelas_DoubleClick(object? sender, EventArgs e)
        {
             var kelasStr = GridKelas.CurrentRow.Cells["KelasId"].Value.ToString();
             GetListData(Convert.ToInt32(kelasStr));
        }

        private void Cb_KelasJurusan_SelectedIndexChanged(object? sender, EventArgs e)
        {
            RefreshComboRadio();
        }

        private void Btn_deleteKelas_Click(object? sender, EventArgs e)
        {
            var kelasName = GridKelas.CurrentRow.Cells[1].Value;
            var kelasClick = Convert.ToInt32(GridKelas.CurrentRow.Cells[0].Value);

            if (MessageBox.Show($"Apakah anda ingin menghapus data \" {kelasName} \" ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                kelasDal.Delete(kelasClick);
                LoadData();
                ClearData();
            }
            else
                return;
            
        }

        private void Btn_newKelas_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Tambahkan data baru ?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearData();
            }
        }

        private void Btn_SaveKelas_Click(object? sender, EventArgs e)
        {
            SaveData();
            LoadData();
            ClearData();
        }

        private void Radio_CheckedChanged(object? sender, EventArgs e)
        {
            if (rb_10.Checked) kelasTingkat = 10;
            if (rb_11.Checked) kelasTingkat = 11;
            if (rb_12.Checked) kelasTingkat = 12;
            RefreshComboRadio();
        }
        #endregion

        private void SaveData()
        {
            var kelasInsert = new KelasModel()
            {
                KelasNama = tx_KelasName.Text,
                KelasTingkat = kelasTingkat,
                JurusanId = Convert.ToInt16(cb_KelasJurusan.SelectedValue)
            };

            var kelasName = tx_KelasName.Text;

            if (tx_KelasId.Text == string.Empty)
            {
                if (MessageBox.Show($"Tambahkan data \" {kelasName} \" ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    kelasDal.Insert(kelasInsert);
            }

            if (tx_KelasId.Text != string.Empty)
            {
                if (MessageBox.Show("Update data ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var kelasUpdate = new KelasModel()
                    {
                        KelasId = Convert.ToInt16(tx_KelasId.Text),
                        KelasNama = tx_KelasName.Text,
                        KelasTingkat = kelasTingkat,
                        JurusanId = Convert.ToInt16(cb_KelasJurusan.SelectedValue)
                    };
                    kelasDal.Update(kelasUpdate);
                }
            }
        }

        private void LoadData()
        {
            GridKelas.DataSource = kelasDal.Listjurusan();
            CustomGrid();
        }

        private void CustomGrid()
        {
            GridKelas.Columns["KelasID"].HeaderText = "Id Kelas";
            GridKelas.Columns["KelasNama"].HeaderText = "Nama Kelas";
            GridKelas.Columns["KelasTingkat"].HeaderText = "Tingkat";

            GridKelas.Columns["JurusanId"].Visible = false;

            GridKelas.Columns["KelasID"].Width = 100;
            GridKelas.Columns["KelasNama"].Width = 200;
            GridKelas.Columns["KelasTingkat"].Width = 100;
        }

        private void ClearData()
        {
            tx_KelasId.Text = string.Empty;
            tx_KelasName.Text= string.Empty;
            cb_KelasJurusan.SelectedIndex = -1;

            rb_10.Checked = false;
            rb_11.Checked = false;
            rb_12.Checked = false;
        }

        private void GetListData(int KelasId)
        {
            var getKelas = kelasDal.GetData(KelasId);

            if (getKelas == null)
                MessageBox.Show("Data tidak ditemukan");

            tx_KelasId.Text = KelasId.ToString();

            if (getKelas.KelasTingkat == 10)
                rb_10.Checked = true;
            if (getKelas.KelasTingkat == 11)
                rb_11.Checked = true;
            if (getKelas.KelasTingkat == 12)
                rb_12.Checked = true;

            cb_KelasJurusan.SelectedValue = getKelas.JurusanId;
        }

    }
}
