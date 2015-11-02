﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maker.aspx.cs" Inherits="Wedding.Maker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <title>婚禮 iApp</title>
    <!-- about SEO -->
    <meta name="description" content="行動哈雷iApp Digital+ 數碼數位 行動自媒體 iApp-Media from Taipei App-Version" />
    <meta name="keywords" content="行動哈雷iApp,活動報名,iApp,App,Digital+,數碼數位,iApp,iApp-Media,iMag,Web App,O2O,SoLoMo,SMO" />
    <!-- for apple (PS:iphone5 去除width=device-width)
         1.viewport符合device真正寬度,scale畫面倍率,scalable是否可縮放
         2-3.將Web Page儲存為home screen icon時的圖示
         4.設定載入頁面時 loading 圖片
         5.隱藏底部 iPhone button bar，看起來更像 iPhone App
         6.更改 status bar 樣式    
     -->
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <link rel="apple-touch-icon-precomposed" href="img/icon.png" />
    <link rel="apple-touch-icon" href="img/114.png" />
    <link rel="apple-touch-startup-image" href="startup-iphone-portrait.png" media="(device-width:320px)"/>
    <link rel="apple-touch-startup-image" href="startup-iphone-retina-portrait.png" media="(device-width:320px) and (-webkit-min-device-pixel-ratio: 2)"/>
    <link rel="apple-touch-startup-image" href="startup-iphone-5-portrait.png" media="(device-width:320px) and (device-height:568px) and (-webkit-min-device-pixel-ratio: 2)"/>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <!-- End for apple -->
    <!-- Add to Home Screen -->
    <!--
    <link rel="stylesheet" href="css/add2home.css">
    <script type="application/javascript" src="js/add2home.js" charset="utf-8"></script>    
    <!-- End Add to Home Screen -->
    <link rel="stylesheet" type="text/css" href="css/reset.css" />
    <link rel="stylesheet" type="text/css" href="css/maker.css" />
    <link rel="stylesheet" type="text/css" href="css/slide.css?v2" />
    <link rel="stylesheet" type="text/css" href="css/action.css" />
    <link rel="stylesheet" type="text/css" href="css/animate.css"/>
    <link rel="stylesheet" href="css/colorbox.css"/>
    <link rel="stylesheet" href="css/jquery.flipster.css"/>
    <link rel="stylesheet" href="css/demo.css"/>
    <link rel="stylesheet" href="css/flipsternavtabs.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="loading">iApp 載入中</div>
    <div class="allMove" id="allMove">
        <a href="#" class="sandwich">
        </a>
        <ul class="menu" id="menu">
            <li>
                <a href="#" class="liColor">
                    <p>創建喜帖</p>
                </a>
            </li>
            <li id="jump2"><a>赴宴名冊</a></li>
            <li class="Blessing"><a>朋友的祝福</a></li>
            <li><a>婚禮 iApp</a></li>
            <li><a>婚禮 微創作</a></li>
            <li><img src="img/qr-code-harley.jpg" alt="" class="QRcode">
                <a href="http://line.naver.jp/R/msg/text/?http://www.iapp-media.net/harley/">
                    <img src="img/lineicon.png" alt="用LINE傳送" class="line" />
                </a>
            </li>
        </ul>
    </div>
    <!-- 三明治 end -->
    <!-- Page1 -->
    <div class="page page-1-1 page-current">
        <div class="time">
            <p>民國<span>104</span>年</p>
            <p>國曆<span>3/15</span></p>
            <p>農曆<span>1/25</span></p>
        </div>
        <div class="page1Title">
            <div>葉大雄</div>
            <div id="heart"></div>
            <div>源靜香</div>
        </div>
        <div class="Protagonist">
            <img src="img/p1-photo.jpg" alt="">
        </div>
        <div class="inside">
            <div>
                <label for="">席設 :</label>
                <input type="text" value="台北君悅酒店">
            </div>
            <div>
                <label for="">地點 :</label>
                <input type="text" value="台北市地球村">
                <img src="img/p1-location.png" class="location" alt="">
            </div>
            <div>
                <label for="">電話 :</label>
                <input type="text" value="(02) 1234567">
                <img src="img/p1-callphone.png" class="callphone" alt="">
            </div>
            <div>
                <label for="">時間 :</label>
                <input type="text" value="中午十二時入場">
            </div>
            <button class="carewed">我要赴宴</button>
        </div>
    </div>
    <!-- Page1 end -->
    <!-- Page2 -->
    <div class="page page-2-1  hide">
        <ul class="Page2index">
            <li class="animated fadeInDown">
                <input type="text" value="一個意外  讓我們  相遇">
                <input type="text" value="一場大雨  讓我們  相知">
            </li>
        </ul>
        <div class="page2pic"><img src="img/p2-photo2.jpg" alt=""></div>
        <div class="page2pic2"><img src="img/p2-photo1.jpg" alt="" onclick=""/></div>
        <img class="up moveIconUp" src="img/icon_up.png" />
    </div>
    <!-- Page2 end -->
    <!-- Page3 -->
    <div class="page page-3-1 hide">
        <ul class="Page3index">
            <li class="animated fadeInDown">
                <input type="text" value="習慣了妳的聲音、妳的氣味、妳的存在...">
                <input type="text" value="連思念都成了習慣">
            </li>
        </ul>
        <ul class="display-animation Page3Insidepic">
            <li><img src="img/p3-photo1.jpg" alt=""></li>
            <li><img src="img/p3-photo2.jpg" alt=""></li>
            <li><img src="img/p3-photo3.jpg" alt=""></li>
            <li><img src="img/p3-photo4.jpg" alt=""></li>
            <li><img src="img/p3-photo5.jpg" alt=""></li>
        </ul>
        <ul class="Page3indexBot">
            <li class="animated fadeInDown">
                <input type="text" value="終於  我牽起你的手">
                <input type="text" value="那一天起  就決定再也不放開">
            </li>
        </ul>
        <img class="up moveIconUp" src="img/icon_up.png" />
    </div>
    <!-- Page3 end -->
    <!-- Page4 -->
    <div class="page page-4-1 hide">
        <ul class="Page4Top">
            <li class="animated fadeInDown">
                <input type="text" value="妳使我的生命得到豐富">
                <input type="text" value="妳照亮了前方的迷霧">
                <input type="text" value="牽著妳的手我更清楚">
                <input type="text" value="相知與相惜">
            </li>
        </ul>
        <ul class="weddinghand">
            <li><img src="img/p4-ani01.png" alt=""></li>
            <li><img src="img/p4-ani02.png" alt=""></li>
            <li><img src="img/p4-ani03.png" alt=""></li>
        </ul>
        <ul class="Page4Bot">
            <li class="animated fadeInDown">
                <input type="text" value="『我們結婚吧』">
                <input type="text" value="Yes I do">
            </li>
        </ul>
        <img class="up moveIconUp" src="img/icon_up.png" />
    </div>
    <!-- Page4 end -->
    <!-- Page5 -->
    <div class="page page-5-1 flipster hide">
        <ul>
            <li>
                <a href="#" class="Button Block">
                    <img src="img/p5-photo1.jpg" alt="">
                </a>
            </li>
            <li>
                <a href="#" class="Button Block">
                    <img src="img/p5-photo1.jpg" alt="">
                </a>
            </li>
            <li>
                <a href="#" class="Button Block">
                    <img src="img/p5-photo1.jpg" alt="">
                </a>
            </li>
            <li>
                <a href="#" class="Button Block">
                    <img src="img/p5-photo1.jpg" alt="">
                </a>
            </li>
            <li>
                <a href="#" class="Button Block">
                    <img src="img/p5-photo1.jpg" alt="">
                </a>
            </li>
            <li>
                <a href="#" class="Button Block">
                    <img src="img/p5-photo1.jpg" alt="">
                </a>
            </li>
        </ul>
        <img class="up moveIconUp" src="img/icon_up.png" />
    </div>
    <!-- Page5 end -->
    <!-- Page6 -->
    <div class="page page-6-1 hide">
        <div class="wrap">
            <img class="up animated moveIconUp" src="img/icon_up.png" />
            <iframe class="map" name="iframemap" src="map.html"></iframe>
            <a href="javascript: return false;" onclick="iframemap.window.location.reload()" class="button"><img src="img/reflash.png" border="0" onclick="this.src=='http://tkining.bitbucket.org/iwedding/img/reflash.png'?this.src='http://tkining.bitbucket.org/iwedding/img/reflash.png':this.src='http://tkining.bitbucket.org/iwedding/img/reflash2.png'"></a>
        </div>
        <h1>交通資訊</h1>
        <div>
            <label for="">公車 :</label>
            <textarea rows="2" cols="3">搭台北聯營公車20.202.207.258.282.284.信義 幹線等路，在世貿下車可抵達君悅大飯店。
            </textarea>
        </div>
        <div class="Carmargin">
            <label for="">開車 :</label>
            <textarea rows="5" cols="3">1.下圓山(松江路)交流道，循建國高架橋南行， 於信義路出口下，轉信義路東行，再左轉基隆路可抵達君悅大飯店 2.北二高台北聯絡道，延辛亥路右轉基隆路行約3公里可抵達
            </textarea>
        </div>
    </div>
    <!-- Page6 end -->
    <!-- Page7 -->
    <div class="page page-7-1 hide">
        <ul class="page7pic">
            <li><img src="img/p7-pic.png" alt=""></li>
            <li><img src="img/p7-qr.jpg" alt=""></li>
            <li><img src="img/p7-create.png" alt=""></li>
            <li><img src="img/p7-share.png" alt=""></li>
        </ul>
    </div>
    <!-- Page7 end -->
    </form>
    <script src="js/zepto.min.js"></script>
    <script src="js/touch.js"></script>
    <script src="js/index.js"></script>
    <script src="js/jquery.mobile-1.4.5.min.js"></script>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/snap.js"></script>
    <script src="js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="js/jquery.colorbox-min.js"></script>
    <script src="js/custom.js"></script>
    <script src="js/jquery.flipster.js"></script>
    <script type="text/javascript" src="js/velocity.min.js"></script>
    <!--行動哈雷iApp GA -->
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

        ga('create', 'UA-62535634-5', 'auto');
        ga('send', 'pageview');
    </script>
    <script>
        document.write('<style>#loading{display:none}</style>');
    </script>
</body>
</html>
