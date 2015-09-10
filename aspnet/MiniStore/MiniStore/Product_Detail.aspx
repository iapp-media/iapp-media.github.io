<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Product_Detail.aspx.cs" Inherits="MiniStore.Product_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--微店內容頁 -->
 
        <div class="content-header">
            <!--<a href="index.html" class="content-logo"></a>
            <a href="../../../../www.facebook.com/enabled.labs" class="facebook-content"></a>
            <a href="../../../../https@twitter.com/iEnabled" class="twitter-content"></a>-->
        </div>

        <div class="content">
            <div class="decoration"></div>
            <div class="container">
                <div class="slider-controls" data-snap-ignore="true">
                    <div>
                        <asp:Image ID="Image1" runat="server" CssClass="responsive-image" /> 
                        <p class="title-slider-caption">
                            <strong>藝術品</strong>
                            <em>From 羅浮宮</em>
                        </p>
                    </div>

                </div>
            </div>
        </div>


        <div class="container no-bottom">
            <div class="section-title">
                <h2>商品名稱：<asp:Literal ID="LName" runat="server"></asp:Literal></h2>
                <div align="right">
                    <img src="images/like-1.png" width="30" alt="img">99</div>
            </div>
        </div>



        <div class="static-notification-red">
            <p class="center-text uppercase">
                <asp:Literal ID="LPrice" runat="server"></asp:Literal>元</p>
        </div>

        <a href="#" class="button-big-icon icon-setting button-blue">購買</a>

        <div class="container no-bottom">
            <div class="section-title">
                <h4>細節內容</h4>
                <em>長：200公分</em>
                <em>寬：300公分</em>

            </div>
            <div class="decoration"></div>
        </div>

        <div class="static-notification-green">

            <a href="#" class="center-text uppercase"><p class="center-text uppercase">留言</p></a>
        </div>
 
</asp:Content>
