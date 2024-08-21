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
    public class SiswaWaliDal
    {
        public void Insert(IEnumerable<SiswaWaliModel> listWali)
        {
            const string sql = @" 
            INSERT INTO SiswaWali(
            SiswaId, JenisWali, Nama, TmptLahir,
            TglLahir, Agama, Kewarga, Pendidikan, 
            Pekerjaan, Penghasilan, Alamat, NoKK,
            NoTelp, StatusHidup, NIK)
            VALUES(
            @SiswaId, @JenisWali, @Nama, @TmptLahir, 
            @TglLahir, @Agama, @Kewarga, @Pendidikan,
            @Pekerjaan, @Penghasilan, @Alamat, @NoKK,
            @NoTelp, @StatusHidup, @NIK)";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            foreach (var item in listWali)
            {
                var dp = new DynamicParameters();
                dp.Add("@SiswaId", item.SiswaId,System.Data.DbType.Int32);
                dp.Add("@JenisWali", item.JenisWali,System.Data.DbType.String);
                dp.Add("@Nama", item.Nama,System.Data.DbType.String);
                dp.Add("@Agama", item.Agama,System.Data.DbType.String);
                dp.Add("@Kewarga", item.Kewarga,System.Data.DbType.String);
                dp.Add("@Pendidikan", item.Kewarga,System.Data.DbType.String);
                dp.Add("@Pekerjaan", item.Pekerjaan, System.Data.DbType.String);
                dp.Add("@Penghasilan", item.Penghasilan, System.Data.DbType.Decimal);
                dp.Add("@Alamat", item.Alamat, System.Data.DbType.String);
                dp.Add("@NoKK", item.NoKK, System.Data.DbType.String);
                dp.Add("@NoTelp", item.NoTelp,System.Data.DbType.String);
                dp.Add("@StatusHidup",item.StatusHidup,System.Data.DbType.String);
                dp.Add("@NIK", item.NIK,System.Data.DbType.String);
                conn.Execute(sql, dp);
            }
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
                   SiswaId, JenisWali, Nama, TmptLahir,
                   TglLahir, Agama, Kewarga, Pendidikan, 
                   Pekerjaan, Penghasilan, Alamat, NoKK,
                   NoTelp, StatusHidup, NIK
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
