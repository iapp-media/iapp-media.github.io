<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiniStore.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <ul> 
        <li class="product">
            <div id="container"> 
                <asp:Literal ID="LData" runat="server"></asp:Literal> 
            </div>
        </li>
      </ul>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footJs" runat="server">
</asp:Content>
