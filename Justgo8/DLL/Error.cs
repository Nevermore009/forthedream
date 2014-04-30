using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace DLL
{
    public class Error
    {
        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable Errors()
        {
            DataTable dt = new DataTable();
            string sql = " select * from tb_error";
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable ErrorInfo(int id)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_error] where id=" + id;
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(int errorCode, string errorType, string errorContent, string url)
        {
            int res = 0;
            string sql = " insert into [tb_error] ([errorCode], [errorType], [errorContent], [url]) values (@errorCode, @errorType, @errorContent, @url)";
            SqlParameter[] pas = new SqlParameter[] { 
                new SqlParameter("@errorCode",errorCode),
                new SqlParameter("@errorType",errorType),
                new SqlParameter("@errorContent",errorContent),
                new SqlParameter("@url",url)
            };
            res = help.GetNum(sql,pas);
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int del(int id)
        {
            int res = 0;
            string sql = " delete from [tb_error] where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
