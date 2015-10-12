<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="MiniStore.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                  <!-- Indicators -->
                                  <ol class="carousel-indicators">
                                    <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                                  </ol>

                                  <!-- Wrapper for slides -->
                                  <div class="carousel-inner" role="listbox">
                                      <asp:Literal ID="Literal6" runat="server"></asp:Literal>
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
                                <div class="col-xs-4">數量</div>
                                <div class="col-xs-7 text-right"><asp:Literal ID="Literal1" runat="server">1</asp:Literal></div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-xs-4">售價</div>
                                <div class="col-xs-7 text-right"><asp:Literal ID="Literal2" runat="server">200</asp:Literal></div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-xs-4">金額</div>
                                <div class="col-xs-7 text-right"><asp:Literal ID="Literal3" runat="server">400</asp:Literal></div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-xs-4">方式</div>
                                <div class="col-xs-7 text-right"><asp:Literal ID="Literal4" runat="server">面交</asp:Literal></div>
                            </div>
                        </li>
                    </ul>
                    <asp:Button ID="Bt_Buy" runat="server" Text="Buy" CssClass="btn btn-default btn-lg btn-block" OnClick="Bt_Buy_Click" />
                

            </div>
    </div>    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
    <script type="text/javascript" src="scripts/bootstrap.min.js"></script>
    <script>
        $('.carousel').carousel({
            interval: false
        })
    </script>
</asp:Content>
