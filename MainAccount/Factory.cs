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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.MainAccount
{
    internal class Factory
    {
        private static Factory _factory = null;
  
        static public Factory setFactory()
        {
            if(_factory == null)
            {
                _factory = new Factory();
            }
            return _factory;
        }
        public void factory(string op)
        {
            show_all show = new show_all();
            switch (op)
            {
                case "Add":
                    Add add = new Add();
                    add.Show();
                    break;
                case "Show_All":
                    show.set(true);
                    show.Show();
                    break;
                case "Show_Accept":
                    WpfApp1.show_all_operations newwindow = new WpfApp1.show_all_operations();
                    newwindow.Show();
                    break ;
                case "Print":
                    export expo = new export();
                    expo.Show();
                    break;
                case "Search":
                    search se = new search();
                    se.Show();
                    break;
                case "Edit":
                    show.set(false);
                    show.Show();
                    break ;
            }
        }
    }
}
