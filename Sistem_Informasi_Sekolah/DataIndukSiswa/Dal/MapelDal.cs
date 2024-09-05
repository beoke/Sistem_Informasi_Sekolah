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
    public class MapelDal
    {
        public int Insert(MapelModel mapel)
        {
            const string sql = @"
            INSERT INTO mapel(
            NamaMapel)
            OUTPUT INTERESTED MapelId
            VALUES (
            @NamaMapel)";

            var dp = new DynamicParameters();
            dp.Add("NamaMapel", mapel.NamaMapel, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.QuerySingle<int>(sql, dp);
            return result;
        }

        public void Update(MapelModel mapel)
        {
            const string sql = @"UPDATE Mapel SET
                    NamaMapel=@NamaMapel
                    WHERE 
                    MapelId = @MapelId ";
            var dp = new DynamicParameters();
            dp.Add("@MapelId", mapel.MapelId, DbType.Int16);
            dp.Add("@NamaMapel", mapel.NamaMapel, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }


        public void Delete(int id)
        {
            const string sql = @"
                   DELETE FROM 
                      Mapel
                    WHERE 
                       MapelId = @MapelId ";
            var dp = new DynamicParameters();
            dp.Add(@"MapelId", id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public MapelModel? GetData(int Id)
        {
            const string sql = @"
                SELECT 
                   MapelId, NamaMapel
                FROM
                    Mapel
                WHERE
                    MapelId = @MapelId";

            var dp = new DynamicParameters();
            dp.Add("@MapelId", Id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QueryFirstOrDefault<MapelModel>(sql, dp);
        }

        public IEnumerable<MapelModel> ListMapel()
        {
            const string sql = @"
                SELECT 
                    MapelId, NamaMapel
                FROM
                    Mapel";
            var dp = new DynamicParameters();

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<MapelModel>(sql, dp);
        }
    }
}
