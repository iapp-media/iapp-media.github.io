<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Detail.aspx.cs" Inherits="MiniStore.Buy_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-xs-12 libor ContentTop">
<%--        <img src="img/backarrow.png" alt="Alternate Text" class="col-xs-2" onclick="javascript:history.back()" />--%>
          <asp:Literal ID="L_Back" runat="server"></asp:Literal>
        <h1 class="col-xs-10">
            <asp:Literal ID="TB_Name" runat="server"></asp:Literal></h1>
    </div>
    <div class="col-xs-12 promana">
        <div class="row">
            <ul>
                <li class="productcare">
                    <div class="col-xs-12 insidecare">
                        <div class="row">
                            <div class="col-xs-12 libor productsinside">
                                <div id="slider">
                                    <div class="control_next glyphicon glyphicon-chevron-right"></div>
                                    <div class="control_prev glyphicon glyphicon-chevron-left"></div>
                                    <ul>
                                        <asp:Literal ID="IMG_li" runat="server"></asp:Literal>
                                    </ul>
                                </div>

                                <h1 class="col-xs-6">
                                    <asp:Literal ID="L_Name" runat="server"></asp:Literal></h1>
                            </div>

                            <div class="DetailMbox col-xs-12">
                                <div class="DetailML MidFonts">
                                    <p>
                                        NT$<asp:Literal ID="TB_Price" runat="server"></asp:Literal>
                                    </p>
                                </div>
                                <div class="DetailMR">
                                    <asp:Button ID="BT_Confirm" runat="server" Text="購買" CssClass="btn btn-warning col-xs-12 sendcareButtom" OnClick="BT_Confirm_Click" />
                                </div>
                            </div>
                            <div class="col-xs-12 libor status CBbot">
                                <label for="" class="col-xs-4">產品規格</label>
                                <span class="ValueText col-xs-8 TRBC">
                                    <asp:Literal ID="TB_Dimension" runat="server"></asp:Literal>
                                </span>
                                <%--      <asp:TextBox ID="TB_Dimension" runat="server" CssClass="col-xs-6"></asp:TextBox>--%>
                            </div>
                            <div class="col-xs-12 libor CBbot CBarea">
                                <label for="" class="col-xs-12">產品介紹</label>
                                <span class="Valuetextarea col-xs-12">
                                    <div class="row">
                                        <asp:Literal ID="TB_Description" runat="server"></asp:Literal>
                                    </div>
                                </span>
                                <%--    <asp:TextBox ID="TB_Description" runat="server" CssClass="col-xs-12"></asp:TextBox>--%>
                            </div>

                            <div class="col-xs-12 libor status CBbot CBBTN questionBTN"> 
                                <asp:Button ID="BT_MSG" runat="server" Text="留言" OnClick="BT_MSG_Click" CssClass="btn btn-warning col-xs-12 SBuyCar" />
                                <%--  <asp:Literal ID="MSG_COUNT" runat="server"></asp:Literal>--%>
                            </div>


                            <div class="col-xs-9 col-sm-6 MsgBox">
                                <div class="row">
                                    <div class="col-xs-4">
                                        <%--  <img src="img/mail.png" alt="Alternate Text" />--%>
                                        <asp:ImageButton ID="BT_Mail" runat="server" ImageUrl="img/mail.png" CssClass="img-responsive"/>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:ImageButton ID="BT_Line" runat="server" ImageUrl="img/line.png" />
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:ImageButton ID="BT_FB" runat="server" ImageUrl="img/facebook-02.png" OnClick="BT_FB_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
