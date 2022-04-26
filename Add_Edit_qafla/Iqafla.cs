using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Add_qafla
{
    internal interface Iqafla
    {
         string code { set; get; }
         string name { set; get; }
         string number { set; get; }
         string national_id { set; get; }
         string diagnosis { set; get; }
         string carvan_reply { set; get; }
         string age { set; get; }
         string carvan_name { set; get; }
         string date { set; get; }
         string ceneter { set; get; }
         string govern { set; get; }
         string p_diagnosis { set; get; }
         string d_diagnosis { set; get; }
         string doctor_name { set; get; }
         string note { set; get; }
            
        string day { get; set; }
        string month { set; get; }
        string year { set; get; }
        

    }

}
