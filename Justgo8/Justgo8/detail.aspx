<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="detail.aspx.cs" Inherits="Justgo8.detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/line.css" />
    <link href="css/datepicker.css" rel="stylesheet" type="text/css" />
    <link href="css/WdatePicker.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/mF_games_tb.css" />
    <link rel="stylesheet" href="css/15.css" type="text/css" charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="css/m-front-icon.css" />
    <link rel="stylesheet" type="text/css" href="css/m-front-mess.css" />
    <link rel="stylesheet" type="text/css" href="css/m-front-invite.css" />
    <link type="text/css" rel="stylesheet" href="css/m-webim-lite.css" />
    <link href="css/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .aa
        {
            position: fixed;
            top: 0px;
            _position: absolute;
            _bottom: auto;
            _top: expression(eval(document.documentElement.scrollTop-185));
        }
        .mF_games_tb_myFocusShow *
        {
            margin: 0;
            padding: 0;
            border: 0;
            list-style: none;
        }
        .mF_games_tb_myFocusShow
        {
            position: relative;
            width: 400px;
            height: 300px;
            overflow: hidden;
            font: 12px/1.5 Verdana;
            text-align: left;
            background: #fff;
            visibility: visible !important;
        }
        .mF_games_tb_myFocusShow .pic
        {
            position: relative;
            width: 400px;
            height: 300px;
            overflow: hidden;
        }
        .mF_games_tb_myFocusShow .txt li
        {
            width: 400px;
            height: defaultpx !important;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript" src="js/myfocus-2.0.4.min.js"></script>
    <%--<script src="js/lineshow.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            if ($('#myFocusShow a').length > 0) {
                $('#myFocusShow').myFocus({ //线路详情页：幻灯片
                    pattern: 'mF_games_tb', //风格应用的名称
                    time: 3, //切换时间间隔(秒)
                    trigger: 'click', //触发切换模式:'click'(点击)/'mouseover'(悬停)
                    width: 400, //设置图片区域宽度(像素)
                    height: 300, //设置图片区域高度(像素)
                    txtHeight: 'default', //文字层高度设置(像素),'default'为默认高度，0为隐藏
                    loadIMGTimeout: 0 //图片的最长等待时间(Loading画面时间)(单位秒,0表示不等待直接播放)
                });
            }
            var DT = $('#Details_nav').offset().top;
            $('#Details_nav>li').click(function () {
                var s = $('#Details_nav>li').index(this);
                $(window).scrollTop($('.mainCon>.ui-tabs-panel:eq(' + s + ')').offset().top - 30);
            });
            $(window).scroll(function () {
                var wt = $(window).scrollTop(), l = $('.mainCon>.ui-tabs-panel'), s = l.length - 1;
                if (wt < DT || wt >= l.last().offset().top + l.last().height() + 30) {
                    $('#Details_nav').removeClass('aa');
                    $('#Details_nav>li:first').addClass('ui-tabs-selected').siblings().removeClass('ui-tabs-selected');
                } else {
                    $('#Details_nav').addClass('aa');
                    for (var i = 0; i < s; i++) {
                        if (wt >= parseInt(l.eq(i).offset().top - 30) && wt < parseInt(l.eq(i + 1).offset().top - 30)) {
                            s = i;
                            break;
                        }
                    }
                    $('#Details_nav>li:eq(' + s + ')').addClass('ui-tabs-selected').siblings().removeClass('ui-tabs-selected');
                }
            });
        });
    </script>
    <script type="text/javascript" src="js/mF_games_tb.js"></script>
    <script type="text/javascript" charset="UTF-8" src="js/bw.js"></script>
    <script src="js/WdatePicker.js" type="text/javascript"></script>
    <script src="js/calendar.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--页头开始-->
    <!--页头结束-->
    <!--主体开始-->
    <div id="main">
        <div class="wrapper show clearfix">
            <div class="crumbs">
                <a href="index.aspx" title="首页">首页</a> -&gt;
                <asp:Label runat="server" ID="lbtitle">  </asp:Label>
            </div>
            <div class="hd">
                <h1 class="title" id="attr">
                    <b>
                        <asp:Label runat="server" ID="lbtitle2">  </asp:Label>
                    </b><i class="lineIco tuiJian" style="display: none">推荐</i> <i class="lineIco teJia"
                        style="display: none">特价</i> <i class="lineIco reMai" style="display: none">热卖</i>
                    <i class="lineIco xinPin" style="display: none">新品</i> <i class="lineIco tuanGou"
                        style="display: none">团购</i>
                </h1>
                <div class="baseView clearfix">
                    <div class="picShow">
                        <div class="sliderBox">
                            <div id="myFocusShow" class=" mF_games_tb mF_games_tb_myFocusShow" style="height: 386px;">
                                <div class="pic">
                                    <ul>
                                        <asp:Repeater runat="server" ID="repeaterdetailpic">
                                            <ItemTemplate>
                                                <li style="display: <%# Container.ItemIndex+1<1?"block":"none"%>; opacity: 1;"><a
                                                    href="#">
                                                    <img src="<%#Eval("pic") %>" width="400" height="300" alt="" title="" text="<%#Eval("remark") %>" /></a></li></ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="info clearfix">
                        <div class="profile">
                            <ul class="clearfix">
                                <li>
                                    <label>
                                        门市价格：</label><em class="price del">¥<asp:Label runat="server" ID="lbgeneralprice"
                                            Text='<%#Eval("generalprice")%>'></asp:Label></em></li>
                                <li>
                                    <label>
                                        出发城市：</label>长沙</li>
                                <li>
                                    <label>
                                        预订须知：</label>请提前<em class="price">3</em>天预订</li>
                                <li>
                                    <label>
                                        出发日期：</label><asp:Label runat="server" ID="lbdeparturetime" Text=''></asp:Label></li>
                                <%--<li>
                                    <label>
                                        往返交通：</label>汽车</li>    
                                <li>
                                    <label>
                                        满 意 度：</label><em>100%</em> <a href="javascript:void(0);" style="color: #C00;">[已有<em>0</em>人点评]</a></li>--%>
                            </ul>
                            <%--<div class="tuanIco sIco0">
                                &nbsp;</div>--%>
                        </div>
                        <div class="choose clearfix">
                            <dl class="clearfix">
                                <dt>出发日期：</dt>
                                <dd id="startdate">
                                    <input type="text" style="ime-mode: disabled; border: 1px solid #C3C5C4; width: 130px;"
                                        readonly="readonly" id="departuretime" name="departuretime" class="Wdate da"
                                        onclick="WdatePicker({minDate:'%y-%M-{%d+1}',maxDate:'{%y+2}-%M-%d'})" onfocus="this.style.imeMode='inactive'"
                                        value="" /></dd>
                            </dl>
                            <div class="person" id="person">
                                <table width="100%" cellspacing="0">
                                    <tbody>
                                        <tr>
                                            <th width="100px">
                                                类型
                                            </th>
                                            <th width="200px">
                                                价格
                                            </th>
                                            <th>
                                                人数
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="tips" style="z-index: 100">
                                                    <i class="help">成人</i>
                                                    <div class="tipsCon">
                                                        <div class="tipsInner">
                                                            <div class="tipsText">
                                                                <p>
                                                                    成人说明：</p>
                                                            </div>
                                                            <small>&nbsp;</small>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td id="c1_price" class="cPrice">
                                                ¥<asp:Label runat="server" ID="lbadultprice" Text='<%#Eval("adultprice")%>'>
                                                </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtadultnum" Style="height: 25px; border: 1px solid #ccc"
                                                    Text="1"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ErrorMessage="*" ValidationGroup="sss" ControlToValidate="txtadultnum"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="tips" style="z-index: 99">
                                                    <i class="help">儿童</i>
                                                    <div class="tipsCon">
                                                        <div class="tipsInner">
                                                            <div class="tipsText">
                                                                <p>
                                                                    儿童说明：</p>
                                                            </div>
                                                            <small>&nbsp;</small>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td id="c2_price" class="cPrice">
                                                ¥<asp:Label runat="server" ID="lbchildprice" Text='<%#Eval("childprice") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtchildnum" Style="height: 25px; border: 1px solid #ccc"
                                                    Text="1"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ErrorMessage="*" ValidationGroup="sss" ControlToValidate="txtchildnum"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div id="bxmsg" style="display: none;">
                                </div>
                            </div>
                            <div class="btns">
                                <center>
                                    <asp:Button runat="server" ID="btnadd" Text="预订" Height="28px" Width="110px" BackColor="SkyBlue"
                                        ValidationGroup="sss" OnClick="btnadd_Click" /></center>
                            </div>
                            <dl class="clearfix">
                                <dd>
                                    <span style="display: none">温馨提示：预定成功后即成为我公司网站会员，手机号码将成为下次预定和登陆的会员账号。</span></dd>
                            </dl>
                        </div>
                    </div>
                </div>
            </div>
            <div class="showBox reason">
                <h2 class="hd">
                    <b>行程特色</b></h2>
                <div class="content reset clearfix">
                    <div runat="server" id="divfeatures">
                    </div>
                </div>
            </div>
            <div class="mainCon clearfix">
                <ul class="ui-tabs-nav clearfix" id="Details_nav">
                    <li class="first ui-tabs-selected"><a href="javascript:;">具体行程</a></li>
                    <li><a href="javascript:;">费用说明</a></li>
                    <li><a href="javascript:;">服务标准</a></li>
                    <li><a href="javascript:;">友情提示</a></li>
                    <li><a href="javascript:;">预订流程</a></li>
                </ul>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <span>
                            <%--<a href="#" class="print">打印行程</a> <a
                            href="#" class="download">下载行程</a>--%></span><b class="route">具体行程</b></h2>
                    <div class="content routes clearfix" id="TravelContainer">
                        <div runat="server" id="divjourney">
                        </div>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="fare">费用说明</b></h2>
                    <div class="content fees clearfix" id="pricelist">
                        <div class="ui-tabs-panel" p_name="常规团" p_id="44" rackrate="110" tqtype="0">
                            <div class="theme">
                                <b>费用包含</b></div>
                            <div class="reset clearfix">
                                <div runat="server" id="divbillinclude">
                                </div>
                            </div>
                            <div class="theme">
                                <b>费用不包含</b></div>
                            <div class="reset clearfix">
                                <div runat="server" id="divbillbeside">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="note">服务标准</b></h2>
                    <div class="content">
                        <div class="reset clearfix">
                            <div runat="server" id="divservicestandard">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="tips">友情提示</b></h2>
                    <div class="content">
                        <div class="reset clearfix">
                            <div runat="server" id="divpresentation">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="process">预订流程</b></h2>
                    <div class="content process clearfix">
                        <div runat="server" id="divcontact">
                        </div>
                    </div>
                </div>
            </div>
            <div class="showBox relative">
            </div>
        </div>
    </div>
    <!--主体结束-->
    <!--页脚开始-->
    <!--页脚结束-->
    <input name="hidelineid" id="hidelineid" type="hidden" value="41" />
    <div id="citypiclist" style="display: none">
    </div>
    <!--页脚脚本开始-->
    <div id="footerJs">
        <%--<script type="text/javascript" src="js/jquery.js"></script>--%>
        <script type="text/javascript" src="js/scrollshow.js"></script>
        <script type="text/javascript" src="js/jquery.vticker.js"></script>
        <script type="text/javascript" src="js/jquery.tinyscrollbar.min.js"></script>
        <script type="text/javascript" src="js/Calendar2.js"></script>
        <script type="text/javascript" src="js/jquery.validate.js"></script>
        <script type="text/javascript" src="js/jquery.validate.check.js"></script>
        <script type="text/javascript" src="js/jquery.vticker(1).js"></script>
        <script type="text/javascript">
            $(function () {
                $('#optChange dd[defaultkey="线路关键词"]').click();
            });
            link['linebooking'] = 'http://www.cts1.cn/order/line/booking.aspx?id=41';
            link['linebooking'] += link['linebooking'].indexOf('?') != -1 ? '&' : '?';
            $('.benefit .content').vTicker({ //网上预订专属优惠滚动
                speed: 500, //滚动速度，单位毫秒。
                pause: 4000, //暂停时间，就是滚动一条之后停留的时间，单位毫秒。
                showItems: 2, //显示内容的条数。
                animation: 'fade', //动画效果，默认是fade，淡出。
                mousePause: true, //鼠标移动到内容上是否暂停滚动，默认为true。
                height: 44, //滚动内容的高度。
                direction: 'up' //滚动的方向，默认为up向上，down则为向下滚动。
            });
        </script>
    </div>
    <!--页脚脚本结束-->
</asp:Content>
