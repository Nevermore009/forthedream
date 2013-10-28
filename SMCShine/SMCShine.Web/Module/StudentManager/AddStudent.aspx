<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="Module_StudentManager_AddStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加学员</title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <span style="font-size: 28px; font-weight: bold">添加学员</span>
            <hr style="height: 1px; color: #444; width: 90%" />
        </center>
        <center>
            <table>
                <tr>
                    <td class="lefttd">
                        身份证号:
                    </td>
                    <td class="righttd">
                        <asp:TextBox runat="server" ID="txtid" CssClass="textbox" Width="175px"></asp:TextBox>
                        <%--<asp:RegularExpressionValidator ID="regular1" runat="server" ErrorMessage="*" ValidationExpression=""
                            Display="Dynamic" ControlToValidate="txtid" ValidationGroup="sss"></asp:RegularExpressionValidator>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            Display="Dynamic" ControlToValidate="txtid" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    </td>
                    <td class="lefttd" style="width: 60px">
                        姓名:
                    </td>
                    <td class="righttd">
                        <asp:TextBox runat="server" ID="txtname" CssClass="textbox"></asp:TextBox>
                    </td>
                    <td class="lefttd">
                        性别:
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropgender" runat="server" CssClass="dropdownlist">
                            <asp:ListItem Value="0" Selected="True">女</asp:ListItem>
                            <asp:ListItem Value="1">男</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="lefttd">
                        手机:
                    </td>
                    <td class="righttd">
                        <asp:TextBox runat="server" ID="txtmobile" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lefttd">
                        校区:
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropcampus" runat="server" CssClass="dropdownlist" AutoPostBack="true"
                            OnSelectedIndexChanged="dropcampus_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                     <td class="lefttd">
                        学校:
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropschool" runat="server" CssClass="dropdownlist" AutoPostBack="true"
                            onselectedindexchanged="dropschool_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="dropschool" ValidationGroup="sss" InitialValue="--请选择--"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                            ControlToValidate="dropschool" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    </td>
                    <td class="lefttd">
                        年级:
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropgrade" runat="server" CssClass="dropdownlist" AutoPostBack="true"
                            OnSelectedIndexChanged="dropgrade_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="lefttd">
                        专业:
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropclass" runat="server" CssClass="dropdownlist">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="dropclass" ValidationGroup="sss" InitialValue="--请选择--"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="dropclass" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    </td>
                   
                </tr>
                <tr>
                    <td class="lefttd">
                        固定电话:
                    </td>
                    <td class="righttd">
                        <asp:TextBox runat="server" ID="txttel" CssClass="textbox"></asp:TextBox>
                    </td>
                    <td class="lefttd">
                        Email:
                    </td>
                    <td class="righttd">
                        <asp:TextBox runat="server" ID="txtemail" CssClass="textbox"></asp:TextBox>
                    </td>
                    <td class="lefttd">
                        地址:
                    </td>
                    <td class="righttd" colspan="3">
                        <asp:TextBox runat="server" ID="txtaddress" CssClass="textbox" Width="80%"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnadd" runat="server" Text="添加" CssClass="button" ValidationGroup="sss"
                OnClick="btnadd_Click" />
            <asp:Button ID="btnreset" runat="server" Text="重填" CssClass="button" />
        </center>
    </div>
    </form>
</body>
</html>
