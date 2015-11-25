<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="StoreMana.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></div>
                <div class="swiper-slide"><a href="Setting.aspx" style="color: white">參數設定</a></div>
                <div class="swiper-slide"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></div>
                <div class="swiper-slide"><a href="Setting_Bonus.aspx" style="color: white">點數設定</a></div>
            </div>
        </div>
    </div>

    <!-- WRAPPER -->
    <div class="buydivmove">
        <div class="col-xs-12 insidecare">
            <div class="row">
                <div class="col-xs-12 BTbox">
                    <p class="BTleft">商品類別</p>
                    <div class="BTright SettAdd">
                        <asp:TextBox ID="TB_Cate" runat="server" CssClass=""></asp:TextBox> 
                        <asp:Button ID="BTplus" runat="server" Text="+" CssClass="btn btn-default" OnClick="BTplus_Click" /> 
                    </div>
                </div>
                <div class="col-xs-12 AllBGC">
                    <div class="row">
                        <div class="SetTable">
                            <asp:CheckBoxList ID="CBL_Cate" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"></asp:CheckBoxList>
                            <asp:Button ID="BTDEL" runat="server" Text="刪除" CssClass="btn btn-warning SBuyCar2" OnClick="BTDEL_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
