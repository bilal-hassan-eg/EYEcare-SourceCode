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

namespace WpfApp1.Add_qafla
{
    public class qafla : Iqafla
    {
        private static qafla _qafla = null;
        public static qafla setQafla()
        {
            if (_qafla == null)
            {
                _qafla = new qafla();
            }
            return _qafla;
        }
        public string code { set; get; }
        public string name { set; get; }
        public string number { set; get; }
        public string national_id { set; get; }
        public string diagnosis { set; get; }
        public string carvan_reply { set; get; }
        public string age { set; get; }
        public string carva_name { set; get; }
        public string date { set; get; }
        public string ceneter { set; get; }
        public string govern { set; get; }
        public string p_diagnosis { set; get; }
        public string d_diagnosis { set; get; }
        public string doctor_name { set; get; }
        public string note { set; get; }
        public string carvan_name { get; set; }
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
    }
}
