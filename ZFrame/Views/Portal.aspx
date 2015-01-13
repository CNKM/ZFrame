<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="Portal.aspx.cs" Inherits="ZFrameWeb.Views.Portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script>
        $(function () {
            $("#MainTab").tabs({ height: $(window).height() });
            AjaxHelper.CallFunction("GetCurrentLoginForEasyUI", null, true,
                function (d) {
                    var ReutrnCurrengLoingObject = JSON.parse(d).Contend;
                    CurrentLoginObject.CurrentDept = ReutrnCurrengLoingObject.CurrentDept;
                    CurrentLoginObject.CurrentFuncs = ReutrnCurrengLoingObject.ExtendContend;
                    CurrentLoginObject.CurrentRole = ReutrnCurrengLoingObject.CurrentRole;
                    CurrentLoginObject.CurrentUser = ReutrnCurrengLoingObject.CurrentUser;
                    $("#FuncTree").tree({
                        data: CurrentLoginObject.CurrentFuncs
                    });
                }, function (e) {
                    alert(e);
                });
        });

        WindowResizeEvent = function () {
            $("#MainTab").tabs({ height: $(window).height() });
        }

    </script>

    <div id="MainTab" class="easyui-tabs" style="width: 100%; height: 768px;">
        <div title="开始首页" style="padding: 2px" data-options="iconCls:'icon-help'">
            <div class="easyui-layout" data-options="fit:true">
                <div data-options="region:'west',split:true" style="width: 300px;">
                    <div class="easyui-panel" style="padding: 5px">
                        <ul id="FuncTree" class="easyui-tree" data-options="animate:true"></ul>
                    </div>
                </div>
                <div data-options="region:'center'">
                </div>
                <div data-options="region:'south'" style="height: 26px">
                    状态栏目
                </div>
            </div>
        </div>
    </div>


</asp:Content>
