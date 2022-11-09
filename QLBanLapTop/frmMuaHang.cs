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
using System.IO;

namespace QLBanLapTop
{
    public partial class frmMuaHang : Form
    {
        public frmMuaHang()
        {
            InitializeComponent();
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            frmThanhToan frmThanhToan = new frmThanhToan();
            frmThanhToan.Show();
            this.Hide();
        }

        public void resetOrder()
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtGiaBan.ResetText();
            cbMaMay.ResetText();
            txtSoDTKH.ResetText();
        }

        private void BindGridProduct()
        {
            //dgvDanhSachSP.Rows.Clear();

            Connection db = new Connection();
            db.conn.Open();
            string sql = "select MaSP, MaHang, TenSP, GiaNhap, GiaBan, soLuong from SanPham";
            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            dgvDanhSachSP.DataSource = dt;
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            try
            {
                if (txtSoDTKH.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại khách hàng", "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {

                        db.conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        //Khai báo tên proc
                        cmd.CommandText = "proc_addNewGioHang";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = db.conn;

                        //Khai báo các thông số truyền vào
                        cmd.Parameters.Add("@SoDTKH", SqlDbType.Char).Value = txtSoDTKH.Text;
                        cmd.Parameters.Add("@TenSP", SqlDbType.Char).Value = txtTenSP.Text;
                        cmd.Parameters.Add("@MaSP", SqlDbType.Char).Value = txtMaSP.Text;
                        cmd.Parameters.Add("@MaMay", SqlDbType.Char).Value = cbMaMay.Text;
                        cmd.Parameters.Add("@GiaBan", SqlDbType.Real).Value = txtGiaBan.Text;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thêm sản phẩm thành công", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        resetOrder();
                        BindGridProduct();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Chưa tồn tại khách hàng!! Hãy thêm khách hàng", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Thêm sản phẩm không thành công. Vui lòng kiểm tra lại thông tin sản phẩm", "Thông báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            frmThanhToan frmThanhToan = new frmThanhToan();
            frmThanhToan.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập mã sản phẩm" || txtSearch.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm", "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {

            }
        }

        private void frmMuaHang_Load(object sender, EventArgs e)
        {
            BindGridProduct();
        }

        private void BindCbBoxMaMay(String maSP)
        {
            cbMaMay.ResetText();
            Connection db = new Connection();
            db.conn.Open();
            string sql = "select MaMay from KhoHang where KhoHang.MaSP = '" +
                maSP.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, db.conn);//SQL là câu truy vấn bảng trong cơ sở dữ liệu, cn là connection đến cơ sở dữ liệu
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbMaMay.DataSource = dt;
            cbMaMay.DisplayMember = "MaMay";//Word là tên trường bạn muốn hiển thị trong combobox
        }

        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // -1 Là dòng title của dgv
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvDanhSachSP.Rows[e.RowIndex];
                txtMaSP.Text = Convert.ToString(row.Cells[0].Value);
                txtTenSP.Text = Convert.ToString(row.Cells[2].Value);
                txtGiaBan.Text = Convert.ToString(row.Cells[4].Value);
                BindCbBoxMaMay(txtMaSP.Text);
            }
        }
    }
}
