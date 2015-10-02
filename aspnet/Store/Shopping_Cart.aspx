<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Shopping_Cart.aspx.vb" Inherits="Shopping_Cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" width:640px">
    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="IDNo"
        AllowPaging="True" CssClass="gv_tb" BorderWidth="0px" CellPadding="5">
        <Columns>
            <asp:BoundField DataField="FilePath" HeaderText="圖片">
                <ItemStyle CssClass="gv_row" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Product_Name" HeaderText="品名">
                <ItemStyle CssClass="gv_row"  Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="價格">
                <ItemStyle CssClass="gv_row" Width="20%" />
            </asp:BoundField>
            <asp:ButtonField CommandName="CN" Text="取消">
                <ItemStyle HorizontalAlign="Center" Width="50px" CssClass="gv_row" />
            </asp:ButtonField>
        </Columns>
        <PagerStyle CssClass="PagerCss" />
        <HeaderStyle CssClass="gv_head" Font-Bold="False" />
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <div>&nbsp;</div>
    <asp:Button ID="Button1" runat="server" Text="送出" Width="100%" Height="70px" BackColor="LightBlue" />
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
    <asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
    </div>
    </form>
</body>
</html>
