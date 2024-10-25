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
        public void Insert(KelasSiswaDetailModel detil)
        {
            const string sql = @"
            INSERT INTO KelasSiswaDetail(KelasId, SiswaId)
            VALUES(@KelasId, @SiswaId)";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", detil.KelasId, DbType.Int32);
            dp.Add("@SiswaId", detil.SiswaId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public void Delete(int kelasId)
        {
            const string sql = @"
            DELETE FROM KelasSiswaDetail
            WHERE KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", kelasId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }

        public void Delete(int kelasId, int siswaId)
        {
            const string sql = @"
            DELETE FROM 
                KelasSiswaDetil
            WHERE 
                KelasId = @KelasId
                AND SiswaId = @SiswaId ";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", kelasId, DbType.Int32);
            dp.Add("@SiswaId", siswaId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            conn.Execute(sql, dp);
        }


        public IEnumerable<KelasSiswaDetailModel> ListData(int kelasId)
        {
            const string sql = @"
            SELECT 
                aa.KelasId, aa.SiswaId, 
                ISNULL(bb.NamaLengkap, '') SiswaName
            FROM 
                KelasSiswaDetil aa
                LEFT JOIN Siswa bb ON aa.SiswaId = bb.SiswaId
            WHERE 
                aa.KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", kelasId, DbType.Int32);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<KelasSiswaDetailModel>(sql, dp);
        }

        public IEnumerable<KelasSiswaDetailModel> ListData()
        {
            const string sql = @"
            SELECT 
                aa.KelasId, aa.SiswaId, 
                ISNULL(bb.NamaLengkap, '') SiswaName
            FROM 
                KelasSiswaDetail aa
                LEFT JOIN Siswa bb ON aa.SiswaId = bb.SiswaId ";

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<KelasSiswaDetailModel>(sql);
        }
    }
}
