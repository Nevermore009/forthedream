<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="detail.aspx.cs" Inherits="Justgo8.detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/common.css" />
    <link rel="stylesheet" type="text/css" href="css/line.css" />
    <link href="css/datepicker.css" rel="stylesheet" type="text/css" />
    <link href="css/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="js/WdatePicker.js" type="text/javascript"></script>
    <script src="js/calendar.js" type="text/javascript"></script>
    <style type="text/css">
        .aa
        {
            position: fixed;
            top: 0px;
            _position: absolute;
            _bottom: auto;
            _top: expression(eval(document.documentElement.scrollTop-185));
        }
    </style>
    <link rel="stylesheet" href="css/mF_games_tb.css" />
    <script type="text/javascript" src="js/mF_games_tb.js"></script>
    <script type="text/javascript" charset="UTF-8" src="js/bw.js"></script>
    <link rel="stylesheet" href="css/15.css" type="text/css" charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="css/m-front-icon.css" />
    <link rel="stylesheet" type="text/css" href="css/m-front-mess.css" />
    <link rel="stylesheet" type="text/css" href="css/m-front-invite.css" />
    <link type="text/css" rel="stylesheet" href="css/m-webim-lite.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--页头开始-->
    <!--页头结束-->
    <!--主体开始-->
    <div id="main">
        <div class="wrapper show clearfix">
            <div class="crumbs">
                <a href="index.aspx" title="首页">首页</a> -&gt;
                <asp:Label runat="server" ID="lbtitle" Text='<%#Eval("title")%>'>  </asp:Label>
            </div>
            <div class="hd">
                <h1 class="title" id="attr">
                    <b>
                        <%#Eval("title") %></b> <i class="lineIco tuiJian" style="display: ">推荐</i>
                    <i class="lineIco teJia" style="display: none">特价</i> <i class="lineIco reMai" style="display: ">
                        热卖</i> <i class="lineIco xinPin" style="display: none">新品</i> <i class="lineIco tuanGou"
                            style="display: ">团购</i>
                </h1>
                <div class="baseView clearfix">
                    <div class="picShow">
                        <div class="sliderBox">
                            <div class="mF_games_tb_wrap">
                                <div id="myFocusShow" class=" mF_games_tb mF_games_tb_myFocusShow" style="height: 386px;">
                                    <div class="pic">
                                        <ul>
                                            <li style="display: none; opacity: 1;"><a href="#" title="坡子街" target="_blank">
                                                <img src="#" width="400" height="300" alt="坡子街" text=""></a></li>
                                            <li style="display: block; opacity: 1;"><a href="#" title="湖南大学" target="_blank">
                                                <img src="#" width="400" height="300" alt="湖南大学" text=""></a></li>
                                            <li style="display: none; opacity: 1;"><a href="#" title="火宫殿" target="_blank">
                                                <img src="#" width="400" height="300" alt="火宫殿" text=""></a></li>
                                        </ul>
                                    </div>
                                    <div class="txt">
                                        <ul>
                                            <li style="bottom: 86px; display: none;"><a href="#" title="坡子街" target="_blank">坡子街</a><p>
                                            </p>
                                                <b></b></li>
                                            <li style="bottom: 86px; display: block;"><a href="#" title="湖南大学" target="_blank">湖南大学</a><p>
                                            </p>
                                                <b></b></li>
                                        </ul>
                                    </div>
                                    <div class="thumb" style="width: 368px; height: 86px; left: 16px;">
                                        <ul style="width: 276px; left: 0px;">
                                            <li class="" style="width: 92px;"><a>
                                                <img src="#" style="height: 60px;"></a><b></b></li><li class="current" style="width: 92px;">
                                                    <a>
                                                        <img src="#" style="height: 60px;"></a><b></b></li><li class="" style="width: 92px;">
                                                            <a>
                                                                <img src="#" style="height: 60px;"></a><b></b></li></ul>
                                    </div>
                                    <div class="prev">
                                        <a href="javascript:;">‹</a></div>
                                    <div class="next">
                                        <a href="javascript:;">›</a></div>
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
                                        出发日期：</label><%#Eval("departuretime") %></li>
                                <%--<li>
                                    <label>
                                        往返交通：</label>汽车</li>    
                                <li>
                                    <label>
                                        满 意 度：</label><em>100%</em> <a href="javascript:void(0);" style="color: #C00;">[已有<em>0</em>人点评]</a></li>--%>
                            </ul>
                            <div class="tuanIco sIco0">
                                &nbsp;</div>
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
                                                <asp:TextBox runat="server" ID="txtadultnum" Style="height: 25px; border: 1px solid #ccc"  Text="1"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="sss"
                                                    ControlToValidate="txtadultnum"></asp:RequiredFieldValidator>
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
                                                <asp:TextBox runat="server" ID="txtchildnum" Style="height: 25px; border: 1px solid #ccc" Text="1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                    ValidationGroup="sss" ControlToValidate="txtchildnum"></asp:RequiredFieldValidator>
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
                    <div runat="server" id="lbfeatures">
                      </div>
                </div>
            </div>
            <div class="mainCon clearfix">
                <ul class="ui-tabs-nav clearfix" id="Details_nav">
                    <li class="first ui-tabs-selected"><a href="javascript:;">出发班期</a></li>
                    <li class=""><a href="javascript:;">参考行程</a></li>
                    <li><a href="javascript:;">费用说明</a></li>
                    <li><a href="javascript:;">预订须知</a></li>
                    <li><a href="javascript:;">温馨提示</a></li>
                    <li><a href="javascript:;">预订流程</a></li>
                    <li><a href="javascript:;">线路点评</a></li>
                    <li><a href="javascript:;">在线咨询</a></li>
                </ul>                
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <span>
                            <%--<a href="http://www.cts1.cn/line/print.aspx?id=41" class="print">打印行程</a> <a
                            href="http://www.cts1.cn/line/down.aspx?id=41" class="download">下载行程</a>--%></span><b
                                class="route">参考行程</b></h2>
                    <div class="content routes clearfix" id="TravelContainer">
                        <div class="plugins_xianlu_xingcheng_1">
                            <span style="font-size: 16px;"><strong>第1天</strong> ：游玩市博物馆、天心阁、爱晚亭、橘子洲、简牍博物馆等。 <strong>
                                交通：</strong> 空调大巴 <strong>用餐：</strong>自理</span></div>
                        <div class="plugins_xianlu_xingcheng_2">
                            <div>
                                <span style="font-size: 16px;">上午：在约定时间内（07:10-08:10）到约定的宾馆/超市/社区上门接（二环内免费接），或07:50分自行到长沙火车站对面的【三九楚云大酒店】门口集合，08:20发团（100分钟左右车程），参观以下景区景点：</span></div>
                            <div>
                                <span style="font-size: 16px;"></span>
                            </div>
                            <div>
                                <span style="font-size: 16px;">1、【<span style="color: #ff0000;"><strong>天心阁</strong></span>】：（门票32元已包含，游览60分钟左右）在长沙市中心地区东南角上，是长沙古城的一座城楼。为长沙重要名胜，也是长沙仅存的古城标志。具体方位为长沙市中心东南角、城南路与天心路交会之处的古城墙内。楼阁三层，建筑面积846平方米，碧瓦飞檐，朱梁画栋，阁与古城墙及天心公园其它建筑巧妙融为一体。基址占着城区最高地势，加之坐落在30多米高的城垣之上，近有妙高峰为伴。其名始见于明末俞仪《天心阁眺望》一诗中，至清乾隆年间重修天心阁，“极城南之盛概萃于斯阁”，盛名于世且成为文人墨客雅集吟咏之所。<br>
                                    <br>
                                    2、【<span style="color: #ff0000;"><strong>简牍博物馆</strong></span>】：（免费景点，游览30分钟左右）长沙简牍博物馆是目前世界唯一一座集简牍收藏、保护、整理、研究和陈列展示于一体的新型现代化专题博物馆，也是长沙一个重要的文化景点和对外开放窗口。本馆占地30亩，主体建筑面积14100平方米，其中展厅面积6000平方米，库房面积3000平方米。本馆简牍藏品主要为1996年出土的14万枚三国孙吴时期纪年简牍和2003年发现的2万余枚西汉初年纪年简牍，另外，青铜、漆木、书画、金银等其它藏品约3500件。<br>
                                    <br>
                                </span>
                                <div>
                                    <span style="font-size: 16px;">3、【<span style="color: #ff0000;"><strong>长沙市博物馆</strong></span>】：（免费景点、游览40分钟左右）是改革开放后在原中共湘区委员会旧址纪念馆基础上修建的综合性的地志博物馆，占地面积4.2万平方米，建筑面积
                                        1.2万平方米。该馆收藏2万余件反映长沙历史和近现代革命史的珍贵文物。其中，商代青铜大铙、青铜编铙、错金银龙凤纹铜盒、蜻蜓眼琉璃珠、带鞘铜剑、曹僎玛璃印被誉为稀世之珍。
                                    </span>
                                </div>
                            </div>
                            <div>
                                <span style="font-size: 16px;"></span>
                            </div>
                            <div>
                                <span style="font-size: 16px;">4、【<span style="color: #ff0000;"><strong>岳麓山爱晚亭</strong></span>】：（免费景点，游览90分钟左右）中国四大名亭之一，始建于1792年，与北京陶然亭、滁州醉翁亭、杭州湖心亭并称为中国古建四大名亭，享誉中外，是岳麓山风景名胜区重要观光点，是革命活动胜地，为省级文物保护单位。亭形为重檐八柱，琉璃碧瓦，亭角飞翘，自远处观之似凌空欲飞状。内为丹漆园柱，外檐四石柱为花岗岩，亭中彩绘藻井，东西两面亭棂悬以红底鎏金“爱晚亭”额，是由当时的湖南大学校长李达专函请毛泽东所书手迹而制；</span></div>
                            <div>
                                <br>
                                <span style="font-size: 16px;">5、【<span style="color: #ff0000;"><strong>橘子洲</strong></span>】：（免费景点，游览90分钟左右）一九八二年七月，正式开放的橘洲公园，现占地十四公顷，有毛泽东诗词碑、颂橘亭、枕江亭、揽岳亭等景点。公园以成片桔园为绿化主体，杂檀名贵花木，风景秀丽，环境清幽，融绿化、美化、香化、净化为一体，观山、观水、观桔、观花各有千秋。橘洲，自古以来便是湖南省著名的旅游胜地。古潇湘八景之一的“江天暮雪”就在这里。宋肖大经的《肖夏诗》誉称橘洲为“小蓬莱”，名胜水陆寺中的“拱极楼中，五六月间无暑气；潇湘江上，二三更里有渔歌”的名联至今仍脍炙人口。（电瓶车20元/人自理）。</span></div>
                            <div>
                                <span style="font-size: 16px;"></span>
                            </div>
                            <div>
                                <span style="font-size: 16px;">游览完以上景点后，回长沙市区；16:30左右在长沙火车站散团（从长沙火车站到长沙黄花机场需50分钟左右，长沙火车南站（高铁站）需40分钟左右，请妥善安排返程交通）。<br>
                                </span>
                            </div>
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
                                <div class="plugins_xianlu_other_2">
                                    <span style="font-size: 16px;"><strong>1、景点门票：</strong>含以上行程内所列景点的门票；<br>
                                        <strong>2、所含保险：</strong>含旅行社责任险、景区意外险（如需购买个人人身意外险，需自费10元/位）；<br>
                                        <strong>3、所含交通：</strong>含空调旅游车，散拼用车，保证每人一正座；<br>
                                        <strong>4、导游服务：</strong>含优秀国证导游全程贴心服务费用；<br>
                                        <strong>5、儿童标准：</strong>1.2-1.4米的未成年人，费用仅含车费、导游服务费、旅行社责任险，若产生门票等其他费用需自理；</span></div>
                            </div>
                            <div class="theme">
                                <b>费用不包含</b></div>
                            <div class="reset clearfix">
                                <span style="font-size: 16px;"><strong>1、散客用餐：</strong>以上报价不包含餐费，游客可自行选择：<br>
                                    A、单独开餐，游客可根据个人喜好自主决定，自由选择风味特色点菜；<br>
                                    B、由旅行社或导游推荐安排包餐，标准为20元/人/餐（10人/桌，九菜一汤，不足十人，保证每人一菜）；<br>
                                    <strong>2、景区索道：</strong>景区内缆车、索道、观光小火车、电梯等代步工具费用，如：岳麓山上山电瓶车20元（可不消费，步行参观）；<br>
                                    <strong>3、大交通费：</strong>不含游客所在地区往返本线路出发城市的交通费用（本公司可免费代订返程交通票）；<br>
                                    <strong>4、其他费用</strong>：个人的消费、自费项目及因不可抗力因素所产生的额外费用等（旅游购物时要谨慎，注意识别假冒伪劣商品，不受任何人左右，自己想好再买）；</span></div>
                        </div>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="note">预订须知</b></h2>
                    <div class="content">
                        <div class="reset clearfix">
                            <span style="font-size: 16px;"><span style="color: #ff0000;"><strong>特别说明：</strong></span><br>
                                1、本线路不含岳麓书院，如需参观岳麓书院，请在预订时说明，我们可为您安排另外一条在本线路基础上增加岳麓书院的线路，团费为160元/人。<br>
                                2、本线路为全国大散拼线路，全市旅游社散客拼团。<br>
                                <br>
                            </span><span style="font-size: 16px; color: #ff0000;"><strong>其他说明：<br>
                            </strong></span>
                            <div class="plugins_xianlu_other_2">
                                <span style="font-size: 16px;"><strong>1、交 通：</strong><br>
                                    （1）合同一经签订且付全款，团队机票、列车票、船票即为出票，不得更改、签转、退票。<br>
                                    （2）飞行时间、车程时间、船程时间以当日实际所用时间为准。<br>
                                    （3）本产品如因淡季或收客人数较少，有可能与相近方向的发班线路拼车出游，届时请游客见谅。<br>
                                    <strong>2、住 宿：</strong><br>
                                    （1）以上报价不含住宿，如需安排住宿，可联系客服人员或直接在线预订酒店，按2人入住1间房核算，如出现单男单女，尽量安排该客人与其他同性别团友拼房；如不愿拼房或未能拼房，请补齐单房差以享用单人房间。<br>
                                    （2）出于环保考虑，所有酒店均不提供一次性卫生用品，请您自行携带好相关用品。<br>
                                    <strong>3、团队用餐：</strong><br>
                                    以上报价不含用餐，如需增加团餐，标准为20元/人/正餐：十人一桌，九菜一汤，人数不足十人时，在每人用餐标准不变的前提下调整餐食的分量。<br>
                                    <strong>4、游 览：</strong><br>
                                    （1）景点游览、自由活动、购物店停留的时间以当天实际游览为准。<br>
                                    （2）行程中需自理门票和当地导游推荐项目，请自愿选择参加。<br>
                                    （3）请您仔细阅读本行程，根据自身条件选择适合自己的旅游线路，出游过程中，如因身体健康等自身原因需放弃部分行程的，或游客要求放弃部分住宿、交通的，均视为自愿放弃，已发生费用不予退还，放弃行程期间的人身安全由旅游者自行负责。<br>
                                    （4）团队游览中不允许擅自离团（自由活动除外），中途离团视同游客违约，按照合同总金额的20%赔付旅行社，由此造成未参加行程内景点、用餐、房、车等费用不退，旅行社亦不承担游客离团时发生意外的责任。<br>
                                    （5）如遇台风、暴雪等不可抗因素导致无法按约定行程游览，行程变更后增加或减少的费用按旅行社团队操作实际发生的费用结算。<br>
                                    （6）出游过程中，如产生退费情况，以退费项目旅行社折扣价为依据，均不以挂牌价为准。<br>
                                    <strong>5、购 物：</strong><br>
                                    本线路<span style="font-family: Tahoma, arial, 宋体, sans-serif; color: #404040; line-height: 18px">市内进店购物0次</span>。【在当地购物时请慎重考虑，把握好质量与价格，务必索要发票】。<br>
                                </span>
                            </div>
                            <div class="plugins_xianlu_other_1">
                                <span style="font-size: 16px;">差价说明：</span></div>
                            <div class="plugins_xianlu_other_2">
                                <span style="font-size: 16px;">（1）如遇国家政策性调整门票、交通价格等，按调整后的实际价格结算。<br>
                                    （2）赠送项目因航班、天气等不可抗因素导致不能赠送的，费用不退。<br>
                                    （3）景点门票为旅行社折扣价，如持优待证件（如老年证、军官证、教师证等）产生折扣退费的，按实际差额退还。</span></div>
                            <div class="plugins_xianlu_other_1">
                                <span style="font-size: 16px;">出团通知：</span></div>
                            <div class="plugins_xianlu_other_2">
                                <span style="font-size: 16px;">出团通知最晚于出团前1天晚上发送，若能提前确定，我们将会第一时间通知您。</span></div>
                            <div class="plugins_xianlu_other_1">
                                <span style="font-size: 16px;">意见反馈：</span></div>
                            <div class="plugins_xianlu_other_2">
                                <span style="font-size: 16px;">请配合导游如实填写当地的意见单，不填或虚填者归来后投诉将无法受理。</span></div>
                            <div class="plugins_xianlu_other_1">
                                &nbsp;</div>
                        </div>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="tips">温馨提示</b></h2>
                    <div class="content">
                        <div class="reset clearfix">
                            <div class="plugins_xianlu_other_2">
                                <div class="plugins_xianlu_other_2">
                                    <span style="font-size: 16px;"><strong>病患者、孕妇及行动不便者预订提示</strong><br>
                                        为了确保旅游顺利出行，防止旅途中发生人身意外伤害事故，请旅游者在出行前做一次必要的身体检查，如存在下列情况，请遵医嘱：<br>
                                        （1）传染性疾病患者，如传染性肝炎、活动期肺结核、伤寒等传染病人；<br>
                                        （2）心血管疾病患者，如严重高血压、心功能不全、心肌缺氧、心肌梗塞等病人；<br>
                                        （3）脑血管疾病患者，如脑栓塞、脑出血、脑肿瘤等病人；<br>
                                        （4）呼吸系统疾病患者，如肺气肿、肺心病等病人；<br>
                                        （5）精神病患者，如癫痫及各种精神病人；<br>
                                        （6）严重贫血病患者，如血红蛋白量水平在50克/升以下的病人；<br>
                                        （7）大中型手术的恢复期病患者；<br>
                                        （8）孕妇及行动不便者。<br>
                                        <strong>老年旅游者预订提示</strong><br>
                                        1、70周岁以上老年人预订出游，须与我司签订《健康证明》并有家属或朋友陪同方可出游。<br>
                                        2、因服务能力所限，无法接待80周岁以上的旅游者报名出游，敬请谅解。<br>
                                        <strong>未成年旅游者预订提示</strong><br>
                                        1、未满18周岁的旅游者请由家属陪同参团。<br>
                                        2、因服务能力所限，无法接待18周岁以下旅游者单独报名出游，敬请谅解。<br>
                                        <strong>外籍人士预订提示</strong><br>
                                        本产品网上报价适用持有大陆居民身份证的游客。如您持有其他国家或地区的护照，请电话现询价格，给您造成的不便，敬请谅解。</span></div>
                                <div class="plugins_xianlu_other_1">
                                    <span style="font-size: 16px;">团队出游须知</span></div>
                                <div class="plugins_xianlu_other_2">
                                    <span style="font-size: 16px;">此线路同样适用于独立成团，成团人数无要求，价格一团一议。并可根据需求提升各项服务标准，详细咨询团队负责人：18507490749。</span></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="process">预订流程</b></h2>
                    <div class="content process clearfix">
                        <div class="processPic">
                            &nbsp;</div>
                        <ul class="notes">
                            <li><span>网上预订：</span>直接通过网站下单，在线选择产品并填写相关信息后，提交订单。</li>
                            <li class="end"><span>电话预订：</span>拨打咨询预定电话185-0749-0749（出境、自由行）、155-7585-9898(国内、周边)，由客服帮助您完成信息的确认和下单操作。</li>
                        </ul>
                        <div class="theme">
                            <b>签约方式</b></div>
                        <ul class="notes">
                            <li><span>在线签约：</span>通过在线签约页面进行签约，付款成功后，将通过电子邮件接收电子版合同，与门市签约及传真签约同等有效。</li>
                            <li><span>传真签约：</span>双方在合同上签字盖章后，通过传真进行签约。</li>
                            <li><span>上门签约：</span>中国旅行社总社湖南有限公司为您提供上门签约、收团款服务。您确认合同并签字后完成签约。服务范围限长沙市区二环以内，需要提前预约，以便我们提前准备好签约材料。</li>
                            <li><span>门市签约：</span>在门市进行签约付款。地址：湖南省长沙市八一路10号越界天佑大厦2824室，建议您提前一天电话预约【185-0749-0749（出境、自由行）、15575859898（国内、周边）】
                            </li>
                        </ul>
                        <div class="theme">
                            <b>付款方式</b></div>
                        <ul class="notes">
                            <li><span>网上支付：</span>网上银行、信用卡、第三方支付(支持开通网上银行的储蓄卡及信用卡)。</li>
                            <li><span>门市支付：</span>门市现金付款、刷卡支付。</li>
                            <li><span>银行汇款：</span>您可以通过不同银行前台汇款支付。<a href="http://www.cts1.cn/help/show.aspx?id=5"
                                target="_blank">【查看汇款帐号】</a>。</li>
                            <li><span>对公汇款：</span>通过银行或者网上银行将相关款项汇至指定账户。仅限团队业务<a href="http://www.cts1.cn/help/show.aspx?id=5"
                                target="_blank">【查看汇款帐号】</a></li>
                            <li class="end"><span>发票说明：</span><a href="http://www.cts1.cn/help/show.aspx?id=6"
                                target="_blank">【如何获取发票】</a> </li>
                        </ul>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="comment">线路点评</b></h2>
                    <div class="content comments clearfix">
                        <%--<div class="markInfo clearfix">
                            <div class="mark1">
                                <p class="hd">
                                    综合满意度</p>
                                <h2>
                                    <em>100%</em></h2>
                                <p>
                                    基于<em>0</em>人评价</p>
                            </div>
                            <div class="mark2">
                                <dl class="clearfix">
                                    <dt>行 程：</dt>
                                    <dd class="d1">
                                        <div class="red" style="width: 100%;">
                                            &nbsp;</div>
                                    </dd>
                                    <dd class="d2">
                                    </dd>
                                </dl>
                                <dl class="clearfix">
                                    <dt>导 游：</dt>
                                    <dd class="d1">
                                        <div class="green" style="width: 100%;">
                                            &nbsp;</div>
                                    </dd>
                                    <dd class="d2">
                                    </dd>
                                </dl>
                                <dl class="clearfix">
                                    <dt>交 通：</dt>
                                    <dd class="d1">
                                        <div class="blue" style="width: 100%;">
                                            &nbsp;</div>
                                    </dd>
                                    <dd class="d2">
                                    </dd>
                                </dl>
                                <dl class="clearfix">
                                    <dt>住 宿：</dt>
                                    <dd class="d1">
                                        <div class="pink" style="width: 100%;">
                                            &nbsp;</div>
                                    </dd>
                                    <dd class="d2">
                                    </dd>
                                </dl>
                            </div>
                            <div class="mark3">
                                <p>
                                    <a href="http://www.cts1.cn/usercenter/line/orderlist.aspx" class="btn" title="发表评论">
                                        &nbsp;</a></p>
                                <p>
                                    只有预订过此产品的用户才能参加点评</p>
                            </div>
                        </div>
                        <div id="scrollComment" class="lists clearfix" reviewss="0" rating_0="0" rating_1="0"
                            rating_2="0" rating_3="0">
                            <div class="viewport">
                                <div class="overview">
                                    <p class="" norecord="">
                                        该产品暂无点评信息，快来抢占沙发哟！</p>
                                </div>
                            </div>
                        </div>--%>
                        <p style="font-weight: bold; font-size: 10px; color: Green">
                            暂未开放,敬请期待...</p>
                    </div>
                </div>
                <div class="ui-tabs-panel">
                    <h2 class="hd">
                        <b class="consult">在线咨询</b></h2>
                    <div class="content consults clearfix">
                        <div id="scrollConsult" class="lists clearfix">
                            <div class="viewport">
                                <div class="overview">
                                    <p class="" norecord="">
                                        该产品暂无咨询信息！</p>
                                </div>
                            </div>
                        </div>
                        <div class="faqBox clearfix">
                            <h3>
                                您的问题？告诉我们您的疑惑，我们会在第一时间为您解答。</h3>
                            <form action="http://www.cts1.cn/line/show.aspx?" id="questionform" name="questionform"
                            novalidate="novalidate">
                            <dl class="clearfix">
                                <dt>咨询内容：</dt>
                                <dd style="height: 136px; overflow: hidden;">
                                    <textarea rows="" cols="" class="inputArea" name="Questions" id="Questions"></textarea>
                                    <span class="tip" id="box_Questions"></span>
                                </dd>
                            </dl>
                            <dl class="clearfix" id="q_login" style="">
                                <dt>用 户 名：</dt>
                                <dd style="width: 100px;">
                                    <input name="q_username" type="text" class="inputText" id="q_username" size="10">
                                    <span class="tip" id="box_q_username"></span>
                                </dd>
                                <dt>密 码：</dt>
                                <dd style="width: 100px;">
                                    <input name="q_userpass" type="password" class="inputText" id="q_userpass" size="10">
                                    <span class="tip" id="box_q_userpass"></span>
                                </dd>
                            </dl>
                            <dl class="clearfix">
                                <dt>验 证 码：</dt>
                                <dd>
                                    <input name="Proof" type="text" class="inputText" id="Proof" onfocus="this.onfocus=&#39;&#39;;get_Code(&#39;/&#39;);"
                                        size="10">
                                    <span id="imgid" style="color: red">点击获取验证码</span> <span class="tip" id="box_Proof">
                                    </span>
                                    <input type="submit" class="inputBtn" value="" name="submit1" id="submit1">
                                </dd>
                            </dl>
                            </form>
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
    <input name="hidelineid" id="hidelineid" type="hidden" value="41">
    <div id="citypiclist" style="display: none">
    </div>
    <!--页脚脚本开始-->
    <div id="footerJs">
        <script type="text/javascript" src="js/jquery.js"></script>
        <script type="text/javascript" src="js/myfocus-2.0.4.min.js"></script>
        <script type="text/javascript" src="js/common.js"></script>
        <script type="text/javascript" src="js/scrollshow.js"></script>
        <script type="text/javascript" src="js/jquery.vticker.js"></script>
        <script type="text/javascript" src="js/jquery.tinyscrollbar.min.js"></script>
        <script type="text/javascript" src="js/Calendar2.js"></script>
        <script type="text/javascript" src="js/line.js"></script>
        <script type="text/javascript" src="js/jquery.validate.js"></script>
        <script type="text/javascript" src="js/jquery.validate.check.js"></script>
        <script type="text/javascript" src="js/jquery.vticker(1).js"></script>
        <script type="text/javascript" src="js/lineshow.js"></script>
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
    <div id="backTop" class="backTop clearfix" style="display: block;">
        <a title="返回顶部" href="javascript:;" rel="nofollow">&nbsp;</a></div>
    <div id="qrCode" class="qrCode clearfix">
        <a href="javascript:;" rel="nofollow">&nbsp;<div class="item">
            &nbsp;</div>
        </a>
    </div>
    <script type="text/javascript" src="js/m-webim-lite.js" charset="utf-8"></script>
</asp:Content>
