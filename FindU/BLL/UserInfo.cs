using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class UserInfo
    {
        public DataTable GetUserInfo(string username)
        {
            string sql = "select * from UserInfo where username=@username";
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@username",username)
            };
            return SqlHelper.GetDataSet(sql,paras).Tables[0];
        }
        public bool EditUserInfo(List<string> list)
        {
            string sql = @"update UserInfo set sex=@sex,position=@position,department=@department,educational=@educational,startwork=@startwork,
identitycard=@identitycard ,address=@address,phonenum=@phonenum,email=@email,summary=@summary,remark=@remark where username=@username ";
            SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@sex",list[0]),
             new SqlParameter("@position",list[1]),
                new SqlParameter("@department",list[2]),
                  new SqlParameter("@educational",list[3]),
                    new SqlParameter("@startwork",list[4]),
                      new SqlParameter("@identitycard",list[5]),
                        new SqlParameter("@address",list[6]),
                          new SqlParameter("@phonenum",list[7]),
                            new SqlParameter("@email",list[8]),
                              new SqlParameter("@summary",list[9]),
                               new SqlParameter("@remark",list[10]),
                                new SqlParameter("@username",list[11])
            };
            return SqlHelper.ExecuteSql(sql, paras) > 0;
        }
    }
}
