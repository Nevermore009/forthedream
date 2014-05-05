using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DLL
{
    public class Comments
    {
        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable GetComments()
        {
            string sql = " select * from [tb_comments] ";
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable CommentInfo(int id)
        {
            string sql = " select * from [tb_comments] where id=" + id;
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 获取随机行
        /// </summary>
        /// <param name="rowcount"></param>
        /// <returns></returns>
        public DataTable GetRandomComment(int rowcount = 1)
        {
            string sql = " select top " + rowcount + " [content] from [tb_comments] order by newid()";
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int update(string content, int id)
        {
            int res = 0;
            string sql = "  update [tb_comments] set [content]='" + content + "' where id=" + id + " ";
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
            string sql = " delete from [tb_comments] where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
