<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Skin/Styles/Header/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Skin/Styles/Header/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/Header/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/Header/bootstrap.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/adminlogin.css" rel="stylesheet" />
     <script src="../Skin/Scripts/jquery-1.11.1.min.js"></script>
     <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <title>Đăng nhập</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-box">
            <div class="box-header">
                <p>Đăng Nhập</p>
            </div>
            <div class="box-body">
                <asp:TextBox ID="txtUserId" placeholder="Tài khoản" CssClass="form-control login-textBox" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtPassWord" TextMode="Password" placeholder="Mật khẩu" CssClass="form-control login-textBox" runat="server"></asp:TextBox>
                <asp:Button ID="btnSubmit" CssClass="button btnLogin"  Text="Đăng nhập" runat="server" OnClick="btnSubmit_OnClick" />
            </div>
            <div class="box-footer">
                <asp:Label ID="ltrMessage" CssClass="text-warning" Visible="False" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

