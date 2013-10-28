using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_SoftWareDownLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();

        }
    }
    #region 绑定GRV
    protected void Bind()
    {
        BLL.SoftWare sbll = new BLL.SoftWare();
        DataTable dt = sbll.GetSoftWare();
        BindHelper.BindGridview(GridView1, dt);
    }
    #endregion
    #region 文件下载与删除
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string id = GridView1.DataKeys[index].Value.ToString();
            string filename = GridView1.Rows[index].Cells[1].Text;
            string path = Server.MapPath("~/software/") + filename;
            BLL.SoftWare sWare = new BLL.SoftWare();
            if (sWare.DeleteByID(int.Parse(id)))
            {
                //删除文件夹里面的软件
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
                Response.Write("<script>alert('删除成功！')</script>");
                Bind();
                // Response.AddHeader("Refresh", "0");//刷新
            }
        }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string remark = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtRemark")).Text;
        string id = GridView1.DataKeys[e.RowIndex].Values["ID"].ToString();
        new BLL.SoftWare().UpdateReamark(remark, int.Parse(id));
        GridView1.EditIndex = -1;
        Bind();
    }
    #endregion
}