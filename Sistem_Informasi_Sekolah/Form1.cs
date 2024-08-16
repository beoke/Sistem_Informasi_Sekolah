namespace Sistem_Informasi_Sekolah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initCombo();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        public void initCombo()
        {
            //Agama
            List<string> Agama = new List<string>() { "ISLAM", "KRISTEN", "KATOLIK", "HINDU", "BUDHA", "KONGHUCU" };
            cb_AgamaAyah.DataSource = new List<string>(Agama);
            cb_AgamaIbu.DataSource = new List<string>(Agama);
            cb_AgamaWali.DataSource = new List<string>(Agama);
            cb_Agama.DataSource = new List<string>(Agama);

            //Yatim
            List<string> Yatim = new List<string>() { "Lengkap", "Yatim", "Piatu", "Yatim-Piatu" };
            cb_Yatim.DataSource = Yatim;

            //Status Tinggal
            cb_statustinggal.Items.Add("DENGAN ORTU");
            cb_statustinggal.Items.Add("DENGAN SAUDARA");
            cb_statustinggal.Items.Add("DI ASRAMA");
            cb_statustinggal.SelectedIndex = 0;


        }
    }
}
