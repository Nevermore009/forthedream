using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace DLL
{
    public class Account
    {
        MsSqlHelper help = new MsSqlHelper();

        public int Validate(string username, string pwd)
        {
            string sql = " select * from [tb_account] where username='" + username + "'";
            DataTable dt = help.SeeResults(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["password"].ToString() == pwd)
                    return 0;
                else
                    return -1;
            }
            else
                return -2;
        }

        public DataTable AccountInfo(string username)
        {
            string sql = " select * from [tb_account] where username='" + username + "'";
            return help.SeeResults(sql);
        }

        public DataTable GetAccountByOpenId(string openid)
        {
            string sql = " select * from [tb_account] where openid='" + openid + "'";
            return help.SeeResults(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public int add(string username, string pwd, string phone, string email)
        {
            int res = 0;
            string sql = "select count(*) from [tb_account] where username='" + username + "'";
            if (int.Parse(help.RunSqlReturn(sql)) <= 0)
            {
                sql = " insert into [tb_account] ([username],[password],[phone],[email]) values ('" + username + "','" + pwd + "','" + phone + "','" + email + "') ";
                res = help.GetNum(sql);
            }
            return res;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序号</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        public int update(string username, string pwd, string phone, string email)
        {
            int res = 0;
            string sql = "  update [tb_account] set [password]='" + pwd + "',[phone]='" + phone + "',[email]='" + email + "' where username=" + username + " ";
            res = help.GetNum(sql);
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int del(string username)
        {
            int res = 0;
            string sql = " delete from [tb_account] where username=" + username + " ";
            res = help.GetNum(sql);
            return res;
        }

        public int AddQQAccount(string username, string pwd, string phone, string email,string openid)
        {
            int res = 0;
            string sql = "select count(*) from [tb_account] where username='" + username + "'";
            if (int.Parse(help.RunSqlReturn(sql)) <= 0)
            {
                sql = " insert into [tb_account] ([username],[password],[phone],[email],[openid]) values ('" + username + "','" + pwd + "','" + phone + "','" + email + "','" + openid + "') ";
                res = help.GetNum(sql);
            }
            return res;
        }
    }
}
