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
using System.Data.SqlClient;
using System.Data;
using WpfApp1.show_all_details;


namespace WpfApp1
{

    public partial class show_details : Window
    {
        public bool stat = false;
        public string date;
        public string name;
        string place;
        List<string> list_codes = new List<string>();
        public show_details(string date,string name,bool x,string place)
        {
   
            InitializeComponent();
            this.stat = x;
            this.date = date;
            this.name = name;
            if (!this.stat)
            {
                grid_select_workspace.Visibility = Visibility.Collapsed;
                list.Visibility = Visibility.Collapsed;
            }
            else
            {
                grid_select_workspace.Visibility = Visibility.Visible;
                list.Visibility = Visibility.Visible;
            }
            string[] arr_place = place.Split(' ');

            Show_all_details show = new Show_all_details(name, date,arr_place[0]);
            
             DataTable dt = show.getData();
             table.ItemsSource = dt.DefaultView;
        }


        private void back(object sender, RoutedEventArgs e)
        {
            show_all show = new show_all();
            show.Show();
            this.Close();

        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            string[] arr_place = place.Split(' ');
            
            Show_all_details show = new Show_all_details(name, date, arr_place[0]);
            DataTable dt = show.getData();
            table.ItemsSource = dt.DefaultView;
            
        }

        private void Add_workspace(object sender, RoutedEventArgs e)
        {
            if(to.Text!="" && from.Text!="" && work_Account.Text != "")
            {
                int to_int = Convert.ToInt32(to.Text);
                int from_int = Convert.ToInt32(from.Text);

                add_workspace work = new add_workspace(to_int, from_int, work_Account.Text);
                work.insert_to_call_center();
                to.Text = from.Text = work_Account.Text = null;
            }else if (list_codes.Count>0)
            {
                add_workspace add = new add_workspace(0, 0, work_Account.Text);
                add.update_sql_list(list_codes);
                list.ItemsSource = null;
            }
            else
            {
                MessageBox.Show("الرجاء ادخال خانة من و الي و رقم الحساب");
            }

        }

        private void Edit_Data(object sender, SelectionChangedEventArgs e)
        {
            if (!stat)
            {
                var dt = table.SelectedItem;
                DataRowView row = (DataRowView)dt;

                Add edit = new Add();
                edit.setStat(stat);
                edit.Edit_text_button();
                edit.getData(row.Row[0].ToString());
                this.Close();
                edit.Show();
            }
            if(stat)
            {
                var dt = table.SelectedItem;
                DataRowView row = (DataRowView)dt;
                int x = list_codes.IndexOf(row.Row[0].ToString());
                if(x == -1)
                {
                    list_codes.Add(row.Row[0].ToString());
                }
                else
                {
                    MessageBox.Show($" {row.Row[0].ToString()} لقد تم اضافة ملف رقم");
                }
                table.SelectedCells.Clear();
                list.ItemsSource = null;
                list.ItemsSource = list_codes;
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int var2;
            if (list.SelectedItems.Count > 0)
            {
                 var2 = list.Items.IndexOf(list.SelectedItems[0]);
                 list_codes.RemoveAt(var2);
            }
            list.ItemsSource = null;
            list.ItemsSource = list_codes;
        }
    }
}
