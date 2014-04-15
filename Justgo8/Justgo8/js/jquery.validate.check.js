function checkidcard(card)
{
	card=card.toLowerCase();
	var vcity={ 11:"北京",12:"天津",13:"河北",14:"山西",15:"内蒙古",21:"辽宁",22:"吉林",23:"黑龙江",31:"上海",32:"江苏",33:"浙江",34:"安徽",35:"福建",36:"江西",37:"山东",41:"河南",42:"湖北",43:"湖南",44:"广东",45:"广西",46:"海南",50:"重庆",51:"四川",52:"贵州",53:"云南",54:"西藏",61:"陕西",62:"甘肃",63:"青海",64:"宁夏",65:"新疆",71:"台湾",81:"香港",82:"澳门",91:"国外"};
	var arrint = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2); 
	var arrch = new Array('1', '0', 'x', '9', '8', '7', '6', '5', '4', '3', '2'); 
	var reg = /(^\d{15}$)|(^\d{17}(\d|x)$)/;
	if(!reg.test(card))return false;
	if(vcity[card.substr(0,2)] == undefined)return false;
	var len=card.length;
    if(len==15)   
		reg=/^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})$/;
    else
		reg=/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|x)$/;
    var d,a = card.match(new RegExp(reg));
	if(!a)return false;
	if (len==15){   
		d = new Date("19"+a[2]+"/"+a[3]+"/"+a[4]);     
	}else{   
		d = new Date(a[2]+"/"+a[3]+"/"+a[4]);    
	}   
    if (!(d.getFullYear()==a[2]&&(d.getMonth()+1)==a[3]&&d.getDate()==a[4]))return false;
	if(len=18)
	{
		len=0;
		for(var i=0;i<17;i++)len += card.substr(i, 1) * arrint[i];
		return arrch[len % 11] == card.substr(17, 1);
	}
	return true;
};
//$(function () {
    jQuery.extend(jQuery.validator.messages, {
        required: "必填字段",
        remote: "请修正该字段",
        email: "请输入正确格式的电子邮件",
        url: "请输入合法的网址",
        date: "请输入合法的日期",
        dateISO: "请输入合法的日期 (ISO).",
        number: "请输入合法的数字",
        digits: "只能输入整数",
        creditcard: "请输入合法的信用卡号",
        equalTo: "请再次输入相同的值",
        accept: "请输入拥有合法后缀名的字符串",
        maxlength: jQuery.validator.format("最多 {0} 个字"),
        minlength: jQuery.validator.format("最少 {0} 个字"),
        rangelength: jQuery.validator.format("内容长度请保持在 {0} 到 {1} 个字之间"),
        range: jQuery.validator.format("请输入一个介于 {0} 和 {1} 之间的值"),
        max: jQuery.validator.format("最大为 {0} "),
        min: jQuery.validator.format("最小为 {0} ")
    });
    jQuery.validator.addMethod("Isw", function (value, element) { return this.optional(element) || /^\w+$/.test(value); }, '只能包含英文字母、数字和下划线！');
    jQuery.validator.addMethod("CheckUserName", function (value, element) {
        return this.optional(element) || (/^[\u4e00-\u9fa5\w]+$/.test(value) && /[\u4e00-\u9fa5a-zA-Z_]+/.test(value));
    }, '只能包含中文、数字和下划线(不允许全数字)！');
    jQuery.validator.addMethod("IsRealName", function (value, element) { return this.optional(element) || (/^(([\u4e00-\u9fa5]+)|([a-zA-Z· ]+))$/.test(value)); }, '请填写真实姓名！');
    jQuery.validator.addMethod("CheckQQ", function (value, element) { return this.optional(element) || /^[1-9][0-9]{4,}$/i.test(value); }, "请正确填写您的QQ号码！");
    jQuery.validator.addMethod("byteRangeLength", function (value, element, param) {
        value = $.trim(value); var length = value.length;
        for (var i = 0; i < value.length; i++) { if (value.charCodeAt(i) > 127) { length++; } }
        return this.optional(element) || (length >= param[0] && length <= param[1]);
    }, $.validator.format("请确保输入的值在{0}-{1}个字节之间(一个中文字算2个字节)！"));
    // 手机号码验证
    jQuery.validator.addMethod("isMobile", function (value, element) { return this.optional(element) || /^1((([358])\d{9})|(47\d{8}))$/.test(value); }, "请正确填写您的手机号码！");
    // 身份证号码验证
    jQuery.validator.addMethod("isIDCard", function (value, element) { return this.optional(element) || checkidcard(value); }, "请正确填写身份证号！");
    // 电话号码验证010-12345678
    jQuery.validator.addMethod("isTel", function (value, element) { var tel = /^\d{3,4}-?\d{7,9}$/; return this.optional(element) || (tel.test(value)); }, "请正确填写您的电话号码！");
    // 联系电话(手机/电话皆可)验证
    jQuery.validator.addMethod("isPhone", function (value, element) { var mobile = /^1((([358])\d{9})|(47\d{8}))$/; var tel = /^\d{3,4}-?\d{7,9}$/; return this.optional(element) || (tel.test(value) || mobile.test(value)); }, "请正确填写您的联系电话(手机/电话皆可)！");
    // 邮政编码验证
    jQuery.validator.addMethod("isZipCode", function (value, element) { return this.optional(element) || (/^[0-9]{6}$/.test(value)); }, "请正确填写您的邮政编码！");
    $.validator.setDefaults(
	{
	    errorPlacement: function (error, element) {
	        var ID = element.attr('box') || element.attr('id');
	        if (!ID || error.html() == '') return;
	        error.removeClass().addClass("error").attr("for", ID);
	        if ($("#box_" + ID).length == 0) element.parent().append("<span id=\"box_" + ID + "\"></span>");
	        if ($("#box_" + ID + ">label").size() == 0) {
	            $("#box_" + ID).html(error);
	        } else {
	            var L = $("#box_" + ID + ">label");
	            if ($.trim(L.html()) == '' || L.attr("for") == element.attr('id')) L.attr("for", element.attr('id')).html(error.html());
	            L.removeClass().addClass("error")
	        }
	    },
	    success: function (label) {
	        var ID = label.attr("for");
	        if ($.trim($("#box_" + ID).text()) == '') {
	            $("#box_" + ID + ">label").removeClass('error').addClass("success").html(' ');
	        }
	    },
        ignore:'',
	    focusInvalid: true, // 获得焦点时不验证 
	    onkeyup: false //,debug: true
	});
//});
