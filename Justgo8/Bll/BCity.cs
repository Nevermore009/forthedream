using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
    public class BCity
    {
        public static DataTable CityInfo()
        {
            return new DLL.City().CityInfo();
        }

        public static DataTable CityInfo(int id)
        {
            return new DLL.City().CityInfo(id);
        }

        public static DataTable CityOfArea(int areaid)
        {
            return new DLL.City().CityOfArea(areaid);
        }

        public static int add(string name, int areaid, bool hot)
        {
            return new DLL.City().add(name, areaid, hot);
        }

        public static int update(string name, bool hot, int id)
        {
            return new DLL.City().update(name, hot, id);
        }

        public static int del(int id)
        {
            return new DLL.City().del(id);
        }

        public static DataTable HotCity(int areaid, int num)
        {
            return new DLL.City().HotCity(areaid, num);
        }
    }
}
