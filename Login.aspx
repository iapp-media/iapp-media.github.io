<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="AppWeb1._4.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>login</title>
    <link rel="stylesheet" href="css/login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="top"></div>
        <div class="content">
            <div class="middle-bar"></div>
            <div class="logo"></div>
            <div style="position: absolute; top: 5%; left: 5%; width: 40%; height: 10%;">
                <p style="text-align: end; font-size: large; font-weight: bold;">登入／註冊</p>
                <div class="bar"></div>
            </div>
            <!-- 登入input位置 -->
            <div class="input">
                <div style="margin:10px;">
                <span style="text-align:right;margin-left:15px;margin-top:0px;margin-right:15px;">帳號:</span>
                <asp:TextBox ID="accBox" runat="server" CssClass="aaa"></asp:TextBox>
                    <br/>
                <span style="color:red;margin:20px">請輸入您註冊的Email</span>
               </div>
                <div style="margin-top:15px;margin-left:10px ">
                <span style=" text-align:right; margin-left:15px;margin-top:0px;margin-right:15px;">密碼:</span>
                <asp:TextBox ID="pwBox" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div style="position: absolute; top: 5%; left: 55%; width: 40%; height: 10%;">
                <p style="text-align: end; font-size: large; font-weight: bold;">Facebook登入</p>
                <div class="bar"></div>
            </div>
            <!-- facebook登入input位置 -->
            <div class="input-fb">facebook登入位置框</div>

            <div style="position: absolute; top: 52%; left: 5%; width: 40%; height: 8%;">


                <asp:ImageButton ID="LoginBtn1" ImageUrl="img/login.png" runat="server" Style="height: 100%; width: auto;" />

                <%--<img src="img/login.png" height="100%" width="auto" onMouseOut="this.src='img/login.png'" onMouseOver="this.src='img/login-1.png'">--%>
                <a href="Register.aspx">
                    <img src="img/register.png" height="100%" width="auto" onmouseout="this.src='img/register.png'" onmouseover="this.src='img/register-1.png'"></a>

                <!-- <div class="login" src="img/button.png" onMouseOut="this.src='img/button.png'" onMouseOver="this.src='img/button-2.png'"></div> -->
                <!-- <a href="signup.html"><div class="register"></div></a> -->
            </div>
        </div>
        <div class="content2 hide">
        </div>
        <div class="bottom"></div>
    </form>
	</body>

</html>

