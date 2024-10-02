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

namespace Sistem_Informasi_Sekolah.Jadwal_Pelajaran.Dal
{
    public class PetaWaktuDal
    {
        public int Insert (PetaWaktuModel timeslot)
        {
            const string sql = @"
            INSERT INTO TimeslotMapel(
                KelasId, Hari, JenisJadwal, JamMulai, Jam selesai 
                MapelId, GuruId, Keterangan)
            OUTPUT INSERTED.TimeslotMapel
            VALUES( 
                @KelasId, @Hari, @JenisMapel, @JamMulai, @JamSelesai,
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

        }
    }
}
