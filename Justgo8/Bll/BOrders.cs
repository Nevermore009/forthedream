using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BOrders
    {
        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable OrderInfo(int orderid)
        {
            return new DLL.Orders().OrderInfo(orderid);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public static int add(int detailid, string username, float generalprice, float adultprice, float childprice, int adultnum, int childnum)
        {
            return new DLL.Orders().add(detailid, username, generalprice, adultprice, childprice, adultnum, childnum);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(int id)
        {
            return new DLL.Orders().del(id);
        }
    }
}
