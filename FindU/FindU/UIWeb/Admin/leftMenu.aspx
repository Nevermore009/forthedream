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
                <span class="normal_icon3"></span>督巡管理</div>
            <ul class="categoryitems">
                <li><a href="PatrolPlanAdd.aspx" target="frmright"><span class="text_slice">添加巡检计划</span></a></li>
                <li><a href="PatrolPlanView.aspx" target="frmright"><span class="text_slice">巡检历史</span></a></li>
                <li><a href="ViewInMap.aspx" target="_blank"><span class="text_slice">地图查看</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon6"></span>报表查看</div>
                <ul class="categoryitems">
                <li><a href="MonthlyReport.aspx" target="frmright"><span class="text_slice">月度报表</span></a></li>
                <li><a href="QuaterlyReport.aspx" target="frmright"><span class="text_slice">季度报表</span></a></li>
                <li><a href="AnnualReport.aspx" target="frmright"><span class="text_slice">年度报表</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon1"></span>终端管理</div>
            <ul class="categoryitems">
                <li><a href="TerminalAdd.aspx" target="frmright"><span class="text_slice">添加终端</span></a></li>
                <li><a href="TerminalView.aspx" target="frmright"><span class="text_slice">终端状态</span></a></li>
                <li><a href="SoftWareDownLoad.aspx" target="frmright"><span class="text_slice">终端软件下载</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon2"></span>光缆线路管理</div>
            <ul class="categoryitems">
                <li><a href="RouteView.aspx" target="frmright"><span class="text_slice">光缆线路查看</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon4"></span>员工管理</div>
            <ul class="categoryitems">
                <li><a href="StaffAdd.aspx" target="frmright"><span class="text_slice">添加巡检员</span></a></li>
                <li><a href="StaffView.aspx" target="frmright"><span class="text_slice">巡检员管理</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon5"></span>个人中心</div>
            <ul class="categoryitems">
                <li><a href="PasswordModify.aspx" target="frmright"><span class="text_slice">密码修改</span></a></li>
                <li><a href="PersonalInfo.aspx" target="frmright"><span class="text_slice">个人信息</span></a></li>
            </ul>
        </div>
    </div>
    <%--    <div class="menuheader expandable">
                <span class="normal_icon5"></span>多层级嵌套模板</div>
            <ul class="categoryitems">
                <li><a href="#" target="frmright"><span class="text_slice">横向导航</span></a></li>
            </ul>
             <div class="menuheader expandable">
                <span class="normal_icon6"></span>图表模板</div>
            <ul class="categoryitems">
                <li><a href="#" target="frmright"><span class="text_slice">简单图表</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon7"></span>其他</div>
            <ul class="categoryitems">
                <li><a href="#" target="frmright"><span class="text_slice">日程安排</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon8"></span>四级导航示例</div>
            <ul class="categoryitems">
                <li><a><span>第二级1</span></a>
                    <ul>
                        <li><a><span>第三极1</span></a>
                            <ul>
                                <li><a href="#"><span>第四级1</span></a></li>
                                <li><a href="#"><span>第四级2</span></a></li>
                            </ul>
                        </li>
                        <li><a href="#"><span>第三极2</span></a></li>
                        <li><a href="#"><span>第三极3</span></a></li>
                    </ul>
                </li>
                <li><a href="#"><span>第二级2</span></a>
                    <ul>
                        <li><a href="#"><span>第三极4</span></a></li>
                        <li><a href="#"><span>第三极5</span></a></li>
                        <li><a href="#"><span>第三极6</span></a></li>
                    </ul>
                </li>
                <li><a href="#"><span>第二级3</span></a></li>
            </ul>
            <div class="menuheader expandable">
                <span class="normal_icon9"></span>基本模板</div>
            <ul class="categoryitems">
                <li><a href="#" target="frmright"><span class="text_slice">基本右侧内页模板</span></a></li>
                <li><a href="#" target="frmright"><span class="text_slice">上下固定的右侧内页模板</span></a></li>
                <li><a href="#" target="frmright"><span class="text_slice">弹出窗口内页模板</span></a></li>
            </ul>
        </div>--%>
    </form>
</body>
</html>
