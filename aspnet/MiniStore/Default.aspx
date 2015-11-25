<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiniStore.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input[type=number] {
            -moz-appearance: textfield;
        }

            input[type=number]::-webkit-inner-spin-button,
            input[type=number]::-webkit-outer-spin-button {
                -webkit-appearance: none;
                margin: 0;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="swiper-container">
        <div class="swiper-wrapper">
            <asp:Literal ID="L_Cate" runat="server"></asp:Literal>
        </div>
    </div>
    <!-- 至購物車 -->
    <asp:Literal ID="LCarLink" runat="server"></asp:Literal>
    <div>
        <div class="product" runat="server" id="Basic">
            <div id="container">
                <asp:Literal ID="LData" runat="server"></asp:Literal>
            </div>
        </div>

        <div class="product" runat="server" id="Fast" visible="false">
            <div id="FastBox">
                <asp:Literal ID="Layout_fast" runat="server"></asp:Literal>
                <div class="clearfix"></div>
                <div class="col-xs-12 libor status CBbot CBBTN">
                    <asp:Button ID="BTFast" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtomeEnd" OnClick="BTFast_Click" />
                </div>
            </div>
        </div>
    </div>
    <script src="js/act.js"></script>
</asp:Content>

