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
using WpfApp1.MainAccount;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainAcount.xaml
    /// </summary>
    public partial class MainAcount : Window
    {
        Factory fact = Factory.setFactory();

        public MainAcount()
        {
            InitializeComponent();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            this.Hide();
            fact.factory("Add");
        }

        private void Show_All(object sender, RoutedEventArgs e)
        {
            this.Hide();
            fact.factory("Show_All");
        }

        private void Show_Accepted(object sender, RoutedEventArgs e)
        {
            this.Hide();
            fact.factory("Show_Accept");
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            this.Hide();
            fact.factory("Edit");
        }
        private void search(object sender, RoutedEventArgs e)
        {
            this.Hide();
            fact.factory("Search");
        }
        private void printer(object sender, RoutedEventArgs e)
        {
            this.Hide();
            fact.factory("Print");
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
