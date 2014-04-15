using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class BProtocol
    {
        public static string getprotocol()
        {
            return new DLL.Protocol().getprotocol();
        }

        /// <summary>
        /// 添加
        /// </summary>
        public static int add(string content)
        {
            return new DLL.Protocol().add(content);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public static int update(string content, int id)
        {
            return new DLL.Protocol().update(content, id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public static int del(int id)
        {
            return new DLL.Protocol().del(id);
        }

    }
}
