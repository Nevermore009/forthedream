using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class DelFRE
    {
        //--删除设备,根据节点找到InfoID，删除Timers，groupinfo，roomsinfo
        //string infoID="";
        //delete from Timers where InfoID=@InfoID
        //delete from GroupInfo where InfoID=@InfoID
        //delete from RoomsInfo where InfoID=@InfoID
        public bool DeleteEquipment(string infoID)
        {
            string sql1 = "delete from Timers where InfoID=@InfoID1";
            string sql2 = " delete from GroupInfo where InfoID=@InfoID2";
            string sql3 = "delete from RoomsInfo where InfoID=@InfoID3";
            SqlParameter[] paras1 = new SqlParameter[] 
            {
                new SqlParameter("@InfoID1",infoID)
            };
            SqlParameter[] paras2 = new SqlParameter[] 
            {
                new SqlParameter("@InfoID2",infoID)
            };
            SqlParameter[] paras3 = new SqlParameter[] 
            {
                new SqlParameter("@InfoID3",infoID)
            };
            SqlHelper.ExecuteSql(sql1, paras1);
            SqlHelper.ExecuteSql(sql2, paras2);
            return SqlHelper.ExecuteSql(sql3, paras3) > 0;
        }
        //--删除房间，根据节点ID找到RoomID，根据RoomID找到InfoID，删除timers，groupinfo，roomsinfo，rooms
        //string roomID="";
        //select InfoID from RoomsInfo where RoomID=@RoomID
        public DataTable SelectRoomID(string roomID)
        {
            string sql1 = "select InfoID from RoomsInfo where RoomID=@RoomID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@RoomID",roomID)
            };
            return SqlHelper.GetDataSet(sql1, paras).Tables[0];
        }
        //delete from Timers where InfoID=@InfoID
        //delete from GroupInfo where InfoID=@InfoID
        //delete from RoomsInfo where InfoID=@InfoID
        //delete from rooms where RoomID=@RoomID
        public bool DeleteRoom(string roomID)
        {
            DataTable dtRoom = SelectRoomID(roomID);
            for (int i = 0; i < dtRoom.Rows.Count; i++)
            {
                string infoID = dtRoom.Rows[0]["InfoID"].ToString();
                DeleteEquipment(infoID);
            }
            string sql1 = "delete from rooms where RoomID=@RoomID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@RoomID",roomID)
            };
            return SqlHelper.ExecuteSql(sql1, paras) > 0;
        }
        //--删除楼层，根据节点找到FloorID，根据FloorID找到RoomID，根据RoomID找到InfoID，删除timers，groupinfo，roomsinfo，rooms，Floors
        //string floorID="";
        //select RoomID from Rooms where FloorID=@Floor
        public DataTable SelectFloorID(string floorID)
        {
            string sql1 = "select RoomID from Rooms where FloorID=@FloorID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@FloorID",floorID)
            };
            return SqlHelper.GetDataSet(sql1, paras).Tables[0];
        }
        //select InfoID from RoomsInfo where RoomID=@RoomID
        //delete from Timers where InfoID=@InfoID
        //delete from GroupInfo where InfoID=@InfoID
        //delete from RoomsInfo where InfoID=@InfoID
        //delete from Rooms where RoomID=@RoomID
        //delete from Floors where FloorID=@FloorID
        public bool DeleteFloor(string floorID)
        {
            DataTable dtFloor = SelectFloorID(floorID);
            for (int i = 0; i < dtFloor.Rows.Count; i++)
			{
                string roomID = dtFloor.Rows[i]["RoomID"].ToString();
                DeleteRoom(roomID);
			}
            string sql1 = "delete from Floors where FloorID=@FloorID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@FloorID",floorID)
            };
            return SqlHelper.ExecuteSql(sql1, paras) > 0;
        }
    }
}
