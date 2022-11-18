using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QLBanLapTop.DBPlayer;
using System.Data.SqlClient;

namespace QLBanLapTop
{
    public partial class LichSuMuaHangUControl : UserControl
    {
        public LichSuMuaHangUControl()
        {
            InitializeComponent();
        }

        bool NhapHang;

        SqlDataAdapter daLichSuMuaHang;
        DataTable dtLichSuMuaHang;
        private Connection db = new Connection();

        private void LoadData()
        {
            try
            {
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();

                daLichSuMuaHang = new SqlDataAdapter("Select * from LichSuMuaHang", db.conn);
                dtLichSuMuaHang = new DataTable();
                daLichSuMuaHang.Fill(dtLichSuMuaHang);

                dgvLichSuMuaHang.DataSource = dtLichSuMuaHang;
                db.conn.Close();
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu !!!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnHienThiDayDu_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnBestSeller_Click(object sender, EventArgs e)
        {
            this.txtBestSeller.Enabled = true;
            SqlCommand cmd = new SqlCommand("SELECT * from dbo.fnc_BestSeller()", db.conn);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.txtBestSeller.Text = dt.Rows[0][0].ToString();
        }

        private void btnTopSaler_Click(object sender, EventArgs e)
        {
            this.panel2.Enabled = true;
            SqlCommand cmd = new SqlCommand("SELECT * from dbo.fnc_TopSaler()", db.conn);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.txtTenNV.Text = dt.Rows[0][0].ToString();
                this.txtLuong.Text = dt.Rows[0][1].ToString();
                this.txtChucVu.Text = dt.Rows[0][2].ToString();
                this.txtSDT.Text = dt.Rows[0][3].ToString();
                this.txtKinhNghiem.Text = dt.Rows[0][4].ToString();
                this.txtCalam.Text = dt.Rows[0][5].ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtLichSuMuaHang.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = db.conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "proc_TimKiemSDTKH";
            command.Parameters.Add("@SDTKH", SqlDbType.Char).Value = txtSDTKH.Text;
            daLichSuMuaHang.SelectCommand = command;
            daLichSuMuaHang.Fill(dtLichSuMuaHang);
            dgvLichSuMuaHang.DataSource = dtLichSuMuaHang;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc muốn THOÁT ????",
             "Thông báo",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
                Application.Exit();
        }

        private void frmLichSuMuaHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
