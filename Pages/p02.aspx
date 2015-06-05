<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p02.aspx.vb" Inherits="AppWeb1._4.p02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div style="height: 440px; width: 280px">
                <div id="Pic1" style="height: 210px; width: 275px">
                  <%--  <asp:FileUpload ID="FU1" runat="server" Height="21px" Width="147px" />--%>
                    <asp:Image ID="Image1" ImageUrl="~/images/1c.jpg" runat="server" />
                    <%--<asp:Button ID="Button1" runat="server" Text="上傳" />--%>
                </div>
                <div id="Pic2" style="height: 210px; width: 275px">
                   <%-- <asp:FileUpload ID="FU2" runat="server" Height="19px" Width="142px" />--%>
                    <asp:Image ID="Image2" ImageUrl="~/images/2c.png" runat="server" />
                <%--    <asp:Button ID="Button2" runat="server" Text="上傳" />--%>
                </div>
            </div>
    </form>
</body>
</html>
