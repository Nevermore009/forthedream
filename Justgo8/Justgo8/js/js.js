(function(jQuery) {
    jQuery.extend(jQuery.browser, {
        client: function() {
            return {
                width: document.documentElement.clientWidth,
                height: document.documentElement.clientHeight,
                bodyWidth: document.body.clientWidth,
                bodyHeight: document.body.clientHeight
            };
        },
        scroll: function() {
            return {
                width: document.documentElement.scrollWidth,
                height: document.documentElement.scrollHeight,
                bodyWidth: document.body.scrollWidth,
                bodyHeight: document.body.scrollHeight,
                left: document.documentElement.scrollLeft,
                top: document.documentElement.scrollTop + document.body.scrollTop
            };
        },
        screen: function() {
            return {
                width: window.screen.width,
                height: window.screen.height
            };
        },
        isIE6: jQuery.browser.msie && jQuery.browser.version == 6,
        isMinW: function(val) {
            return Math.min(jQuery.browser.client().bodyWidth, jQuery.browser.client().width) <= val;
        },
        isMinH: function(val) {
            return jQuery.browser.client().height <= val;
        }
    })
})(jQuery); (function(jQuery) {
    jQuery.widthForIE6 = function(option) {
        var s = jQuery.extend({
            max: null,
            min: null,
            padding: 0
        },
        option || {});
        var init = function() {
            var w = jQuery(document.body);
            if (jQuery.browser.client().width >= s.max + s.padding) {
                w.width(s.max + "px");
            } else if (jQuery.browser.client().width <= s.min + s.padding) {
                w.width(s.min + "px");
            } else {
                w.width("auto");
            }
        };
        init();
        jQuery(window).resize(init);
    }
})(jQuery); (function(jQuery) {
    jQuery.fn.hoverForIE6 = function(option) {
        var s = jQuery.extend({
            current: "hover",
            delay: 10
        },
        option || {});
        jQuery.each(this, 
        function() {
            var timer1 = null,
            timer2 = null,
            flag = false;
            jQuery(this).bind("mouseover", 
            function() {
                if (flag) {
                    clearTimeout(timer2);
                } else {
                    var _this = jQuery(this);
                    timer1 = setTimeout(function() {
                        _this.addClass(s.current);
                        flag = true;
                    },
                    s.delay);
                }
            }).bind("mouseout", 
            function() {
                if (flag) {
                    var _this = jQuery(this);
                    timer2 = setTimeout(function() {
                        _this.removeClass(s.current);
                        flag = false;
                    },
                    s.delay);
                } else {
                    clearTimeout(timer1);
                }
            })
        })
    }
})(jQuery); (function(jQuery) {
    jQuery.extend({
        _jsonp: {
            scripts: {},
            counter: 1,
            head: document.getElementsByTagName("head")[0],
            name: function(callback) {
                var name = '_jsonp_' + (new Date).getTime() + '_' + this.counter;
                this.counter++;
                var cb = function(json) {
                    eval('delete ' + name);
                    callback(json);
                    jQuery._jsonp.head.removeChild(jQuery._jsonp.scripts[name]);
                    delete jQuery._jsonp.scripts[name];
                };
                eval(name + ' = cb');
                return name;
            },
            load: function(url, name) {
                var script = document.createElement('script');
                script.type = 'text/javascript';
                script.charset = this.charset;
                script.src = url;
                this.head.appendChild(script);
                this.scripts[name] = script;
            }
        },
        getJSONP: function(url, callback) {
            var name = jQuery._jsonp.name(callback);
            var url = url.replace(/{callback};/, name);
            jQuery._jsonp.load(url, name);
            return this;
        }
    });
})(jQuery); (function(jQuery) {
    jQuery.fn.jdTab = function(option, callback) {
        if (typeof option == "function") {
            callback = option;
            option = {};
        };
        var s = jQuery.extend({
            type: "static",
            auto: false,
            source: "data",
            event: "mouseover",
            currClass: "curr",
            tab: ".tab",
            content: ".tabcon",
            itemTag: "li",
            stay: 5000,
            delay: 100,
            mainTimer: null,
            subTimer: null,
            index: 0
        },
        option || {});
        var tabItem = jQuery(this).find(s.tab).eq(0).find(s.itemTag),
        contentItem = jQuery(this).find(s.content);
        if (tabItem.length != contentItem.length) return false;
        var reg = s.source.toLowerCase().match(/http:\/\/|\d|\.aspx|\.ascx|\.asp|\.php|\.html\.htm|.shtml|.js|\W/g);
        var init = function(n, tag) {
            s.subTimer = setTimeout(function() {
                hide();
                if (tag) {
                    s.index++;
                    if (s.index == tabItem.length) s.index = 0;
                } else {
                    s.index = n;
                };
                s.type = (tabItem.eq(s.index).attr(s.source) != null) ? "dynamic": "static";
                show();
            },
            s.delay);
        };
        var autoSwitch = function() {
            s.mainTimer = setInterval(function() {
                init(s.index, true);
            },
            s.stay);
        };
        var show = function() {
            tabItem.eq(s.index).addClass(s.currClass);
            switch (s.type) {
            default:
            case "static":
                var source = "";
                break;
            case "dynamic":
                var source = (reg == null) ? tabItem.eq(s.index).attr(s.source) : s.source;
                tabItem.eq(s.index).removeAttr(s.source);
                break;
            };
            if (callback) {
                callback(source, contentItem.eq(s.index), s.index);
            };
            contentItem.eq(s.index).show();
        };
        var hide = function() {
            tabItem.eq(s.index).removeClass(s.currClass);
            contentItem.eq(s.index).hide();
        };
        tabItem.each(function(n) {
            jQuery(this).bind(s.event, 
            function() {
                clearTimeout(s.subTimer);
                clearInterval(s.mainTimer);
                init(n, false);
                return false;
            }).bind("mouseleave", 
            function() {
                if (s.auto) {
                    autoSwitch();
                } else {
                    return;
                }
            })
        });
        if (s.type == "dynamic") {
            init(s.index, false);
        };
        if (s.auto) {
            autoSwitch();
        }
    }
})(jQuery); (function(jQuery) {
    jQuery.fn.jdSlide = function(option) {
        var settings = jQuery.extend({
            width: null,
            height: null,
            pics: [],
            index: 0,
            type: "num",
            current: "curr",
            delay1: 200,
            delay2: 8000
        },
        option || {});
        var element = this;
        var timer1,
        timer2,
        timer3,
        flag = true;
        var total = settings.pics.length;
        var init = function() {
            var img = "<ul style='position:absolute;top:0;left:0;'><li><a href='" + settings.pics[0].href + "' target='_blank'><img src='" + settings.pics[0].src + "' width='" + settings.width + "' height='" + settings.height + "' /></a></li></ul>";
            element.css({
                "position": "relative"
            }).html(img);
            jQuery(function() {
                delayLoad();
            })
        };
        init();
        var initIndex = function() {
            var indexs = "<div>";
            var current;
            var x;
            for (var i = 0; i < total; i++) {
                current = (i == settings.index) ? settings.current: "";
                switch (settings.type) {
                case "num":
                    x = i + 1;
                    break;
                case "string":
                    x = settings.pics[i].alt;
                    break;
                case "image":
                    x = "<img src='" + settings.pics[i].breviary + "' />";
                default:
                    break;
                };
                indexs += "<span class='" + current + "'><a href='" + settings.pics[i].href + "' target='_blank'>" + x + "</a></span>";
            };
            indexs += "</div>";
            element.append(indexs);
            element.find("span").bind("mouseover", 
            function(e) {
                clearInterval(timer1);
                clearInterval(timer3);
                var index = element.find("span").index(this);
                if (index == settings.index) {
                    return;
                } else {
                    timer3 = setInterval(function() {
                        if (flag) running(parseInt(index));
                    },
                    settings.delay1);
                }
            }).bind("mouseleave", 
            function(e) {
                clearInterval(timer3);
                timer1 = setInterval(function() {
                    running(settings.index + 1, true);
                },
                settings.delay2);
            })
        };
        var running = function(index, tag) {
            if (index == total) {
                index = 0;
            };
            element.find("span").eq(settings.index).removeClass(settings.current);
            element.find("span").eq(index).addClass(settings.current);
            timer2 = setInterval(function() {
                var pos_y = parseInt(element.find("ul").get(0).style.top);
                var pos_a = Math.abs(pos_y + settings.index * settings.height);
                var pos_b = Math.abs(index - settings.index) * settings.height;
                var pos_c = Math.ceil((pos_b - pos_a) / 4);
                if (pos_a == pos_b) {
                    clearInterval(timer2);
                    if (tag) {
                        settings.index++;
                        if (settings.index == total) {
                            settings.index = 0;
                        }
                    } else {
                        settings.index = index;
                    };
                    flag = true;
                } else {
                    if (settings.index < index) {
                        element.find("ul").css({
                            top: pos_y - pos_c + "px"
                        });
                    } else {
                        element.find("ul").css({
                            top: pos_y + pos_c + "px"
                        });
                    };
                    flag = false;
                }
            },
            10);
        };
        var delayLoad = function() {
            var img = "";
            for (var i = 1; i < total; i++) {
                img += "<li><a href='" + settings.pics[i].href + "' target='_blank'><img src='" + settings.pics[i].src + "' width='" + settings.width + "' height='" + settings.height + "' /></a></li>";
            };
            element.find("ul").append(img);
            timer1 = setInterval(function() {
                running(settings.index + 1, true);
            },
            settings.delay2);
            if (settings.type) initIndex();
        };
    }
})(jQuery);
function ResumeError() {
    return true;
}
window.onerror = ResumeError;
if (jQuery.browser.isIE6) {
    try {
        document.execCommand("BackgroundImageCache", false, true);
    } catch(err) {}
};

callback1 = function(data) {;
};
log = function(type1, type2, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) {
    var data = '';
    for (i = 2; i < arguments.length; i++) {
        data = data + arguments[i] + '|||';
    }
    var url = loguri.replace(/\jQuerytype1\jQuery/, escape(type1));
    url = url.replace(/\jQuerytype2\jQuery/, escape(type2));
    url = url.replace(/\jQuerydata\jQuery/, escape(data));
    jQuery.getJSON(url, callback1);
};
mark = function(sku, type) {
    jQuery.getJSON(calluri, {
        sku: sku,
        type: type
    },
    callback1);
    log(1, type, sku);
};


function gi_ga(s, name) {
    if (typeof(s) == "undefined") {
        return "";
    };
    s = "^" + s + "^";
    var b = s.indexOf("^" + name + "=");
    if ( - 1 == b) {
        return "";
    } else {
        b += name.length + 2;
    };
    var e = s.indexOf("^", b);
    return s.substring(b, e);
};

var gi_normal__ = new Object();
gi_normal__.deliver = function(arg) {
    if (arg.gi_automatchscreen && screen.width >= 1280) {
        arg.gi_width = arg.gi_width_w;
    };
    var ad = "";
    if (arg.gi_isautomonitorclick) {
        ad = '<div style="position: absolute; width: ' + arg.gi_width + 'px; height: ' + arg.gi_height + 'px; cursor: pointer; background-color: rgb(255, 255, 255); opacity: 0; filter:alpha(opacity=0);" onclick="window.open(\'' + arg.gi_ldp + '\',\'_blank\')"></div>';
    };
    if (arg.gi_type == "img") {
        ad += "<a target=\"_blank\" href=\"" + arg.gi_ldp + "\"><img height=\"" + arg.gi_height + "\" width=\"" + arg.gi_width + "\" border=\"0\" src=\"" + ((arg.gi_width == arg.gi_width_w) ? (arg.gi_src_w) : (arg.gi_src)) + "\"/></a>";
    } else if (arg.gi_type == "flash") {
        ad += '<embed src="' + ((arg.gi_width == arg.gi_width_w) ? (arg.gi_src_w) : (arg.gi_src)) + '" width="' + arg.gi_width + '" height="' + arg.gi_height + '" type="application/x-shockwave-flash" play="true" loop="true" menu="true" wmode="transparent"></embed>';
    };
    var gi_k = gi_ga(arg.gi_ldp, "k");
    var gi_p = gi_ga(arg.gi_ldp, "p");
    document.getElementById("miaozhen" + arg.gi_pid).innerHTML += ad + gi_get_monitor_code(gi_k, gi_p);
};
gi_focus__ = new Object();
gi_focus__.next = function() {
    var arg = gi_focus__.arg;
    if (arg.gi_automatchscreen && screen.width >= 1280) {
        arg.gi_width = arg.gi_width_w;
    };
    var ad_arr = arg.gi_ad_arr;
    gi_focus__.now %= ad_arr.length;
    var html = '<div onmouseover="clearInterval(gi_focus__.timer);" onmouseout="gi_focus__.timer=setInterval(gi_focus__.next,gi_focus__.arg.gi_interval);" style="width: ' + arg.gi_width + 'px; height: ' + arg.gi_height + 'px; cursor: pointer; background-color: rgb(255, 255, 255); position: relative; " onclick="javascript:window.open(\'' + ad_arr[gi_focus__.now].gi_ldp + '\',\'_blank\')">';
    var i;
    var ad = '';
    if (ad_arr[gi_focus__.now].gi_type == "img") {
        var ad = '<img style="display: block" src="' + ((arg.gi_width == arg.gi_width_w) ? (ad_arr[gi_focus__.now].gi_src_w) : (ad_arr[gi_focus__.now].gi_src)) + '" width="' + arg.gi_width + 'px" height="' + arg.gi_height + 'px" />';
    } else if (ad_arr[gi_focus__.now].gi_type == "flash") {
        var ad = '<embed src="' + ((arg.gi_width == arg.gi_width_w) ? (ad_arr[gi_focus__.now].gi_src_w) : (ad_arr[gi_focus__.now].gi_src)) + '" width="' + arg.gi_width + '" height="' + arg.gi_height + '" type="application/x-shockwave-flash" play="true" loop="true" menu="true" wmode="transparent"></embed>';
    };
    html = html + ad;
    for (i = 0; i < ad_arr.length; i++) {
        if (i == gi_focus__.now) {
            html += '<div onmouseover="gi_focus__.now=' + i + ';gi_focus__.next();" style="border: 1px solid #0b6130; right:' + (18 * (ad_arr.length - i) - 18) + 'px; bottom: 0px; position: absolute; z-index: 10; width:15px;height:16px; cursor: pointer; background-color: #3b81cd; opacity: 1; filter:alpha(opacity=100); color:white; font-family:Arial; font-size:11px; text-align: center; vertical-align:middle; ">' + (i + 1) + '</div>';
        } else {
            html += '<div onmouseover="gi_focus__.now=' + i + ';gi_focus__.next();" style="border: 1px solid #0b6130; right:' + (18 * (ad_arr.length - i) - 18) + 'px; bottom: 0px; position: absolute; z-index: 10; width:15px;height:16px; cursor: pointer; background-color: rgb(255, 255, 255); opacity: 1; filter:alpha(opacity=100); font-family:Arial; font-size:11px; text-align: center; vertical-align:middle; " >' + (i + 1) + '</div>';
        }
    };
    html += '</div>';
    document.getElementById("miaozhen" + arg.gi_pid).innerHTML = html;
    gi_focus__.now++;
};
gi_focus__.deliver = function(arg) {
    gi_focus__.arg = arg;
    var ad_arr = arg.gi_ad_arr;
    var newElement = document.createElement("div");
    newElement.innerHTML = gi_get_monitor_code(gi_ga(ad_arr[0].gi_ldp, "k"), gi_ga(ad_arr[0].gi_ldp, "p"));
    document.getElementById("miaozhen" + arg.gi_pid).parentNode.appendChild(newElement);
    gi_focus__.now = 0;
    gi_focus__.timer = setInterval(gi_focus__.next, arg.gi_interval);
    gi_focus__.next();
};
var gi_rotate__ = new Object();
gi_rotate__.deliver = function(arg) {
    var ad_arr = arg.gi_ad_arr;
    var i = ad_arr[0][Math.floor(Math.random() * ad_arr[0].l)];
    if (arg.gi_automatchscreen && screen.width >= 1280) {
        arg.gi_width = arg.gi_width_w;
    };
    var click = '<div style="position: absolute; width: ' + arg.gi_width + 'px; height: ' + arg.gi_height + 'px; cursor: ';
    click += 'pointer; background-color: rgb(255, 255, 255); opacity: 0; filter:alpha(opacity=0);" ';
    click += 'onclick="javascript:window.open(\'' + ad_arr[i].gi_ldp + '\',\'_blank\')"></div>';
    if (ad_arr[i].gi_type == "img") {
        var ad = '<img src="' + ((arg.gi_width == arg.gi_width_w) ? (ad_arr[i].gi_src_w) : (ad_arr[i].gi_src)) + '" width="' + arg.gi_width + '" height="' + arg.gi_height + '" />';
    } else if (ad_arr[i].gi_type == "flash") {
        var ad = '<embed src="' + ((arg.gi_width == arg.gi_width_w) ? (ad_arr[i].gi_src_w) : (ad_arr[i].gi_src)) + '" width="' + arg.gi_width + '" height="' + arg.gi_height + '" type="application/x-shockwave-flash" play="true" loop="true" menu="true" wmode="transparent"></embed>';
    };
    ad = click + ad;
    var gi_k = gi_ga(ad_arr[i].gi_ldp, "k");
    var gi_p = gi_ga(ad_arr[i].gi_ldp, "p");
    document.getElementById("miaozhen" + arg.gi_pid).innerHTML += ad + gi_get_monitor_code(gi_k, gi_p);;
};
