using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming
{
    public partial class MainFormQuanLy : Form
    {
        public MainFormQuanLy()
        {
            InitializeComponent();
        }

        /*private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien_ThemXoaSua qlnv = new QuanLyNhanVien_ThemXoaSua();
            qlnv.Show();
        }*/

        private void kiểmTraGiờLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KiemTraGioLam ktra = new KiemTraGioLam();
            ktra.Show();
        }

        private void tínhTiềnCuốiNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TinhTienCuoiNgay tt = new TinhTienCuoiNgay();
            tt.Show();
        }

        //private void quanLyNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    QuanLyNhanVien_ThemXoaSua qlnv = new QuanLyNhanVien_ThemXoaSua();
        //    qlnv.Show();
        //}

        private void quanLyNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            QuanLyNhanVien_ThemXoaSua qlnv = new QuanLyNhanVien_ThemXoaSua();
            qlnv.Show();
        }
    }
}
