<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControl.UiUserControlHeader" %>

<link href="../Skin/Styles/Header/bootstrap-theme.css" rel="stylesheet" />
<link href="../Skin/Styles/Header/bootstrap-theme.min.css" rel="stylesheet" />
<link href="../Skin/Styles/Header/bootstrap.css" rel="stylesheet" />
<link href="../Skin/Styles/Header/bootstrap.min.css" rel="stylesheet" />
<link href="../Skin/Styles/Header/header_style.css" rel="stylesheet" />
<header class="header">
    <a href="Home.aspx" class="logo">Kênh Tìm Việc Làm
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top bg-light-blue-gradient" role="navigation">
        <!-- Sidebar toggle button-->
        <div class="navbar-left">
            <ul class="nav navbar-nav">
                <li runat="server" id="Home"><a href="Home.aspx">Trang Chủ</a></li>
                <li  runat="server" id="menuSeekJob"><a href="FindJobs.aspx">Tìm Việc</a></li>
                <li runat="server" id="menuRecruiter"><a href="Recruiters.aspx" >Tìm Ứng Viên</a></li>
                <li runat="server" id="menuPostNews"><a href="PostNews.aspx">Đăng Tin Tuyển Dụng</a></li>
                <li runat="server" id="menuManager"><a href="ManageRecruitment.aspx">Quản Lý Tuyển Dụng</a></li>
                <li runat="server" id="divAdmin"><a href="Admin.aspx">Admin</a></li></ul>
        </div>
        <div class="navbar-right">
            <ul class="nav navbar-nav">
                <li style="margin-top: 5px; margin-right: 25px">
                    <div runat="server" id="btLogin">
                        <a class="btn btn-primary" href="Login.aspx?dangnhap=yes">Đăng nhập</a>
                    </div>
                    <div runat="server" id="btSignup">
                        <a class="btn btn-primary" href="Signup.aspx">Đăng Ký</a>
                    </div>
                    <!-- end .login -->
                </li>
                <li>
                   <div style="margin-top: 13px;color: #FCF8E3" id="divrecruiter" runat="server">
                    	<span>Xin Chào <%=UserName%></span>
                    	<a style="color: #00ffff; margin-right: 25px" href="Temp.aspx?Action=1">[Thoát]</a>
                    </div>
                   </li>            
                      
                <li class="dropdown user user-menu" >
                    <div runat="server" id="menu" style="margin-top: 13px">
                        <a style="margin-right: 40px;" class="dropdown-toggle" data-toggle="dropdown">
                            <i class="glyphicon glyphicon-user"></i>
                            <span class="dropdown-toggle">
                                <%=UserName%>
                                <i class="caret"></i>
                            </span>
                        </a>
                        </div>
                        <ul class="dropdown-menu second-menu" style="margin-right: 25px;background-color: #633C7B">
                            <li class="user-body bg-light-blue">
                                <a href="NewResume.aspx">Tạo hồ sơ</a>
                                <a href="MyResume.aspx">Quản lý hồ sơ</a>
                                <a href="InfoModify.aspx?UserId=<%=UserId%>">Thông tin cá nhân</a>
                                <a href="PassWordChange.aspx">Đổi mật khẩu</a>
                                <a href="Temp.aspx?Action=1">Đăng xuất</a>
                            </li>
                        </ul>
                </li>
            </ul>
        </div>
    </nav>
</header>
