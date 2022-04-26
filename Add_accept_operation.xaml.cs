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
using WpfApp1.show_details_call_center;
using WpfApp1.Add_qafla;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Add_accept_operation.xaml
    /// </summary>
    public partial class Add_accept_operation : Window
    {
        public bool state_order_to_update = false;
        private factory _factory;
        public int state;
        public string data;
        private qafla _qafla;
        private string account_name;
        public string code;
        public int state_from_details_window;
        public int state_if_done { get; set; }
        public Add_accept_operation(int state_from_details_window, string code ,qafla qafla, string account, int state)
        {
            this.state = state;
            _qafla = qafla;
            this.code = code;
            account_name = account;
            InitializeComponent();
            state_order_to_update = false;
            state_if_done = 0;
            this.state_from_details_window = state_from_details_window;
            switch (state)
            {
                case 0:
                    text_to_change.Content = "تاريخ الزيارة";
                    break;
                case 1:
                    text_to_change.Content = "تاريخ التأجيل";
                    break;
                case 2:
                    text_to_change.Content = "تاريخ العرض";
                    break;
                case 4:
                    text_to_change.Content = "تاريخ الإجراء";
                    break;
              
            }
        }

        public void Add()
        {
            if (doctor.Text != "" && time.Text != "" && center.Text != "")
            {
                switch (state)
                {
                    case 0:
                        data = $"{doctor.Text},{time.Text}";
                        _factory = factory.getInestance();
                        _factory.setAccept_dalay_show(_qafla, data, account_name, center.Text);
                        _factory.AddData("Add_Accept");
                        MessageBox.Show("تم");
                        call_center1_Account call = new call_center1_Account(account_name);
                        call.order_data = "show_All";
                        call.GetData();
                        call.type.SelectedIndex = 0;
                        call.Show();
                        state_if_done = 1;
                        break;
                    case 1:
                        data = $"{doctor.Text},{time.Text}";
                        _factory = factory.getInestance();
                        _factory.setAccept_dalay_show(_qafla, data, account_name, center.Text);
                        _factory.AddData("Add_Delay");
                        MessageBox.Show("تم");
                        call_center1_Account call1 = new call_center1_Account(account_name);
                        call1.order_data = "show_All";
                        call1.type.SelectedIndex = 0;
                        call1.GetData();
                        call1.Show();

                        break;
                    case 2:
                        data = $"{doctor.Text},{time.Text}";
                        _factory = factory.getInestance();
                        _factory.setAccept_dalay_show(_qafla, data, account_name, center.Text);
                        _factory.AddData("Add_Show");
                        MessageBox.Show("تم");
                        call_center1_Account call2 = new call_center1_Account(account_name);
                        call2.order_data = "show_All";
                        call2.type.SelectedIndex = 0;
                        call2.GetData();
                        call2.Show();

                        break;
                    case 3:
                        string[] date = time.Text.Split('/');
                        Edit_operationcs edit = new Edit_operationcs(doctor.Text, center.Text, date, _qafla.code, account_name);
                        
                         edit.update_accept_sql();
                         edit.update_delay_sql();
                         edit.update_show_sql();
                         edit.update_done_sql();
                        int state_back = edit.type;
                        MessageBox.Show("تم");

                        call_center1_Account call4 = new call_center1_Account(account_name);
                        if (state_from_details_window == 2)
                        {
                            call4.order_data = "show_showed";
                            call4.type.SelectedIndex = 2;
                        }
                        if (state_from_details_window == 3)
                        {
                            call4.order_data = "show_delayed";
                            call4.type.SelectedIndex = 3;
                        }
                        if (state_from_details_window == 1)
                        {
                            call4.order_data = "show_Accepted";
                            call4.type.SelectedIndex = 1;
                        }
                        if (state_from_details_window == 7)
                        {
                            call4.order_data = "show_done";
                            call4.type.SelectedIndex = 6;
                        }
                        call4.GetData();

                        call4.Show();
                        break;
                    case 4:
                        data = $"{doctor.Text},{time.Text}";
                        _factory = factory.getInestance();
                        string type_table = string.Empty;
                        if (this.state == 2)
                        {
                            type_table = "العروض";
                        }
                        else if (this.state == 1)
                        {
                            type_table = "المؤجل";
                        }
                        else if (this.state == 0)
                        {
                            type_table = "المؤكد";
                        }
                        _factory.setDone(_qafla, data, account_name, center.Text, type_table);
                        _factory.AddData("Add_done");
                        MessageBox.Show("تم");
                        call_center1_Account call5 = new call_center1_Account(account_name);
                        call5.order_data = "show_All";
                        call5.GetData();
                        call5.type.SelectedIndex = 0;
                        call5.Show();
                        state_if_done = 1;

                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("الرجاء  ادخال البيانات");
                
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            detatils_opertaion_callcenter back = new detatils_opertaion_callcenter(code, state_from_details_window);
            back.Accountname = account_name;
            back.GetData();
            back.Show();
            this.Close();
        }
    }
}
