<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecruitorManagement.aspx.cs" Inherits="Admin_RecruitorManagement" %>

<%@ Register TagPrefix="uc1" TagName="HeaderAdmin" Src="~/Admin/controls/HeaderAdmin.ascx" %>

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
    <title>Quản Lý Tài Khoản Nhà Tuyển Dụng</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:HeaderAdmin runat="server" ID="HeaderAdmin" />
            <div class="row">
                <div class="col-xs-12">
                    <asp:PlaceHolder ID="msgHolder" runat="server"></asp:PlaceHolder>
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title">Tài khoản</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body table-responsive">
                            <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">

                                <table id="example1" class="table table-bordered table-striped dataTable" aria-describedby="example1_info">

                                    <thead>
                                        <tr role="row">
                                            <th style="text-align: center" class="">STT</th>
                                            <th style="text-align: center">Tài khoản</th>
                                            <th style="text-align: center">Tên công ty</th>
                                            <th style="text-align: center">Email</th>
                                            <th style="text-align: center">Địa chỉ</th>
                                            <th style="text-align: center">Di động</th>
                                            <th style="text-align: center">Ngày tạo</th>
                                            <th style="text-align: center">Trạng thái</th>
                                            <th style="text-align: center">Hành Động</th>
                                        </tr>
                                    </thead>
                                    <asp:Repeater runat="server" ID="rptAccounts">
                                        <HeaderTemplate>
                                            <tbody role="alert" aria-live="polite" aria-relevant="all">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="">
                                                <td style="text-align: center">
                                                    <%# Container.ItemIndex + 1 %>
                                                </td>
                                                <td style="text-align: center">

                                                    <%# Eval("EmailLoginAsRecruitor") %>
                                                </td>
                                                <td style="text-align: center"><%# Eval("CompanyFullName")%></td>
                                                <td style="text-align: center"><%#Eval("EmailToSendResume") %></td>
                                                <td style="text-align: center"><%#Eval("Address") %></td>
                                                <td style="text-align: center"><%#Eval("PhoneToCallForJob") %></td>
                                                <td style="text-align: center"><%#String.IsNullOrEmpty(Eval("RegistrationDateTime").ToString())?"":Convert.ToDateTime(Eval("RegistrationDateTime")).ToString("dd/MM/yyyy")%></td>
                                                <td style="text-align: center"><%#Status(Eval("STATUS").ToString()) %></td>
                                                <td style="text-align: center">
                                                    <asp:Button ID="btBlock" runat="server" Visible='<%#ActionButtons(Eval("STATUS").ToString())%>' Text="Khóa" CssClass="btn btn-danger" CommandName='<%#Eval("RecruitorID") %>' OnCommand="btBlock_OnCommand" />
                                                    <asp:Button ID="btUnLock" runat="server" Visible='<%#ActionButtons2(Eval("STATUS").ToString())%>' Text="Mở Khóa" CssClass="btn btn-warning" CommandName='<%#Eval("RecruitorID") %>' OnCommand="btUnLock_OnCommand" /></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                    <tfoot>
                                        <div id="divMessage" runat="server">
                                        </div>
                                    </tfoot>
                                </table>
                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                </div>
                <div class="col-xs-12">
                    <div class="paging" id="divPager" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
