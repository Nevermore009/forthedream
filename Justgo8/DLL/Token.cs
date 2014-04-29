using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;
using System.Data.SqlClient;

namespace DLL
{
   public class Token
    {
        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable Comments()
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_token] ";
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable CommentInfo(int id)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_token] where id=" + id;
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(string code,string client_id,string access_token,int expires_in,string refresh_token,string token_type)
        {
            int res = 0;
            string sql =" insert into [tb_token] ([code],[client_id],[access_token],[expires_in],[refresh_token],[token_type]) values (@code,@client_id,@access_token,@expires_in,@refresh_token,@token_type)";
            SqlParameter[] pas = new SqlParameter[] { 
                new SqlParameter("@code",code),
                new SqlParameter("@client_id",client_id),
                new SqlParameter("@access_token",access_token),
                new SqlParameter("@expires_in",expires_in),
                new SqlParameter("@refresh_token",refresh_token),
                new SqlParameter("@token_type",token_type)
            };
            res = help.GetNum(sql);
            return res;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int update(string content, int id)
        {
            int res = 0;
            string sql = "  update [tb_token] set [content]='" + content + "' where id=" + id + " ";
            res = help.GetNum(sql);
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
            string sql = " delete from [tb_token] where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
