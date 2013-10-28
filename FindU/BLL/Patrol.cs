using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;
using System.Data;

namespace BLL
{
    public class Patrol
    {
        public bool Add(string lat, string lon, string locatetime, string imei, string remark,string isautolocate)
        {
            string sql = "insert into Patrol(imei,lat,lon,locatetime,remark,isautolocate) values(@imei,@lat,@lon,@locatetime,@remark,@isautolocate)";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@imei", imei), new SqlParameter("@lat", lat), new SqlParameter("@lon", lon), new SqlParameter("@locatetime", locatetime), new SqlParameter("@remark", remark), new SqlParameter("@isautolocate", isautolocate) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public DataTable GetHistoryList()
        {
            string sql = "select * from V_Patrol order by locatetime asc";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public DataTable GetHistoryByPlanInfoId(string planinfoid)
        {
            string sql = "select * from V_Patrol where planinfoid=@planinfoid order by locatetime asc";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@planinfoid", planinfoid) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public string GetHistoryXmlByPlanId(string planid)
        {
            string procedurename = "gettravelxml";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@planid", planid) };
            DataTable dt = SqlHelper.GetProcedureDataSet(procedurename, parameters).Tables[0];
            StringBuilder xml = new StringBuilder();
            foreach (DataRow r in dt.Rows)
            {
                xml.Append(r[0].ToString());
            }
            return xml.ToString();
        }

        public string GetPatrolXml(string planinfoid)
        {
            StringBuilder xml = new StringBuilder();
            string procedurename = "getpatrolxml";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@planinfoid", planinfoid) };
            DataTable dt = SqlHelper.GetProcedureDataSet(procedurename, parameters).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xml.Append(dt.Rows[i][0].ToString());
            }
            return xml.ToString();
        }

        public bool ModifyPatrolByID(string id, string remark)
        {
            string sql = "update [Patrol] set Remark=@Remark where @id=id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", id), new SqlParameter("@Remark", remark) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public DataTable GetPatrolInfo(string PlanYear, string PlanMonth, string staffID)
        {
            string sql = @"select planinfoid,staffname,routename,orderno from V_Patrol where planinfostate>0 and planyear=@PlanYear and PlanMonth=@PlanMonth and staffid=@staffID group by planinfoid,staffname,routename,orderno";
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@staffID",staffID),
            new SqlParameter("@PlanYear",PlanYear),
            new SqlParameter("@PlanMonth",PlanMonth)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        //根据年月查询，不需要用户StaffID
        public DataTable GetPatrolInfoWithoutSID(string PlanYear, string PlanMonth)
        {
            string sql = @"select planinfoid,staffname,routename,orderno from V_Patrol where planinfostate>0 and planyear=@PlanYear and PlanMonth=@PlanMonth group by planinfoid,staffname,routename,orderno";
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@PlanYear",PlanYear),
            new SqlParameter("@PlanMonth",PlanMonth)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }

        public DataTable GetPatrolByID(string id)
        {
            string sql = @"select * from V_Patrol where id=@id";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@id", id) };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
    }
}
