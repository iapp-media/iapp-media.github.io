<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>iApp Mobile We-Media Platform</title>
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/login.css" />
    <link href="css/button.css" rel="stylesheet" />
    <style>
        .tb5 {
            margin-left: 15px;
            margin-top: 10px;
            margin-right: 15px;
            width: 220px;
            height: 20px;
            color: #7b7b7b;
        }
    </style>
</head>
<body>
    <div id="fb-root"></div>
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: '535863396553786',
                xfbml: true,
                version: 'v2.3'
            });
        };

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));



    </script>
    <form id="form1" runat="server">
        
        <div class="content">
            <div class="middle-bar"></div>
            <div class="logo"></div>
            <div style="position: absolute; top: 5%; left: 5%; width: 40%; height: 10%;">
                <p style="text-align: end; font-size: large; font-weight: bold; color: #ff9933;">登入／註冊</p>
                <div class="bar"></div>
            </div>
            <!-- 登入input位置 -->
            <div class="input">
                <div style="margin: 10px;">
                    <span style="text-align: right; margin-left: 15px; margin-top: 0px; margin-right: 15px; color: #7b7b7b;">帳號</span>
                    <br />
                    <asp:TextBox ID="accBox" runat="server" CssClass="tb5" placeholder="Email"></asp:TextBox>
                </div>
                <div style="margin-top: 15px; margin-left: 10px">
                    <span style="text-align: right; margin-left: 15px; margin-top: 0px; margin-right: 15px; color: #7b7b7b;">密碼</span>
                    <br />
                    <asp:TextBox ID="pwBox" runat="server" CssClass="tb5" TextMode="Password"></asp:TextBox><br />
                </div>
            </div>

            <div style="position: absolute; top: 5%; left: 55%; width: 40%; height: 10%;">
                <p style="text-align: end; font-size: large; font-weight: bold; color: #ff9933;">Facebook登入</p>
                <div class="bar"></div>
            </div>
            <!-- facebook登入input位置 -->
            <div class="input-fb">
                <div class="facebook"><a href="#" onclick="startup();">
                    <img src="img/box-fblogin.png"></a></div>
            </div>
            <div style="position: absolute; top: 52%; left: 5%; width: 40%; height: 8%;">
                <div class="login">
                    <%-- <p>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">登入</asp:LinkButton></p>--%>
                    <asp:Button ID="Button1" runat="server" Text="登入" CssClass="login-1" OnClick="LinkButton1_Click" />
                </div>
                <div class="register">
                    <%--    <p><a href="Register.aspx">註冊</a></p>--%>
                    <asp:Button ID="Button2" runat="server" Text="註冊" CssClass="register-1" OnClick="Button2_Click" />
                </div>

            </div>
        </div>
        <div class="content2 hide">
            <asp:LinkButton ID="LB2" runat="server" OnClick="LB2_Click" CssClass="hide"> </asp:LinkButton>
        </div>
    </form>
    <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
    <script>
        function startup() {
            FB.login(function (response) {
                if (response.status === 'connected') {
                    FB.api('/me', function (res) {
                        $.ajax({
                            type: "POST",
                            url: "FBChk.aspx?name=" + res.name + "&email=" + res.email + "&id=" + res.id + "&token=" + encodeURIComponent(response.authResponse.accessToken) + "&gender=" + res.gender + "&link=" + encodeURIComponent(res.link),
                            cache: false,
                            success: function (w) {
                                __doPostBack('LB2', '');
                            },
                            error: function (ss) {
                                alert(ss);
                            }
                        });
                    });

                } else if (response.status === 'not_authorized') {
                    alert('請登入');
                } else {
                    alert('請登入Facebook');
                    //startup();
                }
            }, { scope: 'publish_actions' });

        }
    </script>
</body>
</html>
