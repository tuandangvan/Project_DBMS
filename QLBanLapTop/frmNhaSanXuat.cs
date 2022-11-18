using QLBanLapTop.DBPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanLapTop
{
    public partial class frmNhaSanXuat : Form
    {
        String nameView = "view_HangSanXuat";
        string strSQL = "";
        SqlParameter parameter;

        List<SqlParameter> parameters;
        private Connection db = new Connection();
        public frmNhaSanXuat()
        {
            InitializeComponent();
        }
        SqlDataAdapter daHSX = null;
        DataTable dtHSX = null;

        void LoadData()
        {

            if (db.conn.State == ConnectionState.Open)
                db.conn.Close();
            // Khởi động connection
            // Vận chuyển dữ liệu vào DataTable dtKhachHang
            daHSX = new SqlDataAdapter("SELECT * FROM HangSX", db.conn);
            dtHSX = new DataTable();
            daHSX.Fill(dtHSX);
            dgvHSX.DataSource = dtHSX;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text.Trim() != "" && txtTenHang.Text.Trim() != "" && txtNoiSX.Text.Trim() != "" && txtWebsite.Text.Trim() != "")
            {
                strSQL = "proc_addHangSX";
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@MaHang", txtMaHang.Text));
                parameters.Add(new SqlParameter("@NoiSX", txtNoiSX.Text));
                parameters.Add(new SqlParameter("@TenHang", txtTenHang.Text));
                parameters.Add(new SqlParameter("@Website", txtWebsite.Text));

                db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                LoadData();
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }

        private void frmNhaSanXuat_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvHSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHSX.CurrentCell.RowIndex;

            if (r >= 0)
            {
                /*int r = dgvSanPham.CurrentCell.RowIndex;*/
                this.txtMaHang.Text = dgvHSX.Rows[r].Cells[0].Value.ToString().TrimEnd();
                this.txtTenHang.Text = dgvHSX.Rows[r].Cells[2].Value.ToString().TrimEnd();
                this.txtNoiSX.Text = dgvHSX.Rows[r].Cells[1].Value.ToString().TrimEnd();
                this.txtWebsite.Text = dgvHSX.Rows[r].Cells[3].Value.ToString().TrimEnd();

            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text.Trim() != "" && txtTenHang.Text.Trim() != "" && txtNoiSX.Text.Trim() != "" && txtWebsite.Text.Trim() != "")
            {
                DialogResult check = MessageBox.Show("Bạn có muốn Sửa Hãng Sản Xuất" + " " + txtMaHang.Text, "Thông báo",
                                 MessageBoxButtons.YesNo);
                if (check == DialogResult.No)
                    return;
                strSQL = "proc_updateHangSX";
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@MaHang", txtMaHang.Text));
                parameters.Add(new SqlParameter("@NoiSX", txtNoiSX.Text));
                parameters.Add(new SqlParameter("@TenHang", txtTenHang.Text));
                parameters.Add(new SqlParameter("@Website", txtWebsite.Text));

                db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                LoadData();


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
                daHSX = new SqlDataAdapter("DECLARE @txt nvarchar(50) = N'" + txtSearch.Text + "';Select * from HangSX where MaHang = @txt or TenHang = @txt or NoiSX = @txt or Website = @txt", db.conn);
                dtHSX = new DataTable();
                daHSX.Fill(dtHSX);
                // Đưa dữ liệu lên DataGridView
                dgvHSX.DataSource = dtHSX;
            }
            else
                LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtMaHang.Text = "";
            this.txtTenHang.Text = "";
            this.txtNoiSX.Text = "";
            this.txtWebsite.Text = "";
        }


    }
}
