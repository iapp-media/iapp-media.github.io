<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Add.aspx.cs" Inherits="StoreMana.Mini.Product_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div>&nbsp;</div>
    </div>

    <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">

            <ul class="list-group">
                <li class="list-group-item">
                    <!-- 輪播圖 -->
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                        <!-- Wrapper for slides -->
                     <div class="carousel-inner" role="listbox">
    <%--                           <ol class="carousel-indicators">
                                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                            </ol>
                            <div class="carousel-inner" role="listbox">
                                <div class="item active">
                                    <img src="img/114.png" />
                                </div>
                                <div class="item">
                                    <img src="img/defaulthead.jpg" />
                                </div>
                                <div class="item">
                                    <img src="img/p1-like02.png" />
                                </div>
                            </div>--%>

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
                </li>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">
                            <p>商品名稱</p>
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="TB_ProductName" Class="form-control" runat="server"></asp:TextBox></div>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">類別</div>
                        <div class="col-xs-8">
                            <asp:DropDownList ID="DDL_Cate" Class="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">售價</div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="TB_Price" Class="form-control" runat="server"></asp:TextBox></div>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">付款方式</div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="TB_Payment" Class="form-control" runat="server"></asp:TextBox></div>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">寄送方式</div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="TB_Delivery" Class="form-control" runat="server"></asp:TextBox></div>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">商品規格</div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="TB_Dimension" Class="form-control" runat="server"></asp:TextBox></div>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">商品介紹</div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="TB_Description" Class="form-control" runat="server"></asp:TextBox></div>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-xs-4">備註</div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="TB_Memo" Class="form-control" runat="server"></asp:TextBox></div>
                    </div>
                </li>
            </ul>
            <asp:Button ID="BT_Create" runat="server" Text="Create" CssClass="btn btn-default btn-lg btn-block" OnClick="BT_Create_Click" />
            <asp:Button ID="BT_Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-lg btn-block" OnClick="BT_Cancel_Click" />
            <asp:Literal ID="Literal1" runat="server" Visible="false"></asp:Literal>

        </div>
    </div>


    <script>
        $('.carousel').carousel({
            interval: false
        })
    </script>
</asp:Content>
