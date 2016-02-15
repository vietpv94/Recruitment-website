<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng Ký</title>

    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="../Skin/Styles/jquery.datetimepicker.css" rel="stylesheet" />
    <link href="../Skin/Styles/common.css" rel="stylesheet" />
    <link href="../Skin/Styles/Registration.css" rel="stylesheet" />
    <link href="../Skin/Styles/LogIn.css" rel="stylesheet" />
    <script src="../Skin/Scripts/jquery-1.8.3.js"></script>
    <script src="Skin/Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <script src="../Skin/Scripts/jquery.datetimepicker.js"></script>
    <script src="../Skin/Scripts/bootstrapValidator.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".container_16").css("width", "1116px");
            $(".grid_16").css("width", "1116px");
            $('.rdatetime-picker').datetimepicker({
                format:'d/m/Y',
                lang:'vi'
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#form1').bootstrapValidator({
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                message: "Vui lòng nhập đầy đủ thông tin",
                fields: {
                    // There is no single quote
                    <%=tbInputEmail.UniqueID%>: {
                        validators: {
                            notEmpty: {
                                message: 'Vui lòng nhập email của bạn'
                            },
                            regexp: {
                                regexp: /\w+([-+.']\w+)*@\w+([-.]\w+)*\+?\.[a-zA-Z]{2,3}$/,
                                message: 'Email chưa đúng định dạng'
                            }
                        }
                    },       <%=tbEmailRecruiment.UniqueID%>: {
                    validators: {
                        notEmpty: {
                            message: 'Vui lòng nhập email của bạn'
                        },
                        regexp: {
                            regexp: /\w+([-+.']\w+)*@\w+([-.]\w+)*\+?\.[a-zA-Z]{2,3}$/,
                            message: 'Email chưa đúng định dạng'
                        }
                    }
                },
             
                    <%=tbCompanyPhone.UniqueID%>: {
                    validators: {
                        regexp: {
                            regexp: /^((0|01|\+841|\+84)\d{9})$/,
                            message: 'Số điện thoại chưa đúng định dạng'
                        }
                    }
                }
                }
            });
        });
    
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="grid_16">
            <div class="register2 clearfix">
                <div class="pull-left">
                    <h3>Đăng ký tài khoản</h3>
                </div>

                <div class="pull-right">
                    <div class="register-form">
                        <ul class="nav nav-tabs">
                            <li class="active">
                                <a data-toggle="tab" href="#employee">Dành cho cá nhân</a>
                            </li>
                            <li class="">
                                <a data-toggle="tab" href="#recruiment">Dành cho doanh nghiệp</a>
                            </li>
                        </ul>

                        <div class="tab-content">
                            <div id="employee" class="tab-pane fade in active">
                                <asp:Label ForeColor="Red" ID="lblMessage" runat="server" Visible="False" Text=""></asp:Label>

                                <div class="form-group">
                                    <input type="text" id="tbInputEmail" runat="server" class="form-control" placeholder="Nhập địa chỉ Email(*)" required="" data-bv-message="Vui lòng nhập email của bạn" data-fv-live="Bạn chưa nhập email của bạn" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbInputPassword" runat="server" placeholder="Mật khẩu(*)" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbRe_InputPassword" runat="server" placeholder="Xác nhận mật khẩu(*)" CssClass="form-control" TextMode="Password"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbInputLastName" runat="server" placeholder="Họ(*)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbInputFirstName" runat="server" placeholder="Tên(*)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Ngày tháng năm sinh</label>
                                    <div class="clearfix">
                                        <input type="text" class="form-control rdatetime-picker" id="tbInputDateOfBirth" runat="server" placeholder="Ngày sinh (*)" required="" data-bv-message="Vui lòng cho chúng tôi biết ngày sinh của bạn!" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>Giới tính</label>
                                    <asp:DropDownList ID="ddlSex" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Nam" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Nữ" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Khác" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" runat="server" id="checkPolicy2"/>
                                        Tôi đã đọc và đồng ý với các <a href="#">Quy định bảo mật</a> và <a href="#">Thỏa thuận sử dụng</a></label>
                                </div>
                                <asp:Button ID="btEmployeeSignUp" runat="server" CssClass="btn btn-primary" Text="Đăng ký" OnClick="btEmployeeSignUp_Click" />
                            </div>
                            <div id="recruiment" class="tab-pane fade">
                                <asp:Label ForeColor="Red" ID="lblMessage2" runat="server" Visible="False" Text=""></asp:Label>
                                <div class="form-group">
                                    <input type="text" id="tbEmailRecruiment" runat="server" class="form-control" placeholder="Nhập địa chỉ Email(*)" required="" data-bv-message="Vui lòng nhập email của bạn" data-fv-live="Bạn chưa nhập email của bạn" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbPasswordRecruiment" runat="server" placeholder="Mật khẩu(*)" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbRe_PasswordRecruiment" runat="server" placeholder="Xác nhận mật khẩu(*)" CssClass="form-control" TextMode="Password"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbLastNameRecruiment" runat="server" placeholder="Họ(*)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbFirstNameRecruiment" runat="server" placeholder="Tên(*)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group" style="display: block; height: 1px; border-bottom: 1px solid #ddd; margin: 20px 0 25px">
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbCompanyName" runat="server" placeholder="Tên Công Ty(*)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbCompanyAddress" runat="server" placeholder="Địa Chỉ" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" id="tbCompanyPhone" runat="server" placeholder="Số điện thoại (*)" required="" data-bv-message="Vui lòng nhập đầy đủ số điện thoại của bạn" />
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlQuyMoCongTy" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="checkPolicy" runat="server" />
                                        Tôi đã đọc và đồng ý với các <a href="#">Quy định bảo mật</a> và <a href="#">Thỏa thuận sử dụng</a>
                                    </label>
                                </div>
                                <asp:Button ID="btRecruitorSignUp" runat="server" CssClass="btn btn-primary" Text="Đăng ký" OnClick="btRecruitorSignUp_Click" />

                            </div>
                        </div>
                    </div>
                    <!-- end .register-form -->
                </div>
            </div>
        </div>
        <!-- end .register1 -->
        <!-- end .grid_16 -->
    </form>

</body>
</html>
