using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace DLL
{
    public class Email
    {
        MsSqlHelper help = new MsSqlHelper();

        public  DataTable Emails()
        {
            string sql = " select * from [tb_email]";
            return help.SeeResults(sql);
        }
    }
}
