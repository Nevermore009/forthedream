using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class HelpText
    {
        public DataTable GetHelpList()
        {
            string sql = "select * from helptext";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public DataTable GetHelpByTitle(string title)
        {
            string sql = "select * from helptext where title like '%'+@title+'%'";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@title", title) };
            return SqlHelper.GetDataSet(sql,parameters).Tables[0];
        }
    }
}
