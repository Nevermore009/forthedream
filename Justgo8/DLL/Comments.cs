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
            DataTable dt = new DataTable();
            string sql = " select * from [tb_comments] ";
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable CommentInfo(int id)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_comments] where id=" + id;
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(string content)
        {
            int res = 0;
            string sql = string.Format(" insert into [tb_comments] ([content]) values ('{0}')", content);
            res = help.GetNum(sql);
            return res;
        }

        /// <summary>
        /// 修改专利
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序号</param>
        /// <param name="id">id</param>
        /// <returns></returns>
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
