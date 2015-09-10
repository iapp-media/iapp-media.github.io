<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p01.aspx.vb" Inherits="AppWeb1._4.p01" %>

<!DOCTYPE html>
<html lang="zh-tw" class="no-js">
<head>
    <meta charset="utf-8">
    <title>iApp</title>
    <meta name="description" content="Digital+ 數碼數位 行動自媒體 iApp-Media from Taipei App-Version" />
    <meta name="keywords" content="iApp,App,Digital+,數碼數位,iApp,iApp-Media,iMag,Web App,O2O,SoLoMo,SMO" />


    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no">
    <link rel="apple-touch-icon-precomposed" href="../Apps/img/icon.png" />
    <link rel="apple-touch-icon" href="img/114.png" />
    <link rel="apple-touch-startup-image" href="startup-iphone-portrait.png" media="(device-width:320px)">
    <link rel="apple-touch-startup-image" href="startup-iphone-retina-portrait.png" media="(device-width:320px) and (-webkit-min-device-pixel-ratio: 2)">
    <link rel="apple-touch-startup-image" href="startup-iphone-5-portrait.png" media="(device-width:320px) and (device-height:568px) and (-webkit-min-device-pixel-ratio: 2)">

    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />

    <link rel="stylesheet" type="text/css" href="../Apps/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../Apps/css/index.css" />
    <link rel="stylesheet" type="text/css" href="../Apps/css/slide.css?v3" />
    <link rel="stylesheet" type="text/css" href="../Apps/css/action.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="border:2px solid red;">
            <div class="page page-2-1 page-current">
                <a id="show-upload" onclick="goValue(1)" class='#' href="javascrip:void(0)">
                    <asp:Literal ID="L" runat="server"></asp:Literal>
                </a>
                <img class="up moveIconUp" src="../Apps/img/icon_up.png" />
            </div>
        </div>
    </form>
    <script src="../js/edit.js"></script>
    <script src="../Apps/js/zepto.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="../js/jquery.url.js"></script>
</body>
</html>
