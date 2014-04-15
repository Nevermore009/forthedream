<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="contactus.aspx.cs" Inherits="Justgo8.contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table1 td
        {
            border: #ccc solid 1px;
            padding: 5px;
        }
        .table2 td
        {
            border: #ccc solid 1px;
            padding: 5px;
        }
        .table3 td
        {
            border: #ccc solid 1px;
            padding: 5px;
        }
        .table4 td
        {
            border: #ccc solid 1px;
            padding: 5px;
        }
        .table5 td
        {
            border: #ccc solid 1px;
            padding: 5px;
        }
        .table6 td
        {
            border: #ccc solid 1px;
            padding: 5px;
        }
        .table2 .col1
        {
            width: 74px;
        }
        .table4 .col1
        {
            width: 74px;
        }
        .clause table
        {
            width: 100%;
        }
        .table3 td
        {
            width: 50%;
            text-align: center;
        }
        .table5 td
        {
            width: 50%;
            text-align: center;
        }
        .table6 td
        {
            width: 50%;
            text-align: center;
        }
        .jd_btn2
        {
            background-image: url("theme/images/jd_btn2.gif");
            background-repeat: no-repeat;
            color: #FFFFFF;
            display: block;
            font-weight: bold;
            height: 22px;
            line-height: 22px;
            margin-left: 180px;
            width: 104px;
        }
        .pubDiv_bg
        {
            display: none;
            width: 100%;
            height: 100%;
            background: #000;
            position: fixed;
            _position: absolute;
            left: 0;
            top: 0;
            z-index: 1999;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(opacity=40)";
            filter: alpha(opacity=30);
            -moz-opacity: 0.3;
            -khtml-opacity: 0.3;
            opacity: 0.3;
        }
        .pubDiv
        {
            display: none;
            z-index: 2000;
            height: auto;
            position: fixed;
            top: 200px;
            left: 50%;
            border: 1px solid #CCCCCC;
            -moz-border-radius: 5px;
            -khtml-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            background: #FFF;
            padding: 5px 5px;
            overflow: hidden;
        }
        .pubDiv_title
        {
            background: url("theme/images/pub_tbg.gif") repeat-x scroll left -40px;
            clear: both;
            height: 30px;
            line-height: 30px;
            overflow: hidden;
            width: 100%;
            margin-bottom: 10px;
        }
        .pubDiv_title h2
        {
            background: url("theme/images/pub_tbg.gif") no-repeat scroll left top;
            float: left;
            font-weight: bold;
            height: 30px;
            text-indent: 10px;
        }
        .pubDiv_title span
        {
            background: url("theme/images/pub_tbg.gif") no-repeat scroll right bottom;
            display: block;
            float: right;
            height: 30px;
            padding-right: 10px;
            width: 20px;
        }
        .pubDiv_content
        {
            width: 100%;
            height: auto;
            overflow: hidden;
            clear: both;
        }
        .ww
        {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1px solid #ccc;
            border-radius: 5px;
            height: auto;
            overflow: hidden;
            padding: 5px;
            position: fixed;
            z-index: 2000;
        }
    </style>
    <script type="text/javascript">
        function xykzfShow() {
            CreatPubdiv(820, "免责声明"); //数值为窗体的宽度，文字为窗体标题
            var rehtml = $("#xykzf").html();
            $(".pubDiv_content").html(rehtml);
            $(".pubDiv_bg").show();
            $(".pubDiv").show();
        }
        function CreatPubdiv(w, t) {
            var l = -(w / 2);
            $(".pubDiv .pubDiv_title h2").text(t);
            $(".pubDiv").css({ top: '60px', "width": w + "px", "margin-left": l + "px" });
        }
        function ClosePubdiv() {
            $(".pubDiv_bg").hide();
            $(".pubDiv").hide();
            $(".pubDiv_content").html("");
        }
        function validate2() {
            if (document.getElementById("checkbox2").checked == false) {
                alert("请先阅读注意事项并确认！");
                return false;
            } else {
                window.open("http://gbs.gta-travel.com/fe/enter.jsp?siteid=cits");
                ClosePubdiv();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <div class="clear">
        </div>
        <div class="route">
            您当前位置：首页&nbsp;-&gt;&nbsp;<font color="#cc0107;">关于我们</font></div>
        <div id="main">
            <div class="leftnav">
                <p>
                    关于康辉</p>
                <ul class="u1">
                    <li>
                        <img src="./欢迎访问中国康辉旅行社集团_files/metjiantou_03.gif">
                        <a onclick="hideornot(2010101)">关于我们</a>
                        <div style="display: none;">
                            <p id="title2010101">
                                关于我们</p>
                            <div id="content2010101">
                                <b>
                                    <center>
                                        中国康辉旅行社集团有限责任公司</center>
                                </b>中国康辉旅行社有限责任公司（原中国康辉旅行社总社）创建于1984年，是全国大型旅行社集团企业之一，注册资金逾一亿元人民币。<br>
                                “中国康辉”是中国大型国际旅行社、国家特许经营中国公民出境旅游组团社，经营范围包括入境旅游、出境旅游及国内旅游。康辉总部设有总经理室、办公室、经营管理部、财务部、日韩部、欧洲部、东南亚部、亚洲部、澳非部、港澳商务订房部、国内部、省内接待部、自驾车部、前台、市场销售部、开发旅游部、拓展旅游部、观光旅游部、亚太旅游部、外联旅游部。中国康辉以全国康辉系统的
                                80 多家兄弟旅行社为依托，与国内外同行有着广泛和友好的合作关系。日臻完善的全国网络和垂直管理模式形成康辉集团在全国旅行社业独特的优势。中国康辉以“网络化”“规模化”“品牌化”为发展目标，遍布全国及海外的网络及2300余名优秀员工真诚为海内外旅游者提供全方位的优质服务。北起哈尔滨，南至深圳、海南，东起上海，西至甘肃、新疆，
                                “中国康辉”在全国各大城市设有70多家垂直管理的分公司（分社），其中1999及2000年度就有8个分社进入全国国际旅行社百强行列。2001及2002年，“中国康辉”在国家旅游局
                                “全国国际旅行社百强企业”的业绩排名已列三甲，企业实力不断发展壮大！<br>
                                经营理念：<br>
                                “高质量的服务、高素质的员工、高水平的旅游”是“中国康辉”的经营宗旨，“让合作者放心，让旅游者满意”是“中国康辉”的经营理念。“中国康辉”将在国家旅游局和北京旅游集团的领导下，在各位同行及广大旅游消费者的支持下，励志图新，蓬勃发展。<br>
                                入境旅游：<br>
                                入境旅游业务是康辉旅行社集团发展的基础，“中国康辉”的入境旅游市场遍布世界五大洲，并且以每年20%以上的速度快速增长。“服务优质细腻、线路新颖独特”是“中国康辉”蜚声海外的品牌形象；行程万里的“世界屋脊汽车挑战赛”等成功案例的积淀，日渐形成“中国康辉”卓越的品质特征。<br>
                                公民旅游：<br>
                                “康辉旅游”——中国公民旅游总部隶属中国康辉旅行社有限责任公司，是“中国康辉”这一国家大型旅行社企业集团的重要组成部分。“康辉旅游”特许经营中国公民出境旅游业务，依托“中国康辉”集团的强大实力与品牌以及全国七十余家分社的网络优势及垂直管理体系的建设，常年推广中国公民赴东南亚、港澳、日本、韩国、澳大利亚、新西兰、德国、南非、埃及、土耳其等开放国家和地区旅游，线路丰富、各具特色，并提供赴欧洲、美国、加拿大、中东、地中海地区、俄罗斯等国商务考察活动接待及相关咨询服务，并长年为企业客户提供会议及奖励旅游等服务。“康辉旅游”在北京及全国出境旅游市场已经占有了较大的市场份额，拥有很高的行业知名度。同时，“康辉旅游”国内旅游方面也在锐意进取、不断扩张，成为中国公民旅游行业一支朝气蓬勃的生力军。<br>
                            </div>
                        </div>
                        <ul class="u2" id="con_2010101">
                        </ul>
                    </li>
                    <li>
                        <img src="./欢迎访问中国康辉旅行社集团_files/metjiantou_03.gif">
                        <a onclick="hideornot(2010102)">旅行社资质与荣誉</a>
                        <div style="display: none;">
                            <p id="title2010102">
                                旅行社资质与荣誉</p>
                            <div id="content2010102">
                            </div>
                        </div>
                        <ul class="u2" id="con_2010102" style="display: none;">
                        </ul>
                    </li>
                    <li>
                        <img src="./欢迎访问中国康辉旅行社集团_files/metjiantou_03.gif">
                        <a onclick="hideornot(2010103)">联系我们</a>
                        <div style="display: none;">
                            <p id="title2010103">
                                联系我们</p>
                            <div id="content2010103">
                                <img src="./欢迎访问中国康辉旅行社集团_files/201432410115135687.jpg">
                                康辉总部：中国康辉旅行社集团有限责任公司<br>
                                地址：北京市朝阳区农展馆南路13号瑞辰国际中心15F<br>
                                邮编：100025<br>
                                电话：010-65877676<br>
                                传真：010-65877620<br>
                                旅游资讯热线：40061-40031<br>
                                总社门市<br>
                                地址：北京市朝阳区农展馆南路5号京朝大厦1F
                            </div>
                        </div>
                        <ul class="u2" id="con_2010103" style="">
                        </ul>
                    </li>
                    <li>
                        <img src="./欢迎访问中国康辉旅行社集团_files/metjiantou_03.gif">
                        <a onclick="hideornot(2010104)">预定须知</a>
                        <div style="display: none;">
                            <p id="title2010104">
                                预定须知</p>
                            <div id="content2010104">
                                <b>会员注册： </b>
                                <br>
                                第一步：在“会员注册”页面依次填写邮箱、手机、用户名、密码，确认密码。<br>
                                第二步：注册过程中验证登录手机号/邮箱有效性：<br>
                                1、 手机号验证：输入正确手机号码后页面将显示验证码输入框，点击验证码输入框后的“获取验证码”按钮，填入手机收到的x位数验证码。<br>
                                2、 邮箱验证：提交注册信息后，点击注册邮箱中的验证链接。<br>
                                第三步：点击 “同意以下协议并注册”按钮即可完成注册。<br>
                                <b>会员登录： </b>
                                <br>
                                可通过两种方式进行登录：<br>
                                第一种：注册会员登录，在“会员中心”页面输入用户名、密码进行登录。<br>
                                第二种：快速登录，在“首页”上方点击登陆，跳转登陆页面进行登陆。<br>
                                <b>预订流程：</b><br>
                                一、国内游/出境游：<br>
                                1、搜索商品<br>
                                中国康辉提供两种方便快捷的产品搜索功能<br>
                                ： （1）通过在首页输入线路关键字的方法来搜索想要预订的产品<br>
                                （2）通过中国康辉线路分类导航栏来找到想要预订的产品<br>
                                2、预订 在想要预订的产品详情页点击“预订”，根据页面提示输入预订人数。<br>
                                3、注册登录<br>
                                4、填写参团人信息<br>
                                请填写正确、完整的参团人姓名、性别、联系电话、证件类型和证件号码。<br>
                                5、填写联系人信息<br>
                                请填写正确完整的联系人姓名、手机号码和电子邮件地址。<br>
                                6、提交订单<br>
                                以上信息核实无误后，阅读预订须知及合同条款，如您接受所有条款，请 勾选“我已阅读并接受上述预订须知及合同条款”，并点击“提交订单”，系统将自动生成一个订单号，说明已经成功提交订单。特别提示：提交订单仅表示您提交了预订意向，交款且得到预订人员的确认后才能确认您正式报名了此线路。<br>
                                7、选择支付方式<br>
                                中国康辉提供多种支付方式：<br>
                                （1）在线支付（支付宝支付）<br>
                                （2）门市现付 (现金、刷卡、支票等)
                                <br>
                                （3）银行汇款<br>
                                二、自由行：<br>
                                1、搜索商品<br>
                                中国康辉提供两种方便快捷的产品搜索功能：<br>
                                （1）通过在首页输入线路关键字的方法来搜索想要预订的产品<br>
                                （2）通过中国康辉线路分类导航栏来找到想要预订的产品<br>
                                2、预订<br>
                                在想要预订的产品详情页下方选择出发日期，根据页面提示输入预订人数。<br>
                                3、注册登录<br>
                                4、线路信息选择<br>
                                （1）选择线路中打包好报价的产品，请点击页面下方的“下一步”按钮。<br>
                                （2）如对行程和酒店有其它选择，可在“私人定制”页面进行筛选，选择符合您需要的产品组合搭配。
                                <br>
                                5、填写参团人信息<br>
                                请填写正确、完整的参团人姓名及拼音、性别、证件类型和证件号码、出生日期以及联系电话。<br>
                                6、填写联系人信息<br>
                                请填写正确完整的联系人姓名、手机号码和电子邮件地址。<br>
                                7、提交订单<br>
                                在订单详情页面核实订单信息无误后，阅读预订须知及合同条款，如您接受所有条款，请勾选“我已阅读并接受上述预订须知及合同条款”，并点击“提交订单”，系统自动生成一个订单号，说明已经成功提交订单。特别提示：提交订单仅表示您提交了预订意向，交款且得到预订人员的确认后才能确认您正式报名了此线路<br>
                                8、选择付款方式
                                <br>
                                中国康辉提供多种支付方式：<br>
                                （1）在线支付（银联在线支付、支付宝支付、网上银行支付）<br>
                                （2）门市现付 (现金、刷卡、支票等)
                                <br>
                                （3）银行汇款<br>
                                准确填写参团人、联系人信息并选择付款方式后，请点击“下一步”按钮。<br>
                                三、签证：
                                <br>
                                1、搜索商品<br>
                                中国康辉为提供两种方便快捷的产品搜索功能：<br>
                                （1）通过在首页 导航栏选择“签证服务"进入签证页面选择想要办理的国家地区预定产品。<br>
                                （2）通过中国康辉分类导航栏来找到想要预订的产品<br>
                                2、预订<br>
                                在想要办理的签证产品类型展开页中，点击“预订”按钮。
                                <br>
                                3、注册登录<br>
                                4、填写办签人信息<br>
                                点击办签人信息下的“增加人数”按钮，在弹出框中输入办理签证所需基本信息，点击“保存”按钮。<br>
                                5、填写联系人信息<br>
                                请填写正确完整的联系人姓名、联系人联系电话、联系人电子邮件地址、联系人居住地及邮编。<br>
                                6、提交订单<br>
                                以上信息核实无误后，阅读预订须知及合同条款，如您接受所有条款，请勾选下方的“我已阅读并接受上述预订须知及合同条款”并点击“提交”按钮，系统将自动生成一个订单号，说明已经成功提交订单。稍后预订中心人员将会对订单进行后续处理。<br>
                                <b>在线预订条款：</b><br>
                                中国康辉网站旅游预订须知<br>
                                1、 范围<br>
                                本部分规定了国旅在线网站旅游度假产品预订及确认、旅游度假产品内容、旅游度假产品价格、订单生效、生效订单的解除和变更、游客应履行的义务、中国国旅应履行的义务、涉及第三方的相关责任、旅行保险、不可抗力、解决争议适用法律法规约定以及其它情况等与旅游产品预订相关的内容。<br>
                                本部分适用于所有在国旅在线网站上预订包括旅游度假产品（国内游、出境游）、酒店、机票预订、代办签证以及其他相关旅游服务的人员。<br>
                                国旅在线网站上公布的所有产品，都是中国康辉发出的一种要约邀请，您的订单则被视作为一种要约行为。 2、 旅游度假产品预订及确认
                                <br>
                                2.1通过中国康辉官方网站（www.cct.cn)预订国内游、出境游、机票、酒店、自由行产品及其它旅游服务，您需先注册为中国康辉网站会员。您可在国旅在线网站为自己及他人预订各项旅游服务，请您在网上预订的过程中准确填写您的预订信息及实际出游者的相关信息，并保证您提交个人信息的真实性。如因您提交的预订信息有误，造成您或他人无法出行或发生经济损失的，中国康辉不承担退赔责任；如因此给中国康辉造成损失的，您还需按照具体的赔偿规定进行赔偿。
                                <br>
                                2.2 您的行程的最终确认以中国康辉在出发前提供给您的出团通知为准。
                                <br>
                                3、 旅游度假产品内容
                                <br>
                                中国康辉（www.cct.cn）展示的中国康辉旅游度假产品包括了“团队信息”、“参考行程”、“费用信息”、“参团须知”“签证材料”等，其中除行程展示外涵盖了安全告知、特殊提前解约约定以及该产品的特殊告知事项，请仔细阅读。您的预订表明您已接受展示的所有条款。
                                <br>
                                4、 旅游度假产品价格
                                <br>
                                4.1 中国康辉保留在不事先通知的情况下更改其网站上已公布的旅游线路及度假产品价格和相关信息的权利。所有预订的旅游度假产品价格，以中国康辉给您的最后确认的订单上约定的金额为准。中国康辉给您的确认订单上约定的价格，只包括确认单中注明的“费用包含”项目中的内容。
                                <br>
                                4.2 旅游度假产品报价是按照2成人入住1间房计算的价格，如您的订单产生单间，中国康辉将安排您与其他客人拼房入住，如果没有能够拼住的客人，您需要付单间差。<br>
                                5、 订单生效
                                <br>
                                5.1 在您按时付清中国康辉确认给您的应付费用后，中国康辉确认给您的订单则正式生效，并产生法律效力。如您未按要求及时付清相关费用，而您拟预订产品的价格、内容、标准已发生变化或产品售罄等，中国康辉对此将不承担任何责任，且中国康辉可以随时取消未付款订单。
                                <br>
                                5.2 在您提交订单进行在线支付出境游、国内游、自由行、邮轮度假相关产品前，请确认产品详细页是否有“即时确认”或“二次确认”标签。如果标签显示需“二次确认”，建议您等待预订中心人员确认名额后，再进行在线支付。如果您在不确定是否可“即时确认”的情况下选择继续进行在线支付，在预订中心人员确认名额有效后，您可以继续办理报名手续；若预订中心人员经确认后该线路已无名额，我们将为您办理退款手续。<br>
                                5.3 订单生效后，您应遵循机票按民航电脑显示航班时间登机，酒店按确定日在确定时间后入住，旅游度假按旅游合同中的日期出行。如您未及时登机或未按时入住所订宾馆或未按规定日期出行，视为您解约，您必须赔偿中国康辉的损失。
                                <br>
                                5.4 旅客信息的提供：为保证您能够顺利登机、车、船，请您提供正确的旅客信息（包括证件类型、证件号码、证件有效期、出生日期、性别、身体健康状况）。请您出行前务必检查所持有证件的有效性，随身带好证件，以便顺利出行。<br>
                                6、 生效订单的解除和变更
                                <br>
                                6.1 您主动解除已生效订单<br>
                                订单生效后，您若要主动解除已生效订单，您须提出书面申请并按照与中国康辉约定出行条款时所认可的确认单及相关旅游合同的约定进行相关订单的解除，同时赔偿中国康辉的损失并支付相应违约金。
                                6.2 中国康辉取消您的已生效订单
                                <br>
                                在您按要求付清所有旅游线路费用后，如因中国康辉的原因，致使您的旅游线路不能成行而取消的，中国康辉应当立即通知您，并按照您与中国康辉约定出行条款时所认可的确认单及您与中国康辉签订的旅游合同或《单项委托/组合服务合同》的约定进行相关订单的解除，同时按约定向您支付相应违约金并赔偿您的损失。
                                <br>
                                6.3 已生效订单内容变更
                                <br>
                                经双方协商一致，可以以书面形式变更已生效订单约定的产品内容。但由此增加的费用应由提出变更的一方承担，由此减少的费用，中国康辉应退还给您。如给对方造成损失的，由提出变更的一方承担相应损失。
                                由于某些产品有一定的特殊性，您在预订及出行时还应当仔细阅读产品展示页面的相关介绍及行程单中的相关提示条款，若中国康辉已事先告知可能会产生变更的内容，则不属中国康辉变更需补偿的范围。
                                7、您应注意的事项<br>
                                7.1 您应确保自身身体条件适合外出旅游度假。如您有心脏病、高血压、呼吸系统疾病等病史，请在征得医院专业医生同意后预订旅游产品。
                                <br>
                                7.2 您应确保您不属于中国政府限制出境的人员之列。
                                <br>
                                7.3 您提供给中国康辉的证件和相关资料必须真实有效并符合相关部门要求，通讯联络方式应当保持畅通，如您提供的资料有误，相关责任由您自行承担，如给中国康辉造成损失，您应承担赔偿责任。<br>
                                7.4 孕妇、80岁以上的老年人及无监护人陪同的18周岁以下未成年人请预订前致电中国康辉旅游咨询预订热线40061-40031咨询相关规定。<br>
                                7.5 网上预订只针对需要从北京出发的客人，如需从其他地方出发请联系当地康辉进行咨询。<br>
                                8、涉及第三方的相关责任<br>
                                8.1 第三方是指您和中国康辉及其委托的旅游服务辅助人以外的任何组织、机构、公共交通承运人、同行团友及其他个人。<br>
                                8.2 您与第三方之间出现的下列情况，相关责任按以下约定执行：<br>
                                a)您在旅行中应注意人身财产安全，妥善保管自己的证件及行李物品，贵重物品（如现金、证件、珠宝首饰、有价证券、照相机、摄像机、计算机、手机等）应当随身携带。若非中国康辉原因发生人身意外伤害或随身携带行李物品遗失、被盗、被抢等情况，中国康辉应积极协助办理救助、寻找、补救、报案、索赔等工作，但无赔偿之责任。需要补办证件所产生的费用，由您承担。<br>
                                b)您若违反相关国家或地区法律而被罚、被拘留、遣返及追究其他刑事、民事责任的，一切责任和费用由您自负。但为维护您的合法权益，中国康辉应当协助有关机构查明事实。<br>
                                c) 您在旅途中非中国康辉安排自行购物及参加各种非中国康辉推荐自费项目等，应当风险自担。由此发生的损失及纠纷，由您自行承担和解决，中国康辉不承担责任。<br>
                                d)除非是因中国康辉原因，无论因其他何种原因导致航班、火车或轮船延误、取消、变更，使得您的旅程不得不发生变更时，应当由双方共同与承运人交涉，包括就赔偿事宜进行交涉，中国康辉对此不承担赔偿责任，您不得为此采取不合作态度，更不得采取拒绝登机、车、船或滞留不归等非常手段进行对抗，否则由此造成的损失及其他后果由您承担。<br>
                                e) 是否发放签证，是否准予出入境，系有关机构之行政权或主权，中国康辉接受您的委托代办签证，并不代表中国康辉承诺能够成功办理。如因您自身原因或提供材料存在错漏或使领馆任务的其他原因不能及时办理签证而影响行程的，以及被相关机关拒发签证或拒绝入境的，您承担全部责任和费用。
                                <br>
                                f) 因有关机构政策调整原因造成您的签证延误，双方均不承担责任。如发生费用，由您承担。<br>
                                9、关于旅行安全及其保障<br>
                                9.1 旅游产品的服务对象是旅游者，这决定了确保安全是旅游产品的生命所在。为了确保您的出行安全并在出现安全事故时转嫁风险，使您的利益可以得到最大限度的保证，中国康辉除了投保了旅行社责任险外，也强烈建议您出游时根据个人意愿和需要投保旅游意外伤害保险和救援险。<br>
                                9.2 旅游者参加旅行社组织的旅游活动过程中，由于旅游者个人过错导致的人身伤亡和财产损失，以及由此导致需支出的各种费用，旅行社不承担赔偿责任，这是中国康辉强烈建议您投保相关保险的原因。
                                9.3 旅游者在不参加双方约定的活动而自行活动的时间内，发生的人身、财产损害，旅行社不承担赔偿责任。在此种情况下，购买相关保险对您来说显得尤其重要。<br>
                                10、不可抗力
                                <br>
                                因自然灾害、恶劣天气条件、政府行为、社会异常事件（如罢工、政变、骚乱、游行等）、流行性疾病暴发等双方不可预见、不可避免、不可克服的不可抗力事件，导致已生效订单部分或全部不能履行，双方可以协商延期履行。若您不愿意延期履行，或因不可抗力因素导致中国康辉组团成本增加，双方无法就新价格达成一致时，则双方可以解除已生效订单。延期或解除协议时，中国康辉在此前因组团发生的费用由您承担。<br>
                                中国康辉和您双方因不可抗力不能履行已生效订单约定内容的，部分或者全部免除责任，但应当及时通知对方并在合理期限内提供有关证明，法律另有规定的除外。
                                <br>
                                11、 其它<br>
                                本须知未尽的事项，在中国康辉确认给您的订单、合同中另行约定。<br>
                            </div>
                        </div>
                        <ul class="u2" id="con_2010104" style="display: none;">
                        </ul>
                    </li>
                    <li>
                        <img src="./欢迎访问中国康辉旅行社集团_files/metjiantou_03.gif">
                        <a onclick="hideornot(2010105)">免责声明</a>
                        <div style="display: none;">
                            <p id="title2010105">
                                免责声明</p>
                            <div id="content2010105">
                                1、本网站不承担由于用户自身过错、技术或其它不可控原因（包括因互联网本身的原因以及黑客入侵等原因）导致网站页面信息或其它方面的错误而给用户造成的损失，除非现行的法律法规另有明文规定。但本网站将尽力减少因此而给用户造成的损失和影响；<br>
                                2、为方便用户（包括企业或个人，下同），本网站内设有与其它网站或网页的链接，但本网站不保证所设置的外部链接的准确性和完整性，亦并不对这些网站或网页进行维护，用户启用该网站或网页链接所产生的一切风险，本网站概不承担法律责任；<br>
                                3、任何单位或个人认为本网站上的网页图文等内容可能涉嫌侵犯其著作权，应该及时向我们提出书面权利通知，并提供身份证明、权属证明及详细侵权情况证明。我们收到上述法律文件后，将会依法尽快处理；<br>
                                4、如果本网站的服务内容与中国康辉各企业的相关规章、规定及与客户签订的合同、向客户发出的通知、须知等内容不符或相冲突的，以该相关规章、规定、合同、通知、须知为准。<br>
                            </div>
                        </div>
                        <ul class="u2" id="con_2010105" style="display: none;">
                        </ul>
                    </li>
                    <li>
                        <img src="./欢迎访问中国康辉旅行社集团_files/metjiantou_03.gif">
                        <a onclick="hideornot(2010107)">人才招聘</a>
                        <div style="display: none;">
                            <p id="title2010107">
                                人才招聘</p>
                            <div id="content2010107">
                            </div>
                        </div>
                        <ul class="u2" id="con_2010107" style="display: none;">
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="rightnav" id="contetxt">
                <p class="righttitle">
                    联系我们</p>
                <img src="./欢迎访问中国康辉旅行社集团_files/201432410115135687.jpg">
                康辉总部：中国康辉旅行社集团有限责任公司<br>
                地址：北京市朝阳区农展馆南路13号瑞辰国际中心15F<br>
                邮编：100025<br>
                电话：010-65877676<br>
                传真：010-65877620<br>
                旅游资讯热线：40061-40031<br>
                总社门市<br>
                地址：北京市朝阳区农展馆南路5号京朝大厦1F
            </div>
        </div>
        <script type="text/javascript">
            function hideornot(mark) {
                if (document.getElementById("con_" + mark).style.display == "none") {
                    document.getElementById("con_" + mark).style.display = "";
                }
                else {
                    document.getElementById("con_" + mark).style.display = "none";
                }
                if (document.getElementById("con_" + mark).getElementsByTagName("li").length == 0) {
                    showcontent(mark);
                }
            }
            function showcontent(flag) {
                var html = "<p class='righttitle'>" + document.getElementById("title" + flag).innerHTML + "</p>" + document.getElementById("content" + flag).innerHTML;
                document.getElementById("contetxt").innerHTML = html;
            }
            var recno = "2010101";
            showcontent(recno);
            $(function () {
                var id = 2010103;
                hideornot(id);
            });
        </script>
        <div style="height: 10px; background-color: #fff; width: 100%; float: left;">
        </div>
        <div id="bottomnav">
            <ul class="bottomblock">
                <li class="firstli">预订常见问题</li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A29&recno=201131000091" target="_blank"
                    title="单房差是什么？">单房差是什么？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A29&recno=201131000092" target="_blank"
                    title="双飞、双卧都是什么意思？">双飞、双卧都是什么意思？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A29&recno=201131000093" target="_blank"
                    title="满意度是怎么计算的？">满意度是怎么计算的？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A29&recno=201131000094" target="_blank"
                    title="纯玩是什么意思？">纯玩是什么意思？</a></li>
            </ul>
            <ul class="bottomblock">
                <li class="firstli">付款和发票</li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A30&recno=201131000095" target="_blank"
                    title="签约可以刷卡吗？">签约可以刷卡吗？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A30&recno=201131000096" target="_blank"
                    title="付款方式有哪些？">付款方式有哪些？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A30&recno=201131000097" target="_blank"
                    title="怎么网上支付？">怎么网上支付？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A30&recno=201131000098" target="_blank"
                    title="如何获取发票？">如何获取发票？</a></li>
            </ul>
            <ul class="bottomblock">
                <li class="firstli">签署旅游合同</li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A31&recno=201131000099" target="_blank"
                    title="什么是抵用卷？">什么是抵用卷？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A31&recno=201131000100" target="_blank"
                    title="门市地址在哪里？">门市地址在哪里？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A31&recno=201131000101" target="_blank"
                    title="能传真合同吗？">能传真合同吗？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A31&recno=201131000102" target="_blank"
                    title="可以不签合同吗？">可以不签合同吗？</a></li>
            </ul>
            <ul class="bottomblock">
                <li class="firstli">旅游预订优惠政策</li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A32&recno=201131000103" target="_blank"
                    title="有旅游合同范本下载吗？">有旅游合同范本下载吗？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A32&recno=201131000104" target="_blank"
                    title="抵用卷使用帮助">抵用卷使用帮助</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A32&recno=201131000105" target="_blank"
                    title="什么是纸用卷？">什么是纸用卷？</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A32&recno=201131000106" target="_blank"
                    title="如何获得旅游卷？">如何获得旅游卷？</a></li>
            </ul>
            <ul>
                <li class="firstli">其他事项</li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A33&recno=201131000107" target="_blank"
                    title="签证相关问题解答">签证相关问题解答</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A33&recno=201131000108" target="_blank"
                    title="旅游保险问题解答">旅游保险问题解答</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A33&recno=201131000109" target="_blank"
                    title="退款问题解答">退款问题解答</a></li>
                <li><a href="http://www.cct.cn/bj/questions.aspx?mark=A33&recno=201131000110" target="_blank"
                    title="旅途中的问题">旅途中的问题</a></li>
            </ul>
        </div>
        <div id="wordlinks">
            <div>
                友情链接：</div>
            <p>
                <a target="_blank" href="http://www.webcct.com/" title="康辉在线">康辉在线</a> <a target="_blank"
                    href="http://www.963960.com/" title="甘肃康辉">甘肃康辉</a> <a target="_blank" href="http://www.sdcct.com/"
                        title="济南康辉">济南康辉</a> <a target="_blank" href="http://www.tjkanghui.com/" title="天津康辉">
                            天津康辉</a> <a target="_blank" href="http://www.cctpage.com/" title="广州康辉">广州康辉</a>
                <a target="_blank" href="http://www.hbcct.com.cn/" title="湖北康辉">湖北康辉</a> <a target="_blank"
                    href="http://www.96567.cc/" title="河南康辉">河南康辉</a> <a target="_blank" href="http://www.96333.net.cn/"
                        title="河北康辉">河北康辉</a> <a target="_blank" href="http://www.96555.cc/" title="湖南新康辉">湖南新康辉</a>
                <a target="_blank" href="http://www.yncct.cn/" title="昆明康辉">昆明康辉</a> <a target="_blank"
                    href="http://www.nature-tour.com/" title="新疆康辉">新疆康辉</a> <a target="_blank" href="http://www.uuuly.com/"
                        title="深圳康辉">深圳康辉</a>
            </p>
        </div>
    </div>
</asp:Content>
