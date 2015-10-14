<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Setting2.aspx.vb" Inherits="AppWeb1._4.Setting2" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>set2</title>
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" type="text/css" href="css/set2.css">
    <link rel="stylesheet" href="css/button.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="aspNetHidden">
            </div>
            <div class="aspNetHidden">
            </div>
            <div class="container">
                <div class="left">
                    <h2>iApp封面圖片</h2>
                    <div class="show">
                        <a id='APCover' onclick="callAUL2()" href="javascrip:void(0)">
                            <img id="Img1" runat="server" src="img/uploadicon.png" />
                        </a>
                    </div>
                </div>
            </div>
            <div class="set">
                <div class="icon">
                    <a class='GG' onclick="callAUL()" href="javascrip:void(0)">
                        <img id="p1" class="icon" runat="server" src="img/iconimg-1.png" />
                    </a>
                </div>
                <table>
                    <tr>
                        <td class="text1title">
                            <p>iApp名稱<span class="colorRed">*</span></p>
<%--                            <input id="TAppName" runat="server" class="name" placeholder="必填(限10字)" />--%>
                          
                            <asp:TextBox ID="TAppName" runat="server" CssClass="name" placeholder="必填(限10字)"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text1title">
                            <span>iApp 描述</span>
                          <%--  <input id="TAppMemo" runat="server" class="describe" placeholder="(限140字)" />--%>
                           <asp:TextBox ID="TAppMemo" runat="server" CssClass="describe" placeholder="(限140字)"   TextMode="MultiLine"></asp:TextBox>

                        </td>
                    </tr>
                </table>
            </div>
            <asp:LinkButton ID="send" runat="server" CssClass="send done-1" OnClientClick="GOSlideClear()" Text="完成"></asp:LinkButton><%--完成--%>
        </div>

    </form>
    <script src="js/JIC.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="js/jquery.colorbox-min.js"></script>
    <script>
        var uri = location.search;
        var obj = {};  //Object
        $(document).ready(function () {
            function parsrQueryString(uri) {
                var string_array = [];//Array
                var string_array = uri.replace('?', '').split("&");
                //replace('?','')拿掉第一個問號

                for (var i = 0; i < string_array.length; i++) {
                    //console.log(string_array[i].split('=')[0]);     //[0]取得key name
                    //console.log(string_array[i].split('=')[1]);     //[1]取得value
                    obj[string_array[i].split('=')[0]] = string_array[i].split('=')[1] || '';
                    //沒有值就預設為''
                }
            }
            parsrQueryString(uri);
        });
        function GOSlideClear() {
            
             window.parent.SlideClear();
        }
        function callAUL() {
            $(".GG").attr('href', 'Pages/AUL.aspx?Icon=' + obj.i + "&w=100&h=100")
        }
        function callAUL2() {
            $("#APCover").attr('href', 'Pages/AUL.aspx?APCover=' + obj.i + '&w=640&h=1136');
        }
        function getlength(str) {
            var arr = str.match(/[^\x00-\xff]/ig);
            return (arr == null) ? str.length : str.length + arr.length;
        }
    </script>
</body>
</html>
