using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DLL
{
    public class City
    {
        MsSqlHelper help = new MsSqlHelper();
        /// <summary>
        /// 查看专利技术
        /// </summary>
        /// <returns></returns>
        public DataTable CityInfo()
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_City] order by Cityname asc";
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable CityInfo(int cityid)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_City]  where [Cityid]=" + cityid;
            dt = help.SeeResults(sql);
            return dt;
        }

        public DataTable CityOfArea(int areaid)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_City] where [areaid]=" + areaid + " order by  cityname asc";
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 添加专利
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public int add(string name, int areaid, bool hot)
        {
            int res = 0;
            string sql = " insert into [tb_City] ([Cityname],Areaid,[hot]) values ('" + name + "'," + areaid + "," + (hot ? "1" : "0") + ") ";
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
        public int update(string name, bool hot, int id)
        {
            int res = 0;
            string sql = "  update [tb_City] set [Cityname]='" + name + "',[hot]=" + (hot ? "1" : "0") + " where Cityid=" + id + " ";
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
            string sql = " delete from [tb_City] where Cityid=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public DataTable HotCity(int areaid, int num)
        {
            DataTable dt = new DataTable();
            string sql = " select top " + num + " * from [tb_City] where areaid=" + areaid + " hot desc,Cityname desc ";
            dt = help.SeeResults(sql);
            return dt;
        }
    }
}
