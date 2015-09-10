<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p05.aspx.vb" Inherits="AppWeb1._4.p05" %>

<!DOCTYPE html>
<html lang="zh-tw" class="no-js">
<head>
    <meta charset="utf-8">
    <title>iApp</title>
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
	<script type="application/javascript" src="js/add2home.js" charset="utf-8"></script>    
    <!-- End Add to Home Screen -->
    <link rel="stylesheet" type="text/css" href="../Apps/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../Apps/css/index.css" />
    <link rel="stylesheet" type="text/css" href="../Apps/css/slide.css?v3" />
    <link rel="stylesheet" type="text/css" href="../Apps/css/action.css" />

    <!-- 	<link rel="stylesheet" type="text/css" href="css/animate.css"/>
 -->
</head>
<body style="margin: 0; background-color: white;">
    <form id="form1" runat="server">
        <div>

            <div class="page page-6-1 page-current">
                <asp:Literal ID="L" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
    <script src="../js/edit.js"></script>
    <script src="../Apps/js/zepto.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="../js/jquery.url.js"></script>
</body>
</html>
