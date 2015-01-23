var LoadFuncs = function (pType, funcState, isReloadFunc, Loadcallback) {
    var postvalue = {
        PType: pType,
        FuncState: funcState,
        IsReloadFunc: isReloadFunc
    }
    AjaxHelper.CallFunction("GetCurrentLoginForEasyUI", postvalue, false,
       function (d) {
           var ReutrnCurrengLoingObject = JSON.parse(d).Contend;
           CurrentLoginObject.CurrentDept = ReutrnCurrengLoingObject.CurrentDept;
           CurrentLoginObject.CurrentFuncs = ReutrnCurrengLoingObject.ExtendContend;
           CurrentLoginObject.CurrentRole = ReutrnCurrengLoingObject.CurrentRole;
           CurrentLoginObject.CurrentUser = ReutrnCurrengLoingObject.CurrentUser;
           Loadcallback(CurrentLoginObject);

       }, function (e) {
           msgbox.error(e);
       });
}