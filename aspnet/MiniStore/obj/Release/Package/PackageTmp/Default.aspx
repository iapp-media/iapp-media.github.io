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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <asp:Literal ID="L_Cate" runat="server"></asp:Literal>
            </div>
            <!-- Add Arrows -->
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
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
        <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
        <div class="product" runat="server" id="Fast" visible="false">
            <div id="FastBox">
                <asp:Literal ID="Layout_fast" runat="server"  visible="false"></asp:Literal>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate> 
                <asp:Repeater ID="RPFast_Drink" runat="server" OnItemCommand="RPFast_Drink_ItemCommand" OnItemDataBound="RPFast_Drink_ItemDataBound">
                    <ItemTemplate>
                       <div class="details col-xs-12">
                        <div class="DTimg">
                            <a href='Buy_detail.aspx?entry=<%# Eval("IDNo") %>&SN=OfficACC'>
                                <img class="productSize imgH" src='<%# Eval("FilePath") %>' /></a>
                        </div>
                        <div class="Detailsmid">
                            <h3><%# Eval("Product_Name") %></h3>
                            <div class="MonBoxL">
                                <span class="TOC"><%# Eval("Price") %></span>
                            </div>
                            <%--<div class="clearfix"></div>--%>
                            <div class="addbox">
                              <asp:Literal ID="ItemIDNo" runat="server" Text='<%# Eval("IDNo") %>' Visible="false"></asp:Literal> 
                                <asp:Button ID="BTplus" runat="server" Text="+"  CssClass="input-number-decrement" CommandName="CNplus"/>
                                <div class="clearfix"></div>

<%--                                <span class="input-number-decrement" onclick='minus(<%# Eval("IDNo") %>)'>–</span>--%> 
<%--                                <input id="Num_<%# Eval("IDNo") %>" name="" type="number" value="0"  value='<%# Eval("carbaby") %>'  class="input-number" disabled="disabled" />--%>
<%--                                <span class="input-number-increment" onclick='plus(<%# Eval("IDNo") %>,9999)'>+ </span>--%>
                             
                            </div> 
                             <div class="radioboxUI"> 
                                <asp:RadioButtonList ID="RB_DrinkSize" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" > 
                                </asp:RadioButtonList>
                            </div>
                            <div class="radioboxUI"> 
                                <asp:RadioButtonList ID="RB_DrinkIce" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" > 
                                </asp:RadioButtonList>
                            </div>   
                            <div class="radioboxUI"> 
                                <asp:RadioButtonList ID="RB_DrinkSugar" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" > 
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    </ItemTemplate>
                </asp:Repeater></ContentTemplate></asp:UpdatePanel>
                <div class="clearfix"></div>
                <div class="col-xs-12 libor status CBbot CBBTN">
                    <asp:Button ID="BTFast" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtomeEnd" OnClick="BTFast_Click" />
                </div>
            </div>
        </div>
    </div>
    <script src="js/act.js"></script>
</asp:Content>

