using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLBanLapTop.DBPlayer
{
    public class Connection
    {
        private string ConnStr = "Data Source=(local)" +
            ";Initial Catalog=QuanLyLapTop" +
            ";Integrated Security=True";

        private SqlConnection conn = null;
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
            bool f = false;
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
                f = true;
            }
            catch (SqlException ex)
            {
                
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
    }
    
}
