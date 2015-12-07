<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="portal.aspx.cs" Inherits="AppPortal.portal" EnableViewState="false" %>

<!DOCTYPE html>
<html lang="tw">
<head> 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no">
    <link href="img/favicon.ico" rel="shortcut icon" />
    <meta name="description" content="Digital+ 數碼數位 行動自媒體 iApp-Media from Taipei App-Version" />
    <meta name="keywords" content="iApp,App,Digital+,數碼數位,iApp,iApp-Media,iMag,Web App,O2O,SoLoMo,SMO" />
    <title>iApp Platform</title>
    <link rel="apple-touch-icon-precomposed" href="img/icon.png" />
    <link rel="apple-touch-icon" href="img/114.png" />
    <link rel="apple-touch-startup-image" href="startup-iphone-portrait.png" media="(device-width:320px)">
    <link rel="apple-touch-startup-image" href="startup-iphone-retina-portrait.png" media="(device-width:320px) and (-webkit-min-device-pixel-ratio: 2)">
    <link rel="apple-touch-startup-image" href="startup-iphone-5-portrait.png" media="(device-width:320px) and (device-height:568px) and (-webkit-min-device-pixel-ratio: 2)">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/colorbox.css">
    <!-- 依照不同瀏覽器加上前綴字 -->
    <%--<script src="js/prefixfree.min.js"></script>--%>
    <link rel="stylesheet" href="css/masonry.css">
    <link rel="stylesheet" href="css/index.css">
    <!-- HTML5 shim and Respond.js 讓 IE8 支援 HTML5 元素與媒體查詢 -->
    <!-- 警告：Respond.js 無法在 file:// 協定下運作 -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body data-spy="scroll" data-target=".bs-docs-sidebar">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="row">
                <div class="container-fluid">
                    <a class="iapplogo" href="portal.aspx">
                        <img src="img/iapplogo.png" alt="">
                    </a>

                    <!-- 會員資料選單（PC） -->
                    <div>
                        <ul class="dropdown-menu dropdown-menu-right theme" role="menu">
                            <asp:Literal ID="ThemeLi" runat="server"></asp:Literal>
                        </ul>
                    </div>
                    <!-- 會員資料選單（mobile） -->
                    <div class="mobileProfileall">
                        <div class="smallpro"></div>
                        <ul class="mobileProfile">
                            <li><a href="javascript:__doPostBack('LBmyw','')">我的iApp</a></li>
                            <li><a href="#">收藏的iApp</a></li>
                            <li><a href="#">編輯個人資料</a></li>
                            <li><a class="btn btn-warning LogOutBTN" href="javascript:__doPostBack('LBLogout','')">登出</a></li>
                        </ul>
                    </div>
                    <!--  搜尋bar提示框（共用）-->
                    <div id="listbox">
                        <%--       <ul class="dropdown-menu dropdown-menu-right finder" role="menu">
                        <li><a href="#">最新</a></li>
                        <li class="divider"></li>
                        <li><a href="#">最熱門</a></li>
                        <li class="divider"></li>
                        <li><a href="#"><img class="finder-app" src="img/photoicon.png"
                        > iApp</a></li>
                    </ul>--%>
                    </div>

                    

                    <div class="search-sm">
                        <div class="input-group">
                            <!-- mobile 搜尋 -->
                            <div class="input-group-btn">
                                <button type="button" id="op-search" class="btn btn-default search2" data-toggle="dropdown" aria-expanded="false">
                                    <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                </button>
                            </div>
                        </div>
                    </div>
                    <!-- mobile 搜尋bar -->
                    <div class="search-bar">
                        <div class="container">
                        <asp:TextBox ID="mSearch" CssClass="search bar-text" runat="server"></asp:TextBox>
                        <!--<input type="text" class="search bar-text" placeholder="Search iApp..." id="mSearch"> -->
                        <span class="glyphicon glyphicon-remove cancel" aria-hidden="true" />
                            </div>
                    </div>

                    <div class="login-sm">
                        <div class="input-group">
                            <div class="input-group-btn">
                                <asp:Literal ID="MLogin" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <!-- Web 搜尋bar -->
                    <div class="BarSear">
                        <div class="input-group search">
                            <!-- 搜尋框 -->
                            <%-- <input type="text" class="form-control " placeholder="Search iApp...">--%>
                            <asp:TextBox ID="Search" CssClass="form-control bar-text" runat="server"></asp:TextBox>
                            <%--<input type="text" id="Search" class="form-control bar-text" placeholder="Search iApp...">--%>
                            <!-- 下拉按鈕 -->
                            <div class="input-group-btn">
                                <button type="button" class="dropdown-toggle select" data-toggle="dropdown" aria-expanded="false">
                                    <span class="glyphicon glyphicon-menu-hamburger sandwich" aria-hidden="true"></span>
                                </button>
                            </div>
                            <!-- /btn-group -->
                        </div>
                        <!-- /input-group -->
                    </div>


                    <!-- 登入／註冊 -->
                    <asp:Literal ID="LLogin" runat="server"></asp:Literal>
                    <!-- 微創作 -->
                    <div class="PortalCreat">
                        <asp:Literal ID="LDoIt" runat="server"></asp:Literal>
                    </div>

                </div>
                <!-- /.col-lg-6 -->
            </div>
        </nav>
        <div class="clearfix"></div>
        
    <!-- 會員資料 -->
    <div class="jumbotron">
        <asp:Image ID="ImgUser2" runat="server" CssClass="user-icon" ImageUrl="img/photoicon.png" />
        <!--<img class="user-icon" src="img/photoicon.png">-->
        <asp:Panel ID="Panel1" runat="server" CssClass="option-user" Visible="true">
            <asp:LinkButton ID="LBmyw" runat="server" OnClick="LBmym_Click">
                我的iApp
            </asp:LinkButton>
            <asp:LinkButton ID="LBfvw" runat="server" OnClick="LBfvm_Click">     
                收藏的iApp
            </asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="logout-user" Visible="true">
            <a href="#"><span class="glyphicon glyphicon-cog" aria-hidden="true"></span></a>
            <ul class="dropdown-menu dropdown-menu-right logout" role="menu">
            <%--    <li><a class='iframe-info' href="http://www.iapp-media.com/Login/profile.aspx">會員資料</a></li>--%>
                    <li><a  href="http://www.iapp-media.com/Login/profile.aspx">會員資料</a></li>
                <li class="divider"></li>
                <li id="logout">
                    <asp:LinkButton ID="LBLogout" runat="server" OnClick="LBLogout_Click">登出</asp:LinkButton>
                </li>
            </ul>
        </asp:Panel>
    </div>
    <!-- 回到頂部 -->
    <a href="#">
        <img class="back-top" src="img/top.png" /></a>
        <!-- 瀑布流 -->
        <div id="container">
            <asp:Literal ID="Tile1" runat="server"></asp:Literal>
            <asp:Literal ID="L" runat="server"></asp:Literal>
        </div>

        <div class='nav clearbox'>
        <asp:Literal ID="LMore" runat="server"></asp:Literal>
        <asp:HyperLink ID="HL1" runat="server"></asp:HyperLink> 
    </div>
    </form>


    <!-- jQuery (Bootstrap 所有外掛均需要使用) -->
    <!-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js">
    </script> -->
    <!-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script> -->
    <script type="text/javascript" src="js/jquery-1.8.0.min.js"></script>

    <!-- 依需要參考已編譯外掛版本（如下），或各自獨立的外掛版本 -->
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.masonry.min.js"></script>
    <script type="text/javascript" src="js/jquery.infinitescroll.min.js"></script>
    <script type="text/javascript" src="js/jquery.colorbox-min.js"></script>
    <script type="text/javascript" src="js/act.js"></script>
    <script type="text/javascript" src="js/velocity.min.js"></script>

   
    <asp:Literal ID="JSS" runat="server"></asp:Literal>
</body>

</html>
