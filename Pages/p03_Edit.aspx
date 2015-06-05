<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p03_Edit.aspx.vb" Inherits="AppWeb1._4.p03_Edit" %>
<script src="../js/jquery-2.1.4.min.js"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <a href="#" onclick="pic1()">圖1</a>
         <a href="#" onclick="pic2()">圖2</a>
         <a href="#" onclick="pic3()">圖3</a>
        <br />


        <div></div>
        <div style="height: 400px; width: 300px">
            <div id="pic1" style="height: 200px; width: 300px">
                <asp:Label ID="Label1" runat="server" Text="圖片1"></asp:Label>
                <asp:FileUpload ID="FU1" runat="server" Width="72px" />
                <asp:Button ID="Button1" runat="server" Text="上傳" />
                <asp:Image ID="Image1" runat="server" />
            </div>
            <div id="pic2" style="height: 200px; width: 300px; display:none">
                <asp:Label ID="Label2" runat="server" Text="圖片2"></asp:Label>
                <asp:FileUpload ID="FU2" runat="server" Width="72px" />
                <asp:Button ID="Button2" runat="server" Text="上傳" />
                <asp:Image ID="Image2" runat="server" />
            </div>
            <div id="pic3" style="height: 200px; width: 300px;display:none">
                <asp:Label ID="Label3" runat="server" Text="圖片3"></asp:Label>
                <asp:FileUpload ID="FU3" runat="server" Width="72px" />
                <asp:Button ID="Button3" runat="server" Text="上傳" />
                <asp:Image ID="Image3" runat="server" />
            </div>
        </div>
    </form>
    <script>
        function pic1() {
            $("#pic1").show();
            $("#pic2").hide();
            $("#pic3").hide();
        }
        function pic2() {
            $("#pic1").hide();
            $("#pic2").show();
            $("#pic3").hide();
        }
        function pic3() {
            $("#pic1").hide();
            $("#pic2").hide();
            $("#pic3").show();
        }
    </script>
</body>
</html>
