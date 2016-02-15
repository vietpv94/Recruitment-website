<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageRecruitment.aspx.cs" Inherits="ManageRecruitment" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý tuyển dụng</title>
    <link href="../Skin/Styles/Contact_02.css" rel="stylesheet" />
    <link href="../Skin/Styles/Contact_03.css" rel="stylesheet" />
    <link href="../Skin/Styles/Menu_02.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="../Skin/Styles/common.css" rel="stylesheet" />
    <link href="../Skin/Styles/Registration.css" rel="stylesheet" />
    <link href="../Skin/Styles/LogIn.css" rel="stylesheet" />
     <script src="../Skin/Scripts/jquery-1.8.3.js"></script>
    <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".container_16").css("width", "1116px");
            $(".grid_16").css("width", "1116px");
        });
    </script>
     <script type="text/javascript">
         $(function () {
             $('.logo').addClass('pull-left');
             $("form input[type=submit]").click(function () {
                 $("input[type=submit]", $(this).parents("form")).removeAttr("clicked");
                 $(this).attr("clicked", "true");
             });
             $('#form1').submit(function (e) {
                 var val = $("input[type=submit][clicked=true]").val();
                 if (val == 'Xóa') {
                     return ConfirmDelete();
                 }
             });
             $('#cp3 .right > ul.thumbnails > li table tr a.command').hide();
             $('#cp3 .right > ul.thumbnails > li table tr').hover(function () {
                 $(this).children('.command').show();
             }, function () {
                 $(this).children('.command').hide();
             });
         });
         function ConfirmDelete() {
             if (!confirm('Bạn có chắc chắn muốn xóa?')) {
                 return false;
             }
             return true;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="container_16" style="margin-top: 30px">
            <div class="">
                <div id="cp3" class="">
                    <div class="clearfix">
                        <div class="left">
                            <div class="photo">
                                <img src="/Skin/Images/logo.jpg" alt="" />
                                <p><a href="#">1. Thông tin đăng tuyển</a></p>
                                <p>Thông tin chi tiết sẽ giúp quý khách thu hút được nhiều ứng viên và tìm được nhiều hồ sơ nhất</p>
                                <p><a href="#">2. Xem lại &amp; Hoàn tất</a></p>
                                <p>Xem lại và hoàn tất thông tin đăng tuyển</p>
                            </div>
                            <!-- end .photo -->
                            <div class="newsletter">
                                <h3><a href="#">Đăng ký Bản tin việc làm</a></h3>
                                <p>Bản tin việc làm và hướng nghiệp</p>
                                <span><a href="#">Xem mẫu</a></span> <span><a href="#">Hướng nghiệp</a></span>
                            </div>
                            <!-- end .newsletter -->
                        </div>
                        <!-- end .left -->
                        <div class="right">
                            <ul class="thumbnails">
                                <li>
                                    <h3><a href="#">Đang tuyển dụng</a></h3>
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Chức danh</th>
                                                <th>Mã số</th>
                                                <th>hết hạn</th>
                                                <th>Danh sách đã tuyển</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptRecrutting" runat="server">
                                            <HeaderTemplate>
                                                <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><span><a href="ListProfiles.aspx?jobid=<%#Eval("JobID") %>"><%#Eval("FullTitle") %></a></span></td>
                                                    <td><%#Eval("JobID") %></td>
                                                    <td><%#string.Format("{0:dd/MM/yyyy}", DateTime.Parse(Eval("ExpiredDate").ToString())) %> </td>
                                                    <td style="text-align: center"><a href="ListRecuited.aspx?jobid=<%#Eval("JobID") %>">Xem chi tiết</a></td>
                                                    <td>
                                                        <asp:Button ID="btUpdateNews" runat="server" Text="Cập Nhật" CssClass="btn btn-info" CommandName='<%#Eval("JobID") %>' OnCommand="btUpdateNews_OnCommand" />
                                                    <asp:Button ID="btDelete" runat="server" Text="Xóa" CssClass="btn btn-danger" CommandName='<%#Eval("JobID") %>' OnCommand="btDelete_OnCommand" /></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <tfoot>
                                            <tr>
                                                <td colspan="5">&nbsp;</td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </li>
                                <li>
                                    <h3><a href="#">Hết hạn</a></h3>
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Chức danh</th>
                                                <th>Mã số</th>
                                                <th>hết hạn</th>
                                                <th>Danh sách đã tuyển</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptOutOfDate" runat="server">
                                            <HeaderTemplate>
                                                <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><span><a href="JobDetail.aspx?jobid=<%#Eval("JobID") %>"><%#Eval("FullTitle") %></a></span></td>
                                                    <td><%#Eval("JobID") %></td>
                                                    <td><%#string.Format("{0:dd/MM/yyyy}", DateTime.Parse(Eval("ExpiredDate").ToString())) %> </td>
                                                    <td style="text-align: center"><a href="ListRecuited.aspx?jobid=<%#Eval("JobID") %>">Xem chi tiết</a></td>
                                                    <td>
                                                        <asp:Button ID="btDelete" runat="server" Text="Xóa" CssClass="btn btn-danger" CommandName='<%#Eval("JobID") %>' OnCommand="btDelete_OnCommand" /></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <tfoot>
                                            <tr>
                                                <td colspan="5">&nbsp;</td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </li>
                            </ul>
                        </div>
                        <!-- end .right -->
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
