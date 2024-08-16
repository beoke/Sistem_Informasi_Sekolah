using Dapper;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah
{
    public class DbDal
    {
        private const string connstr = "Server=(local);Database=SekolahKu;Trusted_Connection=True;TrustServerCertificate=True";
        
        public IEnumerable<SiswaModel> ListSiswa()
        {
            string sql = @"SELECT * FROM Siswa";
            using var koneksi = new SqlConnection(connstr);
            var siswa = koneksi.Query<SiswaModel>(sql);
            return siswa;
        }
        public IEnumerable<SiswaModel> ListSiswaRiwayat()
        {
            string sql = @"SELECT * FROM SiswaRiwayat";
            using var koneksi = new SqlConnection(connstr);
            var siswa = koneksi.Query<SiswaModel>(sql);
            return siswa;
        }

        public int TemplateIUD(string sql, object parameter)
        {
            using var koneksi = new SqlConnection(connstr);
            var data = koneksi.Execute(sql, parameter);
            return data;
        }
    }
}
