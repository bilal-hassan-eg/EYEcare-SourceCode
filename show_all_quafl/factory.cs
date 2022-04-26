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
using WpfApp1.show_all_quafl;
namespace WpfApp1.show_all_quafl
{
    internal class factory
    {
        public string[] date;
        public static factory _factory = null;
        public static factory getInetance()
        {
            if(_factory == null)
            {
                _factory = new factory();
            }
            return _factory;
        }
        public DataTable getData(string op)
        {
            switch (op)
            {
                case "All":
                    DataTable dt = show_All.getData();
                    return dt;
                case "Filter_day":
                    DataTable dt1 = show_all_by_day.getData(date);
                    return dt1;
                case "Filter_month":
                    DataTable dt2 = show_all_by_month.getData(date);
                    return dt2;
                case "Filter_year":
                    DataTable dt3 = show_all_by_year.getData(date);
                    return dt3;
            }
            return new DataTable();
        }
    }
}
