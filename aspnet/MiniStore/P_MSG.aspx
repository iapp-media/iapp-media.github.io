<%@ Page Title="" Language="C#" MasterPageFile="~/BuyFont.Master" AutoEventWireup="true" CodeBehind="P_MSG.aspx.cs" Inherits="MiniStore.P_MSG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style >
        .col2 {
            border:1px solid red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="buydivmove">
        <li class="productcare col-xs-12">
            <div class="col-xs-12  ">
                  <div class="row">
                    <img src="img/114.png" />
                    <asp:Literal ID="PName" runat="server"></asp:Literal>
                    <asp:Literal ID="PPrice" runat="server"></asp:Literal>
                </div>
                <div class="row">
                    <div class="col-xs-12 libor productsinside">
 <asp:Repeater ID="RP1" runat="server">
                <HeaderTemplate> 
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="row1">
                        <div class="col2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("Question")%>'></asp:Literal>
                               <asp:Literal ID="Literal4" runat="server" Text='<%# Bind("agoday")%>'></asp:Literal>
                        </div>
                        <div class="col2">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Bind("Ans")%>'></asp:Literal>
                        </div> 
                    </div> 
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
            <asp:SqlDataSource ID="SD1" runat="server"></asp:SqlDataSource>

                    </div>
                       <div class="row"> 
                           <asp:TextBox ID="tbQuen" runat="server"    AutoPostBack="true"   Class="form-control "></asp:TextBox>
                           <asp:Button ID="btsend" runat="server" Text="發送" OnClick="btsend_Click"  CssClass="btn btn-warning col-xs-2 sendcareButtom"  OnClientClick="fun2()"/>
                       </div>

                </div> 
            </div>
        </li>
    </ul>
 
</asp:Content>
