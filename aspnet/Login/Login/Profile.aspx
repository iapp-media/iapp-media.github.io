<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Login.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Document</title>
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" type="text/css" href="css/profile.css" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="top">
                <p>會員資料</p>
                <div class="bar3"></div>
            </div>
            <!-- 基本資料區域 -->
            <div class="profile">
                <div class="HeadMove">
                    <div class="logo-file">
                            <asp:Image ID="p1" CssClass="icon" runat="server" ImageUrl="img/headimg.png" />
                                <a id="show-upload" class='#' href='javascrip:void(0)' onclick="callAUL()">  
                    <p>選擇檔案</p>
                        </a>
                    </div>
                </div>
                <table class="t1">
                    <tr>
                        <th>姓 名</th>
                        <th>
                            <asp:TextBox ID="TName" runat="server"></asp:TextBox>
                            <br />
                        </th>
                    </tr>
                    <tr>
                        <th>電 話</th>
                        <th>
                            <asp:TextBox ID="Tphone" runat="server"></asp:TextBox>
                            <br />
                        </th>
                    </tr>
                    <tr>
                        <th>更改密碼</th>
                        <th>
                            <asp:TextBox ID="pw1" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                        </th>
                    </tr>
                    <tr>
                        <th>再次確認</th>
                        <th>
                            <asp:TextBox ID="pw2" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                        </th>
                    </tr>
                </table>
            </div>
            <asp:LinkButton ID="BtnSend" runat="server" OnClick="BtnSend_Click" ></asp:LinkButton>
            <asp:LinkButton ID="BTCancel" runat="server" OnClientClick="window.parent.ref()"></asp:LinkButton>
        </div>
       
    </form>

    <script src="js/edit.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="js/jquery.url.js"></script>
    <script src="js/jquery.colorbox-min.js"></script>
    <script> 
        function readCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }
        function callAUL() {
            var YorN = getValue('i');
            $("#show-upload").attr('href', 'AUL.aspx?Profile=' + readCookie('iapp_uid') + "&w=100&h=100");
        }
        function getValue(varname) {
            var url = window.location.href;
            try {
                var qparts = url.split("?");
                if (qparts.length == 0) {
                    return "";
                }
                var query = qparts[1];
                var vars = query.split("&");
                var value = "";
                for (i = 0; i < vars.length; i++) {
                    var parts = vars[i].split("=");
                    if (parts[0] == varname) {
                        value = parts[1];
                        break;
                    }
                }
                value = unescape(value);
                value.replace(/\+/g, " ");
                return value;
            } catch (err) {
                return "";
            }
        }

    </script>
</body>
</html>
