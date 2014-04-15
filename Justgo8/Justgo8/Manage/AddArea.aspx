<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddArea.aspx.cs" Inherits="Justgo8.Manage.AddArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:skyblue">
    <form id="form1" runat="server">
    <div>
    旅游类型:<asp:DropDownList ID="droptraveltype" runat="server" Width="120px">
        </asp:DropDownList>
        区域名称:<asp:TextBox runat="server" ID="txtareaname"></asp:TextBox><span style="font-weight: bold;
            color: Red; font-size: 14px">Hot</span><asp:CheckBox ID="cbhot" runat="server" Checked="false"
                Text="" />
        <asp:Button runat="server" ID="btnadd" Text="保存" Height="28px" Width="100px" 
            onclick="btnadd_Click" />
    </div>
    </form>
</body>
</html>
