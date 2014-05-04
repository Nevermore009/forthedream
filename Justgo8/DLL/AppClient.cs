using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace DLL
{
    public class AppClient
    {
        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable GetRandomAppClient()
        {
            string sql = " select top 1 * from [tb_appclient] order by newid() asc";
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable GetAppClientInfo(string client_id)
        {
            string sql = " select * from [tb_appclient] where client_id='" + client_id+"'";
            return help.SeeResults(sql);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int del(string client_id)
        {
            int res = 0;
            string sql = " delete from [tb_appclient] where client_id='" + client_id + "' ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
