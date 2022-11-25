using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanLapTop.UI_Layer;

namespace QLBanLapTop
{
    public partial class frmManager : Form
    {
        public frmManager()
        {
            InitializeComponent();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnKhachHang.BackColor;
            KhachHangUControl KH = new KhachHangUControl();
            panel.Controls.Clear();
            panel.Controls.Add(KH);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnNhanVien.BackColor;
            NhanVienUControl NV = new NhanVienUControl();
            panel.Controls.Clear();
            panel.Controls.Add(NV);
        }

        private void btnHangSX_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnHangSX.BackColor;
            HangSXUControl HSX = new HangSXUControl();
            panel.Controls.Clear();
            panel.Controls.Add(HSX);
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            lblTen.Text = "Tên: " + frmLogin.nameEmp;
            lblQuyen.Text = "Quyền: " + frmLogin.idRole;
            lblNgay.Text = "Ngày: " + DateTime.Now.Date.ToString("dd/MM/yyyy");
            
            timer.Enabled = true;
            timer.Start();
            lblNgayGio.Text = DateTime.Now.ToLongTimeString();

            if (!TaiKhoanUControl.Permission())
            {
                btnSanPham.Visible = false;
                btnNhanVien.Visible = false;
                btnTaiKhoan.Visible = false;
                btnKhoHang.Visible = false;
                btnHangSX.Visible = false;


            }
       
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnSanPham.BackColor;
            SanPhamUContrl SP = new SanPhamUContrl();
            panel.Controls.Clear();
            panel.Controls.Add(SP);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnTaiKhoan.BackColor;
            TaiKhoanUControl TK = new TaiKhoanUControl();
            panel.Controls.Clear();
            panel.Controls.Add(TK);
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnKhoHang.BackColor;
            KhoHangUControl KH = new KhoHangUControl();
            panel.Controls.Clear();
            panel.Controls.Add(KH);
        }

        private void btnBaoHanh_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnBaoHanh.BackColor;
            BaoHanhUControl BH = new BaoHanhUControl();
            panel.Controls.Clear();
            panel.Controls.Add(BH);
        }

        private void btnLichSuMuaHang_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnLichSuMuaHang.BackColor;
            LichSuMuaHangUControl LSMH = new LichSuMuaHangUControl();
            panel.Controls.Clear();
            panel.Controls.Add(LSMH);
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnMuaHang.BackColor;
            MuaHangUControl MH = new MuaHangUControl();
            panel.Controls.Clear();
            panel.Controls.Add(MH);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            panel.BackColor = btnThongKe.BackColor;
            ThongKeUControl TK = new ThongKeUControl();
            panel.Controls.Clear();
            panel.Controls.Add(TK);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            lblNgayGio.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (r == DialogResult.Cancel)
                return;
            else
            {
                frmLogin frmLogin = new frmLogin();
                this.Hide();
                frmLogin.Show();

            }
        }

        
    }
}
