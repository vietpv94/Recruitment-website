<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotificationCenter.aspx.cs" Inherits="Notify.PagesNotificationCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="title" runat="server">Trung tâm thông báo</title>
    <meta http-equiv="content-tyle" content="text/html;charset=UTF-8" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script type="text/javascript">
        var delay = 5000;
        setTimeout(function () { window.location = "<%=RefUrl%>"; }, delay);
        $(function () {
            var counter = 5;
            function tick() {
                addText(counter);
                setTimeout(tick, 1000);
                if(counter > 0)
                    counter--;
            }

            function addText(strNum) {
                $("#countdown").empty();
                $("#countdown").text(strNum + "");
            }
            tick();
        });
        
    </script>
    <style type="text/css">
        * {margin:0;padding:0;}
        li {display:block;}
        li a {font-size:13px;}
        * {font-family:Arial, sans-serif;}
        #container {margin-top: 30px;}
        h3 {font-size:17px;margin:5px;text-align:center;color:teal;font-weight:normal;}
        h4 {font-size:15px;}
        h5 {font-size: 13px;text-align:center;}
        #Option {margin:30px 0;text-align:center;}
        #countdown {color: red;}
        #Reg_success_msg1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <asp:Panel runat="server" ID="CheckOut" Visible="false">
            <asp:Panel runat="server" ID="CheckOut_success" Visible="false">
                <h3 id="Checkout__success_msg" runat="server">Thanh toán thành công.</h3>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel runat="server" ID="Register" Visible="false">
            <asp:Panel runat="server" ID="Reg_success" Visible="false">
                <h1 id="Reg_success_msg1" runat="server">Bạn đã đăng ký tài khoản thành công.</h1>
                <h3 id="Reg_success_msg2" runat="server">Một email kích hoạt đã được gửi đến email của bạn.</h3>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel runat="server" ID="ForgotPass" Visible="false">
            <asp:Panel runat="server" ID="Forgot_success" Visible="false">
                <h3 id="Forgot_success_msg1" runat="server">Một email đã được gửi đến hòm thư của bạn.</h3>
                <h3 id="Forgot_success_msg2" runat="server">Hãy làm theo hướng dẫn để thay đổi mật khẩu của bạn.</h3>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel runat="server" ID="Option">
            <h4 id="Option_msg" runat="server">Bạn có thể chọn một trong các tùy chọn sau:</h4>
            <ul>
                <li>
                    <a id="Option_link_prev"  href="<%=RefUrl %>">Trở về trang trước</a>
                    <a id="Option_link_home"  href="<%=Url %>">Trở về trang chủ</a>
                </li>
            </ul>
        </asp:Panel>
        <h5><span id="redirect_msg" runat="server">Bạn sẽ được tự động chuyển hướng sau</span> <span id="countdown"></span> <span id="second" runat="server">giây</span></h5>
    </div>
    </form>
</body>
</html>
