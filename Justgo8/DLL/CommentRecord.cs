using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace DLL
{
    public class CommentRecord
    {        
        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 添加
        /// </summary>
        public int add(string clientid, string commentid, string videoid, string content)
        {
            int res = 0;
            string sql = string.Format(" insert into [tb_commentrecord] ([clientid],[commentid],[videoid],[content]) values ('{0}','{1}','{2}','{3}')", clientid, commentid, videoid, content);
            res = help.GetNum(sql);
            return res;
        }
    }
}
