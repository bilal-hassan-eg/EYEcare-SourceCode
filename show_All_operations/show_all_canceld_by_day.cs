using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1.show_All_operations
{
    internal class show_all_canceld_by_day
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");
        public DataTable getData(string[] date)
        {
            DataTable dt = new DataTable();
            conn.Open();
            string sql = $" select * from cancel_operations WHERE التاريخ =N'{date[1]}/{date[0]}/{date[2]}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            dt.Columns.Remove("رد القافلة");
            return dt;
        }
    }
}
