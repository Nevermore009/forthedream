using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace SMCShine.Common
{
    public class BindHelper
    {
        /// <summary>
        /// 绑定DropDownList
        /// </summary>
        /// <param name="drop">要绑定的DropDownList</param>
        /// <param name="datasource">DropDownList的数据源</param>
        /// <param name="textmember">显示成员</param>
        /// <param name="valuemember">值成员</param>
        /// <param name="firstitem">自定义首选项</param>
        public static void BindDropDownList(DropDownList drop, object datasource, string textmember, string valuemember, params string[] firstitem)
        {
            drop.Items.Clear();
            drop.DataSource = datasource;
            drop.DataTextField = textmember;
            drop.DataValueField = valuemember;
            drop.DataBind();
            if (firstitem.Length > 0)
            {
                drop.Items.Insert(0, new ListItem(firstitem[0], firstitem[0]));
            }
        }

        /// <summary>
        /// 绑定gridview
        /// </summary>
        public static void BindGridview(GridView grv, object datasource)
        {
            grv.DataSource = datasource;
            grv.DataBind();
            if (grv.Rows.Count <= 0)
            {
                grv.DataSource = null;
                grv.DataBind();
            }
        }
        public static void BindRepeater(Repeater repeater, object datasource)
        {
            repeater.DataSource = datasource;
            repeater.DataBind();
            if (repeater.Items.Count <= 0)
            {
                repeater.DataSource = null;
                repeater.DataBind();
            }
        }

    }
}