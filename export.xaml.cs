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
using WpfApp1.export_pdf;
using System.Data;
using WpfApp1.export_pdf;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for export.xaml
    /// </summary>
    public partial class export : Window
    {
        factory _factory;
        string to_text;
        string from_text;
        string set_type_text;
        public export()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void get_data(object sender, RoutedEventArgs e)
        {
            to_text = to.Text;
            from_text = from.Text;

            if (to_text == "" && from_text == "" && set_type_text == "" )
            {
                MessageBox.Show("الرجاء ادخال البيانات");
            }
            else
            {
                _factory = factory.qetInestance();
                _factory.to = to_text;
                _factory.from = from_text;
                dt.Clear();
                dt =_factory.switch_operation("get_"+set_type_text);
                table.ItemsSource = null;
                table.ItemsSource = dt.DefaultView;
            }
        }
        private void print(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            WpfApp1.export_pdf.export.ToCSV(dt, path + $"/{file_name.Text}.csv");
            MessageBox.Show("تم حفظ الملف علي سطح المكتب");
        }
        private void back(object sender, RoutedEventArgs e)
        {
            MainAcount main = new MainAcount();
            main.Show();
            this.Close();
        }
        private void set_type(object sender, SelectionChangedEventArgs e)
        {
            var x = ((ComboBox)sender).SelectedItem;
            set_type_text = ((ComboBoxItem)x).Name.ToString();
        }


    }
}
