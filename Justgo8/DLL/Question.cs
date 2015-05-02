using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DLL
{
   public class Question
    {
           MsSqlHelper help = new MsSqlHelper();
           /// <summary>
           /// 查看专利技术
           /// </summary>
           /// <returns></returns>
           public DataTable GetQuestionList()
           {
               DataTable dt = new DataTable();
               string sql = " select id,groupid,groupname,title,createtime from [tb_question] order by groupid,id asc";
               dt = help.SeeResults(sql);
               return dt;
           }

           /// <summary>
           /// 根据ID查询一条数据
           /// </summary>
           /// <param name="id"></param>
           /// <returns></returns>
           public DataTable GetQuestionByID(int id)
           {
               DataTable dt = new DataTable();
               string sql = " select * from [tb_question]  where [id]=" + id;
               dt = help.SeeResults(sql);
               return dt;
           }         
       
    }
}
