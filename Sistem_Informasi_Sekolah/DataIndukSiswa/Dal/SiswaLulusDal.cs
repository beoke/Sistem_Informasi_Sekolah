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
        public void Insert(SiswaLulusModel listLulus)
        {
            const string sql = @"
            INSERT INTO SiswaLulus (
            SiswaId, LanjutDi, TglMulaiKerja,
            NamaPerusahaan, Penghasilan)
            VALUES(
            @SiswaId, @LanjutDi, @TglMulaiKerja,
            @NamaPerusahaan, @Penghasilan)";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            {
                var dp = new DynamicParameters();
                dp.Add("@SiswaId", listLulus.SiswaId, System.Data.DbType.Int32);
                dp.Add("@LanjutDi", listLulus.LanjutDi, System.Data.DbType.String);
                dp.Add("@TglMulaiKerja", listLulus.TglMulaiKerja, System.Data.DbType.DateTime);
                dp.Add("@NamaPerusahaan", listLulus.NamaPerusahaan, System.Data.DbType.String);  
                dp.Add("Penghasilan", listLulus.Penghasilan,System.Data.DbType.Decimal);

                conn.Execute(sql, dp);

            }
        }
        public void Update(SiswaLulusModel siswalulus)
        {
            const string sql = @"
                UPDATE SiswaLulus
                SET
                    LanjutDi = @LanjutDi, 
                    TglMulaiKerja = @TglMulaiKerja, 
                    NamaPerusahaan = @NamaPerusahaan, 
                    Penghasilan = @Penghasilan
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswalulus.SiswaId, DbType.Int32);
            dp.Add("@LanjutDi", siswalulus.LanjutDi, DbType.String);
            dp.Add("@TglMulaiKerja", siswalulus.TglMulaiKerja, DbType.DateTime);
            dp.Add("@NamaPerusahaan", siswalulus.NamaPerusahaan, DbType.String);
            dp.Add("@Penghasilan", siswalulus.Penghasilan, DbType.Decimal);

            var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
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
        public SiswaLulusModel? Get(int SiswaId)
        {
            const string sql = @"
            SELECT
            SiswaId, LanjutDi, TglMulaiKerja,
            NamaPerusahaan, Penghasilan
            FROM
                    SiswaLulus
             WHERE
                    SiswaId = @SiswaId";
                

            var dp = new DynamicParameters();
            dp.Add("@SiswaId",SiswaId,DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QueryFirstOrDefault<SiswaLulusModel> (sql, dp);
        }

        public IEnumerable<SiswaLulusModel> ListData(int SiswaId)
        {
            const string sql = @"
            SELECT
            SiswaId, LanjutDi, TglMulaiKerja,
            NamaPerusahaan, Penghasilan
            FROM
            SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", SiswaId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<SiswaLulusModel>(sql, dp);
        }
    }
}
