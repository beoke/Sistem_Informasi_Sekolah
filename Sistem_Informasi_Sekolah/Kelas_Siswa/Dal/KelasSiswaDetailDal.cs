using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.Kelas_Siswa.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Kelas_Siswa.Dal
{
    public class KelasSiswaDetailDal
    {
        public int Insert(KelasSiswaDetailModel model)
        {
            const string sql = @"
            INSERT INTO Kelas(
                KelasName, TahunAjaran, WaliKelasId, WaliKelasName)
            OUTPUT inserted.KelasId
            VALUES (
                @KelasName, @TahunAjaran, @WaliKelasId, @WaliKelasName)";

            var dp = new DynamicParameters();
            dp.Add("@KelasName", model.KelasName, DbType.String);
            dp.Add("@TahunAjaran", model.TahunAjaran, DbType.String);
            dp.Add("@WaliKelasId", model.WaliKelasId, DbType.Int32);
            dp.Add("@WaliKelasName", model.WaliKelasName, DbType.String);

            using var con = new SqlConnection(ConnStringHelper.Get());
            var result = con.QuerySingle<int>(sql, dp);
            return result;
        }
        public void Update(KelasSiswaDetailModel model)
        {
            const string sql = @"
            UPDATE Kelas
            SET 
                KelasName = @KelasName,
                TahunAjaran = @TahunAjaran,
                WaliKelasId = @WaliKelasId,
                WaliKelasName = @WaliKelasName
            WHERE 
                KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", model.KelasId, DbType.Int32);
            dp.Add("@KelasName", model.KelasName, DbType.String);
            dp.Add("@TahunAjaran", model.TahunAjaran, DbType.String);
            dp.Add("@WaliKelasId", model.WaliKelasId, DbType.Int32);
            dp.Add("@WaliKelasName", model.WaliKelasName, DbType.String);

            using var con = new SqlConnection(ConnStringHelper.Get());
            con.Execute(sql, dp);
        }
        public KelasModel GetData(int kelasId)
        {
            const string sql = @"
            SELECT
                KelasId, KelasName, TahunAjaran, WaliKelasId, WaliKelasName
            FROM
                Kelas
            WHERE
                KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", kelasId, DbType.Int32);

            using var con = new SqlConnection(ConnStringHelper.Get());
            return con.QuerySingle<KelasModel>(sql, dp);
        }

    }
}
