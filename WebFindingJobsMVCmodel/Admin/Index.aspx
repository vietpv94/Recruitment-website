<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Admin_Index" %>

<%@ Register Src="~/Admin/controls/HeaderAdmin.ascx" TagPrefix="uc1" TagName="HeaderAdmin" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../Skin/Styles/AdminIndex.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Skin/Styles/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Skin/Styles/nivo-slider.css" rel="stylesheet" />
    <script src="../Skin/Scripts/jquery-1.11.1.min.js"></script>
    <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <script src="../Skin/Scripts/jquery.nivo.slider.js"></script>
    <title>Quản trị Kenhvieclam</title>
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:HeaderAdmin runat="server" ID="HeaderAdmin" />
        <div class="container full-section slider theme-default">
            <div class="row">
                <div id="slider" class="nivoSlider">
                    <img src="/images/tuyendung_vn.png" alt="" />
                    <img src="/images/Banner-quang-cao-03.jpg" alt="" />
                </div>
            </div>
            <!--End Main Top-->
        </div>
             <div class="container full-section main-bottom">
                <div class="row">
                    <div class="col-md-6">
                        <p class="text-justify">Copyright © 2015 Sinh viên khoa CNTT - ĐẠI HỌC BÁCH KHOA HÀ NỘI </p>
                    </div>
                    <div class="col-md-6">
                        <p class="text-warning pull-right">Nhóm bài tập <span class="text-st">Phạm Văn Việt <br> Nguyên Xuân Duẩn</span></p>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
