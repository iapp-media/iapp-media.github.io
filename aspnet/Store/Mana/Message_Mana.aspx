<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Message_Mana.aspx.vb" Inherits="Mana_Message_Mana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--           <div style="width: 640px">
                    <h1><asp:Literal ID="LTitle" runat="server">訊息管理</asp:Literal></h1>
    </div>--%>
    <div>&nbsp;</div>
    <div style=" width:640px">
            <%--<div style="text-align:center;">買家</div>--%>
            <div><asp:TextBox ID="TextBox1" runat="server" Width="620px" Height="70px" Font-Size="65px" placeholder="請輸入留言人"></asp:TextBox></div>
            <div>&nbsp;</div>
            <%--<div style="text-align:center;">商品編號</div>--%>
            <div><asp:TextBox ID="TextBox2" runat="server" Width="620px" Height="70px" Font-Size="65px" placeholder="請輸入商品編號"></asp:TextBox></div>
<%--        <tr>
            <td style="width:15%">產品名稱</td>
            <td style="width:15%">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td style="width:15%">訂單狀態</td>
            <td style="width:15%">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="1">未付款</asp:ListItem>
                    <asp:ListItem Value="2">未發貨</asp:ListItem>
                    <asp:ListItem Value="3">已發貨</asp:ListItem>
                    <asp:ListItem Value="4">交易完成</asp:ListItem>
                    <asp:ListItem Value="5">交易取消</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
        <div>&nbsp;</div>
                <div style="display: inline-block;width:315px;text-align:center"><asp:Button ID="BT_S" runat="server" Text="搜尋"  Width="300px" Height="70px" BackColor="LightGreen" /></div>
                <div style="display: inline-block;width:315px;text-align:center"><asp:Button ID="BT_R" runat="server" Text="重置"  Width="300px" Height="70px" BackColor="LightPink" /></div>
    <div>&nbsp;</div>
    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="IDNo,Product_ID"
        AllowPaging="True" CssClass="gv_tb" BorderWidth="0px" CellPadding="5">
        <Columns>
            <asp:BoundField DataField="product_ID" HeaderText="商品">
                <ItemStyle CssClass="gv_row" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="leave_ID" HeaderText="留言人">
                <ItemStyle CssClass="gv_row"  Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="cont" HeaderText="訊息">
                <ItemStyle CssClass="gv_row" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="Creat_Date" HeaderText="時間">
                <ItemStyle CssClass="gv_row" Width="20%" />
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
</asp:Content>
