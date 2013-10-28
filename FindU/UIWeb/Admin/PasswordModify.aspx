<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswordModify.aspx.cs" Inherits="个人设置_PasswordModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: auto auto">
    <form id="form1" runat="server">
    <div style="margin-top:3%">
    <center>
        <table>
            <tr>
                <td class="lefttd">
                    原密码:
                </td>
                <td class="righttd">
                    <asp:TextBox ID="txtold" runat="server" cssclass="textbox" TextMode="Password" MaxLength="16"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="lefttd">
                    新密码:
                </td>
                <td class="righttd">
                    <asp:TextBox ID="txtnew" runat="server" cssclass="textbox" TextMode="Password"  MaxLength="16"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="lefttd">
                    确认密码:
                </td>
                <td class="righttd">
                    <asp:TextBox ID="txtensure" runat="server" cssclass="textbox" TextMode="Password" MaxLength="16"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="lefttd">
                </td>
                <td class="righttd" colspan="2">
                    <asp:Button ID="btnedit" runat="server" Text="修改" cssclass="button" 
                        onclick="btnedit_Click" />
                </td>
            </tr>
        </table></center>
    </div>
    </form>
</body>
</html>
