<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wordEdit.aspx.vb" Inherits="AppWeb1._4.wordEdit" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <link rel="stylesheet" type="text/css" href="../css/reset.css">
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.1/themes/ui-lightness/jquery-ui.css">
    <link href="../css/evol.colorpicker.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="../css/edit-text.css">
     
</head>

<body>
    <form id="form1" runat="server">
<%--        <asp:TextBox ID="txtEditor" CssClass="txtEditor" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
        <asp:Literal ID="LTextED" runat="server"></asp:Literal>
        <div class="chkstyle1">
            <input type="checkbox" name="radio" id="radio1" class="radio" />
            <label for="radio1">粗體</label>
        </div>
        <div class="chkstyle2">
            <input type="checkbox" name="radio" id="radio2" class="radio" />
            <label for="radio2">斜體</label>
        </div>
        <div class="chkstyle3">
            <input type="checkbox" name="radio" id="radio3" class="radio" />
            <label for="radio3">底線</label>
        </div> 
        <div class="show-color">
            <input id="mycolor" />
            <p style="float: right;  ">色彩</p>
        </div>

     <%--   <div class="send">
            <p>--%>
                <asp:LinkButton ID="send" runat="server" OnClientClick="docopy()" OnClick="send_Click" CssClass="send"></asp:LinkButton><%--完成--%>
     <%--       </p>
        </div>--%>
        <asp:TextBox ID="EDval" runat="server" BorderStyle="None" Font-Size="XX-Small" ForeColor="#FDFDFD" BackColor="#FDFDFD"></asp:TextBox>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js" type="text/javascript" charset="utf-8"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.1/jquery-ui.min.js" type="text/javascript" charset="utf-8"></script>
        <script src="../js/evol.colorpicker.min.js" type="text/javascript" charset="utf-8"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#mycolor").colorpicker({
                    color: "#c3c3c3",
                    defaultPalette: 'theme',
                    displayIndicator: false,
                    hideButton: false,
                    history: false,
                });
            });
        </script>
        <script>
            var texttmp = $("#txtEditor").val(); 
            $("#EDval").hide();
          
            function words_deal(cct) {
                var curLength = getlength($("#txtEditor").val());
                if (curLength > cct) {
                    document.getElementById('txtEditor').value = texttmp;
                    alert("超過字數限制，多出的字將被移除！");
                } else { 
                    texttmp = $("#txtEditor").val(); 
                }
            }
            function getlength(str) {
                var arr = str.match(/[^\x00-\xff]/ig);
                return (arr == null) ? str.length : str.length + arr.length;
            }
            function docopy() {
                $("#EDval").show(); 
                document.getElementById('EDval').value = texttmp;
               //  alert(tans);
            }
        </script>
    </form>
</body>

</html>




