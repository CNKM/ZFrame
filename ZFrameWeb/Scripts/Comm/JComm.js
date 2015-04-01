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
                        msgbox.info(CallBackObject.Msg);
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
    alert: function (msg) { $.messager.alert("消息", msg, "error"); },
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
            bar: { hide: true }
        });
    },
    closeprogress: function () {
        $.messager.progress("close");
    }
};

//获取数据行
var GetDataGridSelection=function(dataGrid) {
    var selectedRows = [];
    var rows = dataGrid.datagrid('getSelections');
    return rows;
}

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
    //window.location(url);
    location.href = url;
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

//树相关
function RegTreeFilter() {
    $.extend($.fn.tree.methods, {
        doFilter: function (jq, text) {
            return jq.each(function () {
                var target = this;
                var data = $.data(target, 'tree').data;
                var ids = {};
                forNodes(data, function (node) {
                    if (node.attributes[node.attributes.length -1].Value.toLowerCase().indexOf(text.toLowerCase()) == -1) {
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
var InitTreeWithFilter = function (treecontrol, treefilter, nodeclickcallback, source,tipsIndex) {
    RegTreeFilter();
    treecontrol.tree({
        onClick: function (node) {
            nodeclickcallback(node);
        },
        formatter: function (node) {
            if (tipsIndex != null && tipsIndex >= 0) {
                return '<span title="' + node.attributes[tipsIndex].Value + '">' + node.text + '</span>';
            }
            else {
                return '<span >' + node.text + '</span>';
            }
        },
        data: source
    });

    treefilter.textbox({
        icons: [{
            iconCls: "icon-search",
            handler: function (e) {
                var v = $(e.data.target).textbox("getValue");
                treecontrol.tree("doFilter", v);
            }
        }, {
            iconCls: "icon-remove",
            handler: function (e) {
                $(e.data.target).textbox("clear");
            }
        }]
    })
    treefilter.textbox("textbox").bind("keydown", function (e) {
        if (e.keyCode == 13) {
            var v = treefilter.textbox("getValue");
            treecontrol.tree("doFilter", v);
        }
    });

}
var GetBrowerVersion = function () {
    var userAgent = navigator.userAgent,
    rMsie = /(msie\s|trident.*rv:)([\w.]+)/,
    rFirefox = /(firefox)\/([\w.]+)/,
    rOpera = /(opera).+version\/([\w.]+)/,
    rChrome = /(chrome)\/([\w.]+)/,
    rSafari = /version\/([\w.]+).*(safari)/;
    var browserinfo = {
        name: "",
        version: null
    };

    var ua = userAgent.toLowerCase();
    function uaMatch(ua) {
        var match = rMsie.exec(ua);
        if (match != null) {
            return { browser: "IE", version: match[2] || "0" };
        }
        var match = rFirefox.exec(ua);
        if (match != null) {
            return { browser: match[1] || "", version: match[2] || "0" };
        }
        var match = rOpera.exec(ua);
        if (match != null) {
            return { browser: match[1] || "", version: match[2] || "0" };
        }
        var match = rChrome.exec(ua);
        if (match != null) {
            return { browser: match[1] || "", version: match[2] || "0" };
        }
        var match = rSafari.exec(ua);
        if (match != null) {
            return { browser: match[2] || "", version: match[1] || "0" };
        }
        if (match != null) {
            return { browser: "", version: "0" };
        }
    }
    var browserMatch = uaMatch(userAgent.toLowerCase());
    if (browserMatch.browser) {
        browserinfo.name = browserMatch.browser;
        browserinfo.version = browserMatch.version;
    }
    return browserinfo;
}

Array.prototype.GetValueByKey = function (SearckKey) {
     for (var i = 0; i < this.length; i++) {
         if (SearckKey == this[i].Key) {
             return this[i].Value;
         }
     }
};
