using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;

namespace DLL
{
    public class Protocol
    {
        MsSqlHelper help = new MsSqlHelper();

        public string getprotocol()
        {
            string sql = "select content from [tb_protocol] ";
            return help.RunSqlReturn(sql).ToString();
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(string content)
        {
            int res = 0;
            string sql = " insert into [tb_protocol] (content) values ('" + content + "') ";
            res = help.GetNum(sql);
            return res;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int update(string content, int id)
        {
            int res = 0;
            string sql = "  update [tb_protocol] set [content]='" + content + "' where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int del(int id)
        {
            int res = 0;
            string sql = " delete from [tb_protocol] where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
