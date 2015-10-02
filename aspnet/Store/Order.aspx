<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Order.aspx.vb" Inherits="Order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:640px;font-size:40px;">
       <div style="width:250px;display: inline-block"><img  width="180" height="150" src="" alt="產品圖" id="imgPP" runat="server" /></div>
       <div style="width:380px;display: inline-block"><asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
        <div>&nbsp;</div>
       <div style="width:200px;display: inline-block;">數量</div>
       <div style="width:430px;display: inline-block"><asp:Literal ID="Literal2" runat="server"></asp:Literal></div>
       <div style="width:200px;height:30px;display: inline-block;height:80px;">商品狀態</div>
       <div style="width:430px;height:30px;display: inline-block;height:80px;"><asp:Literal ID="Literal3" runat="server"></asp:Literal></div>
        <div style="width:200px;height:30px;display: inline-block;height:80px;">商品售價</div>
        <div style="width:430px;height:30px;display: inline-block;height:80px;"><asp:Literal ID="Literal4" runat="server"></asp:Literal></div>
        <div style="width:200px;height:30px;display: inline-block;height:80px;">付款金額</div>
        <div style="width:430px;height:30px;display: inline-block;height:80px;"><asp:Literal ID="Literal5" runat="server"></asp:Literal></div>
        <div style="width:200px;height:30px;display: inline-block;height:80px;">付款方式</div>
        <div style="width:430px;height:30px;display: inline-block;height:80px;"><asp:Literal ID="Literal6" runat="server">面交</asp:Literal></div>
        <div style="width:200px;height:30px;display: inline-block;height:80px;">寄送方式</div>
        <div style="width:430px;height:30px;display: inline-block;height:80px;"><asp:Literal ID="Literal7" runat="server">面交</asp:Literal></div>
        <div><asp:Button ID="BT_C" runat="server" Text="確認購物內容" Width="100%" Height="70px" BackColor="LightBlue" /></div>
    </div>
    </form>
</body>
</html>
