<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostNews.aspx.cs" Inherits="PostNews" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng tin tuyển dụng</title>
       <link href="../Skin/Styles/Contact_02.css" rel="stylesheet" />
    <link href="../Skin/Styles/Contact_03.css" rel="stylesheet" />
    <link href="../Skin/Styles/Menu_02.css" rel="stylesheet" />
     <link href="../Skin/Styles/jquery.datetimepicker.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-formhelpers.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="../Skin/Styles/common.css" rel="stylesheet" />
    <link href="../Skin/Styles/Registration.css" rel="stylesheet" />
    <link href="../Skin/Styles/LogIn.css" rel="stylesheet" />
     <script src="../Skin/Scripts/jquery-1.8.3.js"></script>
    <script src="../Skin/Scripts/bootstrap.min.js"></script>
      <script src="../Skin/Scripts/jquery.datetimepicker.js"></script>
    <script src="Skin/Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".container_16").css("width", "1116px");
            $(".grid_16").css("width", "1116px");
        });
    </script>
       <script type="text/javascript">
           $(document).ready(function () {
               $(".container_16").css("width", "1116px");
               $(".grid_16").css("width", "1116px");
               $('.rdatetime-picker').datetimepicker({
                   format: 'd/m/Y',
                   lang: 'vi'
               });
           });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
       <div class="container_16" style="margin-top: 30px">
            <div class="">
                   <div id="cp2" >
                    <div class="clearfix">
                        <div class="left">
                            <div class="photo">
                                <img src="/Skin/Images/logo.jpg" alt="" />
                                <h4 style="color:cadetblue">1. Thông tin đăng tuyển</h4>
                                <p>Thông tin chi tiết sẽ giúp quý khách thu hút được nhiều ứng viên và tìm được nhiều hồ sơ nhất</p>
                                <h4 style="color:cadetblue">2. Xem lại &amp; Hoàn tất</h4>
                                <p>Xem lại và hoàn tất thông tin đăng tuyển</p>
                            </div>
                            <div class="newsletter">
                                <h3><a href="#">Đăng ký Bản tin việc làm</a></h3>
                                <p>Đăng ký bản tin việc làm để nhận được nhưng thông tin mới nhất từ các nhà tuyển dung, thông tin hướng nghiệp việc làm</p>
                               
                            </div>
                        </div>

                        <div class="right">
                            <ul class="thumbnails">
                                <li>
                                    <h3><a href="#">Thông tin công ty</a></h3>
                                    <div class="info">
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>Tên công ty</label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:TextBox ID="txtFullNameCompany" runat="server" CssClass="txt2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>Tên công ty viết tắt</label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:TextBox ID="txtShortNameCompany" runat="server" CssClass="txt2"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Quy mô
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:DropDownList ID="ddlQuyMoCongTy" CssClass="form-control txt2" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Địa chỉ công ty
                                                    <br />
                                                    <span>(không bắt buộc)</span></label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="txt2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="text-center" style="text-align: -webkit-right !important;">
                                            <asp:Button ID="btnSubmitInfoCompany" runat="server" Text="OK" CssClass="btn btn-primary" OnClick="btnSubmitInfoCompany_OnClick" />
                                            <asp:Button ID="btnCancle" runat="server" Text="Hủy bỏ" CssClass="btn btn-danger" OnClick="btnCancle_OnClick"/>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <h3><a href="#">Thông tin đăng tuyển</a></h3>
                                    <div class="info">
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Nội dung cần tuyển
                                                    <br />
                                                    <span>(Nội dung ghi ngắn gọn)</span>
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="txt2"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>Cấp bậc</label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:DropDownList ID="ddlDegrees" runat="server" CssClass="txt1"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>Mức lương</label>
                                            </div>
                                            <div class="pull-right">
                                                <div class="col-xs-6" style="padding: 0; margin-bottom: 15px;">
                                                    <div class="input-group salary">
                                                        <asp:DropDownList class="txt1" ID="ddlSalary" runat="server" Style="float: none; width: 240px;" />
                                                        <span class="input-group-addon" style="float: none; font-size: 12.4px !important">VNĐ/tháng</span>
                                                    </div>
                                                </div>
                                                <br />
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Nơi làm việc</label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:DropDownList ID="ddlRegions" CssClass="txt1 " runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Nghành nghề
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:DropDownList ID="ddlCategories" runat="server" CssClass="txt1"></asp:DropDownList>
                                            </div>
                                        </div>
                                          <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Vị trí làm việc
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:DropDownList ID="ddlJobPosition" runat="server" CssClass="txt1"></asp:DropDownList>
                                            </div>
                                        </div>
                                          <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Yêu cầu kinh nghiệm
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:DropDownList ID="ddlJobExperienceLevel" runat="server" CssClass="txt1"></asp:DropDownList>
                                            </div>
                                        </div>
                                          <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Kiểu công việc
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:DropDownList ID="ddlWorkType" runat="server" CssClass="txt1"></asp:DropDownList>
                                            </div>
                                        </div>
                                          <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Số lượng cần tuyển
                                                    <br />
                                                    <span>(Bạn hãy nhập rõ số lượng)</span>
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:TextBox ID="txtNumsApplicant" runat="server" CssClass="txt1" Text=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Mô tả công việc
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <textarea id="txtJobDetail" rows="10" runat="server"></textarea>
                                                <div class="clearfix">
                                                    <span class="pull-left">(Nhiều nhất 14.500 kí tự</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>
                                                    Yêu cầu công việc
                                                </label>
                                            </div>
                                            <div class="pull-right">
                                                <textarea id="txtDescription" rows="10" runat="server"></textarea>
                                                <div class="clearfix">
                                                    <span class="pull-left">(Nhiều nhất 14.500 kí tự</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>Hạn chót nộp hồ sơ</label>
                                            </div>
                                            <div class="pull-right">
                                                 <input type="text" class=" rdatetime-picker txt1" id="tbDeadline" runat="server" placeholder=""   />
                                                <%--<asp:TextBox ID="tbDeadline" runat="server" placeholder="MM/dd/yyyy ví dụ:04/24/2015" CssClass="txt1 "></asp:TextBox>--%>
                                            </div>
                                        </div>
                                        <div class="text-center" style="text-align: -webkit-right !important;">
                                           <asp:Button ID="btnSubmitRecuitmentInfo" runat="server" Text="OK" CssClass="btn btn-primary" OnClick="btnSubmitRecuitmentInfo_OnClick" />
                                            <asp:Button ID="btnCancle1" runat="server" Text="Hủy bỏ" CssClass="btn btn-danger" OnClick="btnCancle1_OnClick"/>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <h3><a href="#">Thông tin liên hệ</a></h3>
                                    <div class="info">
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>Tên người liên hệ</label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:TextBox ID="txtPeopleContact" runat="server" CssClass="txt2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>Địa chỉ E-mail nhận hồ sơ</label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:TextBox ID="txtEmailContact" runat="server" CssClass="txt2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix">
                                            <div class="pull-left">
                                                <label>Số điện thoại liên hệ</label>
                                            </div>
                                            <div class="pull-right">
                                                <asp:TextBox ID="txtPhoneContact" runat="server" CssClass="txt2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="text-center" style="text-align: -webkit-right !important;">
                                            <asp:Button ID="btnSubmitContactInfo" runat="server" Text="OK" CssClass="btn btn-primary"  OnClick="btnSubmitContactInfo_OnClick"/>
                                            <asp:Button ID="btnCancle2" runat="server" Text="Hủy bỏ" CssClass="btn btn-danger" OnClick="btnCancle2_OnClick"/>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                   </div>
                  </div>
                </div>
    </form>
</body>
</html>
