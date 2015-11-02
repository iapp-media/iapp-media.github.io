<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Order_Detail.aspx.cs" Inherits="StoreMana.Mini.Order_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Order_Mana.aspx" style="color: white">出貨管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Order_Mana.aspx" style="color: white">訂單管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Order_Mana.aspx?hist=1" style="color: white">歷史訂單</a></li>
            </ul>
        </div>
    </div>
    <!-- WRAPPER -->
    <div id="content">

        <div class="col-xs-12 AllBox BoxBorder">
            <div class="row">
                <div class="content-header">
                    <div>&nbsp;</div>
                </div>
                <div class="container-fluid">
                    <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">
                        <asp:Repeater ID="RP1" runat="server">
                            <HeaderTemplate>
                                <div>
                                    <label>訂單編號:</label>
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Order_No")%>'></asp:Literal>
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="details" runat="server" id="DivDetails">
                                    <div class="col-xs-5 DTimg">
                                        <img src="<%# ShowImg(Eval("Item_ID")) %>" alt="Alternate Text" class="productSize imgH" />
                                    </div>
                                    <div class="col-xs-7">
                                        <h3><%# Eval("Product_Name") %></h3>
                                        <div class="MonBox">
                                            <p>價錢</p>
                                            <span class="TOC">$<%# Eval("Total","{0:0.####}") %></span>
                                        </div>
                                        <div class="MonBox">
                                            <p>數量</p>
                                            <span class="TOC"><%# Eval("QTY") %></span>
                                        </div>
                                    </div> 
                                </div>
                            </ItemTemplate>
                         </asp:Repeater>
                        <asp:Literal ID="L1" runat="server" Visible="false"></asp:Literal>
                        <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
