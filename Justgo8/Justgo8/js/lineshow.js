var showfeeincludes = 1; //非0为只显示一个
var LineID;
var Comment = { page: 0, status: false, count: 0 };
var Consult = { page: 0, status: false, count: 0 };
var flicker, flickeri = 0;
$(function () {
    LineID = $('#hidelineid').val();
    $('#pricelist>div[rackrate]').each(function (i) {
        var pid = $(this).attr('p_id');
        LP['p_' + pid] = { name: $(this).attr('p_name'), rackrate: $(this).attr('rackrate'), crowd: [], date: null, tqtype: $(this).attr('tqtype') };
        var ul = $(this).children('ul:first');
        ul.children('li').each(function () {
            LP['p_' + pid].crowd['i' + $(this).attr('crowdid')] = { id: $(this).attr('crowdid'), name: $(this).attr('crowdname'), text: $(this).text(), bonus: $(this).attr('bonus'), diyong: $(this).attr('diyong') };
        });
        $('#linePrice').append('<span p_id="' + pid + '">' + LP['p_' + pid].name + '</span>');
        if (showfeeincludes == 0) {
            if (i == 0) {
                $(this).removeClass('ui-tabs-hide');
                $('#pricelist>ul.ui-tabs-nav').append('<li class="ui-tabs-selected"><a href="javascript:;">' + LP['p_' + pid].name + '</a></li>');
            } else {
                $('#pricelist>ul.ui-tabs-nav').append('<li><a href="javascript:;">' + LP['p_' + pid].name + '</a></li>');
            }
        }
        if (i == 0) $(this).removeClass('ui-tabs-hide');
        ul.remove();
    });
    if (showfeeincludes != 0) {
        $('#pricelist>div.ui-tabs-hide,#pricelist>ul.ui-tabs-nav').remove();
    }else{
		$('#pricelist>ul.ui-tabs-nav > li > a').click(function(e){ //Tab切换
			if (e.target == this) {
				var tabs = $(this).parent().parent().children('li');
				var panels = $(this).parent().parent().parent().children('.ui-tabs-panel');
				var index = $.inArray(this, $(this).parent().parent().find('a'));
				if (panels.eq(index)[0]) {
					tabs.removeClass('ui-tabs-selected').eq(index).addClass('ui-tabs-selected');
					panels.addClass('ui-tabs-hide').eq(index).removeClass('ui-tabs-hide');
				}
			}
		});
	}
    $('#linePrice>span').click(function () {
        var p_id = $(this).attr('p_id'), obj;
        $('#o_pricetype').val(p_id);
        if (showfeeincludes == 0) {
            var plist = $('#pricelist>div[rackrate]');
            $('#pricelist>ul.ui-tabs-nav>li').eq(plist.index(plist.filter('[p_id="' + p_id + '"]'))).children('a').click();
        }
        $(this).addClass('cur').siblings().removeClass('cur');
        $('#startdate').empty();
        currentLP = LP['p_' + p_id];
        if (currentLP.tqtype == 2) {
            $('#rackrate').parent().hide();
            $('#person').hide();
            $('#calendarcontainer').html('自定');
            $('#startdate').html('一团一价');
            return;
        } else {
            $('#rackrate').parent().show();
            $('#person').show();
        }
        //获取价格
        if (currentLP.date == null) {
            currentLP.date = $.ajax({ url: webpath + 'sys/ajax/getlinedateprice.ashx', data: 'priceid=' + p_id, async: false }).responseXML;
            LC['calendarcontainer'] = ['', '', '', $(currentLP.date).children('root').children('i'), '', '', 1, function (t) {
                var d = $(t).attr('id');
                if ($('#startdate span[startdate="' + d + '"]').length == 0) $('#startdate span[startdate]:last').after('<span startdate="' + d + '">' + d.substring(5).replace(/-/g, '/') + '</span>');
                //添加出发日期点击事件
                startdateclick();
                $('#startdate span[startdate="' + d + '"]').click();
                var h = document.documentElement.clientHeight, p = $('#linePrice').parent().parent();
                h = (h - p.height()) / 2;
                if (h < 0) h = 0;
                $('html,body').animate({ scrollTop: p.offset().top - h }, 'slow');
                flicker = setInterval(function () {
                    flickeri++;
                    var c = flickeri % 2 ? 'red' : '';
                    var p = $('#linePrice').parent().parent();
                    p.css('border-color', c);
                    if (flickeri > 10) {
                        clearInterval(flicker);
                        p.css('border-color', ''); flickeri = 0;
                    }
                }, 100);
            } ];
        } else {
            LC['calendarcontainer'][3] = $(currentLP.date).children('root').children('i');
        }
        occupying = $(currentLP.date).find('root>occupying').text();
        $("#rackrate").html('&#165;' + currentLP.rackrate);
        //初始化日历
        CalendarPage('calendarcontainer', 0, 0);
        //添加出发日期
        obj = $(LC['calendarcontainer'][3]).filter(':lt(9)');
        obj.each(function () {
            $('#startdate').append('<span startdate="' + $(this).attr('d') + '">' + $(this).attr('d').substring(5).replace(/-/g, '/') + '</span>');
        });
        $('#startdate').append('<span>更多</span>');
        //更新价格列表
        var tmp = '<table width="100%" cellspacing="0"><tr><th width="74">&nbsp;</th><th width="70">价格</th><th width="90">人数</th>';
        //tmp+='<th>余位</th>';
        tmp += '<th class="end">优惠</th></tr>';
        var j = 100;
        for (var i in currentLP.crowd) {
            var v = currentLP.crowd[i];
            if (!!v.name) {
                tmp += '<tr><td>';
                tmp += '<div class="tips" style="z-index:' + j + '">';
                tmp += '	<i class="help">' + v.name + '</i>';
                tmp += '	<div class="tipsCon">';
                tmp += '		<div class="tipsInner">';
                tmp += '			<div class="tipsText"><p>' + v.name + '说明：' + v.text + '</p></div>';
                tmp += '			<small>&nbsp;</small>';
                tmp += '		</div>';
                tmp += '	</div>';
                tmp += '</div>';
                tmp += '</td>';
                tmp += '<td id="c' + v.id + '_price" class="cPrice"></td>';
                tmp += '<td><div class="num"><input type="text" class="number" id="c' + v.id + '" name="c' + v.id + '" value="0" maxlength="3"/><strong><a href="javascript:;" class="plus">&nbsp;</a><a href="javascript:;" class="minus">&nbsp;</a></strong></div></td>';

                tmp += '<td class="end">';
                tmp += '	<div class="tips" style="z-index:' + j + '">';
                tmp += '		<ul class="quan clearfix" id="c' + v.id + '_sd">';
                tmp += '			<li class="diyong"><span>' + v.diyong + '元</span></li>';
                tmp += '			<li class="bonus"><span>' + v.bonus + '元</span></li>';
                tmp += '		</ul>';
                tmp += '		<div class="tipsCon">';
                tmp += '			<div class="tipsInner">';
                tmp += '				<div class="tipsText">';
                tmp += '					<p><b class="diyong">&nbsp;</b>预订此产品使用抵用券，每位' + v.name + '可抵扣<em>' + v.diyong + '</em>元现金。</p>';
                tmp += '					<p><b class="bonus">&nbsp;</b>旅游结束后发表点评，赠送【<em>' + v.bonus + '</em>元x' + v.name + '人数】抵用券。</p>';
                tmp += '				</div>';
                tmp += '				<small>&nbsp;</small>';
                tmp += '			</div>';
                tmp += '		</div>';
                tmp += '	</div>';
                tmp += '</td>';
                j--;
            }
        }
        obj = $('#person');
        obj.empty().append(tmp + '</table><div id="bxmsg"></div>');
        $('#person .tips').hover( //提示说明隐藏和显示
			function () { $(this).find('.tipsCon').show(); },
			function () { $(this).find('.tipsCon').hide(); }
		);
        //出游人数更换
        obj.find('input').inputOnlyNum(); //只能输入数字
        obj.find('input').blur(function () {
            var t = $(this).val();
            if (t == '' || t == 0) { $(this).val(0); return; };
            t = parseInt(t);
            var m = surplus($(this).attr('id').replace('c', ''));
            if (m != -1 && t > m) $(this).val(m);
        });
        obj.find('.minus').click(function () {//减少
            var o = $(this).parent().siblings('input'), v = o.val();
            if (o.attr('disabled') || v == '' || parseInt(v) < 1) { o.val(0); return false; }
            o.val(parseInt(v) - 1);
        });
        obj.find('.plus').click(function () {//增加
            var o = $(this).parent().siblings('input');
            if (o.attr('disabled')) { o.val(0); return false; }
            var t = parseInt(o.val()), m = surplus(o.attr('id').replace('c', ''))
            t++;
            if (m != -1 && t > m) t = m;
            if (t > 999) t = 999;
            o.val(t);
        });
        //添加出发日期点击事件
        startdateclick();
        $('#startdate span:first').click();
    });

    if ($('#linePrice>span').length == 0) {
        
    } else {
        $('#linePrice>span:first').click();
    }
    $('#booking').click(function () {
        if (currentLP.tqtype != 2) {
            var s = 0, t = true;
            $('#person input').each(function () {
                s += parseInt($(this).val());
                if (t) t = ($('#' + $(this).attr('id') + '_price').text() != '电询');
            });
            if (s == 0) {
                alert(t ? '请填写出游人数!' : '请电话咨询');
                return;
            }
        }
        var url = link['linebooking'] + 'startdate=' + $('#o_startdate').val() + '&pricetype=' + $('#o_pricetype').val() + '&' + $('#person input:visible').serialize();
        if (GetCookie('username') != '') { location = url; return; }
        ShowWindow('', '', webpath + 'BookingLogin.aspx?Page=' + URLencode(url));
    });
});
function startdateclick() {
    $('#startdate span').unbind().click(function () {
        var d = $(this).attr('startdate'), zw1 = 0, zw2 = '', zw3 = '';
        if (!d) {
            $('.mainCon>.ui-tabs-nav:first>li:first>a').click();
            $('html,body').animate({ scrollTop: $('#calendarcontainer').offset().top - 90 }, 'slow');
        } else {
            $('#o_startdate').val(d);
            $(this).addClass('cur').siblings().removeClass('cur');
            var s = 0;
            var obj = $(LC['calendarcontainer'][3]).filter('i[d="' + d + '"]'), cn = obj.attr('n');
            if (cn == -1) cn = "不限";
            obj.children('c').each(function () {
                var p = $(this).attr('p') == -1 ? '电询' : '&#165;' + $(this).attr('p'), n = $(this).attr('n') == -1 ? '不限' : $(this).attr('n'), i = $(this).attr('i');
                $('#c' + i + '_price').html(p);
                $('#c' + i).val(0);
                if (p == '电询') {
                    $('#c' + i).parent().contents().hide();
                    $('#c' + i + '_number').empty();
                    $('#c' + i + '_sd').hide();
                } else {
                    $('#c' + i + '_sd').show();
                    $('#c' + i).parent().contents().show();
                    if (n == 0 || cn == 0) {
                        $('#c' + i + '_number').html(0);
                        $('#c' + i).val(0).attr('disabled', true).siblings('em').hide();
                    } else {
                        if (n == '不限') {
                            zw2 += '+' + currentLP.crowd['i' + i].name + '人数';
                        } else {
                            zw1 += parseInt(n);
                            zw3 += '、' + currentLP.crowd['i' + i].name;
                        }
                        $('#c' + i).attr('maxvalue', n);
                        $('#c' + i + '_number').html(n);
                        if (s == 0) { $('#c' + i).val(1); s = 1; }
                    }
                }
            });
            $('#bxmsg').hide();
            if (cn != '不限' && cn != 0 && zw2 != '' && zw3 != '') {
                $('#bxmsg').show();
                if (occupying != '') {
                    $('#bxmsg').html("注：当您预订的 " + zw2.substring(1) + '>' + (parseInt(cn) - zw1) + '时,可占用 ' + zw3.substring(1) + '的配额。');
                } else {
                    $('#bxmsg').html("注：您预订的 " + zw2.substring(1) + '不能大于' + (parseInt(cn) - zw1) + '。');
                }
            }
        }
    });
}
function surplus(c) {
    var x = $(currentLP.date).find('root>i[d="' + $('#o_startdate').val() + '"]');
    var cn = parseInt(x.attr('n')), m = parseInt(x.find('c[i="' + c + '"]').attr('n'));
    if (cn == -1 | !occupying) return m;
    var s = 0;
    if (!occupying) {
        x.find('c:not([i="' + c + '"])').each(function () {
            if ($(this).attr('n') == '-1') {
                s += parseInt($('#c' + $(this).attr('i')).val());
            } else {
                s += parseInt($(this).attr('n'));
            }
        });
        return cn - s;
    } else {
        for (var i in currentLP.crowd) {
            if (!!currentLP.crowd[i].id && currentLP.crowd[i].id != c) {
                cn -= parseInt($('#c' + currentLP.crowd[i].id).val());
            }
        }
        if (m == -1) {
            return cn;
        } else {
            return cn > m ? m : cn;
        }
    }
}
//点评加载
function LoadComment() {
    if (Comment.page == 0 || Comment.page < Comment.count) {
        Comment.page++;
        var html = $.ajax({ url: webpath + 'line/reviews.aspx?id=' + LineID + '&page=' + Consult.page, async: false }).responseText;
        var obj = $(html);
        Comment.count = parseInt(obj.filter('div[PageCount]').attr('PageCount'));
        var obj = obj.find('div.item'), o = $('#scrollComment>div.viewport>div.overview');
        if (obj.length == 0) {
            o.append('<p class=""noRecord"">该产品暂无点评信息，快来抢占沙发哟！</p>');
        } else {
            var ratingA = ['差', '中', '好', '很好', '非常好'];
            obj.each(function () {
                $(this).find('.type').html(Math.round(parseInt($(this).attr('count')) / 20 * 100) + '%');
                $(this).find('span[rating]').each(function () {
                    $(this).html(ratingA[parseInt($(this).attr('rating')) - 1]);
                });
            });
            o.append(obj).find('img[data-original]').lazyload();
        }
        if (Comment.count < 2) {
            if (o.height() < 600) {
                $('#scrollComment').removeClass('myScroll').children('div.scrollbar').remove();
            } else {
                $('#scrollComment').tinyscrollbar();
            }
            return;
        }
        if (Comment.page == 1) {
            $('#scrollComment').tinyscrollbar({ callback: function (h, p) {
                if (parseInt(p.obj.css('bottom').replace('px', '')) < 100) {
                    LoadComment();
                }
            } 
            });
        } else {
            $('#scrollComment').tinyscrollbar_update('relative');
        }
    }
}
//咨询加载
function LoadConsult() {
    if (Consult.page == 0 || Consult.page < Consult.count) {
        Consult.page++;
        var html = $.ajax({ url: webpath + 'line/questions.aspx?id=' + LineID + '&page=' + Consult.page, async: false }).responseText;
        var obj = $(html);
        Consult.count = parseInt(obj.filter('div[PageCount]').attr('PageCount'));
        var obj = obj.find('div.item'), o = $('#scrollConsult>div.viewport>div.overview');
        if (obj.length == 0) {
            o.append('<p class=""noRecord"">该产品暂无咨询信息！</p>');
        } else {
            o.append(obj);
        }
        if (Consult.count < 2) {
            if (o.height() < 600) {
                $('#scrollConsult').removeClass('myScroll').children('div.scrollbar').remove();
            } else {
                $('#scrollConsult').tinyscrollbar();
            }
            return;
        }
        if (Consult.page == 1) {
            $('#scrollConsult').tinyscrollbar({ callback: function (h, p) {
                if (parseInt(p.obj.css('bottom').replace('px', '')) < 100) {
                    LoadConsult();
                }
            } 
            });
        } else {
            $('#scrollConsult').tinyscrollbar_update('relative');
        }
    }
}
$(document).ready(function () {
	if($('#myFocusShow a').length>0){
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
	var DT=$('#Details_nav').offset().top;
	$('#Details_nav>li').click(function(){
		var s=$('#Details_nav>li').index(this);
		$(window).scrollTop($('.mainCon>.ui-tabs-panel:eq('+s+')').offset().top-30);
	});
	$(window).scroll(function(){
		var wt=$(window).scrollTop(),l=$('.mainCon>.ui-tabs-panel'),s=l.length-1;
		if(wt<DT||wt>=l.last().offset().top+l.last().height()+30){
			$('#Details_nav').removeClass('aa');
			$('#Details_nav>li:first').addClass('ui-tabs-selected').siblings().removeClass('ui-tabs-selected');
		}else{
			$('#Details_nav').addClass('aa');
			for(var i=0;i<s;i++){
				if(wt>=parseInt(l.eq(i).offset().top-30)&&wt<parseInt(l.eq(i+1).offset().top-30)){
					s=i;
					break;
				}
			}
			$('#Details_nav>li:eq('+s+')').addClass('ui-tabs-selected').siblings().removeClass('ui-tabs-selected');
		}
	});
	LoadComment();
	var obj = $('#scrollComment');
	var rating = [parseInt(obj.attr('rating_0')), parseInt(obj.attr('rating_1')), parseInt(obj.attr('rating_2')), parseInt(obj.attr('rating_3'))], reviewss = parseInt(obj.attr('reviewss'));
	if (reviewss > 0) {
		$('.mark2').find('dl').each(function (i) {
			var v = Math.round(rating[i] / (reviewss * 5) * 100);
			if (v > 0 && v <= 100) {
				$(this).find('.d1 div').width(v + '%');
				$(this).find('.d2').html(v + '%');
			}
		});
	}
	LoadConsult();
	$("#questionform").validate({
		rules: {
			Questions: { required: true, rangelength: [10, 200] },
			Proof: { required: function () { if ($('#Proof').val() == '请输入验证码') $('#Proof').val(''); return true; },
				remote: { url: webpath + 'Sys/Ajax/Check.ashx', type: 'get', dataType: 'json', data: { 'checktext': function () { return $('#Proof').val(); } }, cache: false }
			}
		},
		messages: {
			Questions: { required: '请填写内容' },
			Proof: { required: '请填写验证码!', remote: function () { get_Code(webpath); return '验证码错误!' } }
		}, submitHandler: function (form) {
			var json;
			if (webconfig('linequestionlogined') == 'True' && GetCookie('username') === '') {
				var UN = escape($.trim($('#q_username').val()));
				var UP = escape($.trim($('#q_userpass').val()));
				$.ajax({ type: "GET", url: webpath + 'sys/ajax/login.ashx?u_name=' + UN + '&U_Pass=' + UP + '&callback=?', dataType: "json", async: false, success: function (msg) { json = msg; } });
				if (json.err != '') {
					alert(json.err);
					return false;
				}
				json = null;
				checklogin();
				$('#q_login').hide();
				$('#q_username').rules('remove');
				$('#q_userpass').rules('remove');
			}
			$.ajax({ type: "POST", url: webpath + 'sys/ajax/PostReviews.ashx?id=' + LineID + '&t=linequestions&callback=?', dataType: "json", async: false, data: $(form).serialize(), success: function (msg) { json = msg; } });
			get_Code(webpath);
			$('#Proof').val('');
			$('#Questions').val('');
			if (json.err != '') {
				alert(json.err);
				return false;
			}
			Consult.page = 0;
			Consult.count = 0;
			$('#scrollConsult>div.viewport>div.overview').empty();
			LoadConsult();
		}
	});
	if (webconfig('linequestionlogined') == 'True' && GetCookie('username') === '') {
		$('#q_login').show();
		$('#q_username').rules('add', { required: true });
		$('#q_userpass').rules('add', { required: true });
	} else {
		$('#q_longin').hide();
	}
	var travel = $('#TravelContainer').find('div[name="travel"]');
	if (travel.length == 0) {
		$('img[data-original]').lazyload();
		return;
	};
	var tmp = '', tmp1, ta, obj, nav = '<div class="daysNav"><div class="box"><ul class="clearfix">', days = travel.find('div[name="day"]');
	days.each(function (i) {
		if (i == 0) {
			nav += '<li><a id="d1" class="cur" href="javascript:;">第<em>1</em>天</a></li>';
		} else {
			nav += '<li><a id="d' + (i + 1) + '" href="javascript:;">第<em>' + (i + 1) + '</em>天</a></li>';
		}
		tmp += '<dl class="d' + (i + 1) + ' clearfix">';
		tmp += '	<dt>第<em>' + (i + 1) + '</em>天</dt>';
		tmp += '	<dd>';
		tmp += '		<ul class="dayInfo clearfix">';
		tmp += '			<li class="scenery">';
		tmp += '				<b class="go">行程</b>' + $(this).find('[name="title"]:first').html() ;
		tmp += '			</li>';
		var dining = $(this).find('[name="dining"]').text();
		tmp += '			<li><b class="food">用餐</b>早餐：' + (dining.indexOf('早餐') == -1 ? '敬请自理' : '含') + ' 午餐：' + (dining.indexOf('中餐') == -1 ? '敬请自理' : '含') + ' 晚餐：' + (dining.indexOf('晚餐') == -1 ? '敬请自理' : '含') + '</li>';
		tmp += '			<li><b class="stay">住宿</b>' + $(this).find('[name="stay"]').text() + '</li>';
		tmp += '		</ul>';
		tmp += '		<div class="dayDesc clearfix">';
		$(this).find('[name="activity"]').each(function () {
			tmp += '		<div class="theme"><b>' + $(this).find('[name="title"]').text() + '</b></div><div class="reset clearfix">' + $(this).find('[name="text"]').html() + '</div>';
		});
		tmp += '		</div>';
		var sid = $(this).find('[name="sceneryid"]').text();
		if (sid != '') {
			tmp1 = '';
			ta = sid.split(',');
			for (var j = 0; j < ta.length; j++) {
				obj = $('#citypiclist').find('[d_id="' + ta[j] + '"]');
				if (obj.length > 0) {
					tmp1 += '<li><a href="' + obj.attr('url') + '" title="' + obj.attr('p_title') + '" target="_blank"><img src="' + webpath + 'images/loading.gif" data-original="' + obj.attr('p_pic') + '" height="113" width="150" alt="' + obj.attr('p_title') + '"/><div class="bg">&nbsp;</div><div>' + obj.attr('p_title') + '</div></a></li></li>';
				}
			}
			if (tmp1 != '') {
				tmp += '<div class="dayWays clearfix"><h3 class="hd"><b>途经景点</b></h3><div class="wrap"><ul class="clearfix">' + tmp1 + '</ul></div></div>';
			}
		}
		//obj = $(this).find('[name="self"]');
		//if (obj.length > 0) {
			//tmp += '<div class="shop clearfix"><div class="wrap"><table width="100%" cellspacing="0"><tr><th width="200">自费项目名称</th><th width="70">参考价格</th><th>备注说明</th></tr>';
			//obj.each(function () {
				//tmp += '<tr><td>' + $(this).find('[name="title"]').text() + '</td><td>' + $(this).find('[name="price"]').text() + '</td><td class="left">' + $(this).find('[name="text"]').text() + '</td></tr>';
			//});
			///tmp += '</table></div></div>';
		//}
		//obj = $(this).find('[name="shop"]');
		//if (obj.length > 0) {
			//tmp += '<div class="shop"><div class="wrap"><table width="100%" cellspacing="0"><tr><th width="200">购物信息/名称</th><th width="70">停留时间</th><th width="180">营业产品</th><th>备注说明</th></tr>';
			//obj.each(function () {
				//tmp += '<tr><td>' + $(this).find('[name="name"]').text() + '</td><td>' + $(this).find('[name="stop"]').text() + '</td><td class="left">' + $(this).find('[name="product"]').text() + '</td><td class="left">' + $(this).find('[name="text"]').text() + '</td></tr>';
			//});
			//tmp += '</table></div></div>';
		//}
		tmp += '</dd></dl>';
	});
	$('#TravelContainer').html(tmp);
	$('.mainCon').append(nav + '</ul></div></div>');
	/*参考行程天数悬浮导航开始*/
	$(window).scroll(function () {
		var scrollTop = $(window).scrollTop()  + 77;
		$('div.daysNav').stop().animate({ top: scrollTop });
	}).scroll();

	$('div.daysNav').find('a').click(
		function () {
			$('div.daysNav a').removeClass('cur');
			$(this).addClass('cur');
			var day = $(this).attr('id');
			var pos = $('.' + day).offset().top-30; // 定义将要去的描点位置
			$('html,body').animate({ scrollTop: pos }, 1000); // 实现平滑移动 1000代表时间ms
		}
	);
	/*参考行程天数悬浮导航结束*/
	$('img[data-original]').lazyload();
    if ($('#marquee li').length > 4) $('#marquee').scrollShow('right'); //相关线路无缝滚动
});