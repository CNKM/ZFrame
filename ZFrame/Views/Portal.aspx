<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="Portal.aspx.cs" Inherits="ZFrameWeb.Views.Portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script>
        $(function () {
            $("#MainTab").tabs({ height: $(window).height() });
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
                        <ul class="easyui-tree" data-options="url:'tree_data1.json',method:'get',animate:true"></ul>
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
