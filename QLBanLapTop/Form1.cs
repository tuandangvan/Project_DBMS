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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmNhanVien kh = new frmNhanVien();
            kh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmNhaSanXuat kh = new frmNhaSanXuat();
            kh.Show();
        }
    }
}
