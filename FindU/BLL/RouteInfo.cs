using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class RouteInfo
    {
        public bool ModifyRouteInfoById(int routeinfoid, string title, string description)
        {
            string sql = "update [RouteInfo] set title=@title,Description=@description where routeinfoid=@routeinfoid";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@title", title), new SqlParameter("@routeinfoid", routeinfoid), new SqlParameter("@description", description) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public DataTable GetByRouteiD(int routeid)
        {
            string sql = "select * from RouteInfo where RouteID=@routeid ";
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@routeid",routeid)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        public bool DeleteRouteInfoById(int routeinfoid)
        {
            string sql = "delete from RouteInfo where RouteInfoID=@routeinfoid";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@routeinfoid", routeinfoid) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public bool ModifyTitleById(int routeinfoid, string title,string lat,string lon)
        {
            string sql = "update [RouteInfo] set title=@title,Lat=@lat,Lon=@lon where routeinfoid=@routeinfoid";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@title", title), new SqlParameter("@lon", lon), new SqlParameter("@lat", lat), new SqlParameter("@routeinfoid", routeinfoid) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public bool insertRow(int routeinfoid,string title,string lat,string lon)
        {
           string procedurename = "InserROwPro";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@routeinfoid", routeinfoid),
   new SqlParameter("@title", title),
   new SqlParameter("@lat", lat),
   new SqlParameter("@lon", lon),  
            };
            return SqlHelper.ExecuteProcedure(procedurename, parameters);
        }
       
    }
}
