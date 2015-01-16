<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="View_SYS_Function.aspx.cs" Inherits="ZFrameWeb.Views.SYS.View_SYS_Function" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'west',split:true" style="width: 180px;">
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
</asp:Content>
