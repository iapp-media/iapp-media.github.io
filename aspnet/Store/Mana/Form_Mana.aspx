<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Form_Mana.aspx.vb" Inherits="Mana_Form_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="page-header"  style=" width:640px">
            <div style="text-align: center;">
                <h1><asp:Literal ID="LTitle" runat="server">訂單管理</asp:Literal></h1>
            </div>
    </div>
    <div style=" width:640px">
    <table id="Table4" cellpadding="5" cellspacing="0" class="form_tb" width="100%">
        <tr>
            <td class="form_LC" style=" width:150px">
               訂單狀態：
            </td>
            <td class="form_RC">
                <asp:DropDownList ID="DDL_Status" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
                <tr>
            <td class="form_LC" style=" width:150px">
               訂單編號：
            </td>
            <td class="form_RC">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td class="form_LC">
                產品名稱：
            </td>
            <td class="form_RC">
                <asp:TextBox ID="TName" runat="server"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td class="form_LC" style=" width:150px">
               買家：
            </td>
            <td class="form_RC">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="form_LC">
            </td>
            <td class="form_RC">
                <asp:Button ID="Button1" runat="server" Text="查詢" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="IDNo"
        AllowPaging="True" CssClass="gv_tb" BorderWidth="0px" CellPadding="5">
        <Columns>
            <asp:BoundField DataField="IDNo" HeaderText="訂單編號">
                <ItemStyle CssClass="gv_row" Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="total" HeaderText="金額">
                <ItemStyle CssClass="gv_row"  Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="buy_ID" HeaderText="買家">
                <ItemStyle CssClass="gv_row" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="Status_ID" HeaderText="訂單狀態">
                <ItemStyle CssClass="gv_row" Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="Creat_Date" HeaderText="下單時間">
                <ItemStyle CssClass="gv_row" Width="25%" />
            </asp:BoundField>
            <asp:ButtonField CommandName="CN" Text="編輯">
                <ItemStyle HorizontalAlign="Center" Width="50px" CssClass="gv_row" />
            </asp:ButtonField>
        </Columns>
        <PagerStyle CssClass="PagerCss" />
        <HeaderStyle CssClass="gv_head" Font-Bold="False" />
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
    <asp:Literal ID="L" runat="server" Visible="False"></asp:Literal>
    </div>
    </form>
</body>
</html>
