<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TerminalView.aspx.cs" Inherits="TerminalView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>终端管理</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div>
        <asp:Panel ID="Panel4" runat="server" GroupingText="已绑定的终端设备" Font-Size="17px">
            <br />
            <p style="margin: 0 auto; text-align: center; margin-bottom: 10px;">
                使用者：<asp:TextBox ID="txtstaffname" runat="server"></asp:TextBox><asp:Button ID="btnSearch"
                    runat="server" Text="查找" OnClick="btnSearch_Click" CssClass="button" Width="80px"
                    Height="26px" />&nbsp;&nbsp;<asp:Button ID="btnSearchAll" runat="server" Text="查看全部"
                        CssClass="button" Width="80px" Height="26px" OnClick="btnSearchAll_Click" /></p>
            <center>
                <asp:GridView ID="grvterminal" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                    OnRowDeleting="grvterminal_RowDeleting" 
                    OnPageIndexChanging="grvterminal_PageIndexChanging" OnRowCancelingEdit="grvterminal_RowCancelingEdit"
                    EmptyDataText="没有符合条件的信息" OnRowUpdating="grvterminal_RowUpdating" OnRowEditing="grvterminal_RowEditing"
                    AllowPaging="True" DataKeyNames="imei" 
                    onrowcreated="grvterminal_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="IMEI号" ReadOnly="True" DataField="IMEI" />
                        <asp:TemplateField HeaderText="使用者">
                            <ItemTemplate>
                                <asp:Label ID="lbstaff" runat="server" Text='<%#Eval("staffname")%>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList runat="server" ID="dropstaff" Enabled="false">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发送间隔(秒)">
                            <ItemTemplate>
                                <asp:Label ID="lbinterval" runat="server" Text='<%#Eval("Interval") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtinterval" runat="server" Text='<%#Eval("Interval")%>' Width="80%"></asp:TextBox><asp:CompareValidator
                                    ID="CompareValidator1" runat="server" ErrorMessage="*" ValidationGroup="sss"
                                    ControlToValidate="txtinterval" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="edit" CommandName="Edit" runat="server">编辑</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="delete" Visible="false" CommandName="Delete" OnClientClick="if(confirm('确定要删除吗？')) {return true;} else{return false;}"
                                    runat="server">删除</asp:LinkButton></ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" CommandName="Update" CausesValidation="true" ValidationGroup="sss"
                                    runat="server">更新</asp:LinkButton>&#160;&nbsp;<asp:LinkButton ID="LinkButton2" CommandName="Cancel"
                                        CausesValidation="false" runat="server">取消</asp:LinkButton></EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </center>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
