/**
 * Created by fengxiaojuan on 2018/04/28.
 */
    /**
     * 导航
     */
var Nav = (function () {

    var init = function () {
        // 绑定滚动条
        bindScroll();

        // 绑定目录点击
        bindDirEvent();

       
    };

    /**
     * 绑定滚动条
     */
    var bindScroll = function () {
        /* 监听滚动条 */
        window.onscroll = function () {
            var t = document.documentElement.scrollTop
                || document.body.scrollTop;
            if (t >= 300) {
                $("#top_div").fadeIn();
            } else {
                $("#top_div").fadeOut();
            }
        };

        // $(".fix_index").fadeOut();

        // 点击出现导航条
        $(".change_label").click(function () {
            var value = $(".fix_index").attr("data-value");
            if (value == "false") {
                $(".fix_index").fadeIn();
                $(".fix_index").attr("data-value", "true");
                $(".return_hov").css("background-color", "#EEEEE0");
            } else {
                $(".fix_index").fadeOut();
                $(".fix_index").attr("data-value", "false");
                $(".return_hov").css("background-color", "#FFFFFF");
            }
        });

        // 点击回调顶部
        $("#top_div").click(function () {
            $("html,body").animate({
                scrollTop: 0
            }, 500);
        });
    };

    /**
     * 设置目录居中
     */
    var setDirToCenter = function () {
        var height_css = $(".fix_index").css("height");
        var height = parseInt(height_css);
        height = Math.round(height / 2);
        $(".fix_index").css("margin-top", "-" + height + "px");
    };

    /**
     * 绑定目录点击
     */
    var bindDirEvent = function () {

        // 目录切换
        $("ul#dir-ul li").on("click", function () {

            var $li = $(this);
            $li.siblings(".active").removeClass("active");
            $li.addClass("active");
            var value = $li.attr("data-value");
            $("html,body").animate({
                scrollTop: $("#mari-" + value).offset().top
            }, 500);
        });
    };

    return {
        init: init
    };
})();

/**
 * 公报一执行器
 */
var OneHanlder = (function () {

    /**
     * 公报一 总入口
     */
    var init = function () {
        Nav.init(); // 导航
    };

    return {
        init: init
    };
})();
OneHanlder.init(); // 执行