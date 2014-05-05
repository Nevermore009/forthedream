using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class BCommentRecord
    {
        /// <summary>
        /// 添加
        /// </summary>
        public static int add(string clientid, string commentid, string videoid, string content)
        {
            return new DLL.CommentRecord().add(clientid, commentid, videoid, content);
        }
        
    }
}
