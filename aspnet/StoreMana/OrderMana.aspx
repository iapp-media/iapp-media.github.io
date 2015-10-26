<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="OrderMana.aspx.cs" Inherits="StoreMana.Mini.OrderMana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div class="buydivmove">
        <div class="productcare col-xs-12">
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
                <div class="list-group-item list-group-itemUI">
                    <asp:Button ID="BT_Search" runat="server" Text="Search" CssClass="btn btn-default btn-lg btn-block ButModdle" OnClick="BT_Search_Click" />
                </div>
            </div>

            <asp:Repeater ID="RP1" runat="server" OnItemCommand="RP1_ItemCommand" OnItemDataBound="RP1_ItemDataBound">
                <HeaderTemplate>
                    <div>
                        <div class="col-xs-4 BoxCenter ListTitle">訂單編號</div>
                        <div class="col-xs-4 BoxCenter ListTitle">買家</div>
                        <div class="col-xs-4 BoxCenter ListTitle">訂單狀態</div>
                        <div class="col-xs-4 BoxCenter ListTitle">下單時間</div>
                        <div class="col-xs-4 BoxCenter ListTitle">付款方式</div>
                        <div class="col-xs-4 BoxCenter ListTitle">轉帳資訊</div>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Literal ID="LIDNO" runat="server" Text='<%# Bind("IDNo") %>' Visible="false"></asp:Literal>
                    <div>
                        <div class="col-xs-4 BoxCenter">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Order_No")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 BoxCenter">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("User_name")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 BoxCenter">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("NSta")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 BoxCenter">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("CD")%>'></asp:Literal>
                        </div>
                        <div class="col-xs-4 BoxCenter">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Payment")%>'></asp:Literal>
                        </div>
                        <div class="col2">

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
                                <div class="row">
                                    <asp:Button ID="BT1" runat="server" Text="入帳確認" CommandName="CN3" CssClass="btn btn-default btn-lg ButModdle " />
                                </div>
                            </div>
                            <div class="col-xs-4 BoxCenter">
                                <div class="row">
                                    <asp:Button ID="BT2" runat="server" Text="出貨單列印" CommandName="CN4" CssClass="btn btn-default btn-lg  ButModdle " />
                                </div>
                            </div>
                            <div class="col-xs-4 BoxCenter">
                                <div class="row">
                                    <asp:Button ID="BT3" runat="server" Text="出貨確認" CommandName="CN5" CssClass="btn btn-default btn-lg  ButModdle " />
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
</asp:Content>
