using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BTravelPicture
    {
        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable PictureInfo(int detailid)
        {
            return new DLL.TravelPicture().PictureInfo(detailid);
        }

        /// <summary>
        /// 添加
        /// </summary>
        public static int add(int detailid, string picsrc)
        {
            return new DLL.TravelPicture().add(detailid, picsrc);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name">专利名称</param>
        /// <param name="pic">图片</param>
        /// <param name="sort">排序号</param>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static int update(string picsrc, int id)
        {
            return new DLL.TravelPicture().update(picsrc, id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(int id)
        {
            return new DLL.TravelPicture().del(id);
        }

    }
}
