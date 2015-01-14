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
                    var CallBackObject = JSON.parse(responseText);
                    if (CallBackObject.Code == -1) {
                        alert(CallBackObject.Msg);
                        JumToLogin();
                        return;
                    }
                    successcallback(CallBackObject);
                } catch (err) {
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

var CurrentLoginObject = {
    CurrentDept: {},
    CurrentRole: {},
    CurrentUser: {},
    CurrentFuncs: []
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
            bar: {}
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

var GetCurrentURl = function () {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;
    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);
    return (prePath + postPath);

}
var JumpToURL = function (url) {
    window.location(url);
}

var JumpToPortal = function () {
    var Portal = GetCurrentURl() + "/Views/Portal.aspx";
    JumpToURL(Portal);
}
var JumToLogin = function () {
    var Login = GetCurrentURl() + "/Login.aspx";
    JumpToURL(Login);
}

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
};


function forNodes(data, callback) {
    var nodes = [];
    for (var i = 0; i < data.length; i++) {
        nodes.push(data[i]);
    }
    while (nodes.length) {
        var node = nodes.shift();
        if (callback(node) == false) { return; }
        if (node.children) {
            for (var i = node.children.length - 1; i >= 0; i--) {
                nodes.unshift(node.children[i]);
            }
        }
    }
}
function RegTreeFilter() {
    $.extend($.fn.tree.methods, {
        doFilter: function (jq, text) {
            return jq.each(function () {
                var target = this;
                var data = $.data(target, 'tree').data;
                var ids = {};
                forNodes(data, function (node) {
                    if (node.attributes[1].Value.toLowerCase().indexOf(text.toLowerCase()) == -1) {
                        $('#' + node.domId).hide();
                    } else {
                        $('#' + node.domId).show();
                        ids[node.domId] = 1;
                    }
                });
                for (var id in ids) {
                    showParents(id);
                }

                function showParents(domId) {
                    var p = $(target).tree('getParent', $('#' + domId)[0]);
                    while (p) {
                        $(p.target).show();
                        p = $(target).tree('getParent', p.target);
                    }
                }
            });
        }
    });
}