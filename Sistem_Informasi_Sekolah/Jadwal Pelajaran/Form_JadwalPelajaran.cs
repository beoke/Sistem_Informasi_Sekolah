using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah.Jadwal_Pelajaran
{
    public partial class Form_JadwalPelajaran : Form
    {
        public Form_JadwalPelajaran()
        {
            InitializeComponent();

            InitMaskEdit();
        }
        private void InitMaskEdit()
        {
            JamMulai_mask.Text = "00:00";
            JamSelesai_mask.Text = "00:00";
            Mapel_combo.SelectedIndex = 0;
            Guru_combo.SelectedIndex = 0;
            times
        }

    }
}
