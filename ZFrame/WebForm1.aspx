<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ZFrame.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="<%:ResolveUrl("~/Scripts/jquery-easyui-1.4.1/themes/default/easyui.css")%>" rel="stylesheet" />
    <link href="<%:ResolveUrl("~/Scripts/jquery-easyui-1.4.1/themes/icon.css")%>" rel="stylesheet" />

    <link href="<%:ResolveUrl("~/Images/Icons/ExtIconsLib.css")%>" rel="stylesheet" />
    <%--JS--%>
    <script src="<%:ResolveUrl("~/Scripts/jquery-2.1.1.min.js") %>"></script>
    <script src="<%:ResolveUrl("~/Scripts/jquery-easyui-1.4.1/jquery.easyui.min.js") %>"></script>
    <script src="<%:ResolveUrl("~/Scripts/jquery-easyui-1.4.1/locale/easyui-lang-zh_CN.js")%>"></script>
    <script src="<%:ResolveUrl("~/Scripts/Comm/JComm.js") %>"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <input id="txtCheckCode" class="easyui-textbox" data-options="" type="password" style="height: 25px; width: 80px" />
    </div>
    </form>
</body>
</html>
