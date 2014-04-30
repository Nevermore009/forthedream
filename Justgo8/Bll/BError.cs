using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
   public class BError
    {
        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable Errors()
        {
            return new DLL.Error().Errors();
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable ErrorInfo(int id)
        {
            return new DLL.Error().ErrorInfo(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public static int add(int errorCode, string errorType, string errorContent, string url)
        {
            return new DLL.Error().add(errorCode, errorType, errorContent, url);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(int id)
        {
            return new DLL.Error().del(id);
        }
    }
}
