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
    public partial class frmLogin : Form
    {
        public static string idEmp { get; set; }
        public static string nameEmp { get; set; }
        public static string idRole { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool check = Login();
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Hide();
            try
            {

                if (check)
                {
                    MessageBox.Show("Đăng nhập thành công!!!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //frmMuaHang.Show();
                    //frmTaiKhoan.Show();                   
                    //this.Dispose();   fix giùm t cái lỗi này, đkm nó tắt form login cái nó tắt hết
                    //frmMenu.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!!!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!!!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Login()
        {
            string user = txtUsername.Text.ToString().Trim();
            string password = txtPassword.Text.ToString().Trim();
            Connection db = new Connection();
            string sql = "select * from dbo.func_getIdEmployee(@user, @password)";

            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString() != "")
            {
                idEmp = dt.Rows[0][0].ToString();
                nameEmp = dt.Rows[0][1].ToString();
                if (dt.Rows[0][2].ToString() == "False")
                    idRole = "Nhân Viên";
                else
                    idRole = "Quản Lý";
                return true;
            }
            return false;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Tên Đăng Nhập";
            txtPassword.Text = "Mật khẩu";
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Tên Đăng Nhập")
            {
                txtUsername.ResetText();
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu")
            {
                txtPassword.ResetText();
                txtPassword.PasswordChar = '✽';
            }
        }

        private void btnHienPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '✽';
            }
            else if (txtPassword.PasswordChar == '✽')
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu" || txtPassword.Text == "")
            {
                txtPassword.ResetText();
                txtPassword.PasswordChar = '✽';
            }
        }
    }
}
