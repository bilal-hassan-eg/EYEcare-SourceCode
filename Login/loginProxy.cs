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

namespace WpfApp1.Login
{
    public class LoginProxy
    {
        private string pass;
        private string user;

        public LoginProxy(string pass,string user)
        {
            this.pass = pass;
            this.user = user;
        }
        public bool Enter()
        {
            if (user != "" && pass != "")
            {
                if(user == "رئيسي" && pass == "123")
                {
                    MainAcount main = new MainAcount();
                    main.Show();
                    return true;

                }
                else if (user == "كول سنتر 1" && pass == "111")
                {
                    call_center_dashboard_selelct center1 = new call_center_dashboard_selelct("call_center1");
                    center1.Show();
                    
                    return true;

                }
                else if (user == "كول سنتر 2" && pass == "222")
                {
                    call_center_dashboard_selelct center2 = new call_center_dashboard_selelct("call_center2");
                    center2.Show();
                    return true;

                }
                else if (user == "كول سنتر 3" && pass == "333")
                {
                    call_center_dashboard_selelct center2 = new call_center_dashboard_selelct("call_center3");
                    center2.Show();
                    return true;

                }
                else if (user == "حسابات" && pass == "221")
                {
                    MessageBox.Show("الحسابات");
                    return true;

                }
                else
                {
                    MessageBox.Show("اسم المستخدم او كلمة المرور خطأ");
                    return false;

                }
            }
            else
            {
                MessageBox.Show("برجاء ادخال اسم المستخدم وكلمة المرور");
                return false;

            }

        }
    }
}
