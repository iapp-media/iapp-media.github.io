<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Message.aspx.vb" Inherits="Message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:640px;position:fixed;top:0%;background-color:White; border:1px solid black;">
       <div style="text-align:left; float:left"><a href="javascript:history.back(-1);" title="回上一頁"><img width="75" height="50" src="" id="img5" runat="server" alt="回上一頁"/></a></div>
       <div style="text-align:right;float:right"><asp:ImageButton ID="ImageButton1" runat="server" width="60px" height="50px"/></div>
    </div>
    <div style="width:640px;top:55px;position:relative;">
        <asp:TextBox ID="TB_Message" runat="server" Width="100%" Height="200" TextMode="MultiLine"></asp:TextBox>
    </div>
    </form>
</body>
</html>
