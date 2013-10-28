<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCampus.aspx.cs" Inherits="Module_SchoolManager_AddSchool" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlCampus" runat="server" GroupingText="校区" Width="100%">
            <div style="text-align: left; margin-left: 30px">
                <asp:Button ID="btnAdd" runat="server" Text="新 增" CssClass="button" OnClick="btnAdd_Click" />
                <asp:Button ID="btnedit" runat="server" Text="编 辑" CssClass="button" OnClick="btnedit_Click" />
                <asp:Button ID="btnsave" runat="server" ValidationGroup="campus" Text="保 存" CssClass="button"
                    OnClick="btnsave_Click" />
                <asp:Label runat="server" ID="lbcampusID" Visible="false"></asp:Label>
            </div>
            <br />
            <div style="text-align: left">
                <asp:Panel ID="panelDetail" runat="server" Enabled="false">
                    <table>
                        <tr>
                            <td class="lefttd">
                                <asp:Label ID="lbCampusName" runat="server" Text="校区名称:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtCampusName" runat="server" CssClass="textbox"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="vCampus" runat="server" ErrorMessage="*" ValidationGroup="campus"
                                    ControlToValidate="txtCampusName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd">
                                <asp:Label ID="lbCampusCode" runat="server" Text="校区代码:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtCampusCode" runat="server" CssClass="textbox"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCampusCode"
                                    ErrorMessage="*" ValidationGroup="campus"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd" style="vertical-align: top">
                                <asp:Label ID="lbCampusMemo" runat="server" Text="校区描述:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtCampusMemo" runat="server" TextMode="MultiLine" Height="48px"
                                    Width="400px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
