
var latestedDialogFocusID=false;
//弹出一个提示框，只包含确定按纽。
function ShowMsg(msg,afterDo)
{
    window.focus();
    var top=(document.body.scrollTop==0||document.body.scrollTop==null)?document.documentElement.scrollTop:document.body.scrollTop;//隐藏了的高度
    var Allheight=document.documentElement.clientHeight;//整个页面高度
    var height=Allheight+top;//最终高度
    var middleTop=top+(Allheight)/2-70;//剧中窗口的高度
    var code = "<div class='dialog-container'><table cellspacing='0' cellpadding='0'><tr><td class='dialog-title'>&nbsp;上海尧钢钢铁贸易有限公司提示您：</td></tr><tr><td class='dialog-content'>" + msg + "</td></tr><tr><td align='center' class='dialog-control'><input type='button' value='确 定' name='ok'/></td></tr></table></div>";
    var obj = $(code);
    var id = showShadow();
    obj.prependTo(document.body);
    $("[name=ok]",obj).focus().click(function(){
        obj.remove();
        $("#"+id).remove();
        if(afterDo) eval(afterDo)();
    });
    obj.keydown(function(code){
        if(code.keyCode == 27)
        {
            $("[name=ok]",obj).click();
        }
    });
    showDialog(obj.get(0),true);
}

//弹出提示框，数据加载中，覆盖整个浏览器窗口，半透明。
function ShowLoading(msg)
{
    if(!msg)msg="系统正在读取数据，请稍后...";
    var code = "<table id='div_loading' class='dialog-loading'><tr valign='middle'><td align='center'><img src='/img/loading.gif' class='dialog-waitImg'/> "+msg+" </td></tr></table>";
    var obj = $(code);
    obj.appendTo(document.body);
    _fullscreenIDs.push(showShadow("White"));
    showDialog("div_loading",true);
}

//弹出LOADING
function AjaxLoading(msg)
{
    ShowLoading(msg);
    $("#div_loading").ajaxComplete(function(){
        CloseFullScreenMsg();
    });
    $("#div_loading").ajaxError(function(event, xmlHttp, settings, exception){
        var txtTD = $("#divloding_msg");
        exception = "出现错误,可能是服务器负载过高! ";
        if(xmlHttp.readyState == 4)
        {
   　       switch(xmlHttp.status)
   　       {
   　           case 404:
   　               exception = "请求的资源未找到";
   　               break;
   　       }
        }
        else
            if(!exception)exception = "请求超时，已停止！";
        txtTD.html(exception);
        txtTD.append("<a onclick='CloseFullScreenMsg()' style='text-decoration:underline;cursor:pointer;'> 【点此关闭】</a>");
        settings.global = false;
    });
}

//关闭全屏遮盖。
function CloseFullScreenMsg()
{
    if($("#divFullScreen"))
        $("#divFullScreen").remove();
    if($("#div_loading"))
        $("#div_loading").remove();
    for(var i=0;i<_fullscreenIDs.length;i++)
    {
        $("#"+_fullscreenIDs[i]).remove();
    }
}
//弹出对话框，包含“是”“否”按纽。
function ShowYesNo(msg,YesCallBack,NoCallBack)
{
    window.focus();
    var code = "<div class='dialog-container'><table cellspacing='0' cellpadding='0'><tr><td class='dialog-title'>&nbsp;上海尧钢钢铁贸易有限公司提示您：</td></tr><tr><td class='dialog-content'>" + msg + "</td></tr><tr><td align='center' class='dialog-control'><input type='button' name='yes' value='确  定'/>&nbsp;&nbsp;&nbsp;&nbsp;<input type='button' name='no' value='取  消'/></td></tr></table></div>";
    var obj = $(code);
    var id = showShadow();
    obj.appendTo(document.body);
    $("[name=yes]",obj).click(function(){
        if(YesCallBack)
            eval(YesCallBack)();
        obj.remove();
        $("#"+id).remove();
    }).focus();
    $("[name=no]",obj).click(function(){
        if(NoCallBack)
            eval(NoCallBack)();
        obj.remove();
        $("#"+id).remove();
    });
    obj.keydown(function(code){
        if(code.keyCode == 27)
        {
            $("[name=no]",obj).click();
        }
    });
    showDialog(obj.get(0),true);
}
//一个滑动弹出的对话框，弹出2秒后会自动消失，可以设置持续的时间。可用于操作成功时提示用户。
function ShowSlidMsg(msg,time)
{
    if($("#divflash"))$("#divflash").remove();
    if($("#div_loading"))$("#div_loading").remove();
    if($("#divFullScreen"))$("#divFullScreen").remove();
    if(!time)time = 2000;
    var code = "<div class='dialog-container' style='width:260px;'><table style='width:260px;height:70px;' cellspacing='0' cellpadding='0'><tr><td class='dialog-title'>&nbsp;&nbsp;中国钢铁现货网提示您:</td></tr><tr><td class='dialog-content'>"+msg+"</td></tr></table></div>";
    var obj = $(code);
    obj.appendTo(document.body);
    obj.hide().slideDown('slow');
    showDialog(obj.get(0),true);
    //消失
    window.setTimeout(function(){obj.slideUp('slow',function(){obj.remove();});},time);
}
//在一个容器上面显示一个遮罩层。并显示一个消息。target 是jquery的查找器或者是jquery对象。
function ShowConainerWait(target,msg)
{
    if(typeof(target) == 'string')
        target = $(target);
    if(target.size() == 0) return;
    target.css("position","relative");
    var obj = $("<div class='dialog-divfull'></div>");
    obj.width(target.width()).height(target.height()).appendTo(target);
    var cot = $("<table class='dialog-divmsg'><tr><td align='center' valign='middle'></td></tr></table>");
    $("td:first",cot).append("<img style='vertical-align:middle;' src='/img/loading.gif'/>");
    if(msg) $("td:first",cot).append(msg);
    target.append(cot);
    cot.css("left",(target.width()-cot.width())/2).css("height",(target.height()-cot.height())/3);
}
//关闭层上面的遮罩。
function CloseContainerWait(target)
{
    $(".dialog-divfull,.dialog-divmsg",target).remove();
}
var _dialogIdArray = new Array();
function moveWithScroll(id)
{
    if($.browser.msie && $.browser.version == '6.0')
    {
        _dialogIdArray.push(id);
    }
    else $("#" + pid).css("position",'fixed');
    $(document).resize(OnChgSize).scroll(OnChgSize);
}
function OnChgSize()
{
    for(var i=0,a=_dialogIdArray.length;i<a;i++)
    {
        showDialog(_dialogIdArray[i],false);
    }
}
function showDialog(id,ac,shad)//ac是否注册事件，当窗口大小改变或者移动滚动条时重新将其显示到中间 shad是否显示遮罩层，如果显示则会返回该遮罩层的ID。
{
    var tg;
    if(typeof(id) == "string")
        tg = document.getElementById(id);
    else
        tg = id;
    if(!tg) return;
    var im = getWindowInfo();
    var tt = (im.Height  - tg.offsetHeight) / 2 + im.ScrollY;
    var tl = (im.Width - tg.offsetWidth) / 2 + im.ScrollX;
    if(tt<0) tt=0;
    if(tl<0) tl=0;
    tg.style.left = tl + "px";
    tg.style.top = tt + "px";
    if(ac)
    {
        _dialogIdArray.push(id);
    }
    if(shad) return showShadow();
}
function showShadow(color)
{
    if(!color)color='Black';
    var id = "id_" + new Date().getTime();
    var wimfor = getWindowInfo();
    var element = document.createElement("iframe");
    element.id = id;
    element.style.width = wimfor.ContentWidth + "px";
    element.style.height = wimfor.ContentHeight + "px";
    element.style.left = 0;
    element.style.top = 0;
    element.style.position = "absolute";
    element.style.border = "none";
    element.style["opacity"] = ".6";
    element.style["filter"] = "Alpha(Opacity=60)";
    element.frameborder = '0';
    document.body.appendChild(element);
   
    return id;
}
function getWindowInfo()//获取窗口位置及窗口大小返回对象{ScrollX:11,ScrollY:11,Width:11,Height:11,ContentWidth:11,ContentHeight:11}
{
    var scrollX=0,scrollY=0,width=0,height=0,contentWidth=0,contentHeight=0;
    if(typeof(window.pageXOffset)=='number')
    {
        scrollX=window.pageXOffset;
        scrollY=window.pageYOffset;
    }
    else if(document.body&&(document.body.scrollLeft||document.body.scrollTop))
    {
        scrollX=document.body.scrollLeft;
        scrollY=document.body.scrollTop;
    }
    else if(document.documentElement&&(document.documentElement.scrollLeft||document.documentElement.scrollTop))
    {
        scrollX=document.documentElement.scrollLeft;
        scrollY=document.documentElement.scrollTop;
    }

    if(typeof(window.innerWidth)=='number')
    {
        width=window.innerWidth;
        height=window.innerHeight;
    }
    else if(document.documentElement&&(document.documentElement.clientWidth||document.documentElement.clientHeight))
    {
        width=document.documentElement.clientWidth;
        height=document.documentElement.clientHeight;
    }
    else if(document.body&&(document.body.clientWidth||document.body.clientHeight))
    {
        width=document.body.clientWidth;
        height=document.body.clientHeight;
    }

    if(document.documentElement&&(document.documentElement.scrollHeight||document.documentElement.offsetHeight))
    {
        if(document.documentElement.scrollHeight>document.documentElement.offsetHeight){
            contentWidth=document.documentElement.scrollWidth;
            contentHeight=document.documentElement.scrollHeight;
        }
        else
        {
            contentWidth=document.documentElement.offsetWidth;
            contentHeight=document.documentElement.offsetHeight;
        }
    }
    else if(document.body&&(document.body.scrollHeight||document.body.offsetHeight))
    {
        if(document.body.scrollHeight>document.body.offsetHeight)
        {
            contentWidth=document.body.scrollWidth;
            contentHeight=document.body.scrollHeight;
        }else{
            contentWidth=document.body.offsetWidth;
            contentHeight=document.body.offsetHeight;
        }
    }
    else
    {
        contentWidth=width;
        contentHeight=height;
    }
    if(height>contentHeight)
        height=contentHeight;
    if(width>contentWidth)
        width=contentWidth;
    var rect=new Object();
    rect.ScrollX=scrollX;
    rect.ScrollY=scrollY;
    rect.Width=width;
    rect.Height=height;
    rect.ContentWidth=contentWidth;
    rect.ContentHeight=contentHeight;
    return rect;
}

//刷新当前页面
function ReloadPage() {
    location.href = location.href;
}