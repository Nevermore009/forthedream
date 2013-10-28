using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Equipment
    {
        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetEquipmentList()
        {
            string sql = "select * from roomsinfo";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        /// <summary>
        /// 获取设备的树结构数据，即使没有设备，也有楼层信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetEquipmentTreeList()
        {
            string sql = @"select * from V_Equipment";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public static string sqlEuiqpmentByFloor = "";
        public DataTable GetEquipmentsByState()
        {
            string sqlEuiqpmentByFloor = @"select t1.FloorName,t2.RoomName,t3.EquipmentName,t3.InfoID,t3.EquipmentState  from Floors t1 left join Rooms t2 on t1.FloorID=t2.FloorID right join RoomsInfo t3 on t2.RoomID=t3.RoomID and t3.EquipmentState in(0,1,2) group by t1.FloorName,t2.RoomName,t3.EquipmentName,t3.InfoID,t3.EquipmentState order by t2.RoomName asc";
            return SqlHelper.GetDataSet(sqlEuiqpmentByFloor).Tables[0];
        }
        public DataTable GetEquipmentByFloor(string floorName)
        {
            string sqlEuiqpmentByFloor = "select t1.FloorName,t2.RoomName,t3.EquipmentName,t3.InfoID,t3.EquipmentState  from Floors t1 left join Rooms t2 on t1.FloorID=t2.FloorID  right join RoomsInfo t3 on t2.RoomID=t3.RoomID and t3.EquipmentState in(0,1,2)   where  t1.FloorName=@FloorName group by t1.FloorName,t2.RoomName,t3.EquipmentName,t3.InfoID,t3.EquipmentState order by t2.RoomName asc";
            SqlParameter[] paras = new SqlParameter[]
            {
                 new SqlParameter("@FloorName",floorName)
                //new SqlParameter("@FloorName","%"+floorName+"%")
            };
            return SqlHelper.GetDataSet(sqlEuiqpmentByFloor, paras).Tables[0];
        }
        public DataTable GetEquipmentById(string infoID)
        {
            string sql = "select * from V_Equipment where infoID=@infoID";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@infoID", infoID) };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }

        public bool AddEquipment(string roomID, string EquipmentName)
        {
            string sqlInsert = "insert into RoomsInfo (RoomID ,EquipmentName ) values (@RoomID,@EquipmentName)";
            SqlParameter[] paras = new SqlParameter[]
            {
            new SqlParameter ("@RoomID",roomID ),
            new SqlParameter ("@EquipmentName",EquipmentName )
            };
            return SqlHelper.ExecuteSql(sqlInsert, paras) > 0;
        }
        public bool IsExist(string roomID, string EquipmentName)
        {
            string sqlSelect = "select count(*) from RoomsInfo where EquipmentName =@EquipmentName and RoomID=@RoomID";
            SqlParameter[] paras = new SqlParameter[]
            {
            new SqlParameter ("@RoomID",roomID ),
            new SqlParameter ("@EquipmentName",EquipmentName )
            };
            return SqlHelper.Exists(sqlSelect, paras);
        }
        public bool EquipmentOffer(string infoID, string equipment)
        {
            string sql = "update RoomsInfo set EquipmentState=@equipment  where InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[]
            {
            new SqlParameter ("@InfoID",infoID ),
            new SqlParameter ("@equipment",equipment  )
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
        public bool IsOpen(string infoID)
        {
            string sqlSelect = "select count(*) from RoomsInfo where InfoID=@InfoID and EquipmentState=1";
            SqlParameter[] paras = new SqlParameter[]
            {
            new SqlParameter ("@InfoID",infoID  )
            };
            return SqlHelper.Exists(sqlSelect, paras);
        }
        public DataTable GetIPByID(string ID)
        {
            string sql = "select IPAddress,Port from V_Equipment where infoID=@ID";
            SqlParameter[] paras = new SqlParameter[]
            {
            new SqlParameter ("@ID",ID  )
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }

        public int EquipmentCount()
        {
            string sql = "select * from RoomsInfo";
            DataSet ds = SqlHelper.GetDataSet(sql);
            return ds.Tables[0].Rows.Count;
        }

        public bool UpdateEquipmentState(string state, string str)
        {
            string sql = "update RoomsInfo set EquipmentState=@EquipmentState where InfoID in (" + str + ") ";
            SqlParameter[] paras = new SqlParameter[]
            {
            new SqlParameter("@EquipmentState",state )
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
        public DataTable SelectTemperature()
        {
            string sql = "select t1.FloorName,t2.RoomName,t3.EquipmentName,t3.MinTemperature,t3.MaxTemperature,t3.InfoID from Floors t1,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID and t2.RoomID=t3.RoomID and t3.EquipmentName='空调'";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }


        public DataTable SelectHalfEquipment(string euipmentName)
        {
            string sql = "select * from RoomsInfo where EquipmentName=@EquipmentName order by InfoID desc";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@EquipmentName",euipmentName )
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }

        public DataTable SelectStateEquipment()
        {
            string sql = "select * from RoomsInfo";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable SelectOtherMsg(string infoID)
        {
            string sql = "select t1.RoomName,t2.EquipmentName,t2.InfoID,t2.MaxTemperature,t2.MinTemperature from Rooms t1 ,RoomsInfo t2 where t1.RoomID=t2.RoomID and t2.InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@InfoID",infoID)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];

        }

        public DataTable GetEquipmentByIp(string ip)
        {
            string sql = "select t1.FloorName,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress,t3.MinTemperature,t3.MaxTemperature from Floors t1 ,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID and t2.RoomID=t3.RoomID and t3.IPAddress=@IpAddress";
            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@IpAddress",ip)
           };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        public DataTable GetEquipmentByInfoID(string infoID)
        { 
            string sql="select t1.FloorName,t2.RoomName,t3.EquipmentName,t3.EquipmentState,t3.InfoID,t3.IPAddress,t3.MinTemperature,t3.MaxTemperature from Floors t1 ,Rooms t2,RoomsInfo t3 where t1.FloorID=t2.FloorID and t2.RoomID=t3.RoomID and t3.InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("InfoID",infoID)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
    }
}
