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

namespace WpfApp1.show_all_details
{
    public class Show_all_details
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");

        string name;
        string date;
        string place;
        public Show_all_details(string name,string date,string place)
        {
            this.name = name;
            this.date = date;
            this.place = place;
        }
        public DataTable getData()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string command = $"SELECT * FROM qafla_details WHERE [اسم القافلة]=N'{name}' AND التاريخ='{date}' AND المركز=N'{place}'";
                SqlCommand cmd = new SqlCommand(command, conn);
                SqlDataReader data = cmd.ExecuteReader();
                dt.Load(data);
                conn.Close();
                dt.Columns.Remove("رد القافلة");
                return dt;
            }
            catch
            {
                MessageBox.Show("البيانات غير موجودة");
            }
            return dt; 
        }
    }
}
