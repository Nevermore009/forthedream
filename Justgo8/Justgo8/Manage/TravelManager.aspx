<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="TravelManager.aspx.cs" Inherits="Justgo8.Manage.TravelManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">
        function HotChange(cb, id) {
            $.get("HotHandler.ashx?detailid=" + id + "&ishot=" + (cb.checked ? 1 : 0), function (data) {
                if (data != "success") {
                    alert("修改失败");
                    cb.checked = !cb.checked;                    
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SmallTitle" runat="server">
    旅游线路管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <a href="AddDetail.aspx" id="Area" style="font-weight: bold; color: Green;">添 加</a>
    <hr style="width: 100%;" color="#bbb" size="3" />
    <asp:Repeater ID="repeatertraveltype" runat="server" OnItemDataBound="repeatertraveltype_ItemDataBound">
        <ItemTemplate>
            <%# Eval("traveltypename") %>
            <hr style="width: 100%;" color="#bbb" size="3" />
            <div class="pro_list">
                <ul class="pro_show" style="margin-top: 5px">
                    <asp:Repeater ID="repeaterdetail" runat="server" OnItemCommand="RPlank_ItemCommand">
                        <ItemTemplate>
                            <li><a href="../detail.aspx?id=<%#Eval("id") %>" target="_blank">
                                <img src="..<%#Eval("pic") %>" height="100px" width="100px" title="" alt="" /></a>
                                <br />
                                <font style="font-weight: bold; font-size: 18px">
                                    <%#Eval("title") %></font>
                                <br />
                                <font style="font-weight: bold; font-size: 18px">
                                    <%#Eval("destination").ToString()==""?"":"目的地:"+Eval("destination").ToString()+"等" %></font><br />
                                Hot<input type="checkbox"  <%# bool.Parse(Eval("hot").ToString())?"checked='checked'":"" %>
                                    onclick="HotChange(this,<%#Eval("id") %>)" />
                                <a href='AddDetail.aspx?travelid=<%# Eval("id") %>'>修改</a>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("id")%>'
                                    OnClientClick="javascript:return confirm('确认是否删除？')">删除</asp:LinkButton></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div style="background-color: Green; clear: both;">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
