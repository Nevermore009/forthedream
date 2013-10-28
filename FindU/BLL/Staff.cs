using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Staff
    {
        public bool Add(string staffname)
        {
            string sql = "insert into staff(staffname) values(@staffname)";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@staffname", staffname) };
            return SqlHelper.ExecuteSql(sql,parameters) > 0;
        }

        public DataTable GetStaffList()
        {
            string sql = "select * from V_Staff";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable SelectStaffList()
        {
            string sql = "select * from V_Staff where IMEI is not null";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable GetFreeStaffList()
        {
            string sql = "select * from V_Staff where isonplan=0 and IMEI is not null";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable GetNotFreeStaffList()
        {
            string sql = "select * from V_Staff where isonplan=1";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable GetStaffByName(string staffname)
        {
            string sql = "select * from V_Staff where staffname like '%'+@staffname+'%'";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@staffname", staffname) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }
        public DataTable GetStaffByIMEI(string imei)
        {
            string sql = "select * from V_Staff where imei=@imei";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@imei", imei) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public DataTable GetNoTerminalStaff()
        {
            string sql = "select * from V_staff where imei is null";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }        

        public bool BindTerminal(string staffid,string imei)
        {
            string sql = "update Staff set imei=@imei where staffid=@staffid";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@imei", imei), new SqlParameter("@staffid", staffid) };
            return SqlHelper.ExecuteSql(sql,parameters) > 0;
        }

        public bool IsFree(string staffid)
        {
            string sql = "select count(*) from V_staff where staffid=@staffid and isonplan=0";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@staffid", staffid) };
            return SqlHelper.Exists(sql);
        }
        public bool EditStaffName(string name, int staffid)
        {
            string sql = "update Staff set StaffName=@name  where StaffID=@staffid";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@name", name),
                new SqlParameter("@staffid", staffid) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public DataTable GetOnlineStaff(List<string> list,string datetime)
        {  
            string sql = @"select StaffName,Lat,Lon from Staff,patrol where Staff.IMEI=Patrol.IMEI and   Locatetime>@datetime
          and Patrol.IMEI in(";
            for (int i = 0; i < list.Count; i++)
            {
                sql += list[i]+",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql+=")";
            SqlParameter para = new SqlParameter("@datetime", datetime);
            return SqlHelper.GetDataSet(sql,para).Tables[0];
        }
       
    }
}
