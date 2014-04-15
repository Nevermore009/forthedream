var votetype,rlogin=0,voteobj,votea=['cityxq','cityqg','travelstj','travels','visa'];
$(document).ready(function(){
	$('#s_key').focus(function(){//头部搜索框光标
		$('#defaultKey').hide();
	}).blur(function(){
		if(!$.trim($(this).val())){
			$('#defaultKey').show();
			$(this).val('');
		}
	});
	myCity();
	mySearch();
	menuToggle();
	goToTop();
	qrCode();
	onlineService();

	$('a').bind('focus',function() {if(this.blur) {this.blur()};});// 去除a标签点击时的外部虚线
        
        $('.userNavTit1').click(function(){
		$('.userNavText').hide();
		$('.userNavTit2').removeClass().addClass('userNavTit1');
		$(this).removeClass().addClass('userNavTit2');
		$(this).next().show();
	});

	$('#loginout').click(function(){
		$.get(webpath+'sys/ajax/login.ashx',{act:"out"}, function(){
			checklogin();getvote();
		});
	});
	$('#login').click(function(){
		rlogin=2;
		ShowWindow('','alertlogin',webpath+'alertlogin.aspx');
	});
	checklogin();
	voteobj=$('[id^="cityxq_"],[id^="cityqg_"],[id^="travelstj_"],[id^="travels_"],[id^="visa_"]');
	if(voteobj.length>0){
		voteobj.click(function(){
			rlogin=1;
			var id=$(this).attr('id').split('_');
			if($(this).attr('status')==1){
				if(id[0]=='visa'){
					alert('您已经收藏过!');
				}
				return;
			}
			if(id[0]!='travelstj' && GetCookie('username')==''){
				votetype=$(this);
				rlogin=0;
				ShowWindow('','alertlogin',webpath+'alertlogin.aspx');return;
			}
			favorites(
				id[0],
				id[1],
				function(){
					if(arguments[0]=='true'){
						$('#'+id[0]+'_'+id[1]).removeClass('voteyes').addClass('voteno');
						$('#'+id[0]+'text_'+id[1]).text((parseInt($('#'+id[0]+'text_'+id[1]).text())+1));
						if(id[0]=='visa'){
							alert('恭喜您收藏成功!');
						}
					}
				});
		});
		getvote();
	}
});

//头部城市切换
function myCity(){
	$('#cityChange').hover(
		function(){
			$(this).find('.cityList').show();
			$(this).addClass('hover');
		},
		function(){
			$(this).find('.cityList').hide();
			$(this).removeClass('hover');
		}
	);
}

//头部搜索切换
function mySearch(){
	$('#optChange').hover(
		function(){
			$(this).find('dl').show();
			$(this).addClass('hover');
		},
		function(){
			$(this).find('dl').hide();
			$(this).removeClass('hover');
		}
	);

	$('#optChange dd').hover(
		function(){$(this).addClass('cur');},
		function(){$(this).removeClass('cur');}
	).click(
		function(){
			$('.optionCur').html($(this).attr('text'));
			$('#defaultKey').text($(this).attr('defaultkey'));
			$('#optChange').removeClass('hover').find('dl').hide();
			$('#searchform').attr('action',$(this).attr('url'));
			if(!$.trim($('#s_key').val())){
				$('#defaultKey').show();
				$('#s_key').val('');
			}
		}
	).first().click();
}

//左侧菜单
function menuToggle(){
	var arrayli = $('#allClass li');
	arrayli.each(function(i){
		$(this).hover(
			function(){ $(this).addClass('this'); },
			function(){ $(this).removeClass('this'); }
		);
		$(this).find('em').click(function(){ arrayli.removeClass('this'); });
	});
}

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

/*在线客服开始*/
function onlineService(){
	var html = '<div id="fixedService" class="fixedService clearfix" style="z-index:999;">';
	html += '	<div class="outer">';
	html += '		<div class="box">';
	html += '			<div class="hide"><a href="javascript:;" title="关闭在线客服">&nbsp;</a>在线客服</div>';
	html += '			<dl class="clearfix">';
	html += '				<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=867317777&site=qq&menu=yes" rel="nofollow"><img border="0" src="http://wpa.qq.com/pa?p=2:867317777:41" alt="在线客服" title="售前客服直线电话：400-999-7391"/></a>';
	html += '				<dd><a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=1065089966&site=qq&menu=yes" rel="nofollow"><img border="0" src="http://wpa.qq.com/pa?p=2:867317777:41" alt="在线客服" title="售前客服直线电话：400-999-7391"/></a>';
	html += '				<dd><a href="' + webpath + 'About.aspx?id=2" class="tool">关于我们</a></dd>';
	html += '				<dd><a href="' + webpath + 'feedback.aspx" class="tool">意见反馈</a></dd>';
	html += '				<dd><a href="javascript:void(0);" rel="nofollow" onClick=\'$("#setPageDefault").click();\' class="tool">设为首页</a></dd>';
	html += '				<dd class="end"><a href="javascript:void(0);" rel="nofollow" onclick=\'$("#collectSite").click();\' class="tool">收藏本站</a></dd>';
	html += '			</dl>';
	html += '			<div class="tel">400-999-7391</div>';
	html += '		</div>';
	html += '	</div>';
	html += '</div>';
	$(html).appendTo('body');

	$(window).scroll(function(){ //在线客服跟随滚动
		var scrollTop = $(window).scrollTop();
		 $('div#fixedService').stop().animate({top:scrollTop+236});
	});

	$('.fixedService .box .hide a').click(function(){ //在线客服左侧隐藏
		$('#fixedService').animate({width: '0',right: '0'},300);
		$('#fixedService .box').hide();
	});
}
/*在线客服结束*/


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
//投票与收藏
function getvote(){
	if(voteobj.length==0)return;
	var url=webpath + 'sys/ajax/getvote.ashx?t=',adid='',f,f1='';
	for(var i=0;i<votea.length;i++){
		f=voteobj.filter('[id^="'+votea[i]+'_"]');
		if(f.length!=0){
			url+=votea[i]+',';
			f1+='&'+votea[i]+'id=';
			f.each(function(){
				f1+=$(this).attr('id').replace(votea[i]+'_','')+',';
			});
			f1=f1.substring(0,f1.length-1);
		}
	}
	url=url.substring(0,url.length-1)+f1+'&callback=?';
	$.getJSON(url,
		 function(json) {
			for(var i=0;i<json.length;i++){
				for(var j=0;j<json[i].item.length;j++){
					var t=json[i].item[j];
					$('#'+json[i].type+'text_'+t.adid).text(t.votes);
					$('#'+json[i].type+'_'+t.adid).attr('status',t.status);
					if(t.status==1){
						$('#'+json[i].type+'_'+t.adid).removeClass('voteyes').addClass('voteno');
					}else{
						$('#'+json[i].type+'_'+t.adid).removeClass('voteno').addClass('voteyes');
					}
				}
			}
			$('[id^="cityxq_"]').each(function(){
				var adid=$(this).attr('id').split('_')[1];
				if(parseInt($('#cityxqtext_'+adid).text())+parseInt($('#cityxqtext_'+adid).text())<10){
					$('#cityvotelevel_'+adid).removeClass().addClass('s3');
				}
			});
		}
	);
};