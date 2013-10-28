<%@ Page Language="C#" AutoEventWireup="true" CodeFile="server.aspx.cs" Inherits="server" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        target:
        <asp:TextBox ID="target" runat="server" Width="200px"></asp:TextBox><br />
        content:<asp:TextBox ID="content" runat="server" TextMode="MultiLine" Rows="5" Width="400px"> 
        </asp:TextBox><br /><asp:Button ID="btnsend" runat="server" Text="send" OnClick="btnsend_Click" />
    </div>
    </form>
</body>
</html>
