<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Maker.aspx.vb" Inherits="AppWeb1._4.Maker" %>
<!DOCTYPE html>
<html lang="zh-tw" class="no-js">

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>iApp Mobile Maker</title>
    <!-- about SEO -->
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
    <link rel="apple-touch-icon-precomposed" href="img/icon.png" />
    <link rel="apple-touch-icon" href="img/114.png" />
    <link rel="apple-touch-startup-image" href="startup-iphone-portrait.png" media="(device-width:320px)">
    <link rel="apple-touch-startup-image" href="startup-iphone-retina-portrait.png" media="(device-width:320px) and (-webkit-min-device-pixel-ratio: 2)">
    <link rel="apple-touch-startup-image" href="startup-iphone-5-portrait.png" media="(device-width:320px) and (device-height:568px) and (-webkit-min-device-pixel-ratio: 2)">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <!-- End for apple -->
    <!-- Add to Home Screen -->
    <!--
    <link rel="stylesheet" href="css/add2home.css">
    <script type="application/javascript" src="js/add2home.js" charset="utf-8"></script> -->
    <!-- End Add to Home Screen -->
    <link rel="stylesheet" type="text/css" href="css/reset.css" />
    <link rel="stylesheet" type="text/css" href="css/index.css?v3" />
    <link rel="stylesheet" type="text/css" href="css/slide.css?v3" />
    <link rel="stylesheet" type="text/css" href="css/action.css" />
    <link rel="stylesheet" type="text/css" href="css/processBar.css" />
    <!-- <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"> -->
    <link rel="stylesheet" type="text/css" href="css/cropper.css">
    <link rel="stylesheet" type="text/css" href="css/mobileEditor.css">
    <script src="js/exif.js"></script>
    <!--    <link rel="stylesheet" type="text/css" href="css/animate.css"/>
-->
</head>
<body>
    <form id="form1" runat="server" style="height: 100%">
    <div id="loading">iApp 載入中</div>
    <div id="uploading">
        <img src="img/ajax-loader.gif">
    </div>
    <div class="upload-img">
        <div class="top">
            <img src="img/iapplogo.png" class="toplogo" align="left">
            <img src="img/cancel-01.png" class="cancel" align="right">
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
            <div class="preview-container hide">
                <img id="preview" src="">
            </div>
            <div class="img-container">
                <img src="" alt="支持圖片上傳格式JPG,PNG">
            </div>
            <p class="word">(移動及縮放進行照片裁切)</p>
            <input id="CurrentId" value="" class="hide">
            <input type="file" accept="image/*" id="inputImage" style="display:none;">
            <button data-method="getCroppedCanvas" type="button" id="cut" class="cut" disabled="true">
                截圖
            </button>
            <button onclick="compress()" type="button" class="send" id="sended">
                確認
            </button>
            <input id="Tbase64" value="" style="display:none;">
        </div>
    </div>
        
    <div id="pages" class="pages">
        <div class="page page-1-1 page-current">
            <img class="up moveIconUp" src="img/icon_up.png" />
            <img class="logo animated bounceInDownrubberBand" src="img/logo.png" />
        </div>
        
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>


            <div class="bg"></div>
            <img class="logo2 animated bounce" src="img/logo2.png" />
            <!--<img class="qr animated fadeIn" src="img/qr.jpg" />-->
            <div class="lasttextbox">
                <br>
                <p class="text4 animated fadeIn" style="color: white">[發佈公告]</p>
                <br>
                <p class="text5 animated fadeIn" style="color: white">為尊重圖像版權，敬請全面更換圖片！ 為您的iApp填加<a class="text_color">色彩</a>。
                </p>
                <br>
                <br>
            </div>
            <asp:Literal ID="LPreview" runat="server"></asp:Literal>
            <asp:ImageButton ID="IBSend" runat="server" ImageUrl="img/send-1.png" CssClass="create animated pulse" />
            <!--<input type="image" onclick="alert('1')" class="share animated pulse" src="img/preview-1.png" />-->
            <!--img class="share animated pulse" src="img/preview-1.png" /-->
            <asp:Literal ID="LSet" runat="server"></asp:Literal>
            <!--  <input type="image" onclick="Send();" class="create animated pulse" src="img/send-1.png" /> -->
            <p class="text6 animated fadeIn">iApp 由 Digital+ 數碼數位 支持創作
            </p>
        </div>
    </div>
        <asp:HiddenField ID="MaxNum" runat="server" />
        <asp:HiddenField ID="IIDs" runat="server" />
    </form>
    <script src="js/zepto.min.js"></script>
    <script src="js/touch.js"></script>
    <script src="js/index.js"></script>
    <script src="js/base.js"></script>
    <script src="js/share.js"></script>
    <script src="http://www.parsecdn.com/js/parse-1.5.0.min.js"></script>
    <script src="js/JIC.js" type="text/javascript"></script>
    <!-- // <script src="js/maker.js"></script> -->
    <script src="js/jquery.min.js"></script>
    <!-- // <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script> -->
    <script src="js/toParse.js"></script>
    <script src="js/cropper.js"></script>
    <script src="js/mobileEditor.js"></script>
    <script>
        $(document).ready(function () {
            $("#inputImage").click(function () {
                $('.preview-container').hide();
                $('.img-container').show();
                $(".upload-img").show();
                $(".pages").hide();
                $('.send').hide();
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
                $(".pages").show();

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
                $(".pages").show();
            });
        });
    </script>
    <!--<script>
        var share_button_right = new Share(".share-button-bottom", {
            ui: {
                flyout: "bottom left",
                button_text: ""
            },
            networks: {
                facebook: {
                    app_id: "12345",
                }
            }
        });
    </script>-->
    <!-- Google Analytics 分析 -->
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r;
            i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date();
            a = s.createElement(o),
                m = s.getElementsByTagName(o)[0];
            a.async = 1;
            a.src = g;
            m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-62535634-4', 'auto');
        ga('send', 'pageview');
    </script>
    <script>
        document.write('<style>#loading{display:none}</style>');
    </script>
</body>
</html>