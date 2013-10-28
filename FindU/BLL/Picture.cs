using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class Picture
    {
        public bool Add(string imei, string description, string path)
        {
            string sql = "insert into Picture(IMEI,description,Photo) values(@imei,@description,@path) ";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@imei", imei), new SqlParameter("@description", description), new SqlParameter("@path", path) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public DataTable SelectByImei(string imei)
        {
            string sql = "select planinfoid from V_Plan where IMEI=@IMEI and planinfoState=1";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IMEI", imei) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public string GetPlanInfoIDByPic(string pic)
        {
            string sql = "select planinfoid from Picture where Photo=@pic";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@pic", pic) };
            object o = SqlHelper.ExecuteScalar(sql, parameters);
            return o != null ? o.ToString() : "";
        }

        public DataTable GetPicByPlanInfoID(string planinfoid)
        {
            string sql = "select * from Picture where PlaninfoID=@planinfoid";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@planinfoid", planinfoid) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public bool Delete(string pic)
        {
            string sql = "delete from Picture where photo=@pic";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@pic", pic) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public string GetLatestPictrue(string patrolid)
        {
            string sql = @"select top 1  photo  from patrol t1 inner join [Picture] t2 on t1.planinfoid=t2.PlanInfoID where t1.id=@id and ABS(datediff(MI, t1.CreateTime,t2.CreateTime))<1
 order by ABS(datediff(MI, t1.CreateTime,t2.CreateTime)) asc";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", patrolid) };
            object o = SqlHelper.ExecuteScalar(sql, parameters);
            return o == null ? "" : o.ToString();
        }
    }
}
