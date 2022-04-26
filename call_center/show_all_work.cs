using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1.call_center1
{
    internal class show_all_work
    {
        string Account_Name;
        public void setAcount(string account)
        {
            Account_Name = account;
        }
        public DataTable getdata()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {Account_Name}; Password=123");
            conn.Open();
            DataTable dt = new DataTable();
            string sql = $"SELECT * FROM {Account_Name} WHERE تم IS NULL";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            dt.Columns.Remove("رد القافلة");
            return dt;
        }
    }
}
