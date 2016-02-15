<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs"
    Inherits="Notify.PagesRecoverPassword" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Khôi phục mật khẩu</title>
    <meta http-equiv="content-tyle" content="text/html;charset=UTF-8" />
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <div class="int-log-from register">
            <h1 class="title-from">
                Khôi phục mật khẩu</h1>
            <div style="margin-bottom:10px;overflow:hidden">
                <label style="width: 170px; margin-left: 5px;float:left;margin-top:3px">
                    Mật khẩu mới:
                </label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="text-medium required" TextMode="Password"
                    Style="width: 200px;border:solid 1px #ccc;height:22px;" />
            </div>
            <div style="margin-bottom:10px;overflow:hidden">
                <label style="width: 170px; margin-left: 5px;float:left;margin-top:3px">
                    Xác nhận mật khẩu mới:
                </label>
                <asp:TextBox runat="server" ID="txtRePassword" CssClass="text-medium required" TextMode="Password"
                    Style="width: 200px;border:solid 1px #ccc;height:22px" />
            </div>
            
            <div style="padding: 10px 0px 20px 173px;">
                <input type="submit" id="btnSubmit" onclick="if (typeof(Page_ClientValidate) == 'function') Page_ClientValidate(''); "
                    onserverclick="SubmitForms" value="Thực hiện" runat="server" style="cursor:pointer;margin-right:10px"/>
                <a href="#" id="homepage" runat="server" style="color: #004B91">Quay
                    về trang chủ</a>
            </div>
            <!--End .more-info-->
        </div>
    </div>
    </form>
</body>
</html>
