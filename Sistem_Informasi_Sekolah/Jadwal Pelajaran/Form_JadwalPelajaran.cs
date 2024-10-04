using Sistem_Informasi_Sekolah.Guru.Dal;
using Sistem_Informasi_Sekolah.Guru.Model;
using Sistem_Informasi_Sekolah.Jadwal_Pelajaran.Dal;
using Sistem_Informasi_Sekolah.Jadwal_Pelajaran.Model;
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
            _petaWaktudal = new PetaWaktuDal();
            _kelasDal = new KelasDal();
            _mapelDal = new MapelDal();
            _guruDal = new GuruDal();

            InitMaskEdit();
            InitCombo();
            RegisterEvent();
            RefreshGrid();
        }
        private void RegisterEvent()
        {
            New_button.Click += New_button_Click;
            Save_button.Click += Save_button_Click;
            Delete_button.Click += Delete_button_Click;
            KelasNama_combo.SelectedIndexChanged += KelasNama_combo_SelectedIndexChanged;
        }

        private void KelasNama_combo_SelectedIndexChanged(object? sender, EventArgs e)
        {
           RefreshGrid();
        }

        private void Delete_button_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save_button_Click(object? sender, EventArgs e)
        {
            SavePetaWaktu();
            RefreshGrid();
            CleanForm();
            JamMulai_mask.Focus();
        }

        private void New_button_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void RefreshGrid()
        {
            RefreshGridUmum();
            RefreshGridKhusus();
        }
        private void RefreshGridUmum()
        {
            var kelas = Convert.ToInt16(KelasNama_combo.SelectedValue.ToString());
            var petaWaktu = _petaWaktudal.ListData(kelas)
                ?? new List<PetaWaktuModel>();
            var listUmum = petaWaktu
                .Where(x => x.JenisJadwal == "Mapel Umum")
                .OrderBy(x => x.Hari)
                .ThenBy(x => x.JamMulai)
                .Select(x => new PetaWakttuDto
                {
                    Hari = x.Hari,
                    Timeslot = $"{x.JamMulai}-{x.JamSelesai}",
                    Mapel = $"{x.NamaMapel}{x.Keterangan}",
                    Guru = x.GuruName,
                }).ToList();
            MapelKhusus_grid.DataSource = listUmum;
        }
        private void RefreshGridKhusus()
        {
            var kelas = Convert.ToInt16(KelasNama_combo.SelectedValue.ToString());
            var petaWaktu = _petaWaktudal.ListData(kelas)
                ?? new List<PetaWaktuModel>();
            var listUmum = petaWaktu
                .Where(x => x.JenisJadwal == "Mapel Khusus")
                .OrderBy(x => x.Hari)
                .ThenBy(x => x.JamMulai)
                .Select(x => new PetaWakttuDto
                {
                    Hari = x.Hari,
                    Timeslot = $"{x.JamMulai}-{x.JamSelesai}",
                    Mapel = $"{x.NamaMapel}{x.Keterangan}",
                    Guru = x.GuruName,
                }).ToList();
            MapelUmum_grid.DataSource = listUmum;
        }


        private void CleanForm()
        {
            JamMulai_mask.Text = "00:00";
            JamSelesai_mask.Text = "00:00";
            Mapel_combo.SelectedIndex = 0;
            Guru_combo.SelectedIndex = 0;
            TimeslotIdLabel.Text = string.Empty;
        }

        private int SavePetaWaktu()
        {
            var  timeslotId = TimeslotIdLabel.Text == string.Empty ? 0:
                Convert.ToInt32(TimeslotIdLabel.Text);

            var timeslot = new PetaWaktuModel
            {
                TimeslotMapelId = timeslotId,
                KelasId = Convert.ToInt32(KelasNama_combo.SelectedValue),
                Hari = Hari_combo.Text,
                JenisJadwal = JenisJadwal_combo.Text,
                JamMulai = JamMulai_mask.Text,
                JamSelesai = JamMulai_mask.Text,
                MapelId = Convert.ToInt32(Mapel_combo.SelectedValue),
                GuruId = Convert.ToInt32(Guru_combo.SelectedValue),
                Keterangan = Keterangan_text.Text,
            };

            if (timeslot.TimeslotMapelId == 0)
                timeslotId = _petaWaktudal.Insert(timeslot);
            else
                _petaWaktudal.Update(timeslot);

            TimeslotIdLabel.Text =timeslotId.ToString();
            return timeslotId;
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
            listGuru.AddRange(_guruDal.ListData()?.ToList() ?? new List<GuruModel>());
            Guru_combo.Items.Clear();
            Guru_combo.DataSource = listGuru;
            Guru_combo.ValueMember = "GuruId";
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
            JamMulai_mask.Mask = "00:00";
            JamMulai_mask.Font = new Font("Consolas", 10);
            JamSelesai_mask.Mask = "00:00";
            JamSelesai_mask.Font = new Font("Consolas", 10);
        }

    }
}
public class PetaWakttuDto
{
    public string Hari { get; set; }
    public string Timeslot { get; set; }
    public string Mapel { get; set; }
    public string Guru { get; set; }
}

