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