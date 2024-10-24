using Sistem_Informasi_Sekolah.DataIndukSiswa.Dal;
using Sistem_Informasi_Sekolah.Guru.Dal;
using Sistem_Informasi_Sekolah.Kelas_Siswa.Dal;
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
            KelasSiswa_grid.CellDoubleClick += KelasSiswa_grid_CellDoubleClick; ;
        }

        private void KelasSiswa_grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Allsiswa_grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Kelas_Combo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
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

