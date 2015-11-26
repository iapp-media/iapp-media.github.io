<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="m-Profile.aspx.cs" Inherits="Login.m_Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no" />
    <title>mobile-profile</title>
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/m-profile.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- mobile會員資料畫面 -->
        <div class="login-mobile">
            <div class="navbar">
                <img class="iapplogo" src="img/iapplogo.png">
                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
            </div>
            <div class="content">
                <div class="login">
                    <p>會員資料</p>
                    <div class="bar"></div>
                    <div class="login-input">
                        <%--                    <form method="post" action="" class="login-input" onsubmit="return checkLogin();">--%>
                        <div class="logo-file">
                            <a id="show-upload" class="#" href="javascrip:void(0)" onclick="callAUL()">
                                <asp:Image ID="p1" CssClass="icon" runat="server" ImageUrl="img/defaulthead.jpg" />
                                <p>選擇檔案</p>
                            </a>
                        </div>
                        姓名：<asp:TextBox ID="mname" runat="server" CssClass="name"></asp:TextBox>
                        電話：<asp:TextBox ID="mtel" runat="server" CssClass="tel"></asp:TextBox>
                        更改密碼：<asp:TextBox ID="mrepasswd" runat="server" CssClass="repasswd"></asp:TextBox>
                        確認密碼：<asp:TextBox ID="mckpasswd" runat="server" CssClass="ckpasswd"> </asp:TextBox>
                        <%--<asp:Button runat="server" Text="Button" ID="login-submit"></asp:Button>--%>
                        <%--                    <input type="submit" id="login-submit" style="display: none;">--%>
                        <%--                    </form>--%>
                    </div>
                </div>

                <div class="login-back">
                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                </div>
                <div class="send" id="login">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span></asp:LinkButton>
                </div>
            </div>
            <div class="footer">
            </div>

        </div>

        <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
        <!-- 依需要參考已編譯外掛版本（如下），或各自獨立的外掛版本 -->
        <script src="js/bootstrap.min.js"></script>
        <script src="js/m-login.js"></script>
        <script>
            function readCookie(name) {
                var nameEQ = name + "=";
                var ca = document.cookie.split(';');
                for (var i = 0; i < ca.length; i++) {
                    var c = ca[i];
                    while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
                }
                return null;
            }
            function callAUL() {
                var YorN = getValue('i');
                $("#show-upload").attr('href', 'AUL.aspx?Profile=' + readCookie('iapp_uid') + "&w=100&h=100");
            }
        </script>
    </form>
</body>
</html>

