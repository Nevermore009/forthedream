using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class TerminalAlarm
    {


        public DataTable GetAllAirCondition()
        {
            string sql = "select t1.FloorName,t2.RoomName,t3.EquipmentName,t3.MinTemperature,t3.MaxTemperature,t3.InfoID,t3.IPAddress as localIPAddress  from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID and t2.RoomID=t3.RoomID and t3.EquipmentName='空调'";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }


        public bool UpdateTemperature(string minTemp, string maxTemp, string ipAddress)
        {
            string sql = "update roomsinfo set MinTemperature=@MinTemperature ,MaxTemperature=@MaxTemperature where IPAddress=@IPAddress";
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter ("@MinTemperature",minTemp),
                new SqlParameter ("@MaxTemperature",maxTemp),
                new SqlParameter ("@IPAddress",ipAddress)
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
        public DataTable GetAirTemp()
        {
            string sql = "select t3.FloorName,t2.RoomName,t1.EquipmentName,t1.MinTemperature,t1.MaxTemperature from RoomsInfo t1,Rooms t2,Floors t3 where EquipmentName='空调' and t1.RoomID=t2.RoomID and t2.FloorID=t3.FloorID";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
    }
}
