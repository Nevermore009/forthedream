using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8.Manage
{
    public partial class CityManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArea();
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
                droparea.Items.Insert(0, "请选择区域");
            }
            else
            {
                droparea.DataSource = null;
                droparea.DataBind();
                droparea.Items.Insert(0, "请先添加区域");
            }
        }

        public void BindCity(int areaid)
        {
            DataTable dt = new DataTable();
            dt = Bll.BCity.CityOfArea(areaid);
            if (dt.Rows.Count > 0)
            {
                RPlank.DataSource = dt;
                RPlank.DataBind();
            }
            else
            {
                RPlank.DataSource = null;
                RPlank.DataBind();
            }
        }

        protected void RPlank_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int res = Bll.BCity.del(id);
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除成功')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除失败')", true);
                }
            }
        }

        protected void droparea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int areaid = int.Parse(droparea.SelectedValue);
            BindCity(areaid);
        }
    }
}