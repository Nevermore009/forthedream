using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BDestination
    {
        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable DestinationInfo(int detailid)
        {
            return new DLL.Destination().DestinationInfo(detailid);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="detailid"></param>
        /// <param name="areaid"></param>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public static int add(int detailid, int areaid, int cityid)
        {
            return new DLL.Destination().add(detailid, areaid, cityid);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int del(int id)
        {
            return new DLL.Destination().del(id);
        }
    }
}
