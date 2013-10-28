using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Floor
    {
        public DataTable GetFloorList()
        {
            string sql = "select * from Floors";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public DataTable GetFloorByID(string floorID)
        {
            string sql = "select * from Floors where floorID=@floorID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@floorID", floorID) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public bool ChangeNameByID(string floorID, string floorName)
        {
            string sql = "update floors set floorName=@floorName where floorID=@floorID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@floorID", floorID), new SqlParameter("@floorName", floorName) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        /// <summary>
        /// 添加给定名称的楼层，返回楼层ID
        /// </summary>
        /// <param name="floorName"></param>
        /// <returns></returns>
        public string Add(string floorName)
        {
            string sql = "insert into floors(floorName) values(@floorName);select @@IDENTITY";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@floorName", floorName) };
            return SqlHelper.ExecuteScalar(sql, parameters).ToString();
        }

        public bool Delete(string floorID)
        {
            string sql = "delete from floors where floorID=@floorID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@floorID", floorID) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }
        public bool AddFloor(string floorName)
        {
            string sql = "insert into floors (FloorName) values(@FloorName)";
            SqlParameter[] paras = new SqlParameter[] 
            {
                new SqlParameter("@FloorName",floorName)
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
        public DataTable GetAllFloor()
        {
            string sql = "select * from floors order by FloorID desc";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable GetAllEquipmentName()
        {
            string sql = "select distinct(EquipmentName)  from roomsinfo";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable BindAllFloorName()
        {
            string sql = "select FloorName from Floors";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
    }
}
