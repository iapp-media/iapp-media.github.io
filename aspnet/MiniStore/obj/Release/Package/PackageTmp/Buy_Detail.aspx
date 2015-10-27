<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Detail.aspx.cs" Inherits="MiniStore.Buy_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<<<<<<< HEAD--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
        <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Product_Mana.aspx" style="color: white">圖書文具</a></li>
                <li class="swiper-slide col-xs-4"><a href="Product_Add.aspx" style="color: white">享受美食</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">品味生活</a></li>
            </ul>
        </div>
    </div>
    <div class="col-xs-12 promana">
        <div class="row"> 
    <ul class="buydivmove">
        <li class="productcare">
            <div class="col-xs-12 insidecare">
                <div class="row">
                    <div class="col-xs-12 libor ContentTop">
                        <img src="img/backarrow.png" alt="Alternate Text" class="col-xs-2"/>
                        
                        <h1 class="col-xs-10">商品內容</h1>
                           
                    </div>
                    <div class="col-xs-12 libor productsinside">
                        <div id="slider">
                            <div class="control_next glyphicon glyphicon-chevron-right"></div>
                            <div class="control_prev glyphicon glyphicon-chevron-left"></div>
                            <ul>
                                <asp:Literal ID="IMG_li" runat="server"></asp:Literal>
                                <%-- <li>
=======
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Product_Mana.aspx" style="color: white">商品列表</a></li>
                <li class="swiper-slide col-xs-4"><a href="Product_Add.aspx" style="color: white">建檔修改</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
            </ul>
        </div>
    </div>
    <div class="col-xs-12 promana">
        <div class="row"> 
            <ul class="buydivmove">
                <li class="productcare col-xs-12">
                    <div class="col-xs-12 insidecare">
                        <div class="row">
                            <div class="col-xs-12 libor productsinside">
                                <div id="slider">
                                    <div class="control_next glyphicon glyphicon-chevron-right"></div>
                                    <div class="control_prev glyphicon glyphicon-chevron-left"></div>
                                    <ul>
                                        <asp:Literal ID="IMG_li" runat="server"></asp:Literal>
                                        <%-- <li>
>>>>>>> origin/master
                                    <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" /></li>
                                <li>
                                    <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" /></li>
                                <li>
                                    <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" /></li>
                                <li>
                                    <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" /></li>--%>
                                    </ul>
                                </div>
                                <%--                        <div class="slider_option">
                            <input type="checkbox" id="checkbox" />
                        </div>--%>

                                <h1 class="col-xs-6">
                                    <asp:Literal ID="L_Name" runat="server"></asp:Literal></h1>
                            </div>
                            <div class="col-xs-12 questionBox">
                                <div class="row">
                                    <asp:Button ID="BT_MSG" runat="server" Text="問與答" CssClass="col-xs-4 question" OnClick="BT_MSG_Click" />
                                    <asp:Button ID="BT_Like" runat="server" Text="LIKE" CssClass="col-xs-4 question" />
                                    <asp:Button ID="BT_SHARE" runat="server" Text="分享" CssClass="col-xs-4 question" />
                                </div>
                            </div>
                            <div class="col-xs-12 libor CBtitle">
                               
                                <asp:TextBox ID="TB_Name" runat="server" CssClass="col-xs-12"></asp:TextBox>
                                   
                            </div>
                            <div class="col-xs-12 libor productNum CBbot">
                                <label for="" class="col-xs-6">商品售價</label>
                                <asp:TextBox ID="TB_Price" runat="server" CssClass="col-xs-6"></asp:TextBox>
                            </div>
                            
                            <div class="col-xs-12 libor status CBbot">
                                <label for="" class="col-xs-6">產品規格</label>
                                <asp:TextBox ID="TB_Dimension" runat="server" CssClass="col-xs-6"></asp:TextBox>
                            </div>
                    <div class="col-xs-12 libor CBbot CBarea">
                        <label for="" class="col-xs-12">產品介紹</label>
                            <asp:TextBox ID="TB_Description" runat="server" CssClass="col-xs-12"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor CBbot CBarea CBline">
                        <div></div>
                    </div>
                     <div class="col-xs-12 libor status CBbot CBBTN">
                <asp:Button ID="BT_Confirm" runat="server" Text="立即購買" CssClass="btn btn-warning col-xs-12 sendcareButtom" OnClick="BT_Confirm_Click" />
                         </div>
                    <div class="col-xs-12 libor status CBbot CBBTN">
                            <asp:Button ID="BT_InCar" runat="server" Text="加入購物車" CssClass="btn btn-warning col-xs-12 SBuyCar" OnClick="BT_InCar_Click" />
                        </div>
                            <%--  <div style="display:none">  
                    <asp:Literal ID="L_view" runat="server"></asp:Literal>
                        </div>--%>
                        </div>
                    </div>

                </li>
            </ul>

        </div>
    </div> 
</asp:Content>
