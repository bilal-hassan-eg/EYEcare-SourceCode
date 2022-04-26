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
using WpfApp1.show_all_quafl;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for show_all.xaml
    /// </summary>
    public partial class show_all : Window
    {
        static bool stat;
        static factory _Factory;
        static string filter_type;
        public show_all()
        {
            InitializeComponent();

            _Factory = factory.getInetance();

            DataTable dt = _Factory.getData("All");
            table.ItemsSource = dt.DefaultView;
           
        }
        public void set(bool x)
        {
            if (x)
            {
                stat = true;
            }
            else
            {
                stat = false;
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainAcount mainAcount = new MainAcount();
            mainAcount.Show();
            this.Close();
        }
        private void filter(object sender , RoutedEventArgs e)
        {
            filter_type = ((RadioButton)sender).Content.ToString();
        }
        private void date_selected(object sender, SelectionChangedEventArgs e)
        {
            get();
        }
        private void get()
        {
            string[] date_array = date.Text.Split('/');
            if (filter_type == "اليوم" && date.Text !="")
            {
                _Factory = factory.getInetance();
                _Factory.date = date_array;
                DataTable dt = _Factory.getData("Filter_day");
                table.ItemsSource = dt.DefaultView;
            }
            else if(filter_type == "الشهر" && date.Text != "")
            {
                _Factory = factory.getInetance();
                _Factory.date = date_array;
                DataTable dt = _Factory.getData("Filter_month");
                table.ItemsSource = dt.DefaultView;
            }
            else if(filter_type == "السنة" && date.Text != "")
            {
                _Factory = factory.getInetance();
                _Factory.date = date_array;
                DataTable dt = _Factory.getData("Filter_year");
                table.ItemsSource = dt.DefaultView;
            }
            else if(filter_type == "بدون" && date.Text != "")
            {
                _Factory = factory.getInetance();
                _Factory.date = date_array;
                DataTable dt = _Factory.getData("All");
                table.ItemsSource = dt.DefaultView;
            }
            else
            {
                _Factory = factory.getInetance();
                DataTable dt = _Factory.getData("All");
                table.ItemsSource = dt.DefaultView;
            }
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            get();
        }

        private void select_table(object sender, SelectionChangedEventArgs e)
        {
            var dt = table.SelectedItem;
            DataRowView row = (DataRowView)dt;
            show_details details = new show_details(row.Row[1].ToString(), row.Row[0].ToString(), stat,row.Row[2].ToString());


            details.Show();
            this.Hide();

        }
    }
}
