using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMCShine.Data.Entities;
using SMCShine.Data;

namespace SMCShine.Logic
{
    public class SystemLogManage
    {
        public static void AddSystemLog(string userAccount, Guid campusGuid, string loginIp, string description)
        {
            SystemLog log = new SystemLog();
            log.CampusGuid = campusGuid;
            log.LoginIP = loginIp;
            log.UserAccount = userAccount;
            log.Description = description;
            GlobalDataContext dataContext = new GlobalDataContext();
            dataContext.SystemLog.InsertOnSubmit(log);
            dataContext.SubmitChanges();
        }
    }
}
