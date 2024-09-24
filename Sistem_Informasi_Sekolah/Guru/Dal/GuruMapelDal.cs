using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.Guru.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Guru.Dal
{
    public class GuruMapelDal
    {
        public void Insert(IEnumerable<GuruMapelModel> listMapel)
        {
            const string sql = @"
                INSERT INTO GuruMapel
                    (GuruId, MapelId)
                VALUES
                    (@GuruId, @MapelId)";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            foreach (var item in listMapel)
            {
                var dp = new DynamicParameters();
                dp.Add("@GuruId", item.GuruId);
                dp.Add("@MapelId", item.MapelId);

                conn.Execute(sql, dp);
            }
        }

        public void Delete(int guruId)
        {
            const string sql = @"
                DELETE FROM GuruMapel
                WHERE GuruId = @GuruId";

            var dp = new DynamicParameters();
            dp.Add("@GuruId", guruId);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public IEnumerable<GuruMapelModel> ListData(int guruId)
        {
            const string sql = @"
                SELECT 
                    aa.GuruId, aa.MapelId,
                    ISNULL(bb.NamaMapel, '') AS NamaMapel
                FROM 
                    GuruMapel aa
                    LEFT JOIN Mapel bb ON aa.MapelId = bb.MapelId
                WHERE
                    GuruId = @GuruId";

            var dp = new DynamicParameters();
            dp.Add("@GuruId", guruId);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<GuruMapelModel>(sql, dp).ToList();
        }
    }
}
