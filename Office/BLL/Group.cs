using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    /// <summary>
    /// 群组管理
    /// </summary>
    public class Group
    {
        public DataTable GetGroupListEquipment()
        {
            string sql = "select * from V_Groups where GroupState =1";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }
        public DataTable GetGroupByID(string groupID)
        {
            string sql = "select * from V_Groups where groupid=@groupid";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@groupID", groupID) };
            return SqlHelper.GetDataSet(sql, parameters).Tables[0];
        }

        public bool ChangeNameByID(string groupID, string groupName)
        {
            string sql = "update groups set groupName=@groupName where groupID=@groupID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@groupID", groupID), new SqlParameter("@groupName", groupName) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public void ChangeGroupByID(string groupID, string groupName, string[] equipmentID)
        {
            string procedurename = "changegroup";
            string equipmentids = "";
            foreach (string s in equipmentID)
            {
                equipmentids += s + ",";
            }
            if (equipmentids.Length >= 1)
                equipmentids = equipmentids.Substring(0, equipmentids.Length - 1);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@groupID", groupID), new SqlParameter("@groupname", groupName), new SqlParameter("@equipments", equipmentids) };
            SqlHelper.ExecuteProcedure(procedurename, parameters);
        }

        public void Add(string groupName, string[] equipmentID)
        {
            string procedurename = "addgroup";
            StringBuilder equipments = new StringBuilder();
            foreach (string id in equipmentID)
                equipments.Append(id + ",");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@groupname", groupName), new SqlParameter("@equipments", equipments.Length > 1 ? equipments.ToString(0, equipments.Length - 1) : "") };
            SqlHelper.ExecuteProcedure(procedurename, parameters);
        }

        public bool SetUnAvailable(string groupID)
        {
            string sql = "update groups set groupstate=0 where groupID=@groupID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@groupID", groupID) };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }

        public bool RenameGroup(string groupID, string groupName)
        {
            string sql = "update groups set GroupName=@groupName where groupID=@groupID";
            SqlParameter[] parameters = new SqlParameter[]
            { 
                new SqlParameter("@groupID", groupID), 
                 new SqlParameter("@groupName", groupName) 
            };
            return SqlHelper.ExecuteSql(sql, parameters) > 0;
        }


        public bool DeleteGroup(string groupID)
        { 
            string sql1="delete from GroupInfo where GroupID=@GroupID";
            string sql2 = "delete from Groups where GroupID=@groupID";
            SqlParameter[] paras1 = new SqlParameter[]
            {
              new SqlParameter("@GroupID",groupID)  
            };
            SqlParameter[] paras2 = new SqlParameter[]
            {
              new SqlParameter("@groupID",groupID)  
            };
            SqlHelper.ExecuteSql(sql1, paras1);
            return SqlHelper.ExecuteSql(sql2, paras2) > 0;
        }
    }
}
