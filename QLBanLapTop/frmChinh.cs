using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanLapTop
{
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            frmHangHoa frm = new frmHangHoa();
            frm.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmNhapHang frm = new frmNhapHang();
            frm.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }

        private void btnBaoHanh_Click(object sender, EventArgs e)
        {
            frmBaoHanh frm = new frmBaoHanh();
            frm.Show();
        }

        private void btnLichSuMuaHang_Click(object sender, EventArgs e)
        {
            frmLichSuMuaHang frm = new frmLichSuMuaHang();
            frm.Show();
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
            frmMuaHang frm = new frmMuaHang();
            frm.Show();
        }
    }
}
