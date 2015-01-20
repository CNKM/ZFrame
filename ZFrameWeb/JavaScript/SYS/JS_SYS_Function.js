$(function () {
    InitTreeWithFilter($("#MgrFuncTree"), $("#MgrFuncFilter"), function (node) {
        alert();
    }, CurrentLoginObject.CurrentFuncs);
    $("#checkboxdiv").click(function () {
        var isChecked = $("#ck").prop("checked") ? true : false;
        if (isChecked == true) {
            $("#ck").prop("checked", false);
        } else {
            $("#ck").prop("checked", true);
        }
    });
});