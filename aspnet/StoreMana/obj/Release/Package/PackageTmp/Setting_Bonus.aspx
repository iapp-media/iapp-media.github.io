<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting_Bonus.aspx.cs" Inherits="StoreMana.Setting_Bonus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide"><a href="Setting.aspx" style="color: white">參數設定</a></div>
                <div class="swiper-slide"><a href="Setting_Bonus.aspx" style="color: white">點數設定</a></div>
                <div class="swiper-slide"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></div>
                <div class="swiper-slide"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></div>
            </div>
        </div>
    </div>
    <div class="buydivmove">
        <div class="col-xs-12 insidecare">
            <div class="row">
                <div class="col-xs-12  BTbox">
                    <asp:CheckBox ID="ISBonus" runat="server" />
                    <p class="BTleft">啟用點數活動</p>
                </div>
                <div class="col-xs-12 BTbox">
                    <p class="BTleft">點數折率:</p>
                    <asp:TextBox ID="TBPoint" runat="server" placeholder="1"></asp:TextBox>點折<asp:TextBox ID="TBPrice" runat="server" placeholder="1"></asp:TextBox>元 
                    <p style="color: red;">折扣上限為訂單金額10%</p>
                </div> 
                <asp:Button ID="BTSave" runat="server" Text="儲存" CssClass="btn btn-warning SBuyCar2" OnClick="BTSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
