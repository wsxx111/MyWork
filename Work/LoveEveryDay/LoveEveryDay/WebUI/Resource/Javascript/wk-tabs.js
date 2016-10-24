+function () {
    //alert('nihao');
    // jQuery width() 和 height() 方法
    // width() 方法设置或返回元素的宽度（不包括内边距、边框或外边距）。
    //height() 方法设置或返回元素的高度（不包括内边距、边框或外边距）。
    //innerWidth() 方法返回元素的宽度（包括内边距）。
    //innerHeight() 方法返回元素的高度（包括内边距）。
    //outerWidth() 方法返回元素的宽度（包括内边距和边框）。
    //outerHeight() 方法返回元素的高度（包括内边距和边框）。
    //outerWidth(true) 方法返回元素的宽度（包括内边距、边框和外边距）。
    //<div style="width:300px;height:100px;padding:10px;margin:5px;border:2px solid red"></div>
    // width():300px    innerWidth():(300+10+10)px    outerWidth():(300+10+10+2+2)px   outerWidth(true) (300+10+10+2+2+5+5)px
    function getElemWidth(elems) {
        var k = 0;
        $(elems).each(function () {
            k += $(this).outerWidth(true)
        });
        return k;
    }

    function setTabPositionLeft(elems) {
        var o = getElemWidth($(elems).prevAll()),
        q = getElemWidth($(elems).nextAll());
        var l = getElemWidth($(".content-tabs").children().not(".WK_menuTabs"));
        var k = $(".content-tabs").outerWidth(true) - l;
        var p = 0;
        if ($(".page-tabs-content").outerWidth() < k) {
            p = 0
        } else {
            if (q <= (k - $(elems).outerWidth(true) - $(elems).next().outerWidth(true))) {
                if ((k - $(elems).next().outerWidth(true)) > q) {
                    p = o;
                    var m = n;
                    while ((p - $(elems).outerWidth()) > ($(".page-tabs-content").outerWidth() - k)) {
                        p -= $(elems).prev().outerWidth();
                        m = $(elems).prev()
                    }
                }
            } else {
                if (o > (k - $(elems).outerWidth(true) - $(elems).prev().outerWidth(true))) {
                    p = o - $(elems).prev().outerWidth(true)
                }
            }
        }
        $(".page-tabs-content").animate({
            marginLeft: 0 - p + "px"
        },
        "fast");
    }

    function setTabPositionRight() {
        var o = Math.abs(parseInt($(".page-tabs-content").css("margin-left")));
        var l = getElemWidth($(".content-tabs").children().not(".WK_menuTabs"));
        var k = $(".content-tabs").outerWidth(true) - l;
        var p = 0;
        if ($(".page-tabs-content").width() < k) {
            return false
        } else {
            var m = $(".WK_menuTabs:first");
            var n = 0;
            while ((n + $(m).outerWidth(true)) <= o) {
                n += $(m).outerWidth(true);
                m = $(m).next();
            }
            n = 0;
            if (getElemWidth($(m).prevAll()) > k) {
                while ((n + $(m).outerWidth(true)) < (k) && m.length > 0) {
                    n += $(m).outerWidth(true);
                    m = $(m).prev()
                }
                p = getElemWidth($(m).prevAll())
            }
        }
        $(".page-tabs-content").animate({
            marginLeft: 0 - p + "px"
        },
        "fast");
    }

    function b() {
        var o = Math.abs(parseInt($(".page-tabs-content").css("margin-left")));
        var l = f($(".content-tabs").children().not(".WK_menuTabs"));
        var k = $(".content-tabs").outerWidth(true) - l;
        var p = 0;
        if ($(".page-tabs-content").width() < k) {
            return false
        } else {
            var m = $(".J_menuTab:first");
            var n = 0;
            while ((n + $(m).outerWidth(true)) <= o) {
                n += $(m).outerWidth(true);
                m = $(m).next()
            }
            n = 0;
            while ((n + $(m).outerWidth(true)) < (k) && m.length > 0) {
                n += $(m).outerWidth(true);
                m = $(m).next()
            }
            p = f($(m).prevAll());
            if (p > 0) {
                $(".page-tabs-content").animate({
                    marginLeft: 0 - p + "px"
                },
                "fast")
            }
        }
    }

    $(".Wk_menuItem").each(function (k) {
        if (!$(this).attr("data-index")) {
            $(this).attr("data-index", k)
        }
    });

    function c() {
        var o = $(this).attr("href"),
        m = $(this).data("index"),
        l = $.trim($(this).text()),
        k = true;
        if (o == undefined || $.trim(o).length == 0) {
            return false
        }
        $(".J_menuTab").each(function () {
            if ($(this).data("id") == o) {
                if (!$(this).hasClass("active")) {
                    $(this).addClass("active").siblings(".J_menuTab").removeClass("active");
                    g(this);
                    $(".J_mainContent .J_iframe").each(function () {
                        if ($(this).data("id") == o) {
                            $(this).show().siblings(".J_iframe").hide();
                            return false
                        }
                    })
                }
                k = false;
                return false
            }
        });
        if (k) {
            var p = '<a href="javascript:;" class="active J_menuTab" data-id="' + o + '">' + l + ' <i class="fa fa-times-circle"></i></a>';
            $(".J_menuTab").removeClass("active");
            var n = '<iframe class="J_iframe" name="iframe' + m + '" width="100%" height="100%" src="' + o + '" frameborder="0" data-id="' + o + '" seamless></iframe>';
            $(".J_mainContent").find("iframe.J_iframe").hide().parents(".J_mainContent").append(n);
            $(".J_menuTabs .page-tabs-content").append(p);
            g($(".J_menuTab.active"))
        }
        return false
    }



}()