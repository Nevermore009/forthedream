using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class TimerMgr
    {
        public bool Add(string roomID, string startTime, string stopTime)
        {
            if (Exist(roomID))
                return false;
            string sql = "insert into timers(roomid,starttime,stopTime) values(@roomID,@startTime,@stopTime)";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@roomID", roomID), new SqlParameter("@startTime", startTime), new SqlParameter("@stopTime", stopTime) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public bool SetUnavailable(string infoID)
        {
            string sql = "delete from Timers where InfoID=@infoID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@infoID", infoID) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public bool ChangeTime(string timerID, string startTime, string stopTime)
        {
            string sql = "update timers set startTime=@startTime,stopTime=@stopTime where timerID=@timerID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@timerID", timerID), new SqlParameter("@startTime", startTime), new SqlParameter("@stopTime", stopTime) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public bool Exist(string timerID)
        {
            string sql = "select count(*) from timers where roomID=@roomID and state=1";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@roomID", timerID) };
            return SqlHelper.Exists(sql, parameters);
        }

        public DataTable GetAvailableTimer()
        {
            string sql = @"select t4.FloorName,t1.RoomName,t2.EquipmentName,t3.Starttime,t3.Stoptime,t3.CreateTime,t3.InfoID,SUBSTRING(t3.RepeatTimes, 1, DATALENGTH(t3.RepeatTimes)-1)  as RepeatTime
                                    from Floors t4, Rooms t1 ,RoomsInfo t2,Timers t3 
                                    where t1.RoomID=t2.RoomID and  t2.InfoID=t3.InfoID and t4.FloorID=t1.FloorID";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable GetAvailableTimerByInfoID(string infoID)
        {
            string sql = @"select t4.FloorName,t1.RoomName,t2.EquipmentName,t3.Starttime,t3.Stoptime,t3.CreateTime,t3.InfoID,t3.RepeatTimes
                                    from Floors t4, Rooms t1 ,RoomsInfo t2,Timers t3 
                                    where t1.RoomID=t2.RoomID and  t2.InfoID=t3.InfoID and t3.InfoID=@InfoID and t4.FloorID=t1.FloorID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@InfoID",infoID)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }

        public bool TimerEquipmentOffer(string startTime, string stopTime, string infoID, string repeatTimes )
        {
            string sql1 = "insert into Timers (Starttime,Stoptime,InfoID,RepeatTimes,TimerState) values (@Starttime,@Stoptime,@InfoID,@RepeatTimes,@TimerState)";
            SqlParameter[] paras = new SqlParameter[]
               {
                    new SqlParameter ("@InfoID",infoID ),
                    new SqlParameter ("@Starttime",startTime ),
                    new SqlParameter ("@Stoptime",stopTime ),
                    new SqlParameter ("@RepeatTimes",repeatTimes ),
                    new SqlParameter ("@TimerState","1" )
               };
            return SqlHelper.ExecuteSql(sql1, paras) > 0;
        }

        public DataTable GetStartTime(string nowTime)
        {
            string sql = "select startTime,InfoID,RepeatTimes  from Timers  where Starttime<@NowTime ";
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter("@NowTime",nowTime )
            };
            DataSet ds = SqlHelper.GetDataSet(sql, paras);
            return ds.Tables[0];
        }

        public DataTable GetStopTime(string nowTime)
        {
            string sql = "select stopTime,InfoID,RepeatTimes  from Timers where stopTime<@NowTime";
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter("@NowTime",nowTime )
            };
            DataSet ds = SqlHelper.GetDataSet(sql, paras);
            return ds.Tables[0];
        }
        /// <summary>
        /// 执行定时开启关闭设备事件
        /// </summary>
        public bool ExecuteEquipment(string timerState, string infoID)
        {
            string sql = "update timers set TimerState =@TimerState where InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@TimerState",timerState ),
                new SqlParameter ("@InfoID",infoID)
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
        public DataTable GetInfoIDExist(string infoID)
        {
            string sql = "select * from Timers where InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter("@InfoID",infoID)
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        public bool DeleteAllTimers()
        {
            string sql = "delete from timers ";
            return SqlHelper.ExecuteSql(sql) > 0;
        }
        public bool UpdateTimers(string infoID, string startTime, string stopTime, string repeatTimes)
        {
            string sql = "update Timers set Starttime=@startTime,Stoptime=@stopTime,RepeatTimes=@repeatTimes where InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@InfoID",infoID ),
                new SqlParameter ("@repeatTimes",repeatTimes),
                new SqlParameter ("@stopTime",stopTime ),
                new SqlParameter ("@startTime",startTime )
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
        public bool DeleteTimers(string infoID)
        {
            string sql = "delete from Timers where InfoID=@InfoID";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter ("@InfoID",infoID )
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
    }
}
