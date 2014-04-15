using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DLL
{
    public class Area
    {
        MsSqlHelper help = new MsSqlHelper();
        /// <summary>
        /// 查看专利技术
        /// </summary>
        /// <returns></returns>
        public DataTable AreaInfo()
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_Area] order by areaname asc";
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable AreaInfo(int id)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_Area] where [areaid]=" + id;
            dt = help.SeeResults(sql);
            return dt;
        }


        public DataTable AreaOfTravelType(int traveltypeid)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_Area] where [traveltypeid]=" + traveltypeid + " order by  areaname asc";
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
        public int add(string name, int traveltypeid, bool hot)
        {
            int res = 0;
            string sql = " insert into [tb_Area] ([areaname],[traveltypeid],[hot]) values ('" + name + "'," + traveltypeid + "," + (hot ? "1" : "0") + ") ";
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
            string sql = "  update [tb_Area] set [areaname]='" + name + "',[hot]=" + (hot ? "1" : "0") + " where areaid=" + id + " ";
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
            string sql = " delete from [tb_Area] where areaid=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public DataTable HotArea(int traveltypeid, int num)
        {
            DataTable dt = new DataTable();
            string sql = " select top " + num + " * from [tb_Area] where traveltypeid=" + traveltypeid + " order by  hot desc,areaname asc ";
            dt = help.SeeResults(sql);
            return dt;
        }
    }
}
