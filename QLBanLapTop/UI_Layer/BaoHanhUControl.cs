using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using QLBanLapTop.DBPlayer;

namespace QLBanLapTop
{
    public partial class BaoHanhUControl : UserControl
    {

        public BaoHanhUControl()
        {
            InitializeComponent();
        }
        Connection db = new Connection();

        SqlDataAdapter daLichSuBaoHanh, daTimMay;
        DataTable dtLichSuBaoHanh, dtTimMay;

        private void btnBaoHanh_Click(object sender, EventArgs e)
        {
            if (lblMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng ấn tìm mã máy!");
            }
            else
            {
                try
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn bảo hành không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (rs == DialogResult.Yes)
                    {
                        string strSQL = "proc_addBaoHanh";
                        List<SqlParameter> parameters = new List<SqlParameter>();

                        parameters.Add(new SqlParameter("@MaNV", lblMaNV.Text));
                        parameters.Add(new SqlParameter("@MaSP", lblMaSP.Text));
                        parameters.Add(new SqlParameter("@MaMay", txtMaMay.Text));
                        parameters.Add(new SqlParameter("@SoDTKH", lblSDTKH.Text));
                        parameters.Add(new SqlParameter("@NgayMuaHang", lblNgayMuaHang.Text));
                        parameters.Add(new SqlParameter("@NgayBaoHanh", lblNgayBaoHanh.Text));
                        parameters.Add(new SqlParameter("@GhiChu", txtGhiChu.Text));

                        if (db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters))
                        {
                            MessageBox.Show("Bảo hành thành công!");
                            txtGhiChu.ResetText();
                            txtMaMay.ResetText();
                            lblNgayMuaHang.ResetText();

                        }
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvBaoHanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvBaoHanh.CurrentCell.RowIndex;

            try
            {
                if (r >= 0)
                {
                    this.lblMaNV.Text = dgvBaoHanh.Rows[r].Cells[0].Value.ToString();
                    this.txtMaMay.Text = dgvBaoHanh.Rows[r].Cells[2].Value.ToString();
                    this.lblSDTKH.Text = dgvBaoHanh.Rows[r].Cells[3].Value.ToString();
                    this.lblMaSP.Text = dgvBaoHanh.Rows[r].Cells[1].Value.ToString();
                    this.lblNgayMuaHang.Text = DateTime.Parse(dgvBaoHanh.Rows[r].Cells[4].Value.ToString()).ToString("MM/dd/yyyy");
                    this.lblNgayBaoHanh.Text = DateTime.Parse(dgvBaoHanh.Rows[r].Cells[5].Value.ToString()).ToString("MM/dd/yyyy");
                    this.txtGhiChu.Text = dgvBaoHanh.Rows[r].Cells[6].Value.ToString();
                }
            }
            catch
            {
                //tranh chon vao o trong
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rs == DialogResult.Yes)
                {
                    string strSQL = "proc_updateBaoHanh";
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    parameters.Add(new SqlParameter("@MaSP", lblMaSP.Text));
                    parameters.Add(new SqlParameter("@SoDTKH", lblSDTKH.Text));
                    parameters.Add(new SqlParameter("@NgayMuaHang", lblNgayMuaHang.Text));
                    parameters.Add(new SqlParameter("@NgayBaoHanh", lblNgayBaoHanh.Text));
                    parameters.Add(new SqlParameter("@GhiChu", txtGhiChu.Text));
                    parameters.Add(new SqlParameter("@MaMay", txtMaMay.Text));

                    db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                    LoadData();
                }
            }
            catch (Exception ex)
            { }

        }

        private void btnTimMaMay_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();
                db.conn.Open();
                daTimMay = new SqlDataAdapter("Select SoDTKH, MaSP, NgayMuaHang From LichSuMuaHang where MaMay = '" + txtMaMay.Text + "'", db.conn);

                //doi du lieu
                dtTimMay = new DataTable();
                daTimMay.Fill(dtTimMay);

                lblSDTKH.Text = dtTimMay.Rows[0][0].ToString();
                lblMaSP.Text = dtTimMay.Rows[0][1].ToString();

                DateTime ngaymua = (DateTime)dtTimMay.Rows[0][2];
                lblNgayMuaHang.Text = ngaymua.Date.ToString("MM/dd/yyyy");

                db.conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK);
            }
        }


        private void frmBaoHanh_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            lblTenNV.Text = frmLogin.nameEmp;
            lblMaNV.Text = frmLogin.idEmp;
            try
            {
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();
                db.conn.Open();
                daLichSuBaoHanh = new SqlDataAdapter("Select * From LichSuBaoHanh", db.conn);

                //doi du lieu
                dtLichSuBaoHanh = new DataTable();
                daLichSuBaoHanh.Fill(dtLichSuBaoHanh);
                dgvBaoHanh.DataSource = dtLichSuBaoHanh;


                db.conn.Close();
                lblNgayBaoHanh.Text = DateTime.Today.ToString("MM/dd/yyyy");

            }
            catch (Exception ex)
            {

            }
        }
    }
}
