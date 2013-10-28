<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
    <style type="text/css">
        .left
        {
            color: #2b6dc1;
            font-weight: bold;
            font-family: Arial;
        }
        .btnlogin
        {
            width: 76px;
            height: 27px;
            background-image: url(images/login/login_bg.png);
            background-position: 0px 0px;
            background-repeat: no-repeat;
            border-width: 0px;
        }
        .btnreset
        {
            width: 76px;
            height: 27px;
            background-image: url(images/login/login_bg.png);
            background-position: right top;
            background-repeat: no-repeat;
            border-width: 0px;
        }
        .txtclass
        {
            width: 160px;
        }
        #logintable tr td
        {
            line-height: 36px;
        }
    </style>
</head>
<body style="text-align: center; vertical-align: middle; margin-top: 10%; background-color: Transparent;">
    <form id="form1" runat="server">
    <div>
        <center>
            <table id="logintable">
                <tr>
                    <td>
                        <span class="left">用户名:</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtusername" runat="server" CssClass="txtclass"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="sss"
                            ControlToValidate="txtusername"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <span class="left">密码:</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="txtclass"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="sss"
                            ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <img src="Validatecode.ashx" alt="验证码" title="点击更换" onclick="this.src='Validatecode.ashx?id='+Math.random()" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtcode" runat="server" CssClass="txtclass"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="sss"
                            ControlToValidate="txtcode"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right; line-height: 100%;">
                        <asp:Label runat="server" ID="lbwarn" ForeColor="Red" Font-Size="14px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" CssClass="btnlogin"
                            ValidationGroup="sss" />
                        <input type="reset" value="" class="btnreset" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
