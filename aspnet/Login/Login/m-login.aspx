<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="m-login.aspx.cs" Inherits="Login.m_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no"/>
    <title>mobile-login</title>
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/m-login.css"/>
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
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="LoginAni">
            <div class="Storelogo">
                <img src="img/img-1.png" alt="Alternate Text" />
            </div>
          
                <img src="img/img-1-1.png" alt="Alternate Text" class="Logohouse" />
           
        </div>
        <!-- mobile會員登入畫面 -->
        <div class="login-mobile">
            <div class="navbar">
                <img class="iapplogo" src="img/iapplogo.png">
            </div>
            <div class="content">
                <div class="fb">
                    <p>FaceBook登入</p>
                    <div class="bar"></div>
                    <a href="#" onclick="startup()">
                        <img class="fb-img" src="img/fb.png"></a>
                </div>
                <div class="login">
                    <p>會員帳號登入</p>
                    <div class="bar"></div>
                    <asp:TextBox ID="accBox" class="admin" autocomplete="on" runat="server" placeholder="電子郵件"></asp:TextBox>
                    <asp:TextBox ID="pwBox" class="password" runat="server" placeholder="密碼" TextMode="Password"></asp:TextBox>
                  <%--  <input type="submit" id="login-submit" style="display: none;" />--%>

                </div>
                <div class="login-back">
                    <a href="javascript:history.back();"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a>
                </div>
                <div class="send" > 
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span> 
                    </asp:LinkButton>
                </div> 
            </div>

            <div class="footer">
                <p>還不是會員嗎？>></p>
                <div class="join">
                    <p>
                        <a class="" href="">加入我們</a>
                    </p>
                </div>
            </div>
        </div>
        <!-- mobile會員註冊畫面 -->
        <div class="register-mobile">
            <div class="navbar">
                <img class="iapplogo" src="img/iapplogo.png">
            </div>
            <div class="content">
                <div class="login">
                    <p>註冊會員</p>
                    <div class="bar"></div>
                </div>
                <div class="register-input">
                    <asp:TextBox ID="User_Name" placeholder="名字" CssClass="name" runat="server"></asp:TextBox>
                    <asp:TextBox ID="Email" runat="server" placeholder="email" CssClass="admin"></asp:TextBox>
                    <asp:TextBox ID="Pw" placeholder="密碼" runat="server" TextMode="Password" CssClass="password"></asp:TextBox>
                </div>
                <div class="Sendbox_1">
                    <input type="checkbox" ><strong>我同意 IApp微店《<a target="_blank"  href="../ministore/terms.html">服務條款</a>》及《<a target="_blank"  href="../ministore/privacy.html">隱私權政策</a>》</strong>
                </div>
                <div class="register-back">
                    <a href=""><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></a>
                </div>
                <div class="send" id="register">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">
                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span> 
                    </asp:LinkButton>
                </div>
            </div>
            <div class="footer"> 
                    <asp:LinkButton ID="LB3" runat="server" OnClick="LB3_Click" CssClass="hidden"> 
                    </asp:LinkButton>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
    <!-- 依需要參考已編譯外掛版本（如下），或各自獨立的外掛版本 -->
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
                                __doPostBack('LB3', '');
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
    <script src="js/bootstrap.min.js"></script>
    <script src="js/m-login.js"></script>
</body>
</html>
