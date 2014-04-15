/*首页里面的特效*/
var c = 0;
var s = 0;
var clock;
$(function () {
    c = $("#divbanner ul li").size();
    bannermouseover();
    bannerlist();
});
function banner() {
    if (s >= c)
        s = 0;
    $("#divbanner ul li a").each(function (index, value) {
        $(this).attr("class", "");
    });
    $("#divimagebanner a").each(function () {
        $(this).css("display", "none");
    });
    $("#divbanner ul li a").eq(s).attr("class", "hover");
    $("#divimagebanner a").eq(s).css("display", "block");
    s++;
}
function bannerlist() {
    clock = window.setInterval("banner()", 3000);
}
function bannermouseover() {
    $("#divbanner ul li").each(function (index) {
        $(this).bind("mouseover", function () {
            $("#divbanner ul li a").each(function () {
                $(this).attr("class", "");
            });
            $("#divimagebanner a").each(function () {
                $(this).css("display", "none");
            });
            $("#divbanner ul li a").eq(index).attr("class", "hover");
            $("#divimagebanner a").eq(index).css("display", "block");
            window.clearInterval(clock);
        });
        $(this).bind("mouseout", function () {
            clock = window.setInterval("banner()", 3000);
        });
    });
}

/*首页里面的特效*/



/**   机票+酒店   search_tab**/
function tabs(n, len, x, y) {
    for (var i = 1; i <= len; i++) {
        document.getElementById('tab_' + y + i).style.display = (i == n) ? 'block' : 'none';
        document.getElementById('tab_' + x + i).className = (i == n) ? 'aaa' : 'none';
    }
}
var timeout;
function delayChangeTab(m, n, len, x, y) {  //len tab数量   判定不同的tab,x,y
    timeout = setTimeout('tabs(' + m + ',' + len + ',' + x + ',' + y + ')', n);
}
function cancelChangeTab() {
    clearTimeout(timeout);
}
/**   机票+酒店   search_tab结束**/ 
