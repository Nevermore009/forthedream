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
        public DataTable Tokens()
        {
            return new  DLL.Token().GetTokens();
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable TokenInfo(int id)
        {
            return new DLL.Token().TokenInfo(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(string code, string client_id, string access_token, int expires_in, string refresh_token, string token_type)
        {
            return new DLL.Token().add(code, client_id, access_token, expires_in, refresh_token, refresh_token, DateTime.Now);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int update(string content, int id)
        {
            return new DLL.Token().update(content, id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int del(int id)
        {
            return new DLL.Token().del(id);
        }
    }
}
