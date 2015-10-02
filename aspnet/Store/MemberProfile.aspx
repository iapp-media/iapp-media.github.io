<%@ Page Language="VB"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MemberProfile.aspx.vb" Inherits="MemberProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <%--  <div class="page-header" style="width: 640px">
        <div align="center">
            <h1>
                <asp:Literal ID="LTitle" runat="server">個人頁面</asp:Literal></h1>
        </div>
    </div>--%>
    <div style="width:640px;position:fixed;top:90%;background-color:White;">
        <div id="menu">
            <div style="float:left;width:24%; border:1px solid black;" onclick="location.href='Default.aspx'">首頁</div>
            <div style="float:left;width:25%; border:1px solid black;" onclick="location.href='Favorite.aspx'">最愛</div>
            <div style="float:left;width:25%; border:1px solid black;" onclick="location.href='Search.aspx'">搜尋</div>
            <div style="float:left;width:24%; border:1px solid black;" onclick="location.href='MemberProfile.aspx'">設定</div>
        </div>
    </div>
</asp:Content>
