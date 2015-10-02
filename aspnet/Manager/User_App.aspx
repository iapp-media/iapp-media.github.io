<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/Manager.master" AutoEventWireup="true" CodeFile="User_App.aspx.cs" Inherits="User_App" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_content" runat="Server">
    <h3>iApp管理</h3>
        <asp:Label ID="Label1" runat="server" Text="選擇使用者:"></asp:Label><asp:DropDownList ID="DL_User" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DL_User_SelectedIndexChanged"></asp:DropDownList>
    <div style="margin:10px 0 0 0;width:100%">
        <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" DataKeyNames="IDNo" OnRowCommand="GV_RowCommand" OnRowDataBound="GV_RowDataBound" AllowPaging="True" Width="100%">
            <Columns>
                <asp:BoundField DataField="User_Name" HeaderText="使用者名稱" />
                <asp:BoundField DataField="Theme_ID" HeaderText="主題" />
                <asp:BoundField DataField="App_Name" HeaderText="iApp名稱" />
                <asp:BoundField DataField="App_Memo" HeaderText="iApp描述" />
<%--                <asp:BoundField DataField="App_Name" HeaderText="微創作數" />--%>
                <asp:BoundField DataField="Pshare" HeaderText="熱分享數" />
                <asp:BoundField DataField="VC" HeaderText="VC病毒系數" />
                <asp:BoundField DataField="Pgood" HeaderText="點讚數" />
                <asp:BoundField DataField="Plike" HeaderText="like數" />
                <asp:BoundField DataField="Pfavor" HeaderText="收藏數" />
                <asp:BoundField DataField="Create_Date" HeaderText="創建時間"  HtmlEncode="false" DataFormatString="{0:d}"/>
                <asp:ButtonField ButtonType="Button" CommandName="CN" Text="修改" /> 
              <%--  <asp:ButtonField ButtonType="Button" CommandName="Del" Text="刪除" />--%>
            </Columns>
        </asp:GridView>

    </div>
        <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
        <asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
</asp:Content>

