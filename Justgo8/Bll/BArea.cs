using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BArea
    {
        public static DataTable AreaInfo()
        {
            return new DLL.Area().AreaInfo();
        }

        public static DataTable AreaInfo(int id)
        {
            return new DLL.Area().AreaInfo(id);
        }

        public static DataTable AreaOfTravelType(int traveltypeid)
        {
            return new DLL.Area().AreaOfTravelType(traveltypeid);
        }

        public static int add(string name,int traveltypeid, bool hot)
        {
            return new DLL.Area().add(name, traveltypeid, hot);
        }

        public static int update(string name, bool hot, int id)
        {
            return new DLL.Area().update(name, hot, id);
        }

        public static int del(int id)
        {
            return new DLL.Area().del(id);
        }

        public static DataTable HotArea(int traveltypeid,int num)
        {
            return new DLL.Area().HotArea(traveltypeid, num);
        }
    }
}
