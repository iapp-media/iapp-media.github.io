<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Detail.aspx.cs" Inherits="MiniStore.Buy_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12 insidecare">
                <div class="row">
                    <div class="col-xs-12 libor productsinside">
                        <div id="slider">
                            <div class="control_next glyphicon glyphicon-chevron-right"></div>
                            <div class="control_prev glyphicon glyphicon-chevron-left"></div>
                            <ul>
                                <li>
                                    <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" /></li>
                                <li>
                                    <img src="#" alt="Alternate Text" /></li>
                                <li>
                                    <img src="#" alt="Alternate Text" /></li>
                                <li>
                                    <img src="#" alt="Alternate Text" /></li>
                            </ul>
                        </div>
                        <div class="slider_option">
                            <input type="checkbox" id="checkbox" />
                        </div>

                        <h1 class="col-xs-6">
                            <asp:Literal ID="L_Name" runat="server"></asp:Literal></h1> 
                    </div>

                    <div class="col-xs-12 libor sendadress">
                        <div class="col-xs-12">
                            <asp:Button ID="BT_MSG" runat="server" Text="問與答" CssClass="col-xs-4" OnClick="BT_MSG_Click" />
                            <asp:Button ID="BT_Like" runat="server" Text="LIKE" CssClass="col-xs-4" />
                            <asp:Button ID="BT_SHARE" runat="server" Text="分享" CssClass="col-xs-4" />
                        </div>
                    </div>
                      <div class="col-xs-12 libor productNum">
                        <label for="" class="col-xs-6">商品名稱</label>
                        <asp:TextBox ID="TB_Name" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor productNum">
                        <label for="" class="col-xs-6">商品售價</label>
                        <asp:TextBox ID="TB_Price" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor status">
                        <label for="" class="col-xs-6">商品介紹</label>
                        <asp:TextBox ID="TB_Description" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor status">
                        <label for="" class="col-xs-6">商品規格</label>
                        <asp:TextBox ID="TB_Dimension" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>  
                    <asp:Literal ID="L_view" runat="server"></asp:Literal>
                </div>
            </div>
            <asp:Button ID="BT_Confirm" runat="server" Text="立即購買" CssClass="btn btn-warning col-xs-5 sendcareButtom" OnClick="BT_Confirm_Click" />
            <div class=" col-xs-2"></div>
            <asp:Button ID="BT_InCar" runat="server" Text="加入購物車" CssClass="btn btn-warning col-xs-5 sendcareButtom" OnClick="BT_InCar_Click" />
        </li>
    </ul>
</asp:Content>
