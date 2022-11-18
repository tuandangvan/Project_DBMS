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
        string sdt = "";


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

        void loadlistview()
        {

            SqlDataAdapter daLV = null;
            DataTable dtLV = null;
            if (db.conn.State == ConnectionState.Open)
                db.conn.Close();
            daLV = new SqlDataAdapter("SELECT max (NgayMuaHang) as NgayMuaHang, COUNT (SoDTKH) as countDH, SUM (GiaBan) as sumDH, MAX (GiaBan) as maxDH FROM LichSuMuaHang, SanPham where LichSuMuaHang.SoDTKH=N'" + sdt + "' and LichSuMuaHang.MaSP=SanPham.MaSP", db.conn);
            dtLV = new DataTable();
            daLV.Fill(dtLV);
            int i = 0;
            foreach (DataRow dr in dtLV.Rows)
            {
                listviewDHGN.Items.Add("Lần mua gần nhất:");
                listviewDHGN.Items.Add(dr["NgayMuaHang"].ToString());
                listViewDHmax.Items.Add("Đơn hàng lớn nhất:");
                listViewDHmax.Items.Add(dr["maxDH"].ToString());
                listViewTDH.Items.Add("Số đơn: " + dr["countDH"].ToString());
                listViewTDH.Items.Add("Tổng:");
                listViewTDH.Items.Add(dr["sumDH"].ToString());
                i++;
            }
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim() != "" && txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "")
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
                LoadData();

            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            listviewDHGN.Clear();
            listViewDHmax.Clear();
            listViewTDH.Clear();
            int r = dgvKhachHang.CurrentCell.RowIndex;


            if (r >= 0)
            {
                /*int r = dgvSanPham.CurrentCell.RowIndex;*/
                sdt = (dgvKhachHang.Rows[r].Cells[0].Value.ToString()).TrimEnd();
                this.txtSDT.Text = (dgvKhachHang.Rows[r].Cells[0].Value.ToString()).TrimEnd();
                this.txtHoTen.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString().TrimEnd();
                this.txtDiaChi.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString().TrimEnd();

            }
            loadlistview();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int r = dgvKhachHang.CurrentCell.RowIndex;

            if (sdt != "" && txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "")
            {
                DialogResult check = MessageBox.Show("Bạn có muốn Khách hàng" + " " + sdt, "Thông báo",
                                 MessageBoxButtons.YesNo);
                if (check == DialogResult.No)
                    return;

                strSQL = "proc_updateKhachHang";
                parameters = new List<SqlParameter>();

                parameter = new SqlParameter("@SoDTKH", sdt);
                parameters.Add(parameter);

                parameter = new SqlParameter("@TenKH", txtHoTen.Text);
                parameters.Add(parameter);

                parameter = new SqlParameter("@DiaChi", txtDiaChi.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            strSQL = "proc_updateLoaiKhachHang";
            parameters = new List<SqlParameter>();

            parameter = new SqlParameter("@SoDTKH", txtSDT.Text);
            parameters.Add(parameter);

            db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
            LoadData();
        }

 
    }

}