<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderAdmin.ascx.cs" Inherits="Admin_controls_HeaderAdmin" %>
<link href="../../Skin/Styles/Header/Adminheader.css" rel="stylesheet" />
<div>
    <div class="container full-section menu">
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-md-10 no-padding">
                        <nav class="navbar navbar-default">
                            <div class="container-fluid no-padding">
                                <!-- Brand and toggle get grouped for better mobile display -->
                                <div class="navbar-header">
                                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                                        <span class="sr-only">Toggle navigation</span>
                                        <span class="icon-bar"></span>
                                        <span class="icon-bar"></span>
                                        <span class="icon-bar"></span>
                                    </button>
                                    <a class="navbar-brand hidden" href="#"><i class="glyphicon glyphicon-home"></i></a>
                                </div>

                                <!-- Collect the nav links, forms, and other content for toggling -->
                                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                                    <ul class="nav navbar-nav" style="font-size: 13px">
                                        <li class="active"><a href="/Admin/Index.aspx">Bàn làm việc<span class="sr-only">(current)</span></a></li>
                                        <li runat="server" id="godAccount"><a href="/Admin/Accounts.aspx">Quản lý tài khoản</a></li>
                                        <li><a href="/Admin/RecruitementManage.aspx">Quản lý tin tuyển dụng </a></li>
                                        <li runat="server" id="godAccount1"><a href="/Admin/AddAccount.aspx">Thêm tài khoản quản trị </a></li>
                                        <li class="dropdown"><a href="#" data-toggle="dropdown" role="button" aria-expanded="false">Quản lý Người Dùng <span class="caret"></span></a>
                                            <ul class="dropdown-menu" role="menu" style="background-color: #183F56">
                                                <li><a href="/Admin/UserManagement.aspx">Người tìm việc</a></li>
                                                <li><a href="/Admin/RecruitorManagement.aspx">Nhà tuyển dụng</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                                <!-- /.navbar-collapse -->
                            </div>
                            <!-- /.container-fluid -->
                        </nav>
                    </div>
                    <div class="col-md-2 hidden-sm hidden-xs">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="dropdown user user-menu">
                                <a class="dropdown-toggle" data-toggle="dropdown" aria-expanded="true">
                                    <i class="glyphicon glyphicon-user"></i>
                                    <span>ADMIN<i class="caret"></i></span>
                                </a>
                                <ul class="dropdown-menu second-menu" style="margin-right: 25px; background-color: #633C7B">
                                    <li class="user-body bg-light-blue">
                                        <a href="/Admin/ModifyAcount.aspx?UserId=<%=UserId %>">Thông tin tài khoản</a>
                                        <a href="/Admin/ChangePass.aspx">Đổi mật khẩu</a>
                                        <a href="/Admin/Temp.aspx?Action=1">Đăng xuất</a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
