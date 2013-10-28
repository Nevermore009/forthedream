<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Webmanager.aspx.cs" Inherits="Webmanager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统管理</title>
    <link href="css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <table>
            <tr>
                <td class="lefttd" style="width: 200px">
                    登录页标题及logo图:
                </td>
                <td>
                    <asp:FileUpload ID="fileindex" runat="server" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnindex" CssClass="button" CommandArgument="index"
                        OnClick="btnsubmit_Click" Text="修改" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" style="width: 200px">
                    主界面logo图:
                </td>
                <td>
                    <asp:FileUpload ID="filelogo" runat="server" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnlogo" CssClass="button" CommandArgument="logo"
                        OnClick="btnsubmit_Click" Text="修改" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" style="width: 200px">
                    主界面标题图:
                </td>
                <td>
                    <asp:FileUpload ID="filetitle" runat="server" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btntitle" CssClass="button" CommandArgument="title"
                        OnClick="btnsubmit_Click" Text="修改" />
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
