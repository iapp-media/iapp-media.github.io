<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinAs.aspx.cs" Inherits="MiniStore.JoinAs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="JoinBox">
            <div class="LOGO">
                <img src="img/img-1.jpg" alt="Alternate Text" />
            </div>
            <div class="Sendbox">
                <p>輸入您的微店店名</p>
                <asp:TextBox ID="TB_SNAME" runat="server"></asp:TextBox>
                <div>
                    <asp:Button ID="BT_SNAME" runat="server" Text="確定" CssClass="btn btn-warning sendcareButtomeEnd" OnClick="BT_SNAME_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>