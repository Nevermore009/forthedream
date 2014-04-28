(function ($) {
    $.fn.cvtooltip = function (options) {
        var self = $(this);
        var defaults = {
            panel: "tips",      //该参数是加载气泡提示的容器，值不同可能会导致计算的位置不同，默认为添加至body容器
            selector: "",       //用于计算定位的控件
            direction: 1,       //箭头方向，默认向下
            width: 300,         //气泡提示宽度，完全手动设置
            left: 0,            //距离panel参数的左边距
            top: 0,             //距离panel参数的上边距
            delay: -1,          //延迟关闭，单位毫秒，值为0时表示立刻关闭
            speed: 300,         //关闭时的效果，淡出速度
            close: true,        //是否显示关闭按钮
            callback: function () {
                $.noop();       //点击关闭后的事件
            }
        };

        var param = $.extend({}, defaults, options || {});

        var controlID = self.attr("ID");

        //气泡样式
        var cvToolTipCssBtm = '';
        var cvToolTipCssTop = '';

        if (param.direction == 0) {
            cvToolTipCssBtm = 'position: absolute; border-color: transparent transparent #F9E98E transparent; border-style: dashed dashed solid dashed; border-width: 12px 12px 12px 12px; width: 0; height: 0; overflow: hidden; left:40px; top:-24px;';
            cvToolTipCssTop = 'position: absolute; border-color: transparent transparent #FBF7AA transparent; border-style: dashed dashed solid dashed; border-width: 12px 12px 12px 12px; width: 0; height: 0; overflow: hidden; left:40px; top:-19px;';
        }
        else {
            cvToolTipCssBtm = 'position: absolute; border-color: #F9E98E transparent transparent transparent; border-style: solid dashed dashed dashed; border-width: 12px 12px 12px 12px; width: 0; height: 0; overflow: hidden; left:40px; bottom:-24px;';
            cvToolTipCssTop = 'position: absolute; border-color: #FBF7AA transparent transparent transparent; border-style: solid dashed dashed dashed; border-width: 12px 12px 12px 12px; width: 0; height: 0; overflow: hidden; left:40px; bottom:-19px;';
        }

        var cvToolTipCss = 'z-index:99999; display:none; position: absolute; border: 3px solid #F9E98E; background-color: #FBF7AA; line-height:14px; width: ' + param.width + 'px; left:' + param.left + 'px; top:' + param.top + 'px;';

        //气泡显示
        var cvTipsElement = '';
        cvTipsElement += '<div id="' + controlID + 'Body" class="cvToolTip" style="' + cvToolTipCss + '">';
        cvTipsElement += '<span style="' + cvToolTipCssBtm + '"></span><span style="' + cvToolTipCssTop + '"></span>';
        cvTipsElement += '<span id="' + controlID + 'Content" style="float:left;"></span>';

        if (param.close) {
            cvTipsElement += '<a id="' + controlID + 'Close" style="display:none;"><span style="float:right; font-family:verdana; position: absolute; top:1px; right:5px; font-size:12px; cursor:pointer;">x</span></a>';
        }

        cvTipsElement += '</div>';

        if ($("#" + controlID + "Body").length == 0) {
            $(param.panel).append(cvTipsElement);
        }

        //气泡容器、装载内容的容器
        var cttBody = $("#" + controlID + "Body");
        var cttContent = $("#" + controlID + "Content");
        var cttClose = $("#" + controlID + "Close");

        cttBody.show();

        var ctt = {
            content: function () {
                self.show();
                return self;
            },

            position: function () {
                var p = $(param.selector).position();

                cttBody.css("top", p.top + param.top);
                cttBody.css("left", p.left + param.left);
            },

            hide: function () {
                cttBody.fadeOut(param.speed, function () {
                    ctt.content().hide().appendTo($(param.panel));
                    cttBody.remove();
                });
            },

            show: function () {
                if (cttContent.html() == "") {
                    cttContent.append(ctt.content());
                }

                if (param.selector != "") {
                    ctt.position();
                }

                if (param.delay >= 0) {
                    setTimeout(ctt.hide, param.delay);
                }
            }
        };

        ctt.show();

        //关闭气泡        
        cttClose.click(function () {
            ctt.hide();
            param.callback();
        });

        cttBody.mouseover(function () {
            cttClose.show();
        });

        cttBody.mouseout(function () {
            cttClose.hide();
        });
    }
})(jQuery);