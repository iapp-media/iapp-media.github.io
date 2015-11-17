<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThreeOpen.aspx.cs" Inherits="StoreMana.ThreeOpen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>iApp微店後台</title>
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
    <!--<meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no">-->
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
    <link rel="stylesheet" href="css/index.css" />
    <link rel="stylesheet" href="css/masonry.css" />
    <link rel="stylesheet" href="css/colorbox.css" />
    <link rel="stylesheet" href="css/swiper.min.css" />

    <link rel="stylesheet" href="css/screen.css">
    <link rel="stylesheet" href="sass/slider.css">
    <link rel="stylesheet" href="css/cropper.css">
    <link rel="stylesheet" href="css/mobileEditor.css">
    <!-- HTML5 shim and Respond.js 讓 IE8 支援 HTML5 元素與媒體查詢 -->
    <!-- 警告：Respond.js 無法在 file:// 協定下運作 -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style>
        .minbox {
            background-color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="loading">iApp 載入中</div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- WRAPPER NEW -->
        <div class="buydivmove">
            <div class="productcare col-xs-12">
                <div class="col-xs-12">
                    <div class="row">
                        <div id="Step1" class="col-xs-12 minbox ">
                            <h2>Step1.選擇商店類別</h2>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DLSCate" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:Button runat="server" Text="下一步" ID="BTStep1" OnClientClick="goStep(1)" OnClick="BTStep1_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div id="Step2" class="col-xs-12 minbox ">
                            <h2>Step2.選擇付款</h2>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBoxList ID="CB_Payment" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="1">
                                    </asp:CheckBoxList>
                                    <button id="upStep2" onclick="upStep(2)">上一步</button>
                                    <asp:Button runat="server" Text="下一步" ID="BTStep2" OnClientClick="goStep(2)" OnClick="BTStep2_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div id="Step3" class="col-xs-12 minbox ">
                            <h2>Step3.填寫銀行帳號(如果有選ATM轉帳)</h2>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <p>銀行名稱</p>
                                        <asp:TextBox ID="TBBankName" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>銀行代碼</p>
                                        <asp:TextBox ID="TBBankNo" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>受款帳號</p>
                                        <asp:TextBox ID="TBACC" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>受款戶名</p>
                                        <asp:TextBox ID="TBACName" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>聯絡人</p>
                                        <asp:TextBox ID="TBCEO" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>聯絡電話</p>
                                        <asp:TextBox ID="TBTEL" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>聯絡地址</p>
                                        <asp:TextBox ID="TBAddr" runat="server" CssClass="form-control magclose"></asp:TextBox>
                                    </div>
                                    <button id="upStep3" onclick="upStep(3)">上一步</button>
                                    <asp:Button runat="server" Text="下一步" ID="BTStep3" OnClientClick="goStep(3)" OnClick="BTStep3_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div id="Step4" class="col-xs-12 minbox ">
                            <h2>Step4.選擇寄送方式</h2>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBoxList ID="CB_Delivery" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="1">
                                    </asp:CheckBoxList>
                                    <button id="upStep4" onclick="upStep(4)">上一步</button>
                                    <asp:Button runat="server" Text="下一步" ID="BTStep4" OnClientClick="goStep(4)" OnClick="BTStep4_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                        <div id="Step5" class="col-xs-12 minbox ">
                            <h2>Step5.建立一個商品!!</h2>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
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
                                    <div>
                                        <p>商品類別</p>
                                        <asp:DropDownList ID="DL_Cate" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div>
                                        <p>商品圖片</p>
                                        <div id="slider">
                                            <div class="glyphicon glyphicon-chevron-right control_next"></div>
                                            <div class="glyphicon glyphicon-chevron-left control_prev"></div>
                                            <ul>
                                                <li>
                                                    <img id="p01" src="" class="sliderimgH">
                                                    <label onclick="setCurrent('04','9040')">
                                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider Addbutton">
                                                    </label>
                                                </li>
                                                <li>
                                                    <img id="p02" src="" class="sliderimgH" />
                                                    <label onclick="setCurrent('04','9040')">
                                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider Addbutton">
                                                    </label>

                                                </li>
                                                <li>
                                                    <img id="p03" src="" class="sliderimgH" />
                                                    <label onclick="setCurrent('04','9040')">
                                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider Addbutton">
                                                    </label>

                                                </li>
                                                <li>
                                                    <img id="p04" src="" class="sliderimgH" />
                                                    <label onclick="setCurrent('04','9040')">
                                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider Addbutton">
                                                    </label> 
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div>
                                        <p>商品名稱</p>
                                        <asp:TextBox ID="TB_ProductName" Class="form-control" runat="server" placeholder="限22個字以內" onkeyup="words_deal(44)"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>價格</p>
                                        <asp:TextBox ID="TB_Price" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>數量</p>
                                        <asp:TextBox ID="TB_qty" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>商品說明</p>
                                        <asp:TextBox ID="TB_Description" Class="form-control2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div>
                                        <p>商品規格</p>
                                        <asp:TextBox ID="TB_Dimension" Class="form-control2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <button id="upStep5" onclick="upStep(5)">上一步</button>
                                    <asp:Button runat="server" Text="下一步" ID="BTStep5" OnClientClick="goStep(5)" OnClick="BTStep5_Click" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div id="Step6" class="col-xs-12 minbox ">
                            <h2>Step6.看看我的微店</h2>
                            <a id="upStep6" onclick="upStep(6)">上一步</a>
                            <asp:Button ID="BTStep6" runat="server" Text="完成" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- WRAPPER END -->

 

 
        <!-- Loading -->
        <script>
            document.write('<style>#loading{display:none}</style>');

            $(document).ready(function () {
                $('#Step2').hide();
                $('#Step3').hide();
                $('#Step4').hide();
                $('#Step5').hide();
                $('#Step6').hide();
            });

            function goStep(obj) {
                switch (obj) {
                    case 1:
                        $('#Step1').hide();
                        $('#Step2').fadeIn();
                        break;
                    case 2:
                        $('#Step2').hide();
                        $('#Step3').fadeIn();
                        break;
                    case 3:

                        $('#Step3').hide();
                        $('#Step4').fadeIn();
                        break;
                    case 4:
                        $('#Step4').hide();
                        $('#Step5').fadeIn();
                        break;
                    case 5:
                        $('#Step5').hide();
                        $('#Step6').fadeIn();
                        break;
                    default:

                }
            }

            function upStep(obj) {
                switch (obj) {
                    case 2:
                        $('#Step1').fadeIn();
                        $('#Step2').hide();
                        break;
                    case 3:
                        $('#Step2').fadeIn();
                        $('#Step3').hide();
                        break;
                    case 4:
                        $('#Step3').fadeIn();
                        $('#Step4').hide();
                        break;
                    case 5:
                        $('#Step4').fadeIn();
                        $('#Step5').hide();
                        break;
                    case 6:
                        $('#Step5').fadeIn();
                        $('#Step6').hide();
                        break;
                }
            }

 
        </script>
    </form>
</body>
</html>
