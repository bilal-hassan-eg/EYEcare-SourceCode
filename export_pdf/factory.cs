using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace WpfApp1.export_pdf
{
    internal class factory
    {
        private static factory _factory=null;
        public DataTable dt_to_export;
        public string from;
        public string to;
        public static factory qetInestance()
        {
            if (_factory == null)
            {
                _factory = new factory();
            }
            return _factory;
        }
        public DataTable switch_operation(string op)
        {
            DataTable dt = new DataTable();
            switch (op)
            {
                case "get_qafla":
                    get_data_qafla get_qafla = new get_data_qafla();
                    dt.Clear();
                    dt = get_qafla.getData(to,from); 
                    return dt;
                case "get_operation":
                    qet_data_from_operations get_operation_accept = new qet_data_from_operations();
                    dt.Clear();
                    dt = get_operation_accept.getData(to,from, "Accepted_operations");
                    return dt;
                case "get_delay":
                    qet_data_from_operations get_operation_delay = new qet_data_from_operations();
                    dt.Clear();
                    dt = get_operation_delay.getData(to, from, "delay_operations");
                    return dt;
                case "get_cancel":
                    qet_data_from_operations get_operation_cancel = new qet_data_from_operations();
                    dt.Clear();
                    dt = get_operation_cancel.getData(to, from, "cancel_operations");
                    return dt;
                case "get_show":
                    qet_data_from_operations get_operation_show = new qet_data_from_operations();
                    dt.Clear();
                    dt = get_operation_show.getData(to, from, "Showed_operations");
                    return dt;
                case "get_other":
                    qet_data_from_operations get_operation_other = new qet_data_from_operations();
                    dt.Clear();
                    dt = get_operation_other.getData(to, from, "other_operations");
                    return dt;
            }
            return dt;
        }

    }
}
