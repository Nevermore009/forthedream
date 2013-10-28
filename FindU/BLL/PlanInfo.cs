using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
   public class PlanInfo
    {
       public DataTable GetPlanInfoList(string planid)
       {
           string sql = @"select * from PlanInfo where planid=@planid order by orderno asc";
           SqlParameter para = new SqlParameter("@planid",planid);
           return SqlHelper.GetDataSet(sql,para).Tables[0];
       }
       public DataTable GetListByList(List<string> list)
       {
           string sql = @"select PlanID,PlanName,PatrolCount,staffname,RouteTypeName,RouteName,[state],planyear,planmonth,convert(date,createtime) as plandate,SUM(case when planinfostate=2 then 1 else 0 end)as finishcount from V_Plan where PlanType=0 ";
           if (list[0] != "")
           {
               sql += "and StaffName='"+list[0]+"'";
           }
           if (list[1] != "")
           {
               sql += " and RouteTypeName='"+list[1]+"'";
           }
           if (list[2] != "")
           {
               sql += " and RouteName='" + list[2] + "'";
           }
           if (list[3] != "")
           {
               sql += " and planmonth='" + list[3] + "'";
           }
           sql += " group by PlanID,PlanName,PatrolCount,staffname,RouteTypeName,RouteName,convert(date,createtime),planyear,planmonth,[state]";
           return SqlHelper.GetDataSet(sql).Tables[0];
       }
    }
}
