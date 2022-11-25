using QLBanLapTop.DBPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanLapTop.UI_Layer
{
    public partial class ThongKeUControl : UserControl
    {
        string strSQL = "";
        SqlParameter parameter;

        List<SqlParameter> parameters;
        private Connection db = new Connection();
        public ThongKeUControl()
        {
            InitializeComponent();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            listviewDoanhThu.Clear();
            SqlDataAdapter daLV = null;
            DataTable dtLV = null;
            if (db.conn.State == ConnectionState.Open)
                db.conn.Close();
            string dateF = dateTimePickerFrist.Value.Year.ToString() + "-" + dateTimePickerFrist.Value.Month.ToString() + "-" + dateTimePickerFrist.Value.Day.ToString();
            string dateE = dateTimePickerEnd.Value.Year.ToString() + "-" + dateTimePickerEnd.Value.Month.ToString() + "-" + dateTimePickerEnd.Value.Day.ToString();
            daLV = new SqlDataAdapter("SELECT dbo.func_DoanhThu('"+dateF+"','"+dateE+"') as doanhthu", db.conn);
            dtLV = new DataTable();
            daLV.Fill(dtLV);
            int i = 0;
            foreach (DataRow dr in dtLV.Rows)
            {
                listviewDoanhThu.Items.Add("Doanh thu: từ "+dateF);
                listviewDoanhThu.Items.Add("Đến " + dateE);
                listviewDoanhThu.Items.Add(dr["doanhthu"].ToString());

            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ////chartDS.ResetAutoValues();
            Connection db = new Connection();
            db.conn.Open();
            SqlCommand cmd = new SqlCommand();
            //Khai báo tên proc
            cmd.CommandText = "sh_DoanhThuTheoNgay";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.conn;

            //Khai báo các thông số
            cmd.Parameters.Add("@begin", SqlDbType.Date).Value = dtpBeginDate.Value;
            cmd.Parameters.Add("@end", SqlDbType.Date).Value = dtpEndDate.Value;

            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            db.conn.Close();
            chartDS.DataSource = ds;
            chartDS.Series["Doanh thu"].XValueMember = "dateofTotal";
            chartDS.Series["Doanh thu"].YValueMembers = "totalDate";
            chartDS.Titles.Add("DOANH THU THEO NGÀY");
        }
    }
}
