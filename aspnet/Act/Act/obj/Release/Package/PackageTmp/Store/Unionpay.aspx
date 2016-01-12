<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unionpay.aspx.cs" Inherits="Act.Store.Unionpay" %>

<!DOCTYPE html> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body id="body" runat="server">
    <form runat="server" id="form1" method="post">
    <div>
        <%--交易過程中，請耐心等候授權回覆，勿關閉視窗或異動...<br>(Waiting for response...)--%>
        <asp:Label ID="Lmsg" runat="server"></asp:Label>
        <asp:HiddenField ID="MID" runat="server" />
        <asp:HiddenField ID="CID" runat="server" /> 
        <asp:HiddenField ID="ONO" runat="server" />
        <asp:HiddenField ID="TA" runat="server" /> 
        <asp:HiddenField ID="TT" runat="server" />
        <asp:HiddenField ID="U" runat="server" /> 
        <asp:HiddenField ID="TXNNO" runat="server" />
        <asp:HiddenField ID="M" runat="server" />
        <asp:Literal ID="L" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
