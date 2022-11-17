using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLBanLapTop.DBPlayer
{
    public class Connection
    {
        public string ConnStr = "Data Source=(local)" +
            ";Initial Catalog=QuanLyLapTop" +
            ";Integrated Security=True";

        public SqlConnection conn = null;
        private SqlCommand cmd = null;
        public Connection()
        {
            conn = new SqlConnection(ConnStr);
            cmd = conn.CreateCommand();
        }

        public bool Check(string txt, string table, string colum)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            string sql = "Select * From " + table + " where " + table + "." + colum + " ='" + txt + "'";

            SqlDataAdapter daCheck;
            DataTable dtCheck;
            daCheck = new SqlDataAdapter(sql, conn);
            dtCheck = new DataTable();
            daCheck.Fill(dtCheck);

            if (dtCheck.Rows.Count > 0)
                return true;

            return false;
        }


        public bool ExecuteProcedure(string sqlProcedure, CommandType ct, List<SqlParameter> parameters)
        {
            bool check = true;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            //cmd = new SqlCommand();
            cmd.CommandText = sqlProcedure;
            cmd.CommandType = ct;
            cmd.Parameters.Clear();
            foreach (SqlParameter i in parameters)
            {
                cmd.Parameters.Add(i);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                check = false;//có lỗi
            }
            finally
            {
                conn.Close();
            }

            return check;
        }
    }
    
}
