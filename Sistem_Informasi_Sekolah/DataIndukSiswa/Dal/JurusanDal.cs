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
    public class JurusanDal
    {
        public int Insert(JurusanModel jurusan)
        {
            const string sql = @"
            INSERT INTO Jurusan(
            NamaJurusan)
            OUTPUT INTERESTED Id
            VALUES (
            @NamaJurusan)";

            var dp = new DynamicParameters();
            dp.Add("NamaJurusan", jurusan.NamaJurusan, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.QuerySingle<int>(sql,dp);
            return result;
        }

        public void Update(JurusanModel jurusan)
        {
            const string sql = @"UPDATE Jurusan SET
                    NamaJurusan=@NamaJurusan
                    WHERE 
                    Id = @Id ";
            var dp = new DynamicParameters();
            dp.Add("@Id", jurusan.Id,DbType.Int16);
            dp.Add("@NamaJurusan", jurusan,DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql,dp);
        }

        public void Delete (int id)
        {
            const string sql = @"
                   DELETE FROM 
                      Jurusan
                    WHERE 
                       Id = @id ";
            var dp = new DynamicParameters();
            dp.Add(@"Id", id,DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql,dp);
        }

        public JurusanModel? GetData(int Id)
        {
            const string sql= @"
                SELECT 
                    Id, NamaJurusan
                FROM
                    Jurusan
                WHERE
                    Id = @id";

            var dp = new DynamicParameters();
            dp.Add("@Id", Id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QueryFirstOrDefault<JurusanModel>(sql, dp);
        }
        public IEnumerable<JurusanModel> Listjurusan()
        {
            const string sql = @"
                SELECT 
                    Id, NamaJurusan
                FROM
                    Jurusan";
            var dp = new DynamicParameters();

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<JurusanModel>(sql, dp);
        }
    }
}
