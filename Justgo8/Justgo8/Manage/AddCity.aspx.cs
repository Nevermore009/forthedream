using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8.Manage
{
    public partial class AddCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["cityid"]))
                {
                    BindArea();
                    typeselect.Visible = false;
                    DataTable dt = new DataTable();
                    string id = Request.QueryString["cityid"];
                    dt = Bll.BCity.CityInfo(Convert.ToInt32(id));
                    if (dt.Rows.Count > 0)
                    {
                        txtcityname.Text = dt.Rows[0]["cityname"].ToString();
                        droparea.SelectedValue = dt.Rows[0]["areaid"].ToString();
                        droparea.Enabled = false;
                        cbhot.Checked = bool.Parse(dt.Rows[0]["hot"].ToString());
                    }
                }
                else
                {
                    BindTravelType();
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
                droptraveltype.Items.Insert(0, "请选择类型");
            }
            else
            {
                droptraveltype.DataSource = null;
                droptraveltype.DataBind();
            }
        }

        protected void BindArea()
        {
            DataTable dt = new DataTable();
            dt = Bll.BArea.AreaInfo();
            if (dt.Rows.Count > 0)
            {
                droparea.DataSource = dt.DefaultView;
                droparea.DataValueField = "areaid";
                droparea.DataTextField = "areaname";
                droparea.DataBind();
            }
            else
            {
                droparea.DataSource = null;
                droparea.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["cityid"]))
            {
                if (string.IsNullOrEmpty(droparea.SelectedValue))
                {
                    prompt("必须选择所属地区");
                    return;
                }
                if (string.IsNullOrEmpty(txtcityname.Text.Trim()))
                {
                    prompt("城市名称不能为空");
                    return;
                }

                int res = Bll.BCity.update(txtcityname.Text, cbhot.Checked, Convert.ToInt32(Request.QueryString["cityid"]));
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功');parent.ReloadPage();", true);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(droparea.SelectedValue))
                {
                    prompt("必须选择所属地区");
                    return;
                }
                if (string.IsNullOrEmpty(txtcityname.Text.Trim()))
                {
                    prompt("城市名称不能为空");
                    return;
                }
                int res = Bll.BCity.add(txtcityname.Text, int.Parse(droparea.SelectedValue), cbhot.Checked);
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功');parent.ReloadPage();", true);
                }
            }
        }

        protected void droptraveltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (droptraveltype.SelectedIndex > 0)
            {
                DataTable dt = new DataTable();
                dt = Bll.BArea.AreaOfTravelType(int.Parse(droptraveltype.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    droparea.DataSource = dt.DefaultView;
                    droparea.DataValueField = "areaid";
                    droparea.DataTextField = "areaname";
                    droparea.DataBind();
                }
                else
                {
                    droparea.Items.Clear();
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