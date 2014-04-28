using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BRule
    {
        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable RuleInfo(int id)
        {
            return new DLL.Rule().RuleInfo(id);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable RulesOfType(int ruletype)
        {
            return new DLL.Rule().RulesOfType(ruletype);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public static int add(int ruletype, string content)
        {
            return new DLL.Rule().add(ruletype, content);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public static int update(string content, int id)
        {
            return new DLL.Rule().update(content, id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(int id)
        {
            return new DLL.Rule().del(id);
        }
    }
}
