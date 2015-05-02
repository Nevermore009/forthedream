<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="Justgo8.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/category.css" rel="stylesheet" type="text/css" />
    <script src="js/lrscroll.js" type="text/javascript"></script>
    <script src="js/index_base.js" type="text/javascript"></script>
    <script src="js/saved_resource.js" type="text/javascript"></script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="container">
        <div id="welcome">
            <div id="welcomel">
                <!--旅游线路分类 -->                
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
                                                <a href="search.aspx?traveltype=<%#Eval("traveltypeid") %>">
                                                    <%#Eval("traveltypename") %></a>
                                                <img src="images/index/jiantou_03.gif" class="jiantou" alt="" />
                                            </h3>
                                            <div class="seccat">
                                                <asp:Repeater runat="server" ID="RepeaterHotArea">
                                                    <ItemTemplate>
                                                        <a href='search.aspx?traveltype=<%#Eval("traveltypeid") %>&areaid=<%#Eval("areaid") %>'><em>
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
                                                            <dt><a href="search.aspx?traveltype=<%#Eval("traveltypeid") %>&areid=<%#Eval("areaid") %>">
                                                                <%#Eval("areaname") %></a> </dt>
                                                            <dd>
                                                                <asp:Repeater ID="RepeaterCity" runat="server">
                                                                    <ItemTemplate>
                                                                        <%# Container.ItemIndex+1<=1?"":"<em>|</em>"%>
                                                                        <em><a href="search.aspx?traveltype=<%# DataBinder.Eval(((RepeaterItem)Container.Parent.Parent).DataItem, "traveltypeid")%>&areid=<%#Eval("areaid") %>&cityid=<%#Eval("cityid") %>">
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
                                                        <a href="#"></a></h3>
                                                    <p class="subItem-cat">
                                                        
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
                    }); $(".allsort .item").hoverForIE6({
                        delay: 150
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
                                            <a href="detail.aspx?id=<%#Eval("detailid") %>" <%# Container.ItemIndex+1<=1?"style='display:block;'":"style='display:none;'"%>>
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
        <div id="periphery">
            <div style="width: 185px; height: 30px; float: left; padding-top: 10px;">
                <img src="images/index/periphery.png" alt="" width="185" height="30" /></div>
            <div class="selectarea">
                <asp:Repeater runat="server" ID="repeaterhotperiphery">
                    <ItemTemplate>
                        <a href="search.aspx?traveltype=<%=Bll.BTravelType.Periphery %>&areaid=<%#Eval("areaid") %>" <%# Container.ItemIndex==0?"class='first'":"" %>>
                            <%#Eval("areaname") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="morearea">
                <a href="search.aspx?traveltype=<%=Bll.BTravelType.Periphery %>">更多&gt;&gt;</a></div>
            <div style="width: 100%; float: left; border-top: #489ea9 solid 2px; border-bottom: #c4c4c4 solid 1px;
                border-right: #c4c4c4 solid 1px; overflow: hidden;">
                <div id="peripheryleft">
                    <ul class="zz">
                        <asp:Repeater runat="server" ID="repeaterperiphery">
                            <ItemTemplate>
                                <li><a href="search.aspx?traveltype=<%=Bll.BTravelType.Periphery %>&areaid=<%#Eval("areaid") %>" target="_blank">
                                    <%#Eval("areaname") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div style="width: 815px; float: left;" id="peripherycontent">
                    <div class="hot_sort">
                        <div class="hs_wrap">
                            <div class="hs_w710 clearfix">
                                <div class="hs_con" style="width: 370px; margin-left: 15px;">
                                    <div class="mb_10">
                                        <ol>
                                            <asp:Repeater ID="repeaterperipheryshow1" runat="server">
                                                <ItemTemplate>
                                                    <li class="hs_item"><a class="hs_name" style="width: 280px;" href='detail.aspx?id=<%#Eval("id") %>'
                                                        title='<%#Eval("title") %>' rel="nofollow"><span class="f_0053aa">
                                                            【<%#Eval("description") %>】<%#Eval("title") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                            </asp:Repeater>
                                        </ol>
                                    </div>
                                </div>
                                <div class="hs_con" style="width: 370px; margin-left: 30px;">
                                    <div class="mb_10">
                                        <ol>
                                            <asp:Repeater ID="repeaterperipheryshow2" runat="server">
                                                <ItemTemplate>
                                                    <li class="hs_item"><a class="hs_name" style="width: 280px;" href='detail.aspx?id=<%#Eval("id") %>'
                                                        title='<%#Eval("title") %>' rel="nofollow"><span class="f_0053aa">
                                                            【<%#Eval("description") %>】<%#Eval("title") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                            </asp:Repeater>
                                        </ol>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>        
        <div id="zyx">
            <div style="width: 185px; height: 30px; float: left; padding-top: 10px;">
                <img src="images/index/zyx.png" alt="" width="185" height="30" /></div>
            <div class="selectarea">
                <asp:Repeater runat="server" ID="repeaterhotzyx">
                    <ItemTemplate>
                        <a href="search.aspx?traveltype=<%=Bll.BTravelType.Zyx %>&areaid=<%#Eval("areaid") %>" <%# Container.ItemIndex==0?"class='first'":"" %>>
                            <%#Eval("areaname") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="morearea">
                <a href="search.aspx?traveltype=<%=Bll.BTravelType.Zyx %>">更多&gt;&gt;</a></div>
            <div style="width: 100%; float: left; border-top: #489ea9 solid 2px; border-bottom: #c4c4c4 solid 1px;
                border-right: #c4c4c4 solid 1px; overflow: hidden;">
                <div id="zyxleft">
                    <ul class="zy">
                        <asp:Repeater runat="server" ID="repeaterzyx">
                            <ItemTemplate>
                                <li><a href="search.aspx?traveltype=<%=Bll.BTravelType.Zyx %>&areaid=<%#Eval("areaid") %>" target="_blank">
                                    <%#Eval("areaname") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div style="width: 815px; float: left;" id="zyxcontent">
                    <div class="hot_sort">
                        <div class="hs_wrap">
                            <div class="hs_w710 clearfix">
                                <div class="hs_con" style="width: 370px; margin-left: 15px;">
                                    <div class="mb_10">
                                        <ol>
                                            <asp:Repeater ID="repeaterzyxshow1" runat="server">
                                                <ItemTemplate>
                                                    <li class="hs_item"><a class="hs_name" style="width: 280px;" href='detail.aspx?id=<%#Eval("id") %>'
                                                        title='<%#Eval("title") %>' rel="nofollow"><span class="f_0053aa">
                                                            【<%#Eval("description") %>】<%#Eval("title") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                            </asp:Repeater>
                                        </ol>
                                    </div>
                                </div>
                                <div class="hs_con" style="width: 370px; margin-left: 30px;">
                                    <div class="mb_10">
                                        <ol>
                                            <asp:Repeater ID="repeaterzyxshow2" runat="server">
                                                <ItemTemplate>
                                                    <li class="hs_item"><a class="hs_name" style="width: 280px;" href='detail.aspx?id=<%#Eval("id") %>'
                                                        title='<%#Eval("title") %>' rel="nofollow"><span class="f_0053aa">
                                                            【<%#Eval("description") %>】<%#Eval("title") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                            </asp:Repeater>
                                        </ol>
                                    </div>
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
                <img src="images/index/inland.png" alt="" width="185" height="30" /></div>
            <div class="selectarea">
                <asp:Repeater runat="server" ID="RepeaterHotInland">
                    <ItemTemplate>
                        <a href="search.aspx?traveltype=<%=Bll.BTravelType.Inland %>&areaid=<%#Eval("areaid") %>" <%# Container.ItemIndex==0?"class='first'":"" %>>
                            <%#Eval("areaname") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="morearea">
                <a href="search.aspx?traveltype=<%=Bll.BTravelType.Inland %>">更多&gt;&gt;</a></div>
            <div style="width: 100%; float: left; border-top: #489ea9 solid 2px; border-bottom: #c4c4c4 solid 1px;
                border-right: #c4c4c4 solid 1px; overflow: hidden;">
                <div id="inlandleft">
                    <ul class="gn">
                        <asp:Repeater runat="server" ID="RepeaterInland">
                            <ItemTemplate>
                                <li><a href="search.aspx?traveltype=<%=Bll.BTravelType.Inland %>&areaid=<%#Eval("areaid") %>" target="_blank">
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
                                                            【<%#Eval("description") %>】<%#Eval("title") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
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
                                                           【<%#Eval("description") %>】<%#Eval("title") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
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
                <img alt="" src="images/index/outland.png" width="185" height="30" /></div>
            <div class="selectarea">
                <asp:Repeater runat="server" ID="RepeaterHotOutland">
                    <ItemTemplate>
                        <a href="search.aspx?traveltype=<%=Bll.BTravelType.Outland %>&areaid=<%#Eval("areaid") %>" target="_blank" <%# Container.ItemIndex==0?"class='first'":""%>>
                            <%#Eval("areaname") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="morearea">
                <a href="search.aspx?traveltype=<%=Bll.BTravelType.Outland %>" style="font-family: 宋体">更多&gt;&gt;</a></div>
            <div id="hidden" style="width: 100%; float: left; border-top: #438544 solid 2px;
                border-bottom: #c4c4c4 solid 1px; border-right: #c4c4c4 solid 1px; overflow: hidden;">
                <div id="outlandleft">
                    <ul class="cj">
                        <asp:Repeater runat="server" ID="RepeaterOutland">
                            <ItemTemplate>
                                <li><a href="search.aspx?traveltype=<%=Bll.BTravelType.Outland %>&areaid=<%#Eval("areaid") %>" target="_blank">
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
                                                                【<%#Eval("description") %>】<%#Eval("title") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
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
                                                                【<%#Eval("description") %>】<%#Eval("title") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
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
            <div id="contentl" style="display: none">
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
                                        <asp:Repeater ID="repeaterperipheryshow" runat="server">
                                            <ItemTemplate>
                                                <li class="hs_item"><a class="hs_name" href='detail.aspx?id=<%#Eval("id") %>' title='<%#Eval("title") %>'
                                                    rel="nofollow"><span class="f_0053aa">
                                                        <%#Eval("description") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                        </asp:Repeater>
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
                                        <asp:Repeater ID="repeaterinlandshow" runat="server">
                                            <ItemTemplate>
                                                <li class="hs_item"><a class="hs_name" href='detail.aspx?id=<%#Eval("id") %>' title='<%#Eval("title") %>'
                                                    rel="nofollow"><span class="f_0053aa">
                                                        <%#Eval("description") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                        </asp:Repeater>
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
                                        <asp:Repeater ID="repeateroutlandshow" runat="server">
                                            <ItemTemplate>
                                                <li class="hs_item"><a class="hs_name" href='detail.aspx?id=<%#Eval("id") %>' title='<%#Eval("title") %>'
                                                    rel="nofollow"><span class="f_0053aa">
                                                        <%#Eval("description") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                        </asp:Repeater>
                                    </ol>
                                </div>
                            </div>
                            <!--end hsCon-->
                            <!--start hsCon-->
                            <div class="hs_con">
                                <div class="hs_top">
                                    <h2>
                                        团队定制
                                    </h2>
                                    <a class="hs_more" href="#">更多<span style="font-family: 宋体">&gt;&gt;</span></a>
                                </div>
                                <div class="mb_10">
                                    <ol>
                                        <asp:Repeater ID="repeatercustomize" runat="server">
                                            <ItemTemplate>
                                                <li class="hs_item"><a class="hs_name" href='detail.aspx?id=<%#Eval("id") %>' title='<%#Eval("title") %>'
                                                    rel="nofollow"><span class="f_0053aa">
                                                        <%#Eval("description") %></span></a><em class="hs_p"><b><%#Eval("adultprice") %></b>元起</em></li></ItemTemplate>
                                        </asp:Repeater>
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
