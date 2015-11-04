<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Detail.aspx.cs" Inherits="MiniStore.Buy_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div class="col-xs-12 libor ContentTop">
        <img src="img/backarrow.png" alt="Alternate Text" class="col-xs-2" onclick="javascript:history.back()" /> 
        <h1 class="col-xs-10"><asp:Literal ID="TB_Name" runat="server"></asp:Literal></h1> 
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
                                        <asp:Literal ID="TB_Price" runat="server"></asp:Literal>
                                    </p>
                                </div>
                                <div class="DetailMR">
                                    <asp:Button ID="BT_Confirm" runat="server" Text="購買" CssClass="btn btn-warning col-xs-12 sendcareButtom" OnClick="BT_Confirm_Click" />
                                </div>
                            </div>
                            <div class="col-xs-12 libor status CBbot">
                                <label for="" class="col-xs-6">產品規格</label>
                                  <asp:Literal ID="TB_Dimension" runat="server"></asp:Literal>
                          <%--      <asp:TextBox ID="TB_Dimension" runat="server" CssClass="col-xs-6"></asp:TextBox>--%>
                            </div>
                            <div class="col-xs-12 libor CBbot CBarea">
                                <label for="" class="col-xs-12">產品介紹</label>
                                    <asp:Literal ID="TB_Description" runat="server"></asp:Literal>
                            <%--    <asp:TextBox ID="TB_Description" runat="server" CssClass="col-xs-12"></asp:TextBox>--%>
                            </div>
                             <div class="col-xs-12 questionBox">
                                <div class="row">
                                    <asp:Button ID="BT_MSG" runat="server" Text="留言" CssClass="col-xs-12 question" OnClick="BT_MSG_Click" />
                                    
                                </div>
                            </div>
                            <div class="col-xs-12 questionBox">
                                <div class="row">
                                 <asp:Button ID="BT_Like" runat="server" Text="Facebook" CssClass="col-xs-6 question" />
                                    <asp:Button ID="BT_SHARE" runat="server" Text="LINE" CssClass="col-xs-6 question" />
                                    </div>
                            </div>
                        </div>
                    </div>

                </li>
            </ul>

        </div>
    </div>
</asp:Content>
