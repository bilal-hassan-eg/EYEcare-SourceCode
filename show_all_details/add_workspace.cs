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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace WpfApp1.show_all_details
{
    internal class add_workspace
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");

        public int to_int;
        public int from_int;
        public string account_name;
        public string accoung_name_to_store;
        public add_workspace(int to , int from , string account)
        {
            this.to_int = to;
            this.from_int = from;
            if (account == "كول سنتر 1")
            {
                this.account_name = "call_center1";
            }
            else if(account == "كول سنتر 2")
            {
                this.account_name = "call_center2";
            }
            else if (account == "كول سنتر 3")
            {
                this.account_name = "call_center3";
            }
            this.accoung_name_to_store = account;
        }
        public void insert_to_call_center()
        {

            ArrayList dt = new ArrayList();


            int time_loops = to_int - from_int;
            for(int i = from_int; i <= to_int; i++)
            {

                conn.Open();

                string sql = $"SELECT * FROM qafla_details WHERE [كود المريض]={i}";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    for (int i1 = 0; i1 <= 15; i1++)
                    {
                            dt.Add(data[i1]);  
                    }
                }
                data.Close();
                conn.Close();
                if (dt[15].ToString() == "")
                {
                    conn.Open();
                    string[] date_arr = dt[8].ToString().Split('/');
                    string[] d_diagnosis_Arr = dt[12].ToString().Split('/');

                    string command = $"INSERT INTO {account_name} ([كود المريض],[اسم المريض],[رقم التليفون],[الرقم القومي],التشخيص,[رد القافلة],السن,[اسم القافلة],التاريخ,المركز,المحافظة,[تشخيص العرض],[تاريخ العرض],[اسم الإستشاري],ملاحظات) VALUES (@code,@name,@phone,@id,@diagnosis,@reply,@age,@carvan_name,@date,@center,@govern,@p_diagnosis,@d_diagnosis,@doctor_name,@note)";
                    SqlCommand cmd1 = new SqlCommand(command, conn);
                    cmd1.Parameters.AddWithValue("@code", dt[0]);
                    cmd1.Parameters.AddWithValue("@name", dt[1]);
                    cmd1.Parameters.AddWithValue("@phone", dt[2]);
                    cmd1.Parameters.AddWithValue("@id", dt[3]);
                    cmd1.Parameters.AddWithValue("@diagnosis", dt[4]);
                    cmd1.Parameters.AddWithValue("@reply", dt[5]);
                    cmd1.Parameters.AddWithValue("@age", dt[6]);
                    cmd1.Parameters.AddWithValue("@carvan_name", dt[7]);
                    cmd1.Parameters.AddWithValue("@date", date_arr[0] + "/" + date_arr[1] + "/" + date_arr[2]);
                    cmd1.Parameters.AddWithValue("@center", dt[9]);
                    cmd1.Parameters.AddWithValue("@govern", dt[10]);
                    cmd1.Parameters.AddWithValue("@p_diagnosis", dt[11]);
                    cmd1.Parameters.AddWithValue("@d_diagnosis", d_diagnosis_Arr[0]==null ? d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[2]:"");
                    cmd1.Parameters.AddWithValue("@doctor_name", dt[13]);
                    cmd1.Parameters.AddWithValue("@note", dt[14]);

                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    conn.Open();
                    string comm = $"UPDATE qafla_details SET الحساب=N'{this.accoung_name_to_store}' WHERE [كود المريض]={i}";
                    SqlCommand cmd2 = new SqlCommand(comm, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    conn.Open();
                    string comm2 = $"UPDATE operations_All SET الحساب=N'{this.accoung_name_to_store}' WHERE [كود المريض]={i}";
                    SqlCommand cmd3 = new SqlCommand(comm2, conn);
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                    dt.Clear();

                }
                else
                {
                    MessageBox.Show("المريض رقم" + i + " بالفعل تم اعطاءه لأحد الحاسابات");
                    dt.Clear();

                }
            }

        }
        public void update_sql_list(List<string> item)
        {
            ArrayList dt = new ArrayList();


            int time_loops = to_int - from_int;
            foreach (string i in item)
            {

                conn.Open();

                string sql = $"SELECT * FROM qafla_details WHERE [كود المريض]={i}";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    for (int i1 = 0; i1 <= 15; i1++)
                    {
                        dt.Add(data[i1]);
                    }
                }
                data.Close();
                conn.Close();
                if (dt[15].ToString() == "")
                {
                    conn.Open();
                    string[] date_arr = dt[8].ToString().Split('/');
                    string[] d_diagnosis_Arr = dt[12].ToString().Split('/');

                    string command = $"INSERT INTO {account_name} ([كود المريض],[اسم المريض],[رقم التليفون],[الرقم القومي],التشخيص,[رد القافلة],السن,[اسم القافلة],التاريخ,المركز,المحافظة,[تشخيص العرض],[تاريخ العرض],[اسم الإستشاري],ملاحظات) VALUES (@code,@name,@phone,@id,@diagnosis,@reply,@age,@carvan_name,@date,@center,@govern,@p_diagnosis,@d_diagnosis,@doctor_name,@note)";
                    SqlCommand cmd1 = new SqlCommand(command, conn);
                    cmd1.Parameters.AddWithValue("@code", dt[0]);
                    cmd1.Parameters.AddWithValue("@name", dt[1]);
                    cmd1.Parameters.AddWithValue("@phone", dt[2]);
                    cmd1.Parameters.AddWithValue("@id", dt[3]);
                    cmd1.Parameters.AddWithValue("@diagnosis", dt[4]);
                    cmd1.Parameters.AddWithValue("@reply", dt[5]);
                    cmd1.Parameters.AddWithValue("@age", dt[6]);
                    cmd1.Parameters.AddWithValue("@carvan_name", dt[7]);
                    cmd1.Parameters.AddWithValue("@date", date_arr[0] + "/" + date_arr[1] + "/" + date_arr[2]);
                    cmd1.Parameters.AddWithValue("@center", dt[9]);
                    cmd1.Parameters.AddWithValue("@govern", dt[10]);
                    cmd1.Parameters.AddWithValue("@p_diagnosis", dt[11]);
                    cmd1.Parameters.AddWithValue("@d_diagnosis", d_diagnosis_Arr[0] == null ? d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[2] : "");
                    cmd1.Parameters.AddWithValue("@doctor_name", dt[13]);
                    cmd1.Parameters.AddWithValue("@note", dt[14]);

                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    conn.Open();
                    string comm = $"UPDATE qafla_details SET الحساب=N'{this.accoung_name_to_store}' WHERE [كود المريض]={i}";
                    SqlCommand cmd2 = new SqlCommand(comm, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    conn.Open();
                    string comm2 = $"UPDATE operations_All SET الحساب=N'{this.accoung_name_to_store}' WHERE [كود المريض]={i}";
                    SqlCommand cmd3 = new SqlCommand(comm2, conn);
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                    dt.Clear();

                }
                else
                {
                    MessageBox.Show("المريض رقم" + i + " بالفعل تم اعطاءه لأحد الحاسابات");
                    dt.Clear();

                }
            }
        }
    }
}
