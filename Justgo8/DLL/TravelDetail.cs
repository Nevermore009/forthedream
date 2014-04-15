using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

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
            string sql = " select * from [tb_detail]  where [id]=" + id;
            dt = help.SeeResults(sql);
            return dt;
        }


        public DataTable TravelInfo(int traveltypeid, int num)
        {
            DataTable dt = new DataTable();
            string sql = " select top " + num + " * from [V_travelinfo]  where [traveltypeid]=" + traveltypeid;
            dt = help.SeeResults(sql);
            return dt;
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
        public int add(string title, string description, float generalprice, float adultprice, float childprice, string startdate, string enddate, string departuretime, string features, string billinclude, string billbeside, string servicestandard, string presentation, string journey, string contact, int traveltypeid)
        {
            int res = 0;
            string sql = string.Format(@"insert into [tb_detail] ([title],[description],[generalprice],[adultprice],[childprice],[startdate],[enddate],[departuretime],[features],[billinclude],[billbeside],[servicestandard],[presentation],[journey],[contact],[traveltypeid])
            values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',{15}) select @@identity", title, description, generalprice, adultprice, childprice, startdate, enddate, departuretime, features, billinclude, billbeside, servicestandard, presentation, journey, contact, traveltypeid);
            res = int.Parse(help.RunSqlReturn(sql));
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
        public int update(string title, string description, float generalprice, float adultprice, float childprice, string startdate, string enddate, string departuretime, string features, string billinclude, string billbeside, string servicestandard, string presentation, string journey, string contact, int id)
        {
            int res = 0;
            string sql = string.Format(" update [tb_detail] set [title]='{0}',[description]='{1}',[generalprice]='{2}',[adultprice]='{3}',[childprice]='{4}',[startdate]='{5}',[enddate]='{6}',[departuretime]='{7}',[features]='{8}',[billinclude]='{9}',[billbeside]='{10}',[servicestandard]='{11}',[presentation]='{12}',[journey]='{13}',[contact]='{14}' where id={15}",
                 title, description, generalprice, adultprice, childprice, startdate, enddate, departuretime, features, billinclude, billbeside, servicestandard, presentation, journey, contact, id);
            res = help.GetNum(sql);
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
