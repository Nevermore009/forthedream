<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CampusTableManage.aspx.cs"
    Inherits="Module_CampusManager_CampusTableManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>校区管理</title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" ID="panelcampus" GroupingText="校区信息">
            <center>
                <asp:GridView runat="server" ID="grvcampus" CssClass="gridview" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="校区名称" />
                        <asp:BoundField DataField="campuscode" HeaderText="校区代码" />
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
        <asp:Panel runat="server" ID="panel3" GroupingText="学校">
            <center>
                <asp:GridView runat="server" ID="grvschool" CssClass="gridview" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="学校名称">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="campusname" HeaderText="所属校区" />
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
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
        <asp:Panel runat="server" ID="panel1" GroupingText="年级">
            <center>
                <asp:GridView runat="server" ID="grvgrade" CssClass="gridview" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年级">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="schoolname" HeaderText="所属学校" />
                        <asp:BoundField DataField="campusname" HeaderText="所属校区" />
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
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
        <asp:Panel runat="server" ID="panel2" GroupingText="专业信息">
            <center>
                校区:<asp:DropDownList runat="server" ID="dropcampus" CssClass="dropdownlist">
                </asp:DropDownList>
                年级:<asp:DropDownList runat="server" ID="dropgrade" CssClass="dropdownlist">
                </asp:DropDownList>
                <asp:Button runat="server" ID="btnsearch" Text="查找" CssClass="button" OnClick="btnsearch_Click" />
            </center>
            <br />
            <center>
                <asp:GridView runat="server" ID="grvclass" CssClass="gridview" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="专业">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                         <asp:BoundField DataField="Classification" HeaderText="班级类别" />
                        <asp:TemplateField HeaderText="年级">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("gradename") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="schoolname" HeaderText="所属校区" />
                        <asp:BoundField DataField="campusname" HeaderText="所属校区" />
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("memo") %>'></asp:Label>
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
    <a href="CampusTreeManage.aspx" style="display: block; position: absolute; top: 10px;
        right: 10px; height: 20px; width: 80px; text-decoration: none; background-color: #55cc55">
        树结构形式</a>
    </form>
</body>
</html>
