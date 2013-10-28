using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Common;

public partial class RouteAdd : System.Web.UI.Page
{
    private static DataTable dt = new DataTable();
    private static DataColumn lat = new DataColumn("lat", typeof(string));
    private static DataColumn lon = new DataColumn("lon", typeof(string));
    private static DataColumn title = new DataColumn("title", typeof(string));
    private static DataColumn remark = new DataColumn("remark", typeof(string));
    private static DataColumn orderno = new DataColumn("orderno", typeof(string));
    private Plan planbll = new Plan();
    private Route routebll = new Route();
    private Patrol patrolbll = new Patrol();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHelper.BindDropDownList(dropplan, planbll.GetCollectPlanList(), "planname", "planinfoid", "请选择");
            dt.Columns.Clear();
            dt.Columns.Add(lat);
            dt.Columns.Add(lon);
            dt.Columns.Add(title);
            dt.Columns.Add(remark);
            dt.Columns.Add(orderno);
            dt.Rows.Clear();
        }
    }

    protected void AddRouteinfoRow(string title, string lat, string lon, string remark, string orderno)
    {
        DataRow row = dt.NewRow();
        row["title"] = title;
        row["lat"] = lat;
        row["lon"] = lon;
        row["remark"] = remark;
        row["orderno"] = orderno;
        dt.Rows.Add(row);
        BindHelper.BindGridview(grvrouteinfo, dt);
    }

    protected void Reset()
    {
        txttitle.Text = "";
        txtlat.Text = "";
        txtlon.Text = "";
        txtremark.Text = "";

    }
    protected void dropimportmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropimportmode.SelectedValue == "0")
        {
            panelimport.Visible = false;
            panelinput.Visible = true;
        }
        else
        {
            panelimport.Visible = true;
            panelinput.Visible = false;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            AddRouteinfoRow(txttitle.Text, txtlat.Text, txtlon.Text, txtremark.Text, null);
            Reset();
        }
    }

    protected void dropplan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropplan.SelectedIndex > 0)
        {
            BindHelper.BindGridview(grvimport, patrolbll.GetHistoryByPlanInfoId(dropplan.SelectedValue));
            btnLook.Attributes.Add("onclick", "window.open('RouteAddInMap.aspx?planinfoid=" + dropplan.SelectedValue.ToString() + "','','location=no,titlebar=no,alwaysRaised=yes,scroll=no,Width=800,Height=600')");
        }
    }

    protected void grvimport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "add")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string lat = ((Label)grvimport.Rows[index].FindControl("lblat")).Text;
            string lon = ((Label)grvimport.Rows[index].FindControl("lblon")).Text;
            string title = ((TextBox)grvimport.Rows[index].FindControl("txttitle")).Text;
            string remark = ((TextBox)grvimport.Rows[index].FindControl("txtremark")).Text;
            AddRouteinfoRow(title, lat, lon, remark, index.ToString());
            ((Button)grvimport.Rows[index].FindControl("btnadd")).Enabled = false;
        }
    }

    protected void grvrouteinfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        for (int i = 0; i < grvimport.Rows.Count; i++)
        {
            if (i.ToString() == dt.Rows[e.RowIndex]["orderno"].ToString())
            {
                ((Button)grvimport.Rows[i].FindControl("btnadd")).Enabled = true;
                break;
            }
        }
        dt.Rows.RemoveAt(e.RowIndex);
        BindHelper.BindGridview(grvrouteinfo, dt);
    }
    protected void grvrouteinfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "up")
        {
            int index = ((GridViewRow)((Button)e.CommandSource).Parent.Parent).RowIndex;
            if (index > 0)
            {
                DataRow dr = dt.NewRow();
                dr.ItemArray = dt.Rows[index].ItemArray;
                dt.Rows.RemoveAt(index);
                dt.Rows.InsertAt(dr, index - 1);
                BindHelper.BindGridview(grvrouteinfo, dt);
            }
        }
        else if (e.CommandName == "down")
        {
            int index = ((GridViewRow)((Button)e.CommandSource).Parent.Parent).RowIndex;
            if (index < grvrouteinfo.Rows.Count - 1)
            {
                DataRow dr = dt.NewRow();
                dr.ItemArray = dt.Rows[index].ItemArray;
                dt.Rows.RemoveAt(index);
                dt.Rows.InsertAt(dr, index + 1);
                BindHelper.BindGridview(grvrouteinfo, dt);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (dt.Rows.Count <= 0)
        {
            MessageBox.Show(this.Page, "您还未给线路添加任何基站!");
            return;
        }
        else
        {
            string routeid = routebll.Add(txtroutename.Text, txtdescription.Text);
            if (routeid == null)
            {
                MessageBox.Show(this.Page, "添加失败!");
                return;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    routebll.AddRouteInfo(routeid, i + 1, dt.Rows[i]["lat"].ToString(), dt.Rows[i]["lon"].ToString(), dt.Rows[i]["title"].ToString(), dt.Rows[i]["remark"].ToString());
                }
                MessageBox.Show(this.Page, "添加成功!");
            }
        }
    }

    protected void grvimport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != -1)
        {
            string lat = ((Label)e.Row.FindControl("lblat")).Text;
            string lon = ((Label)e.Row.FindControl("lblon")).Text;
            ((LinkButton)e.Row.FindControl("lbmapview")).Attributes.Add("onclick", "window.open('MapView.aspx?lat=" + lat + "&lon=" + lon + "','','location=no,titlebar=no,alwaysRaised=yes,scroll=no,Width=800,Height=600')");
        }
    }

}
