using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Add_qafla
{
    internal interface IBuilder
    {
        void Add_patient(string code, string name, string number, string age, string nationlid, string govern, string center);
        public void Add_carva(string carvan_name, string carvan_reply, string day, string month, string year);
        void Add(string date, string diagnosis, string p_diagnosis, string d_diagnosis, string doctor_name, string note);
    }
}
