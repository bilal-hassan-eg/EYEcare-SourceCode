using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.call_center_dashboard
{
    internal class factory_call_center_dashboard
    {
        string op = string.Empty;
        string account_name;
        public factory_call_center_dashboard(string account,string op)
        {
            this.account_name = account;
            this.op = op;
        }
        public void getData()
        {
            switch (op)
            {
                case "show_All":
                    call_center1_Account show1 = new call_center1_Account(account_name);
                    show1.order_data = "show_All";
                    show1.type.SelectedIndex = 0;
                    show1.GetData();
                    show1.Show();
                    break;
                case "show_other":
                    call_center1_Account show2 = new call_center1_Account(account_name);
                    show2.order_data = "show_other";
                    show2.type.SelectedIndex = 5;
                    show2.GetData();
                    show2.Show();
                    break;
                case "show_Declined":
                    call_center1_Account show3 = new call_center1_Account(account_name);
                    show3.order_data = "show_Declined";
                    show3.type.SelectedIndex = 4;
                    show3.GetData();
                    show3.Show();
                    break;
                case "show_showed":
                    call_center1_Account show4 = new call_center1_Account(account_name);
                    show4.order_data = "show_showed";
                    show4.type.SelectedIndex = 2;
                    show4.GetData();
                    show4.Show();
                    break;
                case "show_delayed":
                    call_center1_Account show5 = new call_center1_Account(account_name);
                    show5.order_data = "show_delayed";
                    show5.type.SelectedIndex = 3;
                    show5.GetData();
                    show5.Show();
                    break;
                case "show_done":
                    call_center1_Account show6 = new call_center1_Account(account_name);
                    show6.order_data = "show_done";
                    show6.type.SelectedIndex = 6;
                    show6.GetData();
                    show6.Show();
                    break;
                case "show_Accepted":
                    call_center1_Account show7 = new call_center1_Account(account_name);
                    show7.order_data = "show_Accepted";
                    show7.type.SelectedIndex = 1;
                    show7.GetData();
                    show7.Show();
                    break;
            }
        }
    }
}
