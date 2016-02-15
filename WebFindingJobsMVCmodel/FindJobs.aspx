<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindJobs.aspx.cs" Inherits="UI.UiFindJobs" %>

<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tìm Việc Làm</title>
      <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="../Skin/Styles/common.css" rel="stylesheet" />
    <link href="../Skin/Styles/StyleSearch.css" rel="stylesheet" />
    <script src="../Skin/Scripts/jquery-1.8.3.js"></script>
    <script src="../Skin/Scripts/bootstrap.min.js"></script>
    <link href="../Skin/Styles/StyleSearch3.css" rel="stylesheet" />
    <link href="../Skin/Styles/Menu_search.css" rel="stylesheet" />
    <link href="../Skin/Styles/ListNewsResult.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".container_16").css("width", "100%");
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

</head>
<body>
    <form runat="server">
        <uc1:Header runat="server" ID="Header" />
        <div class="container_16" style="padding-left: 213px">
            <div class="grid_16" style="width: 970px">
                <div class="search_03">
                    <div class="clearfix" style="  margin-left: -30px;">
                        <div class="logo pull-left">
                            <h1>
                                <img src="/Skin/Images/findjob_img.png" alt="" /></h1>
                        </div>
                        <!-- end .logo -->
                        <div class="form-search pull-right form-group " style="margin: 11px 0">
                            <asp:Panel runat="server" DefaultButton="btnSearch">
                                <asp:TextBox class="form-control" ID="txtKeywords" placeholder="Nhập công việc muốn tìm. VD: Nhân viên kinh doanh..." runat="server"></asp:TextBox>
                                <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_OnClick" CssClass="btn btn-info" Text="Tìm việc" />
                                <asp:Button runat="server" ID="btnReset" OnClick="btnReset_OnClick" CssClass="btn btn-danger" Text="Làm lại" />
                            </asp:Panel>
                        </div>
                        <!-- end .form-search -->
                    </div>
                </div>
            </div>
            <div class="grid_16">
                <div id="menu">
                    <ul class="nav navbar-nav">
                        <li class="dropdown">
                            <asp:DropDownList Style="border: none; max-width: 130px; width: auto" CssClass="form-control" runat="server" ID="ddlRegions" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="btnSearch_OnClick" />
                        </li>
                        <li class="dropdown">
                            <asp:DropDownList Style="border: none; max-width: 130px; width: auto" CssClass="form-control" runat="server" ID="ddlJobCategories" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="btnSearch_OnClick" />
                        </li>
                        <li class="dropdown">
                            <asp:DropDownList Style="border: none; width: auto; max-width: 130px;" CssClass="form-control" runat="server" ID="ddlJobLevel" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="btnSearch_OnClick" />
                        </li>
                        <li class="dropdown">
                            <asp:DropDownList Style="border: none; width: auto; max-width: 130px;" CssClass="form-control" runat="server" ID="ddlSalaryLevel" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="btnSearch_OnClick" />
                        </li>
                        <li class="dropdown">
                            <asp:DropDownList Style="border: none; width: auto; max-width: 130px;" CssClass="form-control" runat="server" ID="ddlJobExperiences" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="btnSearch_OnClick" />
                        </li>
                        <li class="dropdown">
                            <asp:DropDownList Style="border: none; width: auto; max-width: 130px;" CssClass="form-control" runat="server" ID="ddlDegreeLevel" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="btnSearch_OnClick" />
                        </li>
                        <li class="dropdown">
                            <asp:DropDownList Style="border: none; width: auto; max-width: 150px;" CssClass="form-control" runat="server" ID="ddlJobTimes" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="btnSearch_OnClick" />
                        </li>
                    </ul>
                </div>
            </div>
            <div class="grid_16">

                <div class="list-news">
                    <table class="table">
                        <tr>
                            <td colspan="2"><span id="total_records"></span></td>
                        </tr>
                        <tr>
                            <td>
                                <ul class="lists" style="list-style: none; overflow-y: scroll; height: 790px; margin: 0; padding: 0; background: #f9f9f9; border: 3px solid #FFA319; box-shadow: 0px 0px 8px 2px #c6c6c6; margin-right: 185px;">
                                    <li>
                                        <div id="divMessages" runat="server"></div>
                                    </li>
                                    <asp:Repeater ID="rptSearchResult" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <h4><a href="<%#Eval("RewriteUrl") %>?jobid=<%#Eval("JobID") %>"><%#Eval("FullTitle") %></a> </h4>
                                                <p class="time">
                                                    <label style="color: #ffa319">Thời hạn nộp hồ sơ :</label>
                                                    <%#string.Format("{0:dd/MM/yyyy}", DateTime.Parse(Eval("ExpiredDate").ToString())) %> | <%#Eval("ProvinceName") %>
                                                </p>
                                                <p class="name"><%#Eval("CompanyFullName") %></p>
                                                <p class="add"><%#Eval("Address") %></p>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- end .list-news -->
            </div>
        </div>
        <!-- end .grid_16 -->
    </form>
</body>
</html>
