using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BAppClient
    {
        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRandomAppClient()
        {
            return new DLL.AppClient().GetRandomAppClient();
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAppClientInfo(string client_id)
        {
            return new DLL.AppClient().GetAppClientInfo(client_id);
        }
    }
}
