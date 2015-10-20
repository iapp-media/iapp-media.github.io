<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="P_MSG.aspx.cs" Inherits="MiniStore.P_MSG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style >
        .col2 {
            border:1px solid red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div style="display: none">
                <%-- 暫時先重寫 --%>
                <div class="col-xs-12">
                    <div class="row">
                        <img src="img/114.png" />
                        <asp:Literal ID="PName" runat="server"></asp:Literal>
                        <asp:Literal ID="PPrice" runat="server"></asp:Literal>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 libor productsinside">
                            <asp:Repeater ID="RP1" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="row1">
                                        <div class="col2">
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Question")%>'></asp:Literal>
                                            <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("agoday")%>'></asp:Literal>
                                        </div>
                                        <div class="col2">
                                            <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Ans")%>'></asp:Literal>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>

                        </div>
                        <div class="row">
                            <asp:TextBox ID="tbQuen" runat="server" AutoPostBack="true" Class="form-control "></asp:TextBox>
                            <asp:Button ID="btsend" runat="server" Text="發送" OnClick="btsend_Click" CssClass="btn btn-warning col-xs-2 sendcareButtom" OnClientClick="fun2()" />
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-xs-12 insidecare">
                <div class="row">
                    <div class="col-xs-12 libor payNum">
                        <h1 class="texcenter">問與答</h1>
                    </div>
                    <div class="col-xs-12 libor payNum insideCSS">
                        <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" class="imgH" />
                        <div class="rightbox">
                            <h4>香Q嫩烤雞可郵寄(下標前請仔細看過置頂文)</h4>
                            <span>$100</span>
                            <p>Leo</p>
                        </div>
                    </div>
                    
                    <div class="col-xs-12 libor payNum Issue">
                        <span class="spansizebig">YYY12312DSA</span>
                        <span class="spansizemidleft">發問</span>
                        <span class="spansizemid">2015年12月25日</span>
                        <p>要    多    久?</p>
                    </div>
                    <div class="col-xs-12 libor payNum Issue">
                        <span class="spansizebig">Leo</span>
                        <span class="spansizemidleft">回覆</span>
                        <span class="spansizemid">2015年12月25日</span>
                        <p>已優先幫您處理了請稍後</p>
                    </div>
                    <div class="col-xs-12 libor payNum Issue">
                        <span class="spansizebig">YYY12312DSA</span>
                        <span class="spansizemidleft">發問</span>
                        <span class="spansizemid">2015年12月25日</span>
                        <p>自己親自去拿我住台北市台北有店面嗎?</p>
                    </div>
                    <div class="col-xs-12 libor payNum Issue">
                        <span class="spansizebig">Leo</span>
                        <span class="spansizemidleft">回覆</span>
                        <span class="spansizemid">2015年12月25日</span>
                        <p>有喔在101附近</p>
                    </div>
                    <div class="col-xs-12 libor payNum Issue">
                        <span class="spansizebig">YYY12312DSA</span>
                        <span class="spansizemidleft">發問</span>
                        <span class="spansizemid">2015年12月25日</span>
                        <p>請問多久送到?</p>
                    </div>
                     <div class="col-xs-12 libor payNum Issue">
                        <span class="spansizebig">Leo</span>
                        <span class="spansizemidleft">回覆</span>
                        <span class="spansizemid">2015年12月25日</span>
                        <p>處理時間為1~2天</p>
                    </div>
                     
                </div>
               
            </div>
            
        </li>
    </ul>
    <div class="col-xs-12 fixBar">
        <textarea class="form-control" rows="3"></textarea>
        <asp:Button ID="Button1" runat="server" Text="發送" OnClick="btsend_Click" CssClass="btn btn-warning col-xs-2 sendcareButtom" OnClientClick="fun2()" />
    </div>
 
</asp:Content>
