using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers
{
    public class ConnStringHelper
    {
        public static string Get()
          => $"Server=(local);Database=SekolahKu;Trusted_Connection=True;TrustServerCertificate=True";
    }
}
