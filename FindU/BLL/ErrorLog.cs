using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class ErrorLog
    {
        public bool Add(string imei, string message)
        {
            string sql = "insert into ErrorLog(imei,message) values(@imei,@message)";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@imei", imei), new SqlParameter("@message", message) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;            
        }
    }
}
