// JavaScript Document
//返回顶部
$(function(){
$(window).bind('scroll', {
    Online_DivOffsetBottom: parseInt($('#Online_Div').css('bottom'))
},
function(e) {
    var scrollTop = $(window).scrollTop();
    scrollTop > 100 ? $('#Online_Div_box3').show() : $('#Online_Div_box3').hide();
    if (!/msie 6/i.test(navigator.userAgent)) {
        if ($(window).height() -  $(window).scrollTop() > e.data.Online_DivOffsetBottom) {
            $('#Online_Div').css('bottom', $(window).height() - (referFooter.offset().top - $(window).scrollTop()))
        } else {
            $('#Online_Div').css('bottom', e.data.Online_DivOffsetBottom)
        }
    }
});
$('#Online_Div_box3').click(function() {
    $('body,html').stop().animate({
        'scrollTop': 0,
        'duration': 100,
        'easing': 'ease-in'
    })
});
});