using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.Data;

namespace Justgo8.Manage
{
    public partial class TravelManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTravelType();
            }
        }
        protected void BindTravelType()
        {
            DataTable dt = new DataTable();
            dt = Bll.BTravelType.TravelTypeInfo();
            if (dt.Rows.Count > 0)
            {
                repeatertraveltype.DataSource = dt;
                repeatertraveltype.DataBind();
            }
            else
            {
                repeatertraveltype.DataSource = null;
                repeatertraveltype.DataBind();
            }           
        }

        protected void RPlank_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int res = Bll.BArea.del(id);
                if (res == 1)
                {
                    MessageBox.ResponseScript(this.Page, "alert('删除成功');window.location.href='TravelManager.aspx'");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除失败')", true);
                }
            }
        }

        protected void repeatertraveltype_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                int typeid = Convert.ToInt32(rowv["traveltypeid"]);
                Repeater rep2 = e.Item.FindControl("repeaterdetail") as Repeater;//找到里层的repeater对象
                rep2.DataSource = Bll.BTravelDetail.TravelInfo(typeid);
                rep2.DataBind();                
            }
        }
    }
}