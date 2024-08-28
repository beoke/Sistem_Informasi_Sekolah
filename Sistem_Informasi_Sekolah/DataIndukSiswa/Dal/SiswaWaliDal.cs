using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.DataIndukSiswa.Dal
{
    public class SiswaWaliDal
    {
        public void Insert(IEnumerable<SiswaWaliModel> Walis)
        {
            const string sql = @" 
             INSERT INTO SiswaWali(
                    SiswaId, JenisWali, Nama, TmpLahir,
                    TglLahir, Agama, Kewarga, Pendidikan, 
                    Pekerjaan, Penghasilan, Alamat, NoKK,
                    NoTelp, StatusHidup, NIK, TahunMeninggall)
            VALUES(
                    @SiswaId, @JenisWali, @Nama, @TmpLahir, 
                    @TglLahir, @Agama, @Kewarga, @Pendidikan,
                    @Pekerjaan, @Penghasilan, @Alamat, @NoKK,
                    @NoTelp, @StatusHidup, @NIK, @TahunMeninggall)";
            int cek = 0;
            using var conn = new SqlConnection(ConnStringHelper.Get());
            foreach (var Wali in Walis)
            {
                var dp = new DynamicParameters();
                dp.Add("@SiswaId", Wali.SiswaId, System.Data.DbType.Int32);
                dp.Add("@JenisWali", Wali.JenisWali, System.Data.DbType.Int16);
                dp.Add("@Nama", Wali.Nama, System.Data.DbType.String);
                dp.Add("@TmpLahir", Wali.TmpLahir, System.Data.DbType.String);
                dp.Add("@TglLahir", Wali.TglLahir, System.Data.DbType.DateTime);
                dp.Add("@Agama", Wali.Agama, System.Data.DbType.String);
                dp.Add("@Kewarga", Wali.Kewarga, System.Data.DbType.String);
                dp.Add("@Pendidikan", Wali.Pendidikan, System.Data.DbType.String);
                dp.Add("@Pekerjaan", Wali.Pekerjaan, System.Data.DbType.String);
                dp.Add("@Penghasilan", Wali.Penghasilan, System.Data.DbType.Decimal);
                dp.Add("@Alamat", Wali.Alamat, System.Data.DbType.String);
                dp.Add("@NoKK", Wali.NoKK, System.Data.DbType.String);
                dp.Add("@NoTelp", Wali.NoTelp, System.Data.DbType.String);
                dp.Add("@StatusHidup", Wali.StatusHidup, System.Data.DbType.String);
                dp.Add("@NIK", Wali.NIK, System.Data.DbType.String);
                dp.Add("@TahunMeninggal", Wali.TahunMeninggal, System.Data.DbType.String);

                var insert = conn.Execute(sql, dp);
                if (insert > 0) cek++;
            }
            if (cek >= 3)
                MessageBox.Show("Data Berhasil Di Input");
            else
                MessageBox.Show("Data Gagal Di Input");
        }

        public int Update(IEnumerable<SiswaWaliModel> siswaWalis)
        {

            const string sql = @"
                    UPDATE SiswaWali
                    SET
                        JenisWali = @JenisWali,
                        Nama = @Nama,
                        TmpLahir = @TmpLahir,
                        TglLahir = @TglLahir,
                        Agama = @Agama,
                        Kewarga = @Kewarga,
                        Pendidikan = @Pendidikan,
                        Pekerjaan = @Pekerjaan,
                        Penghasilan = @Penghasilan,
                        Alamat = @Alamat,
                        NoKK = @NoKK,
                        NoTelp = @NoTelp,
                        StatusHidup = @StatusHidup,
                        NIK = @NIK,
                        TahunMeninggal = @TahunMeninggal

                    WHERE SiswaId = @SiswaId";
            int cek = 0;
            using var koneksi = new SqlConnection(ConnStringHelper.Get());
            foreach (var siswaWali in siswaWalis)
            {
                var dp = new DynamicParameters();
                dp.Add("@SiswaId", siswaWali.SiswaId, DbType.Int32);
                dp.Add("@JenisWali", siswaWali.JenisWali, DbType.Int16);
                dp.Add("@Nama", siswaWali.Nama, DbType.String);
                dp.Add("@TmpLahir", siswaWali.TmpLahir, DbType.String);
                dp.Add("@TglLahir", siswaWali.TglLahir, DbType.Date);
                dp.Add("@Agama", siswaWali.Agama, DbType.String);
                dp.Add("@Kewarga", siswaWali.Kewarga, DbType.String);
                dp.Add("@Pendidikan", siswaWali.Pendidikan, DbType.String);
                dp.Add("@Pekerjaan", siswaWali.Pekerjaan, DbType.String);
                dp.Add("@Penghasilan", siswaWali.Penghasilan, DbType.Decimal);
                dp.Add("@Alamat", siswaWali.Alamat, DbType.String);
                dp.Add("@NoKK", siswaWali.NoKK, DbType.String);
                dp.Add("@NoTelp", siswaWali.NoTelp, DbType.String);
                dp.Add("@StatusHidup", siswaWali.StatusHidup, DbType.String);
                dp.Add("@NIK", siswaWali.NIK, DbType.String);
                dp.Add("@TahunMeninggal", siswaWali.TahunMeninggal, DbType.String);

                var update = koneksi.Execute(sql, dp);
                if (update > 0) cek++;
            }
            return cek;
        }
        public void Delete(int siswaId)
        {
            const string sql = @"
                DELETE FROM
                    SiswaWali
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId, System.Data.DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql,dp);
        }
        public IEnumerable<SiswaWaliModel> ListData(int siswaId)
        {
            const string sql = @"
                SELECT 
                   SiswaId, JenisWali, Nama, TmpLahir,
                   TglLahir, Agama, Kewarga, Pendidikan, 
                   Pekerjaan, Penghasilan, Alamat, NoKK,
                   NoTelp, StatusHidup, NIK, TahunMeninggal
                FROM
                    SiswaWali
                WHERE
                    SiswaId = @SiswaId";
            
            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId,DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<SiswaWaliModel>(sql, dp);
        }


        
    }
}
