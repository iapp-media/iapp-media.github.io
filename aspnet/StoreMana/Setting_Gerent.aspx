<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Setting_Gerent.aspx.cs" Inherits="StoreMana.Setting_Gerent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_SInfo.aspx" style="color: white">微店管理</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting_Gerent.aspx" style="color: white">帳號管理</a></li>
            </ul>
        </div>
    </div> 
    <div id="content">
        <div class="col-xs-12 AllBox BoxBorder">
            <div class="row">
                <!-- 參數設定 -->
                <div class="allmodify">
                    <ul class="buydivmove mart10">
                        <li class="modify col-xs-12">
                            <div class="col-xs-12 insidecare">
                                <div class="row">
                                    <div>
                                        <label>Iapp帳號</label>
                                        <asp:TextBox ID="TB_ACC" runat="server"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:Button ID="BT_Confirm" runat="server" Text="加入" OnClick="BT_Confirm_Click" />
                                    </div>
                                    <div>
                                        <asp:Repeater ID="RP1" runat="server">
                                            <HeaderTemplate>
                                                <div>
                                                    <label>管理員帳號</label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div>
                                                    <div>
                                                        <label><%# Eval("Account") %></label>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <asp:Literal ID="L1" runat="server" Visible="false"></asp:Literal>
                                        <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <!-- 參數設定 end -->
            </div>
        </div>
    </div>
</asp:Content>
