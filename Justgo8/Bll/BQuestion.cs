using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
    /// <summary>
    /// 常见问题
    /// </summary>
   public class BQuestion
    {
       public static DataTable GetQuestionList()
        {
            return new DLL.Question().GetQuestionList();
        }

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetQuestionByID(int id)
        {
            return new DLL.Question().GetQuestionByID(id);
        }         
       
    }
}
