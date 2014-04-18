var votetype,rlogin=0,voteobj,votea=['cityxq','cityqg','travelstj','travels','visa'];
$(document).ready(function () {  
//    goToTop();
//    qrCode();
//    $('a').bind('focus', function () { if (this.blur) { this.blur() }; }); // 去除a标签点击时的外部虚线

//    $('.userNavTit1').click(function () {
//        $('.userNavText').hide();
//        $('.userNavTit2').removeClass().addClass('userNavTit1');
//        $(this).removeClass().addClass('userNavTit2');
//        $(this).next().show();
//    });

//    $('#loginout').click(function () {
//        $.get(webpath + 'sys/ajax/login.ashx', { act: "out" }, function () {
//            checklogin(); getvote();
//        });
//    });
//    $('#login').click(function () {
//        rlogin = 2;
//        ShowWindow('', 'alertlogin', webpath + 'alertlogin.aspx');
//    });
//    checklogin();    
});

function goToTop(){ //返回顶部
	var html = '<div id="backTop" class="backTop clearfix" style="z-index;9999"><a title="返回顶部" href="javascript:;" rel="nofollow">&nbsp;</a></div>';
	$(html).appendTo('body');
	$('#backTop').click(function(){
		$('html,body').animate({scrollTop:0},'slow');//慢慢回到页面顶部
		return false;
	});
	$(window).scroll(function(){
		if($(this).scrollTop() < 300) {//当window的垂直滚动条距顶部距离小于300时
			$('#backTop').fadeOut('slow');//goToTop按钮淡出
		} else {
			$('#backTop').fadeIn('slow');//反之按钮淡入
		}
	});
}

function qrCode(){ //二维码
	var html = '<div id="qrCode" class="qrCode clearfix"><a href="javascript:;" rel="nofollow">&nbsp;<div class="item">&nbsp;</div></a></div>';
	$(html).appendTo('body');
	$('#qrCode a').hover(
		function(){$(this).find('.item').show();},
		function(){$(this).find('.item').hide();}
	);
}

//弹出登陆回调
function AlertLoginReturn(){
	checklogin();
	HideWindow();
	if(rlogin==0){
		votetype.click();
	}else if(rlogin==1){
		getvote();
	}
}
//检测登陆
function checklogin(){
	if(GetCookie('username')==''){
		$('#logined').hide();
		$('#unlogin').show();
	}else{
		$('#unlogin').hide();
		$('#logined_name').text(GetCookie('username'));
		$('#logined').show();
	}
}
