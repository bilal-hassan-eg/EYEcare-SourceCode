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
    /// Interaction logic for other_operation_add.xaml
    /// </summary>
    public partial class other_operation_add : Window
    {
        private qafla _qafla;
        private string AccountName;
        string set_type_text;
        public bool state;
        public int state_from_details;
        public string code;
        public other_operation_add(int state_from_details,string data ,qafla qafla , string AccountName,bool state)
        {
            InitializeComponent();
            this._qafla = qafla;
            this.AccountName = AccountName;
            note_manual_enter_label.Visibility = Visibility.Collapsed;
            note_manual_enter_text.Visibility = Visibility.Collapsed;
            this.state = state;
            if (!state)
            {
                btn1.Visibility = Visibility.Visible;
                btn2.Visibility = Visibility.Collapsed;
            }
            if (state)
            {
                btn2.Visibility = Visibility.Visible;
                btn1.Visibility = Visibility.Collapsed;
            }
            this.state_from_details = state_from_details;
            this.code = data;
        }

        private void add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (note_manual_enter_text.IsVisible)
            {
                set_type_text = note_manual_enter_text.Text;
            }
            else
            {
                var item = combo.SelectedItem;
                set_type_text = ((ComboBoxItem)item).Content.ToString();
            }

                if (set_type_text != "")
                {
                    add_other_operaions other = new add_other_operaions(_qafla, AccountName, set_type_text);
                    other.add_other();
                    MessageBox.Show("تم");
                    call_center1_Account test = new call_center1_Account(AccountName);
                    test.order_data = "show_All";
                    test.GetData();
                    test.type.SelectedIndex = 0;
                    test.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("برجاء ادخال البيانات");
                }
            }
            catch
            {
                MessageBox.Show("برجاء ادخال البيانات");

            }


        }

        private void edit_other(object sender, RoutedEventArgs e)
        {
            try
            {
                if (note_manual_enter_text.IsVisible)
            {
                set_type_text = note_manual_enter_text.Text;
            }
            else
            {
                var item = combo.SelectedItem;
                set_type_text = ((ComboBoxItem)item).Content.ToString();
            }

                if (set_type_text != " ")
                {
                    Edit_Other edit = new Edit_Other(set_type_text, _qafla.code, AccountName);
                    edit.updateSql();
                    MessageBox.Show("تم");
                    call_center1_Account test = new call_center1_Account(AccountName);
                    test.order_data = "show_other";
                    test.GetData();
                    test.type.SelectedIndex = 5;
                    test.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("برجاء ادخال البيانات");
                }
            }
            catch {
                MessageBox.Show("برجاء ادخال البيانات");
            }


        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            cancle_opeartion cancel = new cancle_opeartion(_qafla,AccountName);
            cancel.cancel();
            MessageBox.Show("تم");
            call_center1_Account test = new call_center1_Account(AccountName);
            test.order_data = "show_All";
            test.GetData();
            test.type.SelectedIndex = 0;
            test.Show();
            this.Close();

        }

        private void type(object sender, SelectionChangedEventArgs e)
        {
            var text = ((ComboBox)sender).SelectedItem;
            set_type_text = ((ComboBoxItem)text).Content.ToString();
            if (set_type_text == "اخري")
            {
                note_manual_enter_text.Visibility = Visibility.Visible;
                note_manual_enter_label.Visibility = Visibility.Visible;
            }
            else
            {
                note_manual_enter_label.Visibility = Visibility.Collapsed;
                note_manual_enter_text.Visibility = Visibility.Collapsed;
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            detatils_opertaion_callcenter back = new detatils_opertaion_callcenter(code, state_from_details);
            back.Accountname =  AccountName;
            back.GetData();
            back.Show();
            this.Close();
        }
    }
}
