using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using BLL;
using Common;

public partial class TerminalAdd : System.Web.UI.Page
{
    Staff staffbll = new Staff();
    TerminalBind bindbll = new TerminalBind();
    Terminal terminalbll = new Terminal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHelper.BindDropDownList(dropstaff, staffbll.GetNoTerminalStaff(), "staffname", "staffid");
            if (dropstaff.Items.Count == 0)
            {
                dropstaff.Items.Insert(0, new ListItem("请添加员工"));
            }
        }
    }

    #region 添加追踪信息
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string imei = bindbll.GetIMEIByCode(txtnumber.Text);
        if (imei != null )
        {
            if (terminalbll.Exist(imei))
            {
                MessageBox.Show(this.Page, "此终端已绑定到系统！");
                for (int i = 0; i < 2; i++)
                {
                    Message msg = new Message { Source = "server", Content = "bindsuccess", Destination = imei };
                    LongpollingHandle.ConnManager.SendMessage(msg);
                }
                return;
            }
            else
            {
                if (terminalbll.Add(imei, dropstaff.SelectedValue))
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Message msg = new Message { Source = "server", Content = "bindsuccess", Destination = imei };
                        LongpollingHandle.ConnManager.SendMessage(msg);
                    }
                    MessageBox.ResponseScript(this, "alert('绑定成功!');location.href='" + this.Request.Path + "'");
                }
                else
                    MessageBox.Show(this.Page, "网络异常,终端绑定失败,请稍后重试!");
            }
	}
        else
        {
            MessageBox.Show(this.Page, "绑定失败，请确保正确输入终端产生的随机编号或稍后重试！");
            return;
        }
    }
    #endregion
}
