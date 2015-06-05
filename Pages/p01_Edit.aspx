<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p01_Edit.aspx.vb" Inherits="AppWeb1._4.p01_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FU" runat="server" Height="23px" Width="161px" />
        <asp:Button ID="BTFU" runat="server" Text="上傳" />
        <asp:Label ID="Msg" runat="server"></asp:Label>
                <asp:Image ID="Image1" runat="server" Height="400px" Width="300px" />
    </div>
    </form>
</body>
</html>
