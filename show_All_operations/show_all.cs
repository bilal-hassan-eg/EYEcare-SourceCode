using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1.show_All_operations
{
    internal class show_all
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");
        public DataTable getData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand($"select * from Accepted_operations", conn);
            SqlDataReader data = cmd.ExecuteReader();
            dt.Load(data);
            conn.Close();
            dt.Columns.Remove("رد القافلة");
            return dt;

        }
    }
}
