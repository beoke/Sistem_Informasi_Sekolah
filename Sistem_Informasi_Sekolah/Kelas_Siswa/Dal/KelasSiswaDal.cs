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
                KelasId, TahunAjaran, WaliKelasId)
            OUTPUT inserted.SiswaId
            VALUES (
                @KelasId, @TahunAjaran, @WaliKelasId)";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", model.KelasId, DbType.Int32);
            dp.Add("@TahunAjaran", model.TahunAjaran, DbType.String);
            dp.Add("@WaliKelasId", model.WaliKelasId, DbType.Int32);

            using var con = new SqlConnection(ConnStringHelper.Get());
            var result = con.QuerySingle<int>(sql, dp);
            return result;
        }

        public void Update(KelasSiswaModel model)
        {
            const string sql = @"
            UPDATE KelasSiswa
            SET 
                TahunAjaran = @TahunAjaran, 
                WaliKelasId = @WaliKelasId
            WHERE 
                KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", model.KelasId, DbType.Int32);
            dp.Add("@TahunAjaran", model.TahunAjaran, DbType.String);
            dp.Add("@WaliKelasId", model.WaliKelasId, DbType.Int32);

            using var con = new SqlConnection(ConnStringHelper.Get());
            con.Execute(sql, dp);
        }

        public void Delete(int kelasid)
        {
            const string sql = @"
             DELETE FROM
                KelasSiswa
             WHERE 
                KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", kelasid, DbType.String);

            using var con = new SqlConnection(ConnStringHelper.Get());
            var result = con.Execute(sql, dp);
        }

        public KelasSiswaModel GetData(int kelasId)
        {
            const string sql = @"
            SELECT
                aa.KelasId, aa.TahunAjaran, aa.WaliKelasId,
                ISNULL(bb.KelasName, '') KelasName,
                ISNULL(cc.GuruName, '') WaliKelasName
            FROM
                KelasSiswa aa
                LEFT JOIN Kelas bb ON aa.KelasId = bb.KelasId
                LEFT JOIN Guru cc ON aa.WaliKelasId = cc.GuruId
            WHERE
                aa.KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", kelasId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.Query<KelasSiswaModel>(sql, dp).FirstOrDefault();
            return result;
        }

        public IEnumerable<KelasSiswaModel> ListData()
        {
            const string sql = @"
            SELECT
                aa.KelasId, aa.TahunAjaran, aa.WaliKelasId,
                ISNULL(bb.KelasName, '') KelasId,
                ISNULL(cc.GuruName, '') WaliKelasName
            FROM
                KelasSiswa aa
                LEFT JOIN Kelas bb ON aa.KelasId = bb.KelasId
                LEFT JOIN Guru cc ON aa.WaliKelasId = cc.GuruId";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.Query<KelasSiswaModel>(sql);
            return result;
        }

    }
}
