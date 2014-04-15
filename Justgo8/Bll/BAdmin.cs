using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using System.Data;

namespace Bll
{
    public class BAdmin
    {
        /// <summary>
        /// 密码查询
        /// </summary>
        /// <param name="UserName">账号</param>
        /// <returns>返回密码</returns>
        public static DataTable GetTable(string UserName)
        {
            return new DLL.Admin().GetTable(UserName);
        }

        /// <summary>
        /// 修改登录时间和IP地址
        /// </summary>
        /// <param name="Ip">IP地址</param>
        /// <param name="UserName">用户名</param>
        /// <returns></returns>
        public static int GetNum(string Ip, string UserName)
        {
            return new DLL.Admin().GetNum(Ip, UserName);
        }
    }
}
