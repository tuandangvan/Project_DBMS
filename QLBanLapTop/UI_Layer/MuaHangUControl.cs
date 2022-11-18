using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLBanLapTop.DBPlayer;


namespace QLBanLapTop
{
    public partial class MuaHangUControl : UserControl
    {

        public MuaHangUControl()
        {
            InitializeComponent();
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
            Connection db = new Connection();
            db.conn.Open();
            string sql = "select * from view_SanPhamMuaHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            dgvDanhSachSP.DataSource = dt;
        }


        private void dgvDanhSachSP_CellClick(object sender, DataGridViewCellEventArgs e)
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
                        if (cbMaMay.Text != "")
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
                            cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = frmLogin.idEmp;

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            resetOrder();
                            BindGridProduct();
                        }
                        else if (cbMaMay.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập mã máy", "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }


                    }
                    catch (Exception xe)
                    {
                        MessageBox.Show(xe.Message);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Chưa tồn tại khách hàng!! Hãy thêm khách hàng", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            frmThanhToan frmThanhToan = new frmThanhToan();
            frmThanhToan.Show();
            this.Hide();
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToan frmThanhToan = new frmThanhToan();
                frmThanhToan.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Gio hàng trống!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmMuaHang_Load(object sender, EventArgs e)
        {
            BindGridProduct();
        }
    }
}
