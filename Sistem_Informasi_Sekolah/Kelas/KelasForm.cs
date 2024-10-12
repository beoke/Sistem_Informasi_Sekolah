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
using System.Net;
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
            LoadData();
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
            btn_newKelas.Click += Btn_newKelas_Click1;
            btn_SaveKelas.Click += Btn_SaveKelas_Click1;
            btn_deleteKelas.Click += Btn_deleteKelas_Click1; ;

            rb_10.CheckedChanged += Rb_10_Click;
            rb_11.CheckedChanged += Rb_11_Click;
            rb_12.CheckedChanged += Rb_12_Click;

            cb_KelasJurusan.SelectedValueChanged += Cb_KelasJurusan_SelectedValueChanged; ;
            FlagText.TextChanged += FlagText_Validated;

            GridKelas.RowEnter += GridKelas_RowEnter;
        }

        private void GridKelas_RowEnter(object? sender, DataGridViewCellEventArgs e)
        {
            var kelasid = Convert.ToInt16(GridKelas.Rows[e.RowIndex].Cells[0].Value);
            var kelas = _kelasDal.GetData(kelasid);
            if (kelas is null)
            {
                ClearInput();
                return;
            }
            tx_KelasId.Text = kelasid.ToString();
            cb_KelasJurusan.SelectedValue = kelas?.JurusanId ?? 1;
            FlagText.Text = kelas?.Flag ?? string.Empty;

            if (kelas?.Tingkat == 10) rb_10.Checked = true;
            else if (kelas?.Tingkat == 11) rb_11.Checked = true;
            else if (kelas?.Tingkat == 12) rb_12.Checked = true;
        }

        private void LoadKelasData()
        {
            try
            {
                var kelasList = _kelasDal.ListData(); // Method ini mengambil data dari database
                GridKelas.DataSource = kelasList; // Bind data ke GridKelas
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data kelas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FlagText_Validated(object? sender, EventArgs e)
        {
            SetKelasName();
        }

        private void Cb_KelasJurusan_SelectedValueChanged(object? sender, EventArgs e)
        {
            SetKelasName();
        }

        private void Rb_12_Click(object? sender, EventArgs e)
        {
            SetKelasName();
        }

        private void Rb_11_Click(object? sender, EventArgs e)
        {
            SetKelasName();
        }

        private void Rb_10_Click(object? sender, EventArgs e)
        {
            SetKelasName();
        }

        private void Btn_deleteKelas_Click1(object? sender, EventArgs e)
        {
            delete();
        }
        private void delete()
        {
            var kelasClick = Convert.ToInt32(GridKelas.CurrentRow.Cells[0].Value);
            if (MessageBox.Show($"Apakah anda ingin menghapus data", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                _kelasDal.Delete(kelasClick);
                ClearInput();
                LoadData();
            }
            else
                return;
        }
        private void LoadData()
        {
            GridKelas.DataSource = _kelasDal.ListData();
            CustomGrid();
        }
        private void CustomGrid()
        {
            GridKelas.Columns["KelasId"].HeaderText = "Id Kelas";
            GridKelas.Columns["KelasName"].HeaderText = "Nama Kelas";
            GridKelas.Columns["Code"].HeaderText = "Kode Kelas";

            GridKelas.Columns["Tingkat"].Visible = false;
            GridKelas.Columns["Flag"].Visible = false;
            GridKelas.Columns["JurusanId"].Visible = false;
            GridKelas.Columns["JurusanName"].Visible = false;

            GridKelas.Columns["KelasId"].Width = 70;
            GridKelas.Columns["KelasName"].Width = 200;
            GridKelas.Columns["Code"].Width = 150;
        }
        private void Btn_SaveKelas_Click1(object? sender, EventArgs e)
        {

            var kelasId = SaveKelas();
            RefreshListData();
            ClearInput();
            LoadData();
        }
        private int SaveKelas()
        {
            var kelasId = tx_KelasId.Text == string.Empty ? 0
                : int.Parse(tx_KelasId.Text);
            var kelas = new KelasModel
            {
                KelasId = kelasId,
                KelasName = tx_KelasName.Text,
                JurusanId = Convert.ToInt16(cb_KelasJurusan.SelectedValue),
                Flag = FlagText.Text,
                Tingkat = rb_10.Checked ? 10
                    : rb_11.Checked ? 11
                    : 12
            };
            if (kelas.KelasId == 0)
                kelasId = _kelasDal.Insert(kelas);
            else
                _kelasDal.Update(kelas);
            return kelasId;
        }
        private void SetKelasName()
        {
            var tingkat = rb_10.Checked ? 10
                : rb_11.Checked ? 11 : rb_12.Checked ? 12 : 0;

            var jurusanId = Convert.ToInt16(cb_KelasJurusan.SelectedValue);
            var jurusan = _jurusanDal.GetData(jurusanId)
                ?? new JurusanModel { Code = "X" };
            var jurusanCode = jurusan.Code;
            var flag = FlagText.Text;
            tx_KelasName.Text = $"Kelas {tingkat} {jurusanCode}-{flag}";
        }

        private void Btn_newKelas_Click1(object? sender, EventArgs e)
        {
            ClearInput();
        }
        private void ClearInput()
        {
            tx_KelasId.Clear();
            tx_KelasName.Clear();
            FlagText.Clear();
            cb_KelasJurusan.SelectedIndex = 0;
            rb_10.Checked = false;
            rb_11.Checked = false;
            rb_12.Checked = false;
        }
        private void InitComboBox()
        {
            var listJurusan = _jurusanDal.Listjurusan();
            cb_KelasJurusan.DataSource = listJurusan;
            cb_KelasJurusan.ValueMember = "JurusanId";
            cb_KelasJurusan.DisplayMember = "JurusanName";
        }

        #endregion


        private void KelasForm_Load(object sender, EventArgs e)
        {
            LoadKelasData(); // masih ada bug
        }

    }
}
