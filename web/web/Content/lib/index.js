//入口自定义模块

layui.define(['layer','jquery'], function (exports) {
    var layer = layui.layer;

    var index = {
        
    }
    //自动加载页面记录的模块
    if (layui.cache.model) {

        //模块名称
        var modelName = layui.cache.model.modelName;
        //动态获取模块名称
        var extend = {}
        extend[modelName] = 'lib/model/' + modelName;
        //动态加载模块
        layui.extend(extend).use(modelName);
    }

    //对外输出接口
    exports('index', index);
})