using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;

public partial class Admin_PersonalInfo : System.Web.UI.Page
{
    public static DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BIndRepeater();
            
        }
    }
    protected void BIndRepeater()
    {
        BLL.UserInfo userBLL = new BLL.UserInfo();
        if (Session["username"] == null)
        {
            MessageBox.ResponseScript(this.Page, "alert('由于您长时间没有进行操作,网页已过期,请重新登录!');parent.location.href ='../index.aspx';");
            return;
        }
        string username = Session["username"].ToString();
        dt = userBLL.GetUserInfo(username);
        BindHelper.BindRepeater(repeater1, dt);
        DropDownList ddlsex = (DropDownList)repeater1.Items[0].FindControl("ddlSex");
        ddlsex.SelectedValue = dt.Rows[0]["Sex"].ToString();
        DropDownList ddlEducation = (DropDownList)repeater1.Items[0].FindControl("ddlEducation");
        ddlEducation.SelectedValue = dt.Rows[0]["Educational"].ToString(); 
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DropDownList ddlsex = (DropDownList)repeater1.Items[0].FindControl("ddlSex");
        string sex = ddlsex.SelectedValue.ToString();
         TextBox txtPosition = (TextBox)repeater1.Items[0].FindControl("txtPosition");
         string Position = txtPosition.Text;
         TextBox txtDepartment = (TextBox)repeater1.Items[0].FindControl("txtDepartment");
         string Department = txtDepartment.Text;
         DropDownList ddlEducation = (DropDownList)repeater1.Items[0].FindControl("ddlEducation");
         string Education = ddlEducation.SelectedValue.ToString();
         TextBox txtStartTime = (TextBox)repeater1.Items[0].FindControl("txtStartTime");
         string StartTime =txtStartTime.Text;
         TextBox txtIDCard = (TextBox)repeater1.Items[0].FindControl("txtIDCard");
         string IDCard = txtIDCard.Text;
         TextBox txtAddress = (TextBox)repeater1.Items[0].FindControl("txtAddress");
         string Address = txtAddress.Text;
         TextBox txtPhone = (TextBox)repeater1.Items[0].FindControl("txtPhone");
         string Phone = txtPhone.Text;
         TextBox txtEmail = (TextBox)repeater1.Items[0].FindControl("txtEmail");
         string Email = txtEmail.Text;
         TextBox txtSummary = (TextBox)repeater1.Items[0].FindControl("txtSummary");
         string Summary = txtSummary.Text;
         TextBox txtRemark = (TextBox)repeater1.Items[0].FindControl("txtRemark");
         string Remark = txtRemark.Text;
         List<string> list = new List<string>();
         list.Add(sex);
         list.Add(Position);
         list.Add(Department);
         list.Add(Education);
         list.Add(StartTime);
         list.Add(IDCard);
         list.Add(Address);
         list.Add(Phone);
         list.Add(Email);
         list.Add(Summary);
         list.Add(Remark);
         list.Add(Session["username"].ToString());
         BLL.UserInfo bllU = new BLL.UserInfo();
         if (bllU.EditUserInfo(list))
         { 
         MessageBox.Show(this,"修改成功");
         }


    }
}