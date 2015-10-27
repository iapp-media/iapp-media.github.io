<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Product_Detail.aspx.cs" Inherits="MiniStore.Product_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12  ">
                <div class="row" runat="server" id="view2" visible="false">
                    <div class="col-xs-12"> 
                        <asp:Repeater ID="RP1" runat="server">
                            <HeaderTemplate>
                                <div class="col2">運費規則</div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row1">
                                    <div class="col2">
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Memo")%>'></asp:Literal> 
                                    </div> 
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                        <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource> 
                    </div>
                    <div class="col-xs-12"> 
                        <asp:Repeater ID="RP2" runat="server">
                            <HeaderTemplate>
                                <div class="col2">付款方式</div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row1">
                                    <div class="col2">
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Memo")%>'></asp:Literal> 
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
