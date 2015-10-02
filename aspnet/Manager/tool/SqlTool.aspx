<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Sqltool.aspx.vb" Inherits="Search_Sqltool" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SQLTool</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp;
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:TextBox ID="TT" runat="server" Width="530px" Wrap="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
        <asp:TextBox ID="TB" runat="server" Height="200px" TextMode="MultiLine" Width="530px" Visible="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="Button1" runat="server" Text="NonQuery" Visible="False" />
        <asp:Button ID="Button2" runat="server" Text="GetGridview" Visible="False" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="L" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td>
        <asp:GridView ID="GV" runat="server">
        </asp:GridView>
        <asp:SqlDataSource ID="SD" runat="server"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;
        <p>
            <a href="secu.aspx">登出</a> &nbsp; <a href="sqltool.aspx">SQLTOOL</a> &nbsp; <a href="ora.aspx">
                ORATOOL</a> &nbsp; &nbsp; <a href="ODBCTool.aspx">ODBCTOOL</a> &nbsp;
            <br />
            <a href="ADtool.aspx">AD工具</a> &nbsp; <a href="Schema.aspx">SchemaTOOL</a> &nbsp;
            <a href="CheckFiles.aspx">檔案類型搜尋工具</a></p>
    </div>
    </form>
</body>
</html>
