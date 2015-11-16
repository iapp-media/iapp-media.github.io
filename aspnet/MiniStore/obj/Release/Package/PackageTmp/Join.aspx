<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Join.aspx.cs" Inherits="MiniStore.Join" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link href="img/iAppStore.ico" rel="shortcut icon" />
    <link rel="apple-touch-icon-precomposed" href="img/icon.png" />
    <link rel="apple-touch-icon" href="img/114.png" />
    <link rel="apple-touch-startup-image" href="startup-iphone-portrait.png" media="(device-width:320px)" />
    <link rel="apple-touch-startup-image" href="startup-iphone-retina-portrait.png" media="(device-width:320px) and (-webkit-min-device-pixel-ratio: 2)" />
    <link rel="apple-touch-startup-image" href="startup-iphone-5-portrait.png" media="(device-width:320px) and (device-height:568px) and (-webkit-min-device-pixel-ratio: 2)" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <!-- End for apple -->

    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/index.css" />
    <link rel="stylesheet" href="css/masonry.css" />
    <link rel="stylesheet" href="css/colorbox.css" />
    <link href="css/swiper.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="JoinBranchBox">
            <div class="JBBGlogo">
                <img src="img/img-1.png" alt="Alternate Text" />
            </div>
            <div class="JBBG">
                <img src="img/pcimg-2.jpg" alt="Alternate Text" />
            </div>
            <div class="JBBG1">
                <img src="img/pcimg-2-1.png" alt="Alternate Text" />
            </div>
            <div class="JBBG2">
                <img src="img/pcimg-2-2.png" alt="Alternate Text" />
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="加入" CssClass="btn btn-warning sendcareButtomeEnd" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
 