<%@ Page Title="" Language="C#" MasterPageFile="~/MiniMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StoreMana.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="BTNcontent">
        <asp:Button Text="商品管理" runat="server" CssClass="btn btn-warning  ButModdle DefButModdle" />
        <asp:Button ID="Button1" Text="客戶管理" runat="server" CssClass="btn btn-warning  ButModdle DefButModdle" />
        <asp:Button ID="Button2" Text="訂單管理" runat="server" CssClass="btn btn-warning ButModdle DefButModdle" />
        <asp:Button ID="Button3" Text="訊息管理" runat="server" CssClass="btn btn-warning ButModdle DefButModdle" />
        <asp:Button ID="Button4" Text="設定" runat="server" CssClass="btn btn-warning  ButModdle DefButModdle" />
    </div>
</asp:Content>
