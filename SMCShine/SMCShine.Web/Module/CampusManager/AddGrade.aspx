<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGrade.aspx.cs" Inherits="Module_CampusManager_AddGrade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlGrade" runat="server" GroupingText="年级" Width="100%">
            <div style="text-align: left; margin-left: 30px">
                <asp:Button ID="btnAdd" runat="server" Text="新 增" CssClass="button" OnClick="btnAdd_Click" />
                <asp:Button ID="btnedit" runat="server" Text="编 辑" CssClass="button" OnClick="btnedit_Click" />
                <asp:Button ID="btnsave" runat="server" ValidationGroup="Grade" Text="保 存" CssClass="button"
                    OnClick="btnsave_Click" />
                <asp:Label runat="server" ID="lbGradeID" Visible="false"></asp:Label>
            </div>
            <br />
            <div style="text-align: left">
                <asp:Panel ID="panelDetail" runat="server" Enabled="false">
                    <table>
                        <tr>
                            <td class="lefttd">
                                <asp:Label ID="Label1" runat="server" Text="校区:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:DropDownList runat="server" ID="dropCampus" CssClass="dropdownlist" AutoPostBack="true"
                                    OnSelectedIndexChanged="dropCampus_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ValidationGroup="Grade" ControlToValidate="dropCampus"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd">
                                <asp:Label ID="Label2" runat="server" Text="学校:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:DropDownList runat="server" ID="dropSchool" CssClass="dropdownlist">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ValidationGroup="Grade" ControlToValidate="dropSchool"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    InitialValue="--请选择--" ValidationGroup="Grade" ControlToValidate="dropSchool"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd">
                                <asp:Label ID="lbGradeName" runat="server" Text="年级名称:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtGradeName" runat="server" CssClass="textbox"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="vGrade" runat="server" ErrorMessage="*" ValidationGroup="Grade"
                                    ControlToValidate="txtGradeName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd" style="vertical-align: top">
                                <asp:Label ID="lbGradeMemo" runat="server" Text="年级描述:"></asp:Label>
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtGradeMemo" runat="server" TextMode="MultiLine" Height="48px"
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
