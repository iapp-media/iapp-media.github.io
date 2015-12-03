<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting_Gerent.aspx.cs" Inherits="StoreMana.Setting_Gerent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide" data-src="Setting.aspx">參數設定</div>
                <div class="swiper-slide" data-src="Setting_Gerent.aspx">帳號管理</div>
                <div class="swiper-slide" data-src="Setting_SInfo.aspx">微店管理</div>
                <div class="swiper-slide" data-src="Setting_Bonus.aspx">點數設定</div>
            </div>
            <!-- Add Arrows -->
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
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
