<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting_Gerent.aspx.cs" Inherits="StoreMana.Setting_Gerent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></li>
            </ul>
        </div>
    </div>--%>
    <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide"><a href="Setting.aspx" style="color: white">參數設定</a></div>
                <div class="swiper-slide"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></div>
                <div class="swiper-slide"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></div>
            </div>
        </div>
    </div>
    <div class="buydivmove">
        <div class="col-xs-12 insidecare">
            <div class="row">
                <div class="Gerentbox AllBGC">
                    <div class="col-xs-4">
                        <div class="row">
                            <p class="BoxLeft">iApp帳號</p>
                        </div>
                    </div>
                    <asp:TextBox ID="TB_ACC" runat="server" CssClass="col-xs-8"></asp:TextBox>
                    <div class="clearfix"></div>
                </div>
                <div class="AllBGC BorObot SetAdd">
                    <asp:Button ID="BT_Confirm" runat="server" Text="加入" CssClass="btn btn-warning SBuyCar2" OnClick="BT_Confirm_Click" />
                </div>
                <div id="GerBot">
                    <asp:Repeater ID="RP1" runat="server">
                        <HeaderTemplate>
                            <div>
                                <p class="BotTitle">管理員帳號</p>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                
                                    <p class="BotTitle"><%# Eval("Account") %></p>
                        
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="L1" runat="server" Visible="false"></asp:Literal>
                    <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
