<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerifyAccount.aspx.cs" Inherits="Notify.PagesVerifyAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <div id="alertText" runat="server" style="color: green; font-size: 18pt; text-align: center;">
        </div>
        <a href="http://<%=Request.Url.Host%>:<%=Request.Url.Port%>/Home.aspx" style="text-align: center;"id="homepage">Trở về trang chủ</a></div>
    </form>
</body>
</html>
