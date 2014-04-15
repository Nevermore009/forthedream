using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace DLL
{
   public class Patent
    {
       MsSqlHelper help = new MsSqlHelper();
       /// <summary>
       /// 查看专利技术
       /// </summary>
       /// <returns></returns>
       public DataTable PatentInfo()
       {
           DataTable dt = new DataTable();
           string sql = " select * from [tb_Patent] ";
           dt = help.SeeResults(sql);
           return dt;
       }

       /// <summary>
       /// 根据ID查询一条数据
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public DataTable PatentInfo(int id)
       {
           DataTable dt = new DataTable();
           string sql = " select * from [tb_Patent] where [id]="+id+" ";
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
       public int add(string name,string pic,string url,int sort)
       {
           int res = 0;
           string sql = " insert into [tb_Patent] ([name],[pic],[sort],[url],[dodate]) values ('" + name + "','" + pic + "'," + sort + ",'" + url + "',date()) ";
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
       public int update(string name, string pic,string url, int sort,int id)
       {
           int res = 0;
           string sql = "  update [tb_Patent] set [name]='" + name + "',[pic]='" + pic + "',[sort]=" + sort + ",[url]='" + url + "' where id=" + id + " ";
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
           string sql = " delete from [tb_Patent] where id="+id+" ";
           res = help.GetNum(sql);
           return res;
       }

       /// <summary>
       /// 首页
       /// </summary>
       /// <returns></returns>
       public DataTable Info()
       {
           DataTable dt = new DataTable();
           string sql = " select top 5 * from [tb_Patent] order by sort desc ,dodate desc ";
           dt = help.SeeResults(sql);
           return dt;
       }
    }
}
