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
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1.serial_check
{
    internal class check_regiester
    {


        public int check()
        {
            string name = File.ReadAllText(@"C:\path.txt");

                if (name == "0")
                {
                    return 0;
                }
                if (name == "1")
                {
                    return 1;
                }
            return 2;
        }
    }
}
