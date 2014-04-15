var LP=[],occupying, currentLP;
function getlinepricetype(v) {
    var tmp = v + ',';
    if (v == '天天发团') {
        return 0;
    } else if (!tmp.match(new RegExp('^(([0-9]+),)+$', 'i')) == false) {
        return 1;
    } else if (!tmp.match(new RegExp('^([一二三四五六日],)+$', 'i')) == false) {
        return 2;
    } else if (v.indexOf("至") != -1) {
        return 3;
    }
    return 4;
}
function formatlinestartdate() {
    //格式化发团日期
    $('[linestartdate]').each(function () {
        var v = $(this).attr('linestartdate');
        var t = getlinepricetype(v);
        if (t == 1) {
            v = '每月' + v.replace(/,/g, '号,') + '号';
        } else if (t == 2) {
            v = '每周' + v;
        } else if (t == 3) {
            var l = v.indexOf("至");
            var d1 = new Date(Date.parse($.trim(v.substring(0, l)).replace(/-/g, '/')));
            var d2 = new Date(Date.parse($.trim(v.substring(l + 1)).replace(/-/g, '/')));
            v = d1.getFullYear() + '年' + (d1.getMonth() + 1) + '月' + d1.getDate() + '日~' + d2.getFullYear() + '年' + (d2.getMonth() + 1) + '月' + d2.getDate() + '日';
        } else if (t == 4) {
            v = v.replace(/\d{4}\-/g, '');
        }
        t = v.split(',');
        if (t.length > 4) {
            t.length = 4;
            v = t.join(',') + '...';
        }
        $(this).append(v.replace(/,/g, '、'));
    });
}
$(function () {
    formatlinestartdate();
    //满意度
    $('[linereviewss]').each(function () {
        var r = parseInt($(this).attr('linereviewss'));
        var h = parseInt($(this).attr('haoping'));
        $(this).html((r == 0 ? 100 : Math.round(h / r * 100)) + '%');
    });
});
var LC = new Array(),ltm=0,ldxml;
function CalendarPage(c, y, m) {
    CreateCalendar(c, y, m, LC[c][3], LC[c][4],LC[c][5], LC[c][6], LC[c][7]);
}
function CreateCalendar(c, y, m, a, b,d, f,fu) {//c:容器,y:年,m:月,a:出发时间XML,b:参团人群,d:是否天天发团,f:是否显示双日历,fu:回调
    LC[c] = [c, y, m, a, b, d,f, fu];
    var today = new Date(Date.parse(webconfig('date').replace(/-/g, '/')));
    today = new Date(today.getFullYear(),today.getMonth(),today.getDate());
    if (y == 0 || m == 0) { y = today.getFullYear(); m = today.getMonth() + 1; };
	var dmin=Date.parse(a.first().attr('d').replace(/-/g, '/')),dmax =Date.parse(a.last().attr('d').replace(/-/g, '/'));
    var i1 = 0, i2 = 0, i3 = 0, d1 = new Date(dmin), d2;
    today = today.DateToParse();
    if (Date.parse(d1.getFullYear() + '/' + (d1.getMonth() + 1) + '/1') > Date.parse(new Date(y,m-1,1))) {
        y = d1.getFullYear(); m = d1.getMonth() + 1;
    }
    $('#' + c).html('');
	//农历
	//var ca=new Calendar();
	tmp='';	
	for(var i=0;i<=f;i++){
		d1=new Date(y,m-1+i);
		y=d1.getFullYear();
		m=d1.getMonth() + 1;
		
		tmp += '<table cellpadding="0">';
		tmp += '<tr class="month"><th colspan="7"><div class="clearfix"><div class="prevMonth">';
		if(i==0){
			i1=Date.parse(y + '/' + m + '/1');
			d1 = new Date(dmin);
			if(Date.parse(d1.getFullYear() + '/' + (d1.getMonth() + 1) + '/1')<i1){
				d1 = new Date(y,m-2-f,1);
				tmp += '<a class="prev" href="javascript:;" onclick="CalendarPage(\'' + c + '\',' + d1.getFullYear() + ',' + (d1.getMonth() + 1) + ');" title="上个月">&nbsp;</a>';
			}else{
				tmp += '<a class="prev0" href="javascript:;" title="上个月">&nbsp;</a>';
			}
		}
		tmp+='</div>';
		tmp += '<div class="dates"><em>' + y + '</em>年<em>' + m + '</em>月</div>';
		tmp+='<div class="nextMonth">';
		if(i==f){
			i1=Date.parse(y + '/' + m + '/1');
			d1 = new Date(dmax);
			i2=Date.parse(d1.getFullYear() + '/' + (d1.getMonth() + 1) + '/1');
			if(i2>i1){
				d1 = new Date(y,Date.parse(new Date(y,m+1,1))>i2?m-f:m,1);
				tmp += '<a class="next" href="javascript:;" onclick="CalendarPage(\'' + c + '\',' + d1.getFullYear() + ',' + (d1.getMonth() + 1) + ');" title="下个月">&nbsp;</a>';
			}else{
				tmp += '<a class="next0" href="javascript:;" title="下个月">&nbsp;</a>';
			}
		}
		tmp += '</div></div></th></tr>';
		tmp += '  <tr class="week">';
		tmp += '    <th class="weekEnd">星期日</th>';
		tmp += '    <th>星期一</th>';
		tmp += '    <th>星期二</th>';
		tmp += '    <th>星期三</th>';
		tmp += '    <th>星期四</th>';
		tmp += '    <th>星期五</th>';
		tmp += '    <th class="weekEnd">星期六</th>';
		tmp += '  </tr>';
		var maxdays = (new Date(Date.parse(new Date(y,m,1)) - 86400000)).getDate();  //当前月的天数
		d1 = new Date(y,m-1); //要显示的日期
		i1 = d1.getDay(); //这个月的第一天是星期几
		for (var j = 1; j <= 6; j++) {
			tmp += '<tr>';
			for (var k = 1; k <= 7; k++) {
				i2 = (j - 1) * 7 + k - i1;
				if (i2 < 1 || i2 > maxdays) {
					tmp += '<td></td>';
				} else {
					i3 = Date.parse(new Date(y,m-1,i2));
					d1=new Date(i3);
					//农历(ll的值为农历)
					/*var ll=ca.getlf(d1);
					if(ll==''){
						ll=ca.getsf(d1);
						if(ll==''){
							ll=ca.getst(d1)	;
							if(ll=='')ll=ca.getls(d1)[3];
						}
					}*/
					tmp+='<td'
					if (today == i3){tmp+=' class="cur"'};
					if (i3 < dmin || i3 > dmax) {
						tmp += '><p><em>' + i2 + '</em></td>';
					} else {
						tmp += ' week="' + (k - 1) + '" id="' + y + '-' + m + '-' + i2 + '"><p><em>' + i2 + '</em></p></td>';
						
					}
				}
			}
			tmp += '</tr>';
		}
		tmp += '</table>';
	
	}
    $('#' + c).append(tmp);
    var obj,crowdid=0;
	for(var i in currentLP.crowd){
		if(crowdid==0)crowdid=currentLP.crowd[i].id;
	}
	a.each(function(){
		obj=$('#'+$(this).attr('d'));
		var j={d:$(this).attr('d'),n:$(this).attr('n'),c:[]},k=0;
		$(this).children('c').each(function(i){
			if(crowdid==$(this).attr('i'))k=i;
			j.c.push({i:$(this).attr('i'),n:$(this).attr('n'),p:$(this).attr('p')});
		});
		obj.data('i',j).attr('v',1).append('<p><em class="money">'+(j.c[k].p==-1?'电询':'&yen;'+j.c[k].p)+'</em></p><p>余位'+(j.n==-1||j.n>9?'&gt;<em class="money">9</em>':'<em class="money">'+j.n+'</em>')+'</p>');
	});
    if ($.isFunction(fu)){
		$('#' + c +' td[v]').click(function (){ 
			fu(this); 
		}).hover(  function () {
			$(this).addClass("hover");
		  },
		  function () {
			$(this).removeClass("hover");
		  }
		);
	}
}