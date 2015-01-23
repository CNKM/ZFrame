var LoadUserFuncs = function (pType, isReloadFunc, Loadcallback) {
    var postvalue = {
        PType: pType,
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

var LoadFullFuncs = function (Loadcallback) {
    AjaxHelper.CallFunction("GetFuncsForEasyUI", null, false,
   function (d) {
       var ReutrnCurrengLoingObject = JSON.parse(d);
       Loadcallback(ReutrnCurrengLoingObject);

   }, function (e) {
       msgbox.error(e);
   });
}