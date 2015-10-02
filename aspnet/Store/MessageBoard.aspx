<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MessageBoard.aspx.vb" Inherits="MessageBoard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:640px;top:0%;background-color:White; border:1px solid black;">
       <div style="text-align:center; display: inline-block;"><asp:Button ID="BT_Back" runat="server" Text="上一頁" Width="100px" Height="70px" BackColor="LightGreen"/></div>
       <div style="text-align:center; display: inline-block;width:430px;font-size:40px;"><asp:Literal ID="LTitle" runat="server"></asp:Literal></div>
    </div>
    <div>&nbsp;</div>
    <div style="width:640px;">
        <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="IDNo" Font-Size="13px" Width="100%" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="Leave_ID" HeaderText="帳號">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Creat_Date" HeaderText="時間">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="cont" HeaderText="內容">
                <ItemStyle HorizontalAlign="Center" Width="60%"></ItemStyle>
            </asp:BoundField>
<%--            <asp:ButtonField ButtonType="Button" CommandName="CN1" HeaderText="" ShowHeader="True" Text="內容">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>--%>
        </Columns>
    </asp:GridView>
    <div>&nbsp;</div>
    <asp:TextBox ID="TB_Message" runat="server" Width="100%" Height="200" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="送出" Width="100%" Height="70px" BackColor="LightBlue" />
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
    <asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
    </div>
    <%--<div style="width:640px;position:fixed;top:90%;background-color:White;"><a href="" target="_self" id="LM" runat="server" ><img width="100%" height="20px" src="" alt="輸入留言" /></a></div>--%>
    </form>
</body>
</html>
