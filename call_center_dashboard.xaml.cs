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
using WpfApp1.call_center_dashboard;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for call_center_dashboard.xaml
    /// </summary>
    public partial class call_center_dashboard_selelct : Window
    {
        string account_name;

        public call_center_dashboard_selelct(string account_name)
        {
            InitializeComponent();
            this.account_name = account_name; 
        }

        private void show(object sender, RoutedEventArgs e)
        {
            factory_call_center_dashboard fact = new factory_call_center_dashboard(account_name, ((Button)sender).Name.ToString());
            fact.getData();
            this.Close();
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
