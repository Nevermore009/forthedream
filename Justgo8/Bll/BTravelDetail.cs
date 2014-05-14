using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BTravelDetail
    {
        /// <summary>
        /// 查看线路
        /// </summary>
        /// <returns></returns>
        public static DataTable DetailInfo()
        {
            return new DLL.TravelDetail().DetailInfo();
        }

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable DetailInfo(int id)
        {
            return new DLL.TravelDetail().DetailInfo(id);
        }

        public static DataTable TravelInfo(int travelTypeID, int topnum = 0)
        {
            return TravelInfo(travelTypeID, 0, topnum);
        }

        public static DataTable TravelInfo(int travelTypeID, int pageIndex, int pageSize)
        {
            return new DLL.TravelDetail().TravelInfo(travelTypeID, pageIndex, pageSize);
        }

        public static DataTable TravelInfoByCondition(string journeydates, string adultpricestart, string adultpriceend, string traveltype, string destinationarea, string destinationcity, string titlekey, string startdate, string enddate, int pageIndex, int pageSize, string orderbyname, bool asc)
        {
            return new DLL.TravelDetail().TravelInfoByCondition(journeydates, adultpricestart, adultpriceend, traveltype, destinationarea, destinationcity, titlekey, startdate, enddate, pageIndex, pageSize, orderbyname, asc);
        }

        public static int GetTravelInfoCountByCondition(string journeydates, string adultpricestart, string adultpriceend, string traveltype, string destinationarea, string destinationcity, string titlekey, string startdate, string enddate)
        {
            return new DLL.TravelDetail().GetTravelInfoCountByCondition(journeydates, adultpricestart, adultpriceend, traveltype, destinationarea, destinationcity, titlekey, startdate, enddate);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="generalprice">门市价格</param>
        /// <param name="adultprice">成人起始价</param>
        /// <param name="childprice">儿童起始价</param>
        /// <param name="startdate">最早出发日期</param>
        /// <param name="enddate">最晚出发日期</param>
        /// <param name="departuretime">出发日期文字描述</param>
        /// <param name="features">行程特色</param>
        /// <param name="billinclude">费用包含</param>
        /// <param name="billbeside">费用不包含</param>
        /// <param name="servicestandard">服务标准</param>
        /// <param name="journey">行程安排</param>
        /// <param name="contact">预订流程</param>
        /// <returns></returns>
        public static int add(string serialno,string title, string description, float generalprice, float adultprice, float childprice, string startdate, string enddate, string departuretime, string features, string billinclude, string billbeside, string servicestandard, string presentation, string journey, string contact, int traveltypeid, int journeydays, string transportation, int adultruleid, int childruleid)
        {
            return new DLL.TravelDetail().add(serialno,title, description, generalprice, adultprice, childprice, startdate, enddate, departuretime, features, billinclude, billbeside, servicestandard, presentation, journey, contact, traveltypeid, journeydays, transportation, adultruleid, childruleid);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序号</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static int update(string serialno,string title, string description, float generalprice, float adultprice, float childprice, string startdate, string enddate, string departuretime, string features, string billinclude, string billbeside, string servicestandard, string presentation, string journey, string contact, int journeydays, string transportation, int adultruleid, int childruleid, int id)
        {
            return new DLL.TravelDetail().update(serialno,title, description, generalprice, adultprice, childprice, startdate, enddate, departuretime, features, billinclude, billbeside, servicestandard, presentation, journey, contact, journeydays, transportation, adultruleid, childruleid, id);
        }

        public static int ChangeHotState(int id,bool hot)
        {
            return new DLL.TravelDetail().ChangeHotState(id, hot);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(int id)
        {
            return new DLL.TravelDetail().del(id);
        }
    }
}
