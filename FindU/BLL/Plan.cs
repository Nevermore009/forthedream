using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class Plan
    {
        public bool AddCollectPlan(string planname, string description, string staffid)
        {
            string[] sqls = new string[3];
            sqls[0] = "update Staff set isonplan=1 where staffid=@staffid";
            sqls[1] = "insert into [Plan](planname,description,plantype,staffid,patrolcount) values(@planname,@description,1,@staffid,1)";
            sqls[2] = "insert into planinfo(planid,orderno,state) values(@@IDENTITY,1,1)";
            SqlParameter[][] parameters = new SqlParameter[2][];
            parameters[0] = new SqlParameter[] { new SqlParameter("@staffid", staffid) };
            parameters[1] = new SqlParameter[] { new SqlParameter("@planname", planname), new SqlParameter("@description", description), new SqlParameter("@staffid", staffid) };
            return SqlHelper.ExeTransaction(sqls, parameters);
        }

        public bool AddPatrolPlan(string routeid, string description, string staffid, string PlanYear, string PlanMonth, int PatrolCount, List<string> plandatelist)
        {
            if (PatrolCount != plandatelist.Count)
                return false;
            StringBuilder plandatexml = new StringBuilder();
            plandatexml.AppendLine("<root>");
            for (int i = 1; i <= PatrolCount; i++)
            {
                plandatexml.AppendLine("<planinfo orderno='" + i.ToString() + "' plandate='" + plandatelist[i - 1] + "' />");
            }
            plandatexml.AppendLine("</root>");
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@routeid", routeid),
                new SqlParameter("@description", description),
                new SqlParameter("@staffid", staffid),
                new SqlParameter("@PlanYear", PlanYear),
                new SqlParameter("@PlanMonth", PlanMonth),
                new SqlParameter("@PatrolCount", PatrolCount),
                new SqlParameter("@plandatexml",plandatexml.ToString())
            };
            return SqlHelper.ExecuteProcedure("AddPatrolPlanPro", parameters);
        }

        public DataTable GetCollectPlanList()
        {
            string sql = "select * from V_Plan  where plantype=1";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }


        public bool DeleteById(string planID)
        {
            string procedurename = "DeletePLanByid";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@planID", planID), 
                
            };
            return SqlHelper.ExecuteProcedure(procedurename, parameters);
        }

        public bool ModifyPatrolPlanById(string planid, string newcount, string oldcount)
        {
            int newCount = int.Parse(newcount);
            int oldCount = int.Parse(oldcount);

            if (oldCount == newCount)
            {
                return true;
            }
            string procedurename = "EditPatrolCount";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@planid", planid), new SqlParameter("@newCount", newCount), new SqlParameter("@oldCount", oldCount) };
            return SqlHelper.ExecuteProcedure(procedurename, parameters);
        }
        public bool UpdatePatrolPlanById(string planid, string planname, string description)
        {
            string sql = "update [Plan] set PlanName=@planname,Description=@description  where PlanID=@planid";
            SqlParameter[] paras = new SqlParameter[] { 
                 new SqlParameter("@description", description),
                new SqlParameter("@planname", planname),
                 new SqlParameter("@planid", planid)
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
        public bool Finish(string imei)
        {
            string procedurename = "finishplan";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@imei", imei) };
            return SqlHelper.ExecuteProcedure(procedurename, parameters);
        }
        //根据当前月份绑定
        public DataTable GetMonthPlan(string thisYear, string thisMonth)
        {
            string sql = @"select distinct staffname,RouteTypeName,RouteName,planyear,planmonth,sum(PatrolCount) over(partition by staffname,RouteTypeName,RouteName,planyear,planmonth) PatrolCount
from (select distinct staffname,RouteTypeName,RouteName,planyear,planmonth,PatrolCount,PlanType from V_Plan where PlanType=0 
and planmonth=@thisMonth and planyear=@thisYear )t where t.PlanType=0 and planmonth=@thisMonth and planyear=@thisYear   ";
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@thisyear",thisYear),
            new SqlParameter("@thismonth",thisMonth)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        public DataTable GetMonthPlanByName(string thisYear, string thisMonth, string staffname)
        {
            string sql = @"select PlanID,PlanName,PatrolCount,staffname,RouteTypeName,RouteName,planyear,planmonth,convert(date,createtime) as plandate,SUM(case when planinfostate=2 then 1 else 0 end)as finishcount from V_Plan where PlanType=0 
and planmonth=@thismonth and planyear=@thisyear and staffname=@staffname group by PlanID,PlanName,PatrolCount,staffname,RouteTypeName,RouteName,convert(date,createtime),planyear,planmonth ";
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@thisyear",thisYear),
            new SqlParameter("@thismonth",thisMonth),  
            new SqlParameter("@staffname",staffname)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        public DataTable GetPatrolPlanList()
        {
            string sql = @"select PlanID,PlanName,PatrolCount,staffname,RouteTypeName,RouteName,[state],planyear,planmonth,convert(date,createtime) as plandate,SUM(case when planinfostate=2 then 1 else 0 end)as finishcount from V_Plan where PlanType=0 
group by PlanID,PlanName,PatrolCount,staffname,RouteTypeName,RouteName,convert(date,createtime),planyear,planmonth,[state]";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public string GetPlanID()
        {
            string sql = " select top(1)PlanID from [plan] order by PlanID desc ";
            object o = SqlHelper.ExecuteScalar(sql);
            return o == null ? "" : o.ToString();
        }
        public bool UpdateStartDay(string planid, List<string> list)
        {
            string[] sqls = new string[list.Count];
            SqlParameter[][] paras = new SqlParameter[list.Count][];
            for (int i = 1; i <= list.Count; i++)
            {
                sqls[i - 1] = "update planinfo set plandate=@plandate where planid=@planid";
                paras[i - 1] = new SqlParameter[] { 
                new SqlParameter("@plandate",list[i-1]),
                new SqlParameter("@planid",planid)
                };
            }
            return SqlHelper.ExeTransaction(sqls, paras);
        }
    }
}
