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
    internal class Edit_operationcs
    {
        string callcenter;
        string doctor;
        string center_operation;
        string code;
        string[] meet_time;
        public int type;
        public Edit_operationcs(string docotor,string center_operation,string[] meet,string code,string account)
        {
            this.code = code;
            this.doctor = docotor;
            this.center_operation = center_operation;
            this.meet_time = meet;
            this.callcenter = account;
        }

        public void update_show_sql()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {callcenter}; Password=123");

            conn.Open();
            try
            {

                string command2;

                command2 = $"UPDATE Showed_operations  SET " +
                    $"[اسم الدكتور]=N'{doctor}',[وقت المقابلة]=N'{meet_time[1] + "/" + meet_time[0] + "/" + meet_time[2]}'," +
                    $"الموقع=N'{center_operation}' WHERE [كود المريض]=N'{code}'";
                SqlCommand cmd1 = new SqlCommand(command2, conn);
                cmd1.ExecuteNonQuery();
                type = 1;
            }
            catch { }
            conn.Close();
        }
        public void update_delay_sql()
            {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {callcenter}; Password=123");
            conn.Open();

            try
            {

                    string command3 = $"UPDATE delay_operations  SET [اسم الدكتور]=N'{doctor}',[وقت المقابلة]=N'{meet_time[1] + "/" + meet_time[0] + "/" + meet_time[2]}',الموقع=N'{center_operation}'  WHERE [كود المريض]=N'{code}'";
                    SqlCommand cmd3 = new SqlCommand(command3, conn);
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                    type = 2;
            }
            catch { }
            conn.Close();
            }
        public void update_accept_sql()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {callcenter}; Password=123");
            conn.Open();

            {
                try
                {
                    string command4;
                    command4 = $"UPDATE Accepted_operations  SET [اسم الدكتور]=N'{doctor}',[وقت المقابلة]=N'{meet_time[1] + "/" + meet_time[0] + "/" + meet_time[2]}',الموقع=N'{center_operation}'  WHERE [كود المريض]=N'{code}'";

                    SqlCommand cmd2 = new SqlCommand(command4, conn);
                    cmd2.ExecuteNonQuery();
                    type = 3;
                }
                catch {  }
                conn.Close();
            }
        }
   /*     public int update_other_sql()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {callcenter}; Password=123");

            try
            {
                string command5;
                command5 = $"UPDATE other_operations  SET " +
                         $"[اسم الدكتور]=N'{doctor}',[وقت المقابلة]=N'{meet_time[1] + "/" + meet_time[0] + "/" + meet_time[2]}'," +
                            $"الموقع=N'{center_operation}'  WHERE [كود المريض]=N'{code}'";

                SqlCommand cmd4 = new SqlCommand(command5, conn);
                cmd4.ExecuteNonQuery();
                type = 4;
                conn.Close();
                return 4;
            }
            catch { }
            conn.Close();
            return 0;
        }*/
        public void update_done_sql()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {callcenter}; Password=123");
            conn.Open();

            try
            {
                string command5;
                command5 = $"UPDATE Done_operation  SET " +
                         $"[اسم الدكتور]=N'{doctor}',[وقت المقابلة]=N'{meet_time[1] + "/" + meet_time[0] + "/" + meet_time[2]}'," +
                            $"الموقع=N'{center_operation}'  WHERE [كود المريض]=N'{code}'";

                SqlCommand cmd5 = new SqlCommand(command5, conn);
                cmd5.ExecuteNonQuery();
                type=4;
            }
            catch { }
            conn.Close();
        }
    }
    class Edit_Other
    {
        public string notecall;
        string code;
        string callcenter;
        public Edit_Other(string note, string code,string account)
        {
            this.notecall = note;
            this.code = code;
            this.callcenter = account;
        }
        public void updateSql()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {callcenter}; Password=123");

            conn.Open();
            string sql = $"UPDATE other_operations SET [ملاحظات الكول سنتر]=N'{notecall}' WHERE [كود المريض]=N'{code}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
