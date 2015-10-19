<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Mana.aspx.cs" Inherits="StoreMana.Product_Mana" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="allmodify">
            <ul class="buydivmove">
                <li class="modify col-xs-12">
                    <div class="col-xs-12 insidecare">
                        <div class="row">
                            <div class="col-xs-12 libor paynumber">
                                   <label class="col-xs-6">商品類別</label>
                                    <asp:DropDownList class="form-control" ID="DL" runat="server">
                                    </asp:DropDownList>
                            </div>
                            <div class="col-xs-12 libor paynumber">
                                 <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-warning btn-lg btn-block sendcareButtom" OnClick="BT_Search_Click" />
                            </div>
                             <div class="col-xs-12 libor paynumber">
                                  <input type="button" onclick="javascript: location.href = 'Product_Add.aspx'" value="新增商品" class="btn btn-warning btn-lg btn-block sendcareButtom" />
                            </div>
                            <div class="col-xs-12 libor paynumber">
                                 <asp:Repeater ID="RP1" runat="server">
                <HeaderTemplate>
                    
                        <div class="col-xs-3 titleleftfont">商品名稱</div>
                        <div class="col-xs-3 titleleftfont">價格</div>
                        <div class="col-xs-3 titleleftfont">建檔日期</div>　
                   
                </HeaderTemplate> 
                <ItemTemplate>
                    <div class="row1">
                        <div class="col2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Product_Name")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Price")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("CDate")%>'></asp:Literal>
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
                    <%--<div style="display: none">
                        先註解掉因為用display還是會影響到
                        <div class="list-group-item">
                            <div class="row">
                                <div class="modify col-xs-12">
                                    <div class="col-xs-4">
                                        <p>商品類別</p>
                                    </div>
                                    <div class="col-xs-8">
                                        <asp:DropDownList class="form-control" ID="DL" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <div style="display: none">
               
                        <div class="list-group-item">
                            <asp:Button ID="BT_Search" runat="server" Text="Search" CssClass="btn btn-default btn-lg btn-block" OnClick="BT_Search_Click" />
                        </div>
                        <div class="list-group-item">
                            <input type="button" onclick="javascript: location.href = 'Product_Add.aspx'" value="新增商品" class="btn btn-primary btn-lg btn-block" />
                        </div>
                    </div><%-- 這段不要的 --%>
            </li>
            　
            <%--<asp:Repeater ID="RP1" runat="server">
                <HeaderTemplate>
                    <div class="row1">
                        <div class="col2">商品名稱</div>
                        <div class="col2">價格</div>
                        <div class="col2">建檔日期</div>　
                    </div>
                </HeaderTemplate> 
                <ItemTemplate>
                    <div class="row1">
                        <div class="col2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Product_Name")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Price")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("CDate")%>'></asp:Literal>
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
            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>--%>
        </ul>
    </div>

</asp:Content>
