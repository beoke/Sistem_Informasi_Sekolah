using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah
{
    public class KelasDal
    {


        public int Insert(KelasModel kelas)
        {
            const string sql = @"
                INSERT INTO Kelas(
                    KelasName, Tingkat, JurusanId, Flag)
                OUTPUT INSERTED.KelasId
                VALUES (
                    @KelasName, @Tingkat, @JurusanId, @Flag)";

            var dp = new DynamicParameters();
            dp.Add("KelasName", kelas.KelasName, DbType.String);
            dp.Add("Tingkat", kelas.Tingkat, DbType.String);
            dp.Add("JurusanId", kelas.JurusanId, DbType.String);
            dp.Add("Flag", kelas.Flag, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.Execute(sql, dp);
            return result;
        }
        public void Update(KelasModel kelas)
        {
            const string sql = @"
                UPDATE Kelas
                SET KelasName = @KelasName, 
                    Tingkat = @Tingkat,
                    JurusanId = @JurusanId,
                    Flag = @Flag
                WHERE KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("KelasId", kelas.KelasId, DbType.Int32);
            dp.Add("KelasName", kelas.KelasName, DbType.String);
            dp.Add("Tingkat", kelas.Tingkat, DbType.Int16);
            dp.Add("JurusanId", kelas.JurusanId, DbType.String);
            dp.Add("Flag", kelas.Flag, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
           
        }

        public void Delete(int id)
        {
            const string sql = @"
                   DELETE FROM 
                      Kelas
                    WHERE 
                       KelasId = @Kelasid ";
            var dp = new DynamicParameters();
            dp.Add(@"KelasId", id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public KelasModel? GetData(int kelasId)
        {
            const string sql = @"
            SELECT 
                aa.KelasId, aa.KelasName, aa.Tingkat, aa.JurusanId, aa.Flag,
                ISNULL(bb.JurusanName, '') AS JurusanName,
                ISNULL(bb.Code, '') AS Code
            FROM 
                Kelas aa
                LEFT JOIN Jurusan bb ON aa.JurusanId = bb.JurusanId
            WHERE 
                aa.KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasID", kelasId, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QuerySingleOrDefault<KelasModel>(sql, dp);
        }

        public IEnumerable<KelasModel> ListData()
        {
            const string sql = @"
            SELECT 
                aa.KelasId, aa.KelasName, aa.Tingkat, aa.JurusanId, aa.Flag,
                ISNULL(bb.JurusanName, '') AS JurusanName,
                ISNULL(bb.Code, '') AS Code
            FROM 
                Kelas aa
                LEFT JOIN Jurusan bb ON aa.JurusanId = bb.JurusanId";
 
            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<KelasModel>(sql);
        }
    }
}
