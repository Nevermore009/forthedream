using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bll;
using Common;

namespace justgo.Manage
{
    public partial class AddPipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mdy"]))
                {
                    DataTable dt = new DataTable();
                    string id = Request.QueryString["mdy"];
                    dt = Bll.BPatent.pratentInfo(Convert.ToInt32(id));
                    if (dt.Rows.Count > 0)
                    {
                        //品名
                        Name.Text = dt.Rows[0]["Name"].ToString();
                        //图片地址
                        Url.Text = dt.Rows[0]["url"].ToString();
                        Session["Pic"] = dt.Rows[0]["Pic"].ToString();

                        sort.Text = dt.Rows[0]["sort"].ToString();
                    }
                }
            }
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mdy"]))
            {
                if (string.IsNullOrEmpty(Name.Text.Trim()))
                {
                    prompt("专利名称不能为空");
                    return;
                }

                string url = "";
                if (Session["Pic"] != null)
                {
                    url = Session["Pic"].ToString();
                }
                if (string.IsNullOrEmpty(sort.Text.Trim()))
                {
                    prompt("排序号不能为空");
                    return;
                }
                int i;
                if (!int.TryParse(sort.Text, out i))
                {
                    prompt("请输入正确的排序号");
                    return;
                }

                if (FileUpload1.FileName != "")
                {
                    url = FileUpLoad.Upload(Request.Files);
                }
                else
                {
                    url = Session["Pic"].ToString();
                }
                int res = Bll.BPatent.update(Name.Text, url, Url.Text, Convert.ToInt32(sort.Text), Convert.ToInt32(Request.QueryString["mdy"]));
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功');parent.ReloadPage();", true);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Name.Text.Trim()))
                {
                    prompt("品名不能为空");
                    return;
                }

                if (string.IsNullOrEmpty(sort.Text.Trim()))
                {
                    prompt("排序号不能为空");
                    return;
                }
                int i;
                if (!int.TryParse(sort.Text, out i))
                {
                    prompt("请输入正确的排序号");
                    return;
                }

                string url = "";
                if (FileUpload1.FileName != "")
                {
                    url = FileUpLoad.Upload(Request.Files);
                }
                int res = Bll.BPatent.add(Name.Text, url,Url.Text, Convert.ToInt32(sort.Text));
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功成功');parent.ReloadPage();", true);
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