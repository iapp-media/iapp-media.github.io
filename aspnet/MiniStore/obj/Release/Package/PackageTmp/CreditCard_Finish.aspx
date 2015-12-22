<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCard_Finish.aspx.cs" Inherits="MiniStore.CreditCard_Finish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <div id="Div1" runat="server" visible="false">
                回覆碼RC 
                <asp:Literal ID="LRC" runat="server"></asp:Literal>  <br />
                特店代碼MID 
                <asp:Literal ID="LMID" runat="server"></asp:Literal>   <br />
                訂單編號ONO 
                <asp:Literal ID="LONO" runat="server"></asp:Literal>   <br />
                收單交易日期LTD 
                <asp:Literal ID="LLTD" runat="server"></asp:Literal>   <br />
                收單交易時間LTT 
                <asp:Literal ID="LLTT" runat="server"></asp:Literal>   <br />
                簽帳單序號RRN            
                <asp:Literal ID="LRRN" runat="server"></asp:Literal>   <br />
                授權碼AIR                            
                <asp:Literal ID="LAIR" runat="server"></asp:Literal>   <br />
                卡號AN 
                <asp:Literal ID="LAN" runat="server"></asp:Literal>   <br />
                押碼M 
                <asp:Literal ID="LM2" runat="server"></asp:Literal>   <br />
                本機驗證押碼 
		        <asp:Literal ID="LM2_chk" runat="server"></asp:Literal>   <br />

    </div>
    </form>
</body>
</html>
