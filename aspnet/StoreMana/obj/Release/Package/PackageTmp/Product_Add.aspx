<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Add.aspx.cs" Inherits="StoreMana.Mini.Product_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/cropper.css" />
    <link rel="stylesheet" type="text/css" href="css/mobileEditor.css" />
    <script src="js/exif.js"></script>
    <script src="js/jquery-1.8.0.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/JIC.js" type="text/javascript"></script>
    <script src="js/cropper.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Product_Mana.aspx" style="color: white">商品列表</a></li>
                <li class="swiper-slide col-xs-4"><a href="Product_Add.aspx" style="color: white">商品建檔</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
            </ul>
        </div>
    </div>--%>
    <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide"><a href="Product_Mana.aspx" style="color: white">商品列表</a></div>
                <div class="swiper-slide"><a href="Product_Add.aspx" style="color: white">商品建檔</a></div>
                <div class="swiper-slide"><a href="Setting.aspx" style="color: white">參數設定</a></div>
            </div>
        </div>
    </div>

    <!-- WRAPPER -->


    <!-- 建檔修改 -->

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
    <div class="buydivmove">
        <div class="insidecare col-xs-12 AllBGC">
            <div class="row">
                <div class="col-xs-12 libor paynumber">
                    <div class="col-xs-12 BTbox">
                        <div class="row">
                            <p class="BTleft">商品類別</p>
                            <asp:DropDownList class="BTright" ID="DL_Cate" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="col-xs-12 libor status">
                    <div class="col-xs-12 BTbox">
                        <div class="row">
                            <p class="BTleft">商品圖片</p>
                        </div>
                    </div>
                    <div id="slider" class="col-xs-12">
                        <div class="control_next glyphicon glyphicon-chevron-right"></div>
                        <div class="control_prev glyphicon glyphicon-chevron-left"></div>
                        <asp:Literal ID="L_Img" runat="server"></asp:Literal>
                        <%--                                            <ul> 
                                                <li> 
                                                       <img id="p01"   src="img/2531170_203204624000_2.jpg" class="sliderimgH"  />    
                                                    <label onclick="setCurrent('01','3033-1')">
                                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider" />
                                                    </label> 
                                                </li>
                                                <li> 
                                                      <img id="p02"   src="img/2531170_203204624000_2.jpg"  class="sliderimgH"  /> 
                                                    <label onclick="setCurrent('02','3033-0')">
                                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider" />
                                                    </label>
                                                </li>
                                                <li> 
                                                       <img id="p03"   src="img/2531170_203204624000_2.jpg" class="sliderimgH"  /> 
                                                    <label onclick="setCurrent('03','3033-1')">
                                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider" />
                                                    </label>
                                                </li>
                                                <li>
                                                        <img id="p04"  src="img/2531170_203204624000_2.jpg" class="sliderimgH"  /> 
                                                    <label onclick="setCurrent('04','3033-1')">
                                                        <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider" />
                                                    </label>
                                                </li>
                                            </ul>--%>
                    </div>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">商品名稱</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TB_ProductName" Class="form-control" runat="server" placeholder="限22個字以內" onkeyup="words_deal(44)"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">價格</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TB_Price" Class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">數量</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TB_qty" Class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">商品說明</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TB_Description" Class="form-control2" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">商品規格</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TB_Dimension" Class="form-control2" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="col-xs-12 libor paynumber PadLib ProGrayC BorTop">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">備註</p>
                        </div>
                    </div>
                    <%--   <textarea name="" id="" cols="30" rows="10" class="col-xs-12 AllBGC"></textarea>--%>
                    <asp:TextBox ID="TB_Memo" Class="form-control2" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="col-xs-12 BorTop">
                    <div class="row">
                        <div class="col-xs-5 libor status CBbot CBBTN">
                            <asp:Button ID="BT_Cancel" runat="server" Text="取消" CssClass="btn btn-warning col-xs-12 SBuyCar" OnClick="BT_Cancel_Click" />
                        </div>
                        <div class="col-xs-7 libor status CBbot CBBTN">
                            <asp:Button ID="BT_Create" runat="server" Text="確認新增" CssClass="btn btn-warning col-xs-12 sendcareButtom" OnClick="BT_Create_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Literal ID="LPID" runat="server" Visible="false"></asp:Literal>

    <script src="js/mobileEditor-new.js"></script>
    <script src="js/mobileEditor-new.js"></script>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script>
        $('.carousel').carousel({
            interval: false
        })
        var texttmp = $("#ContentPlaceHolder1_TB_ProductName").val();
        function words_deal(cct) {
            var curLength = getlength($("#ContentPlaceHolder1_TB_ProductName").val());
            if (curLength > cct) {
                document.getElementById('ContentPlaceHolder1_TB_ProductName').value = texttmp;
                alert("超過字數限制，多出的字將被移除！");
            } else {
                texttmp = $("#ContentPlaceHolder1_TB_ProductName").val();
            }
        }
        function getlength(str) {
            var arr = str.match(/[^\x00-\xff]/ig);
            return (arr == null) ? str.length : str.length + arr.length;
        }
    </script>
</asp:Content>
