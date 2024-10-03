using Sistem_Informasi_Sekolah.Guru.Dal;
using Sistem_Informasi_Sekolah.Guru.Model;
using Sistem_Informasi_Sekolah.Jadwal_Pelajaran.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah.Jadwal_Pelajaran
{
    public partial class Form_JadwalPelajaran : Form
    {
        private readonly PetaWaktuDal _petaWaktudal;
        private readonly KelasDal _kelasDal;
        private readonly MapelDal _mapelDal;
        private readonly GuruDal _guruDal;
        private readonly List<string> _listJenisJadwal = new () { "Mapel Umum", "Mapel Khusus" };
        private readonly List<string> _listHari = new () { "Senin", "Selasa", "Rabu", "Kamis", "Jum'at"};
        public Form_JadwalPelajaran()
        {
            InitializeComponent();

            InitMaskEdit();
            InitCombo();
        }
        private void InitCombo()
        {
            var listKelas = _kelasDal.ListData() ?? new List<KelasModel>();
            KelasNama_combo.Items.Clear();
            KelasNama_combo.DataSource = listKelas;
            KelasNama_combo.ValueMember = "KelasId";
            KelasNama_combo.DisplayMember = "KelasName";

            var listGuru = new List<GuruModel>
            {
                new GuruModel {GuruId = -1, GuruName = "--Pilih Guru--" }
            };
            Guru_combo.Items.Clear();
            Guru_combo.DataSource = listGuru;
            Guru_combo.ValueMember = "KelasId";
            Guru_combo.DisplayMember = "GuruName";

            var listMapel = new List<MapelModel>
            {
                new MapelModel { MapelId = -1, NamaMapel = "--Pilih Mapel--" }
            };
            listMapel.AddRange(_mapelDal.ListMapel()?.ToList() ?? new List<MapelModel>());

            Mapel_combo.Items.Clear();
            Mapel_combo.DataSource = listMapel;
            Mapel_combo.ValueMember = "MapelId";
            Mapel_combo.DisplayMember = "NamaMapel";


            JenisJadwal_combo.Items.Clear();
            JenisJadwal_combo.DataSource =_listJenisJadwal;
            JenisJadwal_combo.SelectedIndex = 0;

            Hari_combo.Items.Clear();
            Hari_combo.DataSource = _listHari;
            Hari_combo.SelectedIndex = 0;

        }
        private void InitMaskEdit()
        {
            JamMulai_mask.Text = "00:00";
            JamSelesai_mask.Text = "00:00";
            Mapel_combo.SelectedIndex = 0;
            Guru_combo.SelectedIndex = 0;
            TimeslotIdLabel.Text = string.Empty;
        }

    }
}
