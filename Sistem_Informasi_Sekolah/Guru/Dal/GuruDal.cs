using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.Guru.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Guru.Dal
{
    public class GuruDal
    {
        public int Insert (GuruModel model)
        {
            const string sql = @"
            INSERT INTO  Guru(
                GuruName, TglLahir, JurusanPendidikan, TIngkatPendidikan, TahunLulus, InstansiPendidikan, KotaPendidikan)
            OUTPUT inserted.GuruID
            VALUES 
                (@GuruName, @TglLahir, @JurusanPendidikan, @TIngkatPendidikan, @TahunLulus, @InstansiPendidikan, @KotaPendidikan)";
            var dp = new DynamicParameters();
            dp.Add("@GuruName", model.GuruName,DbType.String);
            dp.Add("@TglLahir", model.TglLahir,DbType.DateTime);
            dp.Add("@JurusanPendidikan", model.JurusanPendidikan,DbType.String);
            dp.Add("@TingkatPendidikan", model.TingkatPendidikan, DbType.String);
            dp.Add("@TahunLulus", model.TahunLulus,DbType.String);
            dp.Add("@InstansiPendidikan", model.InstansiPendidikan,DbType.String);
            dp.Add("@KotaPendidikan", model.KotaPendidikan,DbType.String);

            using var con = new SqlConnection(ConnStringHelper.Get());
            var result  = con.QuerySingle<int>(sql, dp);
            return result;
        }

        public void Update(GuruModel model)
        {
            const string sql = @"
                UPDATE Guru
            SET
                GuruName = @GuruName,
                TglLahir  = @TglLahir,
                JurusanPendidikan = @JurusanPendidikan,
                TingkatPendidikan  = @TingkatPendidikan,
                TahunLulus = @TahunLulus,
                InstansiPendidikan = @InstansiPendidikan,
                KotaPendidikan = @KotaPendidikan
            WHERE
                GuruId = @GuruId";
            var dp = new DynamicParameters();
            dp.Add(@"GuruId", model.GuruId,DbType.Int64);
            dp.Add("@GuruName", model.GuruName, DbType.String);
            dp.Add("@TglLahir", model.TglLahir, DbType.DateTime);
            dp.Add("@JurusanPendidikan", model.JurusanPendidikan, DbType.String);
            dp.Add("@TingkatPendidikan", model.TingkatPendidikan, DbType.String);
            dp.Add("@TahunLulus", model.TahunLulus, DbType.String);
            dp.Add("@InstansiPendidikan", model.InstansiPendidikan, DbType.String);
            dp.Add("@KotaPendidikan", model.KotaPendidikan, DbType.String);
               
            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }
        public void Delete(int guruId)
        {
            const string sql = @"
            DELETE FROM Guru
            WHERE GuruId = @GuruId";

            var dp = new DynamicParameters();
            dp.Add("@GuruId", guruId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public GuruModel GetData(int guruId)
        {
            const string sql = @"
            SELECT
                GuruId, GuruName, TglLahir, JurusanPendidikan, TingkatPendidikan, TahunLulus, InstansiPendidikan, KotaPendidikan
            FROM
                Guru
            WHERE
                GuruId = @GuruId";

            var dp = new DynamicParameters();
            dp.Add("@GuruId", guruId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QuerySingle<GuruModel>(sql, dp);
        }

        public IEnumerable<GuruModel> ListData()
        {
            const string sql = @"
            SELECT
                GuruId, GuruName, TglLahir, JurusanPendidikan, TingkatPendidikan, TahunLulus, InstansiPendidikan, KotaPendidikan
            FROM
                Guru ";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<GuruModel>(sql);
        }
    }
}
