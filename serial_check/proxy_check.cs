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
using System.Data;
using System.Data.SQLite;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp.Config;
using System.Net.NetworkInformation;
using System.Management;
using System.IO;
namespace WpfApp1.serial_check
{
    internal class proxy_check
    {
        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "m9aVv7xzUfpQtXHAZjdPdNmJZmAtnrsTrouhJRih",
            BasePath = "https://com-inf-ca85f.firebaseio.com/"
        };
        IFirebaseClient client;

        string[] serial_array;
        string serial_enter;
        public proxy_check(string[] serial,string enter_serial)
        {
            this.serial_array = serial;
            this.serial_enter = enter_serial;
        }
        public int check()
        {
            if (serial_array[0] == serial_enter)
            {
                if (serial_array[1] != "0")
                {
                    File.WriteAllText(@"C:\path.txt", "1");
                    client = new FireSharp.FirebaseClient(fcon);
                    string data = serial_array[0] + "_" + Convert.ToString((Convert.ToInt32(serial_array[1]) - 1));
                    client.Set("/verfy/eyecare/verf/", data);
                    MainWindow main = new MainWindow();
                    main.Show();
                    return 1;
                }
                if(serial_array[1] == "0")
                {
                    MessageBox.Show("كود التفعيل غير صالح");
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}
