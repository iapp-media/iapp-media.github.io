<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Product_Add.aspx.cs" Inherits="MiniStore.Product_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/reset.css" />
    <link rel="stylesheet" href="css/default.css" />
    <link rel="stylesheet" href="css/colorbox.css" />
    <link href="img/favicon.ico" rel="shortcut icon" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 promana"> 
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
                            <div class="col-xs-4"><p>商品名稱</p></div>
                            <div class="col-xs-8"><asp:TextBox ID="TB_ProductName" Class="form-control" runat="server"></asp:TextBox></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                         <div class="row">
                             <div class="col-xs-4">類別</div>
                             <div class="col-xs-8">
                                 <asp:DropDownList ID="DDL_Cate" Class="form-control" runat="server" ></asp:DropDownList>
                             </div>
                         </div>
                    </li>
                    <li class="list-group-item">
                         <div class="row">
                             <div class="col-xs-4">售價</div>
                             <div class="col-xs-8"><asp:TextBox ID="TB_Price" Class="form-control" runat="server"></asp:TextBox></div>
                         </div>
                    </li>
                    <li class="list-group-item">
                         <div class="row">
                             <div class="col-xs-4">付款方式</div>
                             <div class="col-xs-8"><asp:TextBox ID="TB_Payment" Class="form-control" runat="server"></asp:TextBox></div>
                         </div>
                    </li>
                    <li class="list-group-item">
                         <div class="row">
                             <div class="col-xs-4">寄送方式</div>
                             <div class="col-xs-8"><asp:TextBox ID="TB_Delivery" Class="form-control" runat="server"></asp:TextBox></div>
                         </div>
                    </li>
                    <li class="list-group-item">
                         <div class="row">
                             <div class="col-xs-4">商品規格</div>
                             <div class="col-xs-8"><asp:TextBox ID="TB_Dimension" Class="form-control" runat="server"></asp:TextBox></div>
                         </div>
                    </li>
                    <li class="list-group-item">
                         <div class="row">
                             <div class="col-xs-4">商品介紹</div>
                             <div class="col-xs-8"><asp:TextBox ID="TB_Description" Class="form-control" runat="server"></asp:TextBox></div>
                         </div>
                    </li>
                    <li class="list-group-item">
                         <div class="row">
                             <div class="col-xs-4">備註</div>
                             <div class="col-xs-8"><asp:TextBox ID="TB_Memo" Class="form-control" runat="server"></asp:TextBox></div>
                         </div>
                    </li>
                </ul>
                <asp:Button ID="BT_Create" runat="server" Text="Create" CssClass="btn btn-default btn-lg btn-block" OnClick="BT_Create_Click" />
                <asp:Button ID="BT_Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary btn-lg btn-block" OnClick="BT_Cancel_Click" />
                <asp:Literal ID="Literal1" runat="server" Visible="false"></asp:Literal>
          
        </div>
    </div>   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
    <script type="text/javascript" src="scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/webedit.js"></script>
    <script>
        $('.carousel').carousel({
            interval: false
        })
    </script>
</asp:Content>
