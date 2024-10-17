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
        public int Insert(AbsensiDetailModel insert)
        {
            const string sql = @"
        INSERT INTO AbsensiDetail(
            AbsensiId, NoUrut, SiswaaId, SiswaaName, StatusAbsen, Keterangan)
        OUTPUT inserted.AbsensiId
        VALUES (
            @AbsensiId, @NoUrut, @SiswaaId, @SiswaaName, @StatusAbsen, @Keterangan)";

        var dp = new DynamicParameters();
        dp.Add("@AbsensiId", insert.AbsensiId, DbType.Int32);
        dp.Add("@NoUrut", insert.NoUrut, DbType.Int32);
        dp.Add("@SiswaaId", insert.SiswaaId, DbType.Int32); 
        dp.Add("@SiswaaName", insert.SiswaaName, DbType.String); 
        dp.Add("@StatusAbsen", insert.StatusAbsen, DbType.String); 
        dp.Add("@Keterangan", insert.Keterangan, DbType.String); 

        using var con = new SqlConnection(ConnStringHelper.Get());
        var result = con.QuerySingle<int>(sql, dp); 
        return result; 
        }

        public void Update(AbsensiDetailModel update)
        {
            const string sql = @"
        UPDATE AbsensiDetail
        SET 
            NoUrut = @NoUrut, 
            SiswaaId = @SiswaaId, 
            SiswaaName = @SiswaaName, 
            StatusAbsen = @StatusAbsen, 
            Keterangan = @Keterangan
        WHERE 
            AbsensiId = @AbsensiId";

        var dp = new DynamicParameters();
        dp.Add("@AbsensiId", update.AbsensiId, DbType.Int32);
        dp.Add("@NoUrut", update.NoUrut, DbType.Int32);
        dp.Add("@SiswaaId", update.SiswaaId, DbType.Int32);
        dp.Add("@SiswaaName", update.SiswaaName, DbType.String);
        dp.Add("@StatusAbsen", update.StatusAbsen, DbType.String);
        dp.Add("@Keterangan", update.Keterangan, DbType.String);

        using var con = new SqlConnection(ConnStringHelper.Get());
        con.Execute(sql, dp);
        }

        public AbsensiDetailModel GetData(int absenid)
        {
            const string sql = @"
        SELECT
            AbsensiId, NoUrut, SiswaaId, SiswaaName, StatusAbsen, Keterangan
        FROM
            AbsensiDetail
        WHERE
            AbsensiId = @AbsensiId";

        var dp = new DynamicParameters();
        dp.Add("@AbsensiId", absenid, DbType.Int32);

        using var conn = new SqlConnection(ConnStringHelper.Get());
        return conn.QuerySingle<AbsensiDetailModel>(sql, dp);
        }

    }
}
