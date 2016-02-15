<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoModify.aspx.cs" Inherits="InfoModify" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Skin/Styles/Contact_02.css" rel="stylesheet" />
    <link href="../Skin/Styles/Menu_02.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="../Skin/Styles/common.css" rel="stylesheet" />
    <link href="../Skin/Styles/Registration.css" rel="stylesheet" />
    <link href="../Skin/Styles/LogIn.css" rel="stylesheet" />
    <script src="../Skin/Scripts/jquery-1.8.3.js"></script>
    <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <title>Thông tin cá nhân</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="container_16" id="section1" style="margin-top: 30px; margin-left: 0">
            <div class="left col-md-3 ">
                <div class="photo">
                    <img src="<%=ThumbImg %>" alt="Avatar" id="avatar" style="width: 100%; height: 100%" />
                </div>
                <asp:FileUpload runat="server" ID="fuResume" />
            </div>
            <div class="col-md-9">
                <div class="box box-warning">
                    <div class="box-header">
                        <label class="box-title" style="font-size: 28px; text-transform: capitalize; color: #0D6F8C;">
                            Chỉnh sửa thông tin cá nhân
                        </label>
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <label>Họ và tên: </label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtName"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Ngày sinh (*): </label>
                            <asp:TextBox ID="txtDateOfBirth" placeholder="MM/dd/yyyy Ví dụ: 01/20/2014" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Submit" Display="Dynamic" ControlToValidate="txtDateOfBirth" Text="Thiếu" ForeColor="red" ErrorMessage="xd" runat="server"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Giới tính:</label>
                            <asp:DropDownList ID="ddlSex" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Nam" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Nữ" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Khác" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Tỉnh/Thành phố: </label>
                            <asp:DropDownList ID="ddlProvine" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProvine_OnSelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Huyện/Quận: </label>
                            <asp:DropDownList ID="ddlDistrict" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Số điện thoại: </label>
                            <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Nghề Nghiệp: </label>
                            <asp:DropDownList ID="ddlJob" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Dân Tộc: </label>
                            <asp:DropDownList ID="ddRaces" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Châm ngôn sống: </label>
                            <asp:TextBox TextMode="MultiLine" Height="150px" ID="txtMaxim" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <asp:Button runat="server" ID="btnUserInfoSubmit" Text="Thay đổi" CssClass="btn btn-primary" OnClick="btnUserInfoSubmit_OnClick" />
                        <asp:Button runat="server" ID="btnInfoCancel" Text="Hủy bỏ" CssClass="btn btn-danger" OnClick="btnInfoCancel_OnClick" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
