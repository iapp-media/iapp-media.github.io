<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="OrderMana.aspx.cs" Inherits="StoreMana.Mini.OrderMana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Product_Mana.aspx" style="color: white">圖書文具</a></li>
                <li class="swiper-slide col-xs-4"><a href="Product_Add.aspx" style="color: white">享受美食</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">品味生活</a></li>
            </ul>
        </div>
    </div>
    <div class="buydivmove">
        <div class="insidecare col-xs-12">
            <div class="row">
            <div class="list-group">
                <div class="list-group-item list-group-itemUI">
                    <div class="row">
                        <div class="col-xs-4">
                            <p class="BoxLeft">訂單編號</p>
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="TextBox1" runat="server" Class="form-control" placeholder="請輸入訂單編號"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="list-group-item list-group-itemUI">
                    <div class="row">
                        <div class="col-xs-4">
                            <p class="BoxLeft">訂單狀態</p>
                        </div>
                        <div class="col-xs-8">
                            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1">未付款</asp:ListItem>
                                <asp:ListItem Value="2">未發貨</asp:ListItem>
                                <asp:ListItem Value="3">已發貨</asp:ListItem>
                                <asp:ListItem Value="4">交易完成</asp:ListItem>
                                <asp:ListItem Value="5">交易取消</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 libor status CBbot CBBTN">
                    <asp:Button ID="BT_Search" runat="server" Text="搜尋" CssClass="btn btn-warning col-xs-12 SBuyCar" OnClick="BT_Search_Click" />
                </div>
            </div>

            <asp:Repeater ID="RP1" runat="server" OnItemCommand="RP1_ItemCommand" OnItemDataBound="RP1_ItemDataBound">
                <HeaderTemplate>
                    <div>
                        <div class="ProMLtit col-xs-12">
                        <div class="col-xs-4 BoxCenter ListTitle">訂單編號</div>
                        <div class="col-xs-4 BoxCenter ListTitle">買家</div>
                        <div class="col-xs-4 BoxCenter ListTitle">訂單狀態</div>
                        <div class="col-xs-4 BoxCenter ListTitle">下單時間</div>
                        <div class="col-xs-4 BoxCenter ListTitle">付款方式</div>
                        <div class="col-xs-4 BoxCenter ListTitle">轉帳資訊</div>
                            </div>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Literal ID="LIDNO" runat="server" Text='<%# Bind("IDNo") %>' Visible="false"></asp:Literal>
                    <div class="ProMaBOX col-xs-12 ToBoPad">
                    <div class="ProMain col-xs-12">
                        <div class="col-xs-4 ProLPad AlltexC BorTopno BorLeftpno">
                            
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Order_No")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 ProLPad AlltexC BorTopno">
                           
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("User_name")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 ProLPad AlltexC BorTopno BorRightno">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("NSta")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 ProLPad AlltexC BorLeftpno BorBottompno">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("CD")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 ProLPad AlltexC BorBottompno">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Payment")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 ProLPad AlltexC BorRightno BorBottompno">

                            <asp:HyperLink ID="HyperLink1" runat="server" Visible="false" NavigateUrl='<%# ShowDetail(Eval("IDNo")) %>'>
                                     詳細資訊 
                            </asp:HyperLink>
                        </div>
                        <div class="col2">
                            <asp:Button ID="BTCHK" runat="server" Text="訂單確認" CommandName="CN1" Visible="false"  />
                        </div>
                                                <div class="col2">
                            <asp:Button ID="BTEND" runat="server" Text="結案" CommandName="CN2" Visible="false" />
                                                </div>
                        <div id="liSTfooter" class="col-xs-12">
                            <div class="row">
                                <div class="col-xs-4 BoxCenter">
                                   
                                        <asp:Button ID="BT1" runat="server" Text="入帳確認" CommandName="CN3" CssClass="btn btn-warning ThreeBTN " />
                                    
                                </div>
                                <div class="col-xs-4 BoxCenter">
                                    
                                        <asp:Button ID="BT2" runat="server" Text="出貨單列印" CommandName="CN4" CssClass="btn btn-warning  ThreeBTN" />
                                    
                                </div>
                                <div class="col-xs-4 BoxCenter">
                                    
                                        <asp:Button ID="BT3" runat="server" Text="出貨確認" CommandName="CN5" CssClass="btn btn-warning ThreeBTN" />
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
