<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RouteView.aspx.cs" Inherits="Admin_RouteAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>督巡线路管理</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="panel2" runat="server" GroupingText="督巡线路查看">
            <center>
                <asp:GridView runat="server" ID="grvroute" CssClass="gridview" EmptyDataText="暂无线路信息"
                    AutoGenerateColumns="false" DataKeyNames="routeid" OnRowCancelingEdit="grvroute_RowCancelingEdit"
                    OnRowEditing="grvroute_RowEditing" OnRowUpdating="grvroute_RowUpdating" OnRowDataBound="grvroute_RowDataBound"
                    OnRowCommand="grvroute_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="中继段">
                            <ItemTemplate>
                                <asp:Label ID="lbroutename" runat="server" Text='<%#Bind("routename") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtroutename" runat="server" Text='<%#Bind("routename") %>' ReadOnly="true"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="说明">
                            <ItemTemplate>
                                <asp:Label ID="lbremark" runat="server" Text='<%#Bind("description") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtremark" runat="server" Text='<%#Bind("description") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="500px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="地图中查看">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnview" runat="server" Text="查看"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="查看详细">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnviewdetail" Text="查看" CommandName="detail" CommandArgument='<%#Container.DataItemIndex %>'
                                    runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton5" runat="server" CommandName="edit" Text="编辑"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="update" Text="更新"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="cancel" Text="取消"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </center>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="paneldetail" runat="server" GroupingText="线路详细" Visible="false">
            <center>
                <asp:GridView ID="grvrouteinfo" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                    Width="80%" DataKeyNames="RouteInfoID" CssClass="gridview" OnPageIndexChanging="grvrouteinfo_PageIndexChanging"
                    OnRowCommand="grvrouteinfo_RowCommand" OnRowCancelingEdit="grvrouteinfo_RowCancelingEdit"
                    OnRowDeleting="grvrouteinfo_RowDeleting" OnRowEditing="grvrouteinfo_RowEditing"
                    OnRowUpdating="grvrouteinfo_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="基站(井)名">
                            <ItemTemplate>
                                <asp:Label ID="lbtitle" runat="server" Text='<%#Bind("title") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txttitle" runat="server" Text='<%#Bind("title") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="纬度">
                            <ItemTemplate>
                                <asp:Label ID="lblat" runat="server" Text='<%#Bind("lat") %>'></asp:Label></ItemTemplate> 
                            <EditItemTemplate>
                                <asp:TextBox ID="txtlat" runat="server" Text='<%#Bind("lat") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="经度">
                            <ItemTemplate>
                                <asp:Label ID="lblon" runat="server" Text='<%#Bind("lon") %>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtlon" runat="server" Text='<%#Bind("lon") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="备注" DataField="remark" ReadOnly="true" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" Text="编辑"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="删除" OnClientClick="return confirm('确定要删除吗')"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton6" runat="server" CommandName="update" Text="更新" ValidationGroup="sss"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton7" runat="server" CommandName="cancel" Text="取消"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="添加">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton8" runat="server" CommandName="add" Text="下一位置" CommandArgument='<%#Eval("RouteInfoID") %>' ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </center>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
