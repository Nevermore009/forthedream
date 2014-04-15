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
                BindDetail(Bll.BTravelType.Inland);
            }
        }
        protected void BindDetail(int traveltypeid)
        {
            DataTable dt = new DataTable();
            dt = Bll.BTravelDetail.TravelInfo(traveltypeid);
            if (dt.Rows.Count > 0)
            {
                repeaterdestination.DataSource = dt;
                repeaterdestination.DataBind();
            }
            else
            {
                repeaterdestination.DataSource = null;
                repeaterdestination.DataBind();
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
    }
}