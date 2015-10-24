<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Add.aspx.cs" Inherits="StoreMana.Mini.Product_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="css/cropper.css" />
    <link rel="stylesheet" type="text/css" href="css/mobileEditor.css" />
    <script src="js/exif.js"></script>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script> 
    <script src="js/JIC.js" type="text/javascript"></script>
    <script src="js/cropper.js"></script>
    <script src="js/mobileEditor-new.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 建檔修改 -->
    <!--上傳剪裁頁面-->
    <div class="upload-img">
        <div class="top">
            <img src="img/iapplogo.png" class="toplogo" align="left" />
            <img src="img/cancel-01.png" class="cancel" align="right" />
        </div>
        <div class="upload-page">
            <label for="inputImage">
                <div class="select">
                    選擇照片
                </div>
            </label>
            <div class="rotate">
                <button data-method="rotate" type="button" class="rotate-btn">旋轉</button>
            </div>
            <div class="preview-container hide">
                <img id="preview" src="" />
            </div>
            <div class="img-container">
                <img src="" alt="支持圖片上傳格式JPG,PNG" />
            </div>
            <p class="word">(移動及縮放進行照片裁切)</p>
            <asp:TextBox ID="CurrentId" runat="server" CssClass="hide" ClientIDMode="Static"></asp:TextBox>
            <input id="picnum" value="" class="hide" />
            <input type="file" accept="image/*" id="inputImage" style="display:none;" />
            <button data-method="getCroppedCanvas" type="button" id="cut" class="cut" disabled="true">
                截圖
            </button>
            <button onclick="compress()" type="button" class="compress">
                確認
            </button>
            <input id="Tbase64" value="" style="display:none;" />
        </div>
    </div>
    <!-- 建檔修改 -->
    <div class="allmodify">
        <ul class="buydivmove mart10">
            <li class="modify col-xs-12">
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品類別</label>
                            <asp:DropDownList class="form-control" ID="DL_Cate" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-12 libor status">
                            <label for="" class="col-xs-12">商品圖片</label>
                           <div style="display:none;">
                               <%-- 不要的 --%>
                            <div class="form-group">
                                <div style="margin: 0 0 0 300px; width: 500px">
                                    <!-- 輪播圖 
                                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                    
                                        <div class="carousel-inner" role="listbox">
                                            <asp:Literal ID="L" runat="server"></asp:Literal>
                                        </div>
                             
                                        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div> 
                                -->
                                </div> 
                            </div>
                           </div>
                            <div id="slider" class="col-xs-12">
                                <div class="control_next glyphicon glyphicon-chevron-right"></div>
                                <div class="control_prev glyphicon glyphicon-chevron-left"></div>
                                <ul>
                                    <li>
                                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" class="sliderimgH"/>
                                        <label>
                                            <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider">
                                        </label>
                                    </li>
                                    <li>
                                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" class="sliderimgH" />
                                        <label>
                                            <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider">
                                        </label>
                                    </li>
                                    <li>
                                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" class="sliderimgH" />
                                        <label>
                                            <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider">
                                        </label>
                                    </li>
                                    <li>
                                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" class="sliderimgH" />
                                        <label>
                                            <img src="img/uploadicon.png" alt="..." class="imgsize poscenter clickslider openslider">
                                        </label>
                                    </li>
                                </ul>
                            </div>
                            <%-- slider自動播放函式 --%>
                       <%-- <div class="slider_option">
                            <input type="checkbox" id="checkbox">  
                        </div>--%>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
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
                        <!--<div class="col-xs-12 libor paynumber">
                            <label class="col-xs-6">付款方式</label>
                           <div>
                               <asp:CheckBoxList ID="CB_Payment" runat="server" CssClass="aaa"    RepeatDirection="Horizontal" RepeatLayout="Flow"  > 
                               </asp:CheckBoxList>
                               <asp:ListBox ID="aa" runat="server" SelectionMode="Multiple">
                                   <asp:ListItem Text="aaaa"></asp:ListItem>
                                   <asp:ListItem Text="aaaa"></asp:ListItem>
                                   <asp:ListItem Text="aaaa"></asp:ListItem>
                               </asp:ListBox>
                           </div>
                            <div class="checkbox col-xs-4 florichebox" style="display:none">
                                    <input type="checkbox">
                                 <label>
                                   面交
                                </label>
                                <br />
                                <label>
                                    <input type="checkbox">
                                    7-11 ibon
                                </label>
                                <br />
                                <label>
                                    <input type="checkbox">
                                    銀行轉帳
                                </label>
                            </div>
                        </div>-->
                        <!--<div class="col-xs-12 libor paynumber">
                            <label  class="col-xs-6">寄送方式</label>
                            <div style="display:none">
                               <asp:CheckBoxList ID="CB_Delivery" runat="server"    RepeatDirection="Horizontal" RepeatLayout="Flow"  >        
                               </asp:CheckBoxList>
                           </div>  
                             <div class="checkbox col-xs-4 florichebox">
                                <label>
                                    <input type="checkbox">
                                    面交自取
                                </label>
                                <br />
                                <label>
                                    <input type="checkbox">
                                    7-11
                                </label>
                                <br />
                                <label>
                                    <input type="checkbox">
                                    寄送到府
                                </label>
                            </div>
                        </div>-->
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
       
    </div> 
    <script>
        $('.carousel').carousel({
            interval: false
        })

        function Iframeload() { 
            window.location.reload("Product_Add.aspx"); 
        }
    </script>
</asp:Content>
