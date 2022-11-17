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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }

        bool NhapHang;
        SqlDataAdapter daKhoHang;
        DataTable dtKhoHang;
        SqlParameter parameter;
        List<SqlParameter> parameters;
        private Connection db = new Connection();


        private void LoadData()
        {
            try
            {
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();

                daKhoHang = new SqlDataAdapter("Select MaMay,MaSP, NgayNhap From KhoHang", db.conn);
                dtKhoHang = new DataTable();
                daKhoHang.Fill(dtKhoHang);

                dgvNhapHang.DataSource = dtKhoHang;
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

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            NhapHang = true;
            this.txtMaMay.ResetText();
            this.txtMaSanPham.ResetText();
            this.txtNgayNhap.ResetText();


            this.btnLuu.Enabled = true;
            this.panel1.Enabled = true;
            this.btnThoat.Enabled = true;

            this.btnNhapHang.Enabled = false;
            this.btnSua.Enabled = false;
            this.panel2.Enabled = false;

            dgvNhapHang.Enabled = false;
            this.btnHuy.Enabled = true;



            this.txtMaMay.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhapHang = false;
            this.panel1.Enabled = true;
            int r = dgvNhapHang.CurrentCell.RowIndex;

            this.txtMaMay.Text = dgvNhapHang.Rows[r].Cells[0].Value.ToString();
            this.txtMaSanPham.Text = dgvNhapHang.Rows[r].Cells[1].Value.ToString();
            this.txtNgayNhap.Text = dgvNhapHang.Rows[r].Cells[2].Value.ToString();


            this.btnLuu.Enabled = true;
            this.panel1.Enabled = true;
            this.btnThoat.Enabled = true;

            this.btnNhapHang.Enabled = false;
            this.btnSua.Enabled = false;
            this.panel2.Enabled = false;
            this.btnHuy.Enabled = true;

            this.txtMaMay.Focus();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            db.conn.Open();
            if (NhapHang)
            {
                try
                {
                    string strSQL = "add_newKhoHang";
                    parameters = new List<SqlParameter>();

                    parameter = new SqlParameter("@MaMay", txtMaMay.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@MaSP", txtMaSanPham.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@NgayNhap", txtNgayNhap.Text);
                    parameters.Add(parameter);

                    if (db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters))
                    {
                        LoadData();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                        return;
                }
                catch
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                string strSQL = "update_NhapHang";
                parameters = new List<SqlParameter>();

                parameter = new SqlParameter("@MaMay", txtMaMay.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@MaSP", txtMaSanPham.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@NgayNhap", txtNgayNhap.Text);
                parameters.Add(parameter);

                db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                LoadData();
                MessageBox.Show("Cập Nhật thành công", "Thông báo", MessageBoxButtons.OK);
            }
            ResetText();
            db.conn.Close();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNhapHang.CurrentCell.RowIndex;
            if (r >= 0)
            {
                this.txtMaMay.Text =
                dgvNhapHang.Rows[r].Cells[0].Value.ToString();
                this.txtMaSanPham.Text =
                dgvNhapHang.Rows[r].Cells[1].Value.ToString();
                this.txtNgayNhap.Text =
                dgvNhapHang.Rows[r].Cells[2].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtKhoHang.Clear();
            SqlCommand command = new SqlCommand();
            command.Connection = db.conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Tim_Kiem";
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = txtTimTheoNgay.Text;
            daKhoHang.SelectCommand = command;
            daKhoHang.Fill(dtKhoHang);
            dgvNhapHang.DataSource = dtKhoHang;

            this.panel1.Enabled = true;
            this.btnNhapHang.Enabled = true;
            this.btnSua.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.panel1.Enabled = false;
            this.btnNhapHang.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnHuy.Enabled = false;
            this.dgvNhapHang.Enabled = true;
            this.btnLuu.Enabled = false;
            this.panel2.Enabled = true;
            ResetText();
        }
    }
}
