using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WpfApp1.show_details_call_center;
using WpfApp1.Add_qafla;
namespace WpfApp1.show_details_call_center
{
    class factory
    {
        static private factory _factory;
        private qafla _qafla;
        public string AccountName;
        string location;
        string data;
        string type_table;
        string note_other;
        static public factory getInestance()
        {
            if (_factory == null)
            {
                _factory = new factory();
            }
            return _factory;
        }
        public void setAccept_dalay_show(qafla qalfa,string data,string accountName,string location)
        {
            this._qafla=qalfa;
            this.location=location;
            this.AccountName=accountName;
            this.data = data;
        }
        public void setOther(qafla qafla,string accountName,string note)
        {
            this._qafla = qafla;
            this.AccountName = accountName;
            this.note_other = note;
        }
        public void setDone(qafla qalfa,string data,string accountName,string location,string table_from)
        {
            this._qafla = qalfa;
            this.location = location;
            this.AccountName = accountName;
            this.data = data;
            this.type_table = table_from;
        }
        public void AddData(string op)
        {
            switch (op)
            {
                case "Add_Accept":
                    Add_Accept_opertaion accept = new Add_Accept_opertaion(_qafla, data,AccountName,location);
                    accept.insert_Aceepted_operation();
                    break;
                case "Add_Delay":
                    Add_delay_operations delay = new Add_delay_operations(_qafla, data, AccountName, location);
                    delay.insert_delayed_operation();
                    break;
                case "Add_Show":
                    add_show_operations show = new add_show_operations(_qafla, data, AccountName, location);
                    show.insert_showed_operation();
                    break;
                case "Add_Other":
                    add_other_operaions other = new add_other_operaions(_qafla, AccountName, note_other);
                    other.add_other();
                    break;
                case "Add_cancel":
                    cancle_opeartion cancel = new cancle_opeartion(_qafla, AccountName);
                    cancel.cancel();
                    break;
                case "Add_done":
                    Add_done_operation done = new Add_done_operation(_qafla,data, AccountName,location,type_table);
                    done.insert_done_operations();
                    break;
            }
        }
    }
}
