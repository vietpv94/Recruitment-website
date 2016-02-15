<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recruiters.aspx.cs" Inherits="Recruiters" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dành cho nhà tuyển dụng</title>
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

        <div class="container_16" style="margin-top: 30px">
            <div class="">
                <div id="cp1" class="">
                    <div class="clearfix">
                        <div class="left">
                            <div class="photo">
                                <img src="/Skin/Images/logo.jpg" alt="" />
                            </div>
                            <div class="newsletter">
                                  <h3><a href="#">Đăng ký Bản tin việc làm</a></h3>
                                <p>Đăng ký bản tin việc làm để nhận được nhưng thông tin mới nhất từ các nhà tuyển dung, thông tin hướng nghiệp việc làm</p>
                            </div>
                        </div>
                        <div class="right">
                            <ul class="thumbnails">
                                <li>
                                    <div class="title clearfix">
                                        <a class="s" href="#">Tìm hồ sơ</a>
                                    </div>
                                    <div class="tab-content">
                                        <div id="s1" class="tab-pane fade  in active">
                                            <div class="info">
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Từ khóa</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        <asp:TextBox ID="tbKeyword" runat="server" CssClass="txt2"></asp:TextBox>
                                                    </div>
                                                </div>
                                                  <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label></label>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Nghành nghề mong muốn</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        <asp:DropDownList ID="ddlCatelogy" runat="server" CssClass="txt2" AppendDataBoundItems="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Nơi làm việc mong muốn</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="txt2" AppendDataBoundItems="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Cấp bậc mong muốn</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        <asp:DropDownList ID="dllJobPosition" CssClass="txt2" runat="server" AppendDataBoundItems="True" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Số năm kinh nghiệm</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        <asp:DropDownList ID="ddlExperienceLevel" runat="server" CssClass="txt2" AppendDataBoundItems="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Trình độ ngoại ngữ</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        <asp:DropDownList ID="ddlLangSkill" runat="server" CssClass="txt2" AppendDataBoundItems="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label></label>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Bằng cấp thấp nhất đã có</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        <asp:DropDownList ID="ddlCertificate" runat="server" CssClass="txt2" AppendDataBoundItems="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Giới tính</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        <asp:DropDownList ID="ddlSex" runat="server" CssClass="txt2" AppendDataBoundItems="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Mức lương</label>
                                                    </div>
                                                   <div class="pull-right">
                                                        <asp:DropDownList ID="dllSalarylevel" runat="server" CssClass="txt2" AppendDataBoundItems="True"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Kiểu công việc</label>
                                                    </div>
                                                   <div class="pull-right">
                                                        <asp:DropDownList ID="ddlWorktype" runat="server" CssClass="txt2" AppendDataBoundItems="True" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                    <div class="pull-left">
                                                        <label>Tuổi</label>
                                                    </div>
                                                    <div class="pull-right">
                                                        Từ
                                                        	<asp:TextBox ID="txtToAge" runat="server" CssClass="txt4" Text="0"></asp:TextBox>
                                                        Đến
                                                            <asp:TextBox ID="txtFromAge" runat="server" CssClass="txt4" Text="0"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="margin-left: 444px">
                                            <asp:Button ID="btSearchResume" runat="server" CssClass="btn btn-info " Text="Tìm kiếm" OnClick="btSearchResume_Click" />
                                            </div>
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
