<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TT.aspx.cs" Inherits="MiniStore.TT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="GOGO()" OnClick="Button1_Click" />
    </div>
        <script>
         var openOption = 'width=400,height=400';
            function GOGO() {
                location.href = 'https://tw.yahoo.com/'
                //window.open("https://tw.yahoo.com/");
            }
   
 

        </script>
    </form>
</body>
</html>
