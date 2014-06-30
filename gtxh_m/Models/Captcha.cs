using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gtxh_m.Models
{
    /// <summary>
    /// 验证码实体类
    /// </summary>
    public class Captcha
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}