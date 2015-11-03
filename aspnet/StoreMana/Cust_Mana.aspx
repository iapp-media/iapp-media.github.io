<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Cust_Mana.aspx.cs" Inherits="StoreMana.Cust_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <div class="buydivmove">
        <div class="insidecare col-xs-12">
            <div class="row">
                <asp:Repeater ID="RP1" runat="server">
                    <HeaderTemplate>
                        <div>
                            <div class="ProMLtit col-xs-12">
                                <div class="col-xs-4 BoxCenter ListTitle">名次</div>
                                <div class="col-xs-4 BoxCenter ListTitle">姓名</div>
                                <div class="col-xs-4 BoxCenter ListTitle">點擊次數</div>
                                <div class="col-xs-4 BoxCenter ListTitle">產品名稱</div>
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="ProMaBOX col-xs-12 ToBoPad">
                            <div class="ProMain col-xs-12">
                                <div class="col-xs-4 ProLPad AlltexC BorTopno BorLeftpno">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("ROWID")%>'></asp:Literal>
                                </div>
                                <div class="col-xs-4 ProLPad AlltexC BorTopno TGray ">
                                    <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("User_Name")%>'></asp:Literal>
                                </div>
                                <div class="col-xs-4 ProLPad AlltexC BorTopno BorRightno TGray ">
                                    <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("ck")%>'></asp:Literal>
                                </div>
                                <div class="col-xs-4 ProLPad AlltexC BorLeftpno BorBottompno TGray ">
                                    <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("Product_Name")%>'></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="L1" runat="server" Visible="false"></asp:Literal>
                <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>


                <asp:Repeater ID="RP2" runat="server">
                    <HeaderTemplate>
                        <div>
                            <div class="ProMLtit col-xs-12">
                                <div class="col-xs-4 BoxCenter ListTitle">名次</div>
                                <div class="col-xs-4 BoxCenter ListTitle">姓名</div>
                                <div class="col-xs-4 BoxCenter ListTitle">介紹人次</div>
                                <div class="col-xs-4 BoxCenter ListTitle">產品名稱</div>
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="ProMaBOX col-xs-12 ToBoPad">
                            <div class="ProMain col-xs-12">
                                <div class="col-xs-4 ProLPad AlltexC BorTopno BorLeftpno">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("ROWID")%>'></asp:Literal>
                                </div>
                                <div class="col-xs-4 ProLPad AlltexC BorTopno TGray ">
                                    <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("User_Name")%>'></asp:Literal>
                                </div>
                                <div class="col-xs-4 ProLPad AlltexC BorTopno BorRightno TGray ">
                                    <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("ck")%>'></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Literal ID="L2" runat="server" Visible="false"></asp:Literal>
                <asp:SqlDataSource ID="SD2" runat="server"></asp:SqlDataSource>


                <asp:Repeater ID="RP3" runat="server">
                    <HeaderTemplate>
                        <div>
                            <div class="ProMLtit col-xs-12">
                                <div class="col-xs-6 BoxCenter ListTitle">客戶Email</div>
                                <div class="col-xs-6 BoxCenter ListTitle">姓名</div>
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="ProMaBOX col-xs-12 ToBoPad">
                            <div class="ProMain col-xs-12">
                                <div class="col-xs-6 ProLPad AlltexC BorTopno BorLeftpno">
                                    <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("Account")%>'></asp:Literal>
                                </div>
                                <div class="col-xs-6 ProLPad AlltexC BorTopno TGray ">
                                    <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("User_Name")%>'></asp:Literal>
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
</asp:Content>
