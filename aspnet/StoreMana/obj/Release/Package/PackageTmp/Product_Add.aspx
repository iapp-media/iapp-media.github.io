<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Add.aspx.cs" Inherits="StoreMana.Mini.Product_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 建檔修改 -->
    <div class="allmodify">
        <ul class="buydivmove mart10">
            <li class="modify col-xs-12">
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品類別</label>
                            <asp:DropDownList class="form-control" ID="DL_Cate" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-12 libor status">
                            <label for="" class="col-xs-6">商品圖片</label>
                            <div class="form-group">
                                <div style="margin: 0 0 0 300px; width: 500px">
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
                                </div> 
                            </div>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
        <p class="text-center fonts">填寫資料</p>
        <ul class="buydivmove">
            <li class="modify col-xs-12">
                <div class="col-xs-12 insidecare">
                    <div class="row">
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品名稱</label>
                            <asp:TextBox ID="TB_ProductName" Class="form-control" runat="server" placeholder="限30個字以內"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">價格</label>
                            <asp:TextBox ID="TB_Price" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">數量</label>
                            <asp:TextBox ID="TB_qty" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品說明</label>
                            <asp:TextBox ID="TB_Description" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">商品規格</label>
                            <asp:TextBox ID="TB_Dimension" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">付款方式</label>
                            <asp:DropDownList ID="DL_Payment" runat="server" CssClass="form-control">
                                <asp:ListItem Text="面交" Value="1"></asp:ListItem>
                                <asp:ListItem Text="7-11 ibon" Value="2"></asp:ListItem>
                                <asp:ListItem Text="銀行轉帳" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">寄送方式</label>
                            <asp:DropDownList ID="DL_Delivery" runat="server" CssClass="form-control">
                                <asp:ListItem Text="面交自取" Value="1"></asp:ListItem>
                                <asp:ListItem Text="7-11" Value="2"></asp:ListItem>
                                <asp:ListItem Text="寄送到府" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-12 libor paynumber">
                            <label for="" class="col-xs-6">備註</label>
                            <asp:TextBox ID="TB_Memo" Class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
        <asp:Button ID="BT_Create" runat="server" Text="Create" CssClass="btn btn-default btn-lg btn-block" OnClick="BT_Create_Click" />
        <asp:Button ID="BT_Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-lg btn-block" OnClick="BT_Cancel_Click" />

        <asp:Literal ID="LPID" runat="server" Visible="false"></asp:Literal> 
    </div> 
    <script>
        $('.carousel').carousel({
            interval: false
        })

        function Iframeload() { 
            window.location.reload("Product_Add.aspx"); 
        }
    </script>
</asp:Content>
