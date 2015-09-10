<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Orders_Mana.aspx.cs" Inherits="MiniStore.Mana.Orders_Mana" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div>&nbsp;</div>
    </div>

    <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">
            <form id="Form1" runat="server">

                <div class="list-group">
                    <div class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">
                                <p>訂單編號</p>
                            </div>
                            <div class="col-xs-8">
                                <asp:TextBox ID="TextBox1" runat="server" Class="form-control" placeholder="請輸入訂單編號"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">
                                <p>訂單狀態</p>
                            </div>
                            <div class="col-xs-8">
                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="1">未付款</asp:ListItem>
                                    <asp:ListItem Value="2">未發貨</asp:ListItem>
                                    <asp:ListItem Value="3">已發貨</asp:ListItem>
                                    <asp:ListItem Value="4">交易完成</asp:ListItem>
                                    <asp:ListItem Value="5">交易取消</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="list-group-item">
                       <asp:Button ID="BT_Search"  runat="server" Text="Search" CssClass="btn btn-default btn-lg btn-block" OnClick="BT_Search_Click" />
                    </div>
                </div>
                
                <div class="list-group">
                    <div class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">訂單編號</div>
                            <div class="col-xs-2">買家</div>
                            <div class="col-xs-3">訂單狀態</div>
                            <div class="col-xs-3">下單時間</div>
                        </div>
                    </div>
                    <asp:Literal ID="Literal1" runat="server" ></asp:Literal>
                </div>

            </form>
            <asp:Literal ID="L" runat="server" Visible="false" ></asp:Literal>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
</asp:Content>
