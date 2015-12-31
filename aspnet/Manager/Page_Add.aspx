<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Add.aspx.cs" ValidateRequest="false"  Inherits="Page_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
              <div class="side-body">
                    <div class="page-title">
                        <span class="title">頁面資料</span>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-body">
        <asp:Label ID="Label6" runat="server" Text=" "></asp:Label>
    <table class="form_tb">
        <tr>
            <td class="LC">
                <asp:Label ID="Label12" runat="server" Text="主題:"></asp:Label></td>
            <td>
                <asp:DropDownList ID="Theme_ID" runat="server">
                </asp:DropDownList>
            </td> 
            <td class="LC">
                <asp:Label ID="Label13" runat="server" Text="編輯類型:"></asp:Label></td>
            <td>
                <asp:DropDownList ID="EditStat" runat="server">
                    <asp:ListItem Value="1">單圖</asp:ListItem>
                    <asp:ListItem Value="2">單圖下文字</asp:ListItem>
                    <asp:ListItem Value="3">三張連圖</asp:ListItem>
                    <asp:ListItem Value="4">三張分割</asp:ListItem>
                    <asp:ListItem Value="5">中間文字</asp:ListItem>
                    <asp:ListItem Value="6">右下文字</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Page_Name:"></asp:Label></td>
            <td>
                <asp:TextBox ID="Page_Name" runat="server"></asp:TextBox></td>

            <td>
                <asp:Label ID="Label2" runat="server" Text="URL:"></asp:Label></td>
            <td>
                <asp:TextBox ID="URL" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="左邊用Page小圖:"></asp:Label></td>
            <td>
                <asp:TextBox ID="Img01" runat="server"></asp:TextBox></td> 
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="大圖1:"></asp:Label></td>
            <td>
                <asp:TextBox ID="Img01_b" runat="server"></asp:TextBox></td> 
            <td>
                <asp:Label ID="Label8" runat="server" Text="大圖2:"></asp:Label></td>
            <td>
                <asp:TextBox ID="Img02_b" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="大圖3:"></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="Img03_b" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="文字1:"></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="h1" runat="server" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="文字2:"></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="h2" runat="server" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="文字3:"></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="h3" runat="server" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Notes:"></asp:Label>

            </td>
            <td colspan="3">
                <asp:TextBox ID="Notes" runat="server" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Html:"></asp:Label> 
            </td>
            <td colspan="3">
                <asp:TextBox ID="Htmltext" runat="server" TextMode="MultiLine" Height="40px" Width="100%"></asp:TextBox> 
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button9" runat="server" Text="送出" OnClick="Button9_Click" /> 
            </td>
        </tr>
    </table>
                      </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


