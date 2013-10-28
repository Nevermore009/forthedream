<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Campus.ascx.cs" Inherits="Controls_Campus" %>
<asp:UpdatePanel runat="server" ID="update1" RenderMode="Inline">
    <ContentTemplate>
        <span id="campusfield" runat="server">校区:<asp:DropDownList runat="server" ID="dropcampus"
            CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="dropcampus_SelectedIndexChanged">
        </asp:DropDownList>
        </span>学校:<asp:DropDownList runat="server" ID="dropschool" CssClass="dropdownlist"
            AutoPostBack="True" OnSelectedIndexChanged="dropschool_SelectedIndexChanged">
        </asp:DropDownList>
        年级:<asp:DropDownList runat="server" ID="dropgrade" CssClass="dropdownlist" AutoPostBack="True"
            OnSelectedIndexChanged="dropgrade_SelectedIndexChanged">
        </asp:DropDownList>
        专业:<asp:DropDownList runat="server" ID="dropprofession" CssClass="dropdownlist">
        </asp:DropDownList>
    </ContentTemplate>
</asp:UpdatePanel>
