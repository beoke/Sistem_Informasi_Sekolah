using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah
{
    public class JurusanDal
    {
        public int Insert(JurusanModel jurusan)
        {
            const string sql = @"
                INSERT INTO Jurusan(
                NamaJurusan)
            
                VALUES (
                @NamaJurusan)";

            var dp = new DynamicParameters();
            dp.Add("NamaJurusan", jurusan.NamaJurusan, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.Execute(sql, dp);
            return result;
        }

        public void Update(JurusanModel jurusan)
        {
            const string sql = @"UPDATE Jurusan SET
                        NamaJurusan=@NamaJurusan
                        WHERE 
                        JurusanId = @JurusanId ";
            var dp = new DynamicParameters();
            dp.Add("@JurusanId", jurusan.JurusanId, DbType.Int16);
            dp.Add("@NamaJurusan", jurusan.NamaJurusan, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public int Delete(int id)
        {
            const string sql = @"
                       DELETE FROM 
                          Jurusan
                        WHERE 
                           JurusanId = @jurusanid ";
            var dp = new DynamicParameters();
            dp.Add(@"Id", id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Execute(sql, dp);
        }

        public JurusanModel? GetData(int Id)
        {
            const string sql = @"
                    SELECT 
                        JurusanId, NamaJurusan
                    FROM
                        Jurusan
                    WHERE
                        JurusanId = @jurusanid";

            var dp = new DynamicParameters();
            dp.Add("@JurusanId", Id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QueryFirstOrDefault<JurusanModel>(sql, dp);
        }
        public IEnumerable<JurusanModel> Listjurusan()
        {
            const string sql = @"
                    SELECT 
                        JurusanId, NamaJurusan
                    FROM
                        Jurusan";
            var dp = new DynamicParameters();

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<JurusanModel>(sql, dp);
        }
    }
}
