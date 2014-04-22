<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="vip.aspx.cs" Inherits="Justgo8.vip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/control.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main" style="height: 400px; padding-top: 30px; font-size: 20px; color: Green;
        padding-left: 100px;">
        敬请期待...</div>
    <div style="display:none">
        <asp:GridView ID="grvorders" runat="server" CssClass="gridview" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="价格" />
                <asp:BoundField HeaderText="成人数" />
                <asp:BoundField HeaderText="儿童人数" />
                <asp:HyperLinkField HeaderText="详情" />
            </Columns>
        
        </asp:GridView>
    </div>
</asp:Content>
