using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Absensi.Model
{
    public class AbsensiModel
    {
        public int AbsensiId { get; set; }
        public DateTime Tgl {  get; set; }
        public TimeSpan Jam { get; set; }

        public int KelasId {  get; set; }
        public string KelasName { get; set; }

        public int MapelId { get; set; }
        public string MapelName { get; set; }

        public int GuruId { get; set; }
        public string GuruName { get; set; }

        List<AbsensiDetailModel> ListAbsensiDetail { get; set; }
    }
}
