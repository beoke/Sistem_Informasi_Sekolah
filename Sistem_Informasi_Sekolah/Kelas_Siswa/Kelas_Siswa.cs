using Sistem_Informasi_Sekolah.DataIndukSiswa.Dal;
using Sistem_Informasi_Sekolah.Guru.Dal;
using Sistem_Informasi_Sekolah.Kelas_Siswa.Dal;
using Sistem_Informasi_Sekolah.Kelas_Siswa.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah.Kelas_Siswa
{
    public partial class Kelas_Siswaa : Form
    {
        private readonly KelasSiswaDal kelasSiswaDal_;
        private readonly KelasSiswaDetailDal kelasSiswaDetailDal_;
        private readonly SiswaDal siswaDal_;
        private readonly GuruDal guruDal_;
        private readonly KelasDal kelasDal_;
        private BindingList<SiswaDto> allSiswaList_ = new();
        private BindingList<SiswaDto> kelasSiswaList_ = new();
        private BindingSource allSiswaBinding_ = new();
        private BindingSource kelasSiswaBinding_ = new();
        public Kelas_Siswaa()
        {
            InitializeComponent();


             kelasSiswaDal_ = new KelasSiswaDal();
             kelasSiswaDetailDal_ = new KelasSiswaDetailDal();
             siswaDal_ = new SiswaDal();
             guruDal_ = new GuruDal();
             kelasDal_ = new KelasDal();
             allSiswaBinding_.DataSource = allSiswaList_;
             kelasSiswaBinding_.DataSource = kelasSiswaList_;

            Allsiswa_grid.DataSource = allSiswaBinding_;
            KelasSiswa_grid.DataSource = kelasSiswaBinding_;


            PengaturanCombo();
            KontrolEvent();
        }
        private void KontrolEvent()
        {
            Kelas_Combo.SelectedIndexChanged += Kelas_Combo_SelectedIndexChanged; ;

            Allsiswa_grid.CellDoubleClick += Allsiswa_grid_CellDoubleClick;
            KelasSiswa_grid.CellDoubleClick += KelasSiswa_grid_CellDoubleClick;
            Save_button.Click += Save_button_Click;
            search_text.TextChanged += Search_text_TextChanged;
        }

        private void Search_text_TextChanged(object? sender, EventArgs e)
        {
            LoadKelas();
        }

        private void Save_button_Click(object? sender, EventArgs e)
        {
            var kelasId = (int)Kelas_Combo.SelectedValue;
            var kelasSiswa = kelasSiswaDal_.GetData(kelasId);
            if (kelasSiswa is null)
                CreateNewKelasSiswa();

            if (kelasSiswaList_.Count == 0)
            {
                MessageBox.Show("Tidak ada siswa yang ditambahkan ke kelas. Silakan tambahkan siswa sebelum menyimpan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TahunAjaran_text.Text))
            {
                MessageBox.Show("Tahun ajaran harus diisi sebelum menyimpan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
   
            foreach (var siswa in kelasSiswaList_)
            {
                var newDetail = new KelasSiswaDetailModel
                {
                    KelasId = kelasId,
                    SiswaId = siswa.SiswaId
                };

                kelasSiswaDetailDal_.Insert(newDetail);
            }

            KelasSiswa_grid.Refresh();
            ListAvailableSiswa();
            MessageBox.Show("Data berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void KelasSiswa_grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;
            var kelasId = (int)Kelas_Combo.SelectedValue;
            var siswaId = (int)grid.CurrentRow.Cells["SiswaId"].Value;

            kelasSiswaDetailDal_.Delete(kelasId, siswaId);
            var removedItem = kelasSiswaList_.FirstOrDefault(x => x.SiswaId == siswaId);
            kelasSiswaList_.Remove(removedItem);
            KelasSiswa_grid.Refresh();
            ListAvailableSiswa();
        }

        private void Allsiswa_grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null || e.RowIndex < 0) return;


            var siswaId = (int)grid.CurrentRow.Cells["SiswaId"].Value;
            var siswaName = grid.CurrentRow.Cells["SiswaName"].Value.ToString();

            var siswaDto = new SiswaDto(siswaId, siswaName ?? string.Empty);

            kelasSiswaList_.Add(siswaDto);

            var removedItem = allSiswaList_.FirstOrDefault(x => x.SiswaId == siswaId);
            allSiswaList_.Remove(removedItem);
            Allsiswa_grid.Refresh();
        }

        private void CreateNewKelasSiswa()
        {
            var newKelasSiswa = new KelasSiswaModel
            {
                KelasId = (int)Kelas_Combo.SelectedValue,
                TahunAjaran = TahunAjaran_text.Text,
                WaliKelasId = (int)WaliKelas_combo.SelectedValue
            };
            kelasSiswaDal_.Insert(newKelasSiswa);
        }


        private void Kelas_Combo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadKelas();
        }
        private void LoadKelas()
        {
            if (Kelas_Combo.SelectedIndex == -1)
            {
                ClearForm();
                return;
            }
            

            var selectedKelasId = (int)Kelas_Combo.SelectedValue;
            var kelasSiswa = kelasSiswaDal_.GetData(selectedKelasId);
            if (kelasSiswa == null)
            {
                ClearForm();
                return;
            }
            TahunAjaran_text.Text = kelasSiswa.TahunAjaran;
            WaliKelas_combo.SelectedValue = kelasSiswa.KelasId;

            var kelasSiswaList = kelasSiswaDetailDal_.ListData(kelasSiswa.KelasId)?.ToList()
                ?? new();
            kelasSiswaList_.Clear();
            var listSiswaTemp = kelasSiswaList
                .Select(x => new SiswaDto(x.SiswaId, x.SiswaName))?.ToList() ?? new();
            foreach (var item in listSiswaTemp)
            {
                kelasSiswaList_.Add(item);
            }
            ListAvailableSiswa();
        }


        private void ClearForm()
        {
            TahunAjaran_text.Clear();
            WaliKelas_combo.SelectedIndex = -1;
            allSiswaList_.Clear();
            kelasSiswaList_.Clear();

            ListAvailableSiswa();
            Allsiswa_grid.Refresh();
        }

        private void ListAvailableSiswa()
        {
            string filter = search_text.Text;

            var allSiswa = siswaDal_.ListData("WHERE NamaLengkap LIKE '%'+@NamaLengkap+'%'", new {NamaLengkap=filter})?.ToList()
                ?? new();
            var siswaInKelas = kelasSiswaDetailDal_.ListData()?.ToList()
                ?? new();
            var siswaIdInKelas = siswaInKelas.Select(x => x.SiswaId)?.ToList()
                ?? new();

            allSiswa.RemoveAll(x => siswaIdInKelas.Contains(x.SiswaId));

            allSiswaList_.Clear();
            var listSiswaTemp = allSiswa.Select(x => new SiswaDto(x.SiswaId, x.NamaLengkap))?.ToList() ?? new();
            foreach (var item in listSiswaTemp)
            {
                allSiswaList_.Add(item);
            }

            Allsiswa_grid.Refresh();
        }


        private void PengaturanCombo()
        {
            var listKelas = kelasDal_.ListData();
            Kelas_Combo.DataSource = listKelas;
            Kelas_Combo.SelectedIndex = 0;
            Kelas_Combo.DisplayMember = "KelasName";
            Kelas_Combo.ValueMember = "KelasId";

            var listGuru = guruDal_.ListData();
            WaliKelas_combo.DataSource = listGuru;
            WaliKelas_combo.SelectedIndex = 0;
            WaliKelas_combo.DisplayMember = "GuruName";
            WaliKelas_combo.ValueMember = "GuruId";
        }
    }
}
public class SiswaDto
{
    public SiswaDto()
    {
    }
    public SiswaDto(int id, string name) => (SiswaId, SiswaName) = (id, name);

    public int SiswaId { get; set; }
    public string SiswaName { get; set; }
}

