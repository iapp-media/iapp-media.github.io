<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Order_Detail.aspx.vb" Inherits="Mana_Order_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:640px;font-size:x-large;padding: 10px 10px 10px 10px;">
        
        <div style="width:250px;display: inline-block;"><img  width="180" height="150" src="" alt="產品圖" id="imgPP" runat="server" /></div>
        <div style="width:380px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
        <div>&nbsp;</div>
        <div style="width:200px;display: inline-block;font-size:40px;">數量</div>
        <div style="width:430px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal2" runat="server"></asp:Literal></div>

        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">付款金額</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal5" runat="server"></asp:Literal></div>
            
        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">付款方式</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal6" runat="server">面交</asp:Literal></div>

        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">寄送方式</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal7" runat="server">面交</asp:Literal></div>

        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">訂單編號</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal8" runat="server"></asp:Literal></div>

        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">買家</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal3" runat="server"></asp:Literal></div>

        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">E-Mail</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal10" runat="server"></asp:Literal></div>

        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">電話</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal4" runat="server"></asp:Literal></div>

        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">地址</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:Literal ID="Literal9" runat="server"></asp:Literal></div>

        <div style="width:200px;height:80px;display: inline-block;font-size:40px;">訂單狀態</div>
        <div style="width:430px;height:80px;display: inline-block;font-size:40px;"><asp:DropDownList ID="DropDownList1" runat="server" Width="100%" Height="60px" Font-Size="40px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="1">未付款</asp:ListItem>
                <asp:ListItem Value="2">未發貨</asp:ListItem>
                <asp:ListItem Value="3">已發貨</asp:ListItem>
                <asp:ListItem Value="4">交易完成</asp:ListItem>
                <asp:ListItem Value="5">交易取消</asp:ListItem>
            </asp:DropDownList></div>
        <div align="center"><asp:Button ID="BT_C" runat="server" Text="確認" Width="100%" Height="70px" BackColor="LightBlue" /></div>
    </div>

    </form>
</body>
</html>
