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
                for (i = 0; j = document.getElementById("tagContent" + i); i++) {//"tagContent" + i 是包含市城市的外面div
                    j.style.display = "none";
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
        }

        function goToLineView(id) {
            window.open("lineview.aspx?lineno=" + id + "", target = "_blank");
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

        function goToLineView(name) {
            window.open("searchForDIY.aspx?keyWord=" + escape(name) + "");
        }

        $(function () {
            if ("2011111" != "") {
                $("a[title=2011111]").trigger("click");
            }
            setTimeout(function () {
                if ("201111102" != "") {
                    $("li[id=201111102]").trigger("click");
                }
            }, 400);
            setTimeout(function () {
                $("#submit_button").trigger("click");
            }, 1000);
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
                    $("#condition_destination_city").css("display", "").text($(this).text()).attr("title", $(this).attr("id"));
                    $("#c_city").val($(this).attr("title"));
                }
                else {
                    $("#condition_destination_city").css("display", "none");
                }
            }); //二级目的地的li
            $("#ul_product li").click(function () {
                $(this).addClass("cur").siblings("li").removeClass("cur");
                $("#product_all").removeClass("cur");
                $("#condition_product").css("display", "").text($(this).text()).attr("title", $(this).attr("id"));
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
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <div id="route">
            您当前所在位置：<a href="index.aspx">首页</a>&nbsp;->&nbsp;<a href="#" target="_parent"><font
                color="#cd0007">出境旅游</font></a></div>
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
                            <li title='1'>1天</li>
                            <li>2天</li>
                            <li>3天</li>
                            <li>4天</li>
                            <li>5天</li>
                            <li>6天</li>
                            <li>7天</li>
                            <li>8天</li>
                            <li>9天</li>
                            <li>10天</li>
                            <li>11天</li>
                            <li>12天</li>
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
                            <li>100-1000元</li>
                            <li>1000-2000元</li>
                            <li>2000-5000元</li>
                            <li>5000-10000元</li>
                            <li>10000元以上</li>
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
                            <li title="has" id="2011101" class=""><a id="a_tagContent0" title="2011101" href="javascript:void(0)"
                                onclick="selectTag('tagContent0',this,1);">台湾</a></li>
                            <li title="has" id="2011111" class="selectTag"><a id="a_tagContent1" title="2011111"
                                href="javascript:void(0)" onclick="selectTag('tagContent1',this,1);">港澳</a></li>
                            <li title="has" id="2011116" class=""><a id="a_tagContent2" title="2011116" href="javascript:void(0)"
                                onclick="selectTag('tagContent2',this,1);">东南亚</a></li>
                            <li title="has" id="2011121" class=""><a id="a_tagContent3" title="2011121" href="javascript:void(0)"
                                onclick="selectTag('tagContent3',this,1);">韩国</a></li>
                            <li title="has" id="2011126" class=""><a id="a_tagContent4" title="2011126" href="javascript:void(0)"
                                onclick="selectTag('tagContent4',this,1);">日本</a></li>
                            <li title="has" id="2011131" class=""><a id="a_tagContent5" title="2011131" href="javascript:void(0)"
                                onclick="selectTag('tagContent5',this,1);">海岛</a></li>
                            <li title="has" id="2011136" class=""><a id="a_tagContent6" title="2011136" href="javascript:void(0)"
                                onclick="selectTag('tagContent6',this,1);">澳新</a></li>
                            <li title="has" id="2011141" class=""><a id="a_tagContent7" title="2011141" href="javascript:void(0)"
                                onclick="selectTag('tagContent7',this,1);">欧洲</a></li>
                            <li title="has" id="2011146" class=""><a id="a_tagContent8" title="2011146" href="javascript:void(0)"
                                onclick="selectTag('tagContent8',this,1);">美洲</a></li>
                            <li title="has" id="2011151" class=""><a id="a_tagContent9" title="2011151" href="javascript:void(0)"
                                onclick="selectTag('tagContent9',this,1);">非洲中东</a></li>
                            <li title="has" id="2011156" class=""><a id="a_tagContent10" title="2011156" href="javascript:void(0)"
                                onclick="selectTag('tagContent10',this,1);">南亚</a></li>
                            <li title="has_no" id="2011161" class=""><a id="a_tagContent11" title="2011161" href="javascript:void(0)"
                                onclick="selectTag('tagContent11',this,0);">游学</a></li>
                        </ul>
                    </div>
                    <div id="tagContent" style="">
                        <div id="tagContent0" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201110101">台北</li>
                                <li id="201110102">高雄</li>
                                <li id="201110103">日月潭</li>
                                <li id="201110104">阿里山</li>
                                <li id="201110105">台中</li>
                                <li id="201110106">台南</li>
                                <li id="201110107">花莲</li>
                                <li id="201110108">台北故宫</li>
                            </ul>
                        </div>
                        <div id="tagContent1" class="tagContent" style="display: block;">
                            <ul class="normal">
                                <li class="" title="buxian">不限</li>
                                <li id="201111102" class="no">澳门</li>
                                <li id="201111103">海洋公园</li>
                                <li id="201111104">香港迪士尼乐园</li>
                                <li id="201111105">香港</li>
                            </ul>
                        </div>
                        <div id="tagContent2" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201111601">泰国</li>
                                <li id="201111602">普吉</li>
                                <li id="201111603">新加坡</li>
                                <li id="201111604">民丹岛</li>
                                <li id="201111605">马来西亚</li>
                                <li id="201111606">沙巴</li>
                                <li id="201111607">柬埔寨</li>
                                <li id="201111608">越南</li>
                                <li id="201111609">印度</li>
                                <li id="201111610">尼泊尔</li>
                                <li id="201111611">老挝</li>
                                <li id="201111612">不丹</li>
                                <li id="201111613">缅甸</li>
                                <li id="201111614">清迈</li>
                            </ul>
                        </div>
                        <div id="tagContent3" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201112101">首尔</li>
                                <li id="201112102">济州岛</li>
                                <li id="201112103">釜山</li>
                                <li id="201112104">江原道</li>
                            </ul>
                        </div>
                        <div id="tagContent4" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201112601">名古屋</li>
                                <li id="201112602">箱银</li>
                                <li id="201112603">北海道</li>
                                <li id="201112604">冲绳</li>
                                <li id="201112605">大阪</li>
                                <li id="201112606">东京</li>
                                <li id="201112607">京都</li>
                            </ul>
                        </div>
                        <div id="tagContent5" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201113101">马尔代夫</li>
                                <li id="201113102">关岛</li>
                                <li id="201113103">塞班</li>
                                <li id="201113104">巴厘岛</li>
                                <li id="201113105">苏梅</li>
                                <li id="201113106">热浪岛</li>
                                <li id="201113107">兰卡威</li>
                                <li id="201113108">槟城</li>
                                <li id="201113109">长滩</li>
                                <li id="201113110">巴拉望</li>
                                <li id="201113111">帕劳</li>
                                <li id="201113112">岘港</li>
                            </ul>
                        </div>
                        <div id="tagContent6" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201113601">大溪地</li>
                                <li id="201113603">新西兰</li>
                                <li id="201113604">斐济</li>
                                <li id="201113605">澳大利亚</li>
                            </ul>
                        </div>
                        <div id="tagContent7" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201114101">葡萄牙</li>
                                <li id="201114102">爱尔兰</li>
                                <li id="201114103">意大利</li>
                                <li id="201114104">德国</li>
                                <li id="201114105">希腊</li>
                                <li id="201114106">英国</li>
                                <li id="201114107">俄罗斯</li>
                                <li id="201114108">奥地利</li>
                                <li id="201114109">西班牙</li>
                                <li id="201114110">荷兰</li>
                                <li id="201114111">法国</li>
                                <li id="201114112">瑞士</li>
                                <li id="201114113">摩纳哥</li>
                                <li id="201114114">匈牙利</li>
                                <li id="201114115">比利时</li>
                                <li id="201114116">捷克共和国</li>
                                <li id="201114117">斯洛伐克</li>
                                <li id="201114118">丹麦</li>
                                <li id="201114119">瑞典</li>
                            </ul>
                        </div>
                        <div id="tagContent8" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201114601">美国东海岸</li>
                                <li id="201114602">加拿大</li>
                                <li id="201114603">智利</li>
                                <li id="201114604">墨西哥</li>
                                <li id="201114605">美国</li>
                                <li id="201114606">巴西</li>
                                <li id="201114607">美国西海岸</li>
                                <li id="201114608">奥兰多</li>
                                <li id="201114609">阿根廷</li>
                                <li id="201114610">秘鲁</li>
                                <li id="201114611">班夫国家公园</li>
                                <li id="201114612">尼亚加拉大瀑布</li>
                                <li id="201114613">夏威夷</li>
                            </ul>
                        </div>
                        <div id="tagContent9" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201115101">南非</li>
                                <li id="201115102">土耳其</li>
                                <li id="201115103">以色列</li>
                                <li id="201115104">伊朗</li>
                                <li id="201115105">毛里求斯</li>
                                <li id="201115106">塞舌尔</li>
                                <li id="201115107">迪拜</li>
                                <li id="201115108">突尼斯</li>
                                <li id="201115109">肯尼亚</li>
                            </ul>
                        </div>
                        <div id="tagContent10" class="tagContent" style="display: none;">
                            <ul class="normal">
                                <li class="no" title="buxian">不限</li>
                                <li id="201115601">尼泊尔</li>
                                <li id="201115602">斯里兰卡</li>
                                <li id="201115603">印度</li>
                                <li id="201115604">不丹</li>
                                <li id="201115605">老挝</li>
                                <li id="201115606">缅甸</li>
                            </ul>
                        </div>
                        <div id="tagContent11" class="tagContent" style="display: none;">
                            <ul class="normal">
                            </ul>
                        </div>
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
                            <li id="201130300003">常规</li>
                        </ul>
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
                            <li title="HK">长沙</li>
                        </ul>
                    </div>
                </div>
                <div class="proname">
                    <span class="names">产品名称：</span><input type="text" class="na" id="na" />
                    <span class="names names1">出发日期：</span><input type="text" style="ime-mode: disabled;
                        border: 1px solid #C3C5C4; width: 130px;" readonly="readonly" id="startDate"
                        name="startdate" class="Wdate da" onclick="WdatePicker({minDate:'%y-%M-{%d+1}',maxDate:'{%y+2}-%M-%d'})"
                        onfocus="this.style.imeMode='inactive'" value="" />--<input type="text" style="ime-mode: disabled;
                            border: 1px solid #C3C5C4; width: 130px;" readonly="readonly" id="endDate" name="startdate"
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
                                id="condition_destination" class="cond" style="" title="2011111" name="condition_destination">
                                港澳</a> <a href="javascript:void(0);" onclick="removeSelf_city(this);" id="condition_destination_city"
                                    class="cond" style="" title="201111102">澳门</a> <a href="javascript:void(0);" onclick="removeSelf(this,'product_all','ul_product');"
                                        id="condition_product" class="cond" style="display: none;"></a>
                    <a href="javascript:void(0);" onclick="removeSelf(this,'outCity_all','ul_outCity');"
                        id="condition_outCity" class="cond" style="display: none;"></a><a href="javascript:void(0);"
                            onclick="removeSelf_name(this);" id="condition_names" class="cond" style="display: none;">
                        </a>
                    <input type="text" id="c_journeydates" name="c_journeydates" style="display: none" />
                    <input type="text" id="c_adultprice" name="c_adultprice" style="display: none" />
                    <input type="text" id="c_area" name="c_area" style="display: none" />
                    <input type="text" id="c_city" name="c_city" style="display: none" />
                    <input type="text" id="c_type" name="c_type" style="display: none" />
                </div>
            </div>
        </div>
        <div class="filter">
            <span style="color: #027438; padding-left: 5px;">排序方式：</span> <span class="name"
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
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="filter_list" id="div_filter_list">
            <ul id="ul_1">
                <li style="border-bottom: none;">
                    <div class="icon">
                        <a href="http://www.cct.cn/bj/LineView.aspx?lineno=20113120636" target="_blank">
                            <img src="images/search/linesearch_linedefaultimage.png" />
                            <span class="topicon topicontj">特价 </span></a>
                    </div>
                    <div class="detail">
                        <span><a href="http://www.cct.cn/bj/LineView.aspx?lineno=20113120636" target="_blank">
                            【北京出发】*康辉港澳超值自由行*机票+四星/五星酒店</a></span>
                        <p>
                            行程天数：4天 最近出发班期：2014-4-10,2014-4-20 <a href="javascript:void(0);" onclick="getAllKaiban(20113120636);">
                                全部班期</a></p>
                        <span>途经城市：</span></div>
                    <div class="brief_detail">
                        <div>
                            <span class="bold big">￥<span class="bigger">3200</span></span>起</div>
                        <span>2014-4-10出发</span> <span><a class="viewroute" href="http://www.cct.cn/bj/LineView.aspx?lineno=20113120636"
                            target="_blank"></a></span>
                    </div>
                    <div class="hr_5">
                    </div>
                </li>
            </ul>
        </div>
        <center>
            <div id="center_p_Ex" style="display: inline-block;">
                <span class="previous"><a href="javascript:void(0);" onclick="goToPage(1)">上一页</a></span><div
                    class="pgcon">
                    <a href="javascript:void(0);" onclick="goToPage(1)">1</a></div>
                <span class="next"><a href="javascript:void(0);" onclick="goToPage(1)">下一页</a></span></div>
        </center>
    </div>
</asp:Content>
