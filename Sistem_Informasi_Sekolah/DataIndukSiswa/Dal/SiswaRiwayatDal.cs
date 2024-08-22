using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.DataIndukSiswa.Dal
{
    public class SiswaRiwayatDal
    {
        public void Insert(SiswaRiwayatModel siswaRiwayat)
        {
            const string sql = @"
                INSERT INTO SiswaRiwayat(
                    SiswaId, GolDarah, RiwayatPenyakit, 
                    KelainanJasmani, TinggiBdn, BeratBdn, 
                    LulusanDr, TglIjazah, NoIjazah, LamaBljr,
                    PindahanDr, AlasanPindah,
                    DiterimaTingkat, KompKeahlian, TglDiterima, 
                    Kesenian, Olahraga, Organisasi, Hobi, CitaCita,
                    TglTinggalSekolah, AlasanTinggal, AkhirTamatBljr, 
                    AKhirNoIjazah ) 
                VALUES (
                    @SiswaId, @GolDarah, @RiwayatPenyakit, 
                    @KelainanJasmani, @TinggiBdn, @BeratBdn, 
                    @LulusanDr, @TglIjazah, @NoIjazah, @LamaBljr,
                    @PindahanDr, @AlasanPindah,
                    @DiterimaTingkat, @KompKeahlian, @TglDiterima,
                    @Kesenian, @Olahraga, @Organisasi, @Hobi, @CitaCita,
                    @TglTinggalSekolah, @AlasanTinggal, @AkhirTamatBljr, 
                    @AKhirNoIjazah)";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaRiwayat.SiswaId, DbType.Int32);
            dp.Add("@GolDarah", siswaRiwayat.GolDarah, DbType.String);
            dp.Add("@RIwayatPenyakit", siswaRiwayat.RiwayatPenyakit, DbType.String);
            dp.Add("@KelainanJasmani", siswaRiwayat.KelainanJasmani, DbType.String);
            dp.Add("@TinggiBdn", siswaRiwayat.TinggiBdn, DbType.Int16);
            dp.Add("@BeratBdn", siswaRiwayat.BeratBdn, DbType.Int16);
            dp.Add("@LulusanDr", siswaRiwayat.LulusanDr, DbType.String);
            dp.Add("@TglIjazah", siswaRiwayat.TglIjazah, DbType.DateTime);
            dp.Add("@NoIjazah", siswaRiwayat.NoIjazah, DbType.String);
            dp.Add("@LamaBljr", siswaRiwayat.LamaBljr, DbType.String);
            dp.Add("@PindahanDr", siswaRiwayat.PindahanDr, DbType.String);
            dp.Add("@AlasanPindah", siswaRiwayat.AlasanPindah, DbType.String);
            dp.Add("@DiterimaTIngkat", siswaRiwayat.DiterimaTingkat, DbType.String);
            dp.Add("@KompKeahlian", siswaRiwayat.KompKeahlian, DbType.String);
            dp.Add("@TglDiterima", siswaRiwayat.TglDiterima, DbType.DateTime);
            dp.Add("@Kesenian", siswaRiwayat.Kesenian, DbType.String);
            dp.Add("@Olahraga", siswaRiwayat.Olahraga, DbType.String);
            dp.Add("@Organisasi", siswaRiwayat.Organisasi, DbType.String);
            dp.Add("@Hobi", siswaRiwayat.Hobi, DbType.String);
            dp.Add("@CitaCita", siswaRiwayat.CitaCita, DbType.String);
            dp.Add("@TglTinggalSekolah", siswaRiwayat.TglTinggalSekolah, DbType.DateTime);
            dp.Add("@AlasanTInggal", siswaRiwayat.AlasanTinggal, DbType.String);
            dp.Add("@AkhirTamatBljr", siswaRiwayat.AkhirTamatBljr, DbType.DateTime);
            dp.Add("@AkhirNoIjazah", siswaRiwayat.AkhirNoIjazah, DbType.String);



            var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public void Update(SiswaRiwayatModel siswaRiwayat)
        {
            const string sql = @"
                UPDATE SiswaRiwayat
                SET
                    GolDarah = @GolDarah, 
                    RiwayatPenyakit = @RiwayatPenyakit, 
                    KelainanJasmani = @KelainanJasmani, 
                    TinggiBdn = @TinggiBdn, 
                    BeratBdn = @BeratBdn, 
                    LulusanDr = @LulusanDr, 
                    TglIjazah = @TglIjazah, 
                    NoIjazah = @NoIjazah, 
                    LamaBljr = @LamaBljr,
                    PindahanDr = @PindahanDr, 
                    AlasanPindah = @AlasanPindah,
                    DiterimaTingkat = @DiterimaTingkat, 
                    KompKeahlian = @KompKeahlian, 
                    Kesenian = @Kesenian,
                    Olahraga = @Olahraga,
                    Organisasi = @Organisasi,
                    Hobi = @Hobi,
                    CitaCita = @CitaCita, 
                    TglTinggalSekolah = @TglTinggalSekolah,
                    AlasanTinggal = @AlasanTinggal,
                    AkhirTamatBljr = @AkhirTamatBljr,
                    AkhirNoIjazah = @AkhirNoIjazah 

                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaRiwayat.SiswaId, DbType.Int32);
            dp.Add("@GolDarah", siswaRiwayat.GolDarah, DbType.String);
            dp.Add("@RIwayatPenyakit", siswaRiwayat.RiwayatPenyakit, DbType.String);
            dp.Add("@KelainanJasmani", siswaRiwayat.KelainanJasmani, DbType.String);
            dp.Add("@TinggiBdn", siswaRiwayat.TinggiBdn, DbType.Int16);
            dp.Add("@BeratBdn", siswaRiwayat.BeratBdn, DbType.Int16);
            dp.Add("@LulusanDr", siswaRiwayat.LulusanDr, DbType.String);
            dp.Add("@TglIjazah", siswaRiwayat.TglIjazah, DbType.DateTime);
            dp.Add("@NoIjazah", siswaRiwayat.NoIjazah, DbType.String);
            dp.Add("@LamaBljr", siswaRiwayat.LamaBljr, DbType.String);
            dp.Add("@PindahanDr", siswaRiwayat.PindahanDr, DbType.String);
            dp.Add("@AlasanPindah", siswaRiwayat.AlasanPindah, DbType.String);
            dp.Add("@DiterimaTIngkat", siswaRiwayat.DiterimaTingkat, DbType.String);
            dp.Add("@KompKeahlian", siswaRiwayat.KompKeahlian, DbType.String);
            dp.Add("@TglDiterima", siswaRiwayat.TglDiterima, DbType.DateTime);
            dp.Add("@Kesenian", siswaRiwayat.Kesenian, DbType.String);
            dp.Add("@Olahraga", siswaRiwayat.Olahraga, DbType.String);
            dp.Add("@Organisasi", siswaRiwayat.Organisasi, DbType.String);
            dp.Add("@Hobi", siswaRiwayat.Hobi, DbType.String);
            dp.Add("@CitaCita", siswaRiwayat.CitaCita, DbType.String);
            dp.Add("@TglTinggalSekolah", siswaRiwayat.TglTinggalSekolah, DbType.DateTime);
            dp.Add("@AlasanTInggal", siswaRiwayat.AlasanTinggal, DbType.String);
            dp.Add("@AkhirTamatBljr", siswaRiwayat.AkhirTamatBljr, DbType.DateTime);
            dp.Add("@AkhirNoIjazah", siswaRiwayat.AkhirNoIjazah, DbType.String);
            var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public void Delete(int siswaId)
        {
            const string sql = @"
                DELETE FROM SiswaRiwayat
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId, DbType.Int32);

            var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public SiswaRiwayatModel? GetData(int siswaId)
        {
            const string sql = @"
                SELECT
                   SiswaId, GolDarah, RiwayatPenyakit, 
                    KelainanJasmani, TinggiBdn, BeratBdn, 
                    LulusanDr, TglIjazah, NoIjazah, LamaBljr,
                    PindahanDr, AlasanPindah,
                    DiterimaTingkat, KompKeahlian, TglDiterima, 
                    Kesenian, Olahraga, Organisasi, Hobi, CitaCita,
                    TglTinggalSekolah, AlasanTinggal, AkhirTamatBljr, 
                    AKhirNoIjazah 
                FROM
                    SiswaRiwayat
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QueryFirstOrDefault<SiswaRiwayatModel>(sql, dp);
        }

        public IEnumerable<SiswaRiwayatModel> ListData()
        {
            const string sql = @"
                SELECT
                   SiswaId, GolDarah, RiwayatPenyakit, 
                    KelainanJasmani, TinggiBdn, BeratBdn, 
                    LulusanDr, TglIjazah, NoIjazah, LamaBljr,
                    PindahanDr, AlasanPindah,
                    DiterimaTingkat, KompKeahlian, TglDiterima, 
                    Kesenian, Olahraga, Organisasi, Hobi, CitaCita,
                    TglTinggalSekolah, AlasanTinggal, AkhirTamatBljr, 
                    AKhirNoIjazah
                FROM
                    SiswaRiwayat";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<SiswaRiwayatModel>(sql);
        }
    }
}
