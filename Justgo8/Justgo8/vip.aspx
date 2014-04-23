<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="vip.aspx.cs" Inherits="Justgo8.vip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/control.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #content
        {
            margin: 0px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <asp:Panel runat="server" GroupingText="您的预订">
            <center>
                <asp:GridView ID="grvorders" runat="server" CssClass="gridview" AutoGenerateColumns="False"
                    Width="90%">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="成人价格" DataField="adultprice" />
                        <asp:BoundField HeaderText="成人人数" DataField="adultnum" />
                        <asp:BoundField HeaderText="儿童价格" DataField="childprice" />
                        <asp:BoundField HeaderText="儿童人数" DataField="childnum" />
                        <asp:BoundField HeaderText="预订时间" DataField="createtime" />
                        <asp:HyperLinkField HeaderText="详情" DataTextField="detailid" DataNavigateUrlFormatString="detail.aspx?id={0}" />
                    </Columns>
                    <EmptyDataTemplate>
                        <font style="color: Red; font-size: 14px;">暂无订单</font>
                    </EmptyDataTemplate>
                </asp:GridView>
            </center>
        </asp:Panel>
        <br />
        <br />
    </div>
</asp:Content>
