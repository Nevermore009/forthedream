<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="RuleManager.aspx.cs" Inherits="Justgo8.Manage.RuleManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SmallTitle" runat="server">
    <asp:Literal runat="server" ID="lbtitle"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <a href="javascript:" id="Rule" style="font-weight: bold; color: Green;">添 加</a>
    <hr style="width: 100%;" color="#bbb" size="3" />
    <center>
        <ul>
            <asp:Repeater ID="RPlank" runat="server" OnItemCommand="RPlank_ItemCommand">
                <ItemTemplate>
                    <li><font style="font-weight: bold;">
                        <%# Eval("content")%></font>
                        <br />
                        <a href="javascript:" onclick='Rule(<%# Eval("id") %>)'>修改</a>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("id")%>'
                            OnClientClick="javascript:return confirm('确认是否删除？')">删除</asp:LinkButton></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </center>
    <div id="addSourcePanel" class="openform" style="width: 610px; height: 400px;">
        <iframe frameborder="0" id="addFrame" width="710" height="380" src="AddRule.aspx?ruletype=<%=Request["ruletype"] %>"
            scrolling="no"></iframe>
        <center>
            <asp:LinkButton ID="closeAddPanel" runat="server" ForeColor="green">【关闭】</asp:LinkButton></center>
    </div>
</asp:Content>
