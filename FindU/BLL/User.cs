using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Advanced_Encryption_Standard;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class User
    {
        /// <summary>
        /// 登录验证,返回结果代码,-1用户不存在,0密码错误,1验证通过
        /// </summary>
        /// <returns></returns>
        public int ValidateLogin(string UserName, string password, out Model.User model)
        {
            model = null;
            string sql = "select * from V_User where username=@username";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@username", UserName) };
            DataTable dt = SqlHelper.GetDataSet(sql, parameters).Tables[0];
            if (dt.Rows.Count <= 0)
                return -1;
            else
            {
                if (AES.codeEncrypt(password) == dt.Rows[0]["password"].ToString())
                {
                    model = new Model.User();
                    model.UserName = dt.Rows[0]["Username"].ToString();
                    model.RealName = dt.Rows[0]["RealName"].ToString();
                    model.RoleID = dt.Rows[0]["roleid"].ToString();
                    return 1;
                }
                else
                    return 0;
            }
        }

        public DataTable GetStaffList()
        {
            string sql = "select * from V_User where roleid=2";
            return SqlHelper.GetDataSet(sql).Tables[0];
        }

        public bool ChangePasswordByUsername(string userName,string password)
        {
            string sql = "update Users set password=@password where  userName=@userName";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@userName", userName), new SqlParameter("@password", AES.codeEncrypt(password)) };
            return SqlHelper.ExecuteSql(sql,parameters)>0;
        }
        public int GetStaffRole(string username)
        {
            string sql = "select roleid from V_User where  where UserName=@username";
            SqlParameter para = new SqlParameter("@username",username);
            return (int)SqlHelper.ExecuteScalar(sql,para); 
        }
    }
}
