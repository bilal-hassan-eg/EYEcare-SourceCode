using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SQLite;
using System.IO;
namespace WpfApp1
{
    static class get_server
    {/// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
        public static string server()
        {
            string serv = File.ReadAllText("C:/server.txt");
            return serv;
        }
    }
}
