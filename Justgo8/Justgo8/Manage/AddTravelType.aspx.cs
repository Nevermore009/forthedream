using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8.Manage
{
    public partial class AddTravelType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["traveltypeid"]))
                {
                    DataTable dt = new DataTable();
                    string id = Request.QueryString["traveltypeid"];
                    dt = Bll.BTravelType.TravelTypeInfo(Convert.ToInt32(id));
                    if (dt.Rows.Count > 0)
                    {
                        txttraveltypename.Text = dt.Rows[0]["traveltypename"].ToString();
                    }
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["traveltypeid"]))
            {
                if (string.IsNullOrEmpty(txttraveltypename.Text.Trim()))
                {
                    prompt("名称不能为空");
                    return;
                }

                int res = Bll.BTravelType.update(txttraveltypename.Text, Convert.ToInt32(Request.QueryString["traveltypeid"]));
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功');parent.ReloadPage();", true);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txttraveltypename.Text.Trim()))
                {
                    prompt("名称不能为空");
                    return;
                }

                int res = Bll.BTravelType.add(txttraveltypename.Text);
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功');parent.ReloadPage();", true);
                }
            }
        }
        #region"提示信息"
        public void prompt(string str)
        {
            ClientScript.RegisterStartupScript(GetType(), "", "alert('" + str + "')", true);
        }
        #endregion
    }
}