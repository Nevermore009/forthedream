<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoftWareDownLoad.aspx.cs"
    Inherits="Admin_SoftWareDownLoad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:Panel ID="panel2" runat="server" GroupingText="终端软件下载">
            <div align="center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                    EmptyDataText="没有符合条件的信息" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnRowCommand="GridView1_RowCommand" AllowPaging="True" EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderText="文件名称" ReadOnly="true" />
                        <asp:TemplateField HeaderText="上传时间">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CreateTime") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="240px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="版本">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Version") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="400px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="下载">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="txt" NavigateUrl='<%# "~/Admin/downLoad.ashx?filename="+DataBinder.Eval(Container.DataItem,"Title").ToString()%>'>下载</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作" Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="edit" CommandName="Edit" runat="server">编辑</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Container.DataItemIndex  %>'
                                    runat="server" OnClientClick="return confirm('确认要删除？')" CommandName="Del" >删除</asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" CommandName="Update" CausesValidation="true" runat="server">更新</asp:LinkButton>&#160;&nbsp;<asp:LinkButton
                                    ID="LinkButton2" CommandName="Cancel" CausesValidation="false" runat="server">取消</asp:LinkButton></EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
