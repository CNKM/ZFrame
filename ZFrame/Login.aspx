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
            top: 10px !important;
        }

        .panel-with-icon {
            padding-left: 35px !important;
            padding-top: 8px;
            padding-bottom: 3px;
            font-size: 16px;
        }
        .CheckCodeLine {
            float:left;
            *margin-left:30px;
            margin-left:35px;
            
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
        <div style="text-align: center; overflow: hidden; margin-top: 11px; font-size: 13.5px">
            <div style="width: 100%; margin: 5px;">登陆姓名: <input class="easyui-textbox" data-options="prompt:'请输入管理员分配的账号...'" style="width: 70%; height: 25px" /></div>
            <div style="width: 100%; margin: 5px; margin-top: 4px">登陆密码: <input class="easyui-textbox" data-options="prompt:'请输入用户密码...'" style="width: 70%; height: 25px" /></div>
            <div style="width: 100%; margin: 5px;margin-left:32px">
                <div style="float:left;">
                    验证密码: <input class="easyui-textbox" data-options="prompt:'请输入右侧验证码...',validType:'email'" type="password" style="height: 25px; width: 120px" />
                </div>
                <div style="float: left; margin-left: 4px">
                    <img id="icheckcode" src="VCode.aspx" title="看不清楚？点击更换" style="margin-top: 3px;" />
                </div>
            </div>
            <div style="width: 100%; margin: 5px; float: left; margin-top: 8px">
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" style="width: 80px">登陆</a>
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" style="width: 80px; margin-left: 10px">取消</a>
            </div>

        </div>
    </div>
</asp:Content>

