<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobDetail.aspx.cs" Inherits="JobDetail" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chi tiết công việc</title>

    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/common.css" rel="stylesheet" />
    <link href="../Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="../Skin/Styles/StyleSearch3.css" rel="stylesheet" />
    <link href="../Skin/Styles/Menu_search.css" rel="stylesheet" />
    <link href="../Skin/Styles/ListNewsResult.css" rel="stylesheet" />
    <link href="../Skin/Styles/NewsDetails_01.css" rel="stylesheet" />
    <link href="../Skin/Styles/HostNews_01.css" rel="stylesheet" />
    <script src="../Skin/Scripts/jquery-1.8.3.js"></script>
    <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".container_16").css("width", "1116px");
            $(".grid_16").css("width", "1116px");
        });
    </script>
    <script>
        $(document).ready(function () {
            // The size of the scrollbar can be set to a
            // fixed number with the size option.
            //
            $("#scrollbar3").tinyscrollbar({ trackSize: 100 });
        });

    </script>
    <script type="text/javascript">
        function Validate(sender, args) {
            var checkBoxes = document.getElementsByTagName("input");
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    </script>
    <script type="text/javascript">

        function Validate2(sender, args) {
            var checkBoxes = document.getElementsByTagName("input");
            var count = 0;
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {
                    count++;
                }
            }
            if (count > 1) {

                args.IsValid = false;
            } else {
                args.IsValid = true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="container_16" style="margin-left: 220px">
            <div class="grid_16" style="width: 970px">
                <div class="search_03">
                    <div class="clearfix">
                        <div class="logo pull-left">
                            <h1>
                                <img src="../Skin/Images/findjob_img.png" alt="" /></h1>
                        </div>
                        <!-- end .logo -->
                        <div class="form-search pull-right form-group " style="margin: 11px 0">
                            <asp:Panel runat="server" DefaultButton="btnSearch">
                                <asp:TextBox class="form-control" ID="txtKeywords" placeholder="Nhập công việc muốn tìm. VD: Nhân viên kinh doanh..." runat="server"></asp:TextBox>
                                <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_OnClick" CssClass="btn btn-info" Text="Tìm việc" />
                            </asp:Panel>
                        </div>
                        <!-- end .form-search -->
                    </div>
                </div>
            </div>
            <div class="grid_16">
                <div class="news-details clearfix" style="padding-right: 10px">
                    <div class="pull-left">
                        <div class="top-news-details">
                            <div class="clearfix">
                                <div class="image">
                                    <a href="#">
                                        <img src="/Skin/Images/avatar.jpg" alt="" /></a>
                                    <p>
                                        Hạn tuyển dụng: <span>
                                            <asp:Label ID="txtDateLine" runat="server"></asp:Label></span>
                                    </p>
                                </div>
                                <div class="text">
                                    <h2><a href="#">
                                        <asp:Label ID="txtCompanyName" runat="server"></asp:Label></a></h2>
                                    <p class="add">
                                        <asp:Label ID="txtAddress" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        Qui mô công ty: <strong>
                                            <asp:Label ID="txtCompanySize" runat="server"></asp:Label></strong>
                                    </p>
                                    <p>
                                        Tên người liên hệ:
                                        <asp:Label ID="txtRecruterName" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <table class="table">
                                <tr class="clearfix">
                                    <td><strong>Nơi làm việc: </strong>
                                        <br />
                                        <span style="color: #00ced1">
                                            <asp:Label ID="txtLocation" runat="server"></asp:Label></span></td>
                                    <td><strong>Nghành nghề: </strong>
                                        <br />
                                        <span style="color: #00ced1">
                                            <asp:Label ID="txtCatelogy" runat="server"></asp:Label></span></td>
                                    <td><strong>Cấp bậc: </strong>
                                        <br />
                                        <span style="color: #00ced1">
                                            <asp:Label ID="txtJobPosition" runat="server"></asp:Label></span></td>
                                    <td><strong>Mức lương: </strong>
                                        <br />
                                        <span style="color: #00ced1">
                                            <asp:Label ID="txtSalary" runat="server"></asp:Label></span></td>
                                    <td><strong>Kinh Nghiệm: </strong>
                                        <br />
                                        <span style="color: #00ced1">
                                            <asp:Label ID="txtExperienceLevel" runat="server"></asp:Label></span></td>
                                    <td><strong>Kiểu công việc: </strong>
                                        <br />
                                        <span style="color: #00ced1">
                                            <asp:Label ID="txtWorktype" runat="server"></asp:Label></span></td>
                                    <td><strong>Bằng Cấp: </strong>
                                        <br />
                                        <span style="color: #00ced1">
                                            <asp:Label ID="txtCertificate" runat="server"></asp:Label></span></td>
                                </tr>
                            </table>
                        </div>
                        <div class="desc">
                            <h3 class="title">Mô tả công việc</h3>
                            <asp:Label ID="txtJobContent" runat="server"></asp:Label>
                        </div>
                        <!-- end .desc -->
                        <div class="desc">
                            <h3 class="title">Yêu cầu công việc</h3>
                            <asp:Label ID="txtJobDescription" runat="server"></asp:Label>
                        </div>
                        <div class="bot" id="divBtnJobDetail" runat="server">
                            <asp:Button ID="btApplyJob" runat="server" Text="Nộp đơn" CssClass="btn btn-primary" OnClick="btApplyJob_Click" />
                            <asp:Button ID="btSaveJob" runat="server" Text="Lưu việc làm này" CssClass="btn btn-danger" OnClick="btSaveJob_Click" />
                        </div>
                    </div>
                    <div class="pull-right" runat="server" id="divRecomendJobs">
                        <h3 style="text-transform: uppercase; background: #ECECEC; padding: 10px 0 10px 5px; margin-top: 0; font-size: 15px;font-weight: 700; color: #111111;">VIỆC LÀM NỔI BẬT</h3>
                        <asp:Repeater ID="rptSearchResult" runat="server">
                            <HeaderTemplate>
                                <ul class="news" style="width: 325px; overflow-y: scroll; height: 753px;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <h4><a href="<%#Eval("RewriteUrl") %>?jobid=<%#Eval("JobID") %>"><%#Eval("FullTitle") %></a> </h4>
                                    <p class="time"><%#String.Format("{0:dd/MM/yyyy}", DateTime.Parse(Eval("ExpiredDate").ToString())) %> | <%#Eval("ProvinceName") %></p>
                                    <p class="name"><%#Eval("CompanyFullName") %></p>
                                    <p class="add"><%#Eval("Address") %></p>
                                    <hr />
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
