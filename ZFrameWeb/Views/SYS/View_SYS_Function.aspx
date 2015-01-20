<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="View_SYS_Function.aspx.cs" Inherits="ZFrameWeb.Views.SYS.View_SYS_Function" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            var CurrentNode = {
                F_SN: CurrentNode.id,
                F_PlatformType: CurrentNode.id,
                F_ParentSN: null,
                F_FuncRightGroup: null,
                F_Name: CurrentNode.text,
                F_URL: "",
                F_Icon: "",
                F_Tips: "",
                F_OpenType: "",
                F_OpenSpace: "",
                F_Remark: "",
                F_State: "",
                F_Index: "",
                F_IsDel: ""
            };
            $("#MgrFuncTree").tree({
                formatter: function (node) {
                    return '<span title="' + node.attributes[5].Value + '">' + node.text + '</span>';
                }
            })
            InitTreeWithFilter($("#MgrFuncTree"), $("#MgrFuncFilter"), function (node) {
                //CurrentNode.F_SN = node.id;
                //CurrentNode.F_Icon =node.iconCls;
                //CurrentNode.
                $("#nodeText").textbox("setText", node.text);
                $("#nodeURL").textbox("setText", node.attributes[0].Value);
                $("#nodeIcon").textbox("setText", node.iconCls);

                var opentype = node.attributes[2].Value;
                $("#nodeOpenType").combobox("setValue", opentype);
                $("#nodeOpenSpeace").textbox("setText", node.attributes[3].Value);

                var state = (node.attributes[4].Value);
                if (state == 1) {
                    $("#ck").prop("checked", true);
                } else {
                    $("#ck").prop("checked", false);
                }

                $("#nodeTips").textbox("setText", node.attributes[5].Value);
                $("#nodeRemark").textbox("setText", node.attributes[6].Value);
            }, parent.CurrentLoginObject.CurrentFuncs);

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
                    <div style="margin: 4px; margin-top: 8px; cursor: pointer" id="checkboxdiv">
                        <div style="float: left">是否关闭：</div>
                        <div>
                            <input id="ck" style="margin-top: 0px; margin-left: -1px" type="checkbox" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
