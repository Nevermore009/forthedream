<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffAdd.aspx.cs" Inherits="Admin_StaffAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加员工</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" style="margin-top:50px">
    <center>
        <table>
            <tr>
                <td class="lefttd">
                    姓名:
                </td>
                <td class="righttd">
                    <asp:TextBox ID="txtstaffname" runat="server" CssClass="textbox" />
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnsave" Text="添加" CssClass="button" 
            onclick="btnsave_Click" />
    </center>
    </form>
</body>
</html>
