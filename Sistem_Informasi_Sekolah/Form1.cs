namespace Sistem_Informasi_Sekolah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_NextSlide2_Click(object sender, EventArgs e)
        {
            // Jika tab yang sedang aktif bukan yang terakhir
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                // Pindah ke tab berikutnya
                tabControl1.SelectedIndex++;
            }
        }

        private void btn_BackforData_Click(object sender, EventArgs e)
        {
            // Jika tab yang sedang aktif bukan yang pertama
            if (tabControl1.SelectedIndex > 0)
            {
                // Pindah ke tab sebelumnya
                tabControl1.SelectedIndex--;
            }
        }

        private void btn_NextSlide3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 2)
            {
                tabControl1.SelectedIndex++;
            }
        }

        private void btn_BackSlide1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 2)
            {
                tabControl1.SelectedIndex -= 1;
            }
        }

        private void btn_NextSlide4_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabIndex < tabControl1.TabCount - 3)
            {
                tabControl1.SelectedIndex++;
            }
        }
        private void btn_BackSlide2_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabIndex < tabControl1.TabCount - 3)
            {
                tabControl1.SelectedIndex -= 2;
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
