using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace DLL
{
    public class VideoUser
    {
        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable GetVideoUsers()
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_videouser] ";
            return help.SeeResults(sql);
        }
    }
}
