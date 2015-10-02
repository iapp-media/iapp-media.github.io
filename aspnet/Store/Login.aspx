<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="Mana_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=640" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <p style="font-size:65px">Store</p>
            <asp:TextBox ID="TUID" runat="server" placeholder="請輸入帳號" Width="80%" Height="70px" Font-Size="65px">allen</asp:TextBox>
            <div>&nbsp;</div>
            <asp:TextBox ID="TPWD" runat="server" TextMode="Password" placeholder="請輸入密碼" Width="80%" Height="70px" Font-Size="65px"></asp:TextBox>
            <div>&nbsp;</div>
            <asp:Button ID="Button1" runat="server" Text="登入" Width="80%" Height="70px" BackColor="LightBlue" />
        </div>
    </form>
</body>
</html>
