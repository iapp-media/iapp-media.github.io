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

    <div class="col-xs-12 libor ContentTop">
        <h1 class="col-xs-10">購買明細</h1>
    </div>
    <ul class="buydivmove ODetailTop">
        <li class="productcare col-xs-12 insidecare AllBGC">
            <div class="row">
                <asp:Repeater ID="RP4" runat="server">
                    <ItemTemplate>
                        <div class="details" runat="server" id="DivDetails">
                            <div class="col-xs-5">
                                <img src="<%# ShowImg(Eval("Item_ID")) %>" alt="Alternate Text" class=" imgH" />
                            </div>
                            <div class="col-xs-7">
                                <h3><%# Eval("Name") %></h3>
                                <div class="MonBox">
                                    <p>價錢</p>
                                    <span runat="server" id="Dtotal" class="TOC">$<%# Eval("Total","{0:0.####}") %></span>
                                </div>
                                <div class="MonBox">
                                    <p>數量</p>
                                    <span runat="server" id="Qty" class="TOC"><%# Eval("qty") %></span>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="L4" runat="server" Visible="false"></asp:Literal>
                <asp:SqlDataSource ID="SD4" runat="server"></asp:SqlDataSource>
            </div>
            <div>
                <asp:Repeater ID="RP1" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="row">
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <p class="BoxLeft TBC">應付金額</p>
                                </div>
                                <div class="col-xs-8">
                                    <div class="ValueRight TBC">
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Cost")%>'></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <p class="BoxLeft TBC">付款方式</p>
                                </div>
                                <div class="col-xs-8">
                                    <div class="ValueRight TRBC">
                                        <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("Payment")%>'></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <p class="BoxLeft TBC">運送方式</p>
                                </div>
                                <div class="col-xs-8 ">
                                    <div class="ValueRight TRBC">
                                        <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("Delivery")%>'></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-12 libor  CBline ">
                                <div class="row"></div>
                            </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
            </div>

            <div class="row">
                <div class="col-xs-12">

                    <asp:Repeater ID="RP2" runat="server">
                        <HeaderTemplate>
                            <div class="ListLen">
                                <p class="BoxLeft TBC">收件人資訊</p>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <div class="row">
                                        <p class="BoxLeft">姓名</p>
                                    </div>
                                </div>
                                <div class="col-xs-8 padReset">
                                    <div class="ValueRight TRBC">
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Contact_Name")%>'></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <div class="row">
                                        <p class="BoxLeft">電話</p>
                                    </div>
                                </div>
                                <div class="col-xs-8 padReset">
                                    <div class="ValueRight TRBC">
                                        <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("TEL")%>'></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <div class="row">
                                        <p class="BoxLeft">地址</p>
                                    </div>
                                </div>
                                <div class="col-xs-8 padReset">
                                    <div class="ValueRight TRBC">
                                        <asp:Literal ID="Literal8" runat="server" Text='<%# Bind("Addr")%>'></asp:Literal>
                                    </div>
                                </div>
                            </div>


                            </div>
                                </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="L2" runat="server" Visible="false"></asp:Literal>
                    <asp:SqlDataSource ID="SD2" runat="server"></asp:SqlDataSource>
                </div>
            </div>

            <div class="row" runat="server" id="Div_Store_ACInfo">
                <div class="PayPad">
                    <div class="col-xs-12 PayBGC padReset AllMar">
                        <asp:Repeater ID="RP3" runat="server">
                            <HeaderTemplate>
                                <h3 class="BoxTitle TBC">轉帳/匯款資訊</h3>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="ListLen">
                                    <div class="col-xs-4">
                                        <p class="BoxLeft">銀行</p>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="ValueRight">
                                            <asp:Literal ID="Literal9" runat="server" Text='<%# Bind("Bank_Name")%>'></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="ListLen">
                                    <div class="col-xs-4">
                                        <p class="BoxLeft">銀行代碼</p>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="ValueRight">
                                            <asp:Literal ID="Literal10" runat="server" Text='<%# Bind("Bank_No")%>'></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="ListLen">
                                    <div class="col-xs-4">
                                        <p class="BoxLeft">銀行戶名</p>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="ValueRight">
                                            <asp:Literal ID="Literal6" runat="server" Text='<%# Bind("Bank_ACName")%>'></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="ListLen">
                                    <div class="col-xs-4">
                                        <p class="BoxLeft">銀行帳號</p>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="ValueRight">
                                            <asp:Literal ID="Literal11" runat="server" Text='<%# Bind("Bank_ACC")%>'></asp:Literal>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="L3" runat="server" Visible="false"></asp:Literal>
                        <asp:SqlDataSource ID="SD3" runat="server"></asp:SqlDataSource>
                    </div>
                </div>
            </div>

        </li>
    </ul>

</asp:Content>
