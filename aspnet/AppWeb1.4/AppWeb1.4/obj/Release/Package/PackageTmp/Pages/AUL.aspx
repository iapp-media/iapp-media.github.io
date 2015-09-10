<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AUL.aspx.vb" Inherits="AppWeb1._4.AUL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no" />
    <title>iApp Platform</title>
    <!-- 套用css -->
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../css/cropper.css" />
    <link rel="stylesheet" type="text/css" href="../css/edit-pic.css" />
    <style>
        .TShide {
            display: none;
        }
        .PDstyle {
            width:100%;
            position:absolute;
            height:100%;
            z-index:999;
            display:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="show">
            <a id="backlist" onclick="backlist()" href="" runat="server" visible="false">
                <img class="" src="../img/back-1.png" /></a>
            <label for="inputImage">
                <img class="upload" src="../img/uploadicon.png" />
            </label>
            <img id="showImg" runat="server" class="showImg opacity" src="../img/picture1.jpg" />
        </div>
        <div class="upload-img">
            <div class="option">
                <label for="inputImage">
                    <div class="select">
                        
                    </div><%--上傳照片--%>
                </label>
                <button data-method="rotate" type="button" class="rotate-btn"></button><%--旋轉--%>
            </div>
            <div class="preview-container">
                <img id="preview" class="preview" src="" />
            </div>
            <div class="img-container">
                <img src="" alt="支持圖片上傳格式JPG,PNG" />
            </div>
            <p class="word">(拖曳進行照片裁切)</p>
            <input type="file" accept="image/*" capture="camera" class="hide" id="inputImage"   />
            <button data-method="getCroppedCanvas" type="button" class="cut" >
                
            </button><%--截圖--%>
            <asp:Button ID="BTN" data-method="getCroppedCanvas" OnClientClick="compress(),PassBase64()" runat="server" Text="" CssClass="compress" /><%--確認--%>
        </div>
        <label id="base64" style="word-wrap: break-word; word-break: normal; display: none;">Null</label>
        <asp:TextBox ID="TS" runat="server" CssClass="TShide"></asp:TextBox>
        <asp:Image ID="PDialog" runat="server" CssClass="PDstyle" src="../img/6RMhx.gif" />
    </form>
</body>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<!-- 依需要參考已編譯外掛版本（如下），或各自獨立的外掛版本 -->
<script src="../js/exif.js"></script>
<script type="text/javascript" src="../js/JIC.js"></script>
<script type="text/javascript" src="../js/cropper.js"></script>
<script type="text/javascript" src="../js/cropperPage.js"></script>
 <script> 
     function getValue(varname) {
         var url = window.location.href;
         try {
             var qparts = url.split("?");
             if (qparts.length == 0) {
                 return "";
             }
             var query = qparts[1];
             var vars = query.split("&");
             var value = "";
             for (i = 0; i < vars.length; i++) {
                 var parts = vars[i].split("=");
                 if (parts[0] == varname) {
                     value = parts[1];
                     break;
                 }
             }
             value = unescape(value);
             value.replace(/\+/g, " ");
             return value;
         } catch (err) {
             return "";
         }
     }
     if (getValue('APCover') || getValue('Icon')) {
          
         $('.preview-container').hide();
         $('.img-container').show();
         $('.upload-img').show();
         $('#show').hide();
         $('.compress').hide();
         //$('.cut').show();
         $('.cut').hide();
         $('.rotate-btn').show();
         $('#inputImage').trigger('click');
     }
 </script>
<script>
    function PassBase64() {
        document.getElementById('TS').value = document.getElementById('base64').innerText;
    }
</script> 
<script>
    $(document).ready(function () {
        $('.upload').click(function () {
            $('.preview-container').hide();
            $('.img-container').show();
            $('.upload-img').show();
            $('#show').hide();
            $('.compress').hide();
            //$('.cut').show();
            $('.cut').hide();
            $('.rotate-btn').show();
        });
        $('.cut').click(function () {
            $('.cut').hide();
            $('.compress').show();
            $('.rotate-btn').hide();
            $('.word').addClass('transparent');
        });
        $('.compress').click(function () {
            $('.upload-img').hide();
            $('#show').show();
        });
        $('#inputImage').change(function () {
            $('.preview-container').hide();
            $('.img-container').show();
            $('.send').hide();
            $('.cut').show();
            $('.word').removeClass('transparent');
        });
    });
    function backlist() {
        $("#backlist").attr('href', '../Setting1.aspx?i=' + getValue('list') + '');
    }
</script>
</html>
