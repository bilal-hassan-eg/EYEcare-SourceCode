using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace WpfApp1.Add_qafla
{
    internal class get_data_to_edit
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");

        static public ArrayList data(string code)
        {
            conn.Open();
            ArrayList dt = new ArrayList();
            string sql = $"SELECT * FROM qafla_details WHERE [كود المريض]={code}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                for(int i=0; i<data.FieldCount; i++)
                {
                    dt.Add(data[i]);
                }
            }
            conn.Close();
            return dt;
        }
    }
}
