<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListRecuited.aspx.cs" Inherits="ListRecuited" %>


<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh Sách Hồ Sơ Đã Ứng Tuyển</title>
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
            <div class="tab-content">
                <div id="cp1" class="tab-pane fade  in active">
                    <p>Đã Tuyển <asp:Label runat="server" ID="lbNumberFinded"></asp:Label> hồ sơ</p>
                    <ul class="results list-unstyled">
                        <asp:Repeater runat="server" ID="rptSearchResumeResult">
                            <ItemTemplate >
                                <li class="clearfix">
                                    <div class="img pull-left">
                                        <a href="ResumeDetail.aspx?resumeid=<%#Eval("ResumeID") %>&userid=<%#Eval("UserID")%>">
                                            <img src='<%#Eval("PhotoPath")%>' alt="Avata" /></a>
                                    </div>
                                    <div class="txt">
                                        <table class="table">
                                            <tr>
                                                <td colspan="2"><%#Eval("LastName") %>  <%#Eval("FirstName") %></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dl class="dl-horizontal">
                                                        <dt>Giới tính:</dt>
                                                        <dd><%#Eval("SexName") %></dd>
                                                        <dt>Ngày sinh:</dt>
                                                        <dd> <%#string.Format("{0:dd/MM/yyyy}", DateTime.Parse(Eval("DateOfBirth").ToString())) %></dd>
                                                    </dl>
                                                </td>
                                                <td>
                                                    <dl class="dl-horizontal">
                                                        <dt>Địa chỉ:</dt>
                                                        <dd><%#Eval("DistrictName") %>,<%#Eval("ProvinceName") %></dd>
                                                        <dt>Email:</dt>
                                                        <dd><%#Eval("ContactEmail") %></dd>
                                                    </dl>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <dl class="dl-horizontal">
                                                        <dt>Số năm kinh nghiệm:</dt>
                                                        <dd><%#Eval("ExperienceLevelName") %></dd>
                                                        <dt>Trình độ ngoại ngữ:</dt>
                                                        <dd><%#Eval("SkillName") %></dd>
                                                        <dt>Bằng cấp cao nhất:</dt>
                                                        <dd><%#Eval("CertificateName") %></dd>
                                                        <dt>Nghành nghề:</dt>
                                                        <dd><%#Eval("JobIndustryName") %></dd>
                                                        <dt>Mức lương mong muốn:</dt>
                                                        <dd><%#Eval("SalaryLevel") %></dd>
                                                    </dl>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
