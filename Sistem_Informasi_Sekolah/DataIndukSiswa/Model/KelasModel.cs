using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.DataIndukSiswa.Model
{
    public class KelasModel
    {
        public int KelasId { get; set; }
        public string KelasNama { get; set; }
        public int KelasTingkat { get; set; }
        public int JurusanId { get; set; }
    }

}
