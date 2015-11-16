<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinAs.aspx.cs" Inherits="MiniStore.JoinAs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
       <div class="JoinBox">
            <div class="LOGO">
                <img src="img/img-1.jpg" alt="Alternate Text" />
            </div>
            <div class="Sendbox"> 
                <p>輸入您的微店店名</p>
                <asp:TextBox ID="TB_SNAME" runat="server"></asp:TextBox>
                <div>
                    <asp:Button ID="BT_SNAME" runat="server" Text="確定" CssClass="btn btn-warning sendcareButtomeEnd" OnClick="BT_SNAME_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>