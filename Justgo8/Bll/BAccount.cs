using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
   public class BAccount
    {
        public static int Validate(string username, string pwd)
        {
            pwd = Advanced_Encryption_Standard.AES.Encrypt(pwd);
            return new DLL.Account().Validate(username, pwd);
        }

        public static DataTable AccountInfo(string username)
        {
            return new DLL.Account().AccountInfo(username);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static int add(string username, string pwd, string phone, string email)
        {
            pwd=Advanced_Encryption_Standard.AES.Encrypt(pwd);
            return new DLL.Account().add(username, pwd, phone, email);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序号</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static int update(string username, string pwd, string phone, string email)
        {
            return new DLL.Account().update(username, pwd, phone, email);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(string username)
        {
            return new DLL.Account().del(username);
        }
    }
}
