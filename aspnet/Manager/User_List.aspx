<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="User_List.aspx.cs" Inherits="User_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" Runat="Server">
    <H3>使用者資料<H3>
    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" DataKeyNames="IDNo" OnRowCommand="GV_RowCommand" OnRowDataBound="GV_RowDataBound" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Account" HeaderText="EMail" />
            <asp:BoundField DataField="User_Name" HeaderText="使用者名稱" />
            <asp:BoundField DataField="fbID" HeaderText="fbID" />
            <asp:BoundField DataField="User_Type" HeaderText="使用者類型" />
            <asp:ButtonField ButtonType="Button" CommandName="Update" Text="修改" />
            <asp:ButtonField ButtonType="Button" CommandName="Del" Text="刪除" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" Text="送出" OnClick="Button1_Click" />
    <asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
</asp:Content>

