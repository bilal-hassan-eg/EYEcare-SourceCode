using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WpfApp1.call_center1;
namespace WpfApp1.show_All_operations
{
    internal class factory
    {
        private static factory _factory = null;
        public string[] date;
        public static factory getInestance()
        {
            if (_factory == null)
            {
                _factory = new factory();
            }
            return _factory;
        }
        public DataTable getData(string op)
        {
            DataTable dt = null;
            switch (op)
            {
                /*     case "Show_All_All":
                         show_all s1 = new show_all();
                         dt = s1.getData();
                         return dt;
                     case "Show_Acept_All":
                         show_all_accepted s2 = new show_all_accepted(); 
                         dt = s2.getData();
                         return dt;
                     case "Show_Cancel_All":
                         show_all_canceld s3 = new show_all_canceld();
                         dt = s3.getData();
                         return dt;
                     case "Show_All_Day":
                         show_all_by_day s4 = new show_all_by_day();
                         dt = s4.getData(date);
                         return dt;
                     case "Show_Acept_Day":
                         show_all_by_day_Acepted s5 = new show_all_by_day_Acepted();
                         dt = s5.getData(date);
                         return dt;
                     case "Show_Cancel_Day":
                         show_all_canceld_by_day s6 = new show_all_canceld_by_day();
                         dt = s6.getData(date);
                         return dt;
                 */
                case "Show_All_Accepted":
                    show_all_accepted show = new show_all_accepted();
                    dt = show.getData();
                    return dt;
                case "show_all_cancel":
                    show_all_canceld show1 = new show_all_canceld();
                    dt = show1.getData();
                    return dt;
                case "show_all_delay":
                    show_all_delay show2 = new show_all_delay();
                    dt = show2.getdata();
                    return dt;
                case "show_all_other":
                    show_all_other show3 = new show_all_other();
                    dt = show3.getdata();
                    return dt;
                case "show_all_show":
                    show_all_show show4 = new show_all_show();
                    dt = show4.getdata();
                    return dt;
            }
            return null;
        }
    }
}
