
namespace QLBanLapTop
{
    partial class frmKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.SoDTKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.listviewDHGN = new System.Windows.Forms.ListView();
            this.NgayMuaHang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewTDH = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDHmax = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtSDT.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSDT.Location = new System.Drawing.Point(110, 60);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(135, 24);
            this.txtSDT.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtHoTen.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtHoTen.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtHoTen.Location = new System.Drawing.Point(110, 94);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(135, 24);
            this.txtHoTen.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ Tên";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtDiaChi.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtDiaChi.Location = new System.Drawing.Point(110, 130);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(135, 24);
            this.txtDiaChi.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Địa chỉ";
            // 
            // dgvKhachHang
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 7.8F);
            this.dgvKhachHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoDTKH,
            this.TenKH,
            this.DiaChi,
            this.LoaiKH});
            this.dgvKhachHang.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvKhachHang.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvKhachHang.Location = new System.Drawing.Point(260, 20);
            this.dgvKhachHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvKhachHang.MultiSelect = false;
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.RowTemplate.Height = 29;
            this.dgvKhachHang.Size = new System.Drawing.Size(416, 190);
            this.dgvKhachHang.TabIndex = 7;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            // 
            // SoDTKH
            // 
            this.SoDTKH.DataPropertyName = "SoDTKH";
            this.SoDTKH.HeaderText = "Số điện thoại";
            this.SoDTKH.MinimumWidth = 6;
            this.SoDTKH.Name = "SoDTKH";
            this.SoDTKH.Width = 125;
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.HeaderText = "Tên Khách Hàng";
            this.TenKH.MinimumWidth = 6;
            this.TenKH.Name = "TenKH";
            this.TenKH.Width = 125;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 125;
            // 
            // LoaiKH
            // 
            this.LoaiKH.DataPropertyName = "LoaiKH";
            this.LoaiKH.HeaderText = "Loại ";
            this.LoaiKH.MinimumWidth = 6;
            this.LoaiKH.Name = "LoaiKH";
            this.LoaiKH.Width = 125;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Location = new System.Drawing.Point(4, 168);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdate.Location = new System.Drawing.Point(86, 168);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 26);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSearch.Location = new System.Drawing.Point(90, 26);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 24);
            this.txtSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Location = new System.Drawing.Point(13, 26);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.Location = new System.Drawing.Point(173, 168);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // listviewDHGN
            // 
            this.listviewDHGN.AccessibleName = "";
            this.listviewDHGN.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listviewDHGN.AllowColumnReorder = true;
            this.listviewDHGN.AllowDrop = true;
            this.listviewDHGN.BackColor = System.Drawing.Color.Fuchsia;
            this.listviewDHGN.BackgroundImageTiled = true;
            this.listviewDHGN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NgayMuaHang});
            this.listviewDHGN.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.listviewDHGN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listviewDHGN.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listviewDHGN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listviewDHGN.Location = new System.Drawing.Point(6, 226);
            this.listviewDHGN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listviewDHGN.Name = "listviewDHGN";
            this.listviewDHGN.Size = new System.Drawing.Size(188, 103);
            this.listviewDHGN.TabIndex = 30;
            this.listviewDHGN.Tag = "";
            this.listviewDHGN.UseCompatibleStateImageBehavior = false;
            this.listviewDHGN.UseWaitCursor = true;
            this.listviewDHGN.View = System.Windows.Forms.View.List;
            // 
            // NgayMuaHang
            // 
            this.NgayMuaHang.Tag = "NgayMuaHang";
            this.NgayMuaHang.Width = 300;
            // 
            // listViewTDH
            // 
            this.listViewTDH.AllowColumnReorder = true;
            this.listViewTDH.AllowDrop = true;
            this.listViewTDH.BackColor = System.Drawing.Color.Yellow;
            this.listViewTDH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewTDH.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.listViewTDH.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listViewTDH.HideSelection = false;
            this.listViewTDH.Location = new System.Drawing.Point(192, 226);
            this.listViewTDH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewTDH.Name = "listViewTDH";
            this.listViewTDH.Size = new System.Drawing.Size(188, 105);
            this.listViewTDH.TabIndex = 32;
            this.listViewTDH.UseCompatibleStateImageBehavior = false;
            this.listViewTDH.UseWaitCursor = true;
            this.listViewTDH.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "NgayMuaHang";
            this.columnHeader1.Width = 300;
            // 
            // listViewDHmax
            // 
            this.listViewDHmax.AllowColumnReorder = true;
            this.listViewDHmax.AllowDrop = true;
            this.listViewDHmax.BackColor = System.Drawing.Color.Red;
            this.listViewDHmax.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewDHmax.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.listViewDHmax.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listViewDHmax.HideSelection = false;
            this.listViewDHmax.Location = new System.Drawing.Point(379, 226);
            this.listViewDHmax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewDHmax.Name = "listViewDHmax";
            this.listViewDHmax.Size = new System.Drawing.Size(188, 105);
            this.listViewDHmax.TabIndex = 33;
            this.listViewDHmax.UseCompatibleStateImageBehavior = false;
            this.listViewDHmax.UseWaitCursor = true;
            this.listViewDHmax.View = System.Windows.Forms.View.List;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "NgayMuaHang";
            this.columnHeader2.Width = 300;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label4.Location = new System.Drawing.Point(20, 205);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 21);
            this.label4.TabIndex = 36;
            this.label4.Text = "Thông tin mua hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Cyan;
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(256, 203);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khách Hàng";
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(685, 359);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listViewDHmax);
            this.Controls.Add(this.listViewTDH);
            this.Controls.Add(this.listviewDHGN);
            this.Controls.Add(this.dgvKhachHang);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmKhachHang";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormKhachHang";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDTKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiKH;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView listviewDHGN;
        private System.Windows.Forms.ColumnHeader NgayMuaHang;
        private System.Windows.Forms.ListView listViewTDH;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewDHmax;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        #endregion
    }
}