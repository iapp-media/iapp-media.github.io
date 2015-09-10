<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mSet.aspx.vb" Inherits="AppWeb1._4.mSet" %>

<!DOCTYPE html>
<html> 
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script async="" src="js/analytics.js"></script>
    <title>  </title>
    <link rel="stylesheet" type="text/css" href="css/reset.css">
    <link rel="stylesheet" type="text/css" href="css/cropper.css"> 
    <link rel="stylesheet" type="text/css" href="css/mset.css">
</head>
<body>
    <form id="form1" runat="server" style="height:100%">   

    <img src="img/ajax-loader.gif" class="uploading" style="position:absolute; left:calc(50% - 64px); top:calc(50%); z-index:5000;">
    <div class="top">
        <img src="img/iapplogo.png" class="toplogo" align="left">
        <img src="img/cancel-1.png" class="cancel hide" align="right">
    </div>
    <div class="container"> 
        <div class="icon">
            <label for="inputImage" onclick="setCurrent('1',114,114)">
                <asp:Image ID="p1" CssClass="iconimg-1" runat="server" ImageUrl="img/default-icon.png" /> 
            </label>
        </div>
        <div class="">
            <label for="TAppName">iApp名稱</label>
            <asp:TextBox ID="TAppName" runat="server" MaxLength="13" CssClass="name" placeholder="必填(限13個字)"></asp:TextBox> 
        </div>
        <div>
            <label for="TAppMemo">iApp 描述</label>
            <asp:TextBox ID="TAppMemo" runat="server" CssClass="describe" Rows="3" TextMode="MultiLine"></asp:TextBox> 
        </div>
        <input type="button" value="完成" class="submit" onclick="SendData()" />
        <asp:Button ID="Button1" runat="server" Text="完成" CssClass="hide" OnClientClick="return SendData();" />
        <asp:LinkButton ID="LK1" runat="server" CssClass="hide"> </asp:LinkButton>
    </div>
    <div class="upload-img hide">
        <label for="inputImage">
            <div class="select">
                選擇照片
            </div>
        </label>
        <div class="rotate">
            <button data-method="rotate" type="button" class="rotate-btn">旋轉</button>
        </div>
        <div class="preview-container">
            <img id="preview" src="">
        </div>
        <div class="img-container">
            <img src="" alt="支持圖片上傳格式JPG,PNG" for="inputImage">
        </div> 
        <p class="word">(移動及縮放進行照片裁切)</p> 
        <input type="file" accept="image/*" id="inputImage" class="hide">
        <button data-method="getCroppedCanvas" type="button" class="cut">
            截圖
        </button>
        <button onclick="compress()" type="button" class="send" id="sended">
            確認
        </button>
        <asp:TextBox ID="CurrentId" runat="server" CssClass="hide"></asp:TextBox>
        <asp:TextBox ID="Tbase64" runat="server" CssClass="hide"></asp:TextBox>
    </div>
    </form>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="http://www.parsecdn.com/js/parse-1.4.2.js"></script>
    <script src="js/JIC.js"></script>
    <script src="js/cropper.js"></script>
    <script src="js/mset.js"></script>
    <script>
        $(document).ready(function () {
            $('.uploading').hide();
            $("#inputImage").click(function () {
                $('.preview-container').hide();
                $('.img-container').show();
                $(".upload-img").show();
                $(".container").hide();
                $('.send').hide();
                $('.cut').show();
                $('.cancel').show();
                $('.rotate-btn').show();
            });
            $(".cut").click(function () {
                $(".cut").hide();
                $(".send").show();
                $('.rotate-btn').hide();

            });
            $("#sended").click(function () {
                $(".upload-img").hide();
                $(".container").show();
                $('.cancel').hide();
            });
            $('#inputImage').change(function () {
                $('.preview-container').hide();
                $('.img-container').show();
                $('.send').hide();
                $('.cut').show();
            });
            $('.cancel').click(function () {
                $(".upload-img").hide();
                $(".container").show();
                $('.cancel').hide();
            });

        });
        $('#TAppName').change(function () {
            if ($('#TAppName').val() != '') {
                $('.submit').attr("disabled", false);

            } else {
                $('.submit').attr("disabled", true);;
            }
        })

    </script>
</body>
</html>
