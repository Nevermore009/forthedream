using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advanced_Encryption_Standard;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class User
    {
        public  string getPasswordByusername(string username)
        {
            string sql = "select passport from Users where username=@username";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@username",username)};
            object s = SqlHelper.ExecuteScalar(sql, parameters);
            if (s == null)
                return null;
            else
                return s.ToString();
        }

        public  bool LoginCheck(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;
            if (getPasswordByusername(username) == AES.codeEncrypt(password))   //数据存储的为密文的16编码,所以应使用codeEncrypt加密
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable UserMsg(string userName)
        {
            string sql = "select t1.username,t1.Passport,t2.RealName,t2.Gender,t2.PhoneNumber, CONVERT(varchar(100), GETDATE(), 102) as CreateTime from users t1 ,UserInfo t2 where t1.UserName=t2.UserName and t1.UserName=@UserName  order by t1.UserName desc";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName )
            };
            return SqlHelper.GetDataSet(sql, paras).Tables[0];
        }
        public bool UpdateMsg(string userName,string realName,string gender,string phoneNumber,string password)
        {
            string sqlUpdate1 = "update UserInfo set RealName=@RealName,Gender=@Gender,PhoneNumber=@PhoneNumber where UserName=@UserName";
            string sqlUpdate2 = "update Users set Passport=@Passprot where UserName=@UserName";
            SqlParameter[] paras1 = new SqlParameter[]
            {
                new SqlParameter("@RealName",realName),
                new SqlParameter("@Gender",gender),
                new SqlParameter("@PhoneNumber",phoneNumber),
                new SqlParameter("@UserName",userName)
            };
            SqlParameter[] paras2 = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter ("@Passprot",password)
            };
            SqlHelper.ExecuteSql(sqlUpdate2, paras2);
            return SqlHelper.ExecuteSql(sqlUpdate1, paras1) > 0;
        }

        public bool InsertMsg(string userName, string realName, string gender, string phoneNumber, string password)
        {
            string sqlInsert1="insert into UserInfo(UserName,RealName,Gender,PhoneNumber) values(@UserName,@RealName,@Gender,@PhoneNumber)";
            string sqlInsert2="insert into Users(UserName,Passport) values(@UserName,@Passport)";
            SqlParameter[] paras1 = new SqlParameter[]
            {
                new SqlParameter("@RealName",realName),
                new SqlParameter("@Gender",gender),
                new SqlParameter("@PhoneNumber",phoneNumber),
                new SqlParameter("@UserName",userName)
            };
            SqlParameter[] paras2 = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter ("@Passport",password)
            };
            SqlHelper.ExecuteSql(sqlInsert2, paras2);
             return SqlHelper.ExecuteSql(sqlInsert1, paras1) > 0;
        }
    }
}
