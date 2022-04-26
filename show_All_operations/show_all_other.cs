using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1.show_All_operations
{
    internal class show_all_other
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");

        public DataTable getdata()
        {
            DataTable dt = new DataTable();
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from other_operations", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            dt.Columns.Remove("رد القافلة");
            return dt;
        }
    }
}
