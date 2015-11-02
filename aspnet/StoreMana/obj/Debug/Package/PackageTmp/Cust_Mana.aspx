<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Cust_Mana.aspx.cs" Inherits="StoreMana.Cust_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row1 {
            border: 1px solid #000;
            float: left;
            padding: 2px 2px 2px 2px;
            width: 100%;
        }

        .col2 {
            margin: 0 0 0 45px;
            border: 1px solid red;
            float: left;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Cust_Mana.aspx?com=1" style="color: white">社群力排行</a></li>
                <li class="swiper-slide col-xs-4"><a href="Cust_Mana.aspx" style="color: white">客戶列表</a></li>
                <li class="swiper-slide col-xs-4"><a href="Cust_Mana.aspx?act=1" style="color: white">活動力排行</a></li>
            </ul>
        </div>
    </div>

    <!-- WRAPPER -->
    <div id="content">

        <div class="col-xs-12 AllBox BoxBorder">
            <div class="row">
                <div class="container-fluid">
                    <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:Repeater ID="RP1" runat="server">
                                    <HeaderTemplate>
                                        <div class="row1">
                                            <div class="col2">名次</div>
                                            <div class="col2">姓名</div>
                                            <div class="col2">點擊次數</div>
                                            <div class="col2">產品名稱</div>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="row1">
                                            <div class="col2">
                                                <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("ROWID")%>'></asp:Literal>
                                            </div>
                                            <div class="col2">
                                                <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("User_Name")%>'></asp:Literal>
                                            </div>
                                            <div class="col2">
                                                <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("ck")%>'></asp:Literal>
                                            </div>
                                            <div class="col2">
                                                <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("Product_Name")%>'></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Literal ID="L1" runat="server" Visible="false"></asp:Literal>
                                <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                            </div>
                            <div class="col-xs-12">
                                <asp:Repeater ID="RP2" runat="server">
                                    <HeaderTemplate>
                                        <div class="row1">
                                            <div class="col2">名次</div>
                                            <div class="col2">姓名</div>
                                            <div class="col2">介紹人次</div>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="row1">
                                            <div class="col2">
                                                <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("ROWID")%>'></asp:Literal>
                                            </div>
                                            <div class="col2">
                                                <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("User_Name")%>'></asp:Literal>
                                            </div>
                                            <div class="col2">
                                                <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("ck")%>'></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Literal ID="L2" runat="server" Visible="false"></asp:Literal>
                                <asp:SqlDataSource ID="SD2" runat="server"></asp:SqlDataSource>
                            </div>
                            <div class="col-xs-12">
                                <asp:Repeater ID="RP3" runat="server">
                                    <HeaderTemplate>
                                        <div class="row1">
                                            <div class="col2">客戶Email</div>
                                            <div class="col2">姓名</div>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="row1">
                                            <div class="col2">
                                                <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("Account")%>'></asp:Literal>
                                            </div>
                                            <div class="col2">
                                                <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("User_Name")%>'></asp:Literal>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Literal ID="L3" runat="server" Visible="false"></asp:Literal>
                                <asp:SqlDataSource ID="SD3" runat="server"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
