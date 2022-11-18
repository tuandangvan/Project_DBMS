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
    public partial class TaiKhoanUControl : UserControl
    {
        private int roletemp;
        private bool isAdd = false;
        private bool isEdit = false;

        public TaiKhoanUControl()
        {
            InitializeComponent();
        }
        public static bool Permission()
        {
            if (frmLogin.idRole == "Nhân Viên")
            {
                return false;
            }
            return true;
        }

        private void LoadData()
        {
            resetText();
            Connection db = new Connection();
            db.conn.Open();
            string sql = "SELECT * FROM view_TaiKhoan";
            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            dgvTaiKhoan.DataSource = dt;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Permission())
            {
                resetText();
                groupBox1.Enabled = true;
                dgvTaiKhoan.Enabled = false;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                isAdd = true;
                isEdit = false;
                txtIdAcc.Enabled = true;
                txtUserName.Enabled = true;
                cbLoaiTK.Enabled = true;
                cbTenNV.Enabled = true;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thêm tài khoản!!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            txtIdAcc.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = true;
            cbLoaiTK.Enabled = false;
            cbTenNV.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            isEdit = true;
            isAdd = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Permission())
            {
                Connection db = new Connection();
                try
                {
                    db.conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    //Khai báo tên proc
                    cmd.CommandText = "proc_DeleteAccount";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = db.conn;

                    //Khai báo các thông số truyền vào
                    cmd.Parameters.Add("@idAcc", SqlDbType.VarChar).Value = txtIdAcc.Text;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa tài khoản thành công", "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    resetText();
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền xóa tài khoản", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNameNV.Text = cbTenNV.SelectedValue.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Connection db = new Connection();
            try
            {
                if (cbLoaiTK.Text == "Quản lý")
                {
                    roletemp = 1;
                }
                else
                {
                    roletemp = 0;
                }
                if (CheckTextEmpty() == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isAdd = false;
                    isEdit = false;
                }
                if (isAdd)
                {
                    try
                    {
                        db.conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        //Khai báo tên proc
                        cmd.CommandText = "proc_addNewAccount";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = db.conn;

                        //Khai báo các thông số truyền vào
                        cmd.Parameters.Add("@idAcc", SqlDbType.VarChar).Value = txtIdAcc.Text;
                        cmd.Parameters.Add("@TenTK", SqlDbType.VarChar).Value = txtUserName.Text;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text;
                        cmd.Parameters.Add("@LoaiTK", SqlDbType.Bit).Value = roletemp;
                        cmd.Parameters.Add("@MaNV", SqlDbType.VarChar).Value = lbNameNV.Text;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thêm tài khoản thành công", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        resetText();
                        LoadData();
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        txtIdAcc.Enabled = false;
                        txtUserName.Enabled = false;
                        cbTenNV.Enabled = false;
                        cbLoaiTK.Enabled = false;
                        txtPassword.Enabled = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thông tin không hợp lệ", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
                else if (isEdit)
                {
                    try
                    {
                        db.conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        //Khai báo tên proc
                        cmd.CommandText = "proc_updateAccount";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = db.conn;

                        //Khai báo các thông số truyền vào
                        cmd.Parameters.Add("@idAcc", SqlDbType.VarChar).Value = txtIdAcc.Text;
                        cmd.Parameters.Add("@TenTK", SqlDbType.VarChar).Value = txtUserName.Text;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Sửa tài khoản thành công", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        resetText();
                        LoadData();
                        btnAdd.Enabled = true;
                        btnDelete.Enabled = true;
                        btnEdit.Enabled = true;
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        txtIdAcc.Enabled = false;
                        txtUserName.Enabled = false;
                        cbTenNV.Enabled = false;
                        cbLoaiTK.Enabled = false;
                        txtPassword.Enabled = false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Mật khẩu không hợp lệ", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có lỗi xãy ra!!!Hãy kiểm tra lại thông tin", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

        }
        private void resetText()
        {
            txtIdAcc.ResetText();
            txtPassword.ResetText();
            txtUserName.ResetText();
            cbTenNV.ResetText();
            cbLoaiTK.ResetText();
            lbNameNV.ResetText();
        }
        private int CheckTextEmpty()
        {
            if (txtIdAcc.Text == "" || txtPassword.Text == "" || txtUserName.Text == "")
            {
                return 0;
            }
            return 1;
        }
        private void BindCbTenNV()
        {
            Connection db = new Connection();
            string sql = "SELECT * FROM dbo.fnc_ColTenNV()";

            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            db.conn.Close();
            cbTenNV.DataSource = dt;
            cbTenNV.DisplayMember = "TenNV";
            cbTenNV.ValueMember = "MaNV";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetText();
            groupBox1.Enabled = false;
            dgvTaiKhoan.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = true;
            btnSave.Enabled = false;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) // -1 Là dòng title của dgv
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvTaiKhoan.Rows[e.RowIndex];
                txtIdAcc.Text = Convert.ToString(row.Cells[0].Value);
                txtUserName.Text = Convert.ToString(row.Cells[1].Value);
                txtPassword.Text = Convert.ToString(row.Cells[2].Value);
                cbLoaiTK.Text = row.Cells[4].Value.ToString();
                cbTenNV.Text = row.Cells[3].Value.ToString();
                lbNameNV.Text = cbTenNV.SelectedValue.ToString();
            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            cbLoaiTK.Items.Add("Quản lý");
            cbLoaiTK.Items.Add("Nhân viên");
            LoadData();
            BindCbTenNV();
            lbNameNV.Text = cbTenNV.SelectedValue.ToString();
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
        }
    }
}
