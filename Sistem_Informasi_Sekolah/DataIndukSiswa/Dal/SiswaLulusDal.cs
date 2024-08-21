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
    public class SiswaLulusDal
    {
        public void Insert(IEnumerable<SiswaLulusModel> listLulus)
        {
            const string sql = @"
            INSERT INTO SiswaLulus (
            SiswaId, LanjutDi, TglMulaiKerja,
            NamaPerusahaan, Penghasilan)
            VALUES(
            @SiswaId, @LanjutDi, @TglMulaiKerja,
            @NamaPerusahaan, @Penghasilan)";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            foreach(var item in listLulus)
            {
                var dp = new DynamicParameters();
                dp.Add("@SiswaId", item.SiswaId, System.Data.DbType.Int32);
                dp.Add("@LanjutDi", item.LanjutDi, System.Data.DbType.String);
                dp.Add("@TglMulaiKerja", item.TglMulaiKerja, System.Data.DbType.String);
                dp.Add("@NamaPerusahaan", item.NamaPerusahaan, System.Data.DbType.String);  
                dp.Add("Penghasilan", item.NamaPerusahaan,System.Data.DbType.Decimal);

                conn.Execute(sql, dp);

            }
        }
        public void Delete(int SiswaId)
        {
            const string sql = @"
                DELETE FROM 
                    SiswaLulus
                WHERE 
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@Siswaid", SiswaId, DbType.Int32);

            using var conn = new SqlConnection  (ConnStringHelper.Get());
            conn.Execute(sql, dp);
            
        }
        public  IEnumerable<SiswaLulusModel>ListData(int SiswaId)
        {
            const string sql = @"
            SELECT
            SiswaId, LanjutDi, TglMulaiKerja,
            NamaPerusahaan, Penghasilan
            FROM
            SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId",SiswaId,DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<SiswaLulusModel> (sql, dp);
        }
    }
}
