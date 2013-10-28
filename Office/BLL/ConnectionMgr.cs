using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Advanced_Encryption_Standard;

namespace BLL
{
    /// <summary>
    /// 数据库连接管理
    /// </summary>
    public class ConnectionMgr
    {
        public bool IsConnectionAvailable(string server, string user, string password)
        {
            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                return false;
            SqlConnectionStringBuilder constr = new SqlConnectionStringBuilder();
            constr.DataSource = server;
            constr.InitialCatalog = "EnergyConservation";
            constr.UserID = user;
            constr.Password = password;
            return SqlHelper.IsConnectionStringAvailable(constr.ConnectionString);
        }
    }
}
