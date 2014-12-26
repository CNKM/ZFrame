var AjaxHelper = {
    ServerBaseURL: "",
    CallFunction: function (funcurl,parm, successcallback, errorcallback) {
        $.ajax({
            type: "GET",
            url: this.ServerBaseURL + "/"+funcurl,
            data: parm,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                successcallback(data);
            },
            error: function (err) {
                errorcallback(err);
            }
        });
    }
};
var GridJsonRows = function (data) {
    if (data.d != null) {
        var rv = JSON.parse(data.d);
        return rv;
    } else {
        var rv = data;
        return rv;
        
    }

}

