using QLBanLapTop.DBPlayer;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace QLBanLapTop
{
    public partial class frmKhachHang : Form
    {
        string strSQL = "";
        SqlParameter parameter;

        List<SqlParameter> parameters;
        private Connection db = new Connection();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        SqlDataAdapter daQLKH = null;
        DataTable dtQLKH = null;



        void LoadData()
        {

            if (db.conn.State == ConnectionState.Open)
                db.conn.Close();
            // Khởi động connection
            // Vận chuyển dữ liệu vào DataTable dtKhachHang
            daQLKH = new SqlDataAdapter("SELECT * FROM KhachHang", db.conn);
            dtQLKH = new DataTable();
            daQLKH.Fill(dtQLKH);
            // Đưa dữ liệu lên DataGridView
            dgvKhachHang.DataSource = dtQLKH;

        }
        private void FromKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim() != "" && txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "")
            {
                if (db.Check(txtSDT.Text, "KhachHang", "SoDTKH") == false)
                {
                    strSQL = "proc_addKhachHang";
                    parameters = new List<SqlParameter>();

                    parameter = new SqlParameter("@SoDTKH", txtSDT.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@TenKH", txtHoTen.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@DiaChi", txtDiaChi.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@LoaiKH", 1);
                    parameters.Add(parameter);
                    db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                    MessageBox.Show("Thêm khách hàng thành công");
                    LoadData();
                }
                else
                    MessageBox.Show("Khách hàng đã tồn tại");
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKhachHang.CurrentCell.RowIndex;


            if (r >= 0)
            {
                /*int r = dgvSanPham.CurrentCell.RowIndex;*/
                this.txtSDT.Text = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                this.txtHoTen.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
                this.txtDiaChi.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa khách hàng" + " " + txtSDT.Text, "Thông báo",
                                 MessageBoxButtons.YesNo);
            if (check == DialogResult.Yes)
            {
                if (db.Check(txtSDT.Text, "KhachHang", "SoDTKH") == true)
                {
                    strSQL = "proc_DeleteKhachHang";
                    parameters = new List<SqlParameter>();

                    parameter = new SqlParameter("@SoDTKH", txtSDT.Text);
                    parameters.Add(parameter);

                    //String sqlString = "exec proc_updateAccount @idAccount = " + idAccount + ", @nameAccount = '" + nameAccount + "', @password = '" + password + "', @typeOfAcc = " + typeOfAcc + ", @idEmployee = " + idEmployee;
                    db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                    LoadData();
                    MessageBox.Show("Xóa thành công");
                }
                else
                    MessageBox.Show("Khách hàng không tồn tại");


            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int r = dgvKhachHang.CurrentCell.RowIndex;

            if (txtSDT.Text.Trim() != "" && txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "")
            {
                DialogResult check = MessageBox.Show("Bạn có muốn Khách hàng" + " " + txtSDT.Text, "Thông báo",
                                 MessageBoxButtons.YesNo);
                if (check == DialogResult.No)
                    return;
                if (db.Check(txtSDT.Text, "KhachHang", "SoDTKH") == true)
                {

                    strSQL = "proc_updateKhachHang";
                    parameters = new List<SqlParameter>();

                    parameter = new SqlParameter("@SoDTKH", txtSDT.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@TenKH", txtHoTen.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@DiaChi", txtDiaChi.Text);
                    parameters.Add(parameter);

                    db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                    MessageBox.Show("Sửa đổi thông tin khách hàng thành công");
                    LoadData();
                }
                else
                    MessageBox.Show("Khách hàng không tồn tại");

            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();
                daQLKH = new SqlDataAdapter("DECLARE @txt nvarchar(50) = N'" + txtSearch.Text + "';Select * from KhachHang where SoDTKH =@txt or TenKH = @txt or DiaChi = @txt", db.conn);
                dtQLKH = new DataTable();
                daQLKH.Fill(dtQLKH);
                // Đưa dữ liệu lên DataGridView
                dgvKhachHang.DataSource = dtQLKH;
            }
            else
                LoadData();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtSDT.Text = "";
            this.txtHoTen.Text = "";
            this.txtDiaChi.Text = "";
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}