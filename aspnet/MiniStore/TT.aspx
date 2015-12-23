<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TT.aspx.cs" Inherits="MiniStore.TT" %>







<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>iApp微店
    </title>
    <!-- about SEO -->
    <meta name="description" content="Digital+ 數碼數位 行動自媒體 iApp-Media from Taipei App-Version" />
    <meta name="keywords" content="iApp mini store,iApp Social,iApp,App,Digital+,數碼數位,iApp,iApp-Media,iMag,Web App,O2O,SoLoMo,SMO" />
    <!-- FB -->
    <meta property="og:url" content="http://www.iapp-media.net/ilife/" />
    <!-- for apple (PS:iphone5 去除width=device-width)
         1.viewport符合device真正寬度,scale畫面倍率,scalable是否可縮放
         2-3.將Web Page儲存為home screen icon時的圖示
         4.設定載入頁面時 loading 圖片
         5.隱藏底部 iPhone button bar，看起來更像 iPhone App
         6.更改 status bar 樣式    
     -->
    <!--<meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no" />-->
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link href="img/iAppStore.ico" rel="shortcut icon" />
    <link rel="apple-touch-icon-precomposed" href="img/icon.png" />
    <link rel="apple-touch-icon" href="img/114.png" />
    <link rel="apple-touch-startup-image" href="startup-iphone-portrait.png" media="(device-width:320px)" />
    <link rel="apple-touch-startup-image" href="startup-iphone-retina-portrait.png" media="(device-width:320px) and (-webkit-min-device-pixel-ratio: 2)" />
    <link rel="apple-touch-startup-image" href="startup-iphone-5-portrait.png" media="(device-width:320px) and (device-height:568px) and (-webkit-min-device-pixel-ratio: 2)" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <!-- End for apple -->
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/masonry.css" />
    <link rel="stylesheet" href="css/colorbox.css" />
    <link href="css/swiper.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/index.css" />
    <!-- HTML5 shim and Respond.js 讓 IE8 支援 HTML5 元素與媒體查詢 -->
    <!-- 警告：Respond.js 無法在 file:// 協定下運作 -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <style>
        input[type=number] {
            -moz-appearance: textfield;
        }

            input[type=number]::-webkit-inner-spin-button,
            input[type=number]::-webkit-outer-spin-button {
                -webkit-appearance: none;
                margin: 0;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="aspNetHidden">
            <input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
            <input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
            <input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="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U2l6ZSBpbWdIIiBzcmM9J0l0ZW1waWMvMDEvMDAwMDAwNzA0NTAxLmpwZycvPjwvYT4KDSAgICAgICAgICAgIDwvZGl2PgoNICAgICAgICAgICAgPGRpdiBjbGFzcz0iRGV0YWlsc21pZCI+Cg0gICAgICAgICAgICAgICAgPGgzPm5pa2Xnt6jnuZTpnoso54GwKTwvaDM+Cg0gICAgICAgICAgICAgICAgPGRpdiBjbGFzcz0iTW9uQm94TCI+Cg0gICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSJUT0MiPiQ1OTk8L3NwYW4+Cg0gICAgICAgICAgICAgICAgPC9kaXY+Cg08ZGl2IGNsYXNzPSJNb25Cb3hSIj4gICAgICAgICAgICAgICAgPHNwYW4gY2xhc3M9ImlucHV0LW51bWJlci1kZWNyZW1lbnQiIG9uY2xpY2s9J21pbnVzKDcwNDUpJz7igJM8L3NwYW4+Cg0gICAgICAgICAgICAgICAgPGlucHV0IGlkPSJOdW1fNzA0NSIgbmFtZT0iIiB0eXBlPSJudW1iZXIiIHZhbHVlPSIwIiBjbGFzcz0iaW5wdXQtbnVtYmVyIiAgZGlzYWJsZWQ9ImRpc2FibGVkIi8+Cg0gICAgICAgICAgICAgICAgPHNwYW4gY2xhc3M9ImlucHV0LW51bWJlci1pbmNyZW1lbnQiIG9uY2xpY2s9J3BsdXMoNzA0NSw5OTk5KSc+KyA8L3NwYW4+Cg08L2Rpdj4gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgPC9kaXY+IAoNICAgICAgICA8ZGl2IGNsYXNzPSJkZXRhaWxzIGNvbC14cy0xMiI+Cg0gICAgICAgICAgICA8ZGl2IGNsYXNzPSJEVGltZyI+Cg08YSBocmVmPSdCdXlfZGV0YWlsLmFzcHg/ZW50cnk9NzA0NyZTTj1PZmZpY0FDQyc+Cg0gICAgICAgICAgICAgICAgPGltZyBjbGFzcz0icHJvZHVjdFNpemUgaW1nSCIgc3JjPSdJdGVtcGljLzAxLzAwMDAwMDcwNDcwMS5qcGcnLz48L2E+Cg0gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgICAgIDxkaXYgY2xhc3M9IkRldGFpbHNtaWQiPgoNICAgICAgICAgICAgICAgIDxoMz7mpbXoh7Tlpb3mhJ/lpI/ml6XntJvoibLnhKHljbDns7vliJfmo5LnkIPluL08L2gzPgoNICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9Ik1vbkJveEwiPgoNICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0iVE9DIj4kNDU2PC9zcGFuPgoNICAgICAgICAgICAgICAgIDwvZGl2PgoNPGRpdiBjbGFzcz0iTW9uQm94UiI+ICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSJpbnB1dC1udW1iZXItZGVjcmVtZW50IiBvbmNsaWNrPSdtaW51cyg3MDQ3KSc+4oCTPC9zcGFuPgoNICAgICAgICAgICAgICAgIDxpbnB1dCBpZD0iTnVtXzcwNDciIG5hbWU9IiIgdHlwZT0ibnVtYmVyIiB2YWx1ZT0iMCIgY2xhc3M9ImlucHV0LW51bWJlciIgIGRpc2FibGVkPSJkaXNhYmxlZCIvPgoNICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSJpbnB1dC1udW1iZXItaW5jcmVtZW50IiBvbmNsaWNrPSdwbHVzKDcwNDcsMTIzKSc+KyA8L3NwYW4+Cg08L2Rpdj4gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgPC9kaXY+IAoNICAgICAgICA8ZGl2IGNsYXNzPSJkZXRhaWxzIGNvbC14cy0xMiI+Cg0gICAgICAgICAgICA8ZGl2IGNsYXNzPSJEVGltZyI+Cg08YSBocmVmPSdCdXlfZGV0YWlsLmFzcHg/ZW50cnk9NzA0NiZTTj1PZmZpY0FDQyc+Cg0gICAgICAgICAgICAgICAgPGltZyBjbGFzcz0icHJvZHVjdFNpemUgaW1nSCIgc3JjPSdJdGVtcGljLzAxLzAwMDAwMDcwNDYwMS5qcGcnLz48L2E+Cg0gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgICAgIDxkaXYgY2xhc3M9IkRldGFpbHNtaWQiPgoNICAgICAgICAgICAgICAgIDxoMz7mrZDnvo7poqjmi7zmjqXoqK3oqIjoiJLpgankvJHplpLnuK7lj6PopLI8L2gzPgoNICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9Ik1vbkJveEwiPgoNICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0iVE9DIj4kMTIzPC9zcGFuPgoNICAgICAgICAgICAgICAgIDwvZGl2PgoNPGRpdiBjbGFzcz0iTW9uQm94UiI+ICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSJpbnB1dC1udW1iZXItZGVjcmVtZW50IiBvbmNsaWNrPSdtaW51cyg3MDQ2KSc+4oCTPC9zcGFuPgoNICAgICAgICAgICAgICAgIDxpbnB1dCBpZD0iTnVtXzcwNDYiIG5hbWU9IiIgdHlwZT0ibnVtYmVyIiB2YWx1ZT0iMCIgY2xhc3M9ImlucHV0LW51bWJlciIgIGRpc2FibGVkPSJkaXNhYmxlZCIvPgoNICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSJpbnB1dC1udW1iZXItaW5jcmVtZW50IiBvbmNsaWNrPSdwbHVzKDcwNDYsMTIzMTIzKSc+KyA8L3NwYW4+Cg08L2Rpdj4gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgPC9kaXY+IAoNICAgICAgICA8ZGl2IGNsYXNzPSJkZXRhaWxzIGNvbC14cy0xMiI+Cg0gICAgICAgICAgICA8ZGl2IGNsYXNzPSJEVGltZyI+Cg08YSBocmVmPSdCdXlfZGV0YWlsLmFzcHg/ZW50cnk9NzA0OCZTTj1PZmZpY0FDQyc+Cg0gICAgICAgICAgICAgICAgPGltZyBjbGFzcz0icHJvZHVjdFNpemUgaW1nSCIgc3JjPSdJdGVtcGljLzAxLzAwMDAwMDcwNDgwMS5qcGcnLz48L2E+Cg0gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgICAgIDxkaXYgY2xhc3M9IkRldGFpbHNtaWQiPgoNICAgICAgICAgICAgICAgIDxoMz42TU3pm5noibJUUEXpgYvli5Xloooo5Yqg6ZW354mIKTwvaDM+Cg0gICAgICAgICAgICAgICAgPGRpdiBjbGFzcz0iTW9uQm94TCI+Cg0gICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSJUT0MiPiQ1OTk8L3NwYW4+Cg0gICAgICAgICAgICAgICAgPC9kaXY+Cg08ZGl2IGNsYXNzPSJNb25Cb3hSIj4gICAgICAgICAgICAgICAgPHNwYW4gY2xhc3M9ImlucHV0LW51bWJlci1kZWNyZW1lbnQiIG9uY2xpY2s9J21pbnVzKDcwNDgpJz7igJM8L3NwYW4+Cg0gICAgICAgICAgICAgICAgPGlucHV0IGlkPSJOdW1fNzA0OCIgbmFtZT0iIiB0eXBlPSJudW1iZXIiIHZhbHVlPSIwIiBjbGFzcz0iaW5wdXQtbnVtYmVyIiAgZGlzYWJsZWQ9ImRpc2FibGVkIi8+Cg0gICAgICAgICAgICAgICAgPHNwYW4gY2xhc3M9ImlucHV0LW51bWJlci1pbmNyZW1lbnQiIG9uY2xpY2s9J3BsdXMoNzA0OCw5OTkpJz4rIDwvc3Bhbj4KDTwvZGl2PiAgICAgICAgICAgIDwvZGl2PgoNICAgICAgICA8L2Rpdj4gCg0gICAgICAgIDxkaXYgY2xhc3M9ImRldGFpbHMgY29sLXhzLTEyIj4KDSAgICAgICAgICAgIDxkaXYgY2xhc3M9IkRUaW1nIj4KDTxhIGhyZWY9J0J1eV9kZXRhaWwuYXNweD9lbnRyeT03MDQ5JlNOPU9mZmljQUNDJz4KDSAgICAgICAgICAgICAgICA8aW1nIGNsYXNzPSJwcm9kdWN0U2l6ZSBpbWdIIiBzcmM9J0l0ZW1waWMvMDEvMDAwMDAwNzA0OTAxLmpwZycvPjwvYT4KDSAgICAgICAgICAgIDwvZGl2PgoNICAgICAgICAgICAgPGRpdiBjbGFzcz0iRGV0YWlsc21pZCI+Cg0gICAgICAgICAgICAgICAgPGgzPldEIE15IENsb3VkIE1pcnJvciA0VEIoMlRCeDIpIOmbsuerr+WEsuWtmOezu+e1sTwvaDM+Cg0gICAgICAgICAgICAgICAgPGRpdiBjbGFzcz0iTW9uQm94TCI+Cg0gICAgICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSJUT0MiPiQ5LDg5MDwvc3Bhbj4KDSAgICAgICAgICAgICAgICA8L2Rpdj4KDTxkaXYgY2xhc3M9Ik1vbkJveFIiPiAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0iaW5wdXQtbnVtYmVyLWRlY3JlbWVudCIgb25jbGljaz0nbWludXMoNzA0OSknPuKAkzwvc3Bhbj4KDSAgICAgICAgICAgICAgICA8aW5wdXQgaWQ9Ik51bV83MDQ5IiBuYW1lPSIiIHR5cGU9Im51bWJlciIgdmFsdWU9IjAiIGNsYXNzPSJpbnB1dC1udW1iZXIiICBkaXNhYmxlZD0iZGlzYWJsZWQiLz4KDSAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0iaW5wdXQtbnVtYmVyLWluY3JlbWVudCIgb25jbGljaz0ncGx1cyg3MDQ5LDk5KSc+KyA8L3NwYW4+Cg08L2Rpdj4gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgPC9kaXY+IAoNICAgICAgICA8ZGl2IGNsYXNzPSJkZXRhaWxzIGNvbC14cy0xMiI+Cg0gICAgICAgICAgICA8ZGl2IGNsYXNzPSJEVGltZyI+Cg08YSBocmVmPSdCdXlfZGV0YWlsLmFzcHg/ZW50cnk9NzA1MCZTTj1PZmZpY0FDQyc+Cg0gICAgICAgICAgICAgICAgPGltZyBjbGFzcz0icHJvZHVjdFNpemUgaW1nSCIgc3JjPSdJdGVtcGljLzAxLzAwMDAwMDcwNTAwMS5qcGcnLz48L2E+Cg0gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgICAgIDxkaXYgY2xhc3M9IkRldGFpbHNtaWQiPgoNICAgICAgICAgICAgICAgIDxoMz4yMTMxMjM8L2gzPgoNICAgICAgICAgICAgICAgIDxkaXYgY2xhc3M9Ik1vbkJveEwiPgoNICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0iVE9DIj4kMTIzLDEyMzwvc3Bhbj4KDSAgICAgICAgICAgICAgICA8L2Rpdj4KDTxkaXYgY2xhc3M9Ik1vbkJveFIiPiAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0iaW5wdXQtbnVtYmVyLWRlY3JlbWVudCIgb25jbGljaz0nbWludXMoNzA1MCknPuKAkzwvc3Bhbj4KDSAgICAgICAgICAgICAgICA8aW5wdXQgaWQ9Ik51bV83MDUwIiBuYW1lPSIiIHR5cGU9Im51bWJlciIgdmFsdWU9IjAiIGNsYXNzPSJpbnB1dC1udW1iZXIiICBkaXNhYmxlZD0iZGlzYWJsZWQiLz4KDSAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0iaW5wdXQtbnVtYmVyLWluY3JlbWVudCIgb25jbGljaz0ncGx1cyg3MDUwLDEyMzEzKSc+KyA8L3NwYW4+Cg08L2Rpdj4gICAgICAgICAgICA8L2Rpdj4KDSAgICAgICAgPC9kaXY+IAoNZGT0N5LRRKjvsgPYx89QtVCfQzNLrslnwrbnyqLzG6kJcA==" />
        </div>

        <script type="text/javascript">
            //<![CDATA[
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            function __doPostBack(eventTarget, eventArgument) {
                if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                    theForm.__EVENTTARGET.value = eventTarget;
                    theForm.__EVENTARGUMENT.value = eventArgument;
                    theForm.submit();
                }
            }
            //]]>
        </script>


        <div class="aspNetHidden">

            <input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="CA0B0334" />
            <input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="/wEdAAT9uJ+4q1T+wmsQegg9snvO1c+rlcuhQBanRksXVpk5utHCgrTLGrwNV8I3z6ZJgk5Da/DeKWrj2rXrOp7eyEPXlhg5PpVYNEup+e1N1H/lbIRCJp0O9NhJr0TRyED4w5U=" />
        </div>
        <!-- facebook(必須寫在最上面) & parse init -->

        <div id="loading">iApp 載入中</div>
        <!-- 導覽列（共用） -->
        <div class="BGW"></div>
        <nav class="navbar navbar-default navbar-fixed-top">

            <div class="container-fluid">

                <img class="iapplogo" src="img/ministorelogo.png" />
                <a href="SInfo.aspx?SN=OfficACC">
                    <div>
                        <h3 class="FixTitle">甘仔店</h3>
                    </div>
                </a>



                <!-- 左邊logo List -->
                <ul class="dropdown-menu dropdown-menu-right theme scrollable-menu" id="Rightwich" role="menu">
                    <li class="SandTitle">熱分享</li>
                    <li class="boxpos">
                        <a href="Default.aspx?SN=OfficACC&Intr=87" target="_blank">
                            <img src="QRcode.ashx?t=http://220.132.67.201:88/MiniStore/Default.aspx?SN=OfficACC&Intr=87" alt="" class="QRcode">
                        </a><a href="http://line.naver.jp/R/msg/text/?http://220.132.67.201:88/MiniStore/Default.aspx?SN=OfficACC">
                            <img src="img/lineicon.png" alt="用LINE傳送" class="line" />
                        </a>
                    </li>
                    <li class="SandTitle PCright">甘仔店 </li>
                    <li class="PCright"><a href="SInfo.aspx?SN=OfficACC">微店資訊</a></li>
                    <li class="PCright"><a href='Order_history.aspx?SN=OfficACC'>購買紀錄</a></li>
                    <li class="PCright"><a href="default.aspx?SN=OfficACC">回首頁</a></li>

                </ul>
                <!-- 右邊三明治 List -->
                <ul class="dropdown-menu dropdown-menu-right theme scrollable-menu" id="Leftwich" role="menu">
                    <li class="SandTitle">iApp微店</li>

                    <li><a onclick="LeftMenuJump(2)">打造行動微店</a></li>
                    <li class="disabled">加入行動分店</li>
                    <li><a href="http://www.iapp-media.com/portal/portal.aspx?t=10">微店市集</a></li>
                    <li><a href='../Login/me/m-profile.aspx?done=..%2f..%2fMiniStore%2fdefault.aspx%3fSN%3dOfficACC'>個人檔案</a></li>
                    <li id="lilogout">
                        <a id="LBLogout" href="javascript:__doPostBack(&#39;ctl00$LBLogout&#39;,&#39;&#39;)">登出</a>
                    </li>
                    <li class="clearfix"></li>

                </ul>
                <div id="listbox">
                </div>

                <!-- mobile 搜尋bar -->
                <div class="search-bar">
                    <div class="SearBoxCenter">
                        <input name="ctl00$mSearch" type="text" id="mSearch" class="search bar-text" placeholder="Search product..." />
                        <span class="glyphicon glyphicon-remove cancel" aria-hidden="true" />
                    </div>
                </div>


                <!-- mobile會員選單 -->
                <div>
                    <ul class="dropdown-menu dropdown-menu-right m-profile" role="menu">
                        <li><a href="#">我的iApp</a></li>
                        <li class="divider"></li>
                        <li><a href="#">收藏的iApp</a></li>
                        <li class="divider"></li>
                        <li><a href="login/m-login/m-profile.html">編輯個人資料</a></li>
                        <li class="divider"></li>
                        <li class="m-logout">
                            <p><a href="#">登出</a></p>
                        </li>
                    </ul>
                </div>
                <!-- Web -->
                <!-- Web 搜尋bar -->
                <div class="Lgallbar">
                    <button type="button" id="op-search" class="btn btn-default search2" data-toggle="dropdown" aria-expanded="false">
                        <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                    </button>
                    <a href="javascript:void(0)" class="menusandwich example1"><span></span></a>
                </div>
                <!-- 登入／註冊 -->

                <!-- 會員登入後 -->
                <div class="col-sm-2 col-md-1 icon-box">
                    <img class="usericon" src="img/photoicon.png" />
                    <div class="username-icon">
                        <h4>Digital+</h4>
                    </div>
                </div>
            </div>


        </nav>
        <!-- 會員資料 -->
        <div class="jumbotron">
            <img class="user-icon" src="img/photoicon.png" />
            <div class="option-user">
                <a href="#">
                    <div class="my-iapp">
                        <p><a class='iframe-info' href="http://www.iapp-media.com/basic/profile.aspx">會員資料</a></p>
                    </div>
                </a>
                <a href="#">
                    <div class="collect-iapp">
                        <p><a href="#">登出</a></p>
                    </div>
                </a>
            </div>

        </div>
        <!-- 至購物車 -->


        <!-- WRAPPER -->


        <div id="Allswiper">
            <div class="swiper-container">
                <div class="swiper-wrapper">
                    <div class="swiper-slide" data-src="Default.aspx?SN=OfficACC&C=3004">運動器材</div>
                    <div class="swiper-slide" data-src="Default.aspx?SN=OfficACC&C=3008">3C產品</div>
                    <div class="swiper-slide" data-src="Default.aspx?SN=OfficACC&C=3005">男裝服飾</div>
                </div>
                <!-- Add Arrows -->
                <div class="swiper-button-next"></div>
                <div class="swiper-button-prev"></div>
            </div>

        </div>
        <!-- 至購物車 -->
        <a id="Buycar" href="Buy_Ctrl.aspx?SN=OfficACC">
            <img class="back-top" src="img/cart.png" /><span /><label id="IconCar">0</label></span> </a>
        <div>


            <div id="ContentPlaceHolder1_Fast" class="product">
                <div id="FastBox">
                    <div class="details col-xs-12">
                        <div class="DTimg">
                            <a href='Buy_detail.aspx?entry=7045&SN=OfficACC'>
                                <img class="productSize imgH" src='Itempic/01/000000704501.jpg' /></a>
                        </div>
                        <div class="Detailsmid">
                            <h3>nike編織鞋(灰)</h3>
                            <div class="MonBoxL">
                                <span class="TOC">$599</span>
                            </div>
                            <div class="MonBoxR">
                                <span class="input-number-decrement" onclick='minus(7045)'>–</span>
                                <input id="Num_7045" name="" type="number" value="0" class="input-number" disabled="disabled" />
                                <span class="input-number-increment" onclick='plus(7045,9999)'>+ </span>
                            </div>
                            <div class="MonBoxR">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                                    <asp:ListItem>正常</asp:ListItem>
                                     <asp:ListItem>少糖</asp:ListItem>
                                       <asp:ListItem>去冰</asp:ListItem>
                                     <asp:ListItem>正常</asp:ListItem>
                                     <asp:ListItem>少糖</asp:ListItem>
                                     <asp:ListItem>正常</asp:ListItem>
                                     <asp:ListItem>少糖</asp:ListItem>
                                       <asp:ListItem>去冰</asp:ListItem>
                                       <asp:ListItem>去冰</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div class="details col-xs-12">
                        <div class="DTimg">
                            <a href='Buy_detail.aspx?entry=7047&SN=OfficACC'>
                                <img class="productSize imgH" src='Itempic/01/000000704701.jpg' /></a>
                        </div>
                        <div class="Detailsmid">
                            <h3>極致好感夏日紛色無印系列棒球帽</h3>
                            <div class="MonBoxL">
                                <span class="TOC">$456</span>
                            </div>
                            <div class="MonBoxR">
                                <span class="input-number-decrement" onclick='minus(7047)'>–</span>
                                <input id="Num_7047" name="" type="number" value="0" class="input-number" disabled="disabled" />
                                <span class="input-number-increment" onclick='plus(7047,123)'>+ </span>
                            </div>
                        </div>
                    </div>
                    <div class="details col-xs-12">
                        <div class="DTimg">
                            <a href='Buy_detail.aspx?entry=7046&SN=OfficACC'>
                                <img class="productSize imgH" src='Itempic/01/000000704601.jpg' /></a>
                        </div>
                        <div class="Detailsmid">
                            <h3>歐美風拼接設計舒適休閒縮口褲</h3>
                            <div class="MonBoxL">
                                <span class="TOC">$123</span>
                            </div>
                            <div class="MonBoxR">
                                <span class="input-number-decrement" onclick='minus(7046)'>–</span>
                                <input id="Num_7046" name="" type="number" value="0" class="input-number" disabled="disabled" />
                                <span class="input-number-increment" onclick='plus(7046,123123)'>+ </span>
                            </div>
                             
                        </div>
                    </div>
                    <div class="details col-xs-12">
                        <div class="DTimg">
                            <a href='Buy_detail.aspx?entry=7048&SN=OfficACC'>
                                <img class="productSize imgH" src='Itempic/01/000000704801.jpg' /></a>
                        </div>
                        <div class="Detailsmid">
                            <h3>6MM雙色TPE運動墊(加長版)</h3>
                            <div class="MonBoxL">
                                <span class="TOC">$599</span>
                            </div>
                            <div class="MonBoxR">
                                <span class="input-number-decrement" onclick='minus(7048)'>–</span>
                                <input id="Num_7048" name="" type="number" value="0" class="input-number" disabled="disabled" />
                                <span class="input-number-increment" onclick='plus(7048,999)'>+ </span>
                            </div>
                        </div>
                    </div>
                    <div class="details col-xs-12">
                        <div class="DTimg">
                            <a href='Buy_detail.aspx?entry=7049&SN=OfficACC'>
                                <img class="productSize imgH" src='Itempic/01/000000704901.jpg' /></a>
                        </div>
                        <div class="Detailsmid">
                            <h3>WD My Cloud Mirror 4TB(2TBx2) 雲端儲存系統</h3>
                            <div class="MonBoxL">
                                <span class="TOC">$9,890</span>
                            </div>
                            <div class="MonBoxR">
                                <span class="input-number-decrement" onclick='minus(7049)'>–</span>
                                <input id="Num_7049" name="" type="number" value="0" class="input-number" disabled="disabled" />
                                <span class="input-number-increment" onclick='plus(7049,99)'>+ </span>
                            </div>
                        </div>
                    </div>
                    <div class="details col-xs-12">
                        <div class="DTimg">
                            <a href='Buy_detail.aspx?entry=7050&SN=OfficACC'>
                                <img class="productSize imgH" src='Itempic/01/000000705001.jpg' /></a>
                        </div>
                        <div class="Detailsmid">
                            <h3>213123</h3>
                            <div class="MonBoxL">
                                <span class="TOC">$123,123</span>
                            </div>
                            <div class="MonBoxR">
                                <span class="input-number-decrement" onclick='minus(7050)'>–</span>
                                <input id="Num_7050" name="" type="number" value="0" class="input-number" disabled="disabled" />
                                <span class="input-number-increment" onclick='plus(7050,12313)'>+ </span>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <div class="col-xs-12 libor status CBbot CBBTN">
                        <input type="submit" name="ctl00$ContentPlaceHolder1$BTFast" value="結帳" id="ContentPlaceHolder1_BTFast" class="btn btn-warning col-xs-12 sendcareButtomeEnd" />
                    </div>
                </div>
            </div>
        </div>
        <script src="js/act.js"></script>


        <!-- WRAPPER END -->
    </form>
    <script>
        function LeftMenuJump(togo) {
            switch (togo) {
                default:
                    break;
                case 1:
                    window.open('JoinAs.aspx', '_self');
                    break;
                case 2:
                    if (confirm('您目前有一間微店是否要前進後台?')) {
                        window.open('JoinAs.aspx', '_self');
                    } else {
                        // Do nothing!
                    }
                    break;
            }
        }
    </script>
    <script type="text/javascript" src="js/jquery-1.8.0.min.js"></script>
    <!-- Google Map -->
    <script type="text/javascript" src="js/jquery.tinyMap.min.js"></script>
    <!-- 依需要參考已編譯外掛版本（如下），或各自獨立的外掛版本 -->
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.masonry.min.js"></script>
    <script type="text/javascript" src="js/jquery.infinitescroll.min.js"></script>
    <script type="text/javascript" src="js/jquery.colorbox-min.js"></script>
    <script type="text/javascript" src="js/index.js"></script>
    <script type="text/javascript" src="js/swiper.min.js"></script>
    <script type="text/javascript" src="js/jquery.touchSwipe.min.js"></script>
    <!-- Google Map -->
    <script type="text/javascript" src="js/googlemap.js"></script>
    <!-- GA iAppPortal -->
    <script type="text/javascript" src="js/ga-iappportal.js"></script>
    <!-- Loading -->
    <script>
        document.write('<style>#loading{display:none}</style>');
    </script>
</body>
</html>

<%--<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="GOGO()" OnClick="Button1_Click" />
    </div>
        <script>
         var openOption = 'width=400,height=400';
            function GOGO() {
                location.href = 'https://tw.yahoo.com/'
                //window.open("https://tw.yahoo.com/");
            }
   
 

        </script>
    </form>
</body>
</html>--%>
