var AjaxHelper = {
    ServerBaseURL: "",
    CallFunction: function (funcurl, parm, needprocess, successcallback, errorcallback) {
        if (needprocess) {
            msgbox.progress();
        }
        $.ajax({
            type: "GET",
            url: this.ServerBaseURL + "/" + funcurl + "?" + Math.random(),
            data: parm,
            contentType: "application/json; charset=utf-8",
            success: function (responseText, status) {
                msgbox.closeprogress();
                try {
                    successcallback(JSON.parse(responseText));
                } catch (ex) {
                    successcallback(responseText);
                }
            },
            error: function (err) {
                msgbox.closeprogress();
                errorcallback(err);
            }
        });
    }
}

var msgbox = {
    error: function (msg) { $.messager.alert("错误", msg, "error"); },
    info: function (msg) { $.messager.alert("消息", msg, "info"); },
    question: function (confirmmsg, callback) {
        $.messager.confirm("询问", confirmmsg, function (r) {
            if (r) {
                callback();
            }
        });
    },
    progress: function () {
        var win = $.messager.progress({
            title: "请稍候",
            msg: "正在执行操作...",
            bar:{}
        });
    },
    closeprogress: function () {
        $.messager.progress("close");
    }
};

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
    if (WindowResizeEvent != null) {
        WindowResizeEvent();
    }
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



