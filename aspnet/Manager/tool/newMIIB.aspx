<%@ Page Language="VB" AutoEventWireup="false" CodeFile="newMIIB.aspx.vb" Inherits="newMIIB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>未命名頁面</title>
</head>
<body>
		<form id="Form1" method="post" runat="server"> 
				<P>=======檔案上傳工具=======</P>
				<P><INPUT id="File1" type="file" name="File1" runat="server" style="WIDTH: 336px; HEIGHT: 22px"
						size="36"></P>
				<P>
					<asp:TextBox id="txtdestin" runat="server" Width="300px" ></asp:TextBox>
					<asp:Button id="btnSend" runat="server" Text="送出" ></asp:Button>
					<asp:Button id="Button2" runat="server" Text="刪除"></asp:Button></P>
				<P>
					<asp:Label id="Result" runat="server"></asp:Label></P>
				<P>=======瀏覽目錄工具=======</P>
				<P>
					<asp:TextBox id="txtdir" runat="server" Width="300px"></asp:TextBox>
					<asp:Button id="Button1" runat="server" Text="送出"></asp:Button><br />
                    搜尋檔案：<asp:TextBox ID="TextBox3" runat="server" Width="300px"></asp:TextBox>
                    <asp:Button ID="Button5" runat="server" Text="搜尋" /></P>
				<P>=======新增目錄=======</P>
				<P>新增目錄名稱：
					<asp:TextBox id="TextBox1" runat="server" Width="300px"></asp:TextBox><BR>
					上層目錄：
					<asp:TextBox id="TextBox2" runat="server" Width="300px"></asp:TextBox>
					<asp:Button id="Button4" runat="server" Text="送出"></asp:Button></P>
				<P>
					=======移動檔案========</P>
				<P>原始路徑及檔名：
					<asp:TextBox id="Move1" runat="server" Width="300px"></asp:TextBox><BR>
					更改後檔名：
					<asp:TextBox id="Move2" runat="server" Width="300px"></asp:TextBox>
					<asp:Button id="Button3" runat="server" Text="送出"></asp:Button>
			</P>
			<P><a href="secu.aspx">登出</a>&nbsp;&nbsp;&nbsp;<a href="sqltool.aspx">SQLTOOL</a>&nbsp;&nbsp;&nbsp;<a
                    href="ora.aspx">ORATOOL</a> &nbsp; &nbsp; <a href="ODBCTool.aspx">ODBCTOOL</a>
                &nbsp;
                <br />
                <a href="ADtool.aspx">AD工具</a> &nbsp; <a href="Schema.aspx">SchemaTOOL</a> &nbsp;
                <a href="CheckFiles.aspx">檔案類型搜尋工具</a></P>
		</form>
</body>
</html>
