<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCity.aspx.cs" Inherits="Justgo8.Manage.AddCity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: skyblue">
    <form id="form1" runat="server">
    <div>
        <span runat="server" id="typeselect">类型:<asp:DropDownList ID="droptraveltype" runat="server" Width="120px" OnSelectedIndexChanged="droptraveltype_SelectedIndexChanged"
            AutoPostBack="true">
        </asp:DropDownList>
        </span>地区名称:<asp:DropDownList ID="droparea" runat="server" Width="120px">
        </asp:DropDownList>
        城市名称:<asp:TextBox runat="server" ID="txtcityname"></asp:TextBox><span style="font-weight: bold;
            color: Red; font-size: 14px">Hot</span><asp:CheckBox ID="cbhot" runat="server" Checked="false"
                Text="" />
        <asp:Button runat="server" ID="btnadd" Text="保存" Height="28px" Width="100px" OnClick="btnadd_Click" />
    </div>
    </form>
</body>
</html>
