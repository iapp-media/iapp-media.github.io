<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p06_Edit.aspx.vb" Inherits="AppWeb1._4.p06_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../js/jquery-2.1.4.min.js"></script>
    <style>
        #finish {
            height: auto;
            width: auto;
            position: relative;
            color:pink;
            left:0;
            top: 0;
        }
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-2.1.4.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%;text-align:center;">
            <asp:FileUpload ID="FU" runat="server" Height="23px" Width="161px" />
            <asp:Label ID="Msg" runat="server"></asp:Label>
            <div>
            <asp:Image ID="Image1" runat="server" Height="400px" Width="300px" />
                <div>
                    <asp:Label contenteditable="true" ID="AA"  runat="server" Text="點我修改文字" BackColor="#FFFFCC"></asp:Label>
                    <asp:TextBox style="display:none;" ID="TextBox1" runat="server"></asp:TextBox>
                </div>
             </div>
            <div>
                <asp:ImageButton ID="finish" ImageUrl="~/img/finish.png" runat="server" />
            </div>
        </div>
    </form>
    <script>
        $("#AA").focusout(function () {
            document.getElementById("TextBox1").value = $("#AA").text();
        });
    </script>
</body>
</html>