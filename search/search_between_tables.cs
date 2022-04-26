using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp1.search_all
{
    internal class search_between_tables
    {

        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");
        public static DataTable search_other(string name)
        {
            DataTable other_datatable = new DataTable();
            conn.Open();

            try
            {
                string sql = $"SELECT * FROM other_operations WHERE [اسم المريض] LIKE N'%{name}%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                other_datatable.Load(data);
                conn.Close();
                DataColumn dtcolumn = new DataColumn();
                dtcolumn.DataType = Type.GetType("System.String");
                dtcolumn.ColumnName = "الجدول";
                dtcolumn.DefaultValue = "غير ذلك";
                dtcolumn.ReadOnly = true;
                other_datatable.Columns.Add(dtcolumn);
                return other_datatable;
            }
            catch { }
            conn.Close();
            other_datatable.Columns.Remove("رد القافلة");
            return other_datatable;

        }
        static public DataTable search_accept(string name)
        {
            DataTable accept_datatable = new DataTable();
            conn.Open();

            try
            {
                string sql3 = $"SELECT * FROM Accepted_operations WHERE [اسم المريض] LIKE N'%{name}%'";
                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                SqlDataReader data3 = cmd3.ExecuteReader();
                accept_datatable.Load(data3);
                conn.Close();
                DataColumn dtcolumn3 = new DataColumn();
                dtcolumn3.DataType = Type.GetType("System.String");
                dtcolumn3.ColumnName = "الجدول";
                dtcolumn3.DefaultValue = "العمليات المؤكدة";
                dtcolumn3.ReadOnly = true;
                accept_datatable.Columns.Add(dtcolumn3);
                return accept_datatable;
            }
            catch { }
            conn.Close();
            accept_datatable.Columns.Remove("رد القافلة");

            return accept_datatable;
        }
        static public DataTable search_delay(string name)
        {
            DataTable delay_datatable = new DataTable();
            conn.Open();

            try
            {
                string sql1 = $"SELECT * FROM delay_operations WHERE [اسم المريض] LIKE N'%{name}%'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                SqlDataReader data1 = cmd1.ExecuteReader();
                delay_datatable.Load(data1);
                conn.Close();
                DataColumn dtcolumn1 = new DataColumn();
                dtcolumn1.DataType = Type.GetType("System.String");
                dtcolumn1.ColumnName = "الجدول";
                dtcolumn1.DefaultValue = "العمليات المؤجلة";
                dtcolumn1.ReadOnly = true;
                delay_datatable.Columns.Add(dtcolumn1);
                return delay_datatable;
            }
            catch { }
            conn.Close();
            delay_datatable.Columns.Remove("رد القافلة");

            return delay_datatable;
        }
        static public DataTable search_show(string name)
        {
            DataTable show_datatable = new DataTable();
            conn.Open();

           try
            {
                string sql2 = $"SELECT * FROM Showed_operations WHERE [اسم المريض] LIKE N'%{name}%'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                SqlDataReader data2 = cmd2.ExecuteReader();
                show_datatable.Load(data2);
                conn.Close();
                DataColumn dtcolumn2 = new DataColumn();
                dtcolumn2.DataType = Type.GetType("System.String");
                dtcolumn2.ColumnName = "الجدول";
                dtcolumn2.DefaultValue = "العروض";
                dtcolumn2.ReadOnly = true;
                show_datatable.Columns.Add(dtcolumn2);
                return show_datatable;
            }
            catch { }
            conn.Close();
            show_datatable.Columns.Remove("رد القافلة");

            return show_datatable;
        }
        static public DataTable search_cancel(string name)
        {
            DataTable cancel_datatable = new DataTable();
            conn.Open();

            try
            {
                string sql4 = $"SELECT * FROM cancel_operations WHERE [اسم المريض] LIKE N'%{name}%'";
                SqlCommand cmd4 = new SqlCommand(sql4, conn);
                SqlDataReader data4 = cmd4.ExecuteReader();
                cancel_datatable.Load(data4);
                conn.Close();
                DataColumn dtcolumn4 = new DataColumn();
                dtcolumn4.DataType = Type.GetType("System.String");
                dtcolumn4.ColumnName = "الجدول";
                dtcolumn4.DefaultValue = "العمليات الملغية";
                dtcolumn4.ReadOnly = true;
                cancel_datatable.Columns.Add(dtcolumn4);
                return cancel_datatable;
            }
            catch { }
            conn.Close();
            cancel_datatable.Columns.Remove("رد القافلة");

            return cancel_datatable;
        }

        static  public DataTable search_accounts(string account,string name)
        {
            DataTable call_center_dt = new DataTable();
            
            conn.Open();
            try
            {
                string sql5 = $"SELECT * FROM {account} WHERE  تم IS NULL AND [اسم المريض] LIKE N'%{name}%' ";
                SqlCommand cmd5 = new SqlCommand(sql5, conn);
                SqlDataReader data5 = cmd5.ExecuteReader();
                call_center_dt.Load(data5);
             //   DataColumn dtcolumn5 = new DataColumn();
              //  dtcolumn5.DataType = Type.GetType("System.String");
              //  dtcolumn5.ColumnName = "الجدول";
              //  dtcolumn5.DefaultValue = "كول سنتر 1";
              //  dtcolumn5.ReadOnly = true;
              // call_center1_dt.Columns.Add(dtcolumn5);
            }
            catch { }
            conn.Close();

            call_center_dt.Columns.Remove("رد القافلة");

            return call_center_dt;
        }


    }
}
