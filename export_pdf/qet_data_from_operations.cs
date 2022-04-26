using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
namespace WpfApp1.export_pdf
{
    internal class qet_data_from_operations
    {
        string code = string.Empty;
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");

        public DataTable getData(string to, string from,string table)
        {

            DataTable dt = new DataTable();
            int from_int = Convert.ToInt32(from);
            int to_int = Convert.ToInt32(to);
            int time_loop = Convert.ToInt32(to) - Convert.ToInt32(from);
            for (int i = from_int; i <= to_int; i++)
            {
                int count = i;
                code = Convert.ToString(count);
                DataTable dt1 = new DataTable();
                conn.Open();
                string sql = $"SELECT * FROM {table} WHERE [كود المريض]=N'{i}'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                conn.Close();
                
            }
            dt.Columns.Remove("رد القافلة");
            return dt;
        }
    }
}
