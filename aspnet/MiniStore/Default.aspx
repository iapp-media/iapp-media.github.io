<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiniStore.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <ul class="buydivmove"> 
        <li class="product">
            <div id="container">

                <asp:Literal ID="LData" runat="server"></asp:Literal>

<%--                 <div class='item'>
                    <div class='imgcenter'>
                        <div>
                            <a class='#' href="#"><img class="item-pic" src='img/2531170_203204624000_2.jpg' /></a>
                        </div>
                        <div class="col-xs-12 description">
                            <div class="col-xs-12">
                                <div class="row">
                                    <p class='describe'>我叫烤雞</p>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="row">
                                    <input type="checkbox" id="c3" name="cc" />
                                    <label for="c3"></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <p class='iapp-name'>NT$50</p>
                            <button class="buy">購買</button>
                        </div>
                    </div>
                </div>
                <!-- Mobile版 瀑布流 -->
                <div class='item'>
                    <div class='imgcenter'>
                        <div>
                            <a class='#' href="#"><img class="item-pic" src='img/Noodles.jpg' /></a>
                        </div>
                        <div class="col-xs-12 description">
                            <div class="col-xs-12">
                                <div class="row">
                                    <p class='describe'>我叫拉麵拉麵叫我我叫拉麵拉麵叫我我叫拉麵拉麵叫我我叫拉麵拉麵叫我我叫拉麵拉麵叫我</p>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="row">
                                    <input type="checkbox" id="c2" name="cc" />
                                    <label for="c2"></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <p class='iapp-name'>NT$12000</p>
                            <button class="buy">購買</button>
                        </div>
                    </div>
                </div>
                <div class='item'>
                    <div class='imgcenter'>
                        <div>
                            <a class='#' href="#"><img class="item-pic" src='img/cloth.jpg' /></a>
                        </div>
                        <div class="col-xs-12 description">
                            <div class="col-xs-12">
                                <div class="row">
                                    <p class='describe'>我叫洋裝</p>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="row">
                                    <input type="checkbox" id="c1" name="cc" />
                                    <label for="c1"></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <p class='iapp-name'>NT$500000</p>
                            <button class="buy">購買</button>
                        </div>
                    </div>
                </div>--%>
            </div>
        </li>
      </ul>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
</asp:Content>
