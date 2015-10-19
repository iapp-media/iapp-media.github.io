<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Buy_Add.aspx.cs" Inherits="MiniStore.Buy_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ul class="buydivmove"> 
        <li class="productcare col-xs-12">
            <div class="col-xs-12 insidecare">
                <div class="row">
                    <div class="col-xs-12 libor productsinside">
                      <%--  <div class="col-xs-6">
                            <!-- 輪播圖 -->
                            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                <!-- Wrapper for slides -->
                                <div class="carousel-inner" role="listbox">
                                    <asp:Literal ID="L" runat="server"></asp:Literal>
                                </div>
                                <!-- Controls -->
                                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                            </div>
                        </div>--%>
                        <div id="slider">
                            <div class="control_next glyphicon glyphicon-chevron-right"></div>
                            <div class="control_prev glyphicon glyphicon-chevron-left"></div>
                            <ul>
                                <li>
                                    <img src="img/2531170_203204624000_2.jpg" alt="Alternate Text" /></li>
                                <li>
                                    <img src="#" alt="Alternate Text" /></li>
                                <li>
                                    <img src="#" alt="Alternate Text" /></li>
                                <li>
                                    <img src="#" alt="Alternate Text" /></li>
                            </ul>
                        </div>
                        <div class="slider_option">
                            <input type="checkbox" id="checkbox">  
                        </div>

                        <h1 class="col-xs-6">
                            <asp:Literal ID="L_Name" runat="server"></asp:Literal></h1>
                       
                        <span class="col-xs-6">
                            <asp:Literal ID="L_Price" runat="server"></asp:Literal></span>
                    </div>
                    <div style="display:none">
                        <!--這段要搬到產品內容頁-->
                    <div class="col-xs-12 libor sendadress">
                        <div class="col-xs-12">
                            <asp:Button ID="BT_MSG" runat="server" Text="問與答" CssClass="col-xs-4" OnClick="BT_MSG_Click" />
                            <asp:Button ID="BT_Like" runat="server" Text="LIKE" CssClass="col-xs-4" />
                            <asp:Button ID="BT_SHARE" runat="server" Text="分享" CssClass="col-xs-4" />
                        </div>
                    </div>
                    </div>
                    <div class="col-xs-12 libor paynumber">
                        <label for="" class="col-xs-6">購買數量</label>
                        <asp:DropDownList ID="DL_qty" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DL_qty_SelectedIndexChanged">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-12 libor status">
                        <label for="" class="col-xs-6">商品介紹</label>
                        <asp:TextBox ID="TB_Description" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor status">
                        <label for="" class="col-xs-6">商品規格</label>
                        <asp:TextBox ID="TB_Dimension" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor productNum">
                        <label for="" class="col-xs-6">商品售價</label>
                        <asp:TextBox ID="TB_Price" runat="server" CssClass="col-xs-6"></asp:TextBox>
                    </div>
                    <div class="col-xs-12 libor payNum">
                        <label for="" class="col-xs-6">付款金額</label>
                        <asp:TextBox ID="TB_Paysum" runat="server" CssClass="col-xs-6">99</asp:TextBox>
                    </div>
                    <div style="display:none">
                        <!--之後要拿掉的部分-->
                    <asp:Literal ID="L_view" runat="server"></asp:Literal>
                    </div>
                    <div class="col-xs-12 libor paytheway">
                        <label for="" class="col-xs-6">付款方式</label>
                        <select class="form-control">
                            <option>面交</option>
                            <option>7-11 ibon</option>
                            <option>銀行轉帳</option>
                        </select>
                    </div>
                    <div class="col-xs-12 libor sendtheway">
                        <label for="" class="col-xs-6">寄送方式</label>
                        <select class="form-control">
                            <option>面交自取</option>
                            <option>7-11</option>
                            <option>寄送到府</option>
                        </select>
                    </div>
                   
<%--                    <div class="col-xs-12 libor sendadress">
                        <label for="" class="col-xs-5">收件人資訊</label>
                        <div class="col-xs-7">
                            <asp:TextBox ID="TB_Name" runat="server" placeholder="姓名" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_Tel" runat="server" placeholder="電話" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_MNO" runat="server" placeholder="郵遞區號" CssClass="col-xs-12"></asp:TextBox>
                            <asp:TextBox ID="TB_Addr" runat="server" placeholder="地址" CssClass="form-control" Rows="3"></asp:TextBox>
                        </div>
                    </div>--%>
                    
                </div>
            </div>
            <asp:Button ID="BT_Confirm" runat="server" Text="立即購買" CssClass="btn btn-warning col-xs-5 sendcareButtom" OnClick="BT_Confirm_Click" />
            <div class=" col-xs-2"></div>
            <asp:Button ID="BT_InCar" runat="server" Text="加入購物車" CssClass="btn btn-warning col-xs-5 sendcareButtom" OnClick="BT_InCar_Click" />
        </li>
    </ul>

</asp:Content>
