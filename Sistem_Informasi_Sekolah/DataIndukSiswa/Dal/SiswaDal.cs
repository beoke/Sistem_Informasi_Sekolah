using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.DataIndukSiswa.Dal
{
    public class SiswaDal
    {
        public int Insert(SiswaModel siswa)
        {
            const string sql = @"
                INSERT INTO Siswa(
                    NamaLengkap, NamaPanggil,
                    Gender,TempLahir,TglLahir, Agama, Kewarganegaraan,
                    NIK, AnakKe,JmlhSdrKandung, JmlhSdrTiri, JmlhSdrAngkat,
                    YatimPiatu, Bahasa, Alamat,
                    NoTelp, TngglDengan,JrkKeSekolah,TransportSekolah)
                 OUTPUT INSERTED.SiswaId
                VALUES (
                    @NamaLengkap, @NamaPanggil,
                    @Gender, @TempLahir, @TglLahir, @Agama, @Kewarganegaraan,
                    @NIK, @AnakKe, @JmlhSdrKandung, @JmlhSdrTiri, @JmlhSdrAngkat,
                    @YatimPiatu, @Bahasa, @Alamat,
                    @NoTelp, @TngglDengan, @JrkKeSekolah, @TransportSekolah)";

            var dp = new DynamicParameters();
            dp.Add("@NamaLengkap", siswa.NamaLengkap, DbType.String);
            dp.Add("@NamaPanggilan", siswa.NamaPanggil, DbType.String);
            dp.Add("@Gender", siswa.Gender, DbType.String);
            dp.Add("@TempLahir", siswa.TmpLahir, DbType.DateTime);
            dp.Add("@TglLahir", siswa.TglLahir, DbType.Int16);
            dp.Add("@Agama", siswa.Agama, DbType.String);
            dp.Add("@Kewarganegaraan", siswa.Kewarganegaraan, DbType.String);
            dp.Add("@NIK", siswa.NIK, DbType.Int16);
            dp.Add("@AnakKe", siswa.AnakKe, DbType.Int16);
            dp.Add("@JmlhSdrKandung", siswa.JmlhSdrKandung, DbType.Int16);
            dp.Add("@JmlhSdrTiri", siswa.JmlhSdrTiri, DbType.Int16);
            dp.Add("@JmlhSdrAngkat", siswa.JmlhSdrAngkat, DbType.String);
            dp.Add("@YatimPiatu", siswa.YatimPiatu, DbType.String);
            dp.Add("@Bahasa", siswa.Bahasa, DbType.String);
            dp.Add("@Alamat", siswa.Alamat, DbType.Int16);
            dp.Add("@NoTelp", siswa.NoTelp, DbType.String);
            dp.Add("@TngglDengan", siswa.TngglDengan, DbType.String);
            dp.Add("@JrkKeSekolah", siswa.JrkKeSekolah, DbType.String);
            dp.Add("@TransportSekolah", siswa.TransportSekolah, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.QuerySingle<int>(sql, dp);
            return result;
        }
        public void Update(SiswaModel siswa)
        {
           const string sql = @"UPDATE Siswa SET

                      NamaLengkap=@NamaLengkap,
                      NamaPanggil=@NamaPanggil,
                      Gender=@Gender,
                      TmpLahir=@TmpLahir,
                      Agama=@Agama,
                      Kewarganegaraan=@Kewarganegaraan,
                      NIK=@NIK,
                      AnakKe=@AnakKe,
                      JmlhSdrkandung=@JmlhSdrKandung,
                      JmlhSdrTiri=@JmlhSdrTiri,
                      JmlhSdrAngkat=@JmlhSdrAngkat,
                      YatimPiatu=@YatimPiatu,
                      Bahasa=@Bahasa,
                      Alamat=@Alamat,
                      NoTelp=@NoTelp,
                      TngglDengan=@TngglDengan,
                      JrkKeSekolah=@JrkKeSekolah,
                      TransportSekolah=@TransportSekolah
                  WHERE 
                       SiswaId=@SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@NamaLengkap", siswa.NamaLengkap, DbType.String);
            dp.Add("@NamaPanggilan", siswa.NamaPanggil, DbType.String);
            dp.Add("@Gender", siswa.Gender, DbType.String);
            dp.Add("@TempLahir", siswa.TmpLahir, DbType.DateTime);
            dp.Add("@TglLahir", siswa.TglLahir, DbType.Int16);
            dp.Add("@Agama", siswa.Agama, DbType.String);
            dp.Add("@Kewarganegaraan", siswa.Kewarganegaraan, DbType.String);
            dp.Add("@NIK", siswa.NIK, DbType.Int16);
            dp.Add("@AnakKe", siswa.AnakKe, DbType.Int16);
            dp.Add("@JmlhSdrKandung", siswa.JmlhSdrKandung, DbType.Int16);
            dp.Add("@JmlhSdrTiri", siswa.JmlhSdrTiri, DbType.Int16);
            dp.Add("@JmlhSdrAngkat", siswa.JmlhSdrAngkat, DbType.String);
            dp.Add("@YatimPiatu", siswa.YatimPiatu, DbType.String);
            dp.Add("@Bahasa", siswa.Bahasa, DbType.String);
            dp.Add("@Alamat", siswa.Alamat, DbType.Int16);
            dp.Add("@NoTelp", siswa.NoTelp, DbType.String);
            dp.Add("@TngglDengan", siswa.TngglDengan, DbType.String);
            dp.Add("@JrkKeSekolah", siswa.JrkKeSekolah, DbType.String);
            dp.Add("@TransportSekolah", siswa.TransportSekolah, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }
        public void Delete(int siswaId)
        {
            const string sql = @"
                DELETE FROM 
                    Siswa
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }
        public SiswaModel? GetData(int siswaId)
        {
            const string sql = @"
                SELECT
                    Gender,TempLahir,TglLahir, Agama, Kewarganegaraan,
                    NIK, AnakKe,JmlhSdrKandung, JmlhSdrTiri, JmlhSdrAngkat,
                    YatimPiatu, Bahasa, Alamat,
                    NoTelp, TngglDengan,JrkKeSekolah,TransportSekolah
                FROM
                    Siswa
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QueryFirstOrDefault<SiswaModel>(sql, dp);
        }
    }
}
