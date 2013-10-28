using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class TerminalBind
    {
        public void AddCode(string code, string imei)
        {
            string procedurename = "BindingCodeAdd";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@code", code), new SqlParameter("@imei", imei) };
            SqlHelper.ExecuteProcedure(procedurename, parameters);
        }

        public string GetIMEIByCode(string code)
        {
            string sql = "select  imei from BindingCode where code=@code and createtime>@availabletime order by createtime desc";
            string availabletime = DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd HH:mm:ss");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@code", code), new SqlParameter("@availabletime", availabletime) };
            object o = SqlHelper.ExecuteScalar(sql, parameters);
            return o == null ? null : o.ToString();
        }
    }
}
