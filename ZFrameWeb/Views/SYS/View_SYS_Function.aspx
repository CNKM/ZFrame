<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="View_SYS_Function.aspx.cs" Inherits="ZFrameWeb.Views.SYS.View_SYS_Function" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script>
        $(function () {
            InitTreeWithFilter($("#MgrFuncTree"), $("#MgrFuncFilter"), function (node) {
                alert("click");
            }, CurrentLoginObject.CurrentFuncs);
        });
    </script>
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'west',split:true" style="width: 180px;">
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
                    <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-add'" style="margin-left: 4px; margin-bottom: 2px">添加</a>
                    <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-remove'" style="margin-left: 10px">删除</a>
                    <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'" style="margin-left: 10px">保存</a>
                </div>
                <div data-options="region:'center'">
                    <div style="margin: 4px">
                        功能名称：
                        <input class="easyui-textbox" style="width: 286px; height: 32px">
                    </div>
                    <div style="margin: 4px">
                        连接地址：
                        <input class="easyui-textbox" style="width: 286px; height: 32px">
                    </div>
                    <div style="margin: 4px">
                        功能图标：
                        <input class="easyui-textbox" style="width: 286px; height: 32px">
                    </div>
                    <div style="margin: 4px">
                        打开方式：
                        <input class="easyui-textbox" style="width: 286px; height: 32px">
                    </div>
                    <div style="margin: 4px">
                        打开尺寸：
                        <input class="easyui-textbox" style="width: 286px; height: 32px">
                    </div>
                    <div style="margin: 4px">
                        是否关闭:
                        <div class="datagrid-cell-check">
                            <input name="ck" type="checkbox">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
