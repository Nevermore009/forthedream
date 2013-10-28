using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Electricity
    {
        public DataTable GetAllHistory()
        {
            string sql = @"select FloorName,RoomName,CONVERT(date,createtime) as CreateTime,sum(Electricity) as 'Electricity' from 
V_AllFloorAllRoomElectricicy group by FloorName, RoomName,CONVERT(date,createtime);";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public DataTable GetHistoryByRoomID(string roomID)
        {
            string sql = "select * from electricity where roomID=@roomID order by createtime desc";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@roomID", roomID) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public DataTable GetHistoryByCondition( string condition, SqlParameter[] parameters)
        {
            string sql = string.Format(@"select t4.*,t3.RoomName,t3.RoomID,sum(t1.Electricity) as 'Electricity',CONVERT(date,t1.createtime) as createtime from Electricity t1 left join RoomsInfo t2 on t1.EquipmentID=t2.InfoID left join Rooms t3 on t2.RoomID=t3.RoomID left join Floors t4 on t3.FloorID=t4.FloorID where {0} group by t4.FloorID, t4.FloorName,t3.roomid, t3.RoomName,convert(date,t1.CreateTime)", condition ?? "");
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="meterValue">新的电表值</param>
        /// <returns></returns>
        public bool Add(string infoID, float meterValue)
        {
            string[] sqls = new string[2];
            sqls[0] = "insert into Electricity (EquipmentID,StartTime,Electricity)  select @infoID,lastmeterreadtime, @meterValue-lastmetervalue from RoomsInfo where infoID=@infoID";
            SqlParameter[][] parameters = new SqlParameter[2][];
            parameters[0] = new SqlParameter[] { new SqlParameter("@infoID", infoID), new SqlParameter("@meterValue", meterValue) };
            sqls[1] = "update roomsinfo set lastmetervalue=@meterValue,lastmeterreadtime=getdate() where infoid=@infoid";
            parameters[1] = new SqlParameter[] { new SqlParameter("@infoID", infoID), new SqlParameter("@meterValue", meterValue) };
            return SqlHelper.ExeTransaction(sqls, parameters);
        }
    }
}
