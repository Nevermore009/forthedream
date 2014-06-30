using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace gtxh_m.Common
{
    public class MobileHelper
    {
        /// <summary>
        /// 提取字符串的手机号码
        /// </summary>
        /// <param name="phoneold"></param>
        /// <returns></returns>
        public static string FiltPhone(string phoneold)
        {
            string phonenew = "";
            Regex Expression = new Regex(@"[1][358]\d{9}");
            Match match = Expression.Match(phoneold, 0, phoneold.Length);
            if (match.Success)
                return phonenew = phoneold.Substring(match.Index, 11);
            else
                return "";
        }
    }
}