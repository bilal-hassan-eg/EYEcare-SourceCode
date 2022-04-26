using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1.call_center
{
    internal class show_all_done
    {
        public string Account_Name;

        public void setAcount(string account)
        {
            Account_Name = account;
        }

        public DataTable getData()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {Account_Name}; Password=123");

            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand($"select * from Done_operation WHERE الحساب=N'{Account_Name}'", conn);
            SqlDataReader data = cmd.ExecuteReader();
            dt.Load(data);
            conn.Close();
            dt.Columns.Remove("رد القافلة");
            return dt;

        }
    }
}
