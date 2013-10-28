<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="Module_UserManager_AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlUser" runat="server" GroupingText="用户" Height="140px" Width="100%">
            <div>
                <div>
                    <asp:Label ID="lbUSer" runat="server" Text="用户类别:"></asp:Label><asp:DropDownList
                        ID="ddlUserGroup" runat="server" Width="160px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="req3" runat="server" ErrorMessage="*" ValidationGroup="user"
                        ControlToValidate="ddlUserGroup"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbUserName" runat="server" Text="用户姓名:"></asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbMobile" runat="server" Text="联系方式:"></asp:Label>
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lbUserAccount" runat="server" Text="用户帐号:"></asp:Label><asp:TextBox
                        ID="txtUserAccount" runat="server" Width="160px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" ControlToValidate="txtUserAccount" runat="server"
                            ErrorMessage="*" ValidationGroup="user"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbPwdBefore" runat="server" Text="用户密码:"></asp:Label>
                    <asp:TextBox ID="txtPwdBefore" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="txtPwdBefore" ID="req7" runat="server" ErrorMessage="*" ValidationGroup="user"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbPwdAfter" runat="server" Text="重复密码:"></asp:Label>
                    <asp:TextBox ID="txtPwdAfter" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ControlToValidate="txtPwdAfter" ID="req8" runat="server" ErrorMessage="*" ValidationGroup="user"></asp:RequiredFieldValidator><asp:CompareValidator
                            ID="req9" runat="server" ErrorMessage="*" ControlToCompare="txtPwdBefore" ControlToValidate="txtPwdAfter"
                            Operator="Equal" ValidationGroup="user"></asp:CompareValidator>
                </div>
                <div>
                    <asp:Label ID="lbUserMemo" runat="server" Text="用户描述:"></asp:Label><asp:TextBox ID="txtUserMemo"
                        runat="server" TextMode="MultiLine" Height="48px" Width="320px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAddUser" runat="server" ValidationGroup="user" Text="添加用户" OnClick="btnAddUser_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
