using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
   public  class RouteType
    {
       public DataTable GetRouteList()
       {
           string sql = "select * from RouteType";
           return SqlHelper.GetDataSet(sql).Tables[0];
       }
    }
}
