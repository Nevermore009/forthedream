﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DLL;

namespace Bll
{
   public class BPatent
    {
       public static DataTable pratentInfo()
       {
           return new DLL.Patent().PatentInfo();
       }

       public static DataTable pratentInfo(int id)
       {
           return new DLL.Patent().PatentInfo(id);
       }

       public static int add(string name, string pic,int detailid, int sort)
       {
           return new DLL.Patent().add(name, pic, detailid, sort);
       }

       public static int update(string name, string pic,int detailid, int sort,int id)
       {
           return new DLL.Patent().update(name, pic, detailid, sort, id);
       }

       public static int del(int id)
       {
           return new DLL.Patent().del( id);
       }

       public static DataTable info()
       {
           return new DLL.Patent().Info();
       }
    }
}
