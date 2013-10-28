using System;
using SMCShine.Logic;
using SMCShine.Data.Entities;
using SMCShine.Common;

public partial class Module_UserManager_AddUser : BasePage
{
    private CampusManager campusLogic = new CampusManager();
    private UserManager userManager = new UserManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropUserType();
        }
    }


    protected void BindDropUserType()
    {
        BindHelper.BindDropDownList(ddlUserGroup, userManager.GetAllGroup(Campus), "Name", "Guid");
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            User entity = new User();
            entity.Name = txtUserName.Text.Trim();
            entity.Memo = txtUserMemo.Text;
            entity.UserAccount = txtUserAccount.Text.Trim();
            entity.UserPassword = txtPwdAfter.Text.Trim();
            entity.Mobile = txtMobile.Text.Trim();
            Guid groupGuid = new Guid(ddlUserGroup.SelectedValue);
            entity.UserGroupGuid = groupGuid;
            UserGroup group = userManager.GetGroupByID(groupGuid);
            entity.CampusGuid = group.CampusGuid;
            if (userManager.AddUser(entity))
            {
                MessageBox.Show(this.Page, "添加成功!");
                Response.AddHeader("refresh", "0");
            }
            else
            {
                MessageBox.Show(this.Page, "添加失败!");
            }
        }
    }
}
