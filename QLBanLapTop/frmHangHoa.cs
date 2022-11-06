using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using QLBanLapTop.DBPlayer; 

namespace QLBanLapTop
{
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }
        //SqlConnection conn;
        SqlDataAdapter daSanPham, daLoaiRAM, daBoNho, daHeDieuHanh, daManHinh, daHangSX, daRAM;
        DataTable dtSanPham, dtLoaiRam, dtBoNho, dtHeDieuHanh, dtManhHinh, dtHangSX, dtRAM;

        int option;

        SqlParameter parameter;
        List<SqlParameter> parameters;
        private Connection db = new Connection();


        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvSanPham.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            if (r >= 0)
            {
                try
                {
                    this.txtMaSP.Text =
                    dgvSanPham.Rows[r].Cells[0].Value.ToString();
                    this.cbxTenHang.SelectedValue =
                    dgvSanPham.Rows[r].Cells[1].Value.ToString();
                    this.txtTenSP.Text =
                    dgvSanPham.Rows[r].Cells[2].Value.ToString();
                    this.txtGiaNhap.Text =
                    dgvSanPham.Rows[r].Cells[3].Value.ToString();
                    this.txtGiaBan.Text =
                    dgvSanPham.Rows[r].Cells[4].Value.ToString();
                    this.txtTrongluong.Text =
                    dgvSanPham.Rows[r].Cells[5].Value.ToString();
                    this.txtPin.Text =
                    dgvSanPham.Rows[r].Cells[6].Value.ToString();
                    this.cbxManHinh.Text =
                    dgvSanPham.Rows[r].Cells[7].Value.ToString();
                    this.txtDoPhanGiai.Text =
                    dgvSanPham.Rows[r].Cells[8].Value.ToString();
                    this.txtTanSoQuet.Text =
                    dgvSanPham.Rows[r].Cells[9].Value.ToString();
                    this.txtBoXuLy.Text =
                    dgvSanPham.Rows[r].Cells[10].Value.ToString();
                    this.txtDHAM.Text =
                    dgvSanPham.Rows[r].Cells[11].Value.ToString();
                    this.cbxRAM.Text =
                    dgvSanPham.Rows[r].Cells[12].Value.ToString();
                    this.cbxLoaiRam.Text =
                    dgvSanPham.Rows[r].Cells[13].Value.ToString();
                    this.txtSoLuong.Text =
                    dgvSanPham.Rows[r].Cells[14].Value.ToString();
                    this.cbxBoNho.Text =
                    dgvSanPham.Rows[r].Cells[15].Value.ToString();
                    this.picHinhAnh.Image =
                    byteArrayToImage((byte[])dgvSanPham.Rows[r].Cells[16].Value);
                    this.cbxHeDieuHanh.Text =
                    dgvSanPham.Rows[r].Cells[17].Value.ToString();
                }
                catch
                {
                    //tránh chọn vào hàng cuối không có dữ liệu
                }

            }
        }

        private void cbxLocTenHang_Click(object sender, EventArgs e)
        {
            cbxLocTenHang.DataSource = dtHangSX;
            cbxLocTenHang.DisplayMember = "TenHang";
            cbxLocTenHang.ValueMember = "MaHang";
        }

        private void cbxLocManHinh_Click(object sender, EventArgs e)
        {
            cbxLocManHinh.DataSource = dtManhHinh;
            cbxLocManHinh.DisplayMember = "ManHinh";
        }

        private void cbxLocRAM_Click(object sender, EventArgs e)
        {
            cbxLocRAM.DataSource = dtRAM;
            cbxLocRAM.DisplayMember = "RAM";
        }

        private void cbxLocBoNho_Click(object sender, EventArgs e)
        {
            cbxLocBoNho.DataSource = dtBoNho;
            cbxLocBoNho.DisplayMember = "BoNho";
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            cbxLocRAM.ResetText();
            cbxLocManHinh.ResetText();
            cbxLocBoNho.ResetText();
            cbxLocTenHang.ResetText();
            ResetText();
            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            ResetText();
            string findQuery = "Select * from SanPham";
            if (cbxLocTenHang.Text != "")
                findQuery += " where MaHang='" + cbxTenHang.SelectedValue.ToString() + "'";

            if (cbxLocManHinh.Text!="")
                if(findQuery.IndexOf("where")>0)
                    findQuery += "and ManHinh='" + cbxLocManHinh.Text.ToString() + "'";
                else
                    findQuery += " where ManHinh='" + cbxLocManHinh.Text.ToString() + "'";

            if (cbxLocRAM.Text != "")
                if (findQuery.IndexOf("where") > 0)
                    findQuery += "and RAM='" + cbxLocRAM.Text.ToString() + "'";
                else
                    findQuery += " where RAM='" + cbxLocRAM.Text.ToString() + "'";

            if (cbxLocBoNho.Text != "")
                if (findQuery.IndexOf("where") > 0)
                    findQuery += "and BoNho='" + cbxLocBoNho.Text.ToString() + "'";
                else
                    findQuery += " where boNho='" + cbxLocBoNho.Text.ToString() + "'";


            try
            {
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();
                db.conn.Open();
                SqlDataAdapter daLoc;
                DataTable dtLoc;

                daLoc = new SqlDataAdapter(findQuery, db.conn);
                dtLoc = new DataTable();
                daLoc.Fill(dtLoc);

                dgvSanPham.DataSource = dtLoc;
                db.conn.Close();
            }
            catch { }
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                //conn = new SqlConnection(connectionString);
                if (db.conn.State == ConnectionState.Open)
                    db.conn.Close();
                db.conn.Open();


                daSanPham = new SqlDataAdapter("Select * From View_ThongTinSanPham", db.conn);
                daLoaiRAM = new SqlDataAdapter("Select DISTINCT LoaiRAM  FROM SanPham", db.conn);
                daBoNho = new SqlDataAdapter("Select DISTINCT BoNho FROM SanPham", db.conn);
                daManHinh = new SqlDataAdapter("Select DISTINCT ManHinh FROM SanPham", db.conn);
                daHeDieuHanh = new SqlDataAdapter("Select DISTINCT HeDieuHanh FROM SanPham", db.conn);
                daHangSX = new SqlDataAdapter("Select DISTINCT * FROM HangSX", db.conn);
                daRAM = new SqlDataAdapter("Select DISTINCT RAM FROM SanPham", db.conn);

                //doi du lieu
                dtSanPham = new DataTable();
                daSanPham.Fill(dtSanPham);

                dtBoNho = new DataTable();
                daBoNho.Fill(dtBoNho);

                dtLoaiRam = new DataTable();
                daLoaiRAM.Fill(dtLoaiRam);

                dtManhHinh = new DataTable();
                daManHinh.Fill(dtManhHinh);

                dtHeDieuHanh = new DataTable();
                daHeDieuHanh.Fill(dtHeDieuHanh);

                dtHangSX = new DataTable();
                daHangSX.Fill(dtHangSX);

                dtRAM = new DataTable();
                daRAM.Fill(dtRAM);


                //chuyen qua datagirdview
                dgvSanPham.DataSource = dtSanPham;

                cbxBoNho.DataSource = dtBoNho;
                cbxBoNho.DisplayMember = "BoNho";

                cbxRAM.DataSource = dtRAM;
                cbxRAM.DisplayMember = "RAM";

                cbxLoaiRam.DataSource = dtLoaiRam;
                cbxLoaiRam.DisplayMember = "LoaiRAM";

                cbxManHinh.DataSource = dtManhHinh;
                cbxManHinh.DisplayMember = "ManHinh";

                cbxHeDieuHanh.DataSource = dtHeDieuHanh;
                cbxHeDieuHanh.DisplayMember = "HeDieuHanh";

                cbxTenHang.DataSource = dtHangSX;
                cbxTenHang.DisplayMember = "TenHang";
                cbxTenHang.ValueMember = "MaHang";

                db.conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối thất bại!!", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = Image.FromFile(openFileDialog.FileName);
                this.Text = openFileDialog.FileName;
            }
        }

        // Chuyển ảnh sang byte array

        public byte[] ImageToByteArray(Image image)
        {
            if (picHinhAnh.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
            else
                return null;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            byte[] x = ImageToByteArray(picHinhAnh.Image);
            if (byteArrayIn == null)
                return null;
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void ResetText()
        {
            txtDoPhanGiai.ResetText();
            txtBoXuLy.ResetText();
            txtDHAM.ResetText();
            txtGiaNhap.ResetText();
            txtMaSP.ResetText();
            txtPin.ResetText();
            txtSoLuong.ResetText();
            txtTanSoQuet.ResetText();
            txtTenSP.ResetText();
            txtTrongluong.ResetText();
            txtGiaBan.ResetText();
            picHinhAnh.Image = null;
        }

        private void Enabled(bool check)
        {
            groupBox1.Enabled = true;
            //txtMaSP.Enabled = true;
            //txtDHAM.Enabled = true;
            //txtTenSP.Enabled = true;
            //txtBoXuLy.Enabled = true;
            //txtDoPhanGiai.Enabled = true;
            //txtGiaNhap.Enabled = true;
            //txtPin.Enabled = true;
            //txtTanSoQuet.Enabled = true;
            //txtTrongluong.Enabled = true;
            //cbxBoNho.Enabled = true;
            //cbxHeDieuHanh.Enabled = true;
            //cbxLoaiRam.Enabled = true;
            //cbxManHinh.Enabled = true;
            //cbxRAM.Enabled = true;
            //cbxTenHang.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            option = 1;

            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            groupBox1.Enabled = true;
            ResetText();
            groupBox3.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            option = 2;

            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            groupBox1.Enabled = true;
            txtMaSP.Enabled = false;

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                string strSQL = "proc_DeleteSanPham";
                parameters = new List<SqlParameter>();

                parameter = new SqlParameter("@MaSP", txtMaSP.Text);
                parameters.Add(parameter);

                db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                LoadData();
                ResetText();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTrongluong.Text.IndexOf(",") != -1)
            {
                MessageBox.Show("Bạn không được phép dùng dấu phẩy ',' trong ô trọng lượng");
                return;
            }
            // Mở kết nối
            db.conn.Open();
            // Thêm dữ liệu
            if (option == 1)
            {
                bool check = false;
                try
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (rs == DialogResult.Yes)
                    {
                        string strSQL = "proc_addNewSanPham";
                        byte[] imgString = ImageToByteArray(picHinhAnh.Image);
                        parameters = new List<SqlParameter>();

                        parameter = new SqlParameter("@MaSP", txtMaSP.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@MaHang", cbxTenHang.SelectedValue.ToString());
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@TenSP", txtTenSP.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@GiaNhap", txtGiaNhap.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@TrongLuong", txtTrongluong.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@Pin", txtPin.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@ManHinh", cbxManHinh.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@DoPhanGiai", txtDoPhanGiai.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@TanSoQuet", txtTanSoQuet.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@BoXuLi", txtBoXuLy.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@DoHoaAmThanh", txtDHAM.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@RAM", cbxRAM.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@LoaiRAM", cbxLoaiRam.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@BoNho", cbxBoNho.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@HinhAnh", imgString);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@HeDieuHanh", cbxHeDieuHanh.Text);
                        parameters.Add(parameter);

                        check = db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);

                        if (!check)
                        {
                            // Load lại dữ liệu trên DataGridView
                            LoadData();
                            ResetText();
                            // Thông báo
                            MessageBox.Show("Đã thêm xong!");
                            groupBox3.Enabled = true;
                        }
                        else if(picHinhAnh.Image==null)
                        {
                            MessageBox.Show("Chưa có ảnh", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }    
                        else
                        {
                            MessageBox.Show("Trùng mã sản phẩm", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }    
                    }
                    else return;
                }
                catch (SqlException)
                {
                        
                }
            }
            else if (option == 2)
            {
                try
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    // Thực hiện lệnh
                    if (rs == DialogResult.Yes)
                    {
                        string strSQL = "proc_updateSanPham";
                        byte[] imgString = ImageToByteArray(picHinhAnh.Image);
                        parameters = new List<SqlParameter>();

                        parameter = new SqlParameter("@MaSP", txtMaSP.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@MaHang", cbxTenHang.SelectedValue.ToString());
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@TenSP", txtTenSP.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@GiaNhap", txtGiaNhap.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@TrongLuong", txtTrongluong.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@Pin", txtPin.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@ManHinh", cbxManHinh.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@DoPhanGiai", txtDoPhanGiai.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@TanSoQuet", txtTanSoQuet.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@BoXuLi", txtBoXuLy.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@DoHoaAmThanh", txtDHAM.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@RAM", cbxRAM.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@LoaiRAM", cbxLoaiRam.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@BoNho", cbxBoNho.Text);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@HinhAnh", imgString);
                        parameters.Add(parameter);

                        parameter = new SqlParameter("@HeDieuHanh", cbxHeDieuHanh.Text);
                        parameters.Add(parameter);

                        db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                        ResetText();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else return;
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            groupBox1.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            groupBox3.Enabled = true;
            
            ResetText();
        }



    }

}
