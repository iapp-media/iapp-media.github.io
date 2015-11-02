<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Product_Mana.aspx.cs" Inherits="StoreMana.Product_Mana" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12 allClassification swiper-container">
        <div class="row swiper-container">
            <ul class="swiper-wrapper">
                <li class="swiper-slide col-xs-4"><a href="Product_Add.aspx" style="color: white">商品建檔</a></li>
                <li class="swiper-slide col-xs-4"><a href="Product_Mana.aspx" style="color: white">商品列表</a></li>
                <li class="swiper-slide col-xs-4"><a href="Setting.aspx" style="color: white">參數設定</a></li>
            </ul>
        </div>
    </div>
        <div class="allmodify">
            <ul class="buydivmove">
                <li>
                    <div class="col-xs-12 insidecare">
                        <div class="row">
                            <div class="col-xs-12 libor paytheway PadLib">
                                   <label class="TBC">商品類別</label>
                                   <asp:DropDownList class="form-control marReset" ID="DL" runat="server">
                                   </asp:DropDownList>
                            </div>
                            <div class="col-xs-12 libor status CBbot CBBTN">
                                 <asp:Button ID="Button1" runat="server" Text="搜尋" CssClass="btn btn-warning col-xs-12 SBuyCar" OnClick="BT_Search_Click" />
                            </div>
                            <div class="col-xs-12 libor   CBline">
                        <div></div>
                    </div>
                             <div class="col-xs-12 libor status CBbot CBBTN BorObot">
                                  <input type="button" onclick="javascript: location.href = 'Product_Add.aspx'" value="新增商品" class="btn btn-warning col-xs-12 sendcareButtomeEnd" />
                            </div>
                            <div class="col-xs-12 libor paynumber padReset ManaLBG">
                                 <asp:Repeater ID="RP1" runat="server">
                <HeaderTemplate>
                    <div class="ProMLtit col-xs-12">
                        <div class="col-xs-12 ListTitle">商品名稱</div>
                        
                        <div class="col-xs-4 ListTitle">價格</div>
                        <div class="col-xs-4 ListTitle">建檔日期</div>
                        <div class="col-xs-4 ListTitle">&nbsp;</div>
                    </div>
                </HeaderTemplate> 
                <ItemTemplate>
                    <div class="ProMaBOX col-xs-12 ToBoPad">
                        <div class="ProMain col-xs-12">
                            <div>
                                <img src="img/000000102601.jpg" />
                            </div>
                            <div class="col-xs-12 ProLPad TtitleC BorTopno BorRightno BorLeftpno">
                                <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Product_Name")%>'></asp:Literal>
                            </div>

                            <div class="col-xs-4 ProLPad ProLtit TRC BorLeftpno BorBottompno">
                                <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Price")%>'></asp:Literal>
                            </div>
                            <div class="col-xs-4 ProLPad ProLtit TGray BorBottompno">
                                <asp:Literal ID="Literal3" runat="server" Text='<%# Bind("CDate")%>'></asp:Literal>
                            </div>

                            <div class="col-xs-4 ProLPad ProLtit TOCCenter BorRightno BorBottompno">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# ShowDetail(Eval("IDNo")) %>' CssClass="TOC">
                                     詳細資訊
                                </asp:HyperLink>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater> 
                                
                                    <%--<div class="listbox">
                                        <div class="list1">
                                            <div class="col-xs-6">商品名稱</div>
                                            <div class="col-xs-6">氣球</div>
                                        </div>
                                        <div class="list2">
                                            <div>
                                                <div class="col-xs-4">價格</div>
                                                <div class="col-xs-4">建檔日期</div>
                                                <div class="col-xs-4">詳細資料</div>
                                            </div>
                                            <div>
                                                <div class="col-xs-4">1</div>
                                                <div class="col-xs-4">2015/12/31</div>
                                                <div class="col-xs-4">你好你好你好</div>
                                            </div>
                                        </div>
                                    </div>--%>
                                <%--<div class="listbox col-xs-12">
                                    <div class="row">
                                    <div class="listbor">
                                    <div class="list1 col-xs-12">
                                        <div class="row">
                                        <div class="col-xs-3 listtit">商品名稱</div>
                                        <div class="col-xs-9 listval">氣球</div>
                                            </div>
                                    </div>
                                    <div class="list1 col-xs-12">
                                        <div class="row">
                                        <div class="col-xs-3 listtit">價格</div>
                                        <div class="col-xs-9 listval">12313</div>
                                         </div>
                                    </div>
                                    <div class="list1 col-xs-12">
                                        <div class="row">
                                        <div class="col-xs-3 listtit">建檔日期</div>
                                        <div class="col-xs-9 listval">2015/10/18</div>
                                            </div>
                                    </div>

                                    <div class="list1 col-xs-12">
                                        <div class="row">
                                        <div class="col-xs-3">詳細資料</div>
                                        <textarea name="" id="" cols="30" rows="3" class="col-xs-9 listval"></textarea>
                                            </div>
                                    </div>
                                    </div>
                                    </div>
                                </div>
                                <div class="listbox col-xs-12">
                                    <div class="row">
                                    <div class="listbor">
                                    <div class="list1 col-xs-12">
                                        <div class="row">
                                        <div class="col-xs-3 listtit">商品名稱</div>
                                        <div class="col-xs-9 listval">氣球</div>
                                            </div>
                                    </div>
                                    <div class="list1 col-xs-12">
                                        <div class="row">
                                        <div class="col-xs-3 listtit">價格</div>
                                        <div class="col-xs-9 listval">12313</div>
                                         </div>
                                    </div>
                                    <div class="list1 col-xs-12">
                                        <div class="row">
                                        <div class="col-xs-3 listtit">建檔日期</div>
                                        <div class="col-xs-9 listval">2015/10/18</div>
                                            </div>
                                    </div>

                                    <div class="list1 col-xs-12">
                                        <div class="row">
                                        <div class="col-xs-3">詳細資料</div>
                                        <textarea name="" id="Textarea1" cols="30" rows="3" class="col-xs-9 listval"></textarea>
                                            </div>
                                    </div>
                                    </div>
                                    </div>
                                </div>--%>
  
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
