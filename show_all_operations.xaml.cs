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
using WpfApp1.show_All_operations;
using System.Data;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for show_all_operations.xaml
    /// </summary>
    public partial class show_all_operations : Window
    {
        string type_data;
        string filter_data;
        factory _fact = factory.getInestance();
        string[] date_array;
        public show_all_operations()
        {
            InitializeComponent();
            _fact.date = date_array;
            DataTable dt = _fact.getData("Show_All_Accepted");
         //   table.ItemsSource = dt==null ? dt.DefaultView : null;
        }


        private void filter(object sender, RoutedEventArgs e)
        {
            filter_data = ((RadioButton)sender).Name.ToString();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainAcount main = new MainAcount();
            main.Show();
            this.Close();
        }

        private void refresh(object sender, RoutedEventArgs e)
        {
            getData();
        }

        private void getData()
        {
            if (type_data == "العمليات")
            {
                _fact.date = date_array;
                DataTable dt = _fact.getData("Show_All_Accepted");
                table.ItemsSource = dt.DefaultView;

            }

            if (type_data == "العروض")
            {
                _fact.date = date_array;
                DataTable dt = _fact.getData("show_all_show");
                table.ItemsSource = dt.DefaultView;

            }
            if (type_data == "العمليات المؤجلة")
            {
                _fact.date = date_array;
                DataTable dt = _fact.getData("show_all_delay");
                table.ItemsSource = dt.DefaultView;

            }
            if (type_data == "العمليات الملغاة")
            {
                _fact.date = date_array;
                DataTable dt = _fact.getData("show_all_cancel");
                table.ItemsSource = dt.DefaultView;

            }
            if (type_data == "غير ذلك")
            {
                _fact.date = date_array;
                DataTable dt = _fact.getData("show_all_other");
                table.ItemsSource = dt.DefaultView;
            }
        }
        private void set_type(object sender, SelectionChangedEventArgs e)
        {
            var x = ((ComboBox)sender).SelectedItem;
            type_data = ((ComboBoxItem)x).Content.ToString();
            getData();
        }
    }
}
