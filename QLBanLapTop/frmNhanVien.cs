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
    public partial class frmNhanVien : Form
    {
        String nameView = "view_NhanVien";
        string strSQL = "";
        SqlParameter parameter;
        List<SqlParameter> parameters;
        private Connection db = new Connection();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        SqlDataAdapter daQLNV = null;
        DataTable dtQLNV = null;

        SqlDataAdapter daPB = null;
        DataTable dtPB = null;


        void LoadData()
        {

            if (db.conn.State == ConnectionState.Open)
                db.conn.Close();
            // Khởi động connection
            // Vận chuyển dữ liệu vào DataTable dtKhachHang
            daQLNV = new SqlDataAdapter("SELECT * FROM NhanVien", db.conn);
            dtQLNV = new DataTable();
            daQLNV.Fill(dtQLNV);
            dgvNhanVien.DataSource = dtQLNV;

            daPB = new SqlDataAdapter("SELECT * FROM PhongBan", db.conn);
            dtPB = new DataTable();
            daPB.Fill(dtPB);
            // Đưa dữ liệu lên DataGridView
            cbbPB.DataSource = dtPB;
            cbbPB.ValueMember = "MaPB";
            cbbPB.DisplayMember = "TenPB";

            cbbChucVu.Items.Add("Quản Lý");
            cbbChucVu.Items.Add("Tiếp Tân");
            cbbChucVu.Items.Add("NV Kỹ thuật");
            cbbChucVu.Items.Add("NV Bán Hàng");
            cbbChucVu.Items.Add("NV Giao Hàng");
            cbbChucVu.Items.Add("NV Tư Vấn");
            cbbChucVu.Items.Add("Bảo Vệ");


        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtMNV.Text.Trim() != "" && txtHoTen.Text.Trim() != ""
                && txtDiaChi.Text.Trim() != "" && txtCaLam.Text.Trim() != ""
                && txtKinhNghiem.Text.Trim() != "" && txtLuong.Text.Trim() != ""
                )
            {
                strSQL = "proc_addNhanVien";
                parameters = new List<SqlParameter>();

                parameter = new SqlParameter("@MaNV", txtMNV.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@TenNV", txtHoTen.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@DiaChi", txtDiaChi.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@SoDTNV", txtSDT.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@MaPB", cbbPB.SelectedValue);
                parameters.Add(parameter);

                parameter = new SqlParameter("@Luong", txtLuong.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@KinhNghiem", txtKinhNghiem.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@ChucVu", cbbChucVu.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@CaLam", txtCaLam.Text);
                parameters.Add(parameter);

                db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                LoadData();

            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMNV.Text.Trim() != "" && txtHoTen.Text.Trim() != ""
                && txtDiaChi.Text.Trim() != "" && txtCaLam.Text.Trim() != ""
                && txtKinhNghiem.Text.Trim() != "" && txtLuong.Text.Trim() != ""
                )

            {
                DialogResult check = MessageBox.Show("Bạn có muốn Sửa Nhân Viên" + " " + txtMNV.Text, "Thông báo",
                                 MessageBoxButtons.YesNo);
                if (check == DialogResult.No)
                    return;
                if (db.Check(txtMNV.Text, "NhanVien", "MaNV") == true)
                {
                    strSQL = "proc_updateNhanVien";

                    parameters = new List<SqlParameter>();


                    parameter = new SqlParameter("@MaNV", txtMNV.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@MaPB", cbbPB.SelectedValue);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@DiaChi", txtDiaChi.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@SoDTNV", txtSDT.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@Luong", txtLuong.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@KinhNghiem", txtKinhNghiem.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@ChucVu", cbbChucVu.Text);
                    parameters.Add(parameter);

                    parameter = new SqlParameter("@CaLam", txtCaLam.Text);
                    parameters.Add(parameter);

                    db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                    MessageBox.Show("Sửa thành công");
                    LoadData();
                }
                else
                    MessageBox.Show("Hãng sản xuất không tồn tại");
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNhanVien.CurrentCell.RowIndex;

            if (r >= 0)
            {
                /*int r = dgvSanPham.CurrentCell.RowIndex;*/
                this.txtMNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString().TrimEnd();
                this.txtHoTen.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString().TrimEnd();
                this.txtCaLam.Text = dgvNhanVien.Rows[r].Cells[8].Value.ToString().TrimEnd();
                this.txtKinhNghiem.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString().TrimEnd();
                this.txtLuong.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString().TrimEnd();
                this.txtSDT.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString().TrimEnd();
                this.txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[3].Value.ToString().TrimEnd();

                this.cbbPB.SelectedValue = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
                this.cbbChucVu.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();
                daQLNV = new SqlDataAdapter("DECLARE @txt nvarchar(50) = N'" + txtSearch.Text + "';Select * from NhanVien where MaNV =@txt or MaPB =@txt or TenNV =@txt or DiaChi =@txt or SoDTNV =@txt or KinhNghiem =@txt or ChucVu =@txt", db.conn);
                dtQLNV = new DataTable();
                daQLNV.Fill(dtQLNV);
                dgvNhanVien.DataSource = dtQLNV;
            }
            else
                LoadData();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtMNV.Text = "";
            this.txtHoTen.Text = "";
            this.txtCaLam.Text = "";
            this.txtKinhNghiem.Text = "";
            this.txtLuong.Text = "";
            this.txtSDT.Text = "";
            this.txtDiaChi.Text = "";

            this.cbbPB.SelectedValue = "";
            this.cbbChucVu.Text = "";
        }


    }
}
