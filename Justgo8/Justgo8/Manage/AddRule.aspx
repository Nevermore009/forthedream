<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRule.aspx.cs" Inherits="Justgo8.Manage.AddRule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: skyblue">
    <form id="form1" runat="server">
    <div>
        类型:<asp:DropDownList ID="dropruletype" runat="server" Width="120px">
            <asp:ListItem Selected="True" Value="0">成人</asp:ListItem>
            <asp:ListItem Value="1">儿童</asp:ListItem>
        </asp:DropDownList>
        <br />
        说明:<asp:TextBox runat="server" ID="txtcontent" TextMode="MultiLine" Rows="20" Width="600px">
        </asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btnadd" Text="保存" Height="28px" Width="100px" OnClick="btnadd_Click" />
    </div>
    </form>
</body>
</html>
