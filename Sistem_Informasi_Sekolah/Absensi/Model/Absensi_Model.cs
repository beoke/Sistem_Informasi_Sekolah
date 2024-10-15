using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Absensi
{
    public class Absensi_Model
    {
        public string AbsensiId { get; set; }
        public int KelasId { get; set; }
        public string KelasName { get; set; }
        public int MapelId { get; set; }
        public string NamaMapel { get; set; }
        public int GuruId { get; set; }
        public string GuruName { get; set; }

        public int kehadiran {  get; set; }
        public string keterangan {  get; set; }

    }
}
