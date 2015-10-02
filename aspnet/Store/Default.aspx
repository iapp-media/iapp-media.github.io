<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <div style="width: 640px">
                <div style="width: 155px; height: 100px; border: 1px solid black; display: inline-block;" onclick="location.href='Default.aspx?c=1'">類別1</div>
                <div style="width: 155px; height: 100px; border: 1px solid black; display: inline-block;" onclick="location.href='Default.aspx?c=2'">類別2</div>
                <div style="width: 155px; height: 100px; border: 1px solid black; display: inline-block;" onclick="location.href='Default.aspx?c=3'">類別3</div>
                <div style="width: 155px; height: 100px; border: 1px solid black; display: inline-block;" onclick="location.href='Default.aspx?c=4'">類別4</div>
            </div>
    <div style="width:640px;">
        <div id="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Literal ID="L" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
