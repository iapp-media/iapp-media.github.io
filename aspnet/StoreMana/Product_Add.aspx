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

    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Product_Mana.aspx" style="color: white">商品列表</a></li>
                <li class="swiper-slide col-xs-4"><a href="Product_Add.aspx" style="color: white">建檔修改</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
            </ul>
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
                        <div class="insidecare col-xs-12">
                         
                                <div class="row">
                                    <div class="col-xs-12 libor paynumber">
                                        <div class="col-xs-4">
                            <p class="BoxLeft">商品類別</p>
                        </div>
                                        
                                        <asp:DropDownList class="form-control" ID="DL_Cate" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                     
                                    <div class="col-xs-12 libor status">
                                        <label for="" class="col-xs-12">商品圖片</label>
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
                               
                            </div>
                        </div>
                    </div>
                    <p class="text-center fonts">填寫資料</p>
                    <ul class="buydivmove">
                        <li class="modify col-xs-12">
                            <div class="col-xs-12 insidecare">
                                <div class="row">
                                    <div class="col-xs-12 libor paynumber">
                                        <label for="" class="col-xs-6">商品名稱</label>
                                        <asp:TextBox ID="TB_ProductName" Class="form-control" runat="server" placeholder="限30個字以內"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label for="" class="col-xs-6">價格</label>
                                        <asp:TextBox ID="TB_Price" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label for="" class="col-xs-6">數量</label>
                                        <asp:TextBox ID="TB_qty" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label for="" class="col-xs-6">商品說明</label>
                                        <asp:TextBox ID="TB_Description" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label for="" class="col-xs-6">商品規格</label>
                                        <asp:TextBox ID="TB_Dimension" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 libor paynumber">
                                        <label for="" class="col-xs-6">備註</label>
                                        <asp:TextBox ID="TB_Memo" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="BT_Create" runat="server" Text="Create" CssClass="btn btn-warning btn-lg btn-block sendcareButtom" OnClick="BT_Create_Click" />
                            <asp:Button ID="BT_Cancel" runat="server" Text="Cancel" CssClass="btn btn-warning btn-lg btn-block sendcareButtom" OnClick="BT_Cancel_Click" />
                        </li>
                    </ul>
                    <asp:Literal ID="LPID" runat="server" Visible="false"></asp:Literal> 
               
    <script src="js/mobileEditor-new.js"></script>

    <script>
        $('.carousel').carousel({
            interval: false
        })

        //function getimghtml() {
        //    $('#LLL').html = "<div>YYYES</div>"
        // //   alert('aaa');
           
        //}

    </script>
</asp:Content>
