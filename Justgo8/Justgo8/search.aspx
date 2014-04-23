<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="search.aspx.cs" Inherits="Justgo8.search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/search.css" rel="stylesheet" type="text/css" />
    <link href="css/datepicker.css" rel="stylesheet" type="text/css" />
    <link href="css/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="js/WdatePicker.js" type="text/javascript"></script>
    <script src="js/calendar.js" type="text/javascript"></script>
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
            background-image: url("images/search/jd_btn2.gif");
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
            background: url("images/search/pub_tbg.gif") repeat-x scroll left -40px;
            clear: both;
            height: 30px;
            line-height: 30px;
            overflow: hidden;
            width: 100%;
            margin-bottom: 10px;
        }
        .pubDiv_title h2
        {
            background: url("images/search/pub_tbg.gif") no-repeat scroll left top;
            float: left;
            font-weight: bold;
            height: 30px;
            text-indent: 10px;
        }
        .pubDiv_title span
        {
            background: url("images/search/pub_tbg.gif") no-repeat scroll right bottom;
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
        var condition_typeId = "201111102" != null && "201111102" != "" ? "201111102" : "all";
        var de = "";
        var condition_days = "all";
        var condition_price = "all";
        var condition_destination = "all";
        var condition_destination_city = "all";
        var condition_name = "";
        var condition_minDate = "";
        var condition_maxDate = "";
        var condition_outCity = "";
        var condition_sellingPoint = "";
        var pageNum = 0;
        var dataCount = 0;
        var currentPage = 1;
        var pageCount = 0;
        var sortType = "";
        function removeSelf(ele, id_all, id_ul) {//id_all--全部的标签的id，id_ul--相应条件的ul的id
            $(ele).css("display", "none");
            $("#" + id_all + "").addClass("cur");
            $("#" + id_ul + " li").removeClass("cur");
            if (id_all == 'product_all') {
                $("#tags li").css("display", "")
                $("#c_type").val("");
            }
        } //各个div条件删除之后

        function removeSelf_province(ele) {
            $(ele).css("display", "none");
            $("#condition_destination_city").css("display", "none");
            //$("#tagContent div").css("display", "none"); 
            $("#tags li").removeClass("selectTag"); //tags li 这里包含省城市
            $("#tags li a").removeClass("cur"); //这里是删除没有市城市的省城市其中a标签的样式(对于没有市城市的省城市样式不是加在li上，而是加在a上)
            $("#tagContent").css("display", "none"); //#tagContent div 这里面包含市城市
            $("#destination_all").addClass("cur");
            $("#c_area").val("");
        } //目的地省div条件删除之后

        function removeSelf_city(ele) {
            $(ele).css("display", "none");
            $("li:contains('" + $(ele).text() + "')").removeClass("no").siblings("[title=buxian]").addClass("no"); //让自己(市城市)拿掉样式，其对应的不限添加样式
            condition_destination_city = "all";
            $("#c_city").val("");

        } //目的地市div条件删除之后

        function removeSelf_name(ele) {
            $(ele).css("display", "none");
            $("#na").val("");
        } //姓名条件删除之后

        function conditionAll_trigger(id) {//这里是全部(按钮)的单击事件，这里是想直接触发相应的省城市关闭事件
            $("#" + id + "").trigger("click");
        }

        function selectTag(showContent, ele, state) {//这个是省城市li中a标签的onclick事件
            //state为1是代表有3级目的地，0代表没有3级目的地
            var tag = document.getElementById("tags").getElementsByTagName("li");
            var taglength = tag.length;
            for (i = 0; i < taglength; i++) {
                tag[i].className = "";
            }
            if (state == 1) {
                ele.parentNode.className = "selectTag";
                $(ele).parent().siblings().children("a").removeClass("cur"); //拿掉省城市li下a的样式
                var cityinfos = $("#tagContent .tagContent");
                if (cityinfos) {
                    for (i = 0; i < cityinfos.length; i++) {//"tagContent" + i 是包含市城市的外面div
                        cityinfos[i].style.display = "none";
                    }
                }
                $("#tagContent").css("display", "");
                document.getElementById(showContent).style.display = "block";
                $("#" + showContent + " li[title=buxian]").addClass("no").siblings().removeClass("no");
            }
            else if (state == 0) {
                ele.className = "cur";
                $(ele).parent().siblings().children("a").removeClass("cur");
                $("#tagContent").css("display", "none");
            }
            $("#destination_all").removeClass("cur");
            $("#condition_destination").css("display", "").text($(ele).text()).attr("title", $(ele).parent().attr("id"));
            $("#condition_destination_city").css("display", "none");
            $("#c_area").val($(ele).parent().attr("id"));
        }

        function condition_product_all() {
            conditionAll_trigger('condition_product');
            $("#tags li").css("display", "")
            $("#c_type").val("");
        }        

        function submit_condition() {
            condition_name = $("#na").val();
            if (condition_name != "") {
                $("#condition_names").css("display", "").text(condition_name);
            }
            condition_minDate = $("#startDate").val();
            condition_maxDate = $("#endDate").val();
            $("#ul_1").empty().append($("<center style='margin-top:100px;'><img src='images/search/loading.gif' /></center>"));
            $("#center_p").empty();
            $("#center_p_Ex").empty();
            if ($("#condition_date").css("display") == "inline") {
                condition_days = $("#condition_date").text();
            }
            else {
                condition_days = "all";
            }
            if ($("#condition_price").css("display") == "inline") {
                condition_price = $("#condition_price").text();
            }
            else {
                condition_price = "all";
            }
            if ($("#condition_outCity").css("display") == "inline") {
                condition_outCity = $("#condition_outCity").attr("title");
            }
            else {
                condition_outCity = "all";
            }
            if ($("#condition_destination").css("display") == "inline") {
                condition_destination = $("#condition_destination").attr("title");
            }
            else {
                condition_destination = "all";
            }
            if ($("#condition_destination_city").css("display") == "inline") {
                condition_destination_city = $("#condition_destination_city").attr("title");
            }
            else {
                condition_destination_city = "all";
            }
            if ($("#condition_product").css("display") == "inline") {
                condition_sellingPoint = $("#condition_product").attr("title");
            }
            else {
                condition_sellingPoint = "all";
            }
            $.post("getLines_search.ashx", { "condition_outCity": condition_outCity, "condition_typeId": condition_typeId, "condition_days": condition_days, "condition_price": condition_price, "condition_destination": condition_destination, "condition_destination_city": condition_destination_city, "condition_name": condition_name, "condition_minDate": condition_minDate, "condition_maxDate": condition_maxDate, "condition_sellingPoint": condition_sellingPoint, "sortType": sortType }, function (data, status) {
                pageCount = Number(data.split("|")[1]);
                dataCount = Number(data.split("|")[2]);
                $("#search_pageCount").text(pageCount);
                $("#search_resultCount").text(dataCount);
                if (dataCount != 0) {
                    $("#ul_1").empty().html(data.split("|")[0]);
                    if (pageNum == 0) {
                        $("#center_p").empty().append($("<span class='previous'><a  href='javascript:void(0);' onclick='goToPage(1)'>上一页</a></span>"));
                        $("#center_p_Ex").empty().append($("<span class='previous'><a  href='javascript:void(0);' onclick='goToPage(1)'>上一页</a></span>"));
                        pageCount = Number(data.split("|")[1]);
                        pageCount = pageCount <= 5 ? pageCount : 5;
                        $("#center_p").append($("<div class='pgcon'></div>"));
                        $("#center_p_Ex").append($("<div class='pgcon'></div>"));
                        for (var i = 0; i < pageCount; i++) {
                            $(".pgcon").append($("<a href='javascript:void(0);' onclick='goToPage(" + Number(i + 1) + ")'>" + Number(i + 1) + "</a>"));
                        }
                        $("#center_p").append($("<span class='next'><a  href='javascript:void(0);' onclick='goToPage(" + (pageCount == 1 ? 1 : 2) + ")'>下一页</a></span>"));
                        $("#center_p_Ex").append($("<span class='next'><a  href='javascript:void(0);' onclick='goToPage(" + (pageCount == 1 ? 1 : 2) + ")'>下一页</a></span>"));
                        //上面这里是下一页所以才等于的2
                    }
                    $("#pageNum_outPut").text("1/" + pageCount);
                }
                else {
                    $("#ul_1").empty().append($("<center style='margin-top:100px;margin-bottom:100px;'>没有找到相应条件的线路</center>"));
                    $("#pageNum_outPut").text(1 + "/" + 1);
                }
            });
        }

        function goToPage(page) {
            if (currentPage == page) {
                return;
            }
            $("#ul_1").empty().append($("<center style='margin-top:100px;'><img src='images/search/loading.gif' /></center>"));
            currentPage = page;
            $.post("getLines_search.ashx", { "condition_outCity": condition_outCity, "condition_typeId": condition_typeId, "condition_days": condition_days, "condition_price": condition_price, "condition_destination": condition_destination, "condition_destination_city": condition_destination_city, "condition_name": condition_name, "condition_minDate": condition_minDate, "condition_maxDate": condition_maxDate, "condition_sellingPoint": condition_sellingPoint, "sortType": sortType, "pageNum": currentPage }, function (data, status) {
                pageCount = Number(data.split("|")[1]);
                dataCount = Number(data.split("|")[2]);
                var page_prev = Number(currentPage - 1) <= 1 ? 1 : Number(currentPage - 1);
                var page_next = Number(currentPage + 1) > pageCount ? pageCount : Number(currentPage + 1);
                $("#ul_1").empty().html(data.split("|")[0]);
                if (dataCount > 0) {
                    if (page < 5) {

                        $("#center_p").empty().append($("<span class='previous'><a  href='javascript:void(0);' onclick='goToPage(" + page_prev + ")'>上一页</a></span>"));
                        $("#center_p").append($("<div class='pgcon'></div>"));
                        $("#center_p_Ex").empty().append($("<span class='previous'><a  href='javascript:void(0);' onclick='goToPage(" + page_prev + ")'>上一页</a></span>"));
                        $("#center_p_Ex").append($("<div class='pgcon'></div>"));
                        for (var i = 0; i < 5; i++) {
                            if (Number(i + 1) > pageCount) break;
                            if (Number(i + 1) == currentPage) {
                                $(".pgcon").append($("<a href='javascript:void(0);' class='curr' onclick='goToPage(" + Number(i + 1) + ")'>" + Number(i + 1) + "</a>"));
                            }
                            else {
                                $(".pgcon").append($("<a href='javascript:void(0);'  onclick='goToPage(" + Number(i + 1) + ")'>" + Number(i + 1) + "</a>"));
                            }
                        }
                        $("#center_p").append($("<span class='next'><a  href='javascript:void(0);' onclick='goToPage(" + page_next + ")'>下一页</a></span>"));
                        $("#center_p_Ex").append($("<span class='next'><a  href='javascript:void(0);' onclick='goToPage(" + page_next + ")'>下一页</a></span>"));
                    }
                    else {
                        $("#center_p").empty().append($("<span class='previous'><a  href='javascript:void(0);' onclick='goToPage(" + page_prev + ")'>上一页</a></span>"));
                        $("#center_p").append($("<div class='pgcon'></div>"));
                        $("#center_p_Ex").empty().append($("<span class='previous'><a  href='javascript:void(0);' onclick='goToPage(" + page_prev + ")'>上一页</a></span>"));
                        $("#center_p_Ex").append($("<div class='pgcon'></div>"));
                        for (var i = page - 2; i <= page + 2; i++) {
                            if (i < 1) { i++; break; } //这里这句应该不用加，而且应该换成continue
                            if (i > pageCount) { break; }
                            if (Number(i) == currentPage) {
                                $(".pgcon").append($("<a href='javascript:void(0);' class='curr' onclick='goToPage(" + Number(i) + ")'>" + Number(i) + "</a>"));
                            }
                            else {
                                $(".pgcon").append($("<a href='javascript:void(0);'  onclick='goToPage(" + Number(i) + ")'>" + Number(i) + "</a>"));
                            }
                        }
                        $("#center_p").append($("<span class='next'><a  href='javascript:void(0);' onclick='goToPage(" + page_next + ")'>下一页</a></span>"));
                        $("#center_p_Ex").append($("<span class='next'><a  href='javascript:void(0);' onclick='goToPage(" + page_next + ")'>下一页</a></span>"));
                    }
                }
            });
        }

        function getAllKaiban(id) {
            $("#kaibanEx_" + id + "").toggle();

        }

        function goToPreviousPage() {
            if (currentPage - 1 >= 1) {
                goToPage(currentPage - 1);
            }
        }

        function goToNextPage() {
            if (currentPage + 1 <= pageCount) {
                goToPage(currentPage + 1);
            }
        }
        
        $(function () {
            $("#ul_dates li").click(function () {
                $(this).addClass("cur").siblings("li").removeClass("cur");
                $("#date_all").removeClass("cur");
                $("#condition_date").css("display", "").text($(this).text());
                $("#c_journeydates").val($(this).attr("title"));
            }); //行程天数的li
            $("#ul_price li").click(function () {
                $(this).addClass("cur").siblings("li").removeClass("cur");
                $("#price_all").removeClass("cur");
                $("#condition_price").css("display", "").text($(this).text());
                $("#c_adultprice").val($(this).attr("title"));
            }); //价格的li
            $("#ul_outCity li").click(function () {
                $(this).addClass("cur").siblings("li").removeClass("cur");
                $("#outCity_all").removeClass("cur");
                $("#condition_outCity").css("display", "").text($(this).text()).attr("title", $(this).text());
                $("#c_area").val($(this).attr("title"));
            }); //出发城市的li
            $("#tags li span").click(function (e) {
                e.stopPropagation();
            }); //li:span，不能让span触发li的onclick
            $("#tagContent div ul li").click(function () {
                $(this).addClass("no").siblings().removeClass("no");
                //$("#destination_all").removeClass("cur");
                if ($(this).text() != "不限") {
                    $("#condition_destination_city").css("display", "").text($(this).text()).attr("title", $(this).attr("cityid"));
                    $("#c_city").val($(this).attr("cityid"));
                }
                else {
                    $("#condition_destination_city").css("display", "none");
                    $("#c_city").val("");
                }
            }); //二级目的地的li
            $("#ul_product li").click(function () {
                $(this).addClass("cur").siblings("li").removeClass("cur");
                $("#product_all").removeClass("cur");
                $("#condition_product").css("display", "").text($(this).text()).attr("title", $(this).attr("id"));
                $("#c_type").val($(this).attr("title"));
                var traveltypeid = $(this).attr("title");
                $("#tags li[traveltype=" + traveltypeid + "]").css("display", "");
                $("#tags li[traveltype!=" + traveltypeid + "]").css("display", "none");
            }); //产品类型的li
            //下面是各种排序图片的点击
            $("#namedown").click(function () {
                $("#ul_1").empty().append($("<center style='margin-top:100px;'><img src='images/search/loading.gif' /></center>"));
                sortType = "nameDown";
                $(this).attr("src", "images/search/sequence-down.png");
                $("#nameup").attr("src", "images/search/sequence-up1.png");
                $("#priceup").attr("src", "images/search/sequence-up1.png");
                $("#pricedown").attr("src", "images/search/sequence-down1.png");
                $("#timeup").attr("src", "images/search/sequence-up1.png");
                $("#timedown").attr("src", "images/search/sequence-down1.png");
                $.post("getLines_search.ashx", { "condition_outCity": condition_outCity, "condition_typeId": condition_typeId, "condition_days": condition_days, "condition_price": condition_price, "condition_destination": condition_destination, "condition_destination_city": condition_destination_city, "condition_name": condition_name, "condition_minDate": condition_minDate, "condition_maxDate": condition_maxDate, "condition_sellingPoint": condition_sellingPoint, "sortType": sortType, "pageNum": currentPage }, function (data, status) {
                    $("#ul_1").empty().append(data.split("|")[0]);
                });
            });
            $("#nameup").click(function () {
                $("#ul_1").empty().append($("<center style='margin-top:100px;'><img src='images/search/loading.gif' /></center>"));
                sortType = "nameUp";
                $(this).attr("src", "images/search/sequence-up.png");
                $("#namedown").attr("src", "images/search/sequence-down1.png");
                $("#priceup").attr("src", "images/search/sequence-up1.png");
                $("#pricedown").attr("src", "images/search/sequence-down1.png");
                $("#timeup").attr("src", "images/search/sequence-up1.png");
                $("#timedown").attr("src", "images/search/sequence-down1.png");
                $.post("getLines_search.ashx", { "condition_outCity": condition_outCity, "condition_typeId": condition_typeId, "condition_days": condition_days, "condition_price": condition_price, "condition_destination": condition_destination, "condition_destination_city": condition_destination_city, "condition_name": condition_name, "condition_minDate": condition_minDate, "condition_maxDate": condition_maxDate, "condition_sellingPoint": condition_sellingPoint, "sortType": sortType, "pageNum": currentPage }, function (data, status) {
                    $("#ul_1").empty().append(data.split("|")[0]);
                });
            });
            $("#priceup").click(function () {
                $("#ul_1").empty().append($("<center style='margin-top:100px;'><img src='images/search/loading.gif' /></center>"));
                sortType = "priceUp";
                $(this).attr("src", "images/search/sequence-up.png");
                $("#nameup").attr("src", "images/search/sequence-up1.png");
                $("#namedown").attr("src", "images/search/sequence-down1.png");
                $("#pricedown").attr("src", "images/search/sequence-down1.png");
                $("#timeup").attr("src", "images/search/sequence-up1.png");
                $("#timedown").attr("src", "images/search/sequence-down1.png");
                $.post("getLines_search.ashx", { "condition_outCity": condition_outCity, "condition_typeId": condition_typeId, "condition_days": condition_days, "condition_price": condition_price, "condition_destination": condition_destination, "condition_destination_city": condition_destination_city, "condition_name": condition_name, "condition_minDate": condition_minDate, "condition_maxDate": condition_maxDate, "condition_sellingPoint": condition_sellingPoint, "sortType": sortType, "pageNum": currentPage }, function (data, status) {
                    $("#ul_1").empty().append(data.split("|")[0]);
                });
            });
            $("#pricedown").click(function () {
                $("#ul_1").empty().append($("<center style='margin-top:100px;'><img src='images/search/loading.gif' /></center>"));
                sortType = "priceDown";
                $(this).attr("src", "images/search/sequence-down.png");
                $("#nameup").attr("src", "images/search/sequence-up1.png");
                $("#priceup").attr("src", "images/search/sequence-up1.png");
                $("#namedown").attr("src", "images/search/sequence-down1.png");
                $("#timeup").attr("src", "images/search/sequence-up1.png");
                $("#timedown").attr("src", "images/search/sequence-down1.png");
                $.post("getLines_search.ashx", { "condition_outCity": condition_outCity, "condition_typeId": condition_typeId, "condition_days": condition_days, "condition_price": condition_price, "condition_destination": condition_destination, "condition_destination_city": condition_destination_city, "condition_name": condition_name, "condition_minDate": condition_minDate, "condition_maxDate": condition_maxDate, "condition_sellingPoint": condition_sellingPoint, "sortType": sortType, "pageNum": currentPage }, function (data, status) {
                    $("#ul_1").empty().append(data.split("|")[0]);
                });
            });
            $("#timeup").click(function () {
                $("#ul_1").empty().append($("<center style='margin-top:100px;'><img src='images/search/loading.gif' /></center>"));
                sortType = "timeUp";
                $(this).attr("src", "images/search/sequence-up.png");
                $("#nameup").attr("src", "images/search/sequence-up1.png");
                $("#priceup").attr("src", "images/search/sequence-up1.png");
                $("#pricedown").attr("src", "images/search/sequence-down1.png");
                $("#namedown").attr("src", "images/search/sequence-down1.png");
                $("#timedown").attr("src", "images/search/sequence-down1.png");
                $.post("getLines_search.ashx", { "condition_outCity": condition_outCity, "condition_typeId": condition_typeId, "condition_days": condition_days, "condition_price": condition_price, "condition_destination": condition_destination, "condition_destination_city": condition_destination_city, "condition_name": condition_name, "condition_minDate": condition_minDate, "condition_maxDate": condition_maxDate, "condition_sellingPoint": condition_sellingPoint, "sortType": sortType, "pageNum": currentPage }, function (data, status) {
                    $("#ul_1").empty().append(data.split("|")[0]);
                });
            });
            $("#timedown").click(function () {
                $("#ul_1").empty().append($("<center style='margin-top:100px;'><img src='images/search/loading.gif' /></center>"));
                sortType = "timeDown";
                $(this).attr("src", "images/search/sequence-down.png");
                $("#nameup").attr("src", "images/search/sequence-up1.png");
                $("#priceup").attr("src", "images/search/sequence-up1.png");
                $("#pricedown").attr("src", "images/search/sequence-down1.png");
                $("#timeup").attr("src", "images/search/sequence-up1.png");
                $("#namedown").attr("src", "images/search/sequence-down1.png");
                $.post("getLines_search.ashx", { "condition_outCity": condition_outCity, "condition_typeId": condition_typeId, "condition_days": condition_days, "condition_price": condition_price, "condition_destination": condition_destination, "condition_destination_city": condition_destination_city, "condition_name": condition_name, "condition_minDate": condition_minDate, "condition_maxDate": condition_maxDate, "condition_sellingPoint": condition_sellingPoint, "sortType": sortType, "pageNum": currentPage }, function (data, status) {
                    $("#ul_1").empty().append(data.split("|")[0]);
                });
            });

            //加载已有条件
            window.setTimeout(function () {
                if ('<%=journeydates %>') {
                    $("#ul_dates li[title=<%=journeydates %>]").trigger("click");
                }
                if ('<%=adultprice %>') {
                    $("#ul_price li[title=<%=adultprice %>]").trigger("click");
                }
                if ('<%=traveltype %>') {
                    $("#ul_product li[title=<%=traveltype %>]").trigger("click");
                }
                if ('<%=destinationarea %>') {
                    $("#tags li[id=<%=destinationarea%>] a").trigger("click");
                }
                if ('<%=destinationcity %>') {
                    $("#tagContent<%=destinationarea %> li[cityid=<%=destinationcity %>]").trigger("click");
                }
                if ('<%=titlekey %>') {
                    $("#na").val('<%=titlekey %>');
                }
                if ('<%=startdate %>') {
                    $("#startDate").val('<%=startdate %>');
                }
                if ('<%=enddate %>') {
                    $("#endDate").val('<%=enddate %>');
                }
            }, 500);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <div id="route">
            您当前所在位置：<a href="index.aspx">首页</a>&nbsp;->&nbsp;<a href="#" target="_parent"><font
                color="#cd0007">搜索</font></a></div>
        <div class="content">
            <div class="options" style="margin-bottom: 0px;">
                <div class="box">
                    <p class="boxname">
                        行程天数：</p>
                    <div class="rbox">
                        <div class="notto">
                            <a href="javascript:void(0);" class="cur" id="date_all" onclick="conditionAll_trigger('condition_date')">
                                全部</a></div>
                        <ul class="dates" id="ul_dates">
                            <asp:Repeater runat="server" ID="repeaterDates">
                                <ItemTemplate>
                                    <li title='<%#Eval("value") %>'>
                                        <%#Eval("value")%>天</li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="box">
                    <p class="boxname">
                        价格范围：</p>
                    <div class="rbox">
                        <div class="notto">
                            <a href="javascript:void(0);" class="cur" id="price_all" onclick="conditionAll_trigger('condition_price')">
                                全部</a></div>
                        <ul class="dates" id="ul_price">
                            <li title="0-300">300以下</li>
                            <li title="0-600">300-600</li>
                            <li title="600-1000">600-1000元</li>
                            <li title="1000-2000">1000-2000元</li>
                            <li title="2000-5000">2000-5000元</li>
                            <li title="5000-10000">5000-10000元</li>
                            <li title="10000-10000000">10000元以上</li>
                        </ul>
                    </div>
                </div>
                <div class="box">
                    <p class="boxname">
                        产品类型：</p>
                    <div class="rbox">
                        <div class="notto">
                            <a href="javascript:void(0);" class="cur" id="product_all" onclick="conditionAll_trigger('condition_product')">
                                全部</a></div>
                        <ul class="dates" id="ul_product">
                            <asp:Repeater runat="server" ID="repeaterTravelType">
                                <ItemTemplate>
                                    <li title='<%#Eval("traveltypeid") %>'>
                                        <%#Eval("travelTypename") %></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="box box2">
                    <p class="boxname boxname2">
                        目&nbsp;的&nbsp;地：</p>
                    <div class="rbox">
                        <div class="notto notto2">
                            <a href="javascript:void(0);" class="cur" id="destination_all" onclick="conditionAll_trigger('condition_destination')">
                                全部</a></div>
                        <ul id="tags">
                            <asp:Repeater runat="server" ID="RepeaterArea">
                                <ItemTemplate>
                                    <li title="has" id="<%#Eval("areaid") %>" traveltype='<%#Eval("traveltypeid") %>'
                                        class=""><a href="javascript:void(0)" onclick="selectTag('tagContent<%#Eval("areaid") %>',this,1);">
                                            <%#Eval("areaname") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div id="tagContent" style="">
                        <asp:Repeater runat="server" ID="RepeaterAreaInfo" OnItemDataBound="RepeaterAreaInfo_ItemDataBound">
                            <ItemTemplate>
                                <div id="tagContent<%#Eval("areaid") %>" class="tagContent" style="display: none;">
                                    <ul class="normal">
                                        <li class='no' title='buxian'>不限</li>
                                        <asp:Repeater runat="server" ID="RepeaterCity">
                                            <ItemTemplate>
                                                <li cityid='<%#Eval("cityid") %>'>
                                                    <%#Eval("cityname") %></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="box">
                    <p class="boxname">
                        出发城市：</p>
                    <div class="rbox">
                        <div class="notto">
                            <a href="javascript:void(0);" class="cur" id="outCity_all" onclick="conditionAll_trigger('condition_outCity')">
                                全部</a></div>
                        <ul class="dates" id="ul_outCity">
                            <li title="长沙">长沙</li>
                        </ul>
                    </div>
                </div>
                <div class="proname">
                    <span class="names">产品名称：</span><input type="text" class="na" id="na" name="txttitlekey" />
                    <span class="names names1">出发日期：</span><input type="text" style="ime-mode: disabled;
                        border: 1px solid #C3C5C4; width: 130px;" readonly="readonly" id="startDate"
                        name="txtstartdate" class="Wdate da" onclick="WdatePicker({minDate:'%y-%M-{%d+1}',maxDate:'{%y+2}-%M-%d'})"
                        onfocus="this.style.imeMode='inactive'" value="" />--<input type="text" style="ime-mode: disabled;
                            border: 1px solid #C3C5C4; width: 130px;" readonly="readonly" id="endDate" name="txtenddate"
                            class="Wdate da" onclick="WdatePicker({minDate:'%y-%M-{%d+1}',maxDate:'{%y+2}-%M-%d'})"
                            onfocus="this.style.imeMode='inactive'" value="" /><%--<input id="submit_button" type="button"
                                value="" class="searchlinebtn" onclick="submit_condition();" />--%>
                    <asp:Button runat="server" CssClass="searchlinebtn" ID="btnsearch" OnClick="btnsearch_Click" />
                </div>
                <div class="condition">
                    <span class="names">当前条件：</span> <a href="javascript:void(0);" onclick="removeSelf(this,'date_all','ul_dates');"
                        id="condition_date" class="cond" style="display: none;"></a><a href="javascript:void(0);"
                            onclick="removeSelf(this,'price_all','ul_price');" id="condition_price" class="cond"
                            style="display: none;"></a><a href="javascript:void(0);" onclick="removeSelf_province(this);"
                                id="condition_destination" class="cond" style="display: none;" title="" name="condition_destination">
                            </a><a href="javascript:void(0);" onclick="removeSelf_city(this);" id="condition_destination_city"
                                style="display: none;" class="cond" title=""></a><a href="javascript:void(0);" onclick="removeSelf(this,'product_all','ul_product');"
                                    id="condition_product" class="cond" style="display: none;"></a><a href="javascript:void(0);"
                                        onclick="removeSelf(this,'outCity_all','ul_outCity');" id="condition_outCity"
                                        class="cond" style="display: none;"></a><a href="javascript:void(0);" onclick="removeSelf_name(this);"
                                            id="condition_names" class="cond" style="display: none;">
                    </a>
                    <input type="text" id="c_journeydates" name="c_journeydates" style="display: none" />
                    <input type="text" id="c_adultprice" name="c_adultprice" style="display: none" />
                    <input type="text" id="c_type" name="c_type" style="display: none" />
                    <input type="text" id="c_area" name="c_area" style="display: none" />
                    <input type="text" id="c_city" name="c_city" style="display: none" />
                </div>
            </div>
        </div>
        <div class="filter">
            <%--<span style="color: #027438; padding-left: 5px;">排序方式：</span> <span class="name"
                id="name">产品名称<em><img id="namedown" src="images/search/sequence-down1.png" style="cursor: pointer"
                    alt="" /></em><em><img id="nameup" src="images/search/sequence-up1.png" style="cursor: pointer"></em></span>
            <span class="price">价格<em><img id="pricedown" src="images/search/sequence-down1.png"
                style="cursor: pointer" alt="" /></em><em><img id="priceup" src="images/search/sequence-up1.png"
                    style="cursor: pointer" alt="" /></em></span> <span class="date">行程天数<em><img id="timedown"
                        src="images/search/sequence-down1.png" style="cursor: pointer" alt="" /></em><em><img
                            id="timeup" src="images/search/sequence-up1.png" style="cursor: pointer" alt="" /></em></span>
            <div class="conditions">
            </div>
            <div class="statistics">
                <span>查询到 <span style="color: #cf0101;" id="search_resultCount">1</span>条&nbsp; 共 <span
                    style="color: #cf0101;" id="search_pageCount">1</span>页</span>
                <div id="center_p" style="display: inline-block; padding-left: 40px;">
                    <span class="previous"><a href="javascript:void(0);" onclick="goToPage(1)">上一页</a></span><div
                        class="pgcon">
                        <a href="javascript:void(0);" onclick="goToPage(1)">1</a></div>
                    <span class="next"><a href="javascript:void(0);" onclick="goToPage(1)">下一页</a></span></div>
            </div>--%>
            <div class="clear">
            </div>
        </div>
        <div class="filter_list" id="div_filter_list">
            <ul id="ul_1">
                <asp:Repeater runat="server" ID="repeaterdetail">
                    <ItemTemplate>
                        <li style="border-bottom: none;">
                            <div class="icon">
                                <a href="detail.aspx?id=<%#Eval("id") %>" target="_blank">
                                    <img src="<%#Eval("pic") %>" alt="" />
                                    <span class="topicon topicontj">特价</span></a>
                            </div>
                            <div class="detail">
                                <span><a href="detail.aspx?id=<%#Eval("id") %>" target="_blank">
                                    <%#Eval("title") %></a></span>
                                <p>
                                    行程天数：
                                    <%#Eval("journeydays") %>天 出发班期：
                                    <%#Eval("departuretime") %>
                                </p>
                            </div>
                            <div class="brief_detail">
                                <div>
                                    <span class="bold big">￥<span class="bigger">
                                        <%#Eval("adultprice") %></span></span>起</div>
                            </div>
                            <div class="hr_5">
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <center>
            <div id="center_p_Ex" style="display: inline-block;">
                <span class="previous"><a href="javascript:void(0);" onclick="goToPage(1)">第一页</a></span>
                <span class="previous"><a href="javascript:void(0);" onclick="goToPage(1)">上一页</a></span>
                <div class="pgcon">
                    <a href="javascript:void(0);" onclick="goToPage(1)">1</a></div>
                <span class="next"><a href="javascript:void(0);" onclick="goToPage(1)">下一页</a></span>
                <span class="next"><a href="javascript:void(0);" onclick="goToPage(1)">最后一页</a></span>
                <input type="text" value="1" name="pageindex" style="display: none" />
            </div>
        </center>
    </div>
</asp:Content>
