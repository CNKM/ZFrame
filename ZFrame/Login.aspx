<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZFrameWeb.Login" %>

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
    </style>
    <script>
        WindowResizeEvent = function () {
            $("#LoginFrm").window("center");
        }
        var UserLogin = function () {
            var CValue = {
                UserName: $("#txtUserName").textbox("getText"),
                PassWord: $("#txtUserPWD").textbox("getText"),
                CheckCode: $("#txtCheckCode").textbox("getText"),
                ChooseDept: function () {
                    var selectrows = $("#gdChooseDept").datagrid("getSelected");
                    if (selectrows != null) {
                        return selectrows.F_SN;
                    }
                    else { return ""; }
                }
            };

            CValue.CheckCode = $("#txtCheckCode").textbox("getText");
            
            if (StringHelper.IsNullOrEmpty(CValue.UserName)) {
                alert("登录帐号不能为空！");
                return;
            }
            if (StringHelper.IsNullOrEmpty(CValue.PassWord)) {
                alert("登录密码不能为空！");
                return;
            }
            if (StringHelper.IsNullOrEmpty(CValue.CheckCode)) {
                alert("验证编码不能为空！");
                return;
            }
            
            AjaxHelper.CallFunction("UserLoginCheck", CValue,true, function (data) {
                if (data.Code == 1) {
                    JumpToPortal();
                }
                else if (data.Code == -4) {
                    $("#LoginFrm").window({ height: 360 });
                    $("#extTable").show();
                    $("#gdChooseDept").datagrid({
                        data: data.Contend
                    });
                    alert(data.Msg);
                }
                else {
                    $("#LoginFrm").window({ height: 200 });
                    $("#extTable").hide();
                    $("#gdChooseDept").datagrid({
                        data: []
                    });
                    alert(data.Msg);
                }
            }, function (e) {
                alert(e);

            });
        }
        var LoadCheckCode = function () {
            AjaxHelper.CallFunction("GetCheckCodeImage", null,false,
                function (data) {
                    var val = data;
                    $("#icheckcode").attr("src", "data:image/gif;base64," + val.Contend);
                }, function (eeror) {
                });
        }
        $(document).ready(function () {
            //for debug
            $("#txtUserName").textbox("setText", "superadmin");
            $("#txtUserPWD").textbox("setText", "saynccl");
            $("#txtCheckCode").textbox("setText", "123456");
            UserLogin();

            LoadCheckCode();
           
            $('#txtUserName').textbox("textbox").focus();
            $("#txtUserName").textbox("textbox").bind("keydown", function (e) {
                if (e.keyCode == 13) {
                    $("#txtUserPWD").textbox("textbox").focus();
                }
            });
            $("#txtUserPWD").textbox("textbox").bind("keydown", function (e) {
                if (e.keyCode == 13) {
                    $("#txtCheckCode").textbox("textbox").focus();
                }
            });
            $("#txtCheckCode").textbox("textbox").bind("keydown", function (e) {
                if (e.keyCode == 13) {
                    UserLogin();
                }
            })
            $("#btnLogin").click(function () {
                UserLogin();
            });
            $("#btnCancel").click(function () {
                LoadCheckCode();
                $("#txtUserName").textbox("setText", "superadmin");
                $("#txtUserPWD").textbox("setText", "saynccl");
                $("#txtCheckCode").textbox("setText", "123456");
                $("#txtUserName").textbox("textbox").focus();
            })
        });
    </script>
    
    <div id="LoginFrm" class="easyui-window" title="用户登陆"
        data-options="iconCls:'icon-login-user',closable:false,minimizable:false,maximizable:false,collapsible:false,resizable:false,shadow:true,draggable:false"
        style="width: 400px; height: 200px; top: 200px;">
        <div style="text-align: center; overflow: hidden; margin-top: 11px; font-size: 13.5px">
            <div style="width: 380px; margin: 5px;">
                登陆姓名:
                <input id="txtUserName" class="easyui-textbox" data-options="prompt:'请输入管理员分配的账号...',iconCls:'icon-search',iconAlign:'left'" style="width: 70%; height: 25px" />
            </div>
            <div style="width: 380px; margin: 5px; margin-top: 4px">
                登陆密码:
                <input id="txtUserPWD" class="easyui-textbox" type="password" data-options="prompt:''" style="width: 70%; height: 25px" />
            </div>
            <div style="float: left; margin: 5px; margin-top: 1px; width: 196px">
                验证密码:
                    <input id="txtCheckCode" class="easyui-textbox" type="password" data-options="prompt:''"  style="height: 25px; width: 80px" />
            </div>
            <div style="float: left; margin-left: -30px; margin-top: 3px">
                <img id="icheckcode" src="" title="看不清楚？点击更换" style="margin-top: 3px;" />
            </div>
            <div style="clear: both;"></div>
            <table id="extTable" style="width: 380px; margin-left: 5px; display: none">
                <tr>
                    <td style="text-align: center">
                        <table id="gdChooseDept" class="easyui-datagrid" title="部门角色选择" style="width: 370px; height: 160px;"
                            data-options="singleSelect:true,collapsible:false,rownumbers:true,">
                            <thead>
                                <tr>
                                    <th data-options="field:'ck',checkbox:true"></th>
                                    <th data-options="field:'F_DeptName',width:80">部门名称</th>
                                    <th data-options="field:'F_Name',width:100">角色名称</th>
                                </tr>
                            </thead>
                        </table>
                    </td>
                </tr>
            </table>

            <div style="width: 100%; margin: 5px; margin-top: 8px;">
                <a href="#" id="btnLogin" class="easyui-linkbutton" data-options="iconCls:'icon-search'" style="width: 80px">登陆</a>
                <a href="#" id="btnCancel" class="easyui-linkbutton" data-options="iconCls:'icon-search'" style="width: 80px; margin-left: 10px">取消</a>
            </div>
        </div>
    </div>
</asp:Content>

