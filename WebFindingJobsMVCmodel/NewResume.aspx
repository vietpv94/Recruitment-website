<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewResume.aspx.cs" Inherits="NewResume" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tạo Hồ Sơ</title>
    <link href="/Skin/Styles/Contact_02.css" rel="stylesheet" />
    <link href="/Skin/Styles/Menu_02.css" rel="stylesheet" />
    <link href="/Skin/Styles/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="/Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="/Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="/Skin/Styles/common.css" rel="stylesheet" />
    <link href="/Skin/Styles/Registration.css" rel="stylesheet" />
    <link href="/Skin/Styles/LogIn.css" rel="stylesheet" />
    <script src="/Skin/Scripts/jquery-1.8.3.js"></script>
    <script src="Skin/Scripts/jquery-1.11.1.min.js"></script>
    <script src="/Skin/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".container_16").css("width", "1116px");
            $(".grid_16").css("width", "1116px");
            fuck();
        });
    </script>
    <script type="text/javascript">
        function ConfirmDelete() {
            if (!confirm('Bạn có chắc chắn muốn xóa?')) {
                return false;
            }
            return true;
        }
        function fuck() {
            var fuckValue = $('#<%=hfFuck.ClientID%>').val();
            if (fuckValue == '3') $('a[href="#b3"]').click();
            if (fuckValue == '2') $('a[href="#b2"]').click();
            if (fuckValue == '1') $('a[href="#b1"]').click();
        }
        $(function () {
            $('.logo').addClass('pull-left');
            $('.input-group.salary input[type="radio"]').click(function () {
                $('.input-group.salary input[type="text"]').addClass('required').addClass('digits');
            });
            $('#goon-b2').click(function () {
                $('a[href="#b2"]').click();
            });
            $('#goon-b3').click(function () {
                $('a[href="#b3"]').click();
            });
            $('#goback-b1').click(function () {
                $('a[href="#b1"]').click();
            });
            $('#goback-b2').click(function () {
                $('a[href="#b2"]').click();
            });
            jQuery.validator.addClassRules({
                choose: {
                    selectcheck: true
                }
            });
        });
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
                        <asp:Literal runat="server" ID="ltrScript"></asp:Literal>
                        <asp:HiddenField runat="server" ID="hfFuck" Value="1" />
                        <!-- end .left -->
                        <div class="right">
                            <ul class="thumbnails">
                                <li>
                                    <h3 id="resume_page_title" runat="server">Tạo hồ sơ theo từng bước</h3>
                                    <div class="">
                                        <p>Hồ sơ trực tuyến giúp nhà tuyển dụng <strong>tiếp cận bạn nhanh chóng và dễ dàng hơn</strong></p>
                                        <ul class="nav nav-tabs">
                                            <li class="active"><a data-toggle="tab" href="#b1"><span class="img-circle">1</span>Thông tin chung</a></li>
                                            <li><a data-toggle="tab" href="#b2"><span class="img-circle">2</span>Hồ sơ chi tiết</a></li>
                                            <li><a data-toggle="tab" href="#b3"><span class="img-circle">3</span>Xem lại và hoàn tất</a></li>
                                        </ul>
                                        <div class="tab-content">
                                            <div id="b1" class="tab-pane fade in active">
                                                <h4>Thông tin chung</h4>
                                                <div class="info">
                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>Tên hồ sơ</label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:TextBox ID="txtResumeName" runat="server" CssClass="txt2 form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>File hồ sơ đính kèm</label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:FileUpload runat="server" ID="fuResume" />
                                                        </div>
                                                        <div class="pull-right resume_attachment" id="resume_attachment" runat="server" visible="False">
                                                            <a href="<%=LinkCv %>" id="resume_attachment_link">CV Đính Kèm</a>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>Bằng cấp cao nhất</label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:DropDownList ID="ddlDegrees" runat="server" CssClass="select1 form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>Số năm kinh nghiệm</label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:DropDownList class="select1 form-control  " ID="ddlExp" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>
                                                                Trình độ ngoại ngữ
                                                            </label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <div class="lang">
                                                                <asp:DropDownList ID="ddlLangSkill" runat="server" CssClass="select1 form-control"></asp:DropDownList>
                                                                <asp:TextBox ID="txtDescription" CssClass="select2 form-control" runat="server" placeholder="IELTS/TO.. points and types"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>Email Liên hệ</label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:TextBox ID="txtContactMail" CssClass="select1 form-control choose" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <hr />

                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>Cấp bậc mong muốn</label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:DropDownList ID="ddlExpectedPosition" runat="server" CssClass="select1 form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <div class="pull-left">
                                                            <label>
                                                                Nơi làm việc
                                                    <br />
                                                                <span>(Nơi làm việc có địa điểm mong muốn)</span></label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:DropDownList ID="ddlRegions" CssClass="select1 form-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <div class="pull-left">
                                                            <label>
                                                                Nghành nghề
                                                                 <br />
                                                                <span>(Nghành nghề mong muốn và là thế mạnh)</span>
                                                            </label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:DropDownList ID="ddlCategories" runat="server" CssClass="select1 form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>Mức lương mong muốn</label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <div class="col-xs-6" style="padding: 0; margin-bottom: 15px;">
                                                                <div class="input-group salary">
                                                                    <asp:DropDownList class="form-control" ID="ddlExpectedSalary" runat="server" Style="float: none; width: 186px;" />
                                                                    <span class="input-group-addon" style="float: none">VNĐ/tháng</span>
                                                                </div>
                                                            </div>
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <div class="pull-left single-line">
                                                            <label>Thời gian làm việc</label>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:DropDownList ID="ddlworktype" runat="server" CssClass="select1 form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="clearfix">
                                                        <div class="pull-right">
                                                            <a href="MyResume.aspx" class="btn btn-default">Hủy bỏ</a>
                                                            <%--<a id="goon-b2" href="javascript:void(0)" class="btn btn-default">Tiếp tục</a>--%>
                                                            <asp:Button runat="server" ID="Button1"  CssClass="btn btn-default" Text="Tiếp tục" OnClick="GoStep2" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- end .info -->
                                            </div>
                                            <div id="b2" class="tab-pane fade">
                                                <h4>Hồ sơ chi tiết</h4>
                                                <div class="info">

                                                    <div class="box">
                                                        <h5>Mục tiêu nghề nghiệp</h5>
                                                        <div class="editor">
                                                            <textarea id="ta1" runat="server" class="txtArea form-control required"></textarea>
                                                        </div>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Thành tích nổi bật<span> (không bắt buộc)</span></h5>
                                                        <div class="editor">
                                                            <textarea id="ta2" runat="server" class="txtArea form-control"></textarea>
                                                        </div>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Kinh nghiệm làm việc<span> (không bắt buộc)</span></h5>
                                                        <div class="editor">
                                                            <textarea id="ta3" runat="server" class="txtArea form-control"></textarea>
                                                        </div>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Trình độ học vấn</h5>
                                                        <div class="editor">
                                                            <textarea id="ta4" runat="server" class="txtArea form-control required"></textarea>
                                                        </div>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Kỹ năng nổi bật</h5>
                                                        <div class="editor">
                                                            <textarea id="ta5" runat="server" class="txtArea form-control required"></textarea>
                                                        </div>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Thông tin tham khảo<span> (không bắt buộc)</span></h5>
                                                        <div class="editor">
                                                            <textarea id="ta6" runat="server" class="txtArea form-control"></textarea>
                                                        </div>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <div class="text-right">
                                                            <a id="goback-b1" href="javascript:void(0)" class="btn btn-default">Quay lại</a>
                                                            <%--<a id="goon-b3" href="javascript:void(0)" class="btn btn-default">Tiếp tục</a>--%>
                                                            <asp:Button runat="server" ID="btnStep2Submit"  CssClass="btn btn-default" Text="Tiếp tục" OnClick="GoStep3" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- end .info -->
                                            </div>
                                            <div id="b3" class="tab-pane fade">
                                                <h4>Xem lại Hoàn tất</h4>
                                                <div class="info">
                                                    <div class="clearfix">
                                                        <div class="avt">
                                                            <a href="<%=ThumbImg %>">
                                                                <img src="<%=ThumbImg %>" alt="Avatar" id="avatarB3" />
                                                            </a>
                                                        </div>
                                                        <!-- end .avt -->
                                                        <div class="text clearfix">
                                                            <h5>
                                                                <asp:Literal ID="ltrName2" runat="server"></asp:Literal>
                                                                <a href="javascript:void(0)" class="edit-info">[Chỉnh sửa thông tin liên hệ]</a></h5>
                                                            <p class="pull-left">
                                                                <strong>
                                                                    <asp:Literal ID="ltrGender2" runat="server"></asp:Literal><br />
                                                                    <asp:Literal ID="ltrBirth2" runat="server"></asp:Literal>
                                                                </strong>
                                                            </p>
                                                            <p class="pull-right">
                                                                <strong>
                                                                    <asp:Literal ID="ltrAddress2" runat="server"></asp:Literal><br />
                                                                    Email:</strong><small><asp:Literal ID="ltrEmail2" runat="server"></asp:Literal></small>
                                                            </p>
                                                        </div>
                                                        <!-- end .text -->
                                                    </div>
                                                    <div class="box">
                                                        <h5>Thông tin chung</h5>
                                                        <table class="table">
                                                            <tr class="resume_name">
                                                                <td>Tên hồ sơ</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbNameResume" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                            <tr class="attachment">
                                                                <td>File hồ sơ đính kèm</td>
                                                                <td><span></span></td>
                                                            </tr>
                                                            <tr class="exp">
                                                                <td>Số năm kinh nghiệm</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbExperienceLevel" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                            <tr class="languages">
                                                                <td>Trình độ ngoại ngữ</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbLangSkill" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                            <tr class="highest-degree">
                                                                <td>Bằng cấp cao nhất</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbCertificate" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                            <tr class="current-level">
                                                                <td>Thời gian làm việc</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbWorkType" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                            <tr class="expected-position">
                                                                <td>Cấp bậc mong muốn</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbJobPosition" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                            <tr class="working-place">
                                                                <td>Nơi làm việc</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbLocation" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                            <tr class="category">
                                                                <td>Ngành nghề</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbCategory" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                            <tr class="expected-salary">
                                                                <td>Mức lương mong muốn</td>
                                                                <td><span>
                                                                    <asp:Label ID="lbSalaryLevel" runat="server" Text=""></asp:Label></span></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Mục tiêu nghề nghiệp</h5>
                                                        <p class="ta1">
                                                            <asp:Label ID="lbAchievement" runat="server" Text=""></asp:Label>
                                                        </p>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Thành tích nổi bật</h5>
                                                        <p class="ta2">
                                                            <asp:Label ID="lbCareerGoal" runat="server" Text=""></asp:Label>
                                                        </p>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Kinh nghiệm làm việc</h5>
                                                        <p class="ta3">
                                                            <asp:Label ID="lbWorkExp" runat="server" Text=""></asp:Label>
                                                        </p>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Trình độ học vấn</h5>
                                                        <p class="ta4">
                                                            <asp:Label ID="lbReference" runat="server" Text=""></asp:Label>
                                                        </p>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Kỹ năng nổi bật</h5>
                                                        <p class="ta5">
                                                            <asp:Label ID="lbSkill" runat="server" Text=""></asp:Label>
                                                        </p>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <h5>Thông tin tham khảo</h5>
                                                        <p class="ta6">
                                                            <asp:Label ID="lbLiteracy" runat="server" Text=""></asp:Label>
                                                        </p>
                                                    </div>
                                                    <!-- end .box -->
                                                    <div class="box">
                                                        <div class="text-right">
                                                            <a id="goback-b2" href="javascript:void(0)" class="btn btn-default">Quay lại</a>
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-default" Text="Hoàn tất" OnClick="btnSubmit_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- end .info -->
                                            </div>
                                        </div>
                                    </div>
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
