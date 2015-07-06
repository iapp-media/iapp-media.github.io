<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p05.aspx.vb" Inherits="AppWeb1._4.p05" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <style>
       #text {
           position:absolute;
           bottom:100px;
           left:75px;
       }
   </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin:0;padding:0;">
   <div id="p01" style="width: 261px; height:464px; margin:0;padding:inherit">
            <asp:Image Style="width: 261px; height:464px" ID="Image1" ImageUrl="~/img/picture5.jpg" runat="server" />
        </div>
    <div id="text">
            <asp:Label ID="Label1" runat="server" Text="請點選輸入文字"></asp:Label>
         </div>
    </body>
</html>
