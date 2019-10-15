layui.define(['element','jquery'], function (exports) {
    var element = layui.element,$=layui.$;

    var $body = $('body'),
        $tabBodys = $('#tab_Bodys');


    //模块方法集合
    var module = {
        //记录当前激活的选项卡索引
        activeTabIndex: 0,
        //根据激活的索引获取标签页的内容
        tabBody: function (index) {
            return $tabBodys.find('.layadmin-tabsbody-item').eq(index || 0);
        },

        //打开标签页方法
        openTabPage:function(url,text){
            var matchTo,//选项卡是否在已经打开的选项中匹配到
                $tabHeader = $('#tab_Titles>li');//选项卡的li集合
            //遍历选项卡，判断当前点击的菜单对应的标签是否存在
            $tabHeader.each(function (index) {                
                var $Header = $(this),
                    layid = $Header.attr('lay-id');
                //选项卡中已存在
                if (layid == url) {
                    matchTo = true;
                    module.activeTabIndex = index;
                    //定位Tab
                    element.tabChange('layout-tab', url);
                }
            });
            //未在已打开的选项卡中匹配到，则创建新的选项卡
            if (!matchTo) {
                //创建新的选项卡内容                
                $tabBodys.append('<div class="layadmin-tabsbody-item">\
                <iframe src="'+url+'" frameborder="0" class="layadmin-iframe"></iframe>\
            </div>');
                module.activeTabIndex = $tabHeader.length;
                element.tabAdd('layout-tab', {
                    title: text,
                    id: url
                });
                //定位Tab
                element.tabChange('layout-tab', url);               
            }
        },

        //切换选项卡
        tabChange: function (index, option) {
           var option = option || {};
            var showClass = 'layui-show';
            module.tabBody(index).addClass(showClass).siblings().removeClass(showClass);
            module.resetMenu(option);
        },

        //重置菜单状态
        resetMenu: function (options) {
            var url = options.url,
                $sideMenu = $('#menu_side'),
                itemedClass = 'layui-nav-itemed',
                thisClass = 'layui-this',

                getMenuData = function (item) {//item为li元素
                    return {
                        navChildElem: item.children('.layui-nav-child'),//dl元素
                        navLinkElem:item.children('*[lay-href]')//a标签
                    }
                },             

                //捕获当前激活的选项卡所对应的的菜单
                matchMenu = function (list) {
                    //list为li元素的集合
                    list.each(function (firstIndex, firstItem) {
                        //判断当前选中的选项卡内容是否对应一级菜单                        
                        var firstElem = $(firstItem),
                            firstData = getMenuData(firstElem),
                            firstChildList = firstData.navChildElem.children('dd'),//获取dd元素的集合
                            isMatchFirst = url === firstData.navLinkElem.attr('lay-href');//判断当前li中是否存在此url

                        //判断当前选中的选项卡内容是否对应二级菜单
                        firstChildList.each(function (secondIndex, secondItem) {                            
                            var secondElem = $(secondItem),
                                secondData = getMenuData(secondElem),
                                isMatchsecond = url === secondData.navLinkElem.attr('lay-href');
                            //如果二级菜单存在此url，则选中一级菜单，显示二级菜单
                            if (isMatchsecond) {
                                $(secondElem.parents('li')).addClass(itemedClass);
                                secondElem.addClass(thisClass);
                                return false;
                            }
                        })
                        //如果一级菜单存在此url，则显示一级菜单
                        if (isMatchFirst) {
                            firstElem.addClass(thisClass)
                            return false;
                        }
                    });
                }

            //清楚菜单所有的选中状态
            $sideMenu.find('.' + itemedClass).removeClass(itemedClass);
            $sideMenu.find('.' + thisClass).removeClass(thisClass);
            //根据选中的选项卡状态设置菜单的选中状态
            matchMenu($sideMenu.children('li'));
        }
    }; 
    
    //监听选项卡改变     
    element.on('tab(layout-tab)', function (data) {        
        var url = $(this).attr('lay-id'), index = data.index;
        module.activeTabIndex = index;        
        module.tabChange(index, {url:url})
    })

    //监听选项卡删除事件
    element.on('tabDelete(layout-tab)', function (data) {        
        var index = data.index;       
        module.tabBody(index).remove();
    })

    //模块类的事件集合
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
        },

        //全屏展示
        fullScreen: function (that) {
            var screenFullClass = "layui-icon-screen-full",
                screenRestorClass="layui-icon-screen-restore",
                iconElem = $(that).children('i');
            
            if (iconElem.hasClass(screenFullClass)) {
                var bodyElem = document.body;
                if (bodyElem.webkitRequestFullScreen) {
                    bodyElem.webkitRequestFullScreen();
                }
                else if (bodyElem.mozRequestFullScreen) {
                    bodyElem.mozRequestFullScreen();
                }
                else {
                    bodyElem.requestFullScreen();
                }
                iconElem.addClass(screenRestorClass).removeClass(screenFullClass);
            }
            else {
                var elem = document;
                if (elem.webkitCancelFullScreen) {
                    elem.webkitCancelFullScreen();
                }
                else if (elem.mozCancelFullScreen) {
                    elem.mozCancelFullScreen();
                }
                else {
                    elem.exitFullScreen();
                }
                iconElem.removeClass(screenRestorClass).addClass(screenFullClass);
            }
        },

        //关闭当前选项卡
        closeThis: function () {
            if (module.activeTabIndex!==0) {
                $('#tab_Titles>li').eq(module.activeTabIndex).find('.layui-tab-close').trigger('click');
            }
        },

        //关闭其他标签页
        closeOther: function () {
            var removeClass = 'tab-remove';
            //将当前标签页添加Class，再根据Class选择器删除
            $('#tab_Titles>li').each(function (index, item) {
                if (index > 0 && index !== module.activeTabIndex) {
                    $(item).addClass(removeClass);//给标签页添加样式
                    module.tabBody(index).addClass(removeClass);//给内容页添加样式
                }
            });
            $('.tab-remove').remove();
        },

        //关闭所有标签页
        closeAll: function () {
            //移除Tab标题
            $('#tab_Titles>li:gt(0)').remove();
            //移除tab内容
            $tabBodys.find('.layadmin-tabsbody-item:gt(0)').remove();
            //选中第一个标签页
            $('#tab_Titles>li').eq(0).trigger('click');
        }
    };
    //注册全局单击事件
    $body.on('click', '*[click-event]', function () {
        var that = $(this);
        //获取自定义的事件名称
        var eventAttr = that.attr('click-event');
        //执行事件
        events[eventAttr] && events[eventAttr](this);
    });

    //注册菜单导航点击事件
    $body.on('click', '*[lay-href]', function () {
        var href = $(this).attr('lay-href'),
            text = $(this).text();

        module.openTabPage(href, text);
    })

    exports('home',null)
})