<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p03.aspx.vb" Inherits="AppWeb1._4.p03" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="margin:0; background-color:white;">
    <form id="form1" runat="server">
        <div style="height: 450px; width: 300px">
            <div id="pic1"  style="height: 135px; width: 280px">
                <asp:Image ID="Image1" ImageUrl="~/img/basic/p03-1b.jpg" runat="server" />
            </div>
            <div id="pic2" style="height: 135px; width: 280px">
                <asp:Image ID="Image2" ImageUrl="~/img/basic/p03-2b.jpg" runat="server" />
            </div>
            <div id="pic3" style="height: 135px; width: 280px">
                <asp:Image ID="Image3" ImageUrl="~/img/basic/p03-3b.jpg" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
