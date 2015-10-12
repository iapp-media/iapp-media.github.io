<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product_Img.aspx.cs" Inherits="StoreMana.Product_Img" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-2.1.4.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%">
            <div  style="margin:0 0 0 30px">
              <asp:Literal ID="L" runat="server"></asp:Literal>

            </div>
<%--            <a id="show-upload" onclick="goValue(1)" class='#' href="#">
                <label for="FU">
                    <img class="upload" src="img/uploadicon.png" height="250" width="200" />
                </label>
                </a>--%>
            <%-- style="display:none"--%>
            <asp:FileUpload ID="FU" runat="server"  />
            <%--                        <input type="file" accept="image/*" capture="camera" class="hide" id="inputImage"   style="display:none" />--%>
            <asp:Button ID="BTUpload" runat="server" Height="20px" Text="上傳" Width="56px" OnClick="BTUpload_Click" />
        </div>
        <script>
            $('#FU').change()
        </script>
    </form>
</body>
</html>
