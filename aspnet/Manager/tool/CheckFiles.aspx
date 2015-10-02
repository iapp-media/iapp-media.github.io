<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CheckFiles.aspx.vb" Inherits="CheckFiles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        檔案列表工具<br />
        搜尋目錄：<asp:TextBox ID="txtdir" runat="server" Width="300px"></asp:TextBox><br />
        檔案類型：
        <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Button1" runat="server" Text="開始搜尋" /><br />
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
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
