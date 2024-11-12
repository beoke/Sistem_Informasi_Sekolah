using Dapper;
using Sistem_Informasi_Sekolah.Absensi.Model;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Absensi.Dal
{
    public class AbsensiDetailDal
    {
        public IEnumerable<AbsensiDetailModel> ListData(int AbsensiId)
        {
            const string sql = @"
                    SELECT 
                        aa.AbsensiId, aa.NoUrut, aa.SiswaId,
                        bb.NamaLengkap AS SiswaName, aa.StatusAbsen, aa.Keterangan
                    FROM 
                        AbsensiDetail aa
                        LEFT JOIN siswa bb ON aa.SiswaId = bb.SiswaId
                    WHERE aa.AbsensiId = @AbsensiId";

            using var Conn = new SqlConnection(ConnStringHelper.Get());
            return Conn.Query<AbsensiDetailModel>(sql, new { AbsensiId = AbsensiId });
        }

        public int Insert(AbsensiDetailModel insert)
        {
            const string sql = @"
        INSERT INTO AbsensiDetail(
            AbsensiId, NoUrut, SiswaaId, SiswaaName, StatusAbsen, Keterangan)
        VALUES (
            @AbsensiId, @NoUrut, @SiswaaId, @SiswaaName, @StatusAbsen, @Keterangan)";

        var dp = new DynamicParameters();
        dp.Add("@AbsensiId", insert.AbsensiId, DbType.Int32);
        dp.Add("@NoUrut", insert.NoUrut, DbType.Int32);
        dp.Add("@SiswaId", insert.SiswaaId, DbType.Int32); 
        dp.Add("@StatusAbsen", insert.StatusAbsen, DbType.String); 
        dp.Add("@Keterangan", insert.Keterangan, DbType.String); 

        using var con = new SqlConnection(ConnStringHelper.Get());
        var result = con.QuerySingle<int>(sql, dp); 
        return result; 
        }
        public void Delete(int AbsensiId)
        {
            const string sql = "DELETE FROM AbsensiDetail WHERE AbsensiId = @AbsensiId";

            using var Conn = new SqlConnection(ConnStringHelper.Get());
            Conn.Execute(sql, new { AbsensiId = AbsensiId });
        }

    }
}
