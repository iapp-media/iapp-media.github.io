<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Order_prn.aspx.cs" Inherits="MiniStore.Order_prn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12">
                <div class="row">
                    <div class="col-xs-12">
                                                                <h1 class="BoxTitle">購物車明細</h1>
                                        <div style="color:red">
                                            要放商品明細抄buy_ctrl
                                        </div>
                        </div></div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Repeater ID="RP1" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row">
                                    <div class="ListLen">
                                        <div class="col-xs-4">
                                            <p class="BoxLeft">付款方式</p>
                                        </div>
                                        <div class="col-xs-8">
                                            <div class="ValueRight">
                                                <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Payment")%>'></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="ListLen">
                                        <div class="col-xs-4">
                                            <p class="BoxLeft">運送方式</p>
                                        </div>
                                        <div class="col-xs-8">
                                            <div class="ValueRight">
                                                <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("Delivery")%>'></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="ListLen">
                                        <div class="col-xs-4">
                                            <p class="BoxLeft">應付金額</p>
                                        </div>
                                        <div class="col-xs-8">
                                            <div class="ValueRight">
                                                <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("Cost")%>'></asp:Literal>
                                            </div>
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
                                <p class="BoxLeft">收件人資訊</p>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="ListLen">
                                    <div class="col-xs-4">
                                        <p class="BoxLeft">姓名</p>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="ValueRight">
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Contact_Name")%>'></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="ListLen">
                                    <div class="col-xs-4">
                                        <p class="BoxLeft">電話</p>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="ValueRight">
                                            <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("TEL")%>'></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                                <div class="ListLen">
                                    <div class="col-xs-4">
                                        <p class="BoxLeft">地址</p>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="ValueRight">
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
                    <div class="col-xs-12">
                        <asp:Repeater ID="RP3" runat="server">
                            <HeaderTemplate>
                                <p class="BoxLeft">轉帳/匯款資訊</p>
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
                <div class="row" runat="server" id="Div_Send_AC">
                    <label for="" class="col-xs-5 BoxLeft">填寫轉帳通知:</label>
                    <div class="col-xs-12">
                        <div class="ListLen">
                            <div class="col-xs-4">
                                <asp:TextBox ID="TBACC" runat="server" placeholder="帳號後五碼:"></asp:TextBox>
                            </div>
                            <div class="col-xs-8 ValueText">
                                <div class="row">(您使用的的銀行帳號（卡號）最後五個數字碼)</div>
                            </div>
                        </div>
                        <div class="ListLen">
                            <div class="col-xs-12">
                                <asp:TextBox ID="TBTotal" runat="server" placeholder="轉帳金額"></asp:TextBox>
                            </div>
                        </div>
                        <div class="ListLen">
                            <div class="col-xs-4">
                                
                                <asp:TextBox ID="TBACCDate" runat="server" placeholder="轉帳日期" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="ListLen">
                            <div class="col-xs-4">
                                <asp:TextBox ID="TBScode" runat="server" placeholder="輸入驗證碼"></asp:TextBox>
                            </div>
                            <div class="col-xs-8 ValueText">
                                <div class="row">123456</div>
                            </div>
                        </div>
                        <div class="ListLen">
                            <span class="glyphicon glyphicon-calendar col-xs-12"></span>
                        </div>
                        <div class="ListLen">
                            <asp:Button ID="Button1" runat="server" Text="送出" OnClick="BTsend_Click" CssClass="btn btn-warning btn-lg btn-block sendcareButtom" />
                        </div>
                    </div> 
                </div>
            </div>
        </li>
    </ul>


</asp:Content>
