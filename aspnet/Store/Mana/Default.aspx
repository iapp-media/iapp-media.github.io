<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Mana_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <div style="width: 640px;text-align:center;">
          <h1> <asp:Literal ID="LTitle" runat="server">店名</asp:Literal></h1>
        </div>--%>
    <div>&nbsp;</div>
    <div style="width: 640px;">
        <div><asp:TextBox ID="TName" runat="server" Width="620px" Height="70px" Font-Size="65px" placeholder="請輸入商品名稱"></asp:TextBox></div>
        <div>&nbsp;</div>
        <div><asp:DropDownList ID="DDL_Cate" runat="server" Width="620px" Height="70px" Font-Size="65px"></asp:DropDownList></div>
        <div>&nbsp;</div>
        <div style="display: inline-block;width:315px;text-align:center"><asp:Button ID="BT_Search" runat="server" Text="搜尋" Width="300px" Height="70px" BackColor="LightGreen"/></div>
        <div style="display: inline-block;width:315px;text-align:center"><asp:Button ID="BT_Add" runat="server" Text="新增" Width="300px" Height="70px" BackColor="LightPink"/></div>
    <div>&nbsp;</div>
    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="IDNo"
        AllowPaging="True" CssClass="gv_tb" BorderWidth="0px" CellPadding="5">
        <Columns>
            <asp:BoundField DataField="FilePath" HeaderText="圖片">
                <ItemStyle CssClass="gv_row" Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="Product_Name" HeaderText="品名">
                <ItemStyle CssClass="gv_row"  Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="價格">
                <ItemStyle CssClass="gv_row" Width="20%" />
            </asp:BoundField>
<%--            <asp:BoundField DataField="Creat_Date" HeaderText="日期">
                <ItemStyle CssClass="gv_row" Width="20%" />
            </asp:BoundField>--%>
            <asp:ButtonField CommandName="CN" Text="編輯" Visible="false">
                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="gv_row" />
            </asp:ButtonField>
        </Columns>
        <PagerStyle CssClass="PagerCss" />
        <HeaderStyle CssClass="gv_head" Font-Bold="False" />
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
    <asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
    </div>
</asp:Content>
