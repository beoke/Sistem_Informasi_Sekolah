using Dapper;
using Sistem_Informasi_Sekolah.Absensi.Model;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Absensi.Dal
{
    public class AbsensiDal
    {
        public int Insert (AbsensiModel insert)
        {
            const string sql = @"
                INSERT INTO Absensi(
                    Tgl,Jam, KelasId, KelasName, MapelId, MapelName, GuruId, GuruName)
                OUTPUT inserted.AbsensiId
                VALUES (
                    @Tgl, @Jam, @KelasId, @KelasName, @MapelId, @MapelName, @GuruId, @GuruName)";

            var dp = new DynamicParameters();
            dp.Add(@"Tgl", insert.Tgl,DbType.DateTime);
            dp.Add("@Jam", insert.Jam, DbType.Time);
            dp.Add("@KelasId", insert.KelasId, DbType.Int32);
            dp.Add("@KelasName", insert.KelasName, DbType.String);
            dp.Add("@MapelId", insert.MapelId, DbType.Int32);
            dp.Add("@MapelName", insert.MapelName, DbType.String);
            dp.Add("@GuruId", insert.GuruId, DbType.Int32);
            dp.Add("@GuruName", insert.GuruName, DbType.String);

            using var con = new SqlConnection(ConnStringHelper.Get());
            var result = con.QuerySingle<int>(sql,dp);
            return result;

        }

        public void Update (AbsensiModel update)
        {
            const string sql = @"
        UPDATE Absensi 
        SET 
            Tgl = @Tgl,
            Jam = @Jam,
            KelasId = @KelasId,
            KelasName = @KelasName,
            MapelId = @MapelId,
            MapelName = @MapelName,
            GuruId = @GuruId,
            GuruName = @GuruName
        WHERE AbsensiId = @AbsensiId"; 

            var dp = new DynamicParameters();
            dp.Add("@Tgl", update.Tgl, DbType.DateTime);
            dp.Add("@Jam", update.Jam, DbType.Time);
            dp.Add("@KelasId", update.KelasId, DbType.Int32);
            dp.Add("@KelasName", update.KelasName, DbType.String);
            dp.Add("@MapelId", update.MapelId, DbType.Int32);
            dp.Add("@MapelName", update.MapelName, DbType.String);
            dp.Add("@GuruId", update.GuruId, DbType.Int32);
            dp.Add("@GuruName", update.GuruName, DbType.String);

            using var con = new SqlConnection(ConnStringHelper.Get());
            con.Execute(sql, dp); 
        }

        public AbsensiModel GetData(int absensiId)
        {
            const string sql = @"
        SELECT
            AbsensiId, Tgl, Jam, KelasId, KelasName, MapelId, MapelName, GuruId, GuruName
        FROM
            Absensi
        WHERE
            AbsensiId = @AbsensiId";

            var dp = new DynamicParameters();
            dp.Add("@AbsensiId", absensiId, DbType.Int32);
                    
            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QuerySingle<AbsensiModel>(sql, dp);
        }

    }
}
