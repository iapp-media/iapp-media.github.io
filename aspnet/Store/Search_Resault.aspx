<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Search_Resault.aspx.vb" Inherits="Search_Resault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<div style="width: 640px" align="center">
            <h3><asp:Literal ID="LTitle" runat="server"></asp:Literal></h3>
    </div>--%>
    <div style="width: 640px">
        <div id="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Literal ID="L" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>