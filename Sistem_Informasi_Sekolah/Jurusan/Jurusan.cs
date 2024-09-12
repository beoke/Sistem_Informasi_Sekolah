using Sistem_Informasi_Sekolah.DataIndukSiswa.Helpers;
using Sistem_Informasi_Sekolah.DataIndukSiswa.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Informasi_Sekolah
{
    public partial class Jurusan : Form
    {
        private readonly JurusanDal _jurusanDal;
        public Jurusan()
        {
            InitializeComponent();

            _jurusanDal = new JurusanDal();

            InitMaskeditTextBox();
            RegisterControlEvent();
            RefreshListData();
        }

        private void InitMaskeditTextBox()
        {
            CodeText.Mask = "???";
        }

        private void RegisterControlEvent()
        {
            btn_new.Click += Btn_new_Click; ;
            btn_SaveJurusan.Click += Btn_SaveJurusan_Click; ;
            btn_DeleteJurusan.Click += Btn_DeleteJurusan_Click; ;

            GridJurusan.RowEnter += GridJurusan_RowEnter; ;
        }

        private void GridJurusan_RowEnter(object? sender, DataGridViewCellEventArgs e)
        {
            var jurusanId = GridJurusan.Rows[e.RowIndex].Cells[0].Value.ToString();
            var jurusanName = GridJurusan.Rows[e.RowIndex].Cells[1].Value.ToString();
            var code = GridJurusan.Rows[e.RowIndex].Cells[2].Value.ToString();
            tx_JurusanID.Text = jurusanId;
            tx_JurusanNama.Text = jurusanName;
            CodeText.Text = code;
        }

        private void Btn_DeleteJurusan_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn_SaveJurusan_Click(object? sender, EventArgs e)
        {
            var jurusanId = SaveJurusan();
            tx_JurusanID.Text = jurusanId.ToString();
            RefreshListData();
            ClearInput();
        }

        private int SaveJurusan()
        {
            var jurusanId = tx_JurusanID.Text == string.Empty ? 0 : 
                int.Parse(tx_JurusanID.Text);
            var jurusan = new JurusanModel
            {
                JurusanId = jurusanId,
                JurusanName = tx_JurusanNama.Text,
                Code = CodeText.Text
            };

            if (jurusan.JurusanId == 0)
                jurusanId = _jurusanDal.Insert(jurusan);
            else
                _jurusanDal.Update(jurusan);

            return jurusanId;
        }
        private void Btn_new_Click(object? sender, EventArgs e)
        {
            ClearInput();
        }


        private void ClearInput()
        {
            tx_JurusanID.Clear();
            tx_JurusanNama.Clear();
            CodeText.Clear();
        }

        private void RefreshListData()
        {
            var listData = _jurusanDal.Listjurusan() ?? new List<JurusanModel>();
            var dataSource1 = listData
                .Select(x => new JurusaDto
                {
                    JID = x.JurusanId.ToString(),
                    Nama = $"{x.Code} - {x.JurusanName}",
                }).ToList();
            GridJurusan.DataSource = listData;
            GridJurusan.AutoResizeColumns();
            //ListDataGrid.Refresh();
        }
        /* #region PENGATURAN GRID
         private void controlGrid()
         {
             GridJurusan.DataSource = _jurusanDal.Listjurusan();
             adjustGridColumnSize();
             GridJurusan.CellDoubleClick += GridJurusan_CellDoubleClick;
         }

         private void GridJurusan_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
         {
             var siswajurusan = GridJurusan.CurrentRow.Cells["JurusanId"].Value.ToString();
             if (siswajurusan is null)
                 return;
             var Id = Convert.ToInt32(siswajurusan);
             GetJurusan(Id);
         }

         private void GetJurusan(int Id)
         {
             tx_JurusanID.Text = Id.ToString();
             var jurusann = _jurusanDal.GetData(Id);
             if(jurusann is null)
             {
                 MessageBox.Show("Data not found");
                 return;
             }
             tx_JurusanNama.Text = jurusann.JurusanName;
         }

         private void adjustGridColumnSize()
         {
             GridJurusan.Columns["JurusanId"].Width = 50;
             GridJurusan.Columns["NamaJurusan"].Width = 150; 
             GridJurusan.Columns["JurusanId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             GridJurusan.Columns["NamaJurusan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
         }
         #endregion*/
    }
}
    public class JurusaDto
    {
        public string JID { get; set; }
        public string Nama { get; set; }
    }
