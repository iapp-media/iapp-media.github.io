<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p05_Edit.aspx.vb" Inherits="AppWeb1._4.p05_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script src="../js/jquery-2.1.4.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div style="width:300px;height:488px;left:0;top:0;z-index:-2;">
       
        <img style="position:absolute;left:15px;top:15px;z-index:-1; right: 680px;" src="../images/1-3背景圖.jpg"/>
    </div>
        <div>
         <asp:FileUpload ID="FileUpload1" runat="server" Height="27px" Width="71px" />
        <asp:Button ID="Button1" runat="server" Text="上傳" />
            </div>
    </form>
    <script>
       
        
    </script>
</body>
</html>
