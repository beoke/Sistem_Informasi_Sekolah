using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.Kelas_Siswa.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Kelas_Siswa.Dal
{
    public class KelasSiswaDal
    {
        public int Insert (KelasSiswaModel model)
        {
            const string sql = @"
            INSERT INTO KelasSiswa(
                KelasId, SiswaId, SiswaName)
            OUTPUT inserted.SiswaId
            VALUES (
                @KelasId, @SiswaId, @SiswaName)";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", model.KelasId, DbType.Int32);
            dp.Add("@SiswaId", model.SiswaId, DbType.Int32);
            dp.Add("@SiswaName", model.SiswaName, DbType.String);

            using var con = new SqlConnection(ConnStringHelper.Get());
            var result = con.QuerySingle<int>(sql, dp);
            return result;
        }

        public void Update(KelasSiswaModel model)
        {
            const string sql = @"
            UPDATE KelasSiswa
            SET 
                KelasId = @KelasId, 
                SiswaName = @SiswaName
            WHERE 
                SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", model.KelasId, DbType.Int32);
            dp.Add("@SiswaName", model.SiswaName, DbType.String);
            dp.Add("@SiswaId", model.SiswaId, DbType.Int32);

            using var con = new SqlConnection(ConnStringHelper.Get());
            con.Execute(sql, dp);
        }

        public KelasSiswaModel GetData(int siswaId)
        {
            const string sql = @"
            SELECT
                KelasId, SiswaId, SiswaName
            FROM
                KelasSiswa
            WHERE
                SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QuerySingle<KelasSiswaModel>(sql, dp);
        }

    }
}
