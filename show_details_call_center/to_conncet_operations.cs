using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WpfApp1.Add_qafla;
namespace WpfApp1.show_details_call_center
{
    internal class to_connect_operation
    {
        public string AccountName;
        private Iqafla _qafla;
        public to_connect_operation(qafla qafla, string Accountname)
        {
            this._qafla = qafla;
            this.AccountName = Accountname;
        }
        public void to_connect()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {AccountName}; Password=123");

            conn.Open();
            try
            {
                string cm1 = $"DELETE FROM delay_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd2 = new SqlCommand(cm1, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            conn.Open();
            try
            {
                string cm1 = $"DELETE FROM Accepted_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd2 = new SqlCommand(cm1, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            conn.Open();
            try
            {
                string cm1 = $"DELETE FROM other_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd2 = new SqlCommand(cm1, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            conn.Open();
            try
            {
                string cm1 = $"DELETE FROM Showed_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd2 = new SqlCommand(cm1, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            try
            {
                string cm1 = $"DELETE FROM cancel_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd2 = new SqlCommand(cm1, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            conn.Open();
            try
            {
                string cm5 = $"DELETE FROM Done_operation WHERE [كود المريض]=N'{_qafla.code}'";
                SqlCommand cmd5 = new SqlCommand(cm5, conn);
                cmd5.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            conn.Open();
            string sql = $"UPDATE {AccountName} SET تم=NULL WHERE [كود المريض]={_qafla.code}";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
    }
}
