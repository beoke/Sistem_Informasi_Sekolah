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
                INSERT INTO Kelass(
                KelasNama, KelasTingkat, JurusanId)
                VALUES (
                @kelasnama, @kelastingkat, @jurusanid)";

            var dp = new DynamicParameters();
            dp.Add("KelasNama", kelas.KelasNama, DbType.String);
            dp.Add("KelasTingkat", kelas.KelasTingkat, DbType.Int16);
            dp.Add("JurusanId", kelas.JurusanId, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.Execute(sql, dp);
            return result;
        }
        public int Update(KelasModel kelas)
        {
            const string sql = @"
            UPDATE Kelass
            SET 
                KelasNama = @kelasnama,
                KelasTingkat = @kelastingkat,
                JurusanId = @jurusanId
            WHERE
                KelasId = @kelasid";

            var dp = new DynamicParameters();
            dp.Add("KelasId", kelas.KelasId, DbType.Int32);
            dp.Add("KelasNama", kelas.KelasNama, DbType.String);
            dp.Add("KelasTingkat", kelas.KelasTingkat, DbType.Int16);
            dp.Add("JurusanId", kelas.JurusanId, DbType.String);
            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.Execute(sql, dp);
            return result;
        }

        public int Delete(int id)
        {
            const string sql = @"
                   DELETE FROM 
                      Kelass
                    WHERE 
                       KelasID = @KelasiD ";
            var dp = new DynamicParameters();
            dp.Add(@"KelasID", id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Execute(sql, dp);
        }

        public KelasModel? GetData(int kelasId)
        {
            const string sql = @"
             SELECT 
                KelasID, KelasNama, KelasTingkat, JurusanId
             FROM
                Kelass
             WHERE 
                KelasID = @kelasiD";

            var dp = new DynamicParameters();
            dp.Add("@KelasID", kelasId, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QuerySingleOrDefault<KelasModel>(sql, dp);
        }

        public IEnumerable<KelasModel> Listjurusan()
        {
            const string sql = @"
                SELECT 
                    KelasID, KelasNama, KelasTingkat, JurusanId
                FROM
                    Kelass";
            var dp = new DynamicParameters();

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<KelasModel>(sql, dp);
        }
    }
}
