<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mprev.aspx.cs" Inherits="AppPortal.mprev" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no">
    <title>iApp mobille</title>
    <link rel="stylesheet" href="css/reset.css" /> 
    <link rel="stylesheet" href="css/mprev.css" />
</head>
<body>
    <div class="apps-bar">
        <a href="" onclick="history.back(-1);">
            <img class="back" src="img/back-1.png"></a>
        <a id="top" href="">
            <img class="new" src="img/new-1.png"></a>
        <section class="content">
            <ul class="list">
                <li class="list__item good">
                    <input type="checkbox" id="c1" value="likeNumber">
                    <label for="c1">
                    </label>
                </li>
                <li class="list__item like">
                    <input type="checkbox" id="c2" value="loveNumber">
                    <label for="c2">
                    </label>
                </li>
                <li class="list__item startoggle">
                    <input type="checkbox" id="c3" value="starNumber">
                    <label for="c3">
                    </label>
                </li>
            </ul>
        </section>
    </div>
    <asp:Literal ID="LApp" runat="server"></asp:Literal>
    <script src="js/jquery-1.8.0.min.js"></script>
    <script src="js/mprev.js"></script>
</body>
</html>
