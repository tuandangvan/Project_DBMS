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
        private SqlDataAdapter adapter = null;
        private DataTable dt = null;
        public Connection()
        {
            conn = new SqlConnection(ConnStr);
            cmd = conn.CreateCommand();
            dt = new DataTable();
            //err = "";

        }

        public bool ExecuteProcedure(string sqlProcedure, CommandType ct, List<SqlParameter> parameters)
        {
            bool fail = false;
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
                fail = true;
            }
            finally
            {
                conn.Close();
            }
            return fail;
        }
    }
    
}
