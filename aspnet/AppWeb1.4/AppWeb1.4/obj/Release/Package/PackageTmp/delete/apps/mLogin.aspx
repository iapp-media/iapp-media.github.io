<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mLogin.aspx.vb" Inherits="AppWeb1._4.mLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="img/favicon.ico" rel="shortcut icon" />

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
    <div id="status">
    </div>
    <script>
        function startup() {
            FB.login(function (response) {
                if (response.status === 'connected') {
                    var form = document.createElement("form");
                    form.setAttribute("method", 'post');
                    form.setAttribute("action", 'mFBLogin.aspx?c=' + document.getElementById('CID').value);

                    var field = document.createElement("input");
                    field.setAttribute("type", "hidden");
                    field.setAttribute("name", 'accessToken');
                    field.setAttribute("value", response.authResponse.accessToken);
                    form.appendChild(field);
                    document.body.appendChild(form);
                    //alert(response.authResponse.accessToken);
                    form.submit();

                } else if (response.status === 'not_authorized') {
                    // The person is logged into Facebook, but not your app.
                    document.getElementById('status').innerHTML = '請登入';
                } else {
                    // The person is not logged into Facebook, so we're not sure if they are logged into this app or not.
                    document.getElementById('status').innerHTML = '請登入Facebook.';
                    startup();
                }
            }, { scope: 'publish_actions' });

        }

    </script>
    <form id="form1" runat="server">
        <div class="content" style="text-align:center"> 
            <div class="logo"></div>
            <div>
                <p style="text-align: end; font-size: large; font-weight: bold;color: #ff9933;">登入／註冊</p>
                <div class="bar"></div>
            </div>
            <!-- 登入input位置 -->
            <div class="input" style="text-align:left; width:200px; display:inline-block;" >
                <div style="margin:10px;">
                <span style="color:#7b7b7b;">帳號</span> 
                <br/>
                    <asp:TextBox ID="accBox" placeholder="請輸入您註冊的Email" style="color:#7b7b7b;" runat="server" CssClass="tb5"></asp:TextBox>
                </div>
                <div style="margin:10px ">
                <span style="color:#7b7b7b;">密碼</span>
                <br/>
                <asp:TextBox ID="pwBox" runat="server" CssClass="tb5" TextMode="Password" style="color:#7b7b7b;"></asp:TextBox>
                </div>
            </div>
            <div > 
                <div class="login"><p>
                    <asp:LinkButton ID="LoginBtn" runat="server">登入</asp:LinkButton>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<a href="SignUp.aspx">註冊</a></p></div> 
            </div>
            <hr />
            <div>
                <p style="text-align: end; font-size: large; font-weight: bold;color: #ff9933;">Facebook登入</p>
                <div class="bar"></div>
            </div>
            <!-- facebook登入input位置 -->
            <div class="input-fb">
                <div class="facebook"><p><a href="#" onclick="startup()">facebook登入</a></p></div>
            </div>
        </div>
        <div class="content2 hide">
        </div>
        <asp:HiddenField ID="CID" runat="server" />
    </form>
	</body>


</html>

