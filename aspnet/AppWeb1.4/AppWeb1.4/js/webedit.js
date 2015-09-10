
 
$(document).ready(function () {

        $("#btword").click(function () {
            // $(".edit2").show(); class="iframe-ed2"
            //$("#iframe-ed1").removeClass""
        });
        $("#btpic").click(function () {
            $(".edit2").hide();
            $(".edit").show();
        });

        //Examples of how to assign the Colorbox event to elements
        $(".iframe-info").colorbox({
            iframe: true,
            width: "700px",
            height: "600px"
        });
        $(".callbacks").colorbox({
            onOpen: function () {
                alert('onOpen: colorbox is about to open');
            },
            onLoad: function () {
                alert('onLoad: colorbox has started to load the targeted content');
            },
            onComplete: function () {
                alert('onComplete: colorbox has displayed the loaded content');
            },
            onCleanup: function () {
                alert('onCleanup: colorbox has begun the close process');
            },
            onClosed: function () {
                alert('onClosed: colorbox has completely closed');
            }
        });
    });

 
        var c = 0;
    var page_id = 0
    function RDefault() {
        $(".edit").hide();
        $(".select").hide();
        $(".logo").hide();
        $(".final").hide();
        $(".logo").show(); 
    }

    function show(str, id) {

        page_id = id;
        // alert(id);
        //document.getElementById("midiframe").src = "Pages/see.aspx?edit=1&ID=" + page_id;
        document.getElementById("iframe-ed1").src = "Pages/see.aspx?edit=1&ID=" + page_id;
        document.getElementById("midiframe").src = str;
        //str = "Pages/seeEdit.aspx?ID=" + page_id;
        //document.getElementById("iframe-ed1").src = str;

        for (var i = 0; i <= $("#list").sortable('toArray').length; i++) //判斷使用者目前點到哪一頁
        {
            $("#list>li:nth-child(" + (i + 1) + ")").removeClass("active");
            if (($("#list").sortable('toArray')[i]).toString().replace("s", "") == id) { 
                c = i; //當前頁數上下頁功能使用
                $("#list>li:nth-child(" + (i + 1) + ")").addClass("active");
            }
            
            
        }
        
    }

    function ChangeEditUrl(id, thisPageUrl, Img) {
        //alert(id);
      
        var HH = 1136;
        var WD = 640;
        switch (thisPageUrl) {
            case "p03.aspx":
                HH = 378;
                break;
            case "/basicp03.aspx":
                HH = 378;
                break;
            case "p04.aspx":
                HH = 568;
                if (Img == 2 || Img == 3) {
                    WD = 320;
                }
                break;
            case "/basicp04.aspx":
                HH = 568;
                if (Img == 2 || Img == 3) {
                    WD = 320;
                }
                break; 
        }
       
        document.getElementById("iframe-ed1").src = "Pages/AUL.aspx?UPID=" + id + "&Page=" + thisPageUrl + "&Img=" + Img + "&w=" + WD + "&h=" + HH;
    }

    function ChangeEditWD(id, thisPageUrl, text) {
        //alert(id);
        document.getElementById("iframe-ed1").src = "Pages/wordEdit.aspx?UPID=" + id + "&Page=" + thisPageUrl + "&text=" + text;
    }

    function forcus() { 
        var $div = $('#pageNav');
        $div.scrollTop($div[0].scrollHeight)
    }

    function forcusTOP() {
        //增加forcus() 刪掉forcusTOP() 手機畫面跳轉第一個
        document.getElementById("midiframe").src = "pages/cover.htm";
        c = 0;
        $(".edit").hide();

        var $div = $('#pageNav');
        $div.scrollTop($div[0].scrollTop);

    }

    //function editmid() {
    //    str = "Pages/seeEdit.aspx?ID=" + page_id;
    //    document.getElementById("iframe-ed1").src = str;
    //}

    $(document).ready(function () {
        $("#pageShow").click(function () {
            $(".select").animate({
                width: 'toggle'
            }, 350);
            $(".edit").hide();
        });
        $(".demonstrate").click(function () {
            $(".demonstrate").hide();
        });
        $("#preview").click(function () {
                 document.getElementById("iframe-set").src = document.getElementById("iframe-set").src; 
            $("#iappgb").hide();
            $(".edit").hide();
            $(".select").hide();
            $("#MIDHIDE").hide();
            $(".logo").hide();
            $(".preview").hide();
            $("#pageNav").hide();
            $(".add").hide();
            $(".return").show();
            $(".publish-btn").show();
            $(".logo").show();
        });
        $("#return").click(function () {
            $("#iappgb").show();
            $(".edit").hide();
            $(".select").show();
            $("#pageNav").show();
            $("#MIDHIDE").show();
            $(".add").show();
            $(".logo").show();
            $(".return").hide();
            $(".final").hide();
            $(".publish-btn").hide();
            $(".publish").hide();
            $(".preview").show();
            //document.getElementById("midiframe").src = "Pages/see.aspx";
            document.getElementById("midiframe").src = "pages/cover.htm";
            c = 0;
        });
        $("#publish-btn").click(function () {
            $(".publish").show();
        });
        $("#close").click(function () {
            $(".edit").hide();
            $(".select").hide();
            $(".logo").hide();
            $(".final").hide();
            $(".logo").show();

            //open editface
            $(".select").show();
        });
        $("#close-select").click(function () {
            $(".select").hide();
        });
        $("#close-publish").click(function () {
            $(".publish").hide();
        });
        $("#send").click(function () {
            sended();
        });

        var openOption = 'width=400,height=400';
        $("#sharefb").click(function () {
            SendAjax('http://www.iapp-media.com/act/share.aspx?to=2&i=' + getQValue("i"));
            window.open('https://www.facebook.com/sharer.php?u=' + $("#final").text(), '_blank', openOption);
        });

        $("#sharetwitter").click(function () {
            SendAjax('http://www.iapp-media.com/act/share.aspx?to=2&i=' + getQValue("i"));
            window.open('http://twitter.com/intent/tweet?text=' + $("#final").text(), '_blank', openOption);
        });

        $("#shareline").click(function () {
            SendAjax('http://www.iapp-media.com/act/share.aspx?to=3&i=' + getQValue("i"));
            window.open('http://line.naver.jp/R/msg/text/?' + $("#final").text(), '_blank', openOption);
        });



    });
    function FBShareCK() {
        SendAjax('http://www.iapp-media.com/act/share.aspx?to=2&i=' + getQValue("i"));
        window.open('https://www.facebook.com/sharer.php?u=' + $("#final").text(), '_blank', 'width=400,height=400');
    }

    function sended() {
        $(".final").animate({
            width: 'toggle'
        }, 350);
        $(".publish").hide();
        $(".final").show();
    }
    function SlideClear() {
        c = 0;
    }
    function pagechange(a) {
        c = c + a;
        if (c < 0) {
            alert('已經到第一頁了!!');
            c = -1;
        } else if (c == 0) {
            document.getElementById("midiframe").src = "Pages/cover.htm";
        } else if (c > $("#list").sortable('toArray').length) {
            alert('已經到最後第一頁了!!');
            c = c - 1;
            //alert("c >=" + $("#list").sortable('toArray').length);
        } else {
            document.getElementById("midiframe").src = "Pages/see.aspx?ID=" + ($("#list").sortable('toArray')[c - 1]).toString().replace("s", "");
            //document.getElementById("iframe-ed1").src = "Pages/seeEdit.aspx?ID=" + ($("#list").sortable('toArray')[c - 1]).toString().replace("s", "");
            //document.getElementById("midiframe").src = "Pages/see.aspx?ID=" + ($("#list").sortable('toArray')[c]).toString().replace("s", "");

        }
    }

    function putin(a) {
        document.getElementById("AA").value = a;

        for (i = 0; i < a.length; i++) {
            $("#" + a[i] + " .num").html("第" + (i + 1) + "頁");
        }
        __doPostBack('SavSort', '');
    }

    function postit() {
        $.ajax({
            type: 'post',
            url: 'makeHtml.aspx',
            success: function (preUrl) {
                //alert(preUrl);
                document.getElementById("midiframe").src = preUrl + ".html?a=1";
                $("#Qrimg").attr("src", "QRcode.ashx?t=" + preUrl);      // 接收makehtml 回傳直做成QRCODE
                $("#final").html(preUrl); // 接收makehtml 回傳給分享網址的欄位
                //$("#copylink").attr("onclick", "window.clipboardData.setData('Text', '" + preUrl + "');alert('" + preUrl + "');");
            },
            error: function () {
                alert("postit error ,連線逾時，請重新登入。");
                //location.href = 'login.aspx';
            }
        });
    }


    function putDELE(a) {
        document.getElementById("DELEID").value = a;
    }
    //$(function () {
    //    $("#list").dragsort({ dragSelector: "a" });
    //});
    $(document).ready(function () {
        $("#MIDHIDE").click(function () {
            $("#rightdv").hide();
            $(".edit").show();
            $(".edit2").hide();
        });
        $("#btword").click(function () {
            $(".edit2").show();
        });
        $("#btpic").click(function () {
            $(".edit2").hide();
            $(".edit1").show();
        });
        // $("#preview").click(function() {
        //     $(".edit2").hide();
        //     $(".edit1").hide();
        //     $(".final").show();
        // });
    });
     
    function ref() {
        location.reload();
    }


    function getQValue(varname) {
        var url = window.location.href;
        var qparts = url.split("?");
        if (qparts.length <= 1) {
            return "";
        } else {
            var query = qparts[1];
            var vars = query.split("&amp;");
            var value = "";
            for (i = 0; i < vars.length; i++) {
                var parts = vars[i].split("=");
                if (parts[0] == varname) {
                    value = parts[1];
                    break;
                }
            }
            value = unescape(value);
            value.replace(/\+/g, " ").replace("#", "");
            return value;
        }
    }

    function SendAjax(sendurl) {
        var result = '';
        $.ajax({
            type: 'GET',
            url: sendurl,
            success: function (w) { 
                return 'success';
            },
            error: function () {
                return 'err';
            }
        });
    } 