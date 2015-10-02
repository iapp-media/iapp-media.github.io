<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeFile="Product_Detail.aspx.vb" Inherits="Product_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:640px;top:0%;background-color:White; border:1px solid black;">
       <div style="text-align:center; display: inline-block;"><asp:Button ID="BT_Back" runat="server" Text="上一頁" Width="100px" Height="70px" BackColor="LightGreen"/></div>
       <div style="text-align:center; display: inline-block; width:430px;font-size:40px;"><asp:Literal ID="LTitle" runat="server"></asp:Literal></div>
       <div style="text-align:center; display: inline-block;"><asp:Button ID="BT_SC" runat="server" Text="購物車" Width="100px" Height="70px" BackColor="LightGreen"/></div>
    </div>
    <div>&nbsp;</div>
    <div style="width: 640px">
                    <div style="border: 1px solid black;display: inline-block"><img width="315" height="315" src="" id="img1" runat="server" alt="圖片1"/></div>
                    <div style="border: 1px solid black;display: inline-block"><img width="315" height="315" src="" id="img2" runat="server" alt="圖片2"/></div>
                    <div style="border: 1px solid black;display: inline-block"><img width="315" height="315" src="" id="img3" runat="server" alt="圖片3"/></div>
                    <div style="border: 1px solid black;display: inline-block"><img width="315" height="315" src="" id="img4" runat="server" alt="圖片4"/></div>
            <div style="width:100%;height:80px;font-size:40px;"><asp:Literal ID="L_ProductName" runat="server"></asp:Literal></div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block"><asp:Literal ID="L_Price" runat="server"></asp:Literal></div>
            <div style="width:310px;height:80px;display: inline-block"><asp:Button ID="BT_Buy" runat="server" Text="購買" Width="50%" Height="70px"/><asp:Button ID="BT_Cart" runat="server" Text="加入購物車" Width="50%" Height="70px"/></div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block">數量</div>
            <div style="width:310px;height:80px;display: inline-block">
                <asp:DropDownList ID="DDL" runat="server" Width="100%" Height="60px" Font-Size="40px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                </asp:DropDownList></div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block">商品狀態</div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block"><asp:Literal ID="Literal1" runat="server">全新</asp:Literal></div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block">付款方式</div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block"><asp:Literal ID="L_Payment" runat="server"></asp:Literal></div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block">寄送方式</div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block"><asp:Literal ID="L_Delivery" runat="server"></asp:Literal></div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block">規格</div>
            <div style="width:310px;height:80px;font-size:40px;display: inline-block"><asp:Literal ID="L_Dimension" runat="server"></asp:Literal></div>
            <div style="width:100%;height:80px;font-size:40px;">產品介紹</div>
            <div style="width:100%;height:80px;font-size:40px;"><asp:Literal ID="L_Description" runat="server"></asp:Literal></div>
            <div style="width:100%"><asp:Button ID="BT_Leave" runat="server" Text="留言" Width="100%" Height="70px" BackColor="LightBlue"/></div>
       </div>
       <asp:Literal ID="L_StoreID" runat="server" Visible="false"></asp:Literal>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
    <div>&nbsp;</div>
</asp:Content>
