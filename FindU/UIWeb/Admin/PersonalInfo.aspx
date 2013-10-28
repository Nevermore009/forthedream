<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalInfo.aspx.cs" Inherits="Admin_PersonalInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tr1
        {
            height: 35px;
        }
        .td1
        {
            width: 130px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div>
        <asp:Panel ID="info" GroupingText="个人信息" Font-Size="Large" runat="server">
            <center>
                <table id="tb" style="font-size: 12px;">
                    <asp:Repeater ID="repeater1" runat="server">
                        <ItemTemplate>
                            <tr class="tr1">
                                <td class="td1">
                                    姓名：
                                </td>
                                <td class="">
                                    <asp:TextBox ID="txtName" runat="server" ReadOnly="true" Text='<%# Eval("RealName") %>'
                                        BackColor="#D2D2D2"></asp:TextBox>
                                </td>
                                <td class="td1">
                                    性别：
                                </td>
                                <td class="">
                                    <asp:DropDownList ID="ddlSex" runat="server" Width="150px">
                                        <asp:ListItem Value="男">男</asp:ListItem>
                                        <asp:ListItem Value="女">女</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="tr1">
                                <td class="td1">
                                    职务：
                                </td>
                                <td class="">
                                    <asp:TextBox ID="txtPosition" runat="server" Text='<%#Eval("Position") %>'></asp:TextBox>
                                </td>
                                <td class="td1">
                                    所属部门：
                                </td>
                                <td class="">
                                    <asp:TextBox ID="txtDepartment" runat="server" Text='<%#Eval("Department") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tr1">
                                <td class="td1">
                                    学历：
                                </td>
                                <td class="">
                                    <asp:DropDownList ID="ddlEducation" runat="server" Width="150px">
                                        <asp:ListItem Value="初中">初中</asp:ListItem>
                                        <asp:ListItem Value="高中">高中</asp:ListItem>
                                        <asp:ListItem Value="大学专科">大学专科</asp:ListItem>
                                        <asp:ListItem Value="大学本科">大学本科</asp:ListItem>
                                        <asp:ListItem Value="硕士">硕士</asp:ListItem>
                                        <asp:ListItem Value="博士">博士</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="td1">
                                    开始工作时间：
                                </td>
                                <td class="">
                                    <asp:TextBox ID="txtStartTime" runat="server" Text='<%#Eval("StartWork","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                    <cc1:CalendarExtender ID="Calendar1" runat="server" TargetControlID="txtStartTime"
                                        Format="yyyy-MM-dd">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr class="tr1">
                                <td class="td1">
                                    身份证：
                                </td>
                                <td class="">
                                    <asp:TextBox ID="txtIDCard" runat="server" Text='<%#Eval("IdentityCard") %>'></asp:TextBox>
                                </td>
                                <td class="td1">
                                    地址：
                                </td>
                                <td class="">
                                    <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tr1">
                                <td class="td1">
                                    电话：
                                </td>
                                <td class="">
                                    <asp:TextBox ID="txtPhone" runat="server" Text='<%#Eval("PhoneNum") %>'></asp:TextBox>
                                </td>
                                <td class="td1">
                                    电子邮件：
                                </td>
                                <td class="">
                                    <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td1">
                                    简介：
                                </td>
                                <td class="" colspan="2">
                                    <asp:TextBox ID="txtSummary" runat="server" Height="47px" TextMode="MultiLine" Width="100%"
                                        Text='<%#Eval("Summary") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td1">
                                    备注：
                                </td>
                                <td class="" colspan="2">
                                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Height="47px" Width="100%"
                                        Text='<%#Eval("Remark") %>' Style="overflow: hidden; float: left;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="button" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </center>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
