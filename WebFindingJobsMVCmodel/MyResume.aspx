<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyResume.aspx.cs" Inherits="MyResume" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hồ Sơ Của Tôi</title>
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
            $('#section1 .right > ul.thumbnails > li p a.command').hide();
            $('#section1 .right > ul.thumbnails > li p').hover(function () {
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
        <div class="grid_16">
            <div class="tab-content">
                <div id="section1" class="tab-pane fade in active">
                    <div class="clearfix">
                        <div class="left">
                            <div class="photo">
                                <img src="<%=ThumbImg %>" alt="Avatar" id="avatar" />
                            </div>
                            <!-- end .photo -->
                        </div>
                        <!-- end .left -->
                        <div class="right">
                            <ul class="thumbnails">
                                <li>
                                    <h3>Việc làm phù hợp với bạn</h3>
                                    <div id="match_works" runat="server">
                                        <ul class="lists">
                                            <%=BuidRecomendJobs() %>
                                        </ul>
                                    </div>
                                    <div id="no_actived_resume" runat="server" visible="false">
                                        <p class="kq">Bạn cần đăng hồ sơ để hệ thống có thể tự động tìm những công việc phù hợp với hồ sơ của bạn.</p>
                                        <a href="#">Đăng hồ sơ của bạn ngay!</a>
                                    </div>
                                    <div id="no_resume" runat="server" visible="false">
                                        <p class="kq">Xin vui lòng tạo mới hồ sơ để chức năng này có thể hoạt động được.</p>
                                        <a href="NewResume.aspx" class="btn btn-primary">Tạo hồ sơ mới</a>
                                    </div>
                                </li>
                                <li>
                                    <h3>Việc làm đã nộp hồ sơ</h3>
                                    <p id="no_job_apply" runat="server">Bạn chưa nộp hồ sơ cho công việc nào.</p>
                                    <asp:Repeater ID="rptAppliedJobs" runat="server">
                                        <HeaderTemplate>
                                            <ul class="lists">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li>
                                                <h4>
                                                    <a href="<%#Eval("RewriteUrl") %>?jobid=<%#Eval("JobID") %>"><%#Eval("FullTitle") %></a>
                                                </h4>
                                                <p class="time"><%#string.Format("{0:dd/MM/yyyy}", DateTime.Parse(Eval("ExpiredDate").ToString())) %> | <%#Eval("ProvinceName") %></p>
                                                <p class="name"><%#Eval("CompanyFullName") %></p>
                                                <p class="add"><%#Eval("Address") %></p>
                                                <asp:Button ID="btDeleteApplied" runat="server" CssClass="btn btn-danger" Text="Xóa" CommandName='<%#Eval("JobID") %>' OnCommand="btDeleteApplied_OnCommand" />
                                                <hr />
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </li>
                                <li>
                                    <h3>Việc làm đã lưu</h3>
                                    <p id="saved_works" runat="server">Bạn chưa lưu công việc nào.</p>
                                    <asp:Repeater ID="rptSavedWorks" runat="server">
                                        <HeaderTemplate>
                                            <ul id="list_jobs" class="lists">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li>
                                                <h4>
                                                    <a href="<%#Eval("RewriteUrl") %>?jobid=<%#Eval("JobID") %>"><%#Eval("FullTitle") %></a>
                                                </h4>
                                                <p class="time"><%#string.Format("{0:dd/MM/yyyy}", DateTime.Parse(Eval("ExpiredDate").ToString())) %> | <%#Eval("ProvinceName") %></p>
                                                <p class="name"><%#Eval("CompanyFullName") %></p>
                                                <p class="add"><%#Eval("Address") %></p>
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" CommandName='<%#Eval("JobID") %>' OnCommand="btDelete_OnCommandrpt" Text="Xóa" />

                                                <hr />
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </li>
                                <li>
                                    <h3>Hồ sơ của tôi</h3>
                                    <p id="my_resume" runat="server">Bạn chưa tạo hồ sơ nào.</p>
                                    <p id="resume_notice" runat="server" visible="false">Bạn chỉ có thể chọn 1 hồ sơ để đăng. Hồ sơ được đăng sẽ là hồ sơ mà nhà tuyển dụng tìm thấy thông qua công cụ tìm kiếm.</p>
                                    <table id="example1" class="table table-bordered table-striped dataTable" aria-describedby="example1_info">

                                        <thead>
                                            <tr role="row">
                                                <th style="text-align: center" class="">STT</th>
                                                <th style="text-align: center">Tên hồ sơ</th>
                                                 <th style="text-align: center">Trạng thái cho phép tìm kiếm</th>
                                                <th style="text-align: center">Hành động</th>
                                               
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptItems" runat="server">
                                            <HeaderTemplate>
                                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="">
                                                    <td style="text-align: center">
                                                        <%# Container.ItemIndex + 1 %>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <a href="ResumeDetail.aspx?resumeid=<%#Eval("ResumeID") %>"><%#Eval("ResumeName") %></a>
                                                        <span class="published" id="resume_published">(đã đăng)</span>
                                                    </td>
                                                    <td style="text-align: center">
                                                        <asp:Button ID="btUnActive" runat="server" Visible='<%#ActionButtons(Eval("Active").ToString()) %>' CssClass="btn btn-success" CommandName='<%#Eval("ResumeID") %>' OnCommand="btUnActive_OnCommand" Text="yes" />
                                                        <asp:Button ID="btActive" runat="server" Visible='<%#ActionButtons2(Eval("Active").ToString()) %>' CssClass="btn btn-warning" CommandName='<%#Eval("ResumeID") %>' OnCommand="btActive_OnCommand" Text="No" />
                                                    </td>
                                                    <td style="text-align: center"><span>
                                                        <asp:Button ID="btEditMyResume" runat="server" CssClass="btn btn-info" CommandName='<%#Eval("ResumeID") %>' OnCommand="btEditMyResume_OnCommand" Text="Cập Nhật" /></span>
                                                        <span>
                                                            <asp:Button ID="btDeleteMyResume" runat="server" CssClass="btn btn-danger" CommandName='<%#Eval("ResumeID") %>' OnCommand="btDeleteMyResume_OnCommand" Text="Xóa" /></span></td>
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
                                    <asp:Button CssClass="btn btn-primary" runat="server" ID="btCreateNewResume" OnClick="btCreateNewResume_OnClick" Text="Tạo hồ sơ mới"/>
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
