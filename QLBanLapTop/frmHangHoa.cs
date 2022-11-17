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
                    //double a = double.Parse(dgvSanPham.Rows[r].Cells[3].Value.ToString());
                    this.txtMaSP.Text =
                    dgvSanPham.Rows[r].Cells[0].Value.ToString().TrimEnd();
                    this.cbxTenHang.SelectedValue =
                    dgvSanPham.Rows[r].Cells[1].Value.ToString().TrimEnd();
                    this.txtTenSP.Text =
                    dgvSanPham.Rows[r].Cells[2].Value.ToString().TrimEnd();
                    this.txtGiaNhap.Text =
                    (double.Parse(dgvSanPham.Rows[r].Cells[3].Value.ToString())).ToString().TrimEnd();
                    this.txtGiaBan.Text =
                    (double.Parse(dgvSanPham.Rows[r].Cells[4].Value.ToString())).ToString().TrimEnd();
                    this.txtTrongluong.Text =
                    dgvSanPham.Rows[r].Cells[5].Value.ToString().TrimEnd();
                    this.txtPin.Text =
                    dgvSanPham.Rows[r].Cells[6].Value.ToString().TrimEnd();
                    this.cbxManHinh.Text =
                    dgvSanPham.Rows[r].Cells[7].Value.ToString().TrimEnd();
                    this.txtDoPhanGiai.Text =
                    dgvSanPham.Rows[r].Cells[8].Value.ToString().TrimEnd();
                    this.txtTanSoQuet.Text =
                    dgvSanPham.Rows[r].Cells[9].Value.ToString().TrimEnd();
                    this.txtBoXuLy.Text =
                    dgvSanPham.Rows[r].Cells[10].Value.ToString().TrimEnd();
                    this.txtDHAM.Text =
                    dgvSanPham.Rows[r].Cells[11].Value.ToString().TrimEnd();
                    this.cbxRAM.Text =
                    dgvSanPham.Rows[r].Cells[12].Value.ToString().TrimEnd();
                    this.cbxLoaiRam.Text =
                    dgvSanPham.Rows[r].Cells[13].Value.ToString().TrimEnd();
                    this.txtSoLuong.Text =
                    dgvSanPham.Rows[r].Cells[14].Value.ToString().TrimEnd();
                    this.cbxBoNho.Text =
                    dgvSanPham.Rows[r].Cells[15].Value.ToString().TrimEnd();
                    this.picHinhAnh.Image =
                    byteArrayToImage((byte[])dgvSanPham.Rows[r].Cells[16].Value);
                    this.cbxHeDieuHanh.Text =
                    dgvSanPham.Rows[r].Cells[17].Value.ToString().TrimEnd();
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

            if (cbxLocManHinh.Text != "")
                if (findQuery.IndexOf("where") > 0)
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
        private bool CheckGiaNhap(string gianhap)
        {
            char[] charArr = gianhap.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                if ("0123456789".ToString().IndexOf(charArr[i].ToString()) == -1)
                    return false;//có kí tự chữ
            }
            return true;//không có kí tự chữ
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaNhap.Text == "")
                txtGiaBan.Text = "";
            else if(!CheckGiaNhap(txtGiaNhap.Text))
            {
                MessageBox.Show("Chỉ được nhập kí tự số");
                txtGiaNhap.ResetText();
            }    
            else
                txtGiaBan.Text = (double.Parse(txtGiaNhap.Text) * 1.02).ToString();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
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
                List<SqlParameter> parameters = new List<SqlParameter>();
                string strSQL = "proc_DeleteSanPham";

                parameters.Add(new SqlParameter("@MaSP", txtMaSP.Text));

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
            if (txtMaSP.Text == "" || txtGiaNhap.Text == "" || txtDHAM.Text == "" || txtBoXuLy.Text == "" || txtDoPhanGiai.Text == "" ||
                txtPin.Text == "" || txtTanSoQuet.Text == "" || txtTenSP.Text == "" || txtTrongluong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else { 
                if (option == 1)
                {
                    try
                    {
                        DialogResult rs = MessageBox.Show("Bạn có chắc muốn thêm không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rs == DialogResult.Yes)
                        {
                            if (!db.Check(txtMaSP.Text, "SanPham", "MaSP"))
                            {
                                if (picHinhAnh.Image == null)
                                {
                                    MessageBox.Show("Chưa có ảnh", "Thông báo", MessageBoxButtons.OK);
                                    return;
                                }
                                string strSQL = "proc_addNewSanPham";
                                byte[] imgString = ImageToByteArray(picHinhAnh.Image);
                                List<SqlParameter> parameters = new List<SqlParameter>();

                                parameters.Add(new SqlParameter("@MaSP", txtMaSP.Text));
                                parameters.Add(new SqlParameter("@MaHang", cbxTenHang.SelectedValue.ToString()));
                                parameters.Add(new SqlParameter("@TenSP", txtTenSP.Text));
                                parameters.Add(new SqlParameter("@GiaNhap", txtGiaNhap.Text));
                                parameters.Add(new SqlParameter("@TrongLuong", txtTrongluong.Text));
                                parameters.Add(new SqlParameter("@Pin", txtPin.Text));
                                parameters.Add(new SqlParameter("@ManHinh", cbxManHinh.Text));
                                parameters.Add(new SqlParameter("@DoPhanGiai", txtDoPhanGiai.Text));
                                parameters.Add(new SqlParameter("@TanSoQuet", txtTanSoQuet.Text));
                                parameters.Add(new SqlParameter("@BoXuLi", txtBoXuLy.Text));
                                parameters.Add(new SqlParameter("@DoHoaAmThanh", txtDHAM.Text));
                                parameters.Add(new SqlParameter("@RAM", cbxRAM.Text));
                                parameters.Add(new SqlParameter("@LoaiRAM", cbxLoaiRam.Text));
                                parameters.Add(new SqlParameter("@BoNho", cbxBoNho.Text));
                                parameters.Add(new SqlParameter("@HinhAnh", imgString));
                                parameters.Add(new SqlParameter("@HeDieuHanh", cbxHeDieuHanh.Text));

                                if (db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters))
                                {
                                    // Load lại dữ liệu trên DataGridView
                                    LoadData();
                                    ResetText();
                                    groupBox3.Enabled = true;
                                    MessageBox.Show("Thêm sản phẩm thành công");
                                }
                                else
                                    return;
                            }
                            else
                            {
                                //MessageBox.Show("Trùng mã sản phẩm", "Thông báo", MessageBoxButtons.OK);
                                //return;
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
                            if (picHinhAnh.Image == null)
                            {
                                MessageBox.Show("Chưa có ảnh", "Thông báo", MessageBoxButtons.OK);
                                return;
                            }
                            string strSQL = "proc_updateSanPham";
                            byte[] imgString = ImageToByteArray(picHinhAnh.Image);
                            List<SqlParameter> parameters = new List<SqlParameter>();

                            parameters.Add(new SqlParameter("@MaSP", txtMaSP.Text));
                            parameters.Add(new SqlParameter("@MaHang", cbxTenHang.SelectedValue.ToString()));
                            parameters.Add(new SqlParameter("@TenSP", txtTenSP.Text));
                            parameters.Add(new SqlParameter("@GiaNhap", txtGiaNhap.Text));
                            parameters.Add(new SqlParameter("@TrongLuong", txtTrongluong.Text));
                            parameters.Add(new SqlParameter("@Pin", txtPin.Text));
                            parameters.Add(new SqlParameter("@ManHinh", cbxManHinh.Text));
                            parameters.Add(new SqlParameter("@DoPhanGiai", txtDoPhanGiai.Text));
                            parameters.Add(new SqlParameter("@TanSoQuet", txtTanSoQuet.Text));
                            parameters.Add(new SqlParameter("@BoXuLi", txtBoXuLy.Text));
                            parameters.Add(new SqlParameter("@DoHoaAmThanh", txtDHAM.Text));
                            parameters.Add(new SqlParameter("@RAM", cbxRAM.Text));
                            parameters.Add(new SqlParameter("@LoaiRAM", cbxLoaiRam.Text));
                            parameters.Add(new SqlParameter("@BoNho", cbxBoNho.Text));
                            parameters.Add(new SqlParameter("@HinhAnh", imgString));
                            parameters.Add(new SqlParameter("@HeDieuHanh", cbxHeDieuHanh.Text));

                            db.ExecuteProcedure(strSQL, CommandType.StoredProcedure, parameters);
                            // Load lại dữ liệu trên DataGridView
                            LoadData();
                            ResetText();
                            MessageBox.Show("Cập nhật thành công!");
                        }
                        else return;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không sửa được. Lỗi rồi!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                groupBox1.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
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
            txtMaSP.Enabled = true;

            ResetText();
        }
    }
}