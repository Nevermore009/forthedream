<%@ Page Language="C#" AutoEventWireup="true" CodeFile="defaultpage.aspx.cs" Inherits="defaultpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>欢迎使用阳光智邦企业管理系统</title>
    <!--框架必需start-->
    <link href="../css/import_basic.css" rel="stylesheet" type="text/css" />
    <link href="../skins/sky/import_skin.css" rel="stylesheet" type="text/css" id="skin" />
    <script type="text/javascript" src="../js/jquery-1.4.js"></script>
    <script type="text/javascript" src="../js/bsFormat.js"></script>
    <!--框架必需end-->
    <!--让ie6支持透明png图片start-->
    <script src="../js/pngFix/supersleight.js" type="text/javascript"></script>
    <!--让ie6支持透明png图片end-->
</head>
<body>
    <form id="form1" runat="server">
    <div id="floatPanel-1">
    </div>
    <div id="mainFrame">
        <!--头部与导航start-->
        <div id="hbox">
            <div id="bs_bannercenter">
                <div id="bs_bannerleft">
                    <div id="bs_bannerright">
                        <div class="bs_banner_logo">
                        </div>
                        <div class="bs_banner_title">
                        </div>
                        <div class="bs_nav">
                            <div class="bs_navleft">
                                <ul>
                                    <li>尊敬的[<asp:Label runat="server" ID="lbuser"></asp:Label>],欢迎登录系统,今天是
                                        <script type="text/javascript">
                                            var weekDayLabels = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六");
                                            var now = new Date();
                                            var year = now.getFullYear();
                                            var month = now.getMonth() + 1;
                                            var day = now.getDate()
                                            var currentime = year + "年" + month + "月" + day + "日 " + weekDayLabels[now.getDay()]
                                            document.write(currentime)
                                        </script>
                                    </li>
                                </ul>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="bs_navright">
                                <span style="background: url(../skins/sky/mainframe/loginout.jpg) no-repeat left center;
                                    padding-left: 25px;">
                                    <asp:LinkButton ID="lkbtnLoginOut" runat="server" OnClientClick="return confirm('确定要退出系统吗？')"
                                        OnClick="lkbtnLoginOut_Click">退出登录</asp:LinkButton></span>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--头部与导航end-->
        <table width="100%" cellpadding="0" cellspacing="0" class="table_border0">
            <tr>
                <!--左侧区域start-->
                <td id="hideCon" class="ver01 ali01">
                    <div id="lbox">
                        <div id="lbox_topcenter">
                            <div id="lbox_topleft">
                                <div id="lbox_topright">
                                    <div class="lbox_title">
                                        操作菜单</div>
                                </div>
                            </div>
                        </div>
                        <div id="lbox_middlecenter">
                            <div id="lbox_middleleft">
                                <div id="lbox_middleright">
                                    <div id="bs_left">
                                        <iframe scrolling="no" width="100%" frameborder="0" id="frmleft" name="frmleft" src="leftMenu.aspx"
                                            allowtransparency="true" height="100%"></iframe>
                                    </div>
                                    <!--更改左侧栏的宽度需要修改id="bs_left"的样式-->
                                </div>
                            </div>
                        </div>
                        <div id="lbox_bottomcenter">
                            <div id="lbox_bottomleft">
                                <div id="lbox_bottomright">
                                    <div class="lbox_foot">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <!--左侧区域end-->
                <!--中间栏区域start-->
                <td class="main_shutiao">
                    <div class="bs_leftArr" id="bs_center" title="">
                    </div>
                </td>
                <!--中间栏区域end-->
                <!--右侧区域start-->
                <td class="ali01 ver01" width="100%">
                    <div id="rbox">
                        <div id="rbox_topcenter">
                            <div id="rbox_topleft">
                                <div id="rbox_topright">
                                    <div class="rbox_title">
                                        操作内容
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="rbox_middlecenter">
                            <div id="rbox_middleleft">
                                <div id="rbox_middleright">
                                    <div id="bs_right">
                                        <iframe scrolling="yes" width="100%" frameborder="0" id="frmright" name="frmright"
                                            src="open.aspx" allowtransparency="true"></iframe>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="rbox_bottomcenter">
                            <div id="rbox_bottomleft">
                                <div id="rbox_bottomright">
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <!--右侧区域end-->
            </tr>
        </table>
        <!--尾部区域start-->
        <div id="fbox">
            <div id="bs_footcenter">
                <div id="bs_footleft">
                    <div id="bs_footright">
                        Copyright 2013 &copy; 深圳市洲际人才管理有限公司版权所有&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;技术支持：奥凯软件
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--尾部区域end-->
    <!--浏览器resize事件修正start-->
    <div id="resizeFix">
    </div>
    <!--浏览器resize事件修正end-->
    <!--载进度条start-->
    <div class="progressBg" id="progress" style="display: none;">
        <div class="progressBar">
        </div>
    </div>
    <!--载进度条end-->
    
    </form>
</body>
</html>
