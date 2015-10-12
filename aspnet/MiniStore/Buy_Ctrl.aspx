<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Ctrl.aspx.cs" Inherits="MiniStore.Buy_Ctrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12  ">
                <div class="row">
                    <div class="col-xs-12 libor productsinside">
                        <div class="col-xs-6">
                            <!-- 輪播圖 -->
                            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                <!-- Wrapper for slides -->
                                <div class="carousel-inner" role="listbox">
                                    <asp:Literal ID="L" runat="server"></asp:Literal>
                                </div>
                                <!-- Controls -->
                                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                            </div>
                        </div>

                        <%--                        <h1 class="col-xs-6">
                            <asp:Literal ID="L_Name" runat="server"></asp:Literal></h1>
                        <p class="col-xs-6">
                            <asp:Literal ID="L_Description" runat="server"></asp:Literal></p>
                        <span class="col-xs-6">
                            <asp:Literal ID="L_Price" runat="server"></asp:Literal></span>--%>
                    </div>
                    <%-- 總金額 -付款方式 -寄送方式 -收件人資訊 -購買商品明細( name*qty = price) --%>

                    <div class="col-xs-12 libor payNum">
                        <label for="" class="col-xs-6">總金額</label>
                        <asp:TextBox ID="TB_Paysum" runat="server" CssClass="col-xs-6"  Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor paytheway">
                        <label for="" class="col-xs-6">付款方式</label>
                        <asp:TextBox ID="TB_Payment" runat="server" CssClass="col-xs-6"  ></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor sendtheway">
                        <label for="" class="col-xs-6">寄送方式</label>
                        <asp:TextBox ID="TB_Delivery" runat="server" CssClass="col-xs-6"  ></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor sendadress">
                        <label for="" class="col-xs-5">收件人資訊</label>
                        <div class="col-xs-7">
                            <asp:TextBox ID="TB_Tel" runat="server" placeholder="電話" CssClass="col-xs-12"  ></asp:TextBox>
                            <asp:TextBox ID="TB_MNO" runat="server" placeholder="郵遞區號" CssClass="col-xs-12" ></asp:TextBox>
                            <asp:TextBox ID="TB_Addr" runat="server" placeholder="地址" CssClass="form-control" Rows="3" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 libor sendadress">
                        <label for="" class="col-xs-5">購買商品明細</label>
                        <div class="col-xs-7">
                            <asp:Literal ID="L_Detail" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="BT_Confirm" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtomeEnd" OnClick="BT_Confirm_Click" />
        </li>
    </ul>

</asp:Content>
