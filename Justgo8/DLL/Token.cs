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
        public DataTable GetTokens()
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_token] where state=0 order by lasttokentime desc";
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable TokenInfo(int id)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_token] where state=0 and id=" + id;
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(string code, string client_id, string access_token, int expires_in, string refresh_token, string token_type, DateTime lastTokenTime)
        {
            int res = 0;
            string sql = "select count(*) from [tb_token]  where code='" + code + "'";
            int count = int.Parse(help.RunSqlReturn(sql));
            if (count > 0)
            {
                sql = "update [tb_token] set [client_id]=@client_id,[access_token]=@access_token,[expires_in]=@expires_in,[refresh_token]=@refresh_token,[token_type]=@token_type,[lastTokenTime]=@lastTokenTime where [code]=@code";
            }
            else
            {
                sql = " insert into [tb_token] ([code],[client_id],[access_token],[expires_in],[refresh_token],[token_type],[lastTokenTime]) values (@code,@client_id,@access_token,@expires_in,@refresh_token,@token_type,@lastTokenTime)";
            }
            SqlParameter[] pas = new SqlParameter[] { 
                new SqlParameter("@code",code),
                new SqlParameter("@client_id",client_id),
                new SqlParameter("@access_token",access_token),
                new SqlParameter("@expires_in",expires_in),
                new SqlParameter("@refresh_token",refresh_token),
                new SqlParameter("@token_type",token_type),
                new SqlParameter("@lastTokenTime",lastTokenTime)  
            };
            res = help.GetNum(sql, pas);
            return res;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int update(string client_id, string access_token, int expires_in, string new_refresh_token, string token_type, DateTime lastTokenTime, string old_refresh_token)
        {
            int res = 0;
            string sql = "update [tb_token] set [client_id]=@client_id,[access_token]=@access_token,[expires_in]=@expires_in,[refresh_token]=@new_refresh_token,[token_type]=@token_type,[lastTokenTime]=@lastTokenTime where [refresh_token]=@old_refresh_token";
            SqlParameter[] pas = new SqlParameter[] { 
                new SqlParameter("@client_id",client_id),
                new SqlParameter("@old_refresh_token",old_refresh_token),
                new SqlParameter("@new_refresh_token",new_refresh_token),
                new SqlParameter("@expires_in",expires_in),
                new SqlParameter("@access_token",access_token),
                new SqlParameter("@token_type",token_type),
                new SqlParameter("@lastTokenTime",lastTokenTime)  
            };
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
            string sql = " update [tb_token] set state=-1 where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
