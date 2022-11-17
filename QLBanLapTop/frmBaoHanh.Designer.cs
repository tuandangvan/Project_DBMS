
namespace QLBanLapTop
{
    partial class frmBaoHanh
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnBaoHanh = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSDTKH = new System.Windows.Forms.Label();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaMay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTimMaMay = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNgayMuaHang = new System.Windows.Forms.Label();
            this.lblNgayBaoHanh = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvBaoHanh = new System.Windows.Forms.DataGridView();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDTKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMuaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBaoHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoHanh)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Enabled = false;
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(248, 351);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(70, 34);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnBaoHanh
            // 
            this.btnBaoHanh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoHanh.Location = new System.Drawing.Point(19, 351);
            this.btnBaoHanh.Name = "btnBaoHanh";
            this.btnBaoHanh.Size = new System.Drawing.Size(118, 34);
            this.btnBaoHanh.TabIndex = 6;
            this.btnBaoHanh.Text = "Bảo Hành";
            this.btnBaoHanh.UseVisualStyleBackColor = true;
            this.btnBaoHanh.Click += new System.EventHandler(this.btnBaoHanh_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(153, 351);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(70, 34);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSDTKH);
            this.groupBox1.Controls.Add(this.lblMaSP);
            this.groupBox1.Controls.Add(this.lblMaNV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMaMay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnTimMaMay);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.btnBaoHanh);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.lblNgayMuaHang);
            this.groupBox1.Controls.Add(this.lblNgayBaoHanh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 390);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblSDTKH
            // 
            this.lblSDTKH.AutoSize = true;
            this.lblSDTKH.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTKH.Location = new System.Drawing.Point(137, 104);
            this.lblSDTKH.Name = "lblSDTKH";
            this.lblSDTKH.Size = new System.Drawing.Size(0, 19);
            this.lblSDTKH.TabIndex = 9;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSP.Location = new System.Drawing.Point(137, 130);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(0, 19);
            this.lblMaSP.TabIndex = 9;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(137, 45);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(0, 19);
            this.lblMaNV.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã NV";
            // 
            // txtMaMay
            // 
            this.txtMaMay.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMay.Location = new System.Drawing.Point(132, 74);
            this.txtMaMay.Name = "txtMaMay";
            this.txtMaMay.Size = new System.Drawing.Size(151, 22);
            this.txtMaMay.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã máy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã SP";
            // 
            // btnTimMaMay
            // 
            this.btnTimMaMay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimMaMay.Location = new System.Drawing.Point(304, 74);
            this.btnTimMaMay.Name = "btnTimMaMay";
            this.btnTimMaMay.Size = new System.Drawing.Size(75, 26);
            this.btnTimMaMay.TabIndex = 5;
            this.btnTimMaMay.Text = "Tìm";
            this.btnTimMaMay.UseVisualStyleBackColor = true;
            this.btnTimMaMay.Click += new System.EventHandler(this.btnTimMaMay_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(11, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 19);
            this.label19.TabIndex = 0;
            this.label19.Text = "SDT";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(132, 224);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(151, 106);
            this.txtGhiChu.TabIndex = 7;
            this.txtGhiChu.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên NV";
            // 
            // lblNgayMuaHang
            // 
            this.lblNgayMuaHang.AutoSize = true;
            this.lblNgayMuaHang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayMuaHang.Location = new System.Drawing.Point(137, 161);
            this.lblNgayMuaHang.Name = "lblNgayMuaHang";
            this.lblNgayMuaHang.Size = new System.Drawing.Size(0, 19);
            this.lblNgayMuaHang.TabIndex = 0;
            // 
            // lblNgayBaoHanh
            // 
            this.lblNgayBaoHanh.AutoSize = true;
            this.lblNgayBaoHanh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBaoHanh.Location = new System.Drawing.Point(137, 192);
            this.lblNgayBaoHanh.Name = "lblNgayBaoHanh";
            this.lblNgayBaoHanh.Size = new System.Drawing.Size(0, 19);
            this.lblNgayBaoHanh.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày mua hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày bảo hành";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ghi chú";
            // 
            // dgvBaoHanh
            // 
            this.dgvBaoHanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoHanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.MaSP,
            this.MaMay,
            this.SDTKH,
            this.NgayMuaHang,
            this.NgayBaoHanh,
            this.GhiChu});
            this.dgvBaoHanh.Location = new System.Drawing.Point(7, 20);
            this.dgvBaoHanh.Name = "dgvBaoHanh";
            this.dgvBaoHanh.ReadOnly = true;
            this.dgvBaoHanh.RowHeadersWidth = 51;
            this.dgvBaoHanh.RowTemplate.Height = 24;
            this.dgvBaoHanh.Size = new System.Drawing.Size(598, 356);
            this.dgvBaoHanh.TabIndex = 4;
            this.dgvBaoHanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaoHanh_CellClick);
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            this.MaNV.Width = 125;
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            this.MaSP.Width = 125;
            // 
            // MaMay
            // 
            this.MaMay.DataPropertyName = "MaMay";
            this.MaMay.HeaderText = "Mã máy";
            this.MaMay.MinimumWidth = 6;
            this.MaMay.Name = "MaMay";
            this.MaMay.ReadOnly = true;
            this.MaMay.Width = 125;
            // 
            // SDTKH
            // 
            this.SDTKH.DataPropertyName = "SoDTKH";
            this.SDTKH.HeaderText = "SDT KH";
            this.SDTKH.MinimumWidth = 6;
            this.SDTKH.Name = "SDTKH";
            this.SDTKH.ReadOnly = true;
            this.SDTKH.Width = 125;
            // 
            // NgayMuaHang
            // 
            this.NgayMuaHang.DataPropertyName = "NgayMuaHang";
            this.NgayMuaHang.HeaderText = "Ngày mua hàng";
            this.NgayMuaHang.MinimumWidth = 6;
            this.NgayMuaHang.Name = "NgayMuaHang";
            this.NgayMuaHang.ReadOnly = true;
            this.NgayMuaHang.Width = 125;
            // 
            // NgayBaoHanh
            // 
            this.NgayBaoHanh.DataPropertyName = "NgayBaoHanh";
            this.NgayBaoHanh.HeaderText = "Ngay bào hành";
            this.NgayBaoHanh.MinimumWidth = 6;
            this.NgayBaoHanh.Name = "NgayBaoHanh";
            this.NgayBaoHanh.ReadOnly = true;
            this.NgayBaoHanh.Width = 125;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 125;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvBaoHanh);
            this.groupBox3.Location = new System.Drawing.Point(416, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(611, 390);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(408, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 35);
            this.label8.TabIndex = 11;
            this.label8.Text = "Bảo hành";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Location = new System.Drawing.Point(136, 32);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(0, 19);
            this.lblTenNV.TabIndex = 10;
            // 
            // frmBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 492);
            this.Controls.Add(this.lblTenNV);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmBaoHanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBaoHanh";
            this.Load += new System.EventHandler(this.frmBaoHanh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoHanh)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnBaoHanh;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private System.Windows.Forms.Label lblNgayBaoHanh;
        private System.Windows.Forms.Label lblNgayMuaHang;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimMaMay;
        private System.Windows.Forms.TextBox txtMaMay;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblSDTKH;
        private System.Windows.Forms.DataGridView dgvBaoHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDTKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMuaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBaoHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTenNV;
    }
}