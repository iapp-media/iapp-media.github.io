<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Store_Mana.aspx.vb" Inherits="Mana_Store_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--    <div style="width: 640px">
            <h1><asp:Literal ID="LTitle" runat="server">商店設定</asp:Literal></h1>
    </div>--%>
    <div>&nbsp;</div>
    <div style="width: 640px">
        <div><asp:TextBox ID="TB_StoreName" runat="server"  Width="620px" Height="70px" Font-Size="65px" placeholder="請輸入您的商店名稱"></asp:TextBox></div>
        <div>&nbsp;</div>
        <div><asp:TextBox ID="TB_UserNamer" runat="server"  Width="620px" Height="70px" Font-Size="65px" placeholder="請輸入您的姓名"></asp:TextBox></div>
        <div>&nbsp;</div>
        <div><asp:TextBox ID="TB_Tel" runat="server"  Width="620px" Height="70px" Font-Size="65px" placeholder="請輸入您的電話"></asp:TextBox></div>
        <div>&nbsp;</div>
        <div><asp:TextBox ID="TB_Email" runat="server"  Width="620px" Height="70px" Font-Size="65px" placeholder="請輸入您的Email"></asp:TextBox></div>
        <div>&nbsp;</div>
        <div><asp:TextBox ID="TB_Addr" runat="server"  Width="620px" Height="70px" Font-Size="65px" placeholder="請輸入您的地址"></asp:TextBox></div>
        <div>&nbsp;</div>        
        <div style="display: inline-block;width:315px;text-align:center"><asp:Button ID="BTS" runat="server" CssClass="btn" Text="儲存" Width="300px" Height="70px" BackColor="LightGreen" /></div>
                <div style="display: inline-block;width:315px;text-align:center"><asp:Button ID="BTD" runat="server" CssClass="btn" Text="取消" Width="300px" Height="70px" BackColor="LightPink" /></div>
    </div>
</asp:Content>
