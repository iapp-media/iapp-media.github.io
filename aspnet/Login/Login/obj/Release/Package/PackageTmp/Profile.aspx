<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Login.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Document</title>
    <link rel="stylesheet" type="text/css" href="css/reset.css" />
    <link rel="stylesheet" type="text/css" href="css/profile.css" />
    <link rel="stylesheet" type="text/css" href="css/colorbox2.css"/>
    <link rel="stylesheet" type="text/css" href="css/edit.css"/>
    <link href="img/favicon.ico" rel="shortcut icon" />
    <script>
        function show() {
            $("#changePw").show();
        }

    </script>
 
    <style>
        #FU1 {
            display: none;
        }

        #p1 {
            margin-bottom: 5px;
        }

        .hide {
            display: none;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="top">
                <p>會員資料</p>
                <div class="bar3"></div>
            </div>
            <!-- 基本資料區域 -->
            <div class="profile">

                <div class="logo-file">
                    <a id="show-upload" class='#' href='Pages/AUL.aspx?Profile=1&w=100&h=100'>
                        <asp:Image ID="p1" CssClass="icon" runat="server" ImageUrl="img/headimg.png" />
                        <p>選擇檔案</p>
                    </a>
                </div>

                <table class="t1">
                    <tr>
                        <td>帳號:</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>姓名</td>
                        <td>
                            <asp:TextBox ID="TName" runat="server" BorderStyle="None" ></asp:TextBox>
                            <%--<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%>
                        </td>
                    </tr>
                </table>

                <div class="bar"></div>

                <table class="t2">
                    <tr>
                        <td>更新密碼:</td>
                        <td>
                            <asp:TextBox ID="pw1" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>再次輸入新密碼:</td>
                        <td>
                            <asp:TextBox ID="pw2" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                </table>

                <div class="store">
                    <p>
                        <asp:LinkButton ID="BtnSend" runat="server" OnClick="BtnSend_Click">儲存</asp:LinkButton>
                    </p>
                </div>
                <div class="cancel">
                    <p>
                        <%--<a href="#">取消</a>--%>
                         <asp:LinkButton ID="BTCancel" runat="server">取消</asp:LinkButton>
                    </p>
                </div>
            </div>
        </div>
    </form>

    <script src="js/edit.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="js/jquery.url.js"></script>
    <script src="js/jquery.colorbox-min.js"></script>
       <script>
           $(document).ready(function () {
               //Examples of how to assign the Colorbox event to elements
               $("#show-upload").colorbox({
                   iframe: true,
                   width: "100%",
                   height: "400px"
               });
           });
           function ref() {
               location.reload();
           }
    </script>
</body>
</html>
