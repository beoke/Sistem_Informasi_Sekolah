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

        #region GRID
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
                 .OrderBy(x => _listHari.IndexOf(x.Hari))
                 .ThenBy(x => x.JamMulai)
                 .Select(x => new PetaWakttuDto
                 {
                     Hari = x.Hari,
                     Timeslot = $"{x.JamMulai}-{x.JamSelesai}",
                     Mapel = x.NamaMapel,  /*$"{x.NamaMapel}{x.Keterangan}"*/
                     Guru = x.GuruName,
                     Keterangan = x.Keterangan,
                 }).ToList();
             MapelUmum_grid.DataSource = listUmum;
            setelanGridUmum();
        }

        private void setelanGridUmum()
        {
            MapelUmum_grid.CellPainting += MapelUmum_grid_CellPainting;
            MapelUmum_grid.Paint += MapelUmum_grid_Paint;
        }

        private void MapelUmum_grid_Paint(object? sender, PaintEventArgs e)
        {
            int rowIndex = 0;

            while (rowIndex < MapelUmum_grid.Rows.Count)
            {
                // Dapatkan nilai awal dari baris saat ini untuk kolom "Hari"
                var currentHariValue = MapelUmum_grid.Rows[rowIndex].Cells[0].Value?.ToString();

                // Hitung berapa banyak baris berturut-turut yang memiliki nilai yang sama
                int rowSpan = 1;

                for (int i = rowIndex + 1; i < MapelUmum_grid.Rows.Count && i < rowIndex + 6; i++)  // Cek hingga 6 baris ke depan
                {
                    var nextHariValue = MapelUmum_grid.Rows[i].Cells[0].Value?.ToString();
                    if (nextHariValue == currentHariValue)
                    {
                        rowSpan++;
                    }
                    else
                    {
                        break;  // Jika ada nilai yang berbeda, hentikan loop
                    }
                }

                if (rowSpan > 1)
                {
                    // Gambarkan sel yang digabungkan untuk "Hari"
                    Rectangle r1 = MapelUmum_grid.GetCellDisplayRectangle(0, rowIndex, true); // Kolom "Hari"
                    for (int i = 1; i < rowSpan; i++)
                    {
                        Rectangle r2 = MapelUmum_grid.GetCellDisplayRectangle(0, rowIndex + i, true);
                        r1.Height += r2.Height;
                    }

                    // Menggambar cell yang digabungkan
                    e.Graphics.FillRectangle(new SolidBrush(MapelUmum_grid.DefaultCellStyle.BackColor), r1);
                    e.Graphics.DrawRectangle(Pens.Black, r1);
                    e.Graphics.DrawString(currentHariValue, MapelUmum_grid.DefaultCellStyle.Font, Brushes.Black, r1);

                    // Lewati baris yang telah digabungkan
                    rowIndex += rowSpan;
                }
                else
                {
                    // Tidak ada penggabungan, lanjut ke baris berikutnya
                    rowIndex++;
                }
            }
        }

        private void MapelUmum_grid_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            // Cek apakah ini kolom "Hari" (misal, kolom ke-0)
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                // Kondisi untuk menentukan apakah ada baris setelah ini dengan "Hari" yang sama
                if (e.RowIndex < MapelUmum_grid.Rows.Count - 1 &&
                    MapelUmum_grid.Rows[e.RowIndex].Cells[0].Value.ToString() == MapelUmum_grid.Rows[e.RowIndex + 1].Cells[0].Value.ToString())
                {
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Bottom = MapelUmum_grid.AdvancedCellBorderStyle.Bottom;
                }
            }
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
                    Mapel = x.NamaMapel,  /* $"{x.NamaMapel}{x.Keterangan}"*/
                    Guru = x.GuruName,
                    Keterangan = x.Keterangan,
                }).ToList();
            MapelKhusus_grid.DataSource = listUmum;
            stelanGridkhusus();
        }

        private void stelanGridkhusus()
        {
            MapelKhusus_grid.CellPainting += MapelKhusus_grid_CellPainting;
            MapelKhusus_grid.Paint += MapelKhusus_grid_Paint;
        }

        private void MapelKhusus_grid_Paint(object? sender, PaintEventArgs e)
        {
            int rowIndex = 0;

            while (rowIndex < MapelKhusus_grid.Rows.Count)
            {
                var currentHariValue = MapelKhusus_grid.Rows[rowIndex].Cells[0].Value?.ToString();

                int rowSpan = 1;

                for (int i = rowIndex + 1; i < MapelKhusus_grid.Rows.Count && i < rowIndex + 6; i++)  
                {
                    var nextHariValue = MapelKhusus_grid.Rows[i].Cells[0].Value?.ToString();
                    if (nextHariValue == currentHariValue)
                    {
                        rowSpan++;
                    }
                    else
                    {
                        break;  
                    }
                }

                if (rowSpan > 1)
                {
                    Rectangle r1 = MapelKhusus_grid.GetCellDisplayRectangle(0, rowIndex, true); 
                    for (int i = 1; i < rowSpan; i++)
                    {
                        Rectangle r2 = MapelKhusus_grid.GetCellDisplayRectangle(0, rowIndex + i, true);
                        r1.Height += r2.Height;
                    }

                    e.Graphics.FillRectangle(new SolidBrush(MapelKhusus_grid.DefaultCellStyle.BackColor), r1);
                    e.Graphics.DrawRectangle(Pens.Black, r1);
                    e.Graphics.DrawString(currentHariValue, MapelKhusus_grid.DefaultCellStyle.Font, Brushes.Black, r1);

                    rowIndex += rowSpan;
                }
                else
                {
                    rowIndex++;
                }
            }
        }

        private void MapelKhusus_grid_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                if (e.RowIndex < MapelKhusus_grid.Rows.Count - 1 &&
                    MapelKhusus_grid.Rows[e.RowIndex].Cells[0].Value.ToString() == MapelKhusus_grid.Rows[e.RowIndex + 1].Cells[0].Value.ToString())
                {
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Bottom = MapelKhusus_grid.AdvancedCellBorderStyle.Bottom;
                }
            }
        }
        #endregion

        private void CleanForm()
        {
            JamMulai_mask.Text = "__:__";
            JamSelesai_mask.Text = "__:__";
            Mapel_combo.SelectedIndex = 0;
            Guru_combo.SelectedIndex = 0;
            TimeslotIdLabel.Text = string.Empty;
            Keterangan_text.Clear();
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
                JamSelesai =JamSelesai_mask.Text,
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
            KelasNama_combo.MaxDropDownItems = 5; // Membatasi 5 item
            KelasNama_combo.IntegralHeight = false; // Mematikan pengaturan tinggi otomatis
            KelasNama_combo.DropDownHeight = KelasNama_combo.ItemHeight * 5; // Atur tinggi dropdown berdasarkan 5 item

            var listKelas = _kelasDal.ListData() ?? new List<KelasModel>();
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
            Guru_combo.MaxDropDownItems= 4;

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
    public string Keterangan {  get; set; }
}

