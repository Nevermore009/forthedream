<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPipe.aspx.cs" Inherits="justgo.Manage.AddPipe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:skyblue">
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                名称:
            </td>
            <td>
                <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            </td>
            <td>
                线路ID:
            </td>
            <td>
                <asp:TextBox ID="txtdetailid" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                排序号:
            </td>
            <td>
                <asp:TextBox ID="sort" runat="server">0</asp:TextBox>(号码越大越靠前)
            </td>
            <td>
                文件:
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Btn" runat="server" Text="确 定" Width="80px" Height="25px" OnClick="Btn_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
