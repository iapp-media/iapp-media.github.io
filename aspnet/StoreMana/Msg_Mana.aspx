<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Msg_Mana.aspx.cs" Inherits="StoreMana.Msg_Mana" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Msg_Mana.aspx" style="color: white">客戶留言</a></li> 
            </ul>
        </div>
    </div>
    <div id="content">
            <div class="col-xs-12 insidecare">
                <div class="row">
                    <div class="col-xs-12 BTbox">
                        <p class="BTleft">
                            商品類別
                        </p>
                        <asp:DropDownList class="BTright" ID="DL" runat="server">
                            <asp:ListItem Value="0">尚未回覆</asp:ListItem>
                            <asp:ListItem Value="1">已回覆</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-12 BTbox">
                        <p class="BTleft">
                            商品名稱
                        </p>
                          <asp:DropDownList class="BTright" ID="DL_Pname" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-12 libor paynumber delettoplin">
                        <label class="col-xs-6">商品名稱</label>
                      
                    </div>
                    <div class="col-xs-12 libor paynumber delettoplin">
                        <asp:Button ID="BT_Search" runat="server" Text="搜尋" CssClass="btn btn-warning btn-lg btn-block sendcareButtom" OnClick="BT_Search_Click" />
                    </div>
                    <div class="col-xs-12 libor payNum Issue delettoplin">
                        <span class="spansizebig">有折扣嗎?</span>
                        <span class="spansizemidleft">5天前</span>
                        <a href="#" class="spansizemid">回覆</a>
                        <p>尚未回覆</p>
                    </div>
                    <div class="col-xs-12 libor payNum Issue delettoplin">
                        <span class="spansizebig">有折扣嗎?</span>
                        <span class="spansizemidleft">5天前</span>
                        <a href="#" class="spansizemid">回覆</a>
                        <p>尚未回覆</p>
                    </div>
                </div>
            </div>
            <asp:Repeater ID="RP1" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>

                    <!--<div class="col-xs-12 libor paynumber">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Question")%>'></asp:Literal>
                            <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("agoday")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Ans")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# ShowDetail(Eval("IDNo")) %>'>
                                     回覆
                            </asp:HyperLink>
                        </div>-->

                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>

    </div>
    </div>


</asp:Content>
