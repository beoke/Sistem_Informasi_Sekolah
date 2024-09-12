using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah
{
    public class KelasModel
    {
        public int KelasId { get; set; }
        public string KelasName { get; set; }
        public int Tingkat { get; set; }
        public int Flag { get; set; }

        public int JurusanId { get; set; }
        public string JurusanName { get;set; }
        public string Code { get; set; }
    }

}
