<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="TravelTypeManager.aspx.cs" Inherits="Justgo8.Manage.TravelTypeManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SmallTitle" runat="server">
旅游类型管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <a href="javascript:" id="TravelType" style="font-weight: bold; color: Green;">添 加</a>
    <hr style="width: 100%;" color="#bbb" size="3" />
    <center>
        <div class="pro_list">
            <ul class="pro_show" style="margin-top: 5px">
                <asp:Repeater ID="RPlank" runat="server" OnItemCommand="RPlank_ItemCommand">
                    <ItemTemplate>
                        <li style="height: 165px"><font style="font-weight: bold; font-size: 18px">
                            <%# Eval("traveltypename")%></font>
                            <br />
                            <a href="javascript:" onclick='TravelType(<%# Eval("traveltypeid") %>)'>修改</a>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("traveltypeid")%>'
                                OnClientClick="javascript:return confirm('确认是否删除？')">删除</asp:LinkButton></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </center>
    <div id="addSourcePanel" class="openform" style="width: 610px; height: 400px;">
        <iframe frameborder="0" id="addFrame" width="710" height="380" src="AddTravelType.aspx"
            scrolling="no"></iframe>
        <center>
            <asp:LinkButton ID="closeAddPanel" runat="server" ForeColor="green">【关闭】</asp:LinkButton></center>
    </div>
</asp:Content>
