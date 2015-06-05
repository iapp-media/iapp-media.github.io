<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p02_Edit.aspx.vb"  Inherits="AppWeb1._4.p02_Edit" %>
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

        <div>

            <div style="height: 440px; width: 280px">
                <div id="Pic1" style="height: 210px; width: 275px">
                    <asp:Label ID="Label1" runat="server" Text="圖片1"></asp:Label>
                    <asp:FileUpload ID="FU1" runat="server" Height="21px" Width="147px" />
                    <asp:Button ID="Button1" runat="server" Text="上傳" />
                    <asp:Image ID="Image1" runat="server" />
                </div>
                <div id="Pic2" style="height: 210px; width: 275px; display:none; ">
                    <asp:Label ID="Label2" runat="server" Text="圖片2"></asp:Label>
                    <asp:FileUpload ID="FU2" runat="server" Height="19px" Width="142px" />
                    <asp:Button ID="Button2" runat="server" Text="上傳" />
                    <asp:Image ID="Image2" runat="server" />
                </div>
            </div>

        </div>
        <br />
        <br />

    </form>
    <script>
        function pic1() {
            $("#Pic1").show();
            $("#Pic2").hide();
        }
        function pic2() {
            $("#Pic1").hide();
            $("#Pic2").show();
        }
    </script>
</body>
</html>
