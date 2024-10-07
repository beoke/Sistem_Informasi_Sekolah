using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.Jadwal_Pelajaran.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sistem_Informasi_Sekolah.Jadwal_Pelajaran.Dal
{
    public class PetaWaktuDal
    {
        public int Insert (PetaWaktuModel timeslot)
        {
            const string sql = @"
            INSERT INTO TimeslotMapel(
                KelasId, Hari, JenisJadwal, JamMulai, JamSelesai, 
                MapelId, GuruId, Keterangan)
            OUTPUT INSERTED.TimeslotMapelId
            VALUES( 
                @KelasId, @Hari, @JenisJadwal, @JamMulai, @JamSelesai,
                @MapelId, @GuruId, @Keterangan)";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", timeslot.KelasId, DbType.Int16);
            dp.Add("@Hari",timeslot.Hari, DbType.String);
            dp.Add("@JenisJadwal", timeslot.JenisJadwal, DbType.String);
            dp.Add("@JamMulai", timeslot.JamMulai, DbType.String);
            dp.Add("@JamSelesai", timeslot.JamSelesai, DbType.String);
            dp.Add("@MapelId", timeslot.MapelId, DbType.Int16);
            dp.Add("@GuruId", timeslot.GuruId, DbType.Int16);
            dp.Add("@Keterangan", timeslot.Keterangan, DbType.String);

            using var con = new SqlConnection(ConnStringHelper.Get());
            var result = con.QuerySingle<int>(sql, dp);
            return result;
        }

        public void Update (PetaWaktuModel timeslot)
        {
            const string sql = @" 
            UPDATE TImeslotMapel
            SET 
               Kelasid = @KelasId,
               Hari = @Hari,
               JenisJadwal = @JenisJadwal,
               JamMulai = @JamMulai,
               JamSelesai = @JamSelesai,
               MapelId = @MapelId,
               GuruId = @GuruId,
               Keterangan = @Keterangan
            WHERE TimeslotMapelId = @TimeslotMapelId";

            var dp = new DynamicParameters();
            dp.Add("@TimeslotMapelId", timeslot.TimeslotMapelId, DbType.Int32);
            dp.Add("@KelasId", timeslot.KelasId, DbType.Int16);
            dp.Add("@Hari",timeslot.Hari,DbType.String);
            dp.Add("@JenisJadwal", timeslot.JenisJadwal,DbType.String);
            dp.Add("@JamMulai", timeslot.JamMulai,DbType.String);
            dp.Add("@JamSelesai", timeslot.JamSelesai, DbType.String);
            dp.Add("@MapelId", timeslot.MapelId, DbType.Int16);
            dp.Add("@GuruId", timeslot.GuruId, DbType.Int16);
            dp.Add("@Keterangan", timeslot.Keterangan, DbType.String);


            using var con = new SqlConnection (ConnStringHelper.Get());
            con.Execute(sql, dp);
        }

        public void Delete (int id)
        {
            const string sql = @"
            DELETE FROM TimeslotMapel
            WHERE TimeslotMapelId = @TimeslotMapelId";

            var dp = new DynamicParameters();
            dp.Add("@TimeslotMapelId", id, DbType.Int16);

            using var con = new SqlConnection(ConnStringHelper.Get());
            con.Execute(sql, dp);
        }

        public PetaWaktuModel GetData(int Id)
        {
            const string sql = @"
            SELECT 
                aa.TimeslotMapelId, aa.KelasId, aa.Hari, aa.JenisJadwal, 
                aa.JamMulai, aa.JamSelesai,
                aa.MapelId, aa.GuruId, aa.Keterangan,
                ISNULL(bb.KelasName, '') AS KelasName,
                ISNULL(cc.NamaMapel, '') AS NamaMapel,  
                ISNULL(dd.GuruName, '') AS GuruName
            FROM TimeslotMapel aa
                LEFT JOIN Kelas bb ON aa.KelasId = bb.KelasId
                LEFT JOIN Mapel cc ON aa.MapelId = cc.MapelId       
                LEFT JOIN Guru dd ON aa.GuruId = dd.GuruId
            WHERE 
                aa.TimeslotMapelId = @TimeslotMapelId";

            var dp = new DynamicParameters();
            dp.Add("@TimeslotMapelId", Id, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.QuerySingle<PetaWaktuModel>(sql, dp);
        }

        public IEnumerable<PetaWaktuModel> ListData(int KelasID)
        {
            const string sql = @" 
          SELECT 
            aa.TimeslotMapelId, aa.KelasId, aa.Hari, aa.JenisJadwal, 
            aa.JamMulai, aa.JamSelesai,
            aa.MapelId, aa.GuruId, aa.Keterangan,
            ISNULL(b.KelasName, '') AS KelasName,
            ISNULL(c.NamaMapel, '') AS NamaMapel,  
            ISNULL(d.GuruName, '') AS GuruName
          FROM TimeslotMapel aa
            LEFT JOIN Kelas b ON aa.KelasId = b.KelasId
            LEFT JOIN Mapel c ON aa.MapelId = c.MapelId       
            LEFT JOIN Guru d ON aa.GuruId = d.GuruId
          WHERE 
            aa.KelasId = @KelasId";

            var dp = new DynamicParameters();
            dp.Add("@KelasId", KelasID, DbType.Int16);

            using var conn = new SqlConnection(ConnStringHelper.Get());
            return conn.Query<PetaWaktuModel>(sql,dp);
        }
    }
}
