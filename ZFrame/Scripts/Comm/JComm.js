var AjaxHelper = {
    ServerBaseURL: "",
    CallFunction: function (funcurl, parm, successcallback, errorcallback) {
        $.ajax({
            type: "GET",
            url: this.ServerBaseURL + "/" + funcurl+"?"+Math.random(),
            data: parm,
            contentType: "application/json; charset=utf-8",
            success: function (responseText, status) {
                try
                {
                    successcallback(JSON.parse(responseText));
                } catch (ex) {
                    successcallback(responseText);
                }
            },
            error: function (err) {
                errorcallback(err);
            }
        });
    }
}

//获取数据行
var GridJsonRows = function (data) {
    if (data.d != null) {
        var rv = JSON.parse(data.d);
        return rv;
    } else {
        var rv = data;
        return rv;
    }
}

///窗体尺寸改变事件
var WindowResizeEvent;
$(window).resize(function () {
    WindowResizeEvent();
});

///字符串处理
var StringHelper = {
    IsNullOrEmpty: function (str) {
        if (str == null) {
            return true;
        }
        if (str.length == 0) {
            return true;
        }
        return false;
    }
}

