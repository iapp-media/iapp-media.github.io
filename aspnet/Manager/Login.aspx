<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" Runat="Server">
    <div>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="帳號:"></asp:Label></td>
            <td>
                <asp:TextBox ID="ACC" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="密碼:"></asp:Label></td>
            <td>
                <asp:TextBox ID="PW" runat="server"></asp:TextBox></td>
        </tr>
    </table>
        <asp:Button ID="Button1" runat="server" Text="Login" BorderStyle="Solid" OnClick="Button1_Click" /> 
        </div>
</asp:Content>

