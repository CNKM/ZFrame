<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="ZFrameWeb.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <table id="dg" title="数据列表" class="easyui-datagrid" style="width: 100%;"
        data-options="fit:true,singleSelect:false,collapsible:false,url:'Func/GetListUsers',method:'get',loadFilter:GridJsonRows" 
        rownumbers="true" pagination="true" pagesize="10">
        <thead>
            <tr>
                <th data-options="field:'ck',checkbox:true"></th>
                <th data-options="field:'F_SN',width:80" sortable="true">SN</th>
                <th data-options="field:'F_UserName',width:100" sortable="true">名字</th>
            </tr>
        </thead>
    </table>
</asp:Content>
