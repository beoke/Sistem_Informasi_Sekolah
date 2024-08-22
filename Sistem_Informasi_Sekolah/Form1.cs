using Microsoft.VisualBasic.Devices;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Dal;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace Sistem_Informasi_Sekolah
{
    public partial class Form1 : Form
    {
        private readonly SiswaDal siswaDal;
        private readonly SiswaRiwayatDal siswaRiwayatDal;
        private readonly SiswaWaliDal siswaWaliDal;
        private readonly SiswaLulusDal siswaLulusDal;
        private readonly SiswaBeasiswaDal siswaBeasiswaDal;
        public Form1()
        {
            InitializeComponent();

            initCombo();
            siswaDal = new SiswaDal();
            siswaBeasiswaDal = new SiswaBeasiswaDal();
            siswaRiwayatDal = new SiswaRiwayatDal();
            siswaWaliDal = new SiswaWaliDal();
            siswaLulusDal = new SiswaLulusDal();

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
            cb_statustinggal.Items.Add("DENGAN ORTU");
            cb_statustinggal.Items.Add("DENGAN SAUDARA");
            cb_statustinggal.Items.Add("DI ASRAMA");
            cb_statustinggal.SelectedIndex = 0;

            //Hidup meninggal
            List<string>HIdup =new List<string>() { "HIDUP", "MENINGGAL"};
            cb_hidupWali.DataSource =new List<string>(HIdup);
            cb_hidupIbu.DataSource = new List<string>(HIdup);
            cb_HidupAyah.DataSource = new List<string>(HIdup);
        }
        #endregion

        #region SAVE SISWA
        private void SaveSiswa()
        {
            var siswaId = SaveSiswaPerson();
            SaveSiswaRiwayat(siswaId);
            SaveSiswaWali(siswaId);
            SaveSiswalulus(siswaId);
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
                Gender = rb_laki.Checked ? 1 : 0,
                TmpLahir = tx_TmpatLahir.Text,
                TglLahir = date_TglLahir.Value,
                Agama = cb_Agama.SelectedItem.ToString() ?? string.Empty,
                Kewarganegaraan = rb_WNIsiswa.Checked ? "WNI" : "Asing",
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
                MessageBox.Show("Berhasil");
            }
            else
            {
                siswaDal.Update(siswa);
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

            var siswaRiwayat = new SiswaRiwayatModel
            {
                SiswaId = siswaId,
                GolDarah = goldar,
                RiwayatPenyakit = tx_Penyakit.Text,
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

            var cekNengDb = siswaRiwayatDal.GetData(siswaId);
            if (cekNengDb is null)
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
                JenisWali = "Ayah",
                Nama = tx_NamaAyah.Text,
                TmpLahir = tx_TempatAyah.Text,
                TglLahir = date_LahirAyah.Value,
                Agama = cb_AgamaAyah.SelectedItem.ToString() ?? string.Empty,
                Kewarga = (rb_Asingayah.Checked) ? "WNI" : "Asing",
                Pendidikan = tx_PendidikanAyah.Text,
                Pekerjaan = tx_WorkAyah.Text,
                Penghasilan = (int)nu_gajiAyah.Value,
                Alamat = tx_AlamatAyah.Text,
                NoTelp = tx_NohpAyah.Text,
                NoKK = tx_NoKK.Text,
                NIK = tx_NIKAyah.Text,
            };

            var ibu = new SiswaWaliModel
            {
                SiswaId = siswaId,
                JenisWali = "Ibu",
                Nama = tx_NamaIbu.Text,
                TmpLahir = tx_TempatIbu.Text,
                TglLahir = date_LahirIbu.Value,
                Agama = cb_AgamaIbu.SelectedItem.ToString() ?? string.Empty,
                Kewarga = (rb_AsingIbu.Checked) ? "WNI" : "Asing",
                Pendidikan = tx_PendidikanIbu.Text,
                Pekerjaan = tx_WorkIbu.Text,
                Penghasilan = (int)nu_gajiIbu.Value,
                Alamat = tx_AlamatIbu.Text,
                NoTelp = tx_noHpIBu.Text,
            };

            var wali = new SiswaWaliModel
            {
                SiswaId = siswaId,
                JenisWali = "Wali",
                Nama = tx_NamaWali.Text,
                TmpLahir = tx_TempatWali.Text,
                TglLahir = date_LahirWali.Value,
                Agama = cb_AgamaWali.SelectedItem.ToString() ?? string.Empty,
                Kewarga = (rb_WNIWali.Checked) ? "WNI" : "Asing",
                Pendidikan = tx_PendidikanWali.Text,
                Pekerjaan = tx_pekerjaanWali.Text,
                Penghasilan = (int)nu_gajiWali.Value,
                Alamat = tx_AlamatWali.Text,
                NoTelp = tx_NohpWali.Text
            };
            var ListWali = new List<SiswaWaliModel>() { ayah, ibu, wali };

            var cekNengDb = siswaWaliDal.ListData(siswaId);
            using var conn = new SqlConnection(ConnStringHelper.Get());

            if (cekNengDb == null)
                siswaWaliDal.Insert(ListWali);
            else
                siswaWaliDal.Update(ListWali);
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


        }

        #endregion

        private void btn_SaveSiswa_Click(object sender, EventArgs e)
        {
            SaveSiswa();
        }

        private void btn_SaveSiswaRiwayat_Click(object sender, EventArgs e)
        {
            SaveSiswa();
        }

        private void btn_SaveSiswaWali_Click(object sender, EventArgs e)
        {
            SaveSiswa();
        }

        private void btn_SaveLulus_Click(object sender, EventArgs e)
        {
            SaveSiswa();
        }


    }
}   
