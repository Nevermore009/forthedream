<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUserGroup.aspx.cs" Inherits="Module_UserManager_AddUserGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
    <script src="../../js/treeviewSelect.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <span style="font-size: 28px; font-weight: bold">添加用户类别</span>
        <hr style="height: 1px; color: #444; width: 90%" />
    </center>
    <center>
        <table>
            <tr>
                <td style="vertical-align: top">
                    <table>
                        <tr>
                            <td class="lefttd">
                                <asp:Label ID="lbCampus" runat="server" Text="所在校区:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:DropDownList ID="ddlCampus" runat="server" Width="140px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="req1" runat="server" ValidationGroup="userGroup"
                                    ControlToValidate="ddlCampus" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd">
                                <asp:Label ID="lbUserGroupName" runat="server" Text="类别名称:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtUserGroupName" runat="server" Width="140px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="vUserGroupName" runat="server" ErrorMessage="*" ValidationGroup="userGroup"
                                    ControlToValidate="txtUserGroupName"></asp:RequiredFieldValidator>
                            </td>
                            <td rowspan="3" style="padding-left: 40px; text-align: left;">
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd">
                                <asp:Label ID="lbUserGroupMemo" runat="server" Text="类别描述:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtUserGroupMemo" runat="server" TextMode="MultiLine" Height="48px"
                                    Width="320px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd">
                            </td>
                            <td class="righttd" style="vertical-align: top">
                                <asp:Button ID="btnAddUserGroup" runat="server" ValidationGroup="userGroup" Text="添加"
                                    CssClass="button" OnClick="btnAddUserGroup_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <div style="text-align: left">
                        权限选择<br />
                        <asp:TreeView ID="treePermission" runat="server" ImageSet="Simple" BorderColor="#C3C3C3"
                            BorderStyle="Solid" BorderWidth="0px" ExpandDepth="0" NodeIndent="30" ShowLines="True"
                            ShowCheckBoxes="All" >
                            <NodeStyle Font-Names="verdana" Font-Size="15pt" ForeColor="#3366FF" HorizontalPadding="0px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#FF6600" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                        </asp:TreeView>
                    </div>
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
