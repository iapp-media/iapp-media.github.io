<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Msg_Mana.aspx.cs" Inherits="StoreMana.Msg_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4 BorRightno"><a href="Msg_Mana.aspx" style="color: white">客戶留言</a></li>
            </ul>
        </div>
    </div>--%>
    <div id="Allswiper">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide"><a href="Msg_Mana.aspx" style="color: white">客戶留言</a></div>
            </div>
        </div>
    </div>
    <div class="buydivmove">
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
                <div class="col-xs-12 BTbox">
                    <asp:Button ID="BT_Search" runat="server" Text="搜尋" CssClass="btn btn-warning col-xs-12 SBuyCar" OnClick="BT_Search_Click" />
                </div>
                <%--                <div class="QMargin col-xs-12">
                    <div class="row">
                        <div class="col-xs-11 BTbox ShareMargin IssueUI1">
                            <div class="Qutop">
                                <p class="TBlack">問題</p>
                                <p class="TBlack TRBC">YYYY12313</p>
                                <p class="TRBC">5天前</p>
                            </div>
                            <p class="TRBC">我的果菜汁什麼時候送來?</p>
                        </div>
                        <div class="col-xs-11 BTbox IssueUI2">
                            <div class="Qutop">
                                <p class="TBlack">回覆</p>
                                <p class="TBlack TRBC">賣家</p>
                                <p class="TRBC">5天前</p>
                            </div>
                            <p class="TRBC">不好意思現在斷貨中</p>
                        </div>
                    </div>
                </div>
                <div class="QMargin col-xs-12">
                    <div class="row">
                        <div class="col-xs-11 BTbox ShareMargin IssueUI1">
                            <div class="Qutop">
                                <p class="TBlack">問題</p>
                                <p class="TBlack TRBC">YYYY12313</p>
                                <p class="TRBC">5天前</p>
                            </div>
                            <p class="TRBC">我的果菜汁什麼時候送來?</p>
                        </div>
                        <div class="col-xs-11 BTbox TalkUI">
                            <a href="#" class="TBlack TalkR">回覆</a>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
        <asp:Repeater ID="RP1" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="Boxlist col-xs-12">
                    <div class="row">
                        <div class="QMargin col-xs-12">
                            <div class="row">
                                <div class="ShareMargin IssueUI1">
                                    <div class="Qutop">
                                        <img src='<%# ShowImg(Eval("FilePath"))%>' alt="Alternate Text" />
                                        <h3 class="TBC">棒球套件組</h3>
                                    </div>
                                    <div class="Qubot">
                                        <p class="TBlack TRBC">問題</p>
                                        <p class="TBlack TRBC">YYYY12313</p>
                                        <p class="TBlack TextBright"><%# Eval("agoday")%></p>
                                        <p class="TRBC"><%# Eval("Question")%></p>
                                    </div>

                                </div>
                                <div class="col-xs-11 BTbox TalkUI">
                                    <asp:HyperLink ID="HyperLink1" CssClass="TRBC TBlack" runat="server" NavigateUrl='<%# ShowDetail(Eval("IDNo")) %>'>
                                     回覆
                                    </asp:HyperLink>
                                </div>
                                <div class="col-xs-11 BTbox IssueUI2">
                                    <p class="TRBC TBlack">回覆</p>
                                    <p class="TBlack TRBC">賣家</p>
                                    <p class="TRBC TextBright"><%# Eval("reday")%></p>
                                    <p class="TRBC"><%# Eval("Ans")%></p>
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



</asp:Content>
