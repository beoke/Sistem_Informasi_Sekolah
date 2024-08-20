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
    public class SiswaPrestasiDal
    {
        public void Insert(SiswaPrestasiModel siswaPrestasi)
        {
            const string sql = @"
                INSERT INTO SiswaPrestasi(
                    SiswaId, Kesenian, Olahraga, Organisasi, 
                    Hobi, CitaCita)
                VALUES (
                    @SiswaId, @Kesenian, @Olahraga, @Organisasi, 
                    @Hobi, @CitaCita)";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaPrestasi.SiswaId, DbType.Int32);
            dp.Add("@Kesenian", siswaPrestasi.Kesenian, DbType.String);
            dp.Add("@Olahraga", siswaPrestasi.Olahraga, DbType.String);
            dp.Add("@Organisasi", siswaPrestasi.Organisasi, DbType.String);
            dp.Add("@Hobi", siswaPrestasi.Hobi, DbType.String);
            dp.Add("@CitaCita", siswaPrestasi.CitaCita, DbType.String);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public void Update(SiswaPrestasiModel siswaPrestasi)
        {
            const string sql = @"
                UPDATE SiswaPrestasi
                SET
                    SiswaId = @SiswaId,
                    Kesenian = @Kesenian,
                    Olahraga = @Olahraga,
                    Organisasi = @Organisasi,
                    Hobi = @Hobi,
                    CitaCita = @CitaCita
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaPrestasi.SiswaId, DbType.Int32);
            dp.Add("@Kesenian", siswaPrestasi.Kesenian, DbType.String);
            dp.Add("@Olahraga", siswaPrestasi.Olahraga, DbType.String);
            dp.Add("@Organisasi", siswaPrestasi.Organisasi, DbType.String);
            dp.Add("@Hobi", siswaPrestasi.Hobi, DbType.String);
            dp.Add("@CitaCita", siswaPrestasi.CitaCita, DbType.String); ;

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public void Delete(int siswaId)
        {
            const string sql = @"
                DELETE FROM SiswaPrestasi
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public SiswaPrestasiModel? GetData(int siswaId)
        {
            const string sql = @"
                SELECT
                    SiswaId, Kesenian, Olahraga, Organisasi, 
                    Hobi, CitaCita
                FROM
                    SiswaPrestasi
                WHERE
                    SiswaId = @SiswaId";

            var dp = new DynamicParameters();
            dp.Add("@SiswaId", siswaId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QueryFirstOrDefault<SiswaPrestasiModel>(sql, dp);
        }

        public IEnumerable<SiswaPrestasiModel> ListData()
        {
            const string sql = @"
                SELECT
                    SiswaId, Kesenian, Olahraga, Organisasi, 
                    Hobi, CitaCita
                FROM
                    SiswaPrestasi ";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<SiswaPrestasiModel>(sql);
        }
    }
}
