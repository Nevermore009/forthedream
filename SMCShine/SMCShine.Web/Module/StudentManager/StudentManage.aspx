<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentManage.aspx.cs" Inherits="Module_StudentManager_StudentManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学籍管理</title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <span style="font-size: 28px; font-weight: bold">学员管理</span>
            <hr style="height: 1px; color: #444; width: 100%" />
        </center>
        <asp:Panel runat="server" ID="groupstudentlist" GroupingText="查看学生信息">
            <center>
                <asp:GridView ID="grvstudent" runat="server" CssClass="gridview" AutoGenerateColumns="False"
                    AllowPaging="true" PageSize="10" DataKeyNames="guid" OnRowCommand="grvstudent_RowCommand"
                    EnableModelValidation="True" OnPageIndexChanging="grvstudent_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="guid" Visible="false" />
                        <asp:BoundField DataField="studentid" HeaderText="学号" />
                        <asp:BoundField DataField="name" HeaderText="姓名" />
                        <asp:TemplateField HeaderText="性别">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# bool.Parse(Eval("gender").ToString())?"男":"女" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="mobile" HeaderText="手机" />
                        <asp:BoundField DataField="id" HeaderText="证件号码" />
                        <asp:TemplateField HeaderText="查看详细">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtndetail" CommandName="detail" runat="server" Text="编辑">查看</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnedit" CommandName="modify" runat="server" Text="编辑">编辑</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="color: Red; font-size: medium">
                            没有相关记录</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </center>
        </asp:Panel>
        <br />
        <a name="detail"></a>
        <asp:Panel runat="server" ID="groupdetail" GroupingText="学生信息详情">
            <br />
            <asp:Button runat="server" ID="btnedit" Text="编辑" CssClass="button" OnClick="btnedit_Click"
                Enabled="false" /><asp:Button runat="server" ID="btnsave" Text="保存" CssClass="button" Enabled="false"
                    OnClick="btnsave_Click" ValidationGroup="sss" /><asp:Label ID="lbguid" runat="server"
                        Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Panel runat="server" ID="groupedit" Enabled="false">
                <asp:Label runat="server" ID="lbalert" Style="color: Red; font-size: medium">
                </asp:Label>
                <table>
                    <tr>
                        <td class="lefttd">
                            学号:
                        </td>
                        <td class="righttd">
                            <asp:TextBox runat="server" ID="txtstudentid" CssClass="textbox" Enabled="false"></asp:TextBox>
                        </td>
                        <td class="lefttd">
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
                                <asp:ListItem Value="0">女</asp:ListItem>
                                <asp:ListItem Value="1">男</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lefttd">
                            身份证号:
                        </td>
                        <td class="righttd" >
                            <asp:TextBox runat="server" ID="txtid" CssClass="textbox" Width="175px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtid"
                                ValidationExpression="^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$" ValidationGroup="sss"
                                ErrorMessage="*" ToolTip="身份证号码有误"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lefttd">
                            校区:
                        </td>
                        <td class="righttd">
                            <asp:DropDownList ID="dropCampus" runat="server" CssClass="dropdownlist" Enabled="false">
                            </asp:DropDownList>
                        </td>
                        <td class="lefttd">
                            学校:
                        </td>
                        <td class="righttd">
                            <asp:DropDownList ID="dropSchool" runat="server" CssClass="dropdownlist" Enabled="false">
                            </asp:DropDownList>
                        </td>
                        <td class="lefttd">
                            年级:
                        </td>
                        <td class="righttd">
                            <asp:DropDownList ID="dropGrade" runat="server" CssClass="dropdownlist" AutoPostBack="true"
                                OnSelectedIndexChanged="dropGrade_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="req1" runat="server" ErrorMessage="*" ControlToValidate="dropGrade"
                                ValidationGroup="sss"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="req3" runat="server" ErrorMessage="*" ControlToValidate="dropGrade"
                                InitialValue="--请选择--" ValidationGroup="sss"></asp:RequiredFieldValidator>
                        </td>
                        <td class="lefttd">
                            班级:
                        </td>
                        <td class="righttd">
                            <asp:DropDownList ID="dropClass" runat="server" CssClass="dropdownlist">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="req2" runat="server" ErrorMessage="*" ControlToValidate="dropClass"
                                ValidationGroup="sss"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lefttd">
                            手机:
                        </td>
                        <td class="righttd">
                            <asp:TextBox runat="server" ID="txtmobile" CssClass="textbox"></asp:TextBox>
                        </td>
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
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="lefttd">
                            地址:
                        </td>
                        <td class="righttd" colspan="7">
                            <asp:TextBox runat="server" ID="txtaddress" CssClass="textbox" Width="405px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
