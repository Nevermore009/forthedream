using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class Route
    {
        /// <summary>
        /// z
        /// </summary>
        /// <param name="routeName"></param>
        /// <param name="description"></param>
        /// <returns>生成的routeID</returns>
        public string Add(string routeName, string description)
        {
            string sql = "insert into [route](routename,description) values(@routeName,@description);select @@identity;";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@routeName", routeName), new SqlParameter("@description", description) };
            object o = SqlHelper.ExecuteScalar(sql, parameters);
            return o == null ? null : o.ToString();
        }

        public bool AddRouteInfo(string routeid, int orderno, string lat, string lon, string title, string description)
        {
            string sql = "insert into [routeinfo](routeid,orderno,lat,lon,title,description) values(@routeid,@orderno,@lat,@lon,@title,@description)";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@routeid", routeid), new SqlParameter("@orderno", orderno), new SqlParameter("@lat", lat), new SqlParameter("@lon", lon), new SqlParameter("@title", title), new SqlParameter("@description", description) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public DataTable GetRouteList()
        {
            string sql = "select * from [route]";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable GetRoute()
        {
            string sql = "select* from Route,RouteType where RouteTypeID=RouteType.ID";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable GetRouteById(string routeid)
        {
            string sql = "select * from V_Route where routeid=@routeid order by orderno asc";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@routeid", routeid) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }
        public bool ModifyRouteById(string routeid, string routename, string description)
        {
            string sql = "update [route] set routename=@routename,description=@description where routeid=@routeid";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@routename", routename), new SqlParameter("@routeid", routeid), new SqlParameter("@description", description) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public string GetAllRouteXml()
        {
            StringBuilder xml = new StringBuilder();
            string procedurename = "getallroutexml";
            DataTable dt = SqlHelper.GetProcedureDataSet(procedurename).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xml.Append(dt.Rows[i][0].ToString());
            }
            return xml.ToString();
        }

        public string GetRouteXml(string routeid)
        {
            StringBuilder xml = new StringBuilder();
            string procedurename = "getroutexml";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@routeid", routeid) };
            DataTable dt = SqlHelper.GetProcedureDataSet(procedurename, parameters).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xml.Append(dt.Rows[i][0].ToString());
            }
            return xml.ToString();
        }


        public string GetRouteIDByPlanID(string planid)
        {
            string sql = "select routeid from [plan] where planid=@planid";
            SqlParameter[] paramters = new SqlParameter[] { new SqlParameter("@planid", planid) };
            object o = SqlHelper.ExecuteScalar(sql, paramters);
            return o == null ? null : o.ToString();
        }

        public DataTable GetRouteByTypeID(int routeTypeid)
        {
            string sql = "select * from route where RouteTypeID=@routeTypeid  ";
            SqlParameter para = new SqlParameter("@routeTypeid", routeTypeid);
            return SqlHelper.GetDataSet(sql, para).Tables[0];
        }
    }
}
