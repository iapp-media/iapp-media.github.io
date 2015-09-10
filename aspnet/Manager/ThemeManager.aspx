<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="ThemeManager.aspx.cs" Inherits="ThemeManager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" Runat="Server">
    <h3>主題資料 設定</h3>
        <asp:Button ID="Btn" runat="server" Text="新增" OnClick="Btn_Click" />
    <asp:GridView ID="GV" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IDNo" OnRowCommand="GV_RowCommand" OnRowDataBound="GV_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Theme_Name" HeaderText="Theme_Name" />
            <asp:BoundField DataField="FoderName" HeaderText="存放資料夾名稱" />
            <asp:ButtonField ButtonType="Button" CommandName="Update" Text="修改" />
            <asp:ButtonField ButtonType="Button" CommandName="Del" Text="刪除" />
            <asp:ButtonField CommandName="UploadFiles" Text="上傳資料" />
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
<asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
</asp:Content>
