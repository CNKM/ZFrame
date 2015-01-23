<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="View_SYS_Function.aspx.cs" Inherits="ZFrameWeb.Views.SYS.View_SYS_Function" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <script src="<%:ResolveUrl("~/Scripts/Model/JS_SYS_Function.js") %>"></script>
    <script type="text/javascript">
        var CurrentEntity = {
            F_SN: "",
            F_PlatformType: "",
            F_ParentSN: null,
            F_FuncRightGroup: null,
            F_Name: "",
            F_URL: "",
            F_Icon: "",
            F_Tips: "",
            F_OpenType: "",
            F_OpenSpace: "",
            F_Remark: "",
            F_State: "",
            F_Index: ""
        };
        var SelfLoadFunc = function () {
            LoadFuncs(0, null, true, function (data) {
                InitTreeWithFilter($("#MgrFuncTree"), $("#MgrFuncFilter"), function (node) {
                    CurrentEntity.F_SN = node.id;
                    CurrentEntity.F_Icon = node.iconCls;
                    CurrentEntity.F_Name = node.text;
                    CurrentEntity.F_OpenSpace = node.attributes.GetValueByKey("F_OpenSpace");
                    CurrentEntity.F_OpenType = node.attributes.GetValueByKey("F_OpenType");
                    CurrentEntity.F_ParentSN = node.attributes.GetValueByKey("F_ParentSN");
                    CurrentEntity.F_PlatformType = node.attributes.GetValueByKey("F_PlatformType");
                    CurrentEntity.F_Remark = node.attributes.GetValueByKey("F_Remark");
                    CurrentEntity.F_State = node.attributes.GetValueByKey("F_State");
                    CurrentEntity.F_URL = node.attributes.GetValueByKey("F_URL");
                    CurrentEntity.F_Tips = node.attributes.GetValueByKey("F_Tips");

                    $("#nodeText").textbox("setText", CurrentEntity.F_Name);
                    $("#nodeURL").textbox("setText", CurrentEntity.F_URL);
                    $("#nodeIcon").textbox("setText", CurrentEntity.F_Icon);
                    $("#nodeOpenType").combobox("setValue", CurrentEntity.F_OpenType);
                    $("#nodeOpenSpeace").textbox("setText", CurrentEntity.F_OpenSpace);
                    $("#nodeTips").textbox("setText", CurrentEntity.F_Tips);
                    $("#nodeRemark").textbox("setText", CurrentEntity.F_Remark);
                    $("#ck").prop("checked", CurrentEntity.F_State == "1");
                }, data.CurrentFuncs);
            });
        }
        $(function () {
            SelfLoadFunc();
            $("#checkboxdiv").click(function () {
                var isChecked = $("#ck").prop("checked") ? true : false;
                if (isChecked == true) {
                    $("#ck").prop("checked", false);
                } else {
                    $("#ck").prop("checked", true);
                }
            });

            $("#btnAdd").click(function () {

            });

            $("#btnDel").click(function () {

            });

            $("#btnSave").click(function () {
                CurrentEntity.F_Name = $("#nodeText").textbox("getText");
                CurrentEntity.F_URL = $("#nodeURL").textbox("getText");
                CurrentEntity.F_Icon = $("#nodeIcon").textbox("getText");
                CurrentEntity.F_OpenType = $("#nodeOpenType").combobox("getValue");
                CurrentEntity.F_OpenSpace = $("#nodeOpenSpeace").textbox("getText");
                CurrentEntity.F_Tips = $("#nodeTips").textbox("getText");
                CurrentEntity.F_Remark = $("#nodeRemark").textbox("getText");
                CurrentEntity.F_State = $("#ck").prop("checked") ? 1 : 0;
                var PostArrar = [];
                PostArrar[0] = CurrentEntity;
                AjaxHelper.CallFunction("SAVE_Single_SYS_Function", PostValue = { PostEntity: JSON.stringify(PostArrar) }, false,
                    function (d) {
                        if (d.Code == 1) {
                            msgbox.info("保存成功！");
                            //自身重加载(功能内全部)
                            SelfLoadFunc();
                            //主窗体重加载(可显示的)
                            parent.PortalLoadFunc(true,0);
                        }
                    },
                    function (e) {
                        msgbox.error(e);
                    });
            });
        });
    </script>
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'west',split:true" style="width: 220px;">
            <div class="easyui-layout" data-options="fit:true">
                <div data-options="region:'north'" style="width: 100%; height: 32px; padding: 2px">
                    <input id="MgrFuncFilter" class="easyui-textbox" style="width: 100%;" data-options="prompt: '输入拼音过滤',iconWidth: 22" />
                </div>
                <div data-options="region:'center'">
                    <ul id="MgrFuncTree" class="easyui-tree" data-options="animate:true,lines:true,cache:true"></ul>
                </div>
            </div>
        </div>
        <div data-options="region:'center'">
            <div class="easyui-layout" data-options="fit:true">
                <div data-options="region:'north'" style="width: 100%; height: 32px; padding: 2px">
                    <a id="btnAdd" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-add'" style="margin-left: 4px; margin-bottom: 2px">添加</a>
                    <a id="btnDel" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-remove'" style="margin-left: 10px">删除</a>
                    <a id="btnSave" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'" style="margin-left: 10px">保存</a>
                </div>
                <div data-options="region:'center'">
                    <div style="margin: 4px">
                        功能名称：
                        <input id="nodeText" class="easyui-textbox" style="width: 286px; height: 32px" />
                    </div>
                    <div style="margin: 4px">
                        连接地址：
                        <input id="nodeURL" class="easyui-textbox" style="width: 286px; height: 32px" />
                    </div>
                    <div style="margin: 4px">
                        功能图标：
                        <input id="nodeIcon" class="easyui-textbox" style="width: 286px; height: 32px" />
                    </div>
                    <div style="margin: 4px">
                        打开方式：
                        <input id="nodeOpenType" class="easyui-combobox" data-options="valueField:'id',textField:'text',data:[{id: '0',text: 'Tab 方式'},{id: '1', text: '弹出窗体'}]" style="width: 286px; height: 32px" />
                    </div>
                    <div style="margin: 4px">
                        打开尺寸：
                        <input id="nodeOpenSpeace" class="easyui-textbox" style="width: 286px; height: 32px" />
                    </div>
                    <div style="margin: 4px">
                        悬停提示：
                        <input id="nodeTips" class="easyui-textbox" style="width: 286px; height: 32px" />
                    </div>
                    <div style="margin: 4px">
                        备注信息：
                        <input id="nodeRemark" class="easyui-textbox" style="width: 286px; height: 32px" />
                    </div>
                    <div style="margin: 4px; margin-top: 8px; cursor: pointer" >
                        <div style="float: left" id="checkboxdiv">是否关闭：</div>
                        <div>
                            <input id="ck" style="margin-top: 0px; margin-left: -1px" type="checkbox" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
