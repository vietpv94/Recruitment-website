<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAccount.aspx.cs" Inherits="Admin_AddAccount" %>

<%@ Register Src="~/Admin/controls/HeaderAdmin.ascx" TagPrefix="uc1" TagName="HeaderAdmin" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Skin/Styles/nivo-slider.css" rel="stylesheet" />
    <script src="../Skin/Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <script src="../Skin/Scripts/bootstrapValidator.js"></script>
    <title>Thêm tài khoản</title>
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
                       <%=txtEmail.UniqueID%>: {
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
             
                    <%=txtPhone.UniqueID%>: {
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
        <div>
            <uc1:HeaderAdmin runat="server" ID="HeaderAdmin" />
            <div style="width: 970px; margin-left: 135px; margin-top: 20px;">
                <div class="form-group">
                    <label>Email </label>
                    <input id="txtEmail" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label>Password </label>
                    <input id="txtPass" class="form-control" runat="server" />

                </div>

                <div class="form-group">
                    <label>Số điện thoại: </label>
                    <input id="txtPhone" class="form-control" runat="server" />

                </div>

                <div class="form-group">
                    <label>Họ: </label>
                    <input id="txtLastname" class="form-control" runat="server" />
                </div>

                <div class="form-group">
                    <label>Tên: </label>
                    <input id="txtfirstname" class="form-control" runat="server" />

                </div>
                <asp:Button ID="btSubmit" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btSubmit_OnClick" />
            </div>
        </div>
    </form>
</body>
</html>
