<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>欢迎使用阳光智邦企业管理系统</title>
    <%--<link rel="shortcut icon" href="images/logo.png" />--%>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.4.js"></script>
    <script type="text/javascript" src="js/login.js"></script>
    <!--居中显示start-->
    <script type="text/javascript" src="js/center-plugin.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.login_main').center();
        }
    )
    </script>
    <!--居中显示end-->
    <!--让ie6支持透明png图片start-->
    <script src="js/pngFix/supersleight.js" type="text/javascript"></script>
    <!--让ie6支持透明png图片end-->
    <style type="text/css">
        /*提示信息*/#cursorMessageDiv
        {
            position: absolute;
            z-index: 99999;
            border: solid 1px #cc9933;
            background: #ffffcc;
            padding: 2px;
            margin: 0px;
            display: none;
            line-height: 150%;
        }
        /*提示信息*/</style>
</head>
<body>
    <div class="login_main">
        <div class="login_top">
            <div class="login_title">
            </div>
        </div>
        <div class="login_middle">
            <div class="login_middleleft">
            </div>
            <div class="login_middlecenter">
                <div class="login_frame">
                    <iframe id="loginframe" src="Login.aspx" allowtransparency="true" width="100%" height="100%"
                        frameborder="0" scrolling="no" style="z-index:1"></iframe>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="login_bottom">
            <div class="login_copyright">
                Copyright 2013 @ 深圳市洲际人才管理有限公司 版权所有 技术支持：奥凯软件
            </div>
        </div>
    </div>
</body>
</html>
