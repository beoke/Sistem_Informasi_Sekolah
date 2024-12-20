using Dapper;
using Microsoft.VisualBasic.Devices;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Dal;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Security.Permissions;
using System.Security.Policy;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah
{
    public partial class Form1 : Form
    {
        private readonly SiswaDal siswaDal;
        private readonly SiswaRiwayatDal siswaRiwayatDal;
        private readonly SiswaWaliDal siswaWaliDal;
        private readonly SiswaLulusDal siswaLulusDal;
        private readonly SiswaBeasiswaDal siswaBeasiswaDal;

        private readonly BindingSource beasiswaBinding;
        private readonly BindingList<BeasiswaDto> beasiswaList;

        private string FotoLokasi = string.Empty;
        public Form1()
        {
            InitializeComponent();


            siswaDal = new SiswaDal();
            siswaBeasiswaDal = new SiswaBeasiswaDal();
            siswaRiwayatDal = new SiswaRiwayatDal();
            siswaWaliDal = new SiswaWaliDal();
            siswaLulusDal = new SiswaLulusDal();

            beasiswaList = new BindingList<BeasiswaDto>();
            beasiswaBinding = new BindingSource
            {
                DataSource = beasiswaList,
            };
            initCombo();
            initGrid();
            RefreshListData();
            buttonFoto();
        }

        private void ListSiswa_grid_DoubleClick_1(object sender, EventArgs e)
        {
            var siswaIdstr = ListSiswa_grid.CurrentRow.Cells["SiswaId"].Value.ToString();
            if (siswaIdstr is null)
                return;
            var siswaId = Convert.ToInt32(siswaIdstr);
            GetSiswa(siswaId);
            SiswaTabControl.SelectedIndex = 1;
        }


        #region PRODUCE_ISI
        public void initCombo()
        {
            //Agama
            List<string> Agama = new List<string>() { "ISLAM", "KRISTEN", "KATOLIK", "HINDU", "BUDHA", "KONGHUCU" };
            cb_AgamaAyah.DataSource = new List<string>(Agama);
            cb_AgamaIbu.DataSource = new List<string>(Agama);
            cb_AgamaWali.DataSource = new List<string>(Agama);
            cb_Agama.DataSource = new List<string>(Agama);

            //Yatim
            List<string> Yatim = new List<string>() { "Lengkap", "Yatim", "Piatu", "Yatim-Piatu" };
            cb_Yatim.DataSource = Yatim;

            //Status Tinggal
            List<string> StatusTInggal = new List<string>() { "DENGAN ORTU", "DENGAN SAUDARA", "DI ASRAMA" };
            cb_statustinggal.DataSource = new List<string>(StatusTInggal);
            cb_statustinggal.DataSource = new List<string>(StatusTInggal);
            cb_statustinggal.DataSource = new List<string>(StatusTInggal);
            cb_statustinggal.SelectedIndex = 0;

            //Hidup meninggal
            List<string> HIdup = new List<string>() { "HIDUP", "MENINGGAL" };
            cb_hidupWali.DataSource = new List<string>(HIdup);
            cb_hidupIbu.DataSource = new List<string>(HIdup);
            cb_HidupAyah.DataSource = new List<string>(HIdup);

            //warga negara
            cb_warganegara.Items.Add("WNI");
            cb_warganegara.Items.Add("ASING");
        }

        private void initGrid()
        {
            dataGrid_beasiswa.DataSource = beasiswaBinding;
            dataGrid_beasiswa.Columns["No"].Width = 40;
            dataGrid_beasiswa.Columns["Tahun"].Width = 50;
            dataGrid_beasiswa.Columns["Kelas"].Width = 50;
            dataGrid_beasiswa.Columns["AsalBeasiswa"].Width = 200;
        }
        #endregion

        #region SAVE SISWA
        private void SaveSiswa()
        {
            var siswaId = SaveSiswaPerson();
            SaveSiswaRiwayat(siswaId);
            SaveSiswaWali(siswaId);
            SaveSiswalulus(siswaId);
            SaveSiswaBeasiswa(siswaId);
        }
        private int SaveSiswaPerson()
        {
            var siswaId = SiswaIDtxt.Text == string.Empty ? 0 :
                int.Parse(SiswaIDtxt.Text);
            var siswa = new SiswaModel
            {
                SiswaId = siswaId,
                NamaLengkap = tx_Nmlengkap.Text,
                NamaPanggil = tx_NmPanggilan.Text,
                Gender = rb_laki.Checked ? 0 : 1,
                TmpLahir = tx_TmpatLahir.Text,
                TglLahir = date_TglLahir.Value,
                Agama = cb_Agama.SelectedItem.ToString() ?? string.Empty,
                Kewarganegaraan = cb_warganegara.SelectedItem.ToString() ?? string.Empty,
                NIK = tx_NIK.Text,
                AnakKe = (int)anakke_numeric.Value,
                JmlhSdrKandung = (int)jmlsauKan_numeric.Value,
                JmlhSdrTiri = (int)jmlSauTiri_numeric.Value,
                JmlhSdrAngkat = (int)jmlSauAngkat_numeric.Value,
                YatimPiatu = cb_Yatim.SelectedItem.ToString() ?? string.Empty,
                Bahasa = tx_Bahasa.Text,
                Alamat = tx_Alamat.Text,
                NoTelp = tx_Notelp.Text,
                TngglDengan = cb_statustinggal.SelectedItem.ToString() ?? string.Empty,
                JrkKeSekolah = (int)jarakSklh_numeric.Value,
                TransportSekolah = tx_Transportasi.Text
            };
            if (siswa.SiswaId == 0)
            {
                siswaId = siswaDal.Insert(siswa);
                MessageBox.Show("Data Berhasil Di Tambahkan", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                siswaDal.Update(siswa);
                MessageBox.Show("Data Berhasil Di Update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return siswaId;
        }
        private void SaveSiswaRiwayat(int siswaId)
        {
            string goldar = string.Empty;
            if (Goldar_A.Checked) goldar = "A";
            if (Goldar_B.Checked) goldar = "B";
            if (Goldar_AB.Checked) goldar = "AB";
            if (Golddar_O.Checked) goldar = "O";

            var siswaid = SiswaIDtxt.Text == string.Empty ? 0 :
            int.Parse(SiswaIDtxt.Text);
            var siswaRiwayat = new SiswaRiwayatModel
            {
                SiswaId = siswaid,
                GolDarah = goldar,
                RiwayatPenyakit = tx_Penyakit.Text,
                KelainanJasmani = tx_Kelainan.Text,
                TinggiBdn = (int)nu_TB.Value,
                BeratBdn = (int)nu_BB.Value,
                LulusanDr = tx_Lulusan.Text,
                TglIjazah = date_Tglijazah.Value.Date,
                NoIjazah = tx_NoIjazah.Text,
                LamaBljr = tx_LamaBelajar.Text,
                PindahanDr = tx_DariSekolah.Text,
                AlasanPindah = tx_Alasan.Text,
                DiterimaTingkat = tx_diterimakelas.Text,
                KompKeahlian = tx_keahlian.Text,
                TglDiterima = dtp_tglditerima.Value.Date,
                Kesenian = tx_Kesenian.Text,
                Olahraga = tx_Olahraga.Text,
                Organisasi = tx_Organisasi.Text,
                Hobi = tx_Hobi.Text,
                CitaCita = tx_CitaCita.Text,
                TglTinggalSekolah = date_Tglmeninggalkan.Value.Date,
                AlasanTinggal = tx_Alasanmeninggalkan.Text,
                AkhirTamatBljr = dtp_tamatbelajar.Value.Date,
                AkhirNoIjazah = tx_IjazahNo.Text
            };
            var dataDiDb = siswaRiwayatDal.GetData(siswaId);
            if (dataDiDb is null)
            {
                siswaRiwayatDal.Insert(siswaRiwayat);
            }
            else
            {
                siswaRiwayatDal.Update(siswaRiwayat);
            }

        }
        private void SaveSiswaWali(int siswaId)
        {
            var ayah = new SiswaWaliModel
            {
                //Ayah
                SiswaId = siswaId,
                JenisWali = 0,
                Nama = tx_NamaAyah.Text,
                TmpLahir = tx_TempatAyah.Text,
                TglLahir = date_LahirAyah.Value,
                Agama = cb_AgamaAyah.SelectedItem.ToString() ?? string.Empty,
                Kewarga = rb_WNIayah.Checked ? 0 : 1,
                Pendidikan = tx_PendidikanAyah.Text,
                Pekerjaan = tx_WorkAyah.Text,
                Penghasilan = (int)nu_gajiAyah.Value,
                Alamat = tx_AlamatAyah.Text,
                NoTelp = tx_NohpAyah.Text,
                NoKK = tx_NoKK.Text,
                NIK = tx_NIKAyah.Text,
                StatusHidup = cb_HidupAyah.Text,
                TahunMeninggal = tx_MeninggalAyah.Text
            };

            var ibu = new SiswaWaliModel
            {
                SiswaId = siswaId,
                JenisWali = 1,
                Nama = tx_NamaIbu.Text,
                TmpLahir = tx_TempatIbu.Text,
                TglLahir = date_LahirIbu.Value,
                Agama = cb_AgamaIbu.SelectedItem.ToString() ?? string.Empty,
                Kewarga = rb_WNIIbu.Checked ? 0 : 1,
                Pendidikan = tx_PendidikanIbu.Text,
                Pekerjaan = tx_WorkIbu.Text,
                Penghasilan = (int)nu_gajiIbu.Value,
                Alamat = tx_AlamatIbu.Text,
                NoTelp = tx_noHpIBu.Text,
                NoKK = tx_NoKKIbu.Text,
                NIK = tx_NIKIbu.Text,
                StatusHidup = cb_hidupIbu.Text,
                TahunMeninggal = tx_MeninggalIbu.Text,
            };

            var wali = new SiswaWaliModel
            {
                SiswaId = siswaId,
                JenisWali = 2,
                Nama = tx_NamaWali.Text,
                TmpLahir = tx_TempatWali.Text,
                TglLahir = date_LahirWali.Value,
                Agama = cb_AgamaWali.SelectedItem.ToString() ?? string.Empty,
                Kewarga = rb_WNIWali.Checked ? 0 : 1,
                Pendidikan = tx_PendidikanWali.Text,
                Pekerjaan = tx_pekerjaanWali.Text,
                Penghasilan = (int)nu_gajiWali.Value,
                Alamat = tx_AlamatWali.Text,
                NoTelp = tx_NohpWali.Text,
                NoKK = tx_noKKwali.Text,
                NIK = tx_NikWali.Text,
                StatusHidup = cb_hidupWali.Text,
                TahunMeninggal = ""
            };
            var ListWali = new List<SiswaWaliModel>
            {
                ayah, ibu, wali
            };

            var dataDiDb = siswaWaliDal.ListData(siswaId);
            if (!dataDiDb.Any())
            {
                siswaWaliDal.Insert(ListWali);
            }
            else
            {
                siswaWaliDal.Update(ListWali);
            }

        }
        private void SaveSiswaBeasiswa(int siswaId)
        {
            var listBeasiswa = new List<SiswaBeasiswaModel>();
            siswaBeasiswaDal.Delete(siswaId);
            foreach (var item in beasiswaList)
            {
                var newItem = new SiswaBeasiswaModel
                {
                    SiswaId = siswaId,
                    NoUrut = listBeasiswa.Count + 1,
                    Kelas = item.Kelas,
                    Tahun = item.Tahun,
                    AsalBeasiswa = item.AsalBeasiswa
                };
                if ($"{newItem.Kelas}{newItem.Tahun}" == string.Empty)
                    continue;
                listBeasiswa.Add(newItem);
            }
            siswaBeasiswaDal.Insert(listBeasiswa);
        }
        private void SaveSiswalulus(int siswaId)
        {
            var siswalulus = new SiswaLulusModel
            {
                SiswaId = siswaId,
                LanjutDi = tx_melanjutkan.Text,
                TglMulaiKerja = date_mulaikerja.Value.Date,
                NamaPerusahaan = tx_perusahaan.Text,
                Penghasilan = (int)nu_penghasilanLulus.Value,
            };
            var dataDiDb = siswaLulusDal.Get(siswaId);
            if (dataDiDb is null)
                siswaLulusDal.Insert(siswalulus);
            else
                siswaLulusDal.Update(siswalulus);
        }

        #endregion

        #region GET SISWA
        private void GetSiswa(int siswaId)
        {
            ClearInput();
            SiswaIDtxt.Text = siswaId.ToString();
            GetSiswaPersonal(siswaId);
            GetSiswaRiwayat(siswaId);
            GetSiswaWali(siswaId);
            GetSiswaBeasiswa(siswaId);
        }
        private void GetSiswaPersonal(int siswaId)
        {

            var siswaPersonal = siswaDal.GetData(siswaId);
            if (siswaPersonal is null)
            {
                MessageBox.Show("Data not found");
                return;
            }
            tx_Nmlengkap.Text = siswaPersonal.NamaLengkap;
            tx_NmPanggilan.Text = siswaPersonal.NamaPanggil;
            tx_TmpatLahir.Text = siswaPersonal.TmpLahir;
            date_TglLahir.Value = siswaPersonal.TglLahir;

            if (siswaPersonal.Gender == 0)
                rb_laki.Checked = true;
            else if (siswaPersonal.Gender == 1)
                rb_perempuan.Checked = true;

            foreach (var item in cb_Agama.Items)
                if (item.ToString() == siswaPersonal.Agama)
                    cb_Agama.SelectedItem = item;

            foreach (var items in cb_warganegara.Items)
                if (items.ToString() == siswaPersonal.Agama)
                    cb_warganegara.SelectedItem = items;

            anakke_numeric.Value = siswaPersonal.AnakKe;
            jmlsauKan_numeric.Value = siswaPersonal.JmlhSdrKandung;
            jmlSauAngkat_numeric.Value = siswaPersonal.JmlhSdrAngkat;
            jmlSauTiri_numeric.Value = siswaPersonal.JmlhSdrTiri;

            foreach (var item in cb_Yatim.Items)
                if (item.ToString() == siswaPersonal.YatimPiatu)
                    cb_Yatim.SelectedItem = item;

            tx_Bahasa.Text = siswaPersonal.Bahasa;
            tx_NIK.Text = siswaPersonal.NIK;
            tx_Alamat.Text = siswaPersonal.Alamat;
            tx_Notelp.Text = siswaPersonal.NoTelp;

            foreach (var item in cb_statustinggal.Items)
                if (item.ToString() == siswaPersonal.TngglDengan)
                    cb_statustinggal.SelectedItem = item;

            jarakSklh_numeric.Value = siswaPersonal.JrkKeSekolah;
            tx_Transportasi.Text = siswaPersonal.TransportSekolah;
        }
        private void GetSiswaRiwayat(int siswaId)
        {
            var siswaRiwayat = siswaRiwayatDal.GetData(siswaId);
            if (siswaRiwayat is null)
                return;

            if (siswaRiwayat.GolDarah == "A") Goldar_A.Checked = true;
            if (siswaRiwayat.GolDarah == "B") Goldar_B.Checked = true;
            if (siswaRiwayat.GolDarah == "AB") Goldar_AB.Checked = true;
            if (siswaRiwayat.GolDarah == "O") Golddar_O.Checked = true;

            tx_Penyakit.Text = siswaRiwayat.RiwayatPenyakit;
            tx_Kelainan.Text = siswaRiwayat.KelainanJasmani;
            nu_TB.Value = siswaRiwayat.TinggiBdn;
            nu_BB.Value = siswaRiwayat.BeratBdn;

            tx_Lulusan.Text = siswaRiwayat.LulusanDr;
            date_Tglijazah.Value = siswaRiwayat.TglIjazah;
            tx_NoIjazah.Text = siswaRiwayat.NoIjazah;
            tx_LamaBelajar.Text = siswaRiwayat.LamaBljr;

            tx_DariSekolah.Text = siswaRiwayat.PindahanDr;
            tx_Alasan.Text = siswaRiwayat.AlasanPindah;
            tx_diterimakelas.Text = siswaRiwayat.DiterimaTingkat;
            tx_keahlian.Text = siswaRiwayat.KompKeahlian;
            dtp_tglditerima.Value = siswaRiwayat.TglDiterima;

            tx_Kesenian.Text = siswaRiwayat.Kesenian;
            tx_Olahraga.Text = siswaRiwayat.Olahraga;
            tx_Organisasi.Text = siswaRiwayat.Organisasi;
            tx_Hobi.Text = siswaRiwayat.Hobi;
            tx_CitaCita.Text = siswaRiwayat.CitaCita;

            date_Tglmeninggalkan.Value = siswaRiwayat.TglTinggalSekolah;
            tx_Alasanmeninggalkan.Text = siswaRiwayat.AlasanTinggal;

            dtp_tamatbelajar.Value = siswaRiwayat.AkhirTamatBljr;
            tx_IjazahNo.Text = siswaRiwayat.AkhirNoIjazah;
        }
        private void GetSiswaWali(int siswaId)
        {
            var listWali = siswaWaliDal.ListData(siswaId);
            if (listWali is null) return;

            var ayah = listWali.FirstOrDefault(x => x.JenisWali == 0);
            if (ayah is not null)
            {
                tx_NamaAyah.Text = ayah.Nama;
                tx_TempatAyah.Text = ayah.TmpLahir;
                date_LahirAyah.Value = ayah.TglLahir;
                if (ayah.Kewarga == 0)
                    rb_WNIayah.Checked = true;
                else
                    rb_Asingayah.Checked = true;
                tx_PendidikanAyah.Text = ayah.Pendidikan;
                tx_WorkAyah.Text = ayah.Pekerjaan;
                nu_gajiAyah.Value = ayah.Penghasilan;
                tx_AlamatAyah.Text = ayah.Alamat;
                tx_NIKAyah.Text = ayah.NIK;
                tx_NoKK.Text = ayah.NoKK;
                tx_NohpAyah.Text = ayah.NoTelp;
                cb_HidupAyah.Text = ayah.StatusHidup;
                tx_MeninggalAyah.Text = ayah.TahunMeninggal;
            }

            var ibu = listWali.FirstOrDefault(x => x.JenisWali == 1);
            if (ibu is not null)
            {
                tx_NamaIbu.Text = ibu.Nama;
                tx_TempatIbu.Text = ibu.TmpLahir;
                date_LahirIbu.Value = ibu.TglLahir;
                if (ibu.Kewarga == 0)
                    rb_WNIIbu.Checked = true;
                else
                    rb_AsingIbu.Checked = true;
                tx_PendidikanIbu.Text = ibu.Pendidikan;
                tx_WorkIbu.Text = ibu.Pekerjaan;
                nu_gajiIbu.Value = ibu.Penghasilan;
                tx_AlamatIbu.Text = ibu.Alamat;
                tx_noHpIBu.Text = ibu.NoTelp;
                cb_hidupIbu.Text = ibu.StatusHidup;
                tx_MeninggalIbu.Text = ibu.TahunMeninggal;
                tx_NoKKIbu.Text = ibu.NoKK;
                tx_NIKIbu.Text = ibu.NIK;
            }

            var wali = listWali.FirstOrDefault(x => x.JenisWali == 2);
            if (wali is not null)
            {
                tx_NamaWali.Text = wali.Nama;
                tx_TempatWali.Text = wali.TmpLahir;
                date_LahirWali.Value = wali.TglLahir;
                if (wali.Kewarga == 0)
                    rb_WNIWali.Checked = true;
                else
                    rb_AsingWali.Checked = true;
                tx_PendidikanWali.Text = wali.Pendidikan;
                tx_pekerjaanWali.Text = wali.Pekerjaan;
                nu_gajiWali.Value = wali.Penghasilan;
                tx_AlamatWali.Text = wali.Alamat;
                tx_NohpWali.Text = wali.NoTelp;
                cb_hidupWali.Text = wali.StatusHidup;
                tx_NikWali.Text = wali.NIK;
                tx_noKKwali.Text = wali.NoKK;
            }

        }
        private void GetSiswaBeasiswa(int siswaId)
        {
            var listBea = siswaBeasiswaDal.ListData(siswaId)?.ToList();
            if (listBea is null)
                return;

            beasiswaList.Clear();
            listBea.ForEach(x => beasiswaList.Add(new BeasiswaDto
            {
                No = x.NoUrut,
                Kelas = x.Kelas,
                Tahun = x.Tahun,
                AsalBeasiswa = x.AsalBeasiswa
            }));
        }
        #endregion

        #region HELPER
        private void ClearInput()
        {
            //Personal
            SiswaIDtxt.Clear();
            tx_NIK.Clear();
            tx_Nmlengkap.Clear();
            tx_NmPanggilan.Clear();
            tx_TmpatLahir.Clear();
            date_TglLahir.Value = new DateTime(3000, 1, 1);
            cb_Agama.SelectedIndex = 0;
            cb_warganegara.SelectedIndex = 0;
            anakke_numeric.Value = 0;
            jmlsauKan_numeric.Value = 0;
            jmlSauAngkat_numeric.Value = 0;
            jmlSauTiri_numeric.Value = 0;
            cb_Yatim.SelectedIndex = 0;
            tx_Bahasa.Clear();
            tx_Alamat.Clear();
            tx_Notelp.Clear();
            cb_statustinggal.SelectedIndex = 0;
            jarakSklh_numeric.Value = 0;
            tx_Transportasi.Clear();

            //Riwayat
            tx_Penyakit.Clear();
            tx_Kelainan.Clear();
            nu_TB.Value = 0;
            nu_BB.Value = 0;
            tx_Lulusan.Clear();
            date_Tglijazah.Value = new DateTime(3000, 1, 1);
            tx_NoIjazah.Clear();
            tx_LamaBelajar.Clear();
            tx_DariSekolah.Clear();
            tx_Alasan.Clear();
            tx_diterimakelas.Clear();
            tx_keahlian.Clear();
            dtp_tglditerima.Value = new DateTime(3000, 1, 1);
            tx_Kesenian.Clear();
            tx_Olahraga.Clear();
            tx_Organisasi.Clear();
            tx_Hobi.Clear();
            tx_CitaCita.Clear();

            date_Tglmeninggalkan.Value = new DateTime(3000, 1, 1);
            tx_Alasanmeninggalkan.Clear();
            dtp_tamatbelajar.Value = new DateTime(3000, 1, 1);
            tx_IjazahNo.Clear();

            //Wali
            tx_NamaAyah.Clear();
            tx_TempatAyah.Clear();
            date_LahirAyah.Value = new DateTime(3000, 1, 1);
            rb_WNIayah.Checked = true;
            tx_PendidikanAyah.Clear();
            tx_WorkAyah.Clear();
            nu_gajiAyah.Value = 0;
            tx_NIKAyah.Clear();
            tx_NoKK.Clear();
            //      ibu
            tx_NamaIbu.Clear();
            tx_TempatIbu.Clear();
            date_LahirIbu.Value = new DateTime(3000, 1, 1);
            rb_WNIIbu.Checked = true;
            tx_PendidikanIbu.Clear();
            tx_WorkIbu.Clear();
            nu_gajiIbu.Value = 0;
            /*tx_NIKIbu.Clear();
            tx_kkIBu.Clear();*/
            //      wali
            tx_NamaWali.Clear();
            tx_TempatWali.Clear();
            date_LahirWali.Value = new DateTime(3000, 1, 1);
            rb_WNIIbu.Checked = true;
            tx_PendidikanWali.Clear();
            tx_pekerjaanWali.Clear();
            nu_gajiWali.Value = 0;
            /*tx_nikwali.Clear();
            tx_kkwali.Clear();*/

            //lulus
        }
        private void RefreshListData()
        {
            var listData = siswaDal.ListData(string.Empty, new {}) ?? new List<SiswaModel>();
            var dataSource = listData
                .Select(x => new ListSiswaDto
                {
                    SiswaId = x.SiswaId,
                    NamaLengkap = x.NamaLengkap,
                    TglLahir = x.TglLahir,
                    Gender = x.Gender == 0 ? "LakiLaki" : "Perempuan",
                    Alamat = x.Alamat
                })
                .ToList();
            ListSiswa_grid.DataSource = dataSource;
            ListSiswa_grid.Refresh();

            ListSiswa_grid.Columns["SiswaId"].Width = 50;
            ListSiswa_grid.Columns["SiswaId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion

        #region BUTTON SAVE
        private void btn_SaveSiswa_Click(object sender, EventArgs e)
        {
            SaveSiswa();
            RefreshListData();
        }

        private void btn_SaveSiswaRiwayat_Click(object sender, EventArgs e)
        {
            SaveSiswa();
            RefreshListData();
        }

        private void btn_SaveSiswaWali_Click(object sender, EventArgs e)
        {
            SaveSiswa();
            RefreshListData();
        }

        private void btn_SaveLulus_Click(object sender, EventArgs e)
        {
            SaveSiswa();
            RefreshListData();
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Buat data baru??", "Konfirmasi", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
                return;
            var siswaId = SiswaIDtxt.Text;
            var siswaName = tx_Nmlengkap.Text;


            ClearInput();
            SiswaTabControl.SelectedTab = PersonalTabPage;
            tx_Nmlengkap.Focus();
        }
        #endregion


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshListData();
        }
        public class ListSiswaDto
        {
            public int SiswaId { get; set; }
            public string NamaLengkap { get; set; }
            public DateTime TglLahir { get; set; }
            public string Gender { get; set; }
            public string Alamat { get; set; }
        }

        public class BeasiswaDto
        {
            public int No { get; set; }
            public string Tahun { get; set; }
            public string Kelas { get; set; }
            public string AsalBeasiswa { get; set; }
        }

        #region FOTO SISWA
        private void ListSiswa_grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var siswaId = ListSiswa_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            var siswaName = ListSiswa_grid.Rows[e.RowIndex].Cells[1].Value.ToString();

            lbl_siswaId.Text = siswaId;
            lbl_SiswaName.Text = siswaName;

            var siswa = siswaDal.GetData(Convert.ToInt32(siswaId));
            FotoLokasi = siswa?.LokasiPhoto ?? string.Empty;
            if (FotoLokasi != string.Empty)
            {
                SiswaFoto.Image = Image.FromFile(FotoLokasi);
            }
            else
            {
                SiswaFoto.Image = null;
            }
        }

        private void ListSiswa_grid_SelectionChanged(object sender, EventArgs e)
        {
            if (ListSiswa_grid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ListSiswa_grid.SelectedRows[0];

                string siswaId = selectedRow.Cells[0].Value.ToString();
                string siswaName = selectedRow.Cells[1].Value.ToString();

                lbl_siswaId.Text = siswaId;
                lbl_SiswaName.Text = siswaName;

                var siswa = siswaDal.GetData(Convert.ToInt32(siswaId));
                FotoLokasi = siswa?.LokasiPhoto ?? string.Empty;
                if (FotoLokasi != string.Empty)
                {
                    SiswaFoto.Image = Image.FromFile(FotoLokasi);
                }
                else
                {
                    SiswaFoto.Image = null;
                }
            }
        }

        private void buttonFoto()
        {
            btnHapus.Click += btnHapus_Click;
            BtnPilih.Click += BtnPilih_Click;
        }

        private void btnHapus_Click(object? sender, EventArgs e)
        {
            SiswaFoto.Image = null;
            FotoLokasi = string.Empty;
        }
        private void BtnPilih_Click(object sender, EventArgs e)
        {
            var openfileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                FilterIndex = 1,
                Title = "Select a Foto"
            };

            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                SiswaFoto.Image = System.Drawing.Image.FromFile(openfileDialog.FileName);
                SiswaFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                FotoLokasi = openfileDialog.FileName;

                UpdateFotosiswa();
            }
        }

        private void UpdateFotosiswa()
        {
            var siswa = siswaDal.GetData(Convert.ToInt32(lbl_siswaId.Text));
            if (siswa is null)
            {
                SiswaFoto.Image = null;
                FotoLokasi = string.Empty;
                return;
            }
            siswa.LokasiPhoto = FotoLokasi;
            siswaDal.Update(siswa);
        }
        #endregion

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}  
