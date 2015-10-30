<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="Order_history.aspx.cs" Inherits="MiniStore.Order_history" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .row1 {
            border: 1px solid #000;
            float: left;
            padding: 2px 2px 2px 2px;
            width: 100%;
        }

        .col2 {
            margin: 0 0 0 45px;
            border: 1px solid red;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12  ">
                <div class="row">
                    <div class="col-xs-12">
                        <div>篩選</div>
                        <asp:DropDownList ID="DLDate" runat="server"  CssClass="form-control col-xs-5" >
                             <asp:ListItem Value="<">三個月內訂單</asp:ListItem>
                              <asp:ListItem Value=">=">三個月以上訂單</asp:ListItem>
                        </asp:DropDownList>
                           <asp:DropDownList ID="DL_Payment" runat="server" CssClass="form-control" ></asp:DropDownList>
                        <asp:TextBox ID="TB_Search" runat="server" placeholder="請輸入商品名稱"   Class="form-control  col-xs-5 " ></asp:TextBox>
                        
                        <asp:Button ID="BT_Search" runat="server" Text="查詢" OnClick="BT_Search_Click" CssClass="btn btn-warning col-xs-5 " />
                    </div>
                    <div class="col-xs-12">
                        <asp:Repeater ID="RP1" runat="server">
                            <HeaderTemplate>
                                <div class="row1">
                                    <div class="col2">訂單狀態</div>
                                   <%-- <div class="col2">商品</div> 
                                      <div class="col2">數量</div>--%>
                                    <div class="col2">訂單編號</div>
                                    <div class="col2">實付金額</div>
                                    <div class="col2">下單時間</div>
                                </div>

                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row1">
                                    <div class="col2">
                                        <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("Memo")%>'></asp:Literal>
                                    </div>
<%--                                    <div class="col2">
                                        <asp:Literal ID="Literal5" runat="server" Text='<%# Bind("Product_Name")%>'></asp:Literal>
                                    </div>
                                    <div class="col2">
                                        <asp:Literal ID="Literal6" runat="server" Text='<%# Bind("AMT")%>'></asp:Literal>
                                    </div> --%>  
                                    <div class="col2">
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Order_No")%>'></asp:Literal>
                                    </div>
                                    <div class="col2">
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Total_AMT")%>'></asp:Literal>
                                    </div>

                                    <div class="col2">
                                        <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("CDate")%>'></asp:Literal>
                                    </div>
                                   
                                         <div class="col2">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# ShowDetail(Eval("IDNo")) %>'>
                                     詳細資訊
                            </asp:HyperLink>
                        </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                        <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </li>
    </ul>

</asp:Content>
