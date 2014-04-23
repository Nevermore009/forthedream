using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DLL
{
   public class Orders
    {
        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable OrderInfo(int orderid)
        {
            DataTable dt = new DataTable();
            string sql = "select * from [tb_orders] where t1.[id]=" + orderid;
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 获取某用户的订单
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable GetOrders(string username)
        {
            DataTable dt = new DataTable();
            string sql = "select * from [tb_orders] where t1.[username]='" + username+"'";
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(int detailid, string  username,float generalprice,float adultprice,float childprice,int adultnum,int childnum)
        {
            int res = 0;
            string sql = string.Format(@"insert into [tb_orders] ([detailid],[username],[generalprice],[adultprice],[childprice],[adultnum],[childnum])  values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", detailid, username, generalprice, adultprice, childprice, adultnum, childnum);
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
            string sql = " delete from [tb_orders] where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
