layui.define(['element','jquery'], function (exports) {
    var element = layui.element,$=layui.$;

    var $body = $('body');

    var events = {
        //侧边导航栏伸缩事件
        flexible: function (that) {
            var sideShinkClass = 'layadmin-side-shrink',
                shrinkClassIcon = 'layui-icon-shrink-right',
                spreadClassIcon = 'layui-icon-spread-left';

            var $container = $('#cntr_Container'),
                $iconFlexible = $('#icon_flexible'),
                isFlexible = $container.hasClass(sideShinkClass);
            if (isFlexible) {
                $container.removeClass(sideShinkClass);//展开导航栏
                $iconFlexible.removeClass(spreadClassIcon).addClass(shrinkClassIcon);
            }
            else
            {
                $container.addClass(sideShinkClass);//收缩导航栏
                $iconFlexible.addClass(spreadClassIcon).removeClass(shrinkClassIcon);
            }
        }
    };
    //注册全局事件
    $body.on('click', '*[click-event]', function () {
        var that = $(this);
        //获取自定义的事件名称
        var eventAttr = that.attr('click-event');
        //执行事件
        events[eventAttr] && events[eventAttr].call(this,that);
    });

    exports('home',null)
})