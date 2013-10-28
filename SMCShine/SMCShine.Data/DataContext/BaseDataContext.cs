using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Configuration;
using System.Data.Linq;

namespace SMCShine.Data
{
    /// <summary>
    /// 数据访问上下文基类
    /// </summary>
    public class BaseDataContext : DataContext
    {
        private string connectionString = null;
        private static MappingSource mappingSource = new AttributeMappingSource();
        protected static string defaultString = ConfigurationManager.ConnectionStrings["SMCShine"].ConnectionString;

        public string ConnectionString
        {
            get
            {
                if (connectionString == null)
                {
                    connectionString = string.Format(ConfigurationManager.ConnectionStrings["SMCShine"].ConnectionString);
                }
                return connectionString;
            }
        }

        public BaseDataContext()
            : base(defaultString, mappingSource)
        {
            base.Connection.ConnectionString = ConnectionString;
        }
    }
}
