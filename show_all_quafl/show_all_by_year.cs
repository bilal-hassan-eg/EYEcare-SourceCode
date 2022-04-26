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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1.show_all_quafl
{
    internal class show_all_by_year
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");
        public static DataTable getData(string[] datearray)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sql = new SqlCommand($"select [اسم القافلة],[تاريخ القافلة],[مكان القافلة] from qafla_name WHERE السنة={datearray[2]}", conn);
            SqlDataReader cmd = sql.ExecuteReader();
            dt.Load(cmd);
            conn.Close();
            return dt;

        }
    }
}
