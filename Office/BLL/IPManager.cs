using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public  class IPManager
    {
        public DataTable GetAllEquipment()
        {
            string sql = @"select * from V_Equipment where infoid is not null";
           return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public bool UpdateIp(string infoID, string ipAddress,string duankou, string netMask, string gateWay,string macAddress)
        {
            string sql = "update Roomsinfo set IPAddress=@IPAddress,Port=@DuanKou,NetMask=@NetMask,Gateway=@Gateway,MacAddress=@MacAddress where InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@InfoID",infoID ),
                new SqlParameter ("@IPAddress",ipAddress ),
                new SqlParameter ("@DuanKou",duankou  ),
                new SqlParameter ("@NetMask",netMask ),
                new SqlParameter ("@Gateway",gateWay ),
                new SqlParameter ("@MacAddress",macAddress )
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }        
        public DataTable SelectInfoID(string infoID)
        {
            string sql = "select * from Roomsinfo where InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@InfoID",infoID )
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
    }
}
