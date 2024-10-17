using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.Absensi.Model
{
    public class AbsensiDetailModel
    {
        public int AbsensiId { get; set; }
        public int NoUrut { get; set; }
        public int SiswaaId {  get; set; }
        public string SiswaaName { get; set; }
        public string StatusAbsen {  get; set; }
        public string Keterangan { get; set; }

    }
}
