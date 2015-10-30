<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Order_prn.aspx.cs" Inherits="MiniStore.Order_prn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
       
     <div class="col-xs-12 libor ContentTop">
        <h1 class="col-xs-10">購物車明細</h1>
    </div>
    <ul class="buydivmove">
        <li class="productcare col-xs-12 insidecare AllBGC">
            <div class="col-xs-12 padTOP">
                <div class="row">
                    <div class="col-xs-12">
                                                        
                                     
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Repeater ID="RP1" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row">

                                    <div class="ListLen">
                                        <div class="col-xs-4">
                                            <div class="row">
                                                <p class="BoxLeft TBC">應付金額</p>
                                            </div>
                                        </div>
                                        <div class="col-xs-8 padReset">
                                            <div class="ValueRight TBC">
                                               
                                                <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Cost")%>' ></asp:Literal>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <div class="ListLen">
                                        <div class="col-xs-4">
                                            <div class="row">
                                                <p class="BoxLeft TBC">付款方式</p>
                                            </div>
                                        </div>
                                        <div class="col-xs-8 padReset">
                                            <div class="ValueRight TRBC">
                                                <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("Payment")%>'></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="ListLen">
                                        <div class="col-xs-4">
                                            <div class="row">
                                                <p class="BoxLeft TBC">運送方式</p>
                                            </div>
                                        </div>
                                        <div class="col-xs-8 padReset">
                                            <div class="ValueRight TRBC" >
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
                </div>
                <div class="row BorObot">
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
                <div class="PayPad">
                <div class="row PayBGCbot" runat="server" id="Div_Send_AC">
                    <h3 class="BoxTitle TBC">填寫轉帳資訊</h3>
                    <div class="col-xs-12">
                        <div class="row">
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <p class="BoxLeft">銀行帳號:</p>
                                </div>
                                <div class="col-xs-8">
                                    <div class="ValueRight ">
                                        <asp:TextBox ID="TBACC" runat="server" placeholder="最後五個數字碼" CssClass="ValTPad"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <p class="BoxLeft">轉帳金額:</p>
                                </div>
                                <div class="col-xs-8">
                                    <div class="ValueRight">
                                        <asp:TextBox ID="TBTotal" runat="server" placeholder="轉帳金額" CssClass="ValTPad"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        <div class="ListLen">
                            <div class="col-xs-4">
                                <p class="BoxLeft">轉帳日期:</p>
                            </div>
                            <div class="col-xs-8">
                                <div class="ValueRight">
                                    <asp:TextBox ID="TBACCDate" runat="server" placeholder="2015/02/20" CssClass="ValTPad"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                            <div class="ListLen">
                                <div class="col-xs-4">
                                    <p class="BoxLeft">輸入驗證碼:</p>

                                </div>
                                <div class="col-xs-8">
                                    <div class="ValueRight">
                                        <asp:TextBox ID="TBScode" runat="server" placeholder="輸入驗證碼" CssClass="ValTPad"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="ListLen">
                                     <img src="img/codee.jpg" alt="Alternate Text" class="codeeIMG"/>
                                </div>
            </div>
                        </div>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 CBBTN">
                    <div class="row">
                        <asp:Button ID="Button1" runat="server" Text="送出" OnClick="BTsend_Click" CssClass="btn btn-warning btn-lg btn-block sendcareButtom" />
                    </div>
                </div>
            </div>
        </li>
    </ul>


</asp:Content>
