using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Add_qafla
{
    internal class concerteBuilder : IBuilder
    {
        private qafla _qafla;
        
        public concerteBuilder(qafla _qafla)
        {
            this._qafla = _qafla;
        }
        public void Add(string date, string diagnosis, string p_diagnosis, string d_diagnosis, string doctor_name, string note)
        {
            _qafla.date = date;
            _qafla.diagnosis = diagnosis;
            _qafla.p_diagnosis = p_diagnosis ;
            _qafla.d_diagnosis = d_diagnosis ;
            _qafla.doctor_name = doctor_name;
            _qafla.note = note;
        }

        public void Add_carva(string carvan_name, string carvan_reply , string day , string month , string year)
        {
            _qafla.carvan_name = carvan_name;
            _qafla.carvan_reply = carvan_reply;
            _qafla.day = day;
            _qafla.month = month;
            _qafla.year = year;
        }

        public void Add_patient(string code, string name, string number, string age, string nationlid, string govern, string center)
        {
            _qafla.code = code;
            _qafla.name = name;
            _qafla.number = number;
            _qafla.age = age;
            _qafla.national_id = nationlid;
            _qafla.govern = govern;
            _qafla.ceneter = center;
        }
        public  qafla getResult()
        {
            return _qafla;
        }
    }
}
