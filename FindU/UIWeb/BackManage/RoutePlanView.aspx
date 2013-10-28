<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoutePlanView.aspx.cs" Inherits="Admin_RoutePlanView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看采集计划</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="script1" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div>
        <asp:Panel ID="panel2" runat="server" GroupingText="采集计划查看">
            <center>
                <asp:GridView runat="server" ID="grvRoutePlan" CssClass="gridview" EmptyDataText="暂无采集计划"
                    AllowPaging="false" AutoGenerateColumns="False" OnRowDeleting="grvRoutePlan_RowDeleting"
                    DataKeyNames="planid,planinfoid" OnRowCancelingEdit="grvRoutePlan_RowCancelingEdit" OnRowEditing="grvRoutePlan_RowEditing"
                    OnRowUpdating="grvRoutePlan_RowUpdating" OnRowDataBound="grvRoutePlan_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="计划名称">
                            <ItemTemplate>
                                <asp:Label ID="lbroutename" runat="server" Text='<%# Bind("PlanName") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtroutename" runat="server" Text='<%# Bind("PlanName") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="staffname" HeaderText="巡检员" ReadOnly="true" />
                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbstate" Text='<%#Eval("state").ToString()=="0"?"执行中...":"已完成" %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:Label ID="lbdescription" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtdescription" runat="server" Text='<%# Bind("description") %>'
                                    Width="90%"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="地图中查看">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnview" runat="server" Text="查看"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" Text="编辑"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Visible="false"
                                    Text="删除" OnClientClick="return confirm('确定要删除吗')"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="update" Text="更新" ValidationGroup="sss"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="cancel" Text="取消"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </center>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
