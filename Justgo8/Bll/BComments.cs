using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BComments
    {
        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable GetComments()
        {
            return new DLL.Comments().GetComments();
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public static DataTable CommentInfo(int id)
        {
            return new DLL.Comments().CommentInfo(id);
        }
        
        /// <summary>
        /// 获取随机行
        /// </summary>
        /// <param name="rowcount"></param>
        /// <returns></returns>
        public static DataTable GetRandomComment(int rowcount = 1)
        {
            return new DLL.Comments().GetRandomComment(rowcount);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(int id)
        {
            return new DLL.Comments().del(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序号</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static int update(string content, int id)
        {
            return new DLL.Comments().update(content, id);
        }

    }
}
