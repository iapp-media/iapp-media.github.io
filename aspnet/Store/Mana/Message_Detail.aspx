<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Message_Detail.aspx.vb" Inherits="Mana_Message_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>&nbsp;</div>
    <div style="width:640px">
    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="3" DataKeyNames="IDNo" Font-Size="13px" Width="100%">
        <Columns>
            <asp:BoundField DataField="Leave_ID" HeaderText="帳號">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="cont" HeaderText="內容">
                <ItemStyle HorizontalAlign="Center" Width="60%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Creat_Date" HeaderText="時間">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
<%--            <asp:ButtonField ButtonType="Button" CommandName="CN1" HeaderText="" ShowHeader="True" Text="內容">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>--%>
        </Columns>
    </asp:GridView>
    <div>&nbsp;</div>
    <asp:TextBox ID="TB_Message" runat="server" Width="100%" Height="200" TextMode="MultiLine" Font-Size="65px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="送出" Width="100%" Height="70px" BackColor="LightBlue" />
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
    <asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
    </div>
</asp:Content>
