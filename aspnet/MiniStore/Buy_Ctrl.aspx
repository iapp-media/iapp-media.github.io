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
                    <%-- 總金額 -付款方式 -寄送方式 -收件人資訊 -購買商品明細( name*qty = price) --%>
                    <div class="col-xs-12 libor sendadress">
                        <label for="" class="col-xs-5">購買商品明細</label>
                        <div class="col-xs-7">
                            <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" EnableTheming="True" DataKeyNames="ItemID" BorderStyle="Solid" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="商品名稱">
                                        <ItemStyle CssClass="gv_row" Width="40px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Price" HeaderText="單價" HtmlEncode="false" DataFormatString="{0:#,##0.##}">
                                        <ItemStyle CssClass="gv_row" Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AMT" HeaderText="數量">
                                        <ItemStyle CssClass="gv_row" Width="40px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="總價">
                                        <ItemStyle CssClass="gv_row" Width="70px" />
                                    </asp:BoundField>

                                </Columns>

                            </asp:GridView>
                            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                        </div>
                    </div>

                    <div class="col-xs-12 libor payNum">
                        <label for="" class="col-xs-6">總金額</label>
                        <asp:TextBox ID="TB_Paysum" runat="server" CssClass="col-xs-6" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor paytheway">
                        <label for="" class="col-xs-6">付款方式</label>
                        <asp:TextBox ID="TB_Payment" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor sendtheway">
                        <label for="" class="col-xs-6">寄送方式</label>
                        <asp:TextBox ID="TB_Delivery" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor sendadress">
                        <label for="" class="col-xs-5">收件人資訊</label>
                        <div class="col-xs-7">
                            <asp:TextBox ID="TB_Tel" runat="server" placeholder="電話" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_MNO" runat="server" placeholder="郵遞區號" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_Addr" runat="server" placeholder="地址" CssClass="form-control" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="BT_Confirm" runat="server" Text="結帳" CssClass="btn btn-warning col-xs-12 sendcareButtomeEnd" OnClick="BT_Confirm_Click" />
        </li>
    </ul>

</asp:Content>
