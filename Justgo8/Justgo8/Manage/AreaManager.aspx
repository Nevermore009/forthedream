<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="AreaManager.aspx.cs" Inherits="Justgo8.Manage.AreaManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SmallTitle" runat="server">
    地区管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <a href="javascript:" id="Area" style="font-weight: bold; color: Green;">添 加</a>
    <hr style="width: 100%;" color="#bbb" size="3" />
    <asp:DropDownList ID="droptraveltype" runat="server" Height="28px" Width="110px"
        AutoPostBack="true" OnSelectedIndexChanged="droptraveltype_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <center>
        <div class="pro_list">
            <ul class="pro_show" style="margin-top: 5px">
                <asp:Repeater ID="RPlank" runat="server" OnItemCommand="RPlank_ItemCommand">
                    <ItemTemplate>
                        <li style="height: 165px"><font style="font-weight: bold; font-size: 18px">
                            <%# Eval("areaName")%></font>
                            <br />
                            <a href="javascript:" onclick='Area(<%# Eval("areaid") %>)'>修改</a>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("areaid")%>'
                                OnClientClick="javascript:return confirm('确认是否删除？')">删除</asp:LinkButton></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </center>
    <div id="addSourcePanel" class="openform" style="width: 610px; height: 400px;">
        <iframe frameborder="0" id="addFrame" width="710" height="380" src="AddArea.aspx"
            scrolling="no"></iframe>
        <center>
            <asp:LinkButton ID="closeAddPanel" runat="server" ForeColor="green">【关闭】</asp:LinkButton></center>
    </div>
</asp:Content>
