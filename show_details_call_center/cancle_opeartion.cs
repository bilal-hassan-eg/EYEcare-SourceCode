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
    internal class cancle_opeartion
    {
        public string AccountName;
        private Iqafla _qafla;
        public cancle_opeartion(qafla qafla, string Accountname)
        {
            this._qafla = qafla;
            this.AccountName = Accountname;
        }
        public void cancel()
        {
            SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = {AccountName}; Password=123");

            string[] date_arr = _qafla.date.Split('/');
            string[] d_diagnosis_Arr = _qafla.d_diagnosis.Split('/');

            conn.Open();
            string command = "INSERT INTO cancel_operations ([كود المريض],[اسم المريض],[رقم التليفون],[الرقم القومي],التشخيص,[رد القافلة],السن,[اسم القافلة],التاريخ,المركز,المحافظة,[تشخيص العرض],[تاريخ العرض],[اسم الإستشاري],ملاحظات,الحساب) VALUES (@code,@name,@phone,@id,@diagnosis,@reply,@age,@carvan_name,@date,@center,@govern,@p_diagnosis,@d_diagnosis,@doctor_name,@note,@account)";
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
            cmd.Parameters.AddWithValue("@account", AccountName);


            cmd.ExecuteNonQuery();
            conn.Close();
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
                string cm5 = $"DELETE FROM Done_operation WHERE [كود المريض]=N'{_qafla.code}'";
                SqlCommand cmd5 = new SqlCommand(cm5, conn);
                cmd5.ExecuteNonQuery();
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
            conn.Close();
            conn.Open();
            string sql = $"UPDATE {AccountName} SET تم=N'الغيت' WHERE [كود المريض]={_qafla.code}";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
    }
}
