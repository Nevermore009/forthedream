using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class ServerIP
    {
        public ServerIP()
        {
        }
        public bool InsertServerIP(string ipAddress, string port, string subnetMask, string gateway)
        {
            string sqlInsert = "insert into ServerIP(IPAddress,Port,SubnetMask,Gateway ) values (@IPAddress,@Port,@SubnetMask,@Gateway)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@IPAddress",ipAddress ),
                new SqlParameter("@SubnetMask",subnetMask ),
                new SqlParameter("@Gateway",gateway ),
                new SqlParameter("@Port",port )
            };
            return SqlHelper.ExecuteSql(sqlInsert, paras) > 0;
        }
        public bool UpdateServerIP(string ipAddress, string port, string subnetMask, string gateway)
        {
            string sqlUpdate = "update ServerIP set IPAddress=@IPAddress,Port=@Port,SubnetMask=@SubnetMask,Gateway=@Gateway";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@IPAddress",ipAddress ),
                new SqlParameter("@SubnetMask",subnetMask ),
                new SqlParameter("@Gateway",gateway ),
                 new SqlParameter("@Port",port )
            };
            return SqlHelper.ExecuteSql(sqlUpdate, paras) > 0;
        }
        public DataTable SelectServerIP()
        {
            string sqlSelect = "select * from ServerIP";
            return SqlHelper.GetDataSet(sqlSelect).Tables[0];
        }
        public DataTable SelectInfo()
        {
            string sqlSelect = "select * from RoomsInfo";
            return SqlHelper.GetDataSet(sqlSelect).Tables[0];
        }

    }
}
