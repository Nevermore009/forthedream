using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bll
{
  public  class BEmail
    {

      public static DataTable Emails()
      {
          return new DLL.Email().Emails();
      }
    }
}
