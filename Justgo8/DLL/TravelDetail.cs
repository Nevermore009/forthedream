using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using Common;
using System.Data.SqlClient;

namespace DLL
{
    public class TravelDetail
    {
        MsSqlHelper help = new MsSqlHelper();
        /// <summary>
        /// 查看线路
        /// </summary>
        /// <returns></returns>
        public DataTable DetailInfo()
        {
            DataTable dt = new DataTable();
            string sql = " select id,title,description from [tb_detail] order by id desc";
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable DetailInfo(int id)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_detail] t1 where [id]=" + id;
            dt = help.SeeResults(sql);
            return dt;
        }

        public DataTable TravelInfo(int traveltypeid, int pageIndex, int pageSize)
        {
            DataTable dt = new DataTable();
            int start = pageIndex * pageSize + 1;
            int end = (pageIndex + 1) * pageSize;
            if (end == 0) end = int.MaxValue;
            string sql = " select * from (select *,(row_number() over(order by hot desc,id desc)) as rowid from [V_travelinfo]  where [traveltypeid]=" + traveltypeid + ") as t1 where t1.rowid between " + start + " and " + end + "  ";
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 按条件查询,不使用的条件请传入空字符串或null
        /// </summary>
        /// <param name="journeydates">行程天数</param>
        /// <param name="adultprice">价格</param>
        /// <param name="traveltype">线路类型</param>
        /// <param name="destinationarea">目的地区</param>
        /// <param name="destinationcity">目的城市</param>
        /// <param name="titlekey">标题关键字</param>
        /// <param name="startdate">开始日期</param>
        /// <param name="enddate">结束日期</param>
        /// <param name="pageIndex">页索引,从0开始</param>
        /// <param name="pageSize">页大小,0即获取全部</param>
        /// <returns></returns>
        public DataTable TravelInfoByCondition(string journeydates, string adultpricestart, string adultpriceend, string traveltype, string destinationarea, string destinationcity, string titlekey, string startdate, string enddate, int pageIndex, int pageSize, string orderbyname, bool asc)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select * from (select *,(row_number() over(");
            if (!string.IsNullOrEmpty(orderbyname))
            {
                sql.Append(orderbyname);
                sql.Append(asc ? "asc," : "desc,");
            }
            sql.Append("order by hot desc,id desc)) as rowid from V_TravelInfo t1 where 1=1 ");
            if (!string.IsNullOrEmpty(journeydates))
            {
                sql.Append(" and journeydates=");
                sql.Append(journeydates);
            }
            if (!string.IsNullOrEmpty(adultpricestart))
            {
                sql.Append(" and adultprice >= ");
                sql.Append(adultpricestart);
            }
            if (!string.IsNullOrEmpty(adultpriceend))
            {
                sql.Append(" and adultprice <= ");
                sql.Append(adultpriceend);
            }
            if (!string.IsNullOrEmpty(traveltype))
            {
                sql.Append(" and traveltypeid= ");
                sql.Append(traveltype);
            }

            if (!string.IsNullOrEmpty(titlekey))
            {
                sql.Append(" and title like '%");
                sql.Append(traveltype);
                sql.Append("%'");
            }
            if (!string.IsNullOrEmpty(startdate))
            {
                sql.Append(" and startdate <='");
                sql.Append(startdate);
                sql.Append("' ");
            }
            if (!string.IsNullOrEmpty(enddate))
            {
                sql.Append(" and enddate <='");
                sql.Append(enddate);
                sql.Append("' ");
            }
            if (!string.IsNullOrEmpty(destinationarea))
            {
                sql.Append(" and exists(select * from tb_destination where areaid=");
                sql.Append(destinationarea);
                if (!string.IsNullOrEmpty(destinationcity))
                {
                    sql.Append(" and cityid=");
                    sql.Append(destinationcity);
                }
                sql.Append(" and detailid=t1.id)");
            }
            int start = pageIndex * pageSize + 1;
            int end = (pageIndex + 1) * pageSize;
            if (end == 0) end = int.MaxValue;
            sql.Append(") as t2 where t2.rowid between " + start + " and " + end);
            ErrorLog.AddErrorLog(sql.ToString());
            DataTable dt = help.SeeResults(sql.ToString());
            return dt;
        }

        /// <summary>
        /// 按条件查询记录数,不使用的条件请传入空字符串或null
        /// </summary>
        /// <param name="journeydates">行程天数</param>
        /// <param name="adultprice">价格</param>
        /// <param name="traveltype">线路类型</param>
        /// <param name="destinationarea">目的地区</param>
        /// <param name="destinationcity">目的城市</param>
        /// <param name="titlekey">标题关键字</param>
        /// <param name="startdate">开始日期</param>
        /// <param name="enddate">结束日期</param>
        /// <param name="pageIndex">页索引,从0开始</param>
        /// <param name="pageSize">页大小,0即获取全部</param>
        /// <returns></returns>
        public int GetTravelInfoCountByCondition(string journeydates, string adultpricestart, string adultpriceend, string traveltype, string destinationarea, string destinationcity, string titlekey, string startdate, string enddate)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select count(*) from V_TravelInfo t1 where 1=1 ");
            if (!string.IsNullOrEmpty(journeydates))
            {
                sql.Append(" and journeydates=");
                sql.Append(journeydates);
            }
            if (!string.IsNullOrEmpty(adultpricestart))
            {
                sql.Append(" and adultprice >= ");
                sql.Append(adultpricestart);
            }
            if (!string.IsNullOrEmpty(adultpriceend))
            {
                sql.Append(" and adultprice <= ");
                sql.Append(adultpriceend);
            }
            if (!string.IsNullOrEmpty(traveltype))
            {
                sql.Append(" and traveltypeid= ");
                sql.Append(traveltype);
            }

            if (!string.IsNullOrEmpty(titlekey))
            {
                sql.Append(" and title like '%");
                sql.Append(traveltype);
                sql.Append("%'");
            }
            if (!string.IsNullOrEmpty(startdate))
            {
                sql.Append(" and startdate <='");
                sql.Append(startdate);
                sql.Append("' ");
            }
            if (!string.IsNullOrEmpty(enddate))
            {
                sql.Append(" and enddate <='");
                sql.Append(enddate);
                sql.Append("' ");
            }
            if (!string.IsNullOrEmpty(destinationarea))
            {
                sql.Append(" and exists(select * from tb_destination where areaid=");
                sql.Append(destinationarea);
                if (!string.IsNullOrEmpty(destinationcity))
                {
                    sql.Append(" and cityid=");
                    sql.Append(destinationcity);
                }
                sql.Append(" and detailid=t1.id)");
            }
            ErrorLog.AddErrorLog(sql.ToString());
            return int.Parse(help.RunSqlReturn(sql.ToString()));
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
        public int add(string title, string description, float generalprice, float adultprice, float childprice, string startdate, string enddate, string departuretime, string features, string billinclude, string billbeside, string servicestandard, string presentation, string journey, string contact, int traveltypeid, int journeydays, string transportation)
        {
            int res = 0;
            string sql = string.Format(@"insert into [tb_detail] ([title],[description],[generalprice],[adultprice],[childprice],[startdate],[enddate],[departuretime],[features],[billinclude],[billbeside],[servicestandard],[presentation],[journey],[contact],[traveltypeid],[journeydays],[transportation])
            values (@title, @description, @generalprice, @adultprice, @childprice, @startdate, @enddate, @departuretime, @features, @billinclude, @billbeside, @servicestandard, @presentation, @journey, @contact, @traveltypeid, @journeydays, @transportation) select @@identity");
            SqlParameter[] pas = new SqlParameter[] { 
                new SqlParameter("@title",title),
                new SqlParameter("@description",description),
                new SqlParameter("@generalprice",generalprice),
                new SqlParameter("@adultprice",adultprice),
                new SqlParameter("@childprice",childprice),
                new SqlParameter("@startdate",startdate),
                new SqlParameter("@enddate",enddate),
                new SqlParameter("@departuretime",departuretime),
                new SqlParameter("@features",features),
                new SqlParameter("@billinclude",billinclude),
                new SqlParameter("@billbeside",billbeside),
                new SqlParameter("@servicestandard",servicestandard),
                new SqlParameter("@presentation",presentation),
                new SqlParameter("@journey",journey),
                new SqlParameter("@contact",contact),
                new SqlParameter("@traveltypeid",traveltypeid),                 
                new SqlParameter("@journeydays",journeydays),
                new SqlParameter("@transportation",transportation)
            };
            res = int.Parse(help.RunSqlReturn(sql, pas));
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
        public int update(string title, string description, float generalprice, float adultprice, float childprice, string startdate, string enddate, string departuretime, string features, string billinclude, string billbeside, string servicestandard, string presentation, string journey, string contact, int journeydays, string transportation, int id)
        {
            int res = 0;
            string sql = " update [tb_detail] set [title]=@title,[description]=@description,[generalprice]=@generalprice,[adultprice]=@adultprice,[childprice]=@childprice,[startdate]=@startdate,[enddate]=@enddate,[departuretime]=@departuretime,[features]=@features,[billinclude]=@billinclude,[billbeside]=@billbeside,[servicestandard]=@servicestandard,[presentation]=@presentation,[journey]=@journey,[contact]=@contact,[journeydays]=@journeydays,[transportation]=@transportation where id=@id";
            SqlParameter[] pas = new SqlParameter[] { 
                new SqlParameter("@title",title),
                new SqlParameter("@description",description),
                new SqlParameter("@generalprice",generalprice),
                new SqlParameter("@adultprice",adultprice),
                new SqlParameter("@childprice",childprice),
                new SqlParameter("@startdate",startdate),
                new SqlParameter("@enddate",enddate),
                new SqlParameter("@departuretime",departuretime),
                new SqlParameter("@features",features),
                new SqlParameter("@billinclude",billinclude),
                new SqlParameter("@billbeside",billbeside),
                new SqlParameter("@servicestandard",servicestandard),
                new SqlParameter("@presentation",presentation),
                new SqlParameter("@journey",journey),
                new SqlParameter("@contact",contact),
                new SqlParameter("@journeydays",journeydays),
                new SqlParameter("@transportation",transportation),
                new SqlParameter("@id",id)
            };
            res = help.GetNum(sql, pas);
            return res;
        }

        public int ChangeState(int id, int state)
        {
            int res = 0;
            string sql = " update [tb_detail] set [state]=" + state + " where id=" + id;
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
            string sql = " delete from [tb_detail] where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }

    }
}
