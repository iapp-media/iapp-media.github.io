<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p04.aspx.vb" Inherits="AppWeb1._4.p04" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="margin:0px;padding:0;">
    <div style="width: 261px; height:464px">
        <div style="position:relative; width: 261px; height:236px">
            <asp:Image Style="width: 261px; height:236px" ID="Image1" ImageUrl="~/img/picture3-1.png" runat="server" />
        </div >
        <div style="float:left; position:relative; width: 125px; height:226px; border:solid 2px red">
             <asp:Image Style="width: 125px; height:226px;" ID="Image2" ImageUrl="~/img/picture3-2.png" runat="server" />
        </div>
        <div style="float:left;position:relative; width: 130px; height:226px; border:solid 2px green">
             <asp:Image style="width: 130px; height:226px;"  ID="Image3" ImageUrl="~/img/picture3-3.png" runat="server" />
        </div>

    </div>
</body>
</html>
