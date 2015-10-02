<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<div style="width:640px; position:fixed; top:0">
        <div id="menu">
            <div style="float:left;width:80%"><asp:TextBox ID="TName" runat="server" Width="100%"></asp:TextBox></div>
            <div style="float:left;width:10%"><asp:Button ID="BT_Search" runat="server" Text="查詢" Width="100%" /></div>
        </div>
    </div>--%>
    <div style="width: 640px">
            <div><asp:TextBox ID="TName" runat="server" Width="100%" Height="70px" Font-Size="65px"></asp:TextBox></div>
            <div><asp:Button ID="BT_Search" runat="server" Text="查詢" Width="100%" Height="70px" BackColor="LightBlue"/></div>
            <div>&nbsp;</div>
            <div>瀏覽紀錄</div>
            <div>熱門品牌</div>
            <div>&nbsp;</div>
            <div>男裝</div>
            <div>女裝</div>
            <div>家電</div>
            <div>食品</div>
            <div>嬰兒用品</div>
            <div>美妝保養</div>
            <div>運動健身</div>
            <div>樂器</div>
            <div>書</div>
            <div>etc.</div>
    </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>