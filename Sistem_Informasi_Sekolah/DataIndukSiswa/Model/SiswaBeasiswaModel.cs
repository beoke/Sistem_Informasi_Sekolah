﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Informasi_Sekolah.DataIndukSiswa.Model
{
    public class SiswaBeasiswaModel
    {
        public int SiswaId { get; set; }
        public int NoUrut {  get; set; }
        public string Tahun { get; set; }
        public string Kelas { get; set; }
        public string AsalBeasiswa { get; set; }
    }
}
