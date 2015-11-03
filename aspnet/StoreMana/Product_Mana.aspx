<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Mana.aspx.cs" Inherits="StoreMana.Product_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Product_Add.aspx" style="color: white">商品建檔</a></li>
                <li class="swiper-slide col-xs-4"><a href="Product_Mana.aspx" style="color: white">商品列表</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
            </ul>
        </div>
    </div>
    <div class="allmodify">
        <ul class="buydivmove">
            <li>
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 BTbox">
                            <label class="BTleft">商品類別</label>
                            <asp:DropDownList class="BTright" ID="DL" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-12 libor status CBbot CBBTN">
                            <asp:Button ID="BT_Search" runat="server" Text="搜尋" CssClass="btn btn-warning col-xs-12 SBuyCar" OnClick="BT_Search_Click" />
                        </div>
                        <div class="col-xs-12 libor   CBline">
                            <div></div>
                        </div>
                        <div class="col-xs-12 libor status CBbot CBBTN BorObot">
                            <input type="button" onclick="javascript: location.href = 'Product_Add.aspx'" value="新增商品" class="btn btn-warning col-xs-12 sendcareButtomeEnd" />
                        </div>
                        <div class="col-xs-12 libor paynumber padReset ManaLBG">
                            <asp:Repeater ID="RP1" runat="server">
                                <HeaderTemplate>
                                    <div class="ProMLtit col-xs-12">
                                        <div class="col-xs-12 ListTitle">商品名稱</div> 
                                        <div class="col-xs-4 ListTitle">價格</div>
                                        <div class="col-xs-4 ListTitle">建檔日期</div>
                                        <div class="col-xs-4 ListTitle">&nbsp;</div>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="ProMaBOX col-xs-12">
                                        <div class="ProMain col-xs-12">
                                            <div class="col-xs-12 ProLPad TtitleC BorTopno BorRightno BorLeftpno">
                                                <div class="SHead">
                                                    <img src='<%# ShowImg(Eval("FilePath"))%>' />
                                                </div>
                                                <span>
                                                    <asp:Literal ID="Literal1" runat="server" Text='<%# ShowName(Eval("Product_Name"))%>'></asp:Literal>
                                                </span>
                                            </div>

                                            <div class="col-xs-4 ProLPad TRC BorLeftpno BorBottompno">
                                                NT$<asp:Literal ID="Literal2" runat="server" Text='<%# ShowPrice(Eval("Price"))%>'></asp:Literal>
                                            </div>
                                            <div class="col-xs-4 ProLPad TGray BorBottompno">
                                                <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("CDate")%>'></asp:Literal>
                                            </div>

                                            <div class="col-xs-4 ProLPad TOCCenter BorRightno BorBottompno">
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# ShowDetail(Eval("IDNo")) %>' CssClass="TOC">
                                     詳細資訊
                                                </asp:HyperLink>
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
            </li> 
        </ul>
    </div>

</asp:Content>
