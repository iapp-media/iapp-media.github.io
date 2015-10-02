<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Product_Add.aspx.vb" Inherits="Mana_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <div style=" width:640px">
            <h1><asp:Literal ID="LTitle" runat="server">編輯商品</asp:Literal></h1>
    </div>--%>
    <div>&nbsp;</div>
    <div style=" width:640px">
            <div>
                <label id="upload1" for="FU1"><img  height="80" width="100" src="../upload/2.jpg" id="imgA" runat="server" alt="圖片上傳1"/></label><asp:FileUpload ID="FU1" runat="server" Width="240px" style="display:none" />
                <asp:Button ID="Button1" runat="server" CssClass="btn" Text="test" />&nbsp;
                <label id="upload2" for="FU2"><img  height="80" width="100" src="../upload/2.jpg" id="imgB" runat="server" alt="圖片上傳2"/></label><asp:FileUpload ID="FU2" runat="server" Width="240px" style="display:none" />&nbsp;
                <label id="upload3" for="FU3"><img  height="80" width="100" src="../upload/2.jpg" id="imgC" runat="server" alt="圖片上傳3"/></label><asp:FileUpload ID="FU3" runat="server" Width="240px" style="display:none" />&nbsp;
                <label id="upload4" for="FU4"><img  height="80" width="100" src="../upload/2.jpg" id="imgD" runat="server" alt="圖片上傳4"/></label><asp:FileUpload ID="FU4" runat="server" Width="240px" style="display:none" />
            </div>
            <div style="text-align:center;">商品名稱</div>
            <asp:TextBox ID="TB_ProductName" runat="server" Width="100%" Height="70px" Font-Size="65px" placeholder="請輸入商品名稱"></asp:TextBox>
            <div style="text-align:center;">商品類別</div>
            <asp:DropDownList ID="DDL_Cate" runat="server" Width="100%" Height="70px" Font-Size="65px"></asp:DropDownList>
            <div style="text-align:center;">單位</div>
            <asp:DropDownList ID="DDL_Unit" runat="server" Width="100%" Height="70px" Font-Size="65px">
                <asp:ListItem>個</asp:ListItem>
                </asp:DropDownList>
            <div style="text-align:center;">商品價格</div>
            <div><asp:TextBox ID="TB_Price" runat="server" Width="100%" Height="70px" Font-Size="65px" placeholder="請輸入商品價格"></asp:TextBox></div>
            <div style="text-align:center;">付款方式</div>
            <div><asp:DropDownList ID="DDL_Payment" runat="server" Width="100%" Height="70px" Font-Size="65px">
                 <asp:ListItem>面交</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="text-align:center;">寄送方式</div>
            <div><asp:DropDownList ID="DDL_Delivery" runat="server" Width="100%" Height="70px" Font-Size="65px">
                <asp:ListItem>面交</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="text-align:center;">庫存量</div>
            <div><asp:TextBox ID="TB_Stock" runat="server" Width="100%" Height="70px" Font-Size="65px" placeholder="請輸入庫存量">1</asp:TextBox></div>
            <div style="text-align:center;">販售狀態</div>
            <div><asp:DropDownList ID="DDL_OnSale" runat="server" Width="100%" Height="70px" Font-Size="65px">
                <asp:ListItem>上架</asp:ListItem>
                <asp:ListItem>下架</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="text-align:center;">商品狀態</div>
            <div><asp:DropDownList ID="DDL_Status" runat="server" Width="100%" Height="70px" Font-Size="65px">
                <asp:ListItem>全新</asp:ListItem>
                <asp:ListItem>中古</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="text-align:center;">商品規格</div>
            <div><asp:TextBox ID="TB_Dimension" runat="server" Width="100%" Height="70px" Font-Size="65px" placeholder="請輸入商品規格"></asp:TextBox></div>
            <div style="text-align:center;">商品介紹</div>
            <div><asp:TextBox ID="TB_Description" runat="server" TextMode="MultiLine" Width="100%" Height="70px" Font-Size="65px" placeholder="請輸入商品介紹"></asp:TextBox></div>
            <div style="text-align:center;">貨號</div>
            <div><asp:TextBox ID="TB_ProductNo" runat="server" Width="100%" Height="70px" Font-Size="65px" placeholder="請輸入貨號"></asp:TextBox></div>
            <div style="text-align:center;">條碼</div>
            <div><asp:TextBox ID="TB_BarCode" runat="server" Width="100%" Height="70px" Font-Size="65px" placeholder="請輸入條碼"></asp:TextBox></div>
            <div style="text-align:center;">備註</div>
            <div><asp:TextBox ID="TB_Memo" runat="server" Width="100%" Height="70px" Font-Size="65px" placeholder="請輸入備註"></asp:TextBox></div>
            <div>&nbsp;</div>
            <div style="display: inline-block;width:315px;text-align:center"><asp:Button ID="BT" runat="server" CssClass="btn" Text="儲存送出" Width="300px" Height="70px" BackColor="LightGreen" /></div>
            <div style="display: inline-block;width:315px;text-align:center"><asp:Button ID="BTD" runat="server" CssClass="btn" Text="取消" Width="300px" Height="70px" BackColor="LightPink" /></div>
    </div>
    <asp:Literal ID="LP1" runat="server" ></asp:Literal>
    <asp:Literal ID="LP2" runat="server" ></asp:Literal>
    <asp:Literal ID="LP3" runat="server" ></asp:Literal>
    <asp:Literal ID="LP4" runat="server" ></asp:Literal>
</asp:Content>