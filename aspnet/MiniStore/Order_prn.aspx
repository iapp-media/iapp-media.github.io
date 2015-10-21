<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Order_prn.aspx.cs" Inherits="MiniStore.Order_prn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12  ">
                <div class="row">
                    <div class="col-xs-12">
                                                                <p>購物車明細</p>
                                        <div  style="color:red">
                                            要放商品明細抄buy_ctrl
                                        </div>
                        </div></div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Repeater ID="RP1" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row1">
                                    <div class="col2">
                                        <p>付款方式</p>
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Payment")%>'></asp:Literal>
                                        <p>運送方式</p>
                                        <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("Delivery")%>'></asp:Literal>
                                                                                    <p>應付金額</p>
                                            <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("Cost")%>'></asp:Literal>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                        <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Repeater ID="RP2" runat="server">
                            <HeaderTemplate>
                                <p>收件人資訊</p>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row1">
                                    <div class="col2">
                                        <p>姓名</p>
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Contact_Name")%>'></asp:Literal>
                                        <p>電話</p>
                                        <asp:Literal ID="Literal6" runat="server" Text='<%# Bind("TEL")%>'></asp:Literal>
                                        <p>地址</p>
                                        <asp:Literal ID="Literal7" runat="server" Text='<%# Bind("Addr")%>'></asp:Literal>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="L2" runat="server" Visible="false"></asp:Literal>
                        <asp:SqlDataSource ID="SD2" runat="server"></asp:SqlDataSource>
                    </div>
                </div>
                <div class="row" runat="server" id="Div_Store_ACInfo">
                    <div class="col-xs-12">
                        <asp:Repeater ID="RP3" runat="server">
                            <HeaderTemplate>
                                <p>轉帳/匯款資訊</p>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row1">
                                    <div class="col2">
                                        <p>銀行</p>
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Bank_Name")%>'></asp:Literal>
                                        <p>銀行代碼</p>
                                        <asp:Literal ID="Literal6" runat="server" Text='<%# Bind("Bank_No")%>'></asp:Literal>
                                         <p>銀行戶名</p>
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Bank_ACName")%>'></asp:Literal>
                                        <p>銀行帳號</p>
                                        <asp:Literal ID="Literal7" runat="server" Text='<%# Bind("Bank_ACC")%>'></asp:Literal>
                                          
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="L3" runat="server" Visible="false"></asp:Literal>
                        <asp:SqlDataSource ID="SD3" runat="server"></asp:SqlDataSource>
                    </div>
                </div>
                <div class="row" runat="server" id="Div_Send_AC">
                    <label for="" class="col-xs-5">填寫轉帳通知:</label>
                    <div class="col-xs-7">
                        <div class="col-xs-12"> 
                            <asp:TextBox ID="TBACC" runat="server" placeholder="帳號後五碼:" CssClass="col-xs-6"></asp:TextBox>
                            <div class="col-xs-6">(您使用的的銀行帳號（卡號）最後五個數字碼)</div>
                            <asp:TextBox ID="TBTotal" runat="server" placeholder="轉帳金額" CssClass="col-xs-5"></asp:TextBox>
                            <asp:TextBox ID="TBACCDate" runat="server" placeholder="轉帳日期" CssClass="col-xs-5"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar col-xs-2"></span>
                            <asp:Button ID="BTsend" runat="server" Text="送出" OnClick="BTsend_Click" CssClass="btn btn-warning col-xs-2 sendcareButtom" />
                        </div>
                        <div class="col-xs-12">
                            <asp:TextBox ID="TBScode" runat="server" placeholder="輸入驗證碼" CssClass="col-xs-6"></asp:TextBox>
                            <div>123456</div>
                        </div>
                    </div> 
                </div>
            </div>
        </li>
    </ul>


</asp:Content>
