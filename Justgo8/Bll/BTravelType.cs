using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BTravelType
    {
        public static int Inland = 1;
        public static int Outland = 3;
        public static int Periphery = 4;
        public static int Zyx = 5;

        public static DataTable TravelTypeInfo()
        {
            return new DLL.TravelType().TravelTypeInfo();
        }

        public static DataTable TravelTypeInfo(int id)
        {
            return new DLL.TravelType().TravelTypeInfo(id);
        }

        public static int add(string name)
        {
            return new DLL.TravelType().add(name);
        }

        public static int update(string name, int id)
        {
            return new DLL.TravelType().update(name, id);
        }

        public static int del(int id)
        {
            return 0;//不允许删除
           // return new DLL.TravelType().del(id);
        }

        public static DataTable HotTravelType()
        {
            return new DLL.TravelType().HotTravelType();
        }
    }
}
