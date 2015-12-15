<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="m-Profile.aspx.cs" Inherits="Login.m_Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no" />
    <meta name="description" content="Digital+ 數碼數位 行動自媒體 iApp-Media from Taipei App-Version" />
    <meta name="keywords" content="iApp,App,Digital+,數碼數位,iApp,iApp-Media,iMag,Web App,O2O,SoLoMo,SMO" />
    <!-- for apple (PS:iphone5 去除width=device-width)
         1.viewport符合device真正寬度,scale畫面倍率,scalable是否可縮放
         2-3.將Web Page儲存為home screen icon時的圖示
         4.設定載入頁面時 loading 圖片
         5.隱藏底部 iPhone button bar，看起來更像 iPhone App
         6.更改 status bar 樣式    
     -->
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />

    <title>mobile-profile</title>
    <link rel="stylesheet" type="text/css" href="css/reset.css" />
    <%--    <link rel="stylesheet" href="../css/reset.css" />--%>
            <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/m-profile.css" />
  
    <link rel="apple-touch-icon-precomposed" href="img/icon.png" />
    <link rel="apple-touch-icon" href="img/114.png" />
    <link rel="apple-touch-startup-image" href="startup-iphone-portrait.png" media="(device-width:320px)">
    <link rel="apple-touch-startup-image" href="startup-iphone-retina-portrait.png" media="(device-width:320px) and (-webkit-min-device-pixel-ratio: 2)">
    <link rel="apple-touch-startup-image" href="startup-iphone-5-portrait.png" media="(device-width:320px) and (device-height:568px) and (-webkit-min-device-pixel-ratio: 2)">

    <!--
    <link rel="stylesheet" href="css/add2home.css">
    <script type="application/javascript" src="js/add2home.js" charset="utf-8"></script> -->
    <!-- End Add to Home Screen -->

    <link rel="stylesheet" type="text/css" href="css/index.css?v3" />
    <link rel="stylesheet" type="text/css" href="css/slide.css?v3" />
    <link rel="stylesheet" type="text/css" href="css/action.css" />
    <link rel="stylesheet" type="text/css" href="css/processBar.css" />
    <link rel="stylesheet" type="text/css" href="css/cropper.css">
    <link rel="stylesheet" type="text/css" href="css/mobileEditor.css">
</head>
<body>
    <form id="form1" runat="server">
        <!-- mobile 頭像編輯畫面 -->

        <div class="upload-img">
            <div class="top">
                <img src="img/iapplogo.png" class="toplogo" align="left"/>
               <%-- <img src="img/cancel-1.png" class="cancel" align="right"/>--%>
                <span class="glyphicon glyphicon-remove cancel" aria-hidden="true"></span>
            </div>
            <div class="upload-page">
                <label for="inputImage">
                    <div class="select">
                        選擇照片
                    </div>
                </label>
                <div class="rotate">
                    <button data-method="rotate" type="button" class="rotate-btn">旋轉</button>
                </div>
                <div class="preview-container">
                    <img id="preview" src="" />
                </div>
                <div class="img-container">
                    <img src="" alt="支持圖片上傳格式JPG,PNG" />
                </div>
                <p class="word">(移動及縮放進行照片裁切)</p>
                <input id="CurrentId" value="" class="hide" />
                <input type="file" accept="image/*" id="inputImage" style="display: none;" />
                <button data-method="getCroppedCanvas" type="button" id="cut" class="cut" disabled="true">
                    截圖
                </button>
                <%--            <button onclick="compress()" type="button" class="send" id="sended">
                確認
            </button>--%>
                <asp:Button ID="sended" runat="server" Text="確認" CssClass="send" OnClientClick="compress()" OnClick="sended_Click" />
                <asp:TextBox ID="Tbase64" value="" runat="server" Style="display: none;"></asp:TextBox>
            </div>
        </div>
        <!-- mobile會員資料畫面 -->
        <div class="login-mobile">
            <div class="navbar">
                <img class="iapplogo" src="img/iapplogo.png">
                
            </div>
            <div class="content">
                <div class="login">
                    <p>會員資料</p>
                    <div class="bar"></div>
                    <div class="login-input">
                        <div class="logo-file">
                            <a id="show-upload" class="#" href="javascrip:void(0)" onclick="">
                                <asp:Image ID="p1" CssClass="icon" runat="server" ImageUrl="../img/headimg.png" />
                                <label id="toimg"  for="inputImage">選擇檔案</label>
                            </a>
                        </div>
                        姓名：<asp:TextBox ID="mname" runat="server" CssClass="name"></asp:TextBox>
                        電話：<asp:TextBox ID="mtel" runat="server" CssClass="tel"></asp:TextBox>
                        更改密碼：<asp:TextBox ID="mrepasswd" runat="server" CssClass="repasswd"></asp:TextBox>
                        確認密碼：<asp:TextBox ID="mckpasswd" runat="server" CssClass="ckpasswd"> </asp:TextBox>
                        <%--<asp:Button runat="server" Text="Button" ID="login-submit"></asp:Button>--%>
                        <%--                    <input type="submit" id="login-submit" style="display: none;">--%>
                        <%--                    </form>--%>
                    </div>
                </div>

                <div class="login-back">
                                        <asp:LinkButton ID="LinkButton2" runat="server"  OnClick="LinkButton2_Click">
                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> 
                    </asp:LinkButton>
<%--                    <span class="glyphicon glyphicon-remove" aria-hidden="true" onclick="window.open('http://www.iapp-media.com/portal/','_self')"></span>--%>
                </div>
                <div class="send" id="login">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span> 
                    </asp:LinkButton>
                </div>
            </div>
            <div class="footer">
            </div>

        </div>

        <%--        <script type="text/javascript" src="../js/jquery-1.11.3.min.js"></script>
        <!-- 依需要參考已編譯外掛版本（如下），或各自獨立的外掛版本 -->
        <script src="../js/bootstrap.min.js"></script>

        <script src="../js/m-login.js"></script>--%>
        <script>
            function readCookie(name) {
                var nameEQ = name + "=";
                var ca = document.cookie.split(';');
                for (var i = 0; i < ca.length; i++) {
                    var c = ca[i];
                    while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                    if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
                }
                return null;
            }
        </script>
        <script src="js/zepto.min.js"></script>
        <script src="js/touch.js"></script>
        <script src="js/index.js"></script>
        <script src="js/base.js"></script>
        <script src="js/JIC.js" type="text/javascript"></script>
        <script src="js/jquery.min.js"></script>
        <script src="js/cropper.js"></script>
        <script src="js/mobileEditor.js"></script>
        <script>
            $(document).ready(function () {
                $("#toimg").click(function () {
                    $(".login-mobile").hide();
                    $(".send").hide();
                });

                $("#inputImage").click(function () {
                    $('.preview-container').hide();
                    $('.img-container').show();
                    $(".upload-img").show();
                    $(".pages").hide();
                    $('.cut').show();
                    $('.cut').attr("disabled", true);
                    $('.rotate-btn').hide();
                });
                $(".cut").click(function () {
                    $(".cut").hide();
                    $(".send").show();

                });
                $("#sended").click(function () {
                    $(".upload-img").hide();
                    $(".login-mobile").show();

                });
                $('#inputImage').change(function () {
                    $('.preview-container').hide();
                    $('.img-container').show();
                    $('.send').hide();
                    $('.cut').show();
                    $('.rotate-btn').show();
                });
                $('.cancel').click(function () {
                    $(".upload-img").hide();
                    $(".login-mobile").show();
                });
            });
        </script>

        <script>
            document.write('<style>#loading{display:none}</style>');
        </script>

    </form>
</body>
</html>

