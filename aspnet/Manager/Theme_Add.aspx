<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="Theme_Add.aspx.cs" Inherits="Theme_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="Server">
    <div>
        <asp:Label ID="Label6" runat="server" Text=" "></asp:Label>
        <br />
        <asp:Button ID="Button9" runat="server" Text="送出" OnClick="Button9_Click" />
        <table>
            <tr>
                <td>Theme_Name:</td>
                <td>
                    <asp:TextBox ID="Theme_Name" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="FoderName:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="FolderName" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Label ID="Label3" runat="server" Text="這是微頁的上半部:"></asp:Label>
        <asp:TextBox ID="Theme_head" runat="server" TextMode="MultiLine" Width="100%" Height="80px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="這是微頁的下半部:"></asp:Label>
        <asp:TextBox ID="Theme_foot" runat="server" TextMode="MultiLine" Width="100%" Height="80px"></asp:TextBox>
        (用Chrome操作，輸入框可以拖拉大小)  
    </div> 
</asp:Content>
