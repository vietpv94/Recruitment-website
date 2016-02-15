<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>
<%@ Register Src="~/UserControl/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="../Skin/Styles/bootstrap.css" rel="stylesheet" />
    <link href="../Skin/Styles/Style_For_All.css" rel="stylesheet" />
    <link href="../Skin/Styles/common.css" rel="stylesheet" />
    <link href="../Skin/Styles/StyleSearch.css" rel="stylesheet" />
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
        <uc1:Header runat="server" id="Header" />
        <div id="wrapper">
            <div class="container_16">
                <div class="grid_16" >
                    <div class="search">
                	<div class="logo">
                    	<p><strong style="margin-left: 235px;color: #008B8B">Tìm Kiếm Công Việc Mơ Ước. Nâng Bước Thành Công!</strong></p>
                    </div><!-- end .logo -->
                    <div class="form-search">
                    	<div class="form-group">
                            <asp:TextBox ID="tbQuickSearch" runat="server" placeholder="Tìm theo tên việc làm, chức vụ ..." CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button ID="btQuickSearch" runat="server" Text="Tìm Kiếm Nhanh" CssClass="btn btn-default btn-b" OnClick="btQuickSearch_Click"/>
                        </div>
                    </div><!-- end .form-search -->
                </div><!-- end .search -->
                </div>
            </div>
        </div>
    </form>
</body>
</html>
