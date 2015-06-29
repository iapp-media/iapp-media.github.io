<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AppWeb1._4._Default" %>
<!DOCTYPE html>
<html>

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>default</title>
    <link rel="stylesheet" href="0css/accomplish.css" />
    <link rel="stylesheet" href="0css/colorbox.css" />
<!-- <link href="0css/my.css" rel="stylesheet" /> -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script>
    function init() {
        $("#list").sortable({
            update: function() {
                dragSelector: "li",
                putin($(this).sortable('toArray'));
            }
        });
    }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
        <script>
        //// 透過PageRequestManager的物件，我們可以在add_pageLoaded的事件後重新註冊jQuery的方法內容
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_pageLoaded(init);
        </script>
        <div class="all">
            <!-- 
           <div id="UserInfo">
                歡迎您，親愛的
                <asp:Label ID="Label1" runat="server" Text="訪客"></asp:Label>
                <a href="logout.aspx">登出</a>
            </div>
             -->

            <!-- 左側區塊 -->
            <div id='pageNav'>
                <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <ul id="list">
                            <asp:Literal ID="L" runat="server"></asp:Literal>
                        </ul>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton2" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton3" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton4" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton5" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ImageButton6" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="DELE1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>

            <div class="content">

                <div class="phone">
                    <div class="show">
                        <!-- 標題 -->
                        <div class="smallbar">
                            <p style="color: #F19439;text-align: center;">您的iApp</p>
                        </div>
                        <!-- iframe顯示區域 -->
                        <div class="iframe">
                        <iframe src="Pages/p00.aspx" scrolling="no" id="midiframe" style="height: 100%; width: 100%; border:0px"></iframe>
                          <div id="MIDHIDE" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; cursor: pointer;" onclick="editmid()">
                          </div>
                        </div>
                    </div>
                    <!-- 分享/預覽 -->
                    <a href="#" id="preview"><img class="preview" src="0img/preview.png" height="33" width="89" onMouseOut="this.src='0img/preview.png'" onMouseOver="this.src='0img/preview2.png'" /></a>
                    <!-- 返回修改-最後完成頁時出現 -->
                    <a href="#" id="return"><div class="return hide"><img class="preview" src="0img/return-01.png" height="43" width="118" onMouseOut="this.src='0img/return-01.png'" onMouseOver="this.src='0img/return-02.png'" /></div></a>
                    <!-- 上一頁＆下一頁 -->
                    <a href="#" onclick="pagechange(-1)"><img class="up" src="0img/up.png" onMouseOut="this.src='0img/up.png'" onMouseOver="this.src='0img/up2.png'" /></a>
                    <a href="#" onclick="pagechange(1)"><img class="down" src="0img/down.png" onMouseOut="this.src='0img/down.png'" onMouseOver="this.src='0img/down2.png'" /></a>              
                </div>
                <!-- 增加 -->
                <a href="#" id="pageShow"><img class="add" src="0img/add.png" height="57" width="40" onMouseOut="this.src='0img/add.png'" onMouseOver="this.src='0img/add02.png'" /></a>
                <!-- 按下增加，呼叫select選擇區域 -->
                <div class="select hide">
                    <div class="pic1">
                        <div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
                            <asp:ImageButton ID="ImageButton1" CssClass="picture" runat="server" ImageUrl="~/0img/basic/p01-0s.jpg" CommandArgument="1" />
                        </div>
                        <p style="font-size: 5px;text-align: center;">單圖</p>
                    </div>
                    <div class="pic2">
                        <div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
                            <asp:ImageButton ID="ImageButton2" CssClass="picture" runat="server" ImageUrl="~/0img/basic/p02-0s.jpg" CommandArgument="2" />
                        </div>
                        <p style="font-size: 5px;text-align: center;">單圖下文字</p>
                    </div>
                    <div class="pic3">
                        <div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
                            <asp:ImageButton ID="ImageButton3" CssClass="picture" runat="server" ImageUrl="~/0img/basic/p03-0s.jpg" CommandArgument="3" />
                        </div>
                        <p style="font-size: 5px;text-align: center;">三格</p>
                    </div>
                    <div class="pic4">
                        <div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
                            <asp:ImageButton ID="ImageButton4" CssClass="picture" runat="server" ImageUrl="~/0img/basic/p04-0s.jpg" CommandArgument="4" />
                        </div>
                        <p style="font-size: 5px;text-align: center;">置中文字</p>
                    </div>
                    <div class="pic5">
                        <div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
                            <asp:ImageButton ID="ImageButton5" CssClass="picture" runat="server" ImageUrl="~/0img/basic/p05-0s.jpg" CommandArgument="5" />
                        </div>
                        <p style="font-size: 5px;text-align: center;">三圖分割</p>
                    </div>
                    <div class="pic6">
                        <div style="width: 85px;height: 125px;border-style: solid; border-width: 1px; border-color: #000000;}">
                            <asp:ImageButton ID="ImageButton6" CssClass="picture" runat="server" ImageUrl="~/0img/basic/p06-0s.jpg" CommandArgument="6" />
                        </div>
                        <p style="font-size: 5px;text-align: center;">右下文字</p>
                    </div>
                </div>
                <!-- iframe編輯區域 -->
                <div class="edit hide">
                  <a href="#" id="btpic"><img class="button-pic" src="0img/button-pic.png">
                  <a href="#" id="btword"><img class="button-wod" src="0img/button-word.png"></a>
                  <a href="#" id="fin"><img class="finish" src="0img/finish.png"></a>
                  <!-- 圖片編輯iframe -->
                    <iframe id="iframe" class="iframe-ed1" src="Pages/seeEdit.aspx">
                    </iframe>
                  <!-- 文字編輯iframe -->
                  <div class="edit2 hide">
                  <a href="#" id="fin"><img class="finish" src="0img/finish.png"></a>
                    <iframe id="iframe2" class="iframe-ed2" src="Pages/seeEdit.aspx">
                    </iframe>
                  </div>
                </div>

                <!-- 設定＆個人資料＆列表 -->
                <a class='iframe-info' href="profile.html"><img class="head" src="0img/head.png" /></a>
                <a class='iframe-info' href="list.html"><img class="list" src="0img/button1.png" /></a>
                <a class='iframe-info' href="setting.html"><img class="setting" src="0img/setting.png" /></a>
                <!-- 完成時候的結果頁面 -->
                <div class="final hide">
                    <div class="top"></div>
                    <div class="middle">
                        <img class="logo2" src="0img/logo2.png" />
                        <img src="0img/qrcode.jpg" style="position: absolute;top: 170px;left: 150px;">
                        <img src="0img/pic-22.png" style="position: absolute;top: 80px;left: 150px;">
                        <a href="#"><img src="0img/fbicon.png" style="position: absolute;top: 320px;left: 125px;"></a>
                        <a href="#"><img src="0img/copylink.png" style="position: absolute;top: 285px;left: 490px;"></a>
                        <div class="src">http://iapp-media.com/</div>
                    </div>
                    <div class="bottom"></div>
                </div>
                <!-- logo＆company tiltle -->
                 <img class="logo" src="0img/bgimg.png" />
                <div style="position: fixed; top: 620px;right: 10px;">
                  <img src="0img/logo-digital.png" border="0">
                </div>
            </div>

            <!-- 
            <div id="funcdiv">
                <div id="btnMore">
                    <a href="#" id="pageShow">加入頁面按鈕</a>
                </div>

                <div id="btnLast">
                    <a href="#" onclick="pagechange(-1)">上一頁</a>
                </div>
                <div id="btnNext">
                    <a href="#" onclick="pagechange(1)">下一頁</a>
                </div>
            </div>
            <div id="rightdv">
                <div id="tab">
                    <ul id="Test">
                        <li>
                            </li>
                        <li>
                            </li>
                        <li>
                            <asp:ImageButton ID="ImageButton33" CssClass="pagebtn" runat="server" Height="120px" ImageUrl="~/images/3.jpg" Width="140px" CommandArgument="3" /></li>
                        <li>
                            <asp:ImageButton ID="ImageButton34" CssClass="pagebtn" runat="server" Height="120px" ImageUrl="~/images/4.jpg" Width="140px" CommandArgument="4" /></li>
                        <li>
                            <asp:ImageButton ID="ImageButton35" CssClass="pagebtn" runat="server" Height="120px" ImageUrl="~/images/5.jpg" Width="140px" CommandArgument="5" /></li>
                        <li>
                            <asp:ImageButton ID="ImageButton36" CssClass="pagebtn" runat="server" Height="120px" ImageUrl="~/images/6.jpg" Width="140px" CommandArgument="6" /></li>
                    </ul>
                </div>
            </div>
             //-->
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="La" runat="server" Text="Label" CssClass="nosee"></asp:Label>
                <asp:TextBox ID="AA" runat="server" CssClass="nosee"></asp:TextBox>
                <asp:TextBox ID="DELEID" runat="server" CssClass="nosee"></asp:TextBox>
                <asp:LinkButton ID="DELE1" runat="server"></asp:LinkButton>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
    </form>

    <script src="0js/jquery-2.1.4.min.js"></script>
    <script src="0js/jquery-ui.js"></script> <!-- 有min版本的話換掉 -->
    <script src="0js/jquery.colorbox-min.js"></script>

    <script>
    $(document).ready(function() {
        //Examples of how to assign the Colorbox event to elements
        $(".iframe-info").colorbox({
            iframe: true,
            width: "55%",
            height: "85%"
        });
        $(".callbacks").colorbox({
            onOpen: function() {
                alert('onOpen: colorbox is about to open');
            },
            onLoad: function() {
                alert('onLoad: colorbox has started to load the targeted content');
            },
            onComplete: function() {
                alert('onComplete: colorbox has displayed the loaded content');
            },
            onCleanup: function() {
                alert('onCleanup: colorbox has begun the close process');
            },
            onClosed: function() {
                alert('onClosed: colorbox has completely closed');
            }
        });
    });
</script>

</body>
<script>
var c = 0;
var page_id = 0;

function show(str, id) {
    page_id = id;
    document.getElementById("midiframe").src = str;
    $(".edit").hide();
    for (var i = 0; i <= $("#list").sortable('toArray').length; i++) //判斷使用者目前點到哪一頁
    {
        if (($("#list").sortable('toArray')[i]).toString().replace("s", "") == id) {
            c = i; //當前頁數上下頁功能使用
        }
    }

}

function editmid() {
    str = "Pages/seeEdit.aspx?ID=" + page_id;
    document.getElementById("Iframe").src = str;
}


$(document).ready(function() {
    $("#pageShow").click(function() {
        $(".select").animate({
            width: 'toggle'
        }, 350);
        $(".edit").hide();
    });
    $("#preview").click(function() {
        $(".final").animate({
            width: 'toggle'
        }, 350);
        $(".edit").hide();
        $(".select").hide();
        $(".logo").hide();
        $("#pageNav").hide();
        $(".return").show();
        $(".final").show();
    });
    $("#return").click(function() {
        $(".final").animate({
            width: 'toggle'
        }, 350);
        $(".edit").hide();
        $(".select").show();
        $("#pageNav").show();
        $(".logo").show();
        $(".return").hide();
        $(".final").hide();
    });

});

function pagechange(a) {
    c = c + a;
    if (c < 0) {
        alert(c + "No Page");
        c = 0;

    } else if (c >= $("#list").sortable('toArray').length) {
        alert(c + "Page Over");
        c = c - 1;
    } else {
        document.getElementById("midiframe").src = "Pages/see.aspx?ID=" + ($("#list").sortable('toArray')[c]).toString().replace("s", "");
        //document.getElementById("midiframe").src = "Pages/see.aspx?ID=" + ($("#list").sortable('toArray')[c]).toString().replace("s", "");

    }
}

function putin(a) {
    document.getElementById("AA").value = a;

    //alert(document.getElementById("AA").value);
}

function putDELE(a) {
        document.getElementById("DELEID").value = a;
    }
    //$(function () {
    //    $("#list").dragsort({ dragSelector: "a" });
    //});
$(document).ready(function() {
    $("#MIDHIDE").click(function() {
        $("#rightdv").hide();
        $(".edit").show();
        $(".edit2").hide();
    });
    $("#btword").click(function() {
        $(".edit2").show();
    });
    $("#btpic").click(function() {
        $(".edit2").hide();
        $(".edit1").show();
    });
    // $("#preview").click(function() {
    //     $(".edit2").hide();
    //     $(".edit1").hide();
    //     $(".final").show();
    // });
});
</script>

</html>
