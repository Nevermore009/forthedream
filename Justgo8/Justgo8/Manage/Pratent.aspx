<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Pratent.aspx.cs" Inherits="justgo.Manage.Pratent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SmallTitle" runat="server">
    轮播图片编辑
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Body" runat="server">
    <a href="javascript:" id="Pipe" style="font-weight: bold; color: Green;">添 加</a>
    <center>
        <div class="pro_list">
            <ul class="pro_show" style="margin-top: 5px">
                <asp:Repeater ID="RPlank" runat="server" OnItemCommand="RPlank_ItemCommand">
                    <ItemTemplate>
                        <li style="height: 165px">
                            <img src='<%# Eval("pic")%>' width="164px" height="114px"
                                alt="" /><%# Eval("Name")%><br />
                            <a href="javascript:" onclick='Pipe(<%# Eval("id") %>)'>修改</a>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("id")%>'
                                OnClientClick="javascript:return confirm('确认是否删除？')">删除</asp:LinkButton></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </center>
    <div id="addSourcePanel" class="openform" style="width: 610px; height: 400px;">
        <iframe frameborder="0" id="addFrame" width="710" height="380" src="AddPipe.aspx"
            scrolling="no"></iframe>
        <center>
            <asp:LinkButton ID="closeAddPanel" runat="server" ForeColor="green">【关闭】</asp:LinkButton></center>
    </div>
</asp:Content>
