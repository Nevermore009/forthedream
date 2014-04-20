using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DLL
{
    public class TravelPicture
    {
        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable PictureInfo(int detailid)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_travelPicture]  where [detailid]=" + detailid;
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
        public int add(int detailid, string picsrc)
        {
            int res = 0;
            string sql = "insert into [tb_travelPicture] ([detailid],[pic]) values ('" + detailid + "','" + picsrc + "')";
            res = help.GetNum(sql);
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
        public int update(string picsrc, int id)
        {
            int res = 0;
            string sql = string.Format(" update [tb_travelPicture] set [pic]='{0}' where id={1}", picsrc, id);
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
            string sql = " delete from [tb_travelPicture] where picid=" + id;
            res = help.GetNum(sql);
            return res;
        }

    }
}
