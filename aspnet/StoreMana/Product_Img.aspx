<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product_Img.aspx.cs" Inherits="StoreMana.Product_Img" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-2.1.4.min.js"></script>
    <style>
        #BTUpload {
            margin:0 0 0 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     
                            <asp:Literal ID="L" runat="server"></asp:Literal>
                            <asp:FileUpload ID="FU" runat="server" />
                            <asp:Button ID="BTUpload" runat="server" Height="20px" Text="上傳" Width="56px" OnClick="BTUpload_Click" OnClientClick="ToLoad()"/>

<%--                            <a id="show-upload" onclick="goValue(1)" class='#' href="#">
                                <label for="FU">
                                    <img class="upload" src="img/uploadicon.png" height="250" width="200" />
                                </label>
                            </a>
                            <input type="file" accept="image/*" capture="camera" class="hide" id="inputImage" style="display: none" />--%>
                     
        <script> 
            function ToLoad() {
                window.parent.Iframeload();
            }
        </script>
    </form>
</body>
</html>
