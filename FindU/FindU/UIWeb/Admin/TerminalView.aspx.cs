using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;
using System.Threading;
using BLL;
using Common;

public partial class TerminalView : System.Web.UI.Page
{
    Staff staffbll = new Staff();
    Terminal terminalbll = new Terminal();
    private static DataTable datasource;
    public static string lblinterval = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            datasource = terminalbll.GetList();
            BindHelper.BindGridview(grvterminal, datasource);
        }
    }

    #region GRV事件
    protected void grvterminal_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvterminal.PageIndex = e.NewPageIndex;
        BindHelper.BindGridview(grvterminal, datasource);
    }
    protected void grvterminal_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        /*
        string imei = grvterminal.DataKeys[e.RowIndex].Values["imei"].ToString();
        if(terminalbll.DeleteByIMEI(imei))
        {
            datasource=terminalbll.GetTerminalList();
            BindHelper.BindGridview(grvterminal,datasource);
            MessageBox.Show(this.Page, "删除成功!");
        }
        else
        {
            MessageBox.Show(this.Page, "删除失败!");
        } */
    }
    protected void grvterminal_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string staffname = ((Label)grvterminal.Rows[e.NewEditIndex].FindControl("lbstaff")).Text;
        lblinterval = ((Label)grvterminal.Rows[e.NewEditIndex].FindControl("lbinterval")).Text;
        grvterminal.EditIndex = e.NewEditIndex;
        BindHelper.BindGridview(grvterminal, datasource);
        DropDownList dropstaff = ((DropDownList)grvterminal.Rows[e.NewEditIndex].FindControl("dropstaff"));
        BindHelper.BindDropDownList(dropstaff, staffbll.GetStaffList(), "staffname", "staffid");
        dropstaff.SelectedValue = dropstaff.Items.FindByText(staffname).Value;
    }
    protected void grvterminal_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string imei = grvterminal.DataKeys[e.RowIndex].Values["imei"].ToString();
        string interval = ((TextBox)grvterminal.Rows[e.RowIndex].FindControl("txtinterval")).Text;

        if (interval != lblinterval)
        {
            Message msg = new Message { Source = "server", Content = "interval:" + (int.Parse(interval)*1000).ToString(), Destination = imei };
            bool send = false;
            for (int i = 0; i < 3; i++)
            {
                send = LongpollingHandle.ConnManager.SendMessage(msg);
                if (send)
                {
                    terminalbll.ModifyByIMEI(imei, interval);
                    break;
                }
            }
            if (!send)
            {
                MessageBox.Show(this.Page, "更新失败!");
            }
        }

        grvterminal.EditIndex = -1;
        datasource = terminalbll.GetList();
        BindHelper.BindGridview(grvterminal, datasource);
    }

    protected void grvterminal_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvterminal.EditIndex = -1;
        BindHelper.BindGridview(grvterminal, datasource);
    }
    protected void grvterminal_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#D9FFFF'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
        }
    }
    #endregion

    #region 搜索IMEI
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string staffname = txtstaffname.Text;
        if (staffname != "")
        {
            datasource = terminalbll.GetListByStaffName(staffname);
            BindHelper.BindGridview(grvterminal, datasource);
        }
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        datasource = terminalbll.GetList();
        BindHelper.BindGridview(grvterminal, datasource);
    }
    #endregion

}
