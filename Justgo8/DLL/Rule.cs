using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DLL
{
    public class Rule
    {
        MsSqlHelper help = new MsSqlHelper();
        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable RuleInfo(int id)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_rule] where id=" + id;
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public DataTable RulesOfType(int ruletype)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_rule] where ruletype=" + ruletype;
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(int ruletype,string content)
        {
            int res = 0;
            string sql =string.Format(" insert into [tb_rule] ([ruletype],[content]) values ({0},'{1}')",ruletype,content);
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
            string sql = "  update [tb_rule] set [content]='" + content + "' where id=" + id + " ";
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
            string sql = " delete from [tb_rule] where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
