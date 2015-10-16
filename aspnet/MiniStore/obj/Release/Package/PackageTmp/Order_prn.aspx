<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Order_prn.aspx.cs" Inherits="MiniStore.Order_prn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12  ">
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
                                        <p>購物車明細</p>
                                        <div>
                                            <p>應付金額</p>
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
            </div>
        </li>
    </ul>


</asp:Content>
