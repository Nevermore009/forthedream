<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTravelType.aspx.cs"
    Inherits="Justgo8.Manage.AddTravelType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style="background-color:skyblue">
    <form id="form1" runat="server">
    <div>
        名称:<asp:TextBox runat="server" ID="txttraveltypename"></asp:TextBox>
        <asp:Button runat="server" ID="btnadd" Text="保存" Height="28px" Width="100px" OnClick="btnadd_Click" />
    </div>
    </form>
</body>
</html>
