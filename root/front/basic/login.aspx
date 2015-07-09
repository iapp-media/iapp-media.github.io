<!-- <%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="AppWeb1._4.Login" %> -->

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>login</title>
    <link rel="stylesheet" href="css/login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="middle-bar"></div>
            <div class="logo"></div>
            <div style="position: absolute; top: 5%; left: 5%; width: 40%; height: 10%;">
                <p style="text-align: end; font-size: large; font-weight: bold;color: #ff9933;">登入／註冊</p>
                <div class="bar"></div>
            </div>
            <!-- 登入input位置 -->
            <div class="input" >
                <div style="margin:10px;">
                <span style="text-align:right;margin-left:15px;margin-top:0px;margin-right:15px;color:#7b7b7b;">帳號</span>
                <asp:TextBox ID="accBox" runat="server" CssClass="tb5"></asp:TextBox>
                <br/>
                <input type="text" placeholder="Email" style="margin-left:15px;margin-top:10px;margin-right:15px;width:220px;height:20px;color:#7b7b7b;">
                </div>
                <div style="margin-top:15px;margin-left:10px ">
                <span style=" text-align:right; margin-left:15px;margin-top:0px;margin-right:15px;color:#7b7b7b;">密碼</span>
                <asp:TextBox ID="pwBox" runat="server" CssClass="tb5" TextMode="Password"></asp:TextBox><br/>
                <input type="text" style="margin-left:15px;margin-top:10px;margin-right:15px;width:220px;height:20px;color:#7b7b7b;">
                </div>
            </div>

            <div style="position: absolute; top: 5%; left: 55%; width: 40%; height: 10%;">
                <p style="text-align: end; font-size: large; font-weight: bold;color: #ff9933;">Facebook登入</p>
                <div class="bar"></div>
            </div>
            <!-- facebook登入input位置 -->
            <div class="input-fb">
                <div class="facebook"><a href="#"><img src="img/box-fblogin.png"></a><p><a href="#">facebook登入</a></p></div>
            </div>
            <div style="position: absolute; top: 52%; left: 5%; width: 40%; height: 8%;">


                <asp:ImageButton ID="LoginBtn1" ImageUrl="img/login.png" runat="server" Style="height: 100%; width: auto;" />
                
                <div class="login"><p><a href="#">登入</a></p></div>
                <div class="register"><p><a href="Register.html">註冊</a></p></div>
                
            </div>
        </div>
        <div class="content2 hide">
        </div>
    </form>
    </body>

</html>

