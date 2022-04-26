using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WpfApp1.call_center;
namespace WpfApp1.call_center1
{
    internal class factory
    {
        private static factory _factory = null;
        public string account_Name;
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
                case "show_All":
                    show_all_work show = new show_all_work();
                    show.setAcount(account_Name);
                    dt = show.getdata();
                    return dt;
                case "show_Accepted":
                    show_accepted_work show1 = new show_accepted_work();
                    show1.setAcount(account_Name);
                    dt = show1.getData();
                    return dt;
                case "show_Declined":
                    show_canceled_work show2 = new show_canceled_work();
                    show2.setAcount(account_Name);
                    dt = show2.getData();
                    return dt;
                case "show_delayed":
                    show_all_delay show3 = new show_all_delay();
                    show3.setAcount(account_Name);
                    dt = show3.getdata();
                    return dt;
                case "show_other":
                    show_all_other show4 = new show_all_other();
                    show4.setAcount(account_Name);
                    dt = show4.getdata();
                    return dt;
                case "show_showed":
                    show_all_show show5 = new show_all_show();
                    show5.setAcount(account_Name);
                    dt = show5.getdata();
                    return dt;
                case "show_done":
                    show_all_done show6 = new show_all_done();
                    show6.setAcount(account_Name);
                    dt = show6.getData();
                    return dt;
            }
            return null;
        }
    }
}
