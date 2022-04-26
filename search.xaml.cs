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
using WpfApp1.search_all;
using System.Data;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for search.xaml
    /// </summary>
    public partial class search : Window
    {
        string name;
        string type_data;
        public search()
        {
            InitializeComponent();
        }

        private void search_data(object sender, RoutedEventArgs e)
        {
           
            if (type_data == "المؤكد")
            {
                //search_between_tables search = new search_between_tables(name);
                DataTable dt = search_between_tables.search_accept(patient_name.Text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
            else if(type_data == "الملغي")
            {
                DataTable dt = search_between_tables.search_cancel(patient_name.Text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
            else if(type_data == "العروض")
            {
                DataTable dt = search_between_tables.search_show(patient_name.Text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
            else if(type_data == "المؤجل")
            {
                DataTable dt = search_between_tables.search_delay(patient_name.Text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
            else if(type_data == "غير ذلك")
            {
                DataTable dt = search_between_tables.search_other(patient_name.Text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
            else if(type_data == "كول سنتر 1")
            {
                DataTable dt = search_between_tables.search_accounts("call_center1",patient_name.Text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
            else if (type_data == "كول سنتر 2")
            {
                DataTable dt = search_between_tables.search_accounts("call_center2",patient_name.Text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
            else if (type_data == "كول سنتر 3")
            {
                DataTable dt = search_between_tables.search_accounts("call_center3",patient_name.Text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("الرجاء ادخال البيانات");
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainAcount main = new MainAcount();
            main.Show();
            this.Close();
        }

        private void select_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = ((ComboBox)sender).SelectedItem;
            type_data = ((ComboBoxItem)x).Content.ToString();
        }

        private void patient_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            name = patient_name.Text;
        }
    }
}
