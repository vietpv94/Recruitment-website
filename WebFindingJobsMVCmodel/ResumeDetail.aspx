<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResumeDetail.aspx.cs" Inherits="ResumeDetail" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hồ Sơ Chi Tiết</title>
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
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div>
            <div class="container_16" style="margin-top: 30px">
                <div class="">
                    <%=LinkCv %>
                     <a class="btn btn-default" style="position: absolute;right: 9%;top: 75px;" href="javascript:window.print();">In <i class="glyphicon glyphicon-print"></i></a>
                    <div id="cp1">
                        <ul class="file-dt list-unstyled">
                            <li class="clearfix">
                                <div class="img pull-left">
                                    <div class="photo">
                                        <img src="<%=ThumbImg %>" alt="" />
                                    </div>
                                </div>
                                <!-- end .img -->
                                <div class="txt">
                                    <table class="table">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lbFullName" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dl class="dl-horizontal">
                                                      <dt>Ngày sinh:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbDateOfBirth" runat="server"></asp:Label></dd>
                                                    <dt>Giới tính:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbGender" runat="server"></asp:Label></dd>
                                                  
                                                </dl>
                                            </td>
                                            <td>
                                                <dl class="dl-horizontal">
                                                    <dt>Địa chỉ:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbAddress" runat="server"></asp:Label></dd>
                                                    <dt>Email:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbEmailContact" runat="server"></asp:Label></dd>
                                                </dl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Thông tin chung</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <dl class="dl-horizontal">
                                                    <dt>Số năm kinh nghiệm:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbExperienceLevel" runat="server"></asp:Label></dd>
                                                    <dt>Trình độ ngoại ngữ:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbLangSkill" runat="server"></asp:Label></dd>
                                                    <dt>Bằng cấp cao nhất:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbCertificates" runat="server"></asp:Label></dd>
                                                    <dt>Cấp bậc mong muốn:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbJobPosition" runat="server"></asp:Label></dd>
                                                    <dt>Nơi làm việc:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbLocation" runat="server"></asp:Label></dd>
                                                    <dt>Nghành nghề:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbCatelory" runat="server"></asp:Label></dd>
                                                    <dt>Mức lương mong muốn:</dt>
                                                    <dd>
                                                        <asp:Label ID="lbSalaryLevel" runat="server"></asp:Label></dd>
                                                </dl>
                                            </td>
                                        </tr>
                                    </table>
                                    <h4>Mục tiêu nghề nghiệp</h4>
                                    <p>
                                        <asp:Literal ID="ltrMucTieu" runat="server"></asp:Literal>
                                    </p>
                                    <h4>Thành tích nổi bật</h4>
                                    <p>
                                        <asp:Literal ID="ltrNoiBat" runat="server"></asp:Literal>
                                    </p>
                                    <h4>Kinh nghiệm làm việc</h4>
                                    <p>
                                        <asp:Literal ID="lbrWorkExperience" runat="server"></asp:Literal>
                                    </p>
                                    <h4>Trình độ học vấn</h4>
                                    <p>
                                        <asp:Literal ID="lbrHocVan" runat="server"></asp:Literal>
                                    </p>
                                    <h4>Kỹ năng nổi bật</h4>
                                    <p>
                                        <asp:Literal ID="lbrKiNang" runat="server"></asp:Literal>
                                    </p>
                                    <h4>Thông tin tham khảo</h4>
                                    <p>
                                        <asp:Literal ID="lbrThongTin" runat="server"></asp:Literal>
                                    </p>
                                </div>
                            </li>
                        </ul>
                        <div style="margin-left: 444px" id="divBtnRecruit" runat="server" visible="False">
                            <asp:Button ID="btRecruitAction" runat="server" CssClass="btn btn-info " Text="Tuyển Ngay" OnClick="btRecruitAction_Click" />
                            <asp:Button ID="btRejectResume" CssClass="btn btn-danger" runat="server" Text="Từ Chối Tuyển Dụng" OnClick="btRejectResume_OnClick"/>
                        </div>
                        <div style="margin-left: 444px" id="divBtnUpdate" runat="server" visible="True">
                            <asp:Button ID="btUpdate" runat="server" CssClass="btn btn-info " Text="Cập Nhật" OnClick="btUpdate_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
