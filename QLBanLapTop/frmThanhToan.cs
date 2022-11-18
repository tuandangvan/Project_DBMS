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
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            BindGridCart();
            ShowLbDate();
            getSoDTKH();
            getTenKH();
            //getMaNV();
            lbMaNV.Text = frmLogin.idEmp;
            lbNameNV.Text = frmLogin.nameEmp;
            TongBill(lbSDT.Text);
        }

        private void ShowLbDate()
        {
            lbDate.Text = DateTime.Now.ToString();
        }
        private void BindGridCart()
        {
            Connection db = new Connection();
            db.conn.Open();
            string sql = "select *from view_DonHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            dgvGioHang.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvGioHang.Rows[i].Cells[0].Value = (i + 1);
            }
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
            Connection db = new Connection();
            try
            {
                DialogResult tl = MessageBox.Show("Bạn có muốn thanh toán hóa đơn không", "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    


                    for (int i = 0; i < dgvGioHang.RowCount; i++)
                    {
                        try
                        {
                            string sql_addLSMH = "pro_insLichSuMuaHang";
                            List<SqlParameter> parameters = new List<SqlParameter>();

                            parameters.Add(new SqlParameter("@MaMay", dgvGioHang.Rows[i].Cells[2].Value.ToString()));

                            db.ExecuteProcedure(sql_addLSMH, CommandType.StoredProcedure, parameters);
                            db.conn.Open();
                            string sql_delMaMay = "proc_delMaMayKhoHang";
                            List<SqlParameter> param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@MaMay", dgvGioHang.Rows[i].Cells[2].Value.ToString()));
                            db.ExecuteProcedure(sql_delMaMay, CommandType.StoredProcedure, param);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không làm đc r", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }

                    db.conn.Open();
                    string sql_del_DH = "Delete From Donhang";
                    SqlCommand cmd_del_DH = new SqlCommand(sql_del_DH, db.conn);
                    cmd_del_DH.ExecuteNonQuery();

                    MessageBox.Show("Thanh toán thành công", "Thông báo",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    BindGridCart();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.conn.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
