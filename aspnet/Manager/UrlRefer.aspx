<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UrlRefer.aspx.cs" Inherits="UrlRefer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="side-body">
        <div class="page-title">
            <span class="title">瀏覽統計</span>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="card">
                    <div class="card-body">
                        瀏覽人數：<asp:Label ID="LB1" runat="server" Text=""></asp:Label>
                        <br /> 
                        <br /> 
                        <asp:GridView ID="GV" runat="server"></asp:GridView> 
                        <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
                        <asp:Literal ID="L" runat="server" Visible="false"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

