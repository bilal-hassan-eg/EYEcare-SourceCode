using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1.Add_Edit_qafla
{
    public class check_code
    {
        static SqlConnection conn = new SqlConnection($"Data Source={get_server.server()};Initial Catalog = eyecare; User ID = main; Password=123");
        public static bool check(string code_to_check)
        {
            try
            {
                string code = string.Empty;
                string sql = $"SELECT * FROM qafla_details WHERE [كود المريض]={code_to_check}";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    code = dr["كود المريض"].ToString();
                }
                if (code == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
