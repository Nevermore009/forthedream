<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffView.aspx.cs" Inherits="Admin_StaffView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>巡检员管理</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="panel1" runat="server" GroupingText="巡检员管理">
        <center>
            <asp:GridView ID="grvstaff" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                EmptyDataText="没有符合条件的信息" AllowPaging="True" DataKeyNames="staffid" OnRowDeleting="grvstaff_RowDeleting"
                OnRowEditing="grvstaff_RowEditing" OnRowUpdating="grvstaff_RowUpdating" OnRowCancelingEdit="grvstaff_RowCancelingEdit"
                OnRowDataBound="grvstaff_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <asp:Label ID="lbstaff" runat="server" Text='<%#Eval("staffname")%>'></asp:Label></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtstaffname" runat="server" Text='<%#Bind("staffname") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="手机IMEI编号" ReadOnly="True" DataField="IMEI" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="lbstate" runat="server"></asp:Label></ItemTemplate>
                        <ItemStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="edit" CommandName="Edit" runat="server">编辑</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="delete" Visible="false" CommandName="Delete" OnClientClick=" return confirm('确定要删除吗？')"
                                runat="server">删除</asp:LinkButton></ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandName="Update" CausesValidation="true" runat="server">更新</asp:LinkButton>&#160;&nbsp;<asp:LinkButton
                                ID="LinkButton2" CommandName="Cancel" CausesValidation="false" runat="server">取消</asp:LinkButton></EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </center>
    </asp:Panel>
    </form>
</body>
</html>
