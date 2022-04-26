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
    internal class Add_delay_operations
    {
        private Iqafla _qafla;
        public string AccountName;
        string location;
        string data;
        public Add_delay_operations(qafla qafla, string data, string Accountname, string location)
        {
            this._qafla = qafla;
            this.data = data;
            this.AccountName = Accountname;
            this.location = location;
        }
        public void insert_delayed_operation()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {AccountName}; Password=123");

            string[] data_arr = data.Split(',');

            try
            {
                string[] date_arr = _qafla.date.ToString().Split('/');
                string[] d_diagnosis_Arr = _qafla.d_diagnosis.ToString().Split('/');
                string[] meet_time_arr = data_arr[1].Split('/');

                conn.Open();
                string command = "INSERT INTO delay_operations ([كود المريض],[اسم المريض],[رقم التليفون],[الرقم القومي],التشخيص,[رد القافلة],السن,[اسم القافلة],التاريخ,المركز,المحافظة,[تشخيص العرض],[تاريخ العرض],[اسم الإستشاري],ملاحظات,[اسم الدكتور],[وقت المقابلة],الحساب,الموقع) VALUES (@code,@name,@phone,@id,@diagnosis,@reply,@age,@carvan_name,@date,@center,@govern,@p_diagnosis,@d_diagnosis,@doctor_name,@note,@doctor,@time,@account,@location)";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@code", _qafla.code);
                cmd.Parameters.AddWithValue("@name", _qafla.name);
                cmd.Parameters.AddWithValue("@phone", _qafla.number);
                cmd.Parameters.AddWithValue("@id", _qafla.national_id);
                cmd.Parameters.AddWithValue("@diagnosis", _qafla.diagnosis);
                cmd.Parameters.AddWithValue("@reply", _qafla.carvan_reply);
                cmd.Parameters.AddWithValue("@age", _qafla.age);
                cmd.Parameters.AddWithValue("@carvan_name", _qafla.carvan_name);
                cmd.Parameters.AddWithValue("@date", date_arr[0] + "/" + date_arr[1] + "/" + date_arr[2]);
                cmd.Parameters.AddWithValue("@center", _qafla.ceneter);
                cmd.Parameters.AddWithValue("@govern", _qafla.govern);
                cmd.Parameters.AddWithValue("@p_diagnosis", _qafla.p_diagnosis);
                if (d_diagnosis_Arr[0] != "")
                {
                    cmd.Parameters.AddWithValue("@d_diagnosis", d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@d_diagnosis", "");
                }
                cmd.Parameters.AddWithValue("@doctor_name", _qafla.doctor_name);
                cmd.Parameters.AddWithValue("@note", _qafla.note);
                cmd.Parameters.AddWithValue("@doctor", data_arr[0]);
                cmd.Parameters.AddWithValue("@time", meet_time_arr[1] + "/" + meet_time_arr[0] + "/" + meet_time_arr[2]);
                cmd.Parameters.AddWithValue("@account", AccountName);
                cmd.Parameters.AddWithValue("@location", location);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
            }
            conn.Open();
            try
            {
                string cm1 = $"DELETE FROM Accepted_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd = new SqlCommand(cm1, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            conn.Open();
            try
            {
                string cm1 = $"DELETE FROM cancel_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd = new SqlCommand(cm1, conn);
                cmd.ExecuteNonQuery();
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
            try
            {
                string cm1 = $"DELETE FROM other_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd = new SqlCommand(cm1, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
            conn.Open();
            try
            {
                string cm1 = $"DELETE FROM Showed_operations WHERE [كود المريض]={_qafla.code}";
                SqlCommand cmd = new SqlCommand(cm1, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            conn.Close();

            conn.Open();
            string sql = $"UPDATE {AccountName} SET تم=N'اجلت' WHERE [كود المريض]={_qafla.code}";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
    }
}
