<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leftMenu.aspx.cs" Inherits="leftPages_leftMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!--框架必需start-->
    <script type="text/javascript" src="../js/jquery-1.4.js"></script>
    <script type="text/javascript" src="../js/framework.js"></script>
    <link href="../css/import_basic.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" id="skin" />
    <!--框架必需end-->
    <script type="text/javascript" src="../js/nav/ddaccordion.js"></script>
    <style type="text/css">
        .categoryitems span
        {
            width: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="scrollContent">
        <div class="arrowlistmenu">
            <div class="menuheader expandable">
                <span class="normal_icon1"></span>终端管理</div>
            <ul class="categoryitems">
                <li><a href="../Admin/TerminalAdd.aspx" target="frmright"><span class="text_slice">添加终端</span></a></li>
                <li><a href="SoftWareUpLoad.aspx" target="frmright"><span class="text_slice">软件上传</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon2"></span>光缆线路管理</div>
            <ul class="categoryitems">
                <li><a href="RoutePlanAdd.aspx" target="frmright"><span class="text_slice">添加光缆线路采集计划</span></a></li>
                <li><a href="RoutePlanView.aspx" target="frmright"><span class="text_slice">采集计划查看</span></a></li>
                <li><a href="RouteAdd.aspx" target="frmright"><span class="text_slice">添加光缆线路</span></a></li>
                <li><a href="../Admin/RouteView.aspx" target="frmright"><span class="text_slice">光缆线路查看</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon4"></span>员工管理</div>
            <ul class="categoryitems">
                <li><a href="../Admin/StaffAdd.aspx" target="frmright"><span class="text_slice">添加巡检员</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon5"></span>个人中心</div>
            <ul class="categoryitems">
                <li><a href="../Admin/PersonalInfo.aspx" target="frmright"><span class="text_slice">
                    个人信息</span></a></li>
                <li><a href="../Admin/PasswordModify.aspx" target="frmright"><span class="text_slice">
                    密码修改</span></a></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
