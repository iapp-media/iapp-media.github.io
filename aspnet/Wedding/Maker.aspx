<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maker.aspx.cs" Inherits="Wedding.Maker" %>

<!DOCTYPE html>
<html lang="zh-tw" class="no-js">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
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
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link rel="apple-touch-icon-precomposed" href="img/icon.png" />
    <link rel="apple-touch-icon" href="img/114.png" />
    <link rel="apple-touch-startup-image" href="startup-iphone-portrait.png" media="(device-width:320px)" />
    <link rel="apple-touch-startup-image" href="startup-iphone-retina-portrait.png" media="(device-width:320px) and (-webkit-min-device-pixel-ratio: 2)" />
    <link rel="apple-touch-startup-image" href="startup-iphone-5-portrait.png" media="(device-width:320px) and (device-height:568px) and (-webkit-min-device-pixel-ratio: 2)" />
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
    <link rel="stylesheet" type="text/css" href="css/animate.css" />
    <link rel="stylesheet" href="css/colorbox.css" />
    <link rel="stylesheet" href="css/jquery.flipster.css" />
    <link rel="stylesheet" href="css/demo.css" />
    <link rel="stylesheet" href="css/flipsternavtabs.css" />

    <link href="css/mobileEditor.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!--上傳剪裁頁面-->
        <div class="upload-img">
            <div class="top">
                <img src="img/ministorelogo.png" class="toplogo" align="left" />
                <img src="img/cancel-01.png" class="cancelimgfun" align="right" />
            </div>
            <div class="upload-page">
                <label for="inputImage" class="selectBTN">
                    <div class="selectBTNin">
                        選擇照片
                    </div>
                </label>
                <div class="rotate">
                    <button data-method="rotate" type="button" class="rotate-btn">旋轉</button>
                </div>
                <div class="preview-container" style="display: none;">
                    <img id="preview" src="" />
                </div>
                <div class="img-container">
                    <img src="" alt="支持圖片上傳格式JPG,PNG" />
                </div>
                <p class="word">(移動及縮放進行照片裁切)</p>
                <asp:TextBox ID="CurrentId" runat="server" CssClass="hide" ClientIDMode="Static"></asp:TextBox>
                <input id="picnum" value="" class="hide" />
                <input type="file" accept="image/*" id="inputImage" style="display: none;" />
                <button data-method="getCroppedCanvas" type="button" id="cut" class="cut" disabled="true">
                    截圖
                </button>
                <button onclick="compress()" type="button" class="compress">
                    確認
                </button>
                <input id="Tbase64" value="" style="display: none;" />
            </div>
        </div>
        <!-- 首頁三明治 -->
        <!-- <img src="img/wedding-bg.jpg" class="bg_img" alt="">-->
        <div id="loading">iApp 載入中</div>
        <div class="allMove" id="allMove">
            <a href="javascript:void(0)" class="sandwich"></a>
            <ul class="menu" id="menu">
                <li>
                    <a href="javascript:void(0)" class="liColor moveIndex">
                        <img src="img/p7-pic.png" alt="">
                    </a>
                </li>
                <li><a>創建喜帖</a></li>
                <li class="colorboxlist1"><a>赴宴名冊</a></li>
                <li class="colorboxlist2"><a>朋友的祝福</a></li>
                <li><a>婚禮 iApp</a></li>
                <li><a>婚禮 微創作</a></li>
                <li>
                  <%--  <img src="img/qr-code-harley.jpg" alt="" class="QRcode">--%>
                    <asp:Literal ID="menu_QR" runat="server"></asp:Literal>
                    <a href="http://line.naver.jp/R/msg/text/?http://www.iapp-media.net/harley/"> 
                        <img src="img/lineicon.png" alt="用LINE傳送" class="line" />
                    </a>
                </li>
            </ul>
        </div>
        <!-- 三明治 end -->
        <!-- Page1 -->
        <div class="page page-1-1 page-current">
            <div class="time animated fadeInDown">
                <asp:TextBox ID="TB_calender1" runat="server" placeholder="民國104年"></asp:TextBox>
                <asp:TextBox ID="TB_calender2" runat="server" placeholder="國曆3/15"></asp:TextBox>
                <asp:TextBox ID="TB_calender3" runat="server" placeholder="農曆1/25"></asp:TextBox>
            </div>
            <div class="page1Title">
                <asp:TextBox ID="TB_man" runat="server" placeholder="葉大雄"></asp:TextBox>
                <div id="heart"></div>
                <asp:TextBox ID="TB_woman" runat="server" placeholder="源靜香"></asp:TextBox>
            </div>
            <div class="Protagonist animated fadeInDown">
                <asp:Literal ID="Lp01" runat="server"></asp:Literal> 
            </div>
            <div class="inside animated fadeInDown">
                <div>
                    <label for="">席設 :</label>
                    <asp:TextBox ID="TB_plece" runat="server"></asp:TextBox>

                </div>
                <div>
                    <label for="">地點 :</label>
                    <asp:TextBox ID="TB_Addr" runat="server"></asp:TextBox>
                    <img src="img/p1-location.png" class="location" alt="">
                </div>
                <div>
                    <label for="">電話 :</label>
                    <asp:TextBox ID="TB_Tel" runat="server"></asp:TextBox>
                    <img src="img/p1-callphone.png" class="callphone" alt="">
                </div>
                <div>
                    <label for="">時間 :</label>
                    <asp:TextBox ID="TB_Time" runat="server"></asp:TextBox>
                </div>
                <button class="carewed" disabled="disabled">我要赴宴</button>
            </div>
        </div>
        <!-- Page1 end -->
        <!-- Page2 -->
        <div class="page page-2-1  hide">
            <ul class="Page2index">
                <li class="animated fadeInDown">
                    <asp:TextBox ID="TB_p2Memo" runat="server" TextMode="MultiLine" placeholder="一個意外  讓我們  相遇      一場大雨  讓我們  相知"></asp:TextBox> 
                </li>
            </ul>
            <div class="page2pic">
                <asp:Literal ID="Lp02" runat="server"></asp:Literal> 
            </div>
            <div class="page2pic2">
                <img src="img/p2-photo1.jpg" alt="">
            </div>
            <img class="up moveIconUp" src="img/icon_up.png" />
        </div>
        <!-- Page2 end -->
        <!-- Page3 -->
        <div class="page page-3-1 hide">
            <ul class="Page3index">
                <li class="animated fadeInDown">
                    <asp:TextBox ID="TB_p3Memo1" runat="server" TextMode="MultiLine" placeholder="習慣了妳的聲音、妳的氣味、妳的存在...連思念都成了習慣"></asp:TextBox>
                    
                </li>
            </ul>
            <ul class="display-animation Page3Insidepic">
                  <asp:Literal ID="Lp03" runat="server"></asp:Literal> 
               <%-- <li>
                    <img id='p03' src="img/p3-photo1.jpg" alt="">
                    <div class="Uploadimg takeimage1">
                        <label for="inputImage" onclick="setCurrent('03',5,275,275)">
                            <img src="img/uploadicon.png" class="clickslider">
                        </label>
                    </div>
                </li>
                <li>
                    <img id='p04' src="img/p3-photo2.jpg" alt="">
                    <div class="Uploadimg takeimage1">
                        <label for="inputImage" onclick="setCurrent('04',5,276,317)">
                            <img src="img/uploadicon.png" class="clickslider">
                        </label>
                    </div>
                </li>
                <li>
                    <img id='p05' src="img/p3-photo3.jpg" alt="">
                    <div class="Uploadimg takeimage1">
                        <label for="inputImage" onclick="setCurrent('05',5,300,200)">
                            <img src="img/uploadicon.png" class="clickslider">
                        </label>
                    </div>
                </li>
                <li>
                    <img id='p06' src="img/p3-photo4.jpg" alt="">
                    <div class="Uploadimg takeimage1">
                        <label for="inputImage" onclick="setCurrent('06',5,300,200)">
                            <img src="img/uploadicon.png" class="clickslider">
                        </label>
                    </div>
                </li>
                <li>
                    <img id='p07' src="img/p3-photo5.jpg" alt="">
                    <div class="Uploadimg takeimage1">
                        <label for="inputImage" onclick="setCurrent('07',5,300,200)">
                            <img src="img/uploadicon.png" class="clickslider">
                        </label>
                    </div>
                </li>--%>
            </ul>
            <ul class="Page3indexBot">
                <li class="animated fadeInDown">
                     <asp:TextBox ID="TB_p3Memo2" runat="server" TextMode="MultiLine" placeholder="終於  我牽起你的手 那一天起  就決定再也不放開"></asp:TextBox>
               

                </li>
            </ul>
            <img class="up moveIconUp" src="img/icon_up.png" />
        </div>
        <!-- Page3 end -->
        <!-- Page4 -->
        <div class="page page-4-1 hide">
            <ul class="Page4Top">
                <li class="animated fadeInDown">　
                    <input type="text" value="妳使我的生命得到豐富" disabled="disabled">
                    <input type="text" value="妳照亮了前方的迷霧" disabled="disabled" >
                    <input type="text" value="牽著妳的手我更清楚" disabled="disabled">
                    <input type="text" value="相知與相惜" disabled="disabled">
                </li>
            </ul>
            <ul class="weddinghand">
                <li>
                    <img src="img/p4-ani01.png" alt=""></li>
                <li>
                    <img src="img/p4-ani02.png" alt=""></li>
                <li>
                    <img src="img/p4-ani03.png" alt=""></li>
            </ul>
            <ul class="Page4Bot">
                <li class="animated fadeInDown">
                    <input type="text" value="『我們結婚吧』" disabled="disabled">
                    <input type="text" value="Yes I do" disabled="disabled">
                </li>
            </ul>
            <img class="up moveIconUp" src="img/icon_up.png" />
        </div>
        <!-- Page4 end -->
        <!-- Page5 -->
        <div class="page page-5-1 flipster hide">
            <ul>
                 <asp:Literal ID="Lp05" runat="server"></asp:Literal> 
<%--                <li>
                    <a href="javascript:void(0)" class="Button Block">
                        <img id='p08' src="img/p5-photo1.jpg" alt="">
                        <div class="Uploadimg takeimage1">
                            <label for="inputImage" onclick="setCurrent('08',5,435,650)">
                                <img src="img/uploadicon.png" class="clickslider">
                            </label>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="javascript:void(0)" class="Button Block">
                        <img id='p09' src="img/p5-photo1.jpg" alt="">
                        <div class="Uploadimg takeimage1">
                            <label for="inputImage" onclick="setCurrent('09',5,435,650)">
                                <img src="img/uploadicon.png" class="clickslider">
                            </label>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="javascript:void(0)" class="Button Block">
                        <img id='p10' src="img/p5-photo1.jpg" alt="">
                        <div class="Uploadimg takeimage1">
                            <label for="inputImage" onclick="setCurrent('10',5,435,650)">
                                <img src="img/uploadicon.png" class="clickslider">
                            </label>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="javascript:void(0)" class="Button Block">
                        <img id='p11' src="img/p5-photo1.jpg" alt="">
                        <div class="Uploadimg takeimage1">
                            <label for="inputImage" onclick="setCurrent('11',5,435,650)">
                                <img src="img/uploadicon.png" class="clickslider">
                            </label>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="javascript:void(0)" class="Button Block">
                        <img id='p12' src="img/p5-photo1.jpg" alt="">
                        <div class="Uploadimg takeimage1">
                            <label for="inputImage" onclick="setCurrent('12',5,435,650)">
                                <img src="img/uploadicon.png" class="clickslider">
                            </label>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="javascript:void(0)" class="Button Block">
                        <img id='p13' src="img/p5-photo1.jpg" alt="">
                        <div class="Uploadimg takeimage1">
                            <label for="inputImage" onclick="setCurrent('13',5,435,650)">
                                <img src="img/uploadicon.png" class="clickslider">
                            </label>
                        </div>
                    </a>
                </li>--%>
            </ul>
            <img class="up moveIconUp" src="img/icon_up.png" />
        </div>
        <!-- Page5 end -->
        <!-- Page6 -->
        <div class="page page-6-1 hide">
            <div class="wrap">
                <img class="up animated moveIconUp" src="img/icon_up.png" />
                <%--                <asp:Literal ID="L_map" runat="server"></asp:Literal>--%>
                <iframe class="map" name="iframemap" src="map.html"></iframe>
                <a href="javascript: return false;" onclick="iframemap.window.location.reload()" class="button">
                    <img src="img/reflash.png" border="0" onclick="this.src=='http://tkining.bitbucket.org/iwedding/img/reflash.png'?this.src='http://tkining.bitbucket.org/iwedding/img/reflash.png':this.src='http://tkining.bitbucket.org/iwedding/img/reflash2.png'"></a>
            </div>
            <div class="google_adress">
                <label for="">席設地址 :</label>
                <asp:TextBox ID="TB_map_addr" runat="server" TextMode="MultiLine" placeholder="台北市地球村"></asp:TextBox>
            </div>
            <h1>交通資訊</h1>
            <div class="Carmargin">
              <%--  <label for="">開車 :</label>--%>
                <asp:TextBox ID="TB_Traffic_info" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
<%--            <div class="Carmargin">
                <label for="">捷運 :</label>
                <textarea rows="2" cols="50" placeholder="搭台北聯營公車20.202.207.258.282.284.信義 幹線等路，在世貿下車可抵達君悅大飯店。"></textarea>
            </div>
            <div class="Carmargin">
                <label for="">公車 :</label>
                <textarea rows="2" cols="50" placeholder="搭台北聯營公車20.202.207.258.282.284.信義 幹線等路，在世貿下車可抵達君悅大飯店。"></textarea>
            </div>--%>
        </div>
        <!-- Page6 end -->
        <!-- Page7 -->
        <div class="page page-7-1 hide">
            <ul class="page7pic">
                <li>
                    <img src="img/p7-pic.png" alt=""></li>
               
                    <asp:Literal ID="L_QR" runat="server"></asp:Literal>
                <%-- <li>    <img src="img/p7-qr.jpg" alt="">  </li>--%> 
                <li>
                    <a href="m-set.html">
                        <%--    <img src="img/p7-publish.png" alt="">--%>
                        <asp:ImageButton ID="BT_Release" runat="server" ImageUrl="img/p7-publish.png" OnClick="BT_Release_Click" OnClientClick="SendData()" />
                    </a>
                </li>
            </ul>
        </div>
        <!-- Page7 end -->

        <!-- list -->

        <div id="mobile" class="friendtable">
            <div class="close hairline"></div>
            <h1>赴宴名冊</h1>
            <table>
                <thead>
                    <tr>
                        <th>姓名</th>
                        <th>電話</th>
                        <th>人數</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RP_attn" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Tel") %></td>
                                <td><%# Eval("Attendance") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="L1" runat="server" Visible="false"></asp:Literal>
                    <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                </tbody>
            </table>
        </div>

        <div id="mobile2" class="friendtable">
            <div class="close hairline"></div>
            <h1>朋友的祝福</h1>
            <table>
                <thead>
                    <tr>
                        <th>姓名</th>
                        <th>電話</th>
                        <th>祝福</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RP_bless" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Tel") %></td>
                                <td>
                                    <p class="Blessingyou" id="blessck" runat="server">點我觀看</p>
                                </td>
                                <td class="hidden">
                                    <asp:Label ID="mo" runat="server" Text='<%# Eval("Memo") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="L2" runat="server" Visible="false"></asp:Literal>
                    <asp:SqlDataSource ID="SD2" runat="server"></asp:SqlDataSource>

                </tbody>
            </table>
            <div class="applecolorbox">
            </div>
            <textarea rows="4" cols="50" id="SeeMemo">你好恭喜發財</textarea>
        </div>
        <asp:Label ID="Linfo" runat="server" Text="Label" CssClass="hidden"></asp:Label>
    </form>
    <!-- list end -->
    <!-- Src JS -->

    <script src="js/zepto.min.js"></script>
    <script src="js/touch.js"></script>
    <script src="js/index.js"></script>
    <script src="js/jquery.mobile-1.4.5.min.js"></script>
    <%--  <script src="js/jquery-2.1.4.min.js"></script>--%>
    <script src="js/jquery-1.8.0.min.js"></script>
    <script src="js/snap.js"></script>
    <script src="js/jquery.easing.1.3.js"></script>
    <script src="js/jquery.colorbox-min.js"></script>
    <script src="js/custom.js"></script>
    <script src="js/jquery.flipster.js"></script>


    <script src="js/exif.js"></script>
    <script src="js/JIC.js"></script>
    <script src="js/cropper.js"></script>

    <script src="js/mobileEditor-new.js"></script>

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
        $('.Blessingyou').on('click', function () {
            // alert(this.id);
            //alert(this.id.replace("blessck", "mo")); 
            document.getElementById("SeeMemo").innerHTML = document.getElementById(this.id.replace("blessck", "mo")).innerHTML;
        });

        function SendData() {
            $.ajax({
                type: "POST",
                url: "makeHtml.aspx?i=" + document.getElementById("Linfo").innerHTML,
                cache: false,
                success: function (imgurl) {
                    alert(imgurl);
                },
                error: function (ss) {
                    alert("makeHtml.aspx?i=" + document.getElementById("Linfo").innerHTML);
                }
            });
        }

    </script>
</body>
</html>
