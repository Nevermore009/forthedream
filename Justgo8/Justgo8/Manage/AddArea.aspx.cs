using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8.Manage
{
    public partial class AddArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTravelType();
                if (!string.IsNullOrEmpty(Request.QueryString["areaid"]))
                {
                    DataTable dt = new DataTable();
                    string id = Request.QueryString["areaid"];
                    dt = Bll.BArea.AreaInfo(Convert.ToInt32(id));
                    if (dt.Rows.Count > 0)
                    {
                        txtareaname.Text = dt.Rows[0]["areaname"].ToString();
                        cbhot.Checked = dt.Rows[0]["hot"].ToString() == "1";
                        droptraveltype.SelectedValue = dt.Rows[0]["traveltypeid"].ToString();
                        droptraveltype.Enabled = false;
                    }
                }
            }
        }

        protected void BindTravelType()
        {
            DataTable dt = new DataTable();
            dt = Bll.BTravelType.TravelTypeInfo();
            if (dt.Rows.Count > 0)
            {
                droptraveltype.DataSource = dt.DefaultView;
                droptraveltype.DataValueField = "traveltypeid";
                droptraveltype.DataTextField = "traveltypename";
                droptraveltype.DataBind();
            }
            else
            {
                droptraveltype.DataSource = null;
                droptraveltype.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["areaid"]))
            {
                if (string.IsNullOrEmpty(txtareaname.Text.Trim()))
                {
                    prompt("地区名称不能为空");
                    return;
                }


                int res = Bll.BArea.update(txtareaname.Text, cbhot.Checked, Convert.ToInt32(Request.QueryString["areaid"]));
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功');parent.ReloadPage();", true);
                }
            }
            else
            {

                if (string.IsNullOrEmpty(txtareaname.Text.Trim()))
                {
                    prompt("旅游类型不能为空");
                    return;
                }

                if (string.IsNullOrEmpty(txtareaname.Text.Trim()))
                {
                    prompt("地区名称不能为空");
                    return;
                }

                int res = Bll.BArea.add(txtareaname.Text, int.Parse(droptraveltype.SelectedValue), cbhot.Checked);
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