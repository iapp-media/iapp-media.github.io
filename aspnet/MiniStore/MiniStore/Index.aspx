<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MiniStore.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/masonry.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <!--微店內容頁 -->
    
        <div id="container">
            <asp:Repeater ID="RP1" runat="server"> 
                <ItemTemplate>
                    <div class='item'>
                        <div class='imgcenter'>
                            <div>
                                <asp:HyperLink ID="HL" runat="server" NavigateUrl='<%# Eval("IDNo","Product_Detail.aspx?entry={0}") %>' ImageUrl='<%# Bind("ImgPath") %>'></asp:HyperLink>
                                <%-- <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("ImgPath")%>' />--%>
                                <!--product name -->
                                <div style="product-name">
                                    <asp:Literal ID="PName" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Literal>
                                </div>
                                <div class="item-bar">
                                <button type="button" class="btn btn-default heart" onclick="alert('action1 by ajax');" data-toggle="dropdown" aria-expanded="false">
                                    <span class="glyphicon glyphicon-heart" aria-hidden="true"></span>
                                    <p id="ht10">1000</p>
                                </button>
                                    </div>
                                <div style="price">
                                    <asp:Literal ID="LPrice" runat="server" Text='<%# Eval("Price","{0:#,##0}") %>'></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate> 
            </asp:Repeater>
            <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
         </div>

    <div class='nav clearbox'>
        <asp:Literal ID="LMore" runat="server"></asp:Literal>
        <a href='http://sample.diary.tw/flickrsearch/index.php?p=2&q=rainbow'>.</a>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
    <script src="scripts/jquery.masonry.min.js"></script>
    <script src="scripts/jquery.swipebox.js"></script>


</asp:Content>