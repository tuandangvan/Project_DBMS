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
    public partial class frmBaoHanh : Form
    {

        public frmBaoHanh()
        {
            InitializeComponent();
        }
        Connection db = new Connection();
        
        SqlDataAdapter daLichSuBaoHanh, daNhanVien, daTimMay;
        DataTable dtLichSuBaoHanh,dtNhanVien, dtTimMay;

        private void btnBaoHanh_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc muốn bảo hành không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rs == DialogResult.Yes)
                {
                    string strSQL = "proc_addBaoHanh";
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    parameters.Add(new SqlParameter("@MaNV", cbxNhanVien.SelectedValue.ToString()));
                    parameters.Add(new SqlParameter("@MaSP", lblMaSP.Text));
                    parameters.Add(new SqlParameter("@MaMay", txtMaMay.Text));
                    parameters.Add(new SqlParameter("@SoDTKH", lblSDTKH.Text));
                    parameters.Add(new SqlParameter("@NgayMuaHang", lblNgayMuaHang.Text));
                    parameters.Add(new SqlParameter("@NgayBaoHanh", lblNgayBaoHanh.Text));
                    parameters.Add(new SqlParameter("@GhiChu", txtGhiChu.Text));

                    db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                    LoadData();
                }
            } catch (Exception ex)
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
                lblNgayMuaHang.Text = ngaymua.Date.ToString();

                db.conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK);
            }
        }

        

        private void cbxNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTenNV.Text = cbxNhanVien.SelectedValue.ToString();
        }


        private void frmBaoHanh_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();
                db.conn.Open();
                daLichSuBaoHanh = new SqlDataAdapter("Select * From View_LichSuBaoHanh", db.conn);
                daNhanVien = new SqlDataAdapter("Select * From NhanVien", db.conn);

                //doi du lieu
                dtLichSuBaoHanh = new DataTable();
                daLichSuBaoHanh.Fill(dtLichSuBaoHanh);
                dgvBaoHanh.DataSource = dtLichSuBaoHanh;

                dtNhanVien = new DataTable();
                daNhanVien.Fill(dtNhanVien);
                
                cbxNhanVien.DataSource = dtNhanVien;
                cbxNhanVien.DisplayMember = "TenNV";
                cbxNhanVien.ValueMember = "MaNV";
                lblTenNV.Text = cbxNhanVien.SelectedValue.ToString();

                db.conn.Close();
                lblNgayBaoHanh.Text = DateTime.Today.ToString();

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
