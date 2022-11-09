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
using System.IO;
using System.Data.SqlClient;

namespace QLBanLapTop
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }
        private void BindGridCart()
        {
            Connection db = new Connection();
            db.conn.Open();
            string sql = "Select stt, TenSP, MaMay, GiaBan from DonHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            dgvGioHang.DataSource = dt;
        }

        private void getSoDTKH()
        {
            DataTable dt = new DataTable();
            Connection db = new Connection();
            db.conn.Open();
            SqlCommand sqlCmd = new SqlCommand("Select top 1 SoDTKH from DonHang", db.conn);

            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

            sqlDa.Fill(dt);
            db.conn.Close();
            if (dt.Rows.Count != 0)
            {
                lbSDT.Text = dt.Rows[0][0].ToString();
            }
        }

        private void getTenKH()
        {
            DataTable dt = new DataTable();
            Connection db = new Connection();
            db.conn.Open();
            SqlCommand sqlCmd = new SqlCommand("Select top 1 TenKH from DonHang, KhachHang Where DonHang.SoDTKH = KhachHang.SoDTKH", db.conn);

            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

            sqlDa.Fill(dt);
            if (dt.Rows.Count != 0)
                lbName.Text = dt.Rows[0][0].ToString();
        }

        private double TongBill(String SoDTKH)
        {
            Connection db = new Connection();
            string sql = "select dbo.TONG_BILL(@SoDTKH)";

            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.Parameters.AddWithValue("@SoDTKH", SoDTKH);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lbTotal.Text = dt.Rows[0][0].ToString().Replace("E", "0000").Replace("+07", "").Replace(",", "") + "    VNĐ"; //ở đây giá trị trả về chỉ là 1 chuỗi
            return 0;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult tl = MessageBox.Show("Bạn có muốn thanh toán hóa đơn không", "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    Connection db = new Connection();
                    db.conn.Open();


                    for (int i = 0; i < dgvGioHang.RowCount; i++)
                    {
                        string sql_del_KH = "Delete Khohang where MaMay = '" + dgvGioHang.Rows[i].Cells[2].Value.ToString() + "'";
                        SqlCommand cmd_del_KH = new SqlCommand(sql_del_KH, db.conn);
                        cmd_del_KH.ExecuteNonQuery();
                    }
                    string sql_del_DH = "Delete From Donhang";
                    SqlCommand cmd_del_DH = new SqlCommand(sql_del_DH, db.conn);
                    cmd_del_DH.ExecuteNonQuery();

                    db.conn.Close();
                    MessageBox.Show("Thanh toán thành công", "Thông báo",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    BindGridCart();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thanh toán!! Vui lòng kiểm tra lại", "Thông báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }
        private void ShowLbDate()
        {
            lbDate.Text = DateTime.Now.ToString();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            BindGridCart();
            ShowLbDate();
            getSoDTKH();
            getTenKH();
            TongBill(lbSDT.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMuaHang frmMuaHang = new frmMuaHang();
            frmMuaHang.Show();
            this.Hide();
        }
    }
}
