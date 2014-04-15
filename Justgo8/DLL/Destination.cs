using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace DLL
{
    public class Destination
    {

        MsSqlHelper help = new MsSqlHelper();

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable DestinationInfo(int detailid)
        {
            DataTable dt = new DataTable();
            string sql = "select t1.*,t2.cityname,t3.areaname from [tb_destination] t1 left join [tb_city] t2 on t1.cityid=t2.cityid left join [tb_area] t3 on t1.areaid=t3.areaid where t1.[detailid]=" + detailid;
            dt = help.SeeResults(sql);
            return dt;
        }

        /// <summary>
        /// 添加
        /// </summary>
        public int add(int detailid, int areaid, int cityid)
        {
            int res = 0;
            string sql = string.Format(@"insert into [tb_destination] ([detailid],[areaid],[cityid])  values ('{0}','{1}','{2}') ", detailid, areaid, cityid);
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
            string sql = " delete from [tb_destination] where id=" + id + " ";
            res = help.GetNum(sql);
            return res;
        }
    }
}
