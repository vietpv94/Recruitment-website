<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="Admin_ChangePass" %>

<%@ Register Src="~/Admin/controls/HeaderAdmin.ascx" TagPrefix="uc1" TagName="HeaderAdmin" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-theme.css" rel="stylesheet" />
     <script src="../Skin/Scripts/jquery-1.11.1.min.js"></script>
     <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <title>Đổi Mật Khẩu</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:HeaderAdmin runat="server" ID="HeaderAdmin" />
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                    <label class="box-title" style="font-size: 26px; text-transform: uppercase; margin: 30px 0; color: #274782;">
                        Đổi mật khẩu</label>
                </div>
                <div class="box-body">
                    <div class="form-group">
                        <label>Mật khẩu hiện tại:</label>
                        <asp:TextBox runat="server" Width="40%" ID="txtCurentPass" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Mật khẩu mới:</label>
                        <asp:TextBox runat="server" Width="40%" ID="txtNewPass" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Nhập lại mật khẩu mới:</label>
                        <asp:TextBox runat="server" Width="40%" ID="txtConfirmPass" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="box-footer">
                    <asp:Button runat="server" ID="btnSubmit" Text="Thực hiện" OnClick="btnSubmit_OnClick" CssClass="btn btn-primary" />
                </div>
            </div>

        </div>
    </div>
    </form>
</body>
</html>
