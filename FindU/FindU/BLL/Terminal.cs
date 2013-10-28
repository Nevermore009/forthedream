using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class Terminal
    {
        public bool Exist(string imei)
        {
            string sql = "select count(*) from Terminal where imei=@imei";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@imei", imei) };
            return SqlHelper.Exists(sql, parameters);
        }

        public bool ModifyByIMEI(string imei, string interval)
        {
            string sql = "update Terminal set interval=@interval where imei=@imei";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@imei", imei), new SqlParameter("@interval", interval) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public DataTable GetList()
        {
            string sql = "select * from V_Terminal";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public DataTable GetListByStaffName(string staffname)
        {
            string sql = "select * from V_Terminal where staffname like '%'+@staffname+'%'";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@staffname", staffname) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public bool Add(string imei, string staffid)
        {
            string[] sqls = new string[2];
            sqls[0] = "insert into Terminal(imei) values(@imei)";
            sqls[1] = "update staff set imei=@imei where staffid=@staffid";
            SqlParameter[][] parameters = new SqlParameter[2][];
            parameters[0] = new SqlParameter[] { new SqlParameter("@imei", imei) };
            parameters[1] = new SqlParameter[] { new SqlParameter("@imei", imei),new SqlParameter("@staffid", staffid) };
            return SqlHelper.ExeTransaction(sqls,parameters);
        }

    }
}
