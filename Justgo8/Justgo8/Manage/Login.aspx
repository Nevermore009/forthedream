<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSD.Manage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理员登陆</title>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #1D3647;
        }
    </style>
    <link href="css/skin.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; height: 100%; margin: 0px 0px 0px 0px;">
        <table width="100%" height="166" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="42" valign="top">
                    <table width="100%" height="42" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
                        <tr>
                            <td width="1%" height="21">
                                &nbsp;
                            </td>
                            <td height="42">
                                &nbsp;
                            </td>
                            <td width="17%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg">
                        <tr>
                            <td width="49%" align="right">
                                <table width="91%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg2">
                                    <tr>
                                        <td height="138" valign="top">
                                            <table width="89%" height="427" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="35" height="120" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="198" colspan="2" align="right" valign="top">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr align="center">
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td height="25" colspan="2" class="left_txt">
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/logo.png"
                                                                        width="279" height="68" />
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td height="25" colspan="3" class="left_txt">
                                                                    1- 请不要在公共场所使用本系统&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td height="25" colspan="3" class="left_txt">
                                                                    2- 请牢记好您的用户名和密码，切勿泄露
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td height="25" colspan="3" class="left_txt">
                                                                    3- 强大的后台系统，管理内容易如反掌&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="50%" valign="bottom">
                                <table width="100%" height="59" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="4%">
                                            &nbsp;
                                        </td>
                                        <td width="96%" height="38">
                                            <span class="login_txt_bt">登陆网站后台管理</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td height="21">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" id="table211" height="328">
                                                <tr>
                                                    <td height="164" colspan="2" align="right">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0" height="143" id="table212"
                                                            align="left">
                                                            <tr align="left">
                                                                <td width="13%" height="38" class="top_hui_text">
                                                                    <span class="login_txt">用户名：&nbsp;&nbsp; </span>
                                                                </td>
                                                                <td height="38" colspan="2" class="top_hui_text">
                                                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>&nbsp;<asp:Label ID="msg"
                                                                        runat="server" ForeColor="red" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr align="left">
                                                                <td width="13%" height="35" class="top_hui_text">
                                                                    <span class="login_txt">密 码： &nbsp;&nbsp; </span>
                                                                </td>
                                                                <td height="35" colspan="2" class="top_hui_text">
                                                                    <asp:TextBox ID="txtUserPwd" TextMode="Password" runat="server"></asp:TextBox>
                                                                    <img src="images/luck.gif" width="19" height="18">
                                                                </td>
                                                            </tr>
                                                            <tr align="left">
                                                                <td width="13%" height="35" class="top_hui_text">
                                                                    <span class="login_txt">验证码： &nbsp;&nbsp; </span>
                                                                </td>
                                                                <td height="35" colspan="2" class="top_hui_text">
                                                                    <input type="text" id="Text1" name="txtCode" style="width: 50px; height: 18px" />
                                                                    <img style="width: 51px; height: 18px" height="15" alt="" title="看不清,点击换一张" src="CheckCodeImg.aspx"
                                                                        onclick="this.src='CheckCodeImg.aspx?id='+Math.random()" width="51" />
                                                                </td>
                                                            </tr>
                                                            <tr align="left">
                                                                <td height="35">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="15%" height="35">
                                                                    <asp:Button ID="Button1" runat="server" Text="登陆" OnClick="Button1_Click" />
                                                                </td>
                                                                <td width="67%" class="top_hui_text">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="433" height="164" align="right" valign="bottom">
                                                        <img src="images/login-wel.gif" width="242" height="138">
                                                    </td>
                                                    <td width="57" align="right" valign="bottom">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="20">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="login-buttom-bg">
                        <tr>
                            <td align="center">
                                <span class="login-buttom-txt">
                                    <%=ConfigurationSettings.AppSettings["sitename"]%>--后台管理</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
