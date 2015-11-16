<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontPage.aspx.cs" Inherits="MiniStore.FrontPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    	<link rel="stylesheet" href="css/frontpage.css"/>
</head>
<body>
    <form id="form1" runat="server">
	<div class="FrontBox">
		<div></div>
		<div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
		<div><a href="Default.aspx?SN=OfficACC">開始體驗 >></a></div>
	</div>
    </form>
</body>
</html>
