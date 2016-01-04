<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="P_MSG.aspx.cs" Inherits="MiniStore.P_MSG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-xs-12 libor ContentTop">
        <div class="backarrow" onclick="javascript:history.back()"></div>

        <asp:Literal ID="L_Back" runat="server"></asp:Literal>
        <h1 class="col-xs-10">問與答</h1>
    </div>
    <div class="col-xs-12 promana">
        <div class="row">
            <ul>
                <li class="productcare">
                    <div class="col-xs-12 insidecare FBMargin">
                        <div class="row">

                            <div class="col-xs-12 libor payNum" id="pagetitle">
                                <asp:Literal ID="L_Puc" runat="server"></asp:Literal>
                            </div>
                            <asp:Repeater ID="RP1" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="contentBG">
                                        <div class="col-xs-12 libor payNum Issue QCTot">
                                            <span class="spansizemidleft">問題</span>
                                            <span class="spansizebig">客戶A</span>
                                            <span class="spansizemid"><%# Eval("agoday") %></span>
                                            <p><%# Eval("Question") %></p>
                                        </div>
                                        <div class="col-xs-12 libor payNum Issue QCTBot">
                                            <span class="spansizemidleft">回覆</span>
                                            <span class="spansizebig">店家B</span>
                                            <span class="spansizemid">回覆日期</span>
                                            <p><%# Eval("Ans") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                        </div>
                    </div>
                </li>
            </ul>
            <div class="col-xs-12 fixBar">
               
                <asp:TextBox ID="tbQuen" runat="server"  Class="form-control" ></asp:TextBox>
                <div class="fRight" >
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><img src="img/send.png" /></asp:LinkButton>
<%--                    <asp:ImageButton ID="btsend" runat="server" ImageUrl="img/send.png" OnClick="btsend_Click"   />--%>
                </div> 
            </div>
        </div>
    </div>
</asp:Content>
