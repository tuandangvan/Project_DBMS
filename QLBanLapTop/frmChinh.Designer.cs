
namespace QLBanLapTop
{
    partial class frmChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnBaoHanh = new System.Windows.Forms.Button();
            this.btnLichSuMuaHang = new System.Windows.Forms.Button();
            this.btnMuaHang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSanPham
            // 
            this.btnSanPham.Location = new System.Drawing.Point(125, 62);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(112, 33);
            this.btnSanPham.TabIndex = 0;
            this.btnSanPham.Text = "Sản Phẩm";
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Location = new System.Drawing.Point(125, 101);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(112, 26);
            this.btnKhachHang.TabIndex = 0;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(125, 133);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Kho Hàng";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(125, 162);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(112, 23);
            this.btnNhanVien.TabIndex = 0;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnBaoHanh
            // 
            this.btnBaoHanh.Location = new System.Drawing.Point(125, 191);
            this.btnBaoHanh.Name = "btnBaoHanh";
            this.btnBaoHanh.Size = new System.Drawing.Size(129, 29);
            this.btnBaoHanh.TabIndex = 0;
            this.btnBaoHanh.Text = "Bảo Hành";
            this.btnBaoHanh.UseVisualStyleBackColor = true;
            this.btnBaoHanh.Click += new System.EventHandler(this.btnBaoHanh_Click);
            // 
            // btnLichSuMuaHang
            // 
            this.btnLichSuMuaHang.Location = new System.Drawing.Point(125, 220);
            this.btnLichSuMuaHang.Name = "btnLichSuMuaHang";
            this.btnLichSuMuaHang.Size = new System.Drawing.Size(112, 52);
            this.btnLichSuMuaHang.TabIndex = 0;
            this.btnLichSuMuaHang.Text = "Lịch Sử Mua Hàng";
            this.btnLichSuMuaHang.UseVisualStyleBackColor = true;
            this.btnLichSuMuaHang.Click += new System.EventHandler(this.btnLichSuMuaHang_Click);
            // 
            // btnMuaHang
            // 
            this.btnMuaHang.Location = new System.Drawing.Point(125, 290);
            this.btnMuaHang.Name = "btnMuaHang";
            this.btnMuaHang.Size = new System.Drawing.Size(112, 32);
            this.btnMuaHang.TabIndex = 0;
            this.btnMuaHang.Text = "Mua Hàng";
            this.btnMuaHang.UseVisualStyleBackColor = true;
            this.btnMuaHang.Click += new System.EventHandler(this.btnMuaHang_Click);
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 531);
            this.Controls.Add(this.btnMuaHang);
            this.Controls.Add(this.btnLichSuMuaHang);
            this.Controls.Add(this.btnBaoHanh);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnKhachHang);
            this.Controls.Add(this.btnSanPham);
            this.Name = "frmChinh";
            this.Text = "frmChinh";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnBaoHanh;
        private System.Windows.Forms.Button btnLichSuMuaHang;
        private System.Windows.Forms.Button btnMuaHang;
    }
}