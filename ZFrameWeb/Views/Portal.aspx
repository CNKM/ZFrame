<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="Portal.aspx.cs" Inherits="ZFrameWeb.Views.Portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script src="../Scripts/jquery-easyui-1.4.1/plugins/jquery.tree.js"></script>
    <script>
        $(function () {
            RegTreeFilter();
            $("#FuncFilter").textbox({
                icons: [{
                    iconCls: "icon-search",
                    handler: function (e) {
                        var v = $(e.data.target).textbox("getValue");
                        $("#FuncTree").tree("doFilter", v);
                    }
                }, {
                    iconCls: "icon-remove",
                    handler: function (e) {
                        $(e.data.target).textbox("clear");
                    }
                }]
            })
            $("#FuncTree").tree({
                onClick: function (node) {
                    var funcurl = node.attributes[0].Value;
                    if (StringHelper.IsNullOrEmpty(funcurl)) {
                        msgbox.info("功能链接错误,请联系管理员.")
                        return;
                    }
                    var hosturl = GetCurrentURl();
                    var title = node.text;
                    var isexists = $("#MainTab").tabs("exists", title);
                    if (isexists) {
                        $("#MainTab").tabs("select", title);
                    } else {
                        funcurl = funcurl.replace("~", hosturl);
                        $("#MainTab").tabs("add", {
                            id: node.id,
                            title: title,
                            selected: true,
                            href: funcurl,
                            iconCls: node.iconCls,
                            closable: true
                        });
                    }

                }
            });
            $("#FuncFilter").textbox("textbox").bind("keydown", function (e) {
                if (e.keyCode == 13) {
                    var v = $("#FuncFilter").textbox("getValue");
                    $("#FuncTree").tree("doFilter", v);
                }
            });

            AjaxHelper.CallFunction("GetCurrentLoginForEasyUI", null, false,
                function (d) {
                    var ReutrnCurrengLoingObject = JSON.parse(d).Contend;
                    CurrentLoginObject.CurrentDept = ReutrnCurrengLoingObject.CurrentDept;
                    CurrentLoginObject.CurrentFuncs = ReutrnCurrengLoingObject.ExtendContend;
                    CurrentLoginObject.CurrentRole = ReutrnCurrengLoingObject.CurrentRole;
                    CurrentLoginObject.CurrentUser = ReutrnCurrengLoingObject.CurrentUser;
                    $("#FuncTree").tree({
                        data: CurrentLoginObject.CurrentFuncs
                    });
                    $("#currentUser").text("注当前登录人员:【" + CurrentLoginObject.CurrentUser.F_Name + "】");
                    $("#currentDept").text("前登录部门:【" + CurrentLoginObject.CurrentDept.F_Name + "】");
                    $("#currentRole").text("当前岗位角色:【" + CurrentLoginObject.CurrentRole.F_Name + "】");
                }, function (e) {
                    msgbox.error(e);
                });

            $("#btnLoginOff").click(function (e) {
                AjaxHelper.CallFunction("UserLoginOut", null, false,
              function (d) {
                  if (d.Code == 1) {
                      JumToLogin();
                  }

              }, function (e) {
                  msgbox.error(e);
              });

            });
        });
    </script>


    <div class="easyui-layout" data-options="fit:true">
        <%--<div data-options="region:'north'" style="width: 100%;">
            HeadContend
        </div>--%>
        <div data-options="region:'center'" style="width: 100%">
            <div id="MainTab" class="easyui-tabs" style="width: 100%;" data-options="fit:true">
                <div title="开始首页" style="padding: 2px" data-options="iconCls:'icon-help'">
                    <div class="easyui-layout" data-options="fit:true">
                        <div data-options="region:'west',split:true" style="width: 220px;">
                            <div class="easyui-layout" data-options="fit:true">
                                <div data-options="region:'north'" style="width: 100%; height: 30px; padding: 2px">
                                    <input id="FuncFilter" class="easyui-textbox" style="width: 100%;" data-options="prompt: '输入拼音过滤',iconWidth: 22" />
                                </div>
                                <div data-options="region:'center'">
                                    <ul id="FuncTree" class="easyui-tree" data-options="animate:true,lines:true,cache:true"></ul>
                                </div>
                            </div>
                        </div>
                        <div data-options="region:'center'">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div data-options="region:'south'" style="width: 100%; height: 28px; font-size: 16px; overflow: hidden">
            <div style="margin-left: 10px;" class="PortalFooterBar">
                <span class="l-btn-icon icon-cancel"></span>
                <div id="btnLoginOff">注销登录</div>
            </div>
            <div style="margin-left: 30px;" class="PortalFooterBar">
                <span class="l-btn-icon icon-cancel"></span>
                <div id="currentUser"></div>
            </div>
            <div style="margin-left: 10px;" class="PortalFooterBar">
                <span class="l-btn-icon icon-cancel"></span>
                <div id="currentDept"></div>
            </div>
            <div style="margin-left: 10px;" class="PortalFooterBar">
                <span class="l-btn-icon icon-cancel"></span>
                <div id="currentRole"></div>
            </div>
            <div style="clear: both;display: inline-block"></div>
        </div>
    </div>





</asp:Content>

