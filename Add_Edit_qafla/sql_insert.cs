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



namespace WpfApp1.Add_qafla
{

    internal class sql_insert
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");

        static public void insert_qaflaName(Iqafla qafla)
        {


            conn.Open();
            try
            {
                string[] date_arr = qafla.date.Split('/');
                DataTable dt = new DataTable();

                string comm = $"SELECT اليوم FROM qafla_name WHERE اليوم={date_arr[1]} AND الشهر={date_arr[0]} AND السنة={date_arr[2]} AND المركز=N'{qafla.ceneter}'";
                SqlCommand cm = new SqlCommand(comm, conn);
                SqlDataReader cmm = cm.ExecuteReader();
                dt.Load(cmm);

                if (dt.Rows.Count >= 1)
                {
                    conn.Close();

                }
                else
                {
                    string command = "INSERT INTO qafla_name ([اسم القافلة],[تاريخ القافلة],[مكان القافلة],اليوم,الشهر,السنة,المركز) VALUES (@Name,@Date,@Address,@day,@month,@year,@center)";
                    SqlCommand cmd = new SqlCommand(command, conn);
                    cmd.Parameters.AddWithValue("@Name", qafla.carvan_name);
                    cmd.Parameters.AddWithValue("@Date", date_arr[1] + "/" + date_arr[0] + "/" + date_arr[2]);
                    cmd.Parameters.AddWithValue("@Address", qafla.ceneter + " " + qafla.govern);
                    cmd.Parameters.AddWithValue("@day", qafla.day);
                    cmd.Parameters.AddWithValue("@month", qafla.month);
                    cmd.Parameters.AddWithValue("@year", qafla.year);
                    cmd.Parameters.AddWithValue("@center", qafla.ceneter);
                    cmd.ExecuteNonQuery();
                 }
                }
                catch
                {
                    MessageBox.Show("1رجاء ادخال البيانات الأساسية");
                }
            conn.Close();



        }
        static public void insert_qafla(Iqafla qafla)
        {

            try
            {
                string[] date_arr = qafla.date.Split('/');
                string[] d_diagnosis_Arr = { null, null, null };
            if (qafla.d_diagnosis != null)
             {
                 d_diagnosis_Arr = qafla.d_diagnosis.Split('/');
             }
              else{
                    d_diagnosis_Arr[0] = "";
               }

                conn.Open();
            string command = "INSERT INTO qafla_details ([كود المريض],[اسم المريض],[رقم التليفون],[الرقم القومي],التشخيص,[رد القافلة],السن,[اسم القافلة],التاريخ,المركز,المحافظة,[تشخيص العرض],[تاريخ العرض],[اسم الإستشاري],ملاحظات) VALUES (@code,@name,@phone,@id,@diagnosis,@reply,@age,@carvan_name,@date,@center,@govern,@p_diagnosis,@d_diagnosis,@doctor_name,@note)";
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@code", qafla.code);
            cmd.Parameters.AddWithValue("@name", qafla.name);
            cmd.Parameters.AddWithValue("@phone", qafla.number);
            cmd.Parameters.AddWithValue("@id", qafla.national_id);
            cmd.Parameters.AddWithValue("@diagnosis", qafla.diagnosis);
            cmd.Parameters.AddWithValue("@reply", qafla.carvan_reply);
            cmd.Parameters.AddWithValue("@age", qafla.age);
            cmd.Parameters.AddWithValue("@carvan_name", qafla.carvan_name);
            cmd.Parameters.AddWithValue("@date", date_arr[1] + "/" + date_arr[0] + "/" + date_arr[2]);
            cmd.Parameters.AddWithValue("@center", qafla.ceneter);
            cmd.Parameters.AddWithValue("@govern", qafla.govern);
            cmd.Parameters.AddWithValue("@p_diagnosis", qafla.p_diagnosis);
            if (d_diagnosis_Arr[0] !="")
            {
                cmd.Parameters.AddWithValue("@d_diagnosis", d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]);

            }
            else
            {
                cmd.Parameters.AddWithValue("@d_diagnosis","");
            }
            cmd.Parameters.AddWithValue("@doctor_name", qafla.doctor_name);
            cmd.Parameters.AddWithValue("@note", qafla.note);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            { 
                MessageBox.Show("رجاء ادخال البيانات الأساسية2");
            }

        }
        static public void insert_operation(Iqafla qafla)
        {

            try
            {
                string[] date_arr = qafla.date.Split('/');
                string[] d_diagnosis_Arr = { null, null, null };
                if (qafla.d_diagnosis != null)
                {
                    d_diagnosis_Arr = qafla.d_diagnosis.Split('/');
                }
                else
                {
                    d_diagnosis_Arr[0] = "";
                }
                conn.Open();
                string command = "INSERT INTO operations_All ([كود المريض],[اسم المريض],[رقم التليفون],[الرقم القومي],التشخيص,[رد القافلة],السن,[اسم القافلة],التاريخ,المركز,المحافظة,[تشخيص العرض],[تاريخ العرض],[اسم الإستشاري],ملاحظات) VALUES (@code,@name,@phone,@id,@diagnosis,@reply,@age,@carvan_name,@date,@center,@govern,@p_diagnosis,@d_diagnosis,@doctor_name,@note)";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@code", qafla.code);
                cmd.Parameters.AddWithValue("@name", qafla.name);
                cmd.Parameters.AddWithValue("@phone", qafla.number);
                cmd.Parameters.AddWithValue("@id", qafla.national_id);
                cmd.Parameters.AddWithValue("@diagnosis", qafla.diagnosis);
                cmd.Parameters.AddWithValue("@reply", qafla.carvan_reply);
                cmd.Parameters.AddWithValue("@age", qafla.age);
                cmd.Parameters.AddWithValue("@carvan_name", qafla.carvan_name);
                cmd.Parameters.AddWithValue("@date", date_arr[1] + "/" + date_arr[0] + "/" + date_arr[2]);
                cmd.Parameters.AddWithValue("@center", qafla.ceneter);
                cmd.Parameters.AddWithValue("@govern", qafla.govern);
                cmd.Parameters.AddWithValue("@p_diagnosis", qafla.p_diagnosis);
                if (d_diagnosis_Arr[0] != "")
                {
                    cmd.Parameters.AddWithValue("@d_diagnosis", d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@d_diagnosis", "");
                }
                cmd.Parameters.AddWithValue("@doctor_name", qafla.doctor_name);
                cmd.Parameters.AddWithValue("@note", qafla.note);


                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("رجاء ادخال البيانات الأساسية3");
            }

        }
    }
}
