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
using WpfApp1.call_center1;
using System.Data;
using WpfApp1.call_center1;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for call_center1_Account.xaml
    /// </summary>
    public partial class call_center1_Account : Window
    {
        public string set_type_text=null;
        public string Account_name;
        private factory _factory;
        public int state;
        public string order_data;
        public call_center1_Account(string account)
        {
            this.Account_name = account;
            InitializeComponent();
            _factory = factory.getInestance();
            _factory.account_Name = Account_name;
            order_data = "show_All";
            DataTable dt = _factory.getData(order_data);
            table.ItemsSource = dt.DefaultView;
            type.IsEnabled = false;
        }


        public void GetData()
        {
            if (order_data ==  "show_All")
            {
                _factory = factory.getInestance();
                _factory.account_Name = Account_name;
                DataTable dt = _factory.getData(order_data);
                table.ItemsSource = null;

                table.ItemsSource = dt.DefaultView;
            }
            if (order_data == "show_Accepted")
            {
                _factory = factory.getInestance();
                _factory.account_Name = Account_name;
                DataTable dt = _factory.getData(order_data);
                table.ItemsSource = null;

                table.ItemsSource = dt.DefaultView;
            }
            if (order_data == "show_showed")
            {
                _factory = factory.getInestance();
                _factory.account_Name = Account_name;
                DataTable dt = _factory.getData(order_data);
                table.ItemsSource = null;

                table.ItemsSource = dt.DefaultView;
            }
            if (order_data == "show_delayed")
            {
                _factory = factory.getInestance();
                _factory.account_Name = Account_name;
                table.SelectionChanged -= select_table;
                table.SelectionChanged += select_table;
                DataTable dt = _factory.getData(order_data);
                table.ItemsSource = null;

                table.ItemsSource = dt.DefaultView;
            }
            if (order_data == "show_Declined")
            {
                _factory = factory.getInestance();
                _factory.account_Name = Account_name;
                table.SelectionChanged -= select_table;
                table.SelectionChanged += select_table;
                DataTable dt = _factory.getData(order_data);
                table.ItemsSource = null;

                table.ItemsSource = dt.DefaultView;
            }
            if (order_data == "show_other")
            {
                _factory = factory.getInestance();
                _factory.account_Name = Account_name;
                table.SelectionChanged += select_table;
                DataTable dt = _factory.getData(order_data);
                table.ItemsSource = null;

                table.ItemsSource = dt.DefaultView;
            }
            if (order_data == "show_done")
            {
                _factory = factory.getInestance();
                _factory.account_Name = Account_name;
                table.SelectionChanged += select_table;
                DataTable dt = _factory.getData(order_data);
                table.ItemsSource = null;

                table.ItemsSource = dt.DefaultView;
            }
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void select_table(object sender, SelectionChangedEventArgs e)
        {

            if (set_type_text == "العمليات")
            {
                state = 1;
            }
            if (set_type_text == "العروض")
            {
                state = 2;
            }
            if (set_type_text == "العمليات المؤجلة")
            {
                state = 3;
            }
            if (set_type_text == "غير ذلك")
            {
                state = 4;
            }
            if (set_type_text == "العمليات الملغاة")
            {
                state = 5;
            }
            if (set_type_text == "جاري التواصل")
            {
                state = 6;
            }
            if (set_type_text == "اجريت")
            {
                state = 7;
            }
            var dt = table.SelectedItem;
            DataRowView row = (DataRowView)dt;
            if (row != null)
            {
                detatils_opertaion_callcenter show = new detatils_opertaion_callcenter(row.Row[0].ToString(),state);          
                show.Accountname = Account_name;
                show.GetData();
                show.Show();
                table.UnselectAll();
                this.Close();
            }
        }
        private void set_type(object sender, SelectionChangedEventArgs e)
        {
            var text = ((ComboBox)sender).SelectedItem;
            set_type_text = ((ComboBoxItem)text).Content.ToString();
            // table.SelectionChanged += select_table;
            if (set_type_text == "جاري التواصل")
            {
                order_data = "show_All";
            }
                if (set_type_text == "العمليات")
            {
                order_data = "show_Accepted";
            }
            if (set_type_text == "العروض")
            {
                order_data = "show_showed";
            }
            if (set_type_text == "العمليات المؤجلة")
            {
                order_data = "show_delayed";
            }
            if (set_type_text == "غير ذلك")
            {
                order_data = "show_other";
            }
            if (set_type_text == "العمليات الملغاة")
            {
                order_data = "show_Declined";
            }
            if (set_type_text == "اجريت")
            {
                order_data = "show_done";
            }
            GetData();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            call_center_dashboard_selelct main = new call_center_dashboard_selelct(Account_name);
            main.Show();
            this.Close();
        }
    }
}
