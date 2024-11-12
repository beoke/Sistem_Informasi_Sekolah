﻿using Dapper;
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
        public int Insert(AbsensiModel absen)
        {
            const string sql = @"
                    INSERT INTO Absensi
                        (Tanggal, Jam, 
                        KelasId, MapelId, GuruId)

                        OUTPUT INSERTED.AbsensiId
                    VALUES
                        (@Tanggal, @Jam, 
                        @KelasId, @MapelId, @GuruId)";

            var Dp = new DynamicParameters();
            Dp.Add("@Tgl", absen.Tgl.Date.ToString("dd-MM-yyyy"), DbType.DateTime);
            Dp.Add("@Jam", absen.Jam, DbType.String);
            Dp.Add("@KelasId", absen.KelasId, DbType.Int32);
            Dp.Add("@MapelId", absen.MapelId, DbType.Int32);
            Dp.Add("@GuruId", absen.GuruId, DbType.Int32);

            using var Conn = new SqlConnection(ConnStringHelper.Get());
            return Conn.QuerySingle<int>(sql, Dp);
        }


        public int GetAbsensiId(AbsensiModel absen)
        {
            const string sql = @"
        SELECT 
            AbsensiId
        FROM 
            Absensi
        WHERE 
            KelasId = @KelasId AND Tanggal = @Tanggal AND
            Jam = @Jam AND MapelId = @MapelId AND GuruId = @GuruId";

            var Dp = new DynamicParameters();
            Dp.Add("@KelasId", absen.KelasId, DbType.Int32);
            Dp.Add("@Tgl", absen.Tgl.Date.ToString("dd-MM-yyyy"), DbType.DateTime);
            Dp.Add("@Jam", absen.Jam, DbType.String);
            Dp.Add("@MapelId", absen.MapelId, DbType.Int32);
            Dp.Add("@GuruId", absen.GuruId, DbType.Int32);

            using var Conn = new SqlConnection(ConnStringHelper.Get());
            return Conn.QueryFirstOrDefault<int>(sql, Dp);
        }
    }
}
