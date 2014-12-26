<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZFrame.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style>
        /*http://ie.microsoft.com/testdrive/Graphics/CSSGradientBackgroundMaker/Default.html*/
        body {
            /* Note: This gradient may render differently in browsers that don't support the unprefixed gradient syntax */
            /* IE10 Consumer Preview */
            background-image: -ms-linear-gradient(bottom right, #FFFFFF 0%, #47A3FF 200%);
            /* Mozilla Firefox */
            background-image: -moz-linear-gradient(bottom right, #FFFFFF 0%, #47A3FF 200%);
            /* Opera */
            background-image: -o-linear-gradient(bottom right, #FFFFFF 0%, #47A3FF 200%);
            /* Webkit (Safari/Chrome 10) */
            background-image: -webkit-gradient(linear, right bottom, left top, color-stop(0, #FFFFFF), color-stop(2, #47A3FF));
            /* Webkit (Chrome 11+) */
            background-image: -webkit-linear-gradient(bottom right, #FFFFFF 0%, #47A3FF 200%);
            /* W3C Markup, IE10 Release Preview */
            background-image: linear-gradient(to top left, #FFFFFF 0%, #47A3FF 200%);
        }

        .panel-icon {
            width: 32px !important;
            height: 32px !important;
            top:10px !important;
        }

        .panel-with-icon {
            padding-left:35px !important;
            padding-top:8px;
            padding-bottom:3px;
            font-size:16px;
        }
    </style>
    <script>
        WindowResizeEvent = function () {
            $("#LoginFrm").window("center");
        }
    </script>
    <div id="LoginFrm" class="easyui-window" title="用户登陆"
        data-options="iconCls:'icon-login-user',closable:false,minimizable:false,maximizable:false,collapsible:false,resizable:false,shadow:true,draggable:false"
        style="width: 400px; height: 200px; top: 200px;">
    </div>
</asp:Content>

