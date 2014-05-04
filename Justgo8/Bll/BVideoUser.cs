using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
   public class BVideoUser
    {
        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVideoUsers()
        {
            return new DLL.VideoUser().GetVideoUsers();
        }
    }
}
