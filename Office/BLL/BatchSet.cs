using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BatchSet
    {
        //有楼层和设备名
        //select t1.FloorID,t1.FloorName,t2.RoomID,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress 
        //from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID 
        //and t2.RoomID=t3.RoomID and t1.FloorID='124' and t3.EquipmentName='空调' order by InfoID desc
        public DataTable YFandYE(string floorID, string equipmentName)
        {
            string sql = @"select t1.FloorID,t1.FloorName,t2.RoomID,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress 
            from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID and t2.RoomID=t3.RoomID and t1.FloorID=@FloorID and t3.EquipmentName=@EquipmentName order by InfoID desc";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@FloorID",floorID),
                new SqlParameter("@EquipmentName",equipmentName)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        //没有楼层没有设备名
        //select t1.FloorID,t1.FloorName,t2.RoomID,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress 
        //from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID 
        //and t2.RoomID=t3.RoomID  order by InfoID desc
        public DataTable NFandNE()
        {
            string sql = @"select t1.FloorID,t1.FloorName,t2.RoomID,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress 
            from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID and t2.RoomID=t3.RoomID  order by InfoID desc";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        //没有楼层有设备名
        //select t1.FloorID,t1.FloorName,t2.RoomID,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress 
        //from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID 
        //and t2.RoomID=t3.RoomID and t3.EquipmentName='空调' order by InfoID desc
        public DataTable NFandYE(string equipmentName)
        {
            string sql = @"select t1.FloorID,t1.FloorName,t2.RoomID,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress 
           from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID and t2.RoomID=t3.RoomID and t3.EquipmentName=@EquipmentName order by InfoID desc";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@EquipmentName",equipmentName)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        //有楼层没有设备名
        //select t1.FloorID,t1.FloorName,t2.RoomID,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress 
        //from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID 
        //and t2.RoomID=t3.RoomID and t1.FloorID='124' order by InfoID desc
        public DataTable YFandNE(string floorID)
        {
            string sql = @"select t1.FloorID,t1.FloorName,t2.RoomID,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress 
            from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID and t2.RoomID=t3.RoomID and t1.FloorID=@FloorID order by InfoID desc";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@FloorID",floorID)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
    }
}
