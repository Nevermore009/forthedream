using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BToken
    {
        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable Tokens()
        {
            return new  DLL.Token().GetTokens();
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable TokenInfo(int id)
        {
            return new DLL.Token().TokenInfo(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public static int add(string code, string client_id, string access_token, int expires_in, string refresh_token, string token_type)
        {
            return new DLL.Token().add(code, client_id, access_token, expires_in, refresh_token, token_type, DateTime.Now);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public static int update(string client_id, string access_token, int expires_in, string new_refresh_token, string token_type, string old_refresh_token)
        {
            return new DLL.Token().update(client_id, access_token, expires_in, new_refresh_token, token_type, DateTime.Now, old_refresh_token);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(int id)
        {
            return new DLL.Token().del(id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(string access_token)
        {
            return new DLL.Token().del(access_token);
        }
    }
}
