<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="ThemeUpload.aspx.cs" Inherits="ThemeUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="選擇Css,img,js:" Font-Size="X-Large"></asp:Label>
    <asp:DropDownList ID="DDL1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL1_SelectedIndexChanged">
        <asp:ListItem>CSS</asp:ListItem>
        <asp:ListItem>JS</asp:ListItem>
        <asp:ListItem>Img</asp:ListItem>
        <asp:ListItem>Apps\CSS</asp:ListItem>
        <asp:ListItem>Apps\JS</asp:ListItem>
        <asp:ListItem>Apps\Img</asp:ListItem>
        <asp:ListItem>Apps\ME\CSS</asp:ListItem>
        <asp:ListItem>Apps\ME\JS</asp:ListItem>
        <asp:ListItem>Apps\ME\Img</asp:ListItem>
    </asp:DropDownList>
    <br />
        <br />
 
    <asp:FileUpload ID="FU1" runat="server" />
    <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="上傳" />
    <br />
           <asp:Literal ID="Result" runat="server"></asp:Literal>
        <br />
    <asp:Literal ID="LPath" runat="server"></asp:Literal>
    <asp:Literal ID="LFolder" runat="server"></asp:Literal>
    <asp:Literal ID="LN" Visible="false" runat="server"></asp:Literal>
    <br />
 
    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" CellPadding="3" OnRowDataBound="GV_RowDataBound" OnRowCommand="GV_RowCommand" DataKeyNames="filename">
        <Columns>
         <asp:BoundField DataField="items" HeaderText="項次" />
            <asp:HyperLinkField DataTextField="filename" HeaderText="檔案名稱" />
            <asp:BoundField DataField="filesize" HeaderText="檔案大小" />
            <asp:BoundField DataField="filetype" HeaderText="檔案大小" />
            <asp:ButtonField Text="刪除" CommandName="CN" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>

