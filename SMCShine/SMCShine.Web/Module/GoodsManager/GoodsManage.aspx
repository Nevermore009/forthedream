<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsManage.aspx.cs" Inherits="Module_GoodsManager_GoodsManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>缴费项目管理</title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" ID="panelgoodstype" GroupingText="费用类型">
            <center>
                <asp:GridView runat="server" ID="grvGoodsType" CssClass="gridview" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="费用类型" />
                        <asp:BoundField DataField="campusName" HeaderText="所属校区" />
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="color: Red; font-size: medium">
                            没有相关记录</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </center>
            <br />
        </asp:Panel>
        <br />
        <br />
        <asp:Panel runat="server" ID="panelgoodsitem" GroupingText="缴费项目">
            <center>
                <asp:GridView runat="server" ID="grvGoodsItem" CssClass="gridview" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="缴费项目名称" />
                        <asp:BoundField DataField="goodsTypeName" HeaderText="所属类型" />
                        <asp:BoundField DataField="schoolName" HeaderText="学校" />
                        <asp:BoundField DataField="gradeName" HeaderText="年级" />
                        <asp:BoundField DataField="className" HeaderText="专业" />
                        <asp:BoundField DataField="price" HeaderText="价格" />
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="color: Red; font-size: medium">
                            没有相关记录</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </center>
            <br />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
