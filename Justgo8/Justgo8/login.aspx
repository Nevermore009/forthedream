<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="Justgo8.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #main
        {
            margin: 0 auto;
            width: 1000px;
        }
        .green
        {
            color: #007434;
        }
        #content
        {
            background-image: url('images/login/login_bg.png');
            background-repeat: no-repeat;
            width: 1000px;
            height: 510px;
        }
        #logincon
        {
            position: absolute;
            top: 85px;
            right: 9px;
            width: 346px;
        }
        #logincon ul.tabs
        {
        }
        #logincon ul.tabs li.tab
        {
            background-image: url('images/login/login_tab_bg.png');
            height: 46px;
            background-repeat: repeat-x;
        }
        #logincon ul.tabs li.tab a
        {
            display: block;
            width: 100%;
            height: 100%;
            color: #333333;
            font-size: 14px;
            line-height: 44px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            letter-spacing: 2px;
        }
        #logincon ul.tabs li.cur a
        {
            color: #007434;
        }
        #tab1
        {
            padding-left: 45px;
        }
        #LoginUser
        {
            width: 100%;
        }
        .login p
        {
            height: 25px;
            line-height: 25px;
            vertical-align: middle;
            margin-bottom: 10px;
        }
        .login p label
        {
            font-size: 14px;
            font-weight: bold;
            margin-right: 12px;
            display: inline-block;
            width: 45px;
        }
        #rm
        {
            margin-left: 61px;
            line-height: 14px;
            vertical-align: middle;
            height: 14px;
        }
        #rm input
        {
            display: inline;
            vertical-align: middle;
        }
        #rm label
        {
            font-size: 12px;
            display: inline;
            font-weight: normal;
            margin: 0;
        }
        #rm a
        {
            margin: 0;
            padding: 0;
        }
        .textbox
        {
            width: 189px;
            padding-left: 3px;
            font-size: 12px;
            height: 25px;
            line-height: 25px;
            border: 1px solid #c4c4c4;
        }
        .submitButton
        {
            line-height: 29px;
            height: 29px;
            margin-left: 61px;
        }
        .LoginButton
        {
            background-image: url('images/login/login_lgbtn_bg.png');
            background-repeat: no-repeat;
            width: 82px;
            height: 29px;
            cursor: hand;
        }
        .submitButton a
        {
            background-position: right center;
            display: inline-block;
            margin-left: 12px;
            background-repeat: no-repeat;
            padding-right: 24px;
        }
        .failureNotificationWrapper
        {
            margin: 10px 0;
            display: block;
            margin-left: 61px;
            line-height: 20px;
            min-height: 60px;
        }
        .failureNotification
        {
            color: Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <div id="content" style="position: relative">
            <div id="logincon">
                <ul class="tabs clearfix">
                    <li class="tab"><a>会员登录</a></li>
                </ul>
                <div id="tab1">
                    <div class="failureNotificationWrapper">
                        <span class="failureNotification"></span>
                        <div id="LoginUserValidationSummary" class="failureNotification" style="display: none;">
                        </div>
                    </div>
                    <div class="accountInfo">
                        <fieldset class="login">
                            <p>
                                <label for="UserName" id="UserNameLabel">
                                    用户名</label>
                                <asp:TextBox runat="server" ID="txtusername" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ForeColor="Red" ValidationGroup="sss" ControlToValidate="txtusername"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <label for="Password" id="PasswordLabel">
                                    密 码</label>
                                <asp:TextBox runat="server" ID="txtpassword" CssClass="textbox"  TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ForeColor="Red" ValidationGroup="sss" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button runat="server" ID="btnsubmit" Text="" CssClass="LoginButton" ValidationGroup="sss"
                                OnClick="btnsubmit_Click" />
                                <%--<a href="/API/QQ/QQ.ashx" ><img src="images/Connect_logo_3.png" alt="使用QQ登录" /></a>--%>
                            <a href='register.aspx<%=String.IsNullOrEmpty(Request["returnurl"])?"":("?returnurl="+Request["returnurl"]) %>' class="green">免费注册</a></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
