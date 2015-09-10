<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="User_Add.aspx.cs" Inherits="User_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" Runat="Server">
      <div style="margin-left: auto; margin-right: auto; width: 500px;">
          <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Account:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="Account" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="Password" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="User_Name:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="User_Name" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>
                   <asp:Label ID="Label3" runat="server" Text="fbID:"></asp:Label></td>
                <td>
                     <asp:TextBox ID="fbID" runat="server" ></asp:TextBox></td>
            </tr>
             <tr>
                <td>
                     <asp:Label ID="Label4" runat="server" Text="User_Type:"></asp:Label></td>
                <td>
                     <asp:TextBox ID="User_Type" runat="server"></asp:TextBox></td>
            </tr>

        </table>
        <asp:Button ID="Button9" runat="server" Text="送出" OnClick="Button9_Click" />
    </div>
    
</asp:Content>

