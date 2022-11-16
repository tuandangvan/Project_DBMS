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
                parameters = new List<SqlParameter>();

                parameter = new SqlParameter("@MaHang", txtMaHang.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@NoiSX", txtNoiSX.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@TenHang", txtTenHang.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@Website", txtWebsite.Text);
                parameters.Add(parameter);

                db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                LoadData();

            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text.Trim() != "" && txtTenHang.Text.Trim() != "" && txtNoiSX.Text.Trim() != "" && txtWebsite.Text.Trim() != "")
            {
                strSQL = "proc_updateHangSX";
                parameters = new List<SqlParameter>();

                parameter = new SqlParameter("@MaHang", txtMaHang.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@NoiSX", txtNoiSX.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@TenHang", txtTenHang.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@Website", txtWebsite.Text);
                parameters.Add(parameter);

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
                daHSX = new SqlDataAdapter("Select * from HangSX where MaHang = '" + txtSearch.Text + "'" + " or TenHang = '" + txtSearch.Text + "'" + " or NoiSX = '" + txtSearch.Text + "'" + " or Website = '" + txtSearch.Text + "'", db.conn);
                dtHSX = new DataTable();
                daHSX.Fill(dtHSX);
                // Đưa dữ liệu lên DataGridView
                dgvHSX.DataSource = dtHSX;
            }
        }

        private void frmNhaSanXuat_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvHSX_Click(object sender, EventArgs e)
        {
            int r = dgvHSX.CurrentCell.RowIndex;

            if (r >= 0)
            {
                /*int r = dgvSanPham.CurrentCell.RowIndex;*/
                this.txtMaHang.Text = dgvHSX.Rows[r].Cells[0].Value.ToString();
                this.txtTenHang.Text = dgvHSX.Rows[r].Cells[2].Value.ToString();
                this.txtNoiSX.Text = dgvHSX.Rows[r].Cells[1].Value.ToString();
                this.txtWebsite.Text = dgvHSX.Rows[r].Cells[3].Value.ToString();
            }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn xóa Hãng Sản Xuất" + " " + txtMaHang.Text, "Thông báo",
                                 MessageBoxButtons.YesNo);
            if (check == DialogResult.Yes)
            {
                strSQL = "proc_DeleteHangSX";
                parameters = new List<SqlParameter>();

                parameter = new SqlParameter("@MaHang", txtMaHang.Text);
                parameters.Add(parameter);

                db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                LoadData();
            }
        }

        private void btnCLear_Click(object sender, EventArgs e)
        {
            this.txtMaHang.Text = "";
            this.txtTenHang.Text = "";
            this.txtNoiSX.Text = "";
            this.txtWebsite.Text = "";
        }
    }
}
