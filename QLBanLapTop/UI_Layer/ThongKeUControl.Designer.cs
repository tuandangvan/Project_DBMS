namespace QLBanLapTop.UI_Layer
{
    partial class ThongKeUControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnDoanhThu = new System.Windows.Forms.Button();
            this.listviewDoanhThu = new System.Windows.Forms.ListView();
            this.NgayMuaHang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.chartDS = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrist = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.chartDS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThu.Location = new System.Drawing.Point(1021, 318);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(134, 38);
            this.btnDoanhThu.TabIndex = 0;
            this.btnDoanhThu.Text = "Doanh thu";
            this.btnDoanhThu.UseVisualStyleBackColor = true;
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // listviewDoanhThu
            // 
            this.listviewDoanhThu.AccessibleName = "";
            this.listviewDoanhThu.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listviewDoanhThu.AllowColumnReorder = true;
            this.listviewDoanhThu.AllowDrop = true;
            this.listviewDoanhThu.BackColor = System.Drawing.Color.Aqua;
            this.listviewDoanhThu.BackgroundImageTiled = true;
            this.listviewDoanhThu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NgayMuaHang});
            this.listviewDoanhThu.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.listviewDoanhThu.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.listviewDoanhThu.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listviewDoanhThu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listviewDoanhThu.HideSelection = false;
            this.listviewDoanhThu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listviewDoanhThu.Location = new System.Drawing.Point(862, 376);
            this.listviewDoanhThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listviewDoanhThu.Name = "listviewDoanhThu";
            this.listviewDoanhThu.Size = new System.Drawing.Size(478, 156);
            this.listviewDoanhThu.TabIndex = 31;
            this.listviewDoanhThu.Tag = "";
            this.listviewDoanhThu.UseCompatibleStateImageBehavior = false;
            this.listviewDoanhThu.UseWaitCursor = true;
            this.listviewDoanhThu.View = System.Windows.Forms.View.List;
            // 
            // NgayMuaHang
            // 
            this.NgayMuaHang.Tag = "NgayMuaHang";
            this.NgayMuaHang.Width = 300;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(287, 184);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(137, 28);
            this.dtpEndDate.TabIndex = 35;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeginDate.Location = new System.Drawing.Point(84, 184);
            this.dtpBeginDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(131, 28);
            this.dtpBeginDate.TabIndex = 34;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(626, 178);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 28);
            this.btnThongKe.TabIndex = 33;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // chartDS
            // 
            this.chartDS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chartDS.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            this.chartDS.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            this.chartDS.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartDS.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDS.Legends.Add(legend1);
            this.chartDS.Location = new System.Drawing.Point(21, 214);
            this.chartDS.Margin = new System.Windows.Forms.Padding(4);
            this.chartDS.Name = "chartDS";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Doanh thu";
            this.chartDS.Series.Add(series1);
            this.chartDS.Size = new System.Drawing.Size(784, 369);
            this.chartDS.TabIndex = 32;
            this.chartDS.Text = "Doanh số";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 36;
            this.label1.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 36;
            this.label2.Text = "Ngày kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(892, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Ngày bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1132, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 21);
            this.label4.TabIndex = 36;
            this.label4.Text = "Ngày kết thúc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(588, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 37);
            this.label5.TabIndex = 36;
            this.label5.Text = "THỐNG KÊ";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(1127, 246);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(137, 28);
            this.dateTimePickerEnd.TabIndex = 37;
            // 
            // dateTimePickerFrist
            // 
            this.dateTimePickerFrist.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrist.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrist.Location = new System.Drawing.Point(896, 246);
            this.dateTimePickerFrist.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrist.Name = "dateTimePickerFrist";
            this.dateTimePickerFrist.Size = new System.Drawing.Size(131, 28);
            this.dateTimePickerFrist.TabIndex = 38;
            // 
            // ThongKeUControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePickerFrist);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpBeginDate);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.chartDS);
            this.Controls.Add(this.listviewDoanhThu);
            this.Controls.Add(this.btnDoanhThu);
            this.Name = "ThongKeUControl";
            this.Size = new System.Drawing.Size(1367, 615);
            ((System.ComponentModel.ISupportInitialize)(this.chartDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.ListView listviewDoanhThu;
        private System.Windows.Forms.ColumnHeader NgayMuaHang;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrist;
    }
}
