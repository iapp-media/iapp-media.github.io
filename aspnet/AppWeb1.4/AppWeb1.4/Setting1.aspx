<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Setting1.aspx.vb" Debug="true" Inherits="AppWeb1._4.Setting1" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>set</title>
    <link rel="stylesheet" href="css/reset.css" />
    <link href="css/button.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/set.css">
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="top">
                <h1>我的iApp設定</h1>
            </div>
            <div class="left">
                <h2>iApp封面圖片</h2>
                <div class="show">
                    <a id="show-upload" onclick="callAUL2()">
                        <asp:Image ID="Img_cover" CssClass="upload" runat="server" ImageUrl="img/uploadicon.png" />
                    </a>
                </div>
            </div>
            <div class="set">
                <div class="icon">
                    <a id="Hreficon" onclick="callAUL()">
                        <label for="FU1">
                            <asp:Image ID="p1" CssClass="iconimg-1" runat="server" ImageUrl="img/default-icon.png" />
                        </label>
                    </a>
                </div> 
                <table>
                    <tr>
                        <td class="text1title">
                             <p>iApp名稱<span class="colorRed">*</span></p>
                            <asp:TextBox ID="TAppName"  ForeColor="#CCCCCC"  onfocus="WaterMarkFocus(this,'必填(限10字)')" onblur="WaterMarkBlur(this,'必填(限10字)')" runat="server" CssClass="name" MaxLength="10"></asp:TextBox>
                            <%--Text="必填（限10字）"--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="text1title">
                            <span>iApp 描述</span>
                            <asp:TextBox ID="TAppMemo"   ForeColor="#CCCCCC"   onfocus="WaterMarkFocus(this,'(限140字)')" onblur="WaterMarkBlur(this,'(限140字)')" runat="server" CssClass="describe" TextMode="MultiLine" ValidateRequestMode="Disabled"></asp:TextBox>
                            <%--Text="(限140字）"--%>
                        </td>
                    </tr>
                </table>
            </div>
            <%--<div class="send">
                <p>--%>
                    <asp:LinkButton ID="sendOK" runat="server" CssClass="done-1"></asp:LinkButton>
              <%--  </p>
            </div>--%>
        </div>
    </form>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/JIC.js"></script>
    <script type="text/javascript">
        function WaterMarkFocus(txt, text) {
            if (txt.value == text) {
                txt.value = "";
                txt.style.color = "black";
            }
        }

        function WaterMarkBlur(txt, text) {
            if (txt.value == "") {
                txt.value = text;
                txt.style.color = "#ccc";
            }
        }
    </script>

    <script>
        function callAUL() {
            var YorN = getValue('i');
            $("#Hreficon").attr('href', 'Pages/AUL.aspx?Icon=' + YorN + "&w=100&h=100&list=" + getValue('i'))
        }
        function callAUL2() {
            $("#show-upload").attr('href', 'Pages/AUL.aspx?APCover=' + getValue('i') + '&w=640&h=1136&list=' + getValue('i'))
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
