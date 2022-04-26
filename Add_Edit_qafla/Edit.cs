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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using WpfApp1.Add_qafla;

namespace WpfApp1.Edit_qafla
{
    internal class Edit
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");


        static public void update_sql(Iqafla new_qafle)
        {
           // conn.Close();
            conn.Open();

            string[] d_diagnosis_Arr = {string.Empty , string.Empty , string.Empty};
            if (new_qafle.d_diagnosis.Length>0) 
            {
                d_diagnosis_Arr = new_qafle.d_diagnosis.Split('/');
            }
            string command;
            if (d_diagnosis_Arr[0] != "")
            {
                 command = $"UPDATE qafla_details  SET " +
                    $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                    $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                    $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                    $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                    $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                    $"WHERE [كود المريض]={new_qafle.code}";
            }
            else
            {
                 command = $"UPDATE qafla_details  SET " +
                    $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                    $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                    $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                    $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                    $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                    $"WHERE [كود المريض]={new_qafle.code}";
            }
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            string command1;
            if (d_diagnosis_Arr[0] != "")
            {
                command1 = $"UPDATE operations_All  SET " +
                   $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                   $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                   $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                   $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                   $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                   $"WHERE [كود المريض]={new_qafle.code}";
            }
            else
            {
                command1 = $"UPDATE operations_All  SET " +
                   $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                   $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                   $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                   $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                   $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                   $"WHERE [كود المريض]={new_qafle.code}";
            }
            SqlCommand cmd1 = new SqlCommand(command1, conn);
            cmd1.ExecuteNonQuery();
            try
            {
                string command2;
                if (d_diagnosis_Arr[0] != "")
                {
                    command2 = $"UPDATE call_center1  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                else
                {
                    command2 = $"UPDATE call_center1  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                SqlCommand cmd2 = new SqlCommand(command2, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            try
            {
                string command3;
                if (d_diagnosis_Arr[0] != "")
                {
                    command3 = $"UPDATE call_center2  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                else
                {
                    command3 = $"UPDATE call_center2  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                SqlCommand cmd2 = new SqlCommand(command3, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            try
            {
                string command4;
                if (d_diagnosis_Arr[0] != "")
                {
                    command4 = $"UPDATE call_center3  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                else
                {
                    command4 = $"UPDATE call_center3  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                SqlCommand cmd2 = new SqlCommand(command4, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            try
            {
                string command4;
                if (d_diagnosis_Arr[0] != "")
                {
                    command4 = $"UPDATE Accepted_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                else
                {
                    command4 = $"UPDATE Accepted_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                SqlCommand cmd2 = new SqlCommand(command4, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            try
            {
                string command4;
                if (d_diagnosis_Arr[0] != "")
                {
                    command4 = $"UPDATE cancel_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                else
                {
                    command4 = $"UPDATE cancel_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                SqlCommand cmd2 = new SqlCommand(command4, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            try
            {
                string command4;
                if (d_diagnosis_Arr[0] != "")
                {
                    command4 = $"UPDATE delay_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                else
                {
                    command4 = $"UPDATE delay_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                SqlCommand cmd2 = new SqlCommand(command4, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            try
            {
                string command4;
                if (d_diagnosis_Arr[0] != "")
                {
                    command4 = $"UPDATE Showed_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                else
                {
                    command4 = $"UPDATE Showed_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                SqlCommand cmd2 = new SqlCommand(command4, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            try
            {
                string command4;
                if (d_diagnosis_Arr[0] != "")
                {
                    command4 = $"UPDATE other_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N'{d_diagnosis_Arr[1] + "/" + d_diagnosis_Arr[0] + "/" + d_diagnosis_Arr[2]}'," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                else
                {
                    command4 = $"UPDATE other_operations  SET " +
                       $"[اسم المريض]=N'{new_qafle.name}' , [رقم التليفون]=N'{new_qafle.number}'," +
                       $"[الرقم القومي]=N'{new_qafle.national_id}' , التشخيص=N'{new_qafle.diagnosis}'," +
                       $"[رد القافلة]=N'{new_qafle.carvan_reply}' , السن=N'{new_qafle.age}'," +
                       $"[تشخيص العرض]=N'{new_qafle.p_diagnosis}' , [تاريخ العرض]=N''," +
                       $"[اسم الإستشاري]=N'{new_qafle.doctor_name}' , ملاحظات=N'{new_qafle.note}'" +
                       $"WHERE [كود المريض]={new_qafle.code}";
                }
                SqlCommand cmd2 = new SqlCommand(command4, conn);
                cmd2.ExecuteNonQuery();
            }
            catch { }
            conn.Close();
        }
    }
}
