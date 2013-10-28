using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Room
    {
        public DataTable GetEquipmentListTimer()
        {
            string sql = @"select * from timers t1 left join RoomsInfo t2 on t1.RoomID=t2.RoomID  ";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public DataTable GetRoomList()
        {
            string sql = "select * from V_Equipment";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public DataTable GetRoomByID(string roomID)
        {
            string sql = "select * from V_Equipment where roomID=@roomID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@roomID", roomID) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public DataTable GetRoomByFloorID(string floorID)
        {
            string sql = "select distinct * from Rooms t1 left join Floors t2 on t1.FloorID=t2.FloorID where  t2.floorID=@floorID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@floorID", floorID) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public bool ChangeNameByID(string roomID, string roomName)
        {
            string sql = "update rooms set roomName=@roomName where roomID=@roomID";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@roomID", roomID), 
                new SqlParameter("@roomName", roomName)
            };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public bool ChangeFloorID(string roomID, string floorID)
        {
            string sql = "update rooms set floorID=@floorID where roomID=@roomID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@roomID", roomID), new SqlParameter("@floorID", floorID) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public DataTable GetRoomTree()
        {
            string sql = "select null as pid,floorid as id,floorname as name from floors union select floorid,roomid ,roomname from rooms";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public string Add(string roomName, string floorID)
        {
            string sql = "insert into rooms(roomName,floorID) values(@roomName,@floorID);select @@IDENTITY";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@roomName", roomName), new SqlParameter("@floorID", floorID) };
            return SqlHelper.ExecuteScalar(sql, parameters).ToString();
        }

        public bool Delete(string roomID)
        {
            string sql = "delete from rooms where roomID=@roomID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@roomID", roomID) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public void DeleteRoom(string roomID)
        {
            string sql1 = "delete from RoomsInfo where RoomID=@RoomID";
            string sql2 = "delete from Rooms where RoomID =@RoomID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoomID", roomID) };
            SqlHelper.ExecuteSql(sql1, parameters);
            SqlHelper.ExecuteSql(sql2, parameters);
        }

    }
}
