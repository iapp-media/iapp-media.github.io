<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Order_Detail.aspx.cs" Inherits="MiniStore.Order_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div>&nbsp;</div>
    </div>

    <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">
            <form id="Form1" runat="server">
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">商品名稱</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_ProductName" runat="server"></asp:Literal></div>
                        </div>                        
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">數量</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_AMT" runat="server"></asp:Literal></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">金額</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_Total" runat="server"></asp:Literal></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">付款方式</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_Payment" runat="server">面交</asp:Literal></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">寄送方式</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_Delivery" runat="server">面交</asp:Literal></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">訂單編號</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_OrderNo" runat="server"></asp:Literal></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">訂單狀態</div>
                            <div class="col-xs-7 text-right">
                                <asp:DropDownList ID="DDL_Status" runat="server">
                                    <asp:ListItem Value="1">未付款</asp:ListItem>
                                    <asp:ListItem Value="2">未發貨</asp:ListItem>
                                    <asp:ListItem Value="3">已發貨</asp:ListItem>
                                    <asp:ListItem Value="4">交易完成</asp:ListItem>
                                    <asp:ListItem Value="5">交易取消</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">買家</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_Contact_ID" runat="server"></asp:Literal></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">E-Mail</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_Email" runat="server"></asp:Literal></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">電話</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_TEL" runat="server"></asp:Literal></div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-xs-4">地址</div>
                            <div class="col-xs-7 text-right"><asp:Literal ID="L_Addr" runat="server"></asp:Literal></div>
                        </div>
                    </li>
                </ul>
                <asp:Button ID="Bt_Leave"  runat="server" Text="Confirm" CssClass="btn btn-default btn-lg btn-block" OnClick="Bt_Leave_Click" />
            </form>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
</asp:Content>
