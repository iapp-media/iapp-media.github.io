<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verify.aspx.cs" Inherits="Wedding.verify" %>
 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no"/>
    <title>mobile-login</title>
  <%--  <link rel="stylesheet" href="css/reset.css" />--%>
    <link rel="stylesheet" href="css/admin/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/m-login.css"/>
</head>
<body>
    
    
    <form id="form1" runat="server">
        <!-- mobile會員登入畫面 -->
        <div class="login-mobile">
           
            <div class="content">
 
                <div class="login">
                    <p>序號驗證</p>
                    <div class="bar"></div> 
                       <asp:TextBox ID="T_No" runat="server" CssClass="admin" placeholder="序號"></asp:TextBox>　
                </div>
                <div class="login-back">
                    <a href="javascript:history.back();"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a>
                </div>
                <div class="send" id="login">
                　<asp:Button ID="BT_Send" runat="server" Text="驗證"　 OnClick="BT_Send_Click" />

　                </div>
            </div>
             
        </div>
       
    </form>
    <script type="text/javascript" src="js/jquery-1.11.2.min.js"></script> 
    <script src="js/admin/bootstrap.min.js"></script>
  >
</body>
</html>

 