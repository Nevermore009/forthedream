<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="Justgo8.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/category.css" rel="stylesheet" type="text/css" />
    <script src="js/lrscroll.js" type="text/javascript"></script>
    <script src="js/index_base.js" type="text/javascript"></script>
    <script src="js/saved_resource.js" type="text/javascript"></script>
    <!--滚动栏-->
    <style type="text/css">
        .titbox
        {
            font-size: 18px;
            color: #3366cc;
            height: 32px;
            overflow: hidden;
            width: 880px;
            margin: 20px auto;
        }
        .scroll
        {
            width: 880px;
            color: #333333;
            margin: 2px 2px 0px 2px;
            overflow: hidden;
        }
        .scroll #scrollcon img
        {
            border: solid 1px #ddd;
            margin: 0 1px;
            height: 325px;
        }
        .scroll #scrollcon2 img
        {
            border: solid 1px #ddd;
            margin: 0 1px;
            height: 243px;
        }
        .scroll a
        {
            height: 100%;
        }
        .scroll a:hover img
        {
            border: solid 1px #990000;
        }
    </style>
    <!--inland滚动-->
    <script type="text/javascript">

        var dir = 1; //每步移动像素，大＝快
        var speed = 30; //循环周期（毫秒）大＝慢
        var MyMar = null;

        function Marquee() {//正常移动
            var scrollbox = document.getElementById("scrollbox");
            var scrollcopy = document.getElementById("scrollcopy");
            if (dir > 0 && (scrollcopy.offsetWidth - scrollbox.scrollLeft) <= 0) {
                scrollbox.scrollLeft = 0;
            }
            if (dir < 0 && (scrollbox.scrollLeft <= 0)) {
                scrollbox.scrollLeft = scrollcopy.offsetWidth;
            }
            scrollbox.scrollLeft += dir;
        }

        function onmouseoverMy() {
            window.clearInterval(MyMar);
        } //暂停移动

        function onmouseoutMy() {
            MyMar = setInterval(Marquee, speed);
        } //继续移动

        function r_left() {
            if (dir == -1)
                dir = 1;
        } //换向左移

        function r_right() {
            if (dir == 1)
                dir = -1;
        } //换向右移

        function IsIE() {
            var browser = navigator.appName
            if ((browser == "Netscape")) {
                return false;
            }
            else if (browser == "Microsoft Internet Explorer") {
                return true;
            } else {
                return null;
            }
        }

        var _IsIE = IsIE();
        var _MousePX = 0;
        var _MousePY = 0;
        var _DivLeft = 0;
        var _DivRight = 0;
        var _AllDivWidth = 0;
        var _AllDivHeight = 0;

        function MoveDiv(e) {

            var obj = document.getElementById("scrollbox");
            _MousePX = _IsIE ? (document.body.scrollLeft + event.clientX) : e.pageX;
            _MousePY = _IsIE ? (document.body.scrollTop + event.clientY) : e.pageY;
            //Opera Browser Can Support ''window.event'' and ''e.pageX''

            var obj1 = null;

            if (obj.getBoundingClientRect) {
                //IE
                obj1 = document.getElementById("scrollbox").getBoundingClientRect();
                _DivLeft = obj1.left;
                _DivRight = obj1.right;
                _AllDivWidth = _DivRight - _DivLeft;
            } else if (document.getBoxObjectFor) {
                //FireFox
                obj1 = document.getBoxObjectFor(obj);
                var borderwidth = (obj.style.borderLeftWidth != null && obj.style.borderLeftWidth != "") ? parseInt(obj.style.borderLeftWidth) : 0;
                _DivLeft = parseInt(obj1.x) - parseInt(borderwidth);
                _AllDivWidth = Cut_Px(obj.style.width);
                _DivRight = _DivLeft + _AllDivWidth;
            } else {
                //Other Browser(Opera)
                _DivLeft = obj.offsetLeft;
                _AllDivWidth = Cut_Px(obj.style.width);
                var parent = obj.offsetParent;

                if (parent != obj) {
                    while (parent) {
                        _DivLeft += parent.offsetLeft;
                        parent = parent.offsetParent;
                    }
                }
                _DivRight = _DivLeft + _AllDivWidth;
            }

            var pos1, pos2;
            pos1 = parseInt(_AllDivWidth * 0.4) + _DivLeft;
            pos2 = parseInt(_AllDivWidth * 0.6) + _DivLeft;

            if (_MousePX > _DivLeft && _MousePX < _DivRight) {
                if (_MousePX > _DivLeft && _MousePX < pos1) {
                    r_left(); //Move left
                }
                else if (_MousePX < _DivRight && _MousePX > pos2) {
                    r_right(); //Move right
                }
                if (_MousePX > pos1 && _MousePX < pos2) {
                    onmouseoverMy(); //Stop
                    MyMar = null;
                } else if (_MousePX < pos1 || _MousePX > pos2) {
                    if (MyMar == null) {
                        MyMar = setInterval(Marquee, speed);
                    }
                }
            }
        }

        function Cut_Px(cswidth) {
            cswidth = cswidth.toLowerCase();
            if (cswidth.indexOf("px") != -1) {
                cswidth.replace("px", "");
                cswidth = parseInt(cswidth);
            }
            return cswidth;
        }

        function MoveOutDiv() {
            if (MyMar == null) {
                MyMar = setInterval(Marquee, speed);
            }
        }
    </script>
    <!--outland滚动-->
    <script type="text/javascript">

        var dir2 = 1; //每步移动像素，大＝快
        var speed2 = 30; //循环周期（毫秒）大＝慢
        var MyMar2 = null;

        function Marquee2() {//正常移动
            var scrollbox = document.getElementById("scrollbox2");
            var scrollcopy = document.getElementById("scrollcopy2");
            if (dir2 > 0 && (scrollcopy.offsetWidth - scrollbox.scrollLeft) <= 0) {
                scrollbox.scrollLeft = 0;
            }
            if (dir2 < 0 && (scrollbox.scrollLeft <= 0)) {
                scrollbox.scrollLeft = scrollcopy.offsetWidth;
            }
            scrollbox.scrollLeft += dir2;
        }

        function onmouseoverMy2() {
            window.clearInterval(MyMar2);
        } //暂停移动

        function onmouseoutMy2() {
            MyMar2 = setInterval(Marquee2, speed2);
        } //继续移动

        function r_left2() {
            if (dir2 == -1)
                dir2 = 1;
        } //换向左移

        function r_right2() {
            if (dir2 == 1)
                dir2 = -1;
        } //换向右移

        var _MousePX2 = 0;
        var _MousePY2 = 0;
        var _DivLeft2 = 0;
        var _DivRight2 = 0;
        var _AllDivWidth2 = 0;
        var _AllDivHeight2 = 0;

        function MoveDiv2(e) {
            var obj = document.getElementById("scrollbox2");
            _MousePX2 = _IsIE ? (document.body.scrollLeft + event.clientX) : e.pageX;
            _MousePY2 = _IsIE ? (document.body.scrollTop + event.clientY) : e.pageY;
            //Opera Browser Can Support ''window.event'' and ''e.pageX''

            var obj1 = null;

            if (obj.getBoundingClientRect) {
                //IE
                obj1 = document.getElementById("scrollbox2").getBoundingClientRect();
                _DivLeft2 = obj1.left;
                _DivRight2 = obj1.right;
                _AllDivWidth2 = _DivRight2 - _DivLeft2;
            } else if (document.getBoxObjectFor) {
                //FireFox
                obj1 = document.getBoxObjectFor(obj);
                var borderwidth = (obj.style.borderLeftWidth != null && obj.style.borderLeftWidth != "") ? parseInt(obj.style.borderLeftWidth) : 0;
                _DivLeft2 = parseInt(obj1.x) - parseInt(borderwidth);
                _AllDivWidth2 = Cut_Px(obj.style.width);
                _DivRight2 = _DivLeft2 + _AllDivWidth2;
            } else {
                //Other Browser(Opera)
                _DivLeft2 = obj.offsetLeft;
                _AllDivWidth2 = Cut_Px(obj.style.width);
                var parent = obj.offsetParent;

                if (parent != obj) {
                    while (parent) {
                        _DivLeft2 += parent.offsetLeft;
                        parent = parent.offsetParent;
                    }
                }
                _DivRight2 = _DivLeft2 + _AllDivWidth2;
            }

            var pos1, pos2;
            pos1 = parseInt(_AllDivWidth2 * 0.4) + _DivLeft2;
            pos2 = parseInt(_AllDivWidth2 * 0.6) + _DivLeft2;

            if (_MousePX2 > _DivLeft2 && _MousePX2 < _DivRight2) {
                if (_MousePX2 > _DivLeft2 && _MousePX2 < pos1) {
                    r_left2(); //Move left
                }
                else if (_MousePX2 < _DivRight2 && _MousePX2 > pos2) {
                    r_right2(); //Move right
                }
                if (_MousePX2 > pos1 && _MousePX2 < pos2) {
                    onmouseoverMy2(); //Stop
                    MyMar2 = null;
                } else if (_MousePX2 < pos1 || _MousePX2 > pos2) {
                    if (MyMar2 == null) {
                        MyMar2 = setInterval(Marquee2, speed2);
                    }
                }
            }
        }

        function MoveOutDiv2() {
            if (MyMar2 == null) {
                MyMar2 = setInterval(Marquee2, speed2);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="container">
        <div id="welcome">
            <div id="welcomel">
                <!--旅游线路分类 -->
                <script type="text/javascript">
                    function goToLineView(id) {
                        window.open("search.aspx?de=" + id + "", target = "_blank");
                    }
                </script>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $(".item:last").css("border-bottom", "1px solid #0B6130");
                        $(".item:last").css("height", "28px");
                        $(".allsort .item .i-mc:first").css("top", "-38px");
                    });
                </script>
                <div class="shipin_main312">
                    <div class="allsort">
                        <p class="catetitle">
                            旅游线路分类</p>
                        <div class="mc">
                            <asp:Repeater runat="server" ID="RepeaterTraveltype" OnItemDataBound="RepeaterTraveltype_ItemDataBound">
                                <ItemTemplate>
                                    <div class="item">
                                        <span>
                                            <h3>
                                                <a href="#">
                                                    <%#Eval("traveltypename") %></a>
                                                <img src="images/index/jiantou_03.gif" class="jiantou" alt="" />
                                            </h3>
                                            <div class="seccat">
                                                <asp:Repeater runat="server" ID="RepeaterHotArea">
                                                    <ItemTemplate>
                                                        <a href='TravelDetail.aspx?areaid=<%#Eval("areaid") %>'><em>
                                                            <%#Eval("areaname") %></em></a>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </span>
                                        <div class="i-mc">
                                            <div class="subitem">
                                                <asp:Repeater ID="RepeaterArea" runat="server" OnItemDataBound="RepeaterArea_ItemDataBound">
                                                    <ItemTemplate>
                                                        <dl>
                                                            <dt><a href="#">
                                                                <%#Eval("areaname") %></a> </dt>
                                                            <dd>
                                                                <asp:Repeater ID="RepeaterCity" runat="server">
                                                                    <ItemTemplate>
                                                                        <%# Container.ItemIndex+1<=1?"":"<em>|</em>"%>
                                                                        <em><a href="#">
                                                                            <%#Eval("cityname") %></a></em></ItemTemplate>
                                                                </asp:Repeater>
                                                            </dd>
                                                        </dl>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="item">
                                <span>
                                    <h3>
                                        <a href="#">团队定制</a>
                                        <img src="images/index/jiantou_03.gif" class="jiantou" alt="" />
                                    </h3>
                                </span>
                                <div class="i-mc">
                                    <div class="subitem" style="width: 804px; right: -1px; bottom: -1px;">
                                        <div class="subView5">
                                            <ul>
                                                <li class="subItemli">
                                                    <h3 class="subItem-hd ">
                                                        <a href="#">私人定制</a></h3>
                                                    <p class="subItem-cat">
                                                        <a href="#">主题特色</a> <a href="#">城市印象</a> <a href="#">自驾探险</a> <a href="#">“慢”旅游</a>
                                                        <a href="#">健康养生</a> <a href="#">美食购物</a> <a href="#">亲子家庭</a> <a href="#">浪漫甜蜜</a>
                                                    </p>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <script type="text/javascript">
                    $(".allsort").hoverForIE6({
                        current: "allsorthover", delay: 200
                    }); $(".allsort .item").hoverForIE6({ delay: 150
                    });
                </script>
            </div>
            <div id="welcomer">
                <div style="width: 810px; height: 382px; float: left;">
                    <!--轮播图片部分-->
                    <div class="Cenline">
                        <div class="part01center">
                            <div class="topbanner">
                                <div id="divimagebanner" class="bannerimg">
                                    <!--图片加上图片上方的图片名字-->
                                    <asp:Repeater ID="RepeaterWelcomePic" runat="server">
                                        <ItemTemplate>
                                            <a href="<%# Eval("url")%>" <%# Container.ItemIndex+1<=1?"style='display:block;'":"style='display:none;'"%>>
                                                <img border="0" width="810px" height="352px" src='<%# Eval("pic")%>' alt="<%# Eval("name")%>"
                                                    title='<%# Eval("name")%>' /></a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div id="divbanner" class="bannertext">
                                    <!--图片下方的透明切换-->
                                    <ul>
                                        <asp:Repeater ID="RepeaterWelcomeWord" runat="server">
                                            <ItemTemplate>
                                                <li><a href="<%# Eval("url")%>" <%# Container.ItemIndex+1<=1?"class='hover'":""%>>
                                                    <%# Eval("name")%></a></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--INLAND AREA STARTS-->
        <div id="inland">
            <div style="width: 185px; height: 30px; float: left; padding-top: 10px;">
                <img src="images/index/inland.jpg" alt="" width="185" height="30" /></div>
            <div class="selectarea">
                <asp:Repeater runat="server" ID="RepeaterHotInland">
                    <ItemTemplate>
                        <a href="#" <%# Container.ItemIndex==0?"class='first'":"" %>>
                            <%#Eval("areaname") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="morearea">
                <a href="#">更多&gt;&gt;</a></div>
            <div style="width: 100%; float: left; border-top: #489ea9 solid 2px; border-bottom: #c4c4c4 solid 1px;
                border-right: #c4c4c4 solid 1px; overflow: hidden;">
                <div id="inlandleft">
                    <ul class="gn">
                        <asp:Repeater runat="server" ID="RepeaterInland">
                            <ItemTemplate>
                                <li><a href="#" target="_blank">
                                    <%#Eval("areaname") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div style="width: 815px; float: left;" id="inlandcontent">
                    <div class="hot_sort">
                        <div class="hs_wrap">
                            <div class="hs_w710 clearfix">
                                <div class="hs_con" style="width: 370px; margin-left: 15px;">
                                    <div class="mb_10">
                                        <ol>
                                            <asp:Repeater ID="repeaterinlandshow1" runat="server">
                                                <ItemTemplate>
                                                    <li class="hs_item"><a class="hs_name" style="width: 280px;" href='detail.aspx?id=<%#Eval("id") %>'
                                                        title='<%#Eval("title") %>' rel="nofollow"><span class="f_0053aa">
                                                            <%#Eval("description") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                            </asp:Repeater>
                                        </ol>
                                    </div>
                                </div>
                                <div class="hs_con" style="width: 370px; margin-left: 30px;">
                                    <div class="mb_10">
                                        <ol>
                                            <asp:Repeater ID="repeaterinlandshow2" runat="server">
                                                <ItemTemplate>
                                                    <li class="hs_item"><a class="hs_name" style="width: 280px;" href='detail.aspx?id=<%#Eval("id") %>'
                                                        title='<%#Eval("title") %>' rel="nofollow"><span class="f_0053aa">
                                                            <%#Eval("description") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                            </asp:Repeater>
                                        </ol>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- <div class="scroll" id="scrollbox" onmousemove="MoveDiv(event);" onmouseout="MoveOutDiv();"
                        style="width: 100%; height: 325px;">
                        <div id="scrollcon" style="width: 100%; height: 325px;">
                            <table style="height: 100%; width: 100%; line-height: 100%">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table width="100%" style="line-height: 100%; height: 100%">
                                                <tr style="height: 93%">
                                                    <td>
                                                        <a href="#">
                                                            <img src="images/index/inland001.jpg" alt="" /></a>
                                                    </td>
                                                    <td>
                                                        <a href="#">
                                                            <img src="images/index/inland002.jpg" alt="" />
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <a href="#">
                                                            <img src="images/index/inland003.jpg" alt="" /></a>
                                                    </td>
                                                    <td>
                                                        <a href="#">
                                                            <img src="images/index/inland004.jpg" alt="" />
                                                        </a>
                                                    </td>
                                                    <td>
                                                        <a href="#">
                                                            <img src="images/index/inland005.jpg" alt="" /></a>
                                                    </td>
                                                    <td>
                                                        <a href="#">
                                                            <img src="images/index/inland006.jpg" alt="" />
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr style="text-align: center; font-size: 14px">
                                                    <td>
                                                        <a href="#">香港一日游</a>
                                                    </td>
                                                    <td>
                                                        <a href="#">韩国一日游</a>
                                                    </td>
                                                    <td>
                                                        <a href="#">日本一日游</a>
                                                    </td>
                                                    <td>
                                                        <a href="#">凤凰一日游</a>
                                                    </td>
                                                    <td>
                                                        <a href="#">法国一日游</a>
                                                    </td>
                                                    <td>
                                                        <a href="#">内地一日游</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <div id="scrollcopy" style="width: 100%;">
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <script type="text/javascript">
                        document.getElementById("scrollcopy").innerHTML = document.getElementById("scrollcon").innerHTML;
                        MyMar = setInterval(Marquee, speed);
                    </script>--%>
                </div>
            </div>
        </div>
        <!--INLAND AREA ENDS-->
        <!--OUTLAND AREA STARTS-->
        <div id="outland">
            <div style="width: 185px; height: 30px; float: left; padding-top: 10px;">
                <img alt="" src="images/index/outland.jpg" width="185" height="30" /></div>
            <div class="selectarea">
                <asp:Repeater runat="server" ID="RepeaterHotOutland">
                    <ItemTemplate>
                        <li><a href="#" target="_blank" <%# Container.ItemIndex==0?"class='first'":""%>>
                            <%#Eval("areaname") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="morearea">
                <a href="#" style="font-family: 宋体">更多&gt;&gt;</a></div>
            <div id="hidden" style="width: 100%; float: left; border-top: #438544 solid 2px;
                border-bottom: #c4c4c4 solid 1px; border-right: #c4c4c4 solid 1px; overflow: hidden;">
                <div id="outlandleft">
                    <ul class="cj">
                        <asp:Repeater runat="server" ID="RepeaterOutland">
                            <ItemTemplate>
                                <li><a href="#" target="_blank">
                                    <%#Eval("areaname") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="rightheight">
                    <div style="width: 815px; float: left;" id="outlandcontent">
                        <div class="hot_sort">
                            <div class="hs_wrap">
                                <div class="hs_w710 clearfix">
                                    <div class="hs_con" style="width: 370px; margin-left: 15px;">
                                        <div class="mb_10">
                                            <ol>
                                                <asp:Repeater ID="repeateroutlandshow1" runat="server">
                                                    <ItemTemplate>
                                                        <li class="hs_item"><a class="hs_name" style="width: 280px;" href='detail.aspx?id=<%#Eval("id") %>'
                                                            title='<%#Eval("title") %>' rel="nofollow"><span class="f_0053aa">
                                                                <%#Eval("description") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                                </asp:Repeater>
                                            </ol>
                                        </div>
                                    </div>
                                    <div class="hs_con" style="width: 370px; margin-left: 30px;">
                                        <div class="mb_10">
                                            <ol>
                                                <asp:Repeater ID="repeateroutlandshow2" runat="server">
                                                    <ItemTemplate>
                                                        <li class="hs_item"><a class="hs_name" style="width: 280px;" href='detail.aspx?id=<%#Eval("id") %>'
                                                            title='<%#Eval("title") %>' rel="nofollow"><span class="f_0053aa">
                                                                <%#Eval("description") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                                </asp:Repeater>
                                            </ol>
                                        </div>
                                    </div>
                                    <!--end hsCon-->
                                </div>
                            </div>
                        </div>
                        <%-- <div class="scroll" id="scrollbox2" onmousemove="MoveDiv2(event);" onmouseout="MoveOutDiv2();"
                            style="height: 243px;">
                            <div id="scrollcon2" style="width: 100%; height: 243px;">
                                <table style="height: 100%; width: 100%; line-height: 100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <table width="100%" style="line-height: 100%; height: 100%">
                                                    <tr style="height: 93%">
                                                        <td>
                                                            <a href="#">
                                                                <img src="images/index/outland001.jpg" alt="" /></a>
                                                        </td>
                                                        <td>
                                                            <a href="#">
                                                                <img src="images/index/outland002.jpg" alt="" />
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href="#">
                                                                <img src="images/index/outland003.jpg" alt="" /></a>
                                                        </td>
                                                        <td>
                                                            <a href="#">
                                                                <img src="images/index/outland004.jpg" alt="" />
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href="#">
                                                                <img src="images/index/outland005.jpg" alt="" /></a>
                                                        </td>
                                                        <td>
                                                            <a href="#">
                                                                <img src="images/index/outland006.jpg" alt="" />
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr style="text-align: center; font-size: 14px">
                                                        <td>
                                                            <a href="#">香港一日游</a>
                                                        </td>
                                                        <td>
                                                            <a href="#">韩国一日游</a>
                                                        </td>
                                                        <td>
                                                            <a href="#">日本一日游</a>
                                                        </td>
                                                        <td>
                                                            <a href="#">凤凰一日游</a>
                                                        </td>
                                                        <td>
                                                            <a href="#">法国一日游</a>
                                                        </td>
                                                        <td>
                                                            <a href="#">内地一日游</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <div id="scrollcopy2" style="width: 100%;">
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <script type="text/javascript">
                            document.getElementById("scrollcopy2").innerHTML = document.getElementById("scrollcon2").innerHTML;
                            MyMar2 = setInterval(Marquee2, speed2);                            
                        </script>--%>
                    </div>
                </div>
            </div>
        </div>
        <!--OUTLAND AREA ENDS-->
        <!--CONTENT STARTS-->
        <div id="content">
            <!--CONTENT LEFT STARTS-->
            <div id="contentl">
                <div class="hot_sort">
                    <div class="hs_wrap">
                        <div class="hs_w710 clearfix">
                            <!--start hsCon-->
                            <div class="hs_con">
                                <div class="hs_top">
                                    <h2>
                                        周边旅游</h2>
                                    <a class="hs_more" href="#">更多<span style="font-family: 宋体">&gt;&gt;</span></a>
                                </div>
                                <div class="mb_10">
                                    <ol>
                                        <li class="hs_item"><a class="hs_name" href="#" title="【长城品质纯玩1日B】八达岭长城-定陵-鸟巢水立外景"
                                            rel="nofollow"><span class="f_0053aa">【长城品质纯玩1日B】八达岭长城-定陵-鸟巢水立外景</span></a><em class="hs_p"><b>260</b>元起</em></li>
                                        <li class="hs_item"><a class="hs_name" href="#" title="【故宫品质纯玩1日A】故宫-天坛-颐和园" rel="nofollow">
                                            <span class="f_0053aa">【故宫品质纯玩1日A】故宫-天坛-颐和园</span></a><em class="hs_p"><b>260</b>元起</em></li>
                                    </ol>
                                </div>
                            </div>
                            <!--end hsCon-->
                            <!--start hsCon-->
                            <div class="hs_con">
                                <div class="hs_top">
                                    <h2>
                                        国内旅游</h2>
                                    <a class="hs_more" href="#">更多<span style="font-family: 宋体">&gt;&gt;</span></a>
                                </div>
                                <div class="mb_10">
                                    <ol>
                                        <li class="hs_item"><a class="hs_name" href="#" title="【长城品质纯玩1日B】八达岭长城-定陵-鸟巢水立外景"
                                            rel="nofollow"><span class="f_0053aa">【长城品质纯玩1日B】八达岭长城-定陵-鸟巢水立外景</span></a><em class="hs_p"><b>260</b>元起</em></li>
                                        <li class="hs_item"><a class="hs_name" href="#" title="【故宫品质纯玩1日A】故宫-天坛-颐和园" rel="nofollow">
                                            <span class="f_0053aa">【故宫品质纯玩1日A】故宫-天坛-颐和园</span></a><em class="hs_p"><b>260</b>元起</em></li>
                                    </ol>
                                </div>
                            </div>
                            <!--end hsCon-->
                        </div>
                    </div>
                </div>
                <!-- banner-->
                <!-- banner-->
                <!--省内+景点   -->
                <div class="hot_sort">
                    <div class="hs_wrap">
                        <div class="hs_w710 clearfix">
                            <!--start hsCon-->
                            <div class="hs_con">
                                <div class="hs_top">
                                    <h2>
                                        出境旅游
                                    </h2>
                                    <a class="hs_more" href="#">更多<span style="font-family: 宋体">&gt;&gt;</span></a>
                                </div>
                                <div class="mb_10">
                                    <ol>
                                        <li class="hs_item"><a class="hs_name" href="#" title="爱自游--【丽江自由行】双飞四晚五日（德鑫酒店）"
                                            rel="nofollow"><span class="f_0053aa">爱自游--【丽江自由行】双飞四晚五日（德鑫酒店）</span></a><em class="hs_p"><b>2920</b>元起</em></li>
                                        <li class="hs_item"><a class="hs_name" href="#" title="爱自游--【丽江自由行】双飞四晚五日（古城天雨上院）"
                                            rel="nofollow"><span class="f_0053aa">爱自游--【丽江自由行】双飞四晚五日（古城天雨上院）</span></a><em class="hs_p"><b>3360</b>元起</em></li>
                                        <li class="hs_item"><a class="hs_name" href="#" title="爱自游--【丽江自由行】双飞四晚五日（古城竹苑）"
                                            rel="nofollow"><span class="f_0053aa">爱自游--【丽江自由行】双飞四晚五日（古城竹苑）</span></a><em class="hs_p"><b>3020</b>元起</em></li>
                                    </ol>
                                </div>
                            </div>
                            <!--end hsCon-->
                            <!--start hsCon-->
                            <div class="hs_con">
                                <div class="hs_top">
                                    <h2>
                                        私人定制
                                    </h2>
                                    <a class="hs_more" href="#">更多<span style="font-family: 宋体">&gt;&gt;</span></a>
                                </div>
                                <div class="mb_10">
                                    <ol>
                                        <li class="hs_item"><a class="hs_name" href="#" title="爱自游--【丽江自由行】双飞四晚五日（德鑫酒店）"
                                            rel="nofollow"><span class="f_0053aa">爱自游--【丽江自由行】双飞四晚五日（德鑫酒店）</span></a><em class="hs_p"><b>2920</b>元起</em></li>
                                        <li class="hs_item"><a class="hs_name" href="#" title="爱自游--【丽江自由行】双飞四晚五日（古城天雨上院）"
                                            rel="nofollow"><span class="f_0053aa">爱自游--【丽江自由行】双飞四晚五日（古城天雨上院）</span></a><em class="hs_p"><b>3360</b>元起</em></li>
                                        <li class="hs_item"><a class="hs_name" href="#" title="爱自游--【丽江自由行】双飞四晚五日（古城竹苑）"
                                            rel="nofollow"><span class="f_0053aa">爱自游--【丽江自由行】双飞四晚五日（古城竹苑）</span></a><em class="hs_p"><b>3020</b>元起</em></li>
                                    </ol>
                                </div>
                            </div>
                            <!--end hsCon-->
                        </div>
                    </div>
                </div>
                <!--省内+景点   -->
            </div>
            <!--CONTENT LEFT ENDS-->
            <!--CONTENT RIGHT STARTS-->
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var index = 0;
            var adtimer;
            var _wrap = $("#containe ol");
            var len = $("#containe ol li").length;
            if (len > 1) {
                $("#containe").hover(function () {
                    clearInterval(adtimer);
                },
        function () {
            adtimer = setInterval(function () {

                var _field = _wrap.find('li:first');
                var _h = _field.height();
                _field.animate({
                    marginTop: -_h + 'px'
                },
                500,
                function () {
                    _field.css('marginTop', 0).appendTo(_wrap);
                })

            },
            5000);
        }).trigger("mouseleave");
                function showImg(index) {
                    var Height = $("#containe").height();
                    $("#containe ol").stop().animate({
                        marginTop: -_h + 'px'
                    },
            1000);
                }

                $("#containe").mouseover(function () {
                    $("#containe .mouse_direction").css("display", "block");
                });
                $("#container").mouseout(function () {
                    $("#containe .mouse_direction").css("display", "none");
                });
            }

            $("#containe").find(".mouse_top").click(function () {
                var _field = _wrap.find('li:first');
                var last = _wrap.find('li:last');
                var _h = last.height();
                $("#containe ol").css('marginTop', -_h + "px");
                last.prependTo(_wrap);
                $("#containe ol").animate({
                    marginTop: 0
                },
        500,
        function () {
        })
            });
            $("#containe").find(".mouse_bottom").click(function () {
                var _field = _wrap.find('li:first');
                var _h = _field.height();
                _field.animate({
                    marginTop: -_h + 'px'
                },
        500,
        function () {
            _field.css('marginTop', 0).appendTo(_wrap);
        })
            });
        });
    </script>
    <!--marqueeleft end-->
    <div style="height: 10px; background-color: #fff; width: 100%; float: left;">
    </div>
</asp:Content>
