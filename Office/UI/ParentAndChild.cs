using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI
{
    #region 树结构父子关系类

    class ParentAndChild
    {
        public string Pid { set; get; }
        public string ID { set; get; }
        public string Name { set; get; }
        public ParentAndChild(string pid, string id, string name)
        {
            this.Pid = pid;
            this.ID = id;
            this.Name = name;
        }
    }

    #endregion
}
