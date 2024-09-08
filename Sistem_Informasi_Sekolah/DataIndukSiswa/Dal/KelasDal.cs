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
    public class KelasDal
    {

        /* public List<KelasModel> ListKelas()
         {
             List<KelasModel> data = new List<KelasModel>();

             using (SqlConnection connection = new SqlConnection("your_connection_string_here"))
             {
                 string query = @"
                     SELECT K.KelasId, K.KelasNama, K.KelasTingkat, J.JurusanNama
                     FROM Kelas K
                     JOIN Jurusan J ON K.JurusanId = J.JurusanId;";

                 SqlCommand command = new SqlCommand(query, connection);

                 try
                 {
                     connection.Open();
                     SqlDataReader reader = command.ExecuteReader();

                     while (reader.Read())
                     {
                         KelasModel kdm = new KelasModel
                         {
                             KelasId = (int)reader["KelasId"],
                             KelasNama = reader["KelasNama"].ToString(),
                             KelasTingkat = (int)reader["KelasTingkat"],
                             JurusanNama = reader["JurusanNama"].ToString()
                         };
                         data.Add(kdm);
                     }

                     reader.Close();
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);
                 }
             }

             return data;
         }*/
        public int Insert(KelasModel kelas)
        {
            const string sql = @"
                INSERT INTO Kelas(
                KelasNama, KelasTingkat, JurusanNama)
                VALUES (
                @kelasnama, @kelastingkat, @jurusannama)";

            var dp = new DynamicParameters();
            dp.Add("KelasNama", kelas.KelasNama, DbType.String);
            dp.Add("KelasTingkat", kelas.KelasTingkat, DbType.Int16);
            dp.Add("JurusanNama", kelas.JurusanNama, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.Execute(sql, dp);
            return result;
        }
        public int Update(KelasModel kelas)
        {
            const string sql = @"
            UPDATE Kelas
            SET 
                KelasNama = @kelasnama,
                KelasTingkat = @kelastingkat,
                JurusanNama = @jurusannama
            WHERE
                KelasId = @kelasid";

            var dp = new DynamicParameters();
            dp.Add("KelasId", kelas.KelasId, DbType.Int32);
            dp.Add("KelasNama", kelas.KelasNama, DbType.String);
            dp.Add("KelasTingkat", kelas.KelasTingkat, DbType.Int16);
            dp.Add("JurusanNama", kelas.JurusanNama, DbType.String);
            using var conn = new SqlConnection(ConnStringHelper.Get());
            var result = conn.Execute(sql, dp);
            return result;
        }

        public int Delete(int id)
        {
            const string sql = @"
                   DELETE FROM 
                      Kelas
                    WHERE 
                       KelasId = @Kelasid ";
            var dp = new DynamicParameters();
            dp.Add(@"KelasId", id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Execute(sql, dp);
        }

        public KelasModel GetData(int kelasId)
        {
            const string sql = @"
             SELECT 
                KelasId, KelasNama, KelasTingkat, JurusanNama
             FROM
                Kelas
             WHERE 
                KelasId = @kelasid";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QuerySingleOrDefault<KelasModel>(sql, new { KelasId = kelasId });
        }

        public IEnumerable<KelasModel> Listjurusan()
        {
            const string sql = @"
                SELECT 
                    KelasId, KelasNama, KelasTingkat, JurusanNama
                FROM
                    Kelas";
            var dp = new DynamicParameters();

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<KelasModel>(sql, dp);
        }
    }
}
