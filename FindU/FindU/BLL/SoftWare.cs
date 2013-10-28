using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
   public class SoftWare
    {
       public bool Add(string Title, string Path, string Remark,string version)
       {
           string sql = @"insert into SoftWare(Title,Path,Remark,Version) values(@Title,@Path,@Remark,@version)";
           SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Title", Title), new SqlParameter("@Path", Path),  new SqlParameter("@Remark", Remark),new SqlParameter("@version",version) };
           return SqlHelper.ExecuteSql(sql, parameters) > 0;
       }
       public DataTable GetSoftWare()
       {
           string sql = @"select *From SoftWare";
           return SqlHelper.GetDataSet(sql).Tables[0];
       }
       public bool DeleteByID(int id)
       {
           string sql = "delete SoftWare where ID=@id";
           SqlParameter[] parameters = new SqlParameter[] { 
           new SqlParameter("@id",id)
           };
           return SqlHelper.ExecuteSql(sql, parameters) > 0;
       }
       public bool UpdateReamark(string remark, int id)
       {
           string sql = "update SoftWare set remark=@remark where  id=@id";
           SqlParameter[] paras = new SqlParameter[] { 
           new SqlParameter("@remark",remark),
           new SqlParameter("@id",id)
           };
           return SqlHelper.ExecuteSql(sql, paras)>0;
       }
    }
}
