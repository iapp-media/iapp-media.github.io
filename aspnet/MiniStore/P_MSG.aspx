﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="P_MSG.aspx.cs" Inherits="MiniStore.P_MSG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
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
    <div class="col-xs-12 libor ContentTop">
                                <img src="img/backarrow.png" alt="Alternate Text" class="col-xs-2" onclick="javascript:history.back()" />

                                <h1 class="col-xs-10">問與答</h1>

                            </div>
    <div class="col-xs-12 promana">
        <div class="row">

            <ul>
                <li class="productcare">
                    <div class="col-xs-12 insidecare FBMargin">
                        <div class="row">
                            
                            <div class="col-xs-12 libor payNum pagetitle">
                                <asp:Literal ID="L_Puc" runat="server"></asp:Literal>
                            </div>
                            <asp:Repeater ID="RP1" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="contentBG">
                                        <div class="col-xs-12 libor payNum Issue QCTot">
                                            <span class="spansizemidleft">問題</span>
                                            <span class="spansizebig">客戶A</span>
                                            <span class="spansizemid"><%# Eval("agoday") %></span>
                                            <p><%# Eval("Question") %></p>
                                        </div>
                                        <div class="col-xs-12 libor payNum Issue QCTBot">
                                            <span class="spansizemidleft">回覆</span>
                                            <span class="spansizebig">店家B</span>
                                            <span class="spansizemid">回覆日期</span>
                                            <p><%# Eval("Ans") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                        </div>
                    </div>
                </li>
            </ul>
            <div class="col-xs-12 fixBar">
                <asp:TextBox ID="tbQuen" runat="server" AutoPostBack="true" Class="form-control" Rows="3"></asp:TextBox>
                <div class="fRight">
                <img src="img/send.png" alt="Alternate Text" />
                    </div>
                <%--<asp:Button ID="btsend" runat="server" Text="發送" OnClick="btsend_Click" CssClass="btn btn-warning col-xs-2 sendcareButtom" OnClientClick="fun2()" />--%>

            </div>
        </div>
    </div>
</asp:Content>
