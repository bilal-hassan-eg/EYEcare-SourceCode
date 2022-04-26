using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1.export_pdf
{
    internal class get_data_qafla
    {
        string code = string.Empty;
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");

        public DataTable getData(string to, string from)
        {
            conn.Open();
            DataTable dt = new DataTable();
            int time_loop = Convert.ToInt32(to) - Convert.ToInt32(from);
            for (int i = Convert.ToInt32(from); i <= Convert.ToInt32(to);i++) 
            {
                int count = i;
                code = Convert.ToString(count);
                string sql = $"SELECT * FROM qafla_details WHERE [كود المريض]=N'{code}'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                count ++;
                code = string.Empty;
            }
            dt.Columns.Remove("رد القافلة");
            conn.Close();
            return dt;
        }
    }
}
