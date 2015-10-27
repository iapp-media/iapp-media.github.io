<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Order_Detail.aspx.cs" Inherits="StoreMana.Mini.Order_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div>&nbsp;</div>
    </div>

    <div class="container-fluid">
        <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3 col-lg-4 col-lg-offset-4">
            <asp:Repeater ID="RP1" runat="server">
                <HeaderTemplate>
                    <div class="row1">
                        <%--<div class="col2">訂單狀態</div>--%>
                        <div class="col2">商品</div>
                        <div class="col2">數量</div>
                        <div class="col2">訂單編號</div>
                        <div class="col2">實付金額</div>
                        <div class="col2">下單時間</div>
                    </div>

                </HeaderTemplate>
                <ItemTemplate>
                    <%--    <asp:DropDownList ID="DL_STA" runat="server" >
                                                                            <asp:ListItem Value="1">未付款</asp:ListItem>
                                <asp:ListItem Value="2">未發貨</asp:ListItem>
                                <asp:ListItem Value="3">已發貨</asp:ListItem>
                                <asp:ListItem Value="4">交易完成</asp:ListItem>
                                <asp:ListItem Value="5">交易取消</asp:ListItem>
                                        </asp:DropDownList>--%>
                    <div class="row1">
                        <div class="col2">
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("Product_Name")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# Bind("QTY")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Order_No")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Total")%>'></asp:Literal>
                        </div>

                        <div class="col2">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("CDate")%>'></asp:Literal>
                        </div> 
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="L1" runat="server" Visible="false"></asp:Literal>
            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>


            <%--                <ul class="list-group">
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
                </ul>--%>
        </div>
    </div>

</asp:Content>
