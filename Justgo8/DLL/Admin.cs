using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace DLL
{
    public class Admin
    {
        MsSqlHelper help = new MsSqlHelper();
        /// <summary>
        /// 密码查询
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>返回密码</returns>
        public DataTable GetTable(string UserName)
        {
            string sql = "select [UserPwd] from [tb_admin] where [UserName]='" + UserName + "'";
            DataTable dt = new DataTable();
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 修改登录时间，登录IP
        /// </summary>
        /// <param name="Ip">登录IP地址</param>
        /// <param name="UserName">用户名</param>
        /// <returns>1，成功，0失败</returns>
        public int GetNum(string Ip,string UserName)
        {
            int Results = 0;
            string sql = "update [td_admin] set [ActiveTime]='" + DateTime.Now.ToString().Trim() + "',[ActiveIp]='" + Ip + "' where [UserName]='" + UserName + "'";
            Results = help.GetNum(sql);
            return Results;
        }
    }
}
