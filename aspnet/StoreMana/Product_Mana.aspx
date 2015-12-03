<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Mana.aspx.cs" Inherits="StoreMana.Product_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide" data-src="Product_Add.aspx">商品建檔</div>
                <div class="swiper-slide" data-src="Product_Mana.aspx">商品列表</div>
                <div class="swiper-slide" data-src="Setting.aspx">參數設定</div>
            </div>
            <!-- Add Arrows -->
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
        </div>
    </div>
    <div class="buydivmove">
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
                                <div class="ListBG">
                                    <div class="col-xs-3 ListTitle1">
                                        <div class="row">
                                            商品圖片
                                        </div>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="row">
                                            <div class="col-xs-12 ListTitle2">商品名稱</div>
                                            <div class="col-xs-6 ListTitle2">價格</div>
                                            <div class="col-xs-6 ListTitle2">建檔日期</div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# ShowDetail(Eval("IDNo")) %>'>
                                <div class="ProMaBOX col-xs-12">
                                    <div class="SHead col-xs-3">
                                        <img src='<%# ShowImg(Eval("FilePath"))%>' />
                                    </div>
                                    <div class="ProMain col-xs-8">
                                        <div class="col-xs-12 ProLPad TtitleC BorTopno">
                                            <div class="row">
                                                <span>
                                                    <asp:Literal ID="Literal1" runat="server" Text='<%# ShowName(Eval("Product_Name"))%>'></asp:Literal>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="col-xs-6 ProLPad TRC BorBottompno">
                                            <div class="row">
                                                <asp:Literal ID="Literal2" runat="server" Text='<%# ShowPrice(Eval("Price"))%>'></asp:Literal>
                                            </div>
                                        </div>
                                        <div class="col-xs-6 ProLPad TGray BorBottompno">
                                            <div class="row">
                                                <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("CDate")%>'></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-1 ProLast">
                                        <div class="row">
                                            <img src="img/arrow.png" alt="Alternate Text" />
                                        </div>
                                    </div>
                                </div>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                    <asp:SqlDataSource ID="SD1" runat="server" OnSelected="SD1_Selected"></asp:SqlDataSource>
                </div>
                <div class="ProMaBOX col-xs-12 Nodate" runat="server" visible="false" id="PNodate">
                    <div class="SHead col-xs-3">
                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" />
                    </div>
                    <div class="ProMain col-xs-8">
                        <div class="col-xs-12 ProLPad TtitleC BorTopno">
                            <span>香Q嫩烤雞
                            </span>
                        </div>
                        <div class="col-xs-6 ProLPad TRC BorBottompno">
                            100,000
                        </div>
                        <div class="col-xs-6 ProLPad TGray BorBottompno">
                            2015/11/11
                        </div>
                    </div>
                    <div class="col-xs-1 ProLast">
                        <div class="row">
                            <img src="img/arrow.png" alt="Alternate Text" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
