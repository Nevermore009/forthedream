using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMCShine.Common.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredValidator : Attribute, IValidator
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 执行验证
        /// </summary>
        /// <param name="obj">待验证的值</param>
        public void Validate(object obj)
        {
            if (obj.ToString().Length == 0)
            {
                throw new ValidationException(ErrorMessage);
            }
        }
    }
}
