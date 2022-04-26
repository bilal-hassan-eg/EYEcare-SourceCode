using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace WpfApp1.show_details_call_center
{
    internal class get_data_to_show
    {
        static public ArrayList data(string code, string AccountName)
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {AccountName}; Password=123");

            conn.Open();
            ArrayList dt = new ArrayList();
            string sql = $"SELECT * FROM {AccountName} WHERE [كود المريض]={code}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                for (int i = 0; i < data.FieldCount; i++)
                {
                    dt.Add(data[i]);
                }
            }
            conn.Close();
            return dt;
        }
    }
}

