<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StoreMana.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="BTNcontent">
        <div class="col-xs-12 libor status CBbot CBBTN">
            <a href="Product_Mana.aspx" class="btn btn-warning col-xs-12 sendcareButtomeEnd">
                <img src="img/Product.png" alt="Alternate Text" class="Menuicon" />商品管理<asp:Literal ID="PCount" runat="server"></asp:Literal></a>
        </div> 
         <div class="col-xs-12 libor status CBbot CBBTN">
            <a href="Cust_Mana.aspx" class="btn btn-warning col-xs-12 sendcareButtomeEnd">
                <img src="img/Client.png" alt="Alternate Text" class="Menuicon" />客戶管理<asp:Literal ID="CCount" runat="server"></asp:Literal></a>
        </div>
         <div class="col-xs-12 libor status CBbot CBBTN">
            <a href="OrderMana.aspx" class="btn btn-warning col-xs-12 sendcareButtomeEnd"> 
                <img src="img/order.png" alt="Alternate Text" class="Menuicon" />訂單管理<asp:Literal ID="OCount" runat="server"></asp:Literal></a>
        </div>
         <div class="col-xs-12 libor status CBbot CBBTN">
            <a href="Msg_Mana.aspx" class="btn btn-warning col-xs-12 sendcareButtomeEnd"> 
                <img src="img/message.png" alt="Alternate Text" class="Menuicon" />訊息管理<asp:Literal ID="MCount" runat="server"></asp:Literal></a>
        </div>
         <div class="col-xs-12 libor status CBbot CBBTN">
            <a href="Setting.aspx" class="btn btn-warning col-xs-12 sendcareButtomeEnd"> 
                <img src="img/setting.png" alt="Alternate Text" class="Menuicon" />設定</a>
        </div>
        <div class="clearfix"></div>
    </div>

   <%-- <span class="MenuNum">99+</span>--%>
</asp:Content>
