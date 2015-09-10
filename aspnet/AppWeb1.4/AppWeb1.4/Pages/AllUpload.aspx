<%@ Page Language="vb" AutoEventWireup="false" Debug="true" CodeBehind="p01_Edit.aspx.vb" Inherits="AppWeb1._4.p01_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../js/jquery-2.1.4.min.js"></script>
    <style>
        #finish {
            height: auto;
            width: auto;
            position: relative;
            color:pink;
            left:0;
            top: 0;
        }
        #topClick {
            top:186px;
            left:580px;
            background:url("../img/uploadicon.png")  no-repeat;
             height: 92px;
              width: 92px;
             opacity:0.3; 
             z-index:1;
             position:absolute;
        }
        #img01 {
            position:relative;
            top:0;
            left:0;
            z-index:-1;
        }


    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%;text-align:center;">
            <asp:FileUpload ID="FU" runat="server" CssClass="nosee" />
            <asp:Label ID="Msg" runat="server"></asp:Label>
            <div  style="width:300px;height:420px;margin:auto;overflow:hidden; ">
              <a href="#">
                  <div id="topClick"></div>
                <img id="Img01" runat="server" height="420" alt="" /></a>
                
            </div>
            <div>
                <asp:ImageButton ID="finish" ImageUrl="../img/finish.png" runat="server" />
            </div>
        </div>
    </form>
</body>
    <script>

        function getImgSize(input) {
            if (input.files && input.files[0]) { //判斷有無值
                var reader = new FileReader();      //建立Filereader()物件
                reader.onload = function (e) {
                    $("#Img01").attr("src", e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

        //$('#c').on('load', function () {
        //    alert($(this).width() + '*' + $(this).height());
        //});

        $("#FU").change(function () {  //上傳BAR
            getImgSize(this);
        });
    </script>
</html>
