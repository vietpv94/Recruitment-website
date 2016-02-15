<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng Nhập</title>
    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="../Skin/Styles/common.css" rel="stylesheet" />
    <link href="../Skin/Styles/LogIn.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="grid_16" style="margin-left: 130px">
           
            <div class="register1 clearfix">
                <div class="pull-left" runat="server" id="logintitle">
                    <h2 style="color: #0896ff; margin-left: 228px; margin-bottom: -60px; margin-top: 2px">Đăng nhập để xem chi tiết....</h2>
                    <div class="box" style="height: 296px; margin-top: 23px">
                        <p><strong>Truy cập hàng ngàn công việc</strong></p>
                        <p>Xem trên 3.000 việc mới hàng tháng và nộp hồ sơ trực tuyến ngay!</p>
                        <p><strong>Việc tìm bạn</strong></p>
                        <p>Tạo Thông Báo Việc Làm để nhận được nhiều việc mới phù hợp bằng email.</p>
                        <p><strong>Tư vấn nghề nghiệp</strong></p>
                        <p>Trang Quản lý Nghề Nghiệp sẽ giúp bạn viết hồ sơ xin việc và phỏng vấn thành công.</p>
                    </div>
                    <!-- end .box -->
                </div>
                <div class="pull-right" runat="server" id="loginform">
                    <div class="login-form" style="margin-top: -2px" >
                        <h2>Đăng nhập</h2>
                        <div class="form-group">
                            <label>Nhập địa chỉ Email</label>
                            <asp:TextBox ID="txtEmailId" placeholder="Tài khoản" CssClass="form-control " runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Mật khẩu</label>
                            <asp:TextBox ID="txtPassWord" TextMode="Password" placeholder="Mật khẩu" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_OnClick" Text="Đăng nhập" runat="server" /><br />
                        <br />
                        <a class="forgetpass" href="Login.aspx?forgotpass=yes" id="anchorForgetPassword" runat="server">Quên mật khẩu</a>
                    </div>
                    <!-- end .login-form -->
                    <div class="login-with">
                        <h4>Đăng nhập với</h4>
                        <ul>
                            <li class="fb"><a href="#">facebook</a></li>
                            <li class="gg"><a href="#">Google</a></li>
                            <li class="in"><a href="#">Linkedln</a></li>
                        </ul>
                    </div>
                  
                    <!-- end .login-with -->
                </div>
                
                    <div class="pull-right " runat="server" id="forgotpass" style="margin-left: 93px">
                        <div class="forgot-form">
                            <h2 id="hForgetpassword" runat="server">Quên mật khẩu</h2>
                            <div class="form-group">

                                <label for="inputEmail" id="lblForgetEmail" runat="server">Nhập địa chỉ email:</label>

                                <input type="text" class="form-control required email" id="inputEmail" placeholder="" runat="server"/>
                            </div>
                            <asp:Button runat="server" ID="btnForgot" Text="Lấy lại mật khẩu" CssClass="btn btn-primary" OnClick="btnForgot_Click" />
                            <a id="backtologin" href="Login.aspx?dangnhap=yes" runat="server">Trở lại đăng nhập</a>
                        </div>
                    </div>
               
            </div>
            <!-- end .register1 -->
        </div>
        <!-- end .grid_16 -->
    </form>
</body>
</html>
