using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DLL
{
    public class TravelType
    {
        MsSqlHelper help = new MsSqlHelper();
        /// <summary>
        /// 查看专利技术
        /// </summary>
        /// <returns></returns>
        public DataTable TravelTypeInfo()
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_travelType] order by travelTypename asc";
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable TravelTypeInfo(int id)
        {
            DataTable dt = new DataTable();
            string sql = " select * from [tb_travelType] where [traveltypeid]=" + id;
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
        public int add(string name)
        {
            int res = 0;
            string sql = " insert into [tb_travelType] ([traveltypename]) values ('" + name + "') ";
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
        public int update(string name, int id)
        {
            int res = 0;
            string sql = "  update [tb_travelType] set [traveltypename]='" + name + "' where traveltypeid=" + id + " ";
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
            string sql = " delete from [tb_travelType] where traveltypeid=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public DataTable HotTravelType()
        {
            DataTable dt = new DataTable();
            string sql = " select top 5 * from [tb_travelType] traveltypename desc ";
            dt = help.SeeResults(sql);
            return dt;
        }
    }
}
