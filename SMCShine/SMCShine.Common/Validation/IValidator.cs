using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMCShine.Common.Validation
{
    public interface IValidator
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 执行验证
        /// </summary>
        void Validate(object obj);
    }
}
