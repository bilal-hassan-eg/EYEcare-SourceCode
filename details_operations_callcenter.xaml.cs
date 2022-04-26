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
using System.Collections;
using WpfApp1.show_details_call_center;
using WpfApp1.Add_qafla;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for details_.xaml
    /// </summary>
    public partial class detatils_opertaion_callcenter : Window 
    {
        string data;
        private qafla _qafla = qafla.setQafla();
        public string Accountname;
        public int state;
        public detatils_opertaion_callcenter(string data,int state)
        {
            this.state = state;
            InitializeComponent();
            this.data = data;
          //  check_done.Visibility = Visibility.Collapsed;
            if(state == 7)
            {
                btn_text0.Text = "تعديل";
                btn0.Click -= add_done_operation;
                btn0.Click += edit;
            }
            if (state == 1)
            {
           //     check_done.Visibility = Visibility.Visible;
                btn_text1.Text = "تعديل";
                btn.Click -= add;
                btn.Click += edit;
                
            }
            if (state == 2)
            {
                btn_text2.Text = "تعديل";
                btn1.Click -= show;
                btn1.Click += edit;

            }
            if (state == 3)
            {
                btn_text4.Text = "تعديل";
                btn2.Click -= delay;
                btn2.Click += edit;

            }
            if (state == 4)
            {
                btn_text3.Text = "تعديل";
                btn3.Click -= other;
                btn3.Click += editOther;

            }
        }

        public void GetData()
        {

            if (data != null)
            {
                ArrayList dt = get_data_to_show.data(data,Accountname);
                string[] date_array = dt[8].ToString().Split('/');
                string[] d_diagnosis_array = dt[12].ToString().Split('/');

                //date.SelectedDate = new DateTime(int.Parse(date_array[2]), int.Parse(date_array[1]), int.Parse(date_array[0]));

                //d_diagnosis.SelectedDate = new DateTime(Convert.ToInt32(d_diagnosis_array[2]), Convert.ToInt32(d_diagnosis_array[1]), Convert.ToInt32(d_diagnosis_array[0]));
                date.Text = $"{date_array[0]}/{date_array[1]}/{date_array[2]}";
                if (d_diagnosis_array[0] != "")
                {
                    d_diagnosis.Text = $"{d_diagnosis_array[0]}/{d_diagnosis_array[1]}/{d_diagnosis_array[2]}";
                }

                code1.Text =  dt[0].ToString();
                 name.Text =  dt[1].ToString();
                 number.Text = dt[2].ToString();
                 national_id.Text = dt[3].ToString();
                 diagnosis.Text = dt[4].ToString();
               //  carvan_reply.Text = dt[5].ToString();
                 age.Text = dt[6].ToString();
                 carvan_name.Text = dt[7].ToString();
                 center.Text = dt[9].ToString();
                 govern.Text = dt[10].ToString();
                 p_diagnosis.Text = dt[11].ToString();
                 doctor_name.Text = dt[13].ToString();
                 note.Text = dt[14].ToString();

                _qafla.code = dt[0].ToString();
                _qafla.name = dt[1].ToString();
                _qafla.number = dt[2].ToString();
                _qafla.national_id = dt[3].ToString();
                _qafla.diagnosis = dt[4].ToString();
                _qafla.carvan_reply = dt[5].ToString();
                _qafla.age = dt[6].ToString();
                _qafla.carvan_name = dt[7].ToString();
                _qafla.date = dt[8].ToString();
                _qafla.ceneter = dt[9].ToString();
                _qafla.govern = dt[10].ToString();
                _qafla.p_diagnosis = dt[11].ToString();
                _qafla.d_diagnosis = dt[12].ToString();
                _qafla.doctor_name = dt[13].ToString();
                _qafla.note = dt[14].ToString();
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            call_center1_Account test = new call_center1_Account(Accountname);
            if(state ==1)
            {
                test.order_data = "show_Accepted";
                test.type.SelectedIndex = 1;
            }
            else if(state == 2)
            {
                test.order_data = "show_Showed";
                test.type.SelectedIndex = 2;
            }
            else if (state == 3)
            {
                test.order_data = "show_delayed";
                test.type.SelectedIndex = 3;
            }
            else if (state == 4)
            {
                test.order_data = "show_other";
                test.type.SelectedIndex = 5;
            }
            else if (state == 5)
            {
                test.order_data = "show_Declined";
                test.type.SelectedIndex = 4;
            }
            else if (state == 6)
            {
                test.order_data = "show_All";
                test.type.SelectedIndex = 0;
            }
            test.GetData();
            test.Show();
            this.Close();
        }

        private void show(object sender, RoutedEventArgs e)
        {
            Add_accept_operation show = new Add_accept_operation(state,data,_qafla, Accountname,2);

            show.Show();
            this.Close();

        }
        private void delay(object sender, RoutedEventArgs e)
        {
            Add_accept_operation show = new Add_accept_operation(state,data, _qafla, Accountname,1);

            show.Show();
            this.Close();

        }
        private void add(object sender, RoutedEventArgs e)
        {
            Add_accept_operation show = new Add_accept_operation(state,data, _qafla, Accountname,0);
            
            show.Show();
            this.Close();

        }

        private void other(object sender, RoutedEventArgs e)
        {
            other_operation_add other = new other_operation_add(state,data,_qafla, Accountname,false);

            other.Show();
            this.Close();

        }
        private void edit(object sender, RoutedEventArgs e)
        {
            Add_accept_operation show = new Add_accept_operation(state,data,_qafla, Accountname,3);

            show.Show();
            this.Close();

        }
        private void editOther(object sender, RoutedEventArgs e)
        {
            other_operation_add show = new other_operation_add(state,data,_qafla, Accountname, true);

            show.Show();

            this.Close();
        }
        private void to_conncet(object sender, RoutedEventArgs e)
        {
            to_connect_operation show = new to_connect_operation(_qafla, Accountname);
            show.to_connect();
            call_center1_Account call = new call_center1_Account(Accountname);
            call.order_data = "show_All";
            call.GetData();
            call.type.SelectedIndex = 0;
            call.Show();
            this.Close();

        }
        private void add_done_operation(object sender, RoutedEventArgs e)
        {
            Add_accept_operation show = new Add_accept_operation(state, data, _qafla, Accountname, 4);

            show.Show();
            this.Close();

        }

        
    }
}
